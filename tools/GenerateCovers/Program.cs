// Hugo page-bundle cover.jpg generator using SkiaSharp (see content/blog/SkiaSharp/cover.md).
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SkiaSharp;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

const int Width = 720;
const int Height = 220;
const float TitleMaxFrac = 0.92f;
const float SubtitleMaxFrac = 0.88f;
const float Padding = 20f;
const float TitleSizeStart = 44f;
const float SubtitleSize = 22f;
const float TitleSizeMin = 22f;
const int SubtitleMaxWords = 4;

var dryRun = args.Any(a => a.Equals("--dry-run", StringComparison.Ordinal));
var force = args.Any(a => a.Equals("--force", StringComparison.Ordinal));
var roots = args.Where(a => !a.StartsWith("-", StringComparison.Ordinal)).ToList();
if (roots.Count == 0)
    roots = [Path.Combine(FindRepoRoot(), "content")];

var skipNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
{
    "_index.md", "archives.md", "search.md",
};

var deserializer = new DeserializerBuilder()
    .WithNamingConvention(NullNamingConvention.Instance)
    .IgnoreUnmatchedProperties()
    .Build();

var ok = 0;
var dry = 0;
var skip = 0;

foreach (var root in roots.Select(Path.GetFullPath))
{
    if (!Directory.Exists(root))
    {
        Console.Error.WriteLine($"Not a directory: {root}");
        return 1;
    }

    foreach (var path in Directory.EnumerateFiles(root, "*.md", SearchOption.AllDirectories).OrderBy(p => p, StringComparer.Ordinal))
    {
        var fileName = Path.GetFileName(path);
        if (skipNames.Contains(fileName))
        {
            skip++;
            continue;
        }

        var (status, msg) = ProcessFile(path, dryRun, force, deserializer);
        switch (status)
        {
            case "skip":
                skip++;
                break;
            case "dry-run":
                dry++;
                Console.WriteLine($"[dry-run] {Path.GetRelativePath(FindRepoRoot(), path)}: {msg}");
                break;
            case "ok":
                ok++;
                Console.WriteLine($"[ok] {Path.GetRelativePath(FindRepoRoot(), path)}: {msg}");
                break;
        }
    }
}

Console.WriteLine($"Done. ok={ok} dry-run={dry} (skipped {skip} files)");
return 0;

static string FindRepoRoot()
{
    var dir = new DirectoryInfo(Environment.CurrentDirectory);
    while (dir != null)
    {
        if (Directory.Exists(Path.Combine(dir.FullName, "content")))
            return dir.FullName;
        dir = dir.Parent;
    }
    throw new InvalidOperationException("Could not find a directory containing 'content'. Run from the repo root.");
}

static (string Status, string Msg) ProcessFile(
    string path,
    bool dryRun,
    bool force,
    IDeserializer deserializer)
{
    var text = File.ReadAllText(path);
    var split = SplitFrontMatter(text);
    if (split is null)
        return ("skip", "no front matter");

    var (fmRaw, body) = split.Value;

    Dictionary<string, object> data;
    try
    {
        data = deserializer.Deserialize<Dictionary<string, object>>(fmRaw) ?? [];
    }
    catch
    {
        return ("skip", "yaml parse error");
    }

    var stem = Path.GetFileNameWithoutExtension(path);
    var bundleCover = Path.Combine(Path.GetDirectoryName(path)!, stem, "cover.jpg");

    if (!ShouldProcess(data, bundleCover, force, out var reason))
        return ("skip", reason);

    var title = StripTitle(data.GetValueOrDefault("title")?.ToString() ?? stem);
    var desc = data.GetValueOrDefault("description")?.ToString() ?? "";

    var target = CoverImageTarget(data);
    var needFm = target != "cover.jpg";
    var needRender = force || !File.Exists(bundleCover);

    if (dryRun)
    {
        var parts = new List<string>();
        if (needRender)
            parts.Add($"would write {bundleCover}");
        if (needFm)
            parts.Add("update front matter image");
        return ("dry-run", parts.Count > 0 ? string.Join("; ", parts) : "no-op");
    }

    if (needRender)
        RenderCover(title, desc, bundleCover);

    if (needFm)
    {
        var newFm = EnsureCoverImageInFm(fmRaw);
        File.WriteAllText(path, JoinFrontMatter(newFm, body), new UTF8Encoding(false));
    }

    var msgParts = new List<string>();
    if (needRender)
        msgParts.Add($"wrote {bundleCover}");
    if (needFm)
        msgParts.Add("updated front matter");
    return ("ok", string.Join("; ", msgParts));
}

static bool ShouldProcess(Dictionary<string, object> data, string bundleCover, bool force, out string reason)
{
    if (!data.TryGetValue("cover", out var coverObj) || coverObj is null)
    {
        reason = "no cover block";
        return false;
    }

    var coverDict = AsStringKeyedDict(coverObj);
    if (coverDict is null)
    {
        reason = "no cover block";
        return false;
    }

    var target = CoverImageTargetFromDict(coverDict);
    if (target is not null && target != "cover.jpg")
    {
        reason = $"custom image '{target}'";
        return false;
    }

    var needFm = target != "cover.jpg";
    var needRender = force || !File.Exists(bundleCover);
    if (!needRender && !needFm)
    {
        reason = "exists";
        return false;
    }

    reason = "process";
    return true;
}

static string? CoverImageTarget(Dictionary<string, object> data)
{
    if (!data.TryGetValue("cover", out var coverObj) || coverObj is null)
        return null;
    var d = AsStringKeyedDict(coverObj);
    return d is null ? null : CoverImageTargetFromDict(d);
}

static string? CoverImageTargetFromDict(Dictionary<string, object> coverDict)
{
    if (!coverDict.TryGetValue("image", out var img) || img is null)
        return null;
    var s = img.ToString()?.Trim().Trim('"').Trim('\'');
    return string.IsNullOrEmpty(s) ? null : s;
}

static Dictionary<string, object>? AsStringKeyedDict(object? o)
{
    switch (o)
    {
        case Dictionary<string, object> ds:
            return ds;
        case Dictionary<object, object> dod:
            return dod.ToDictionary(kv => kv.Key.ToString()!, kv => kv.Value);
        default:
            return null;
    }
}

static string StripTitle(string s)
{
    s = s.Trim();
    if (s.Length >= 2 &&
        ((s[0] == '"' && s[^1] == '"') || (s[0] == '\'' && s[^1] == '\'')))
        return s[1..^1];
    return s;
}

static (string Fm, string Body)? SplitFrontMatter(string text)
{
    if (!text.StartsWith("---\n", StringComparison.Ordinal))
        return null;
    var end = text.IndexOf("\n---\n", 4, StringComparison.Ordinal);
    if (end < 0)
        return null;
    var fm = text[4..end];
    var body = text[(end + 5)..];
    return (fm, body);
}

static string JoinFrontMatter(string fm, string body) => "---\n" + fm + "\n---\n" + body;

static string EnsureCoverImageInFm(string fmRaw)
{
    var lines = fmRaw.Split('\n');
    var outLines = new List<string>();
    var i = 0;
    while (i < lines.Length)
    {
        var line = lines[i];
        if (CoverRegex.CoverLine.IsMatch(line))
        {
            outLines.Add(line);
            i++;
            var block = new List<string>();
            while (i < lines.Length && (lines[i].StartsWith(' ') || lines[i].StartsWith('\t')))
            {
                block.Add(lines[i]);
                i++;
            }

            var newBlock = new List<string>();
            var seenImage = false;
            foreach (var bl in block)
            {
                var stripped = bl.TrimStart();
                if (CoverRegex.CommentedImage.IsMatch(stripped))
                {
                    if (!seenImage)
                    {
                        var indent = Regex.Match(bl, @"^(\s*)").Groups[1].Value;
                        if (string.IsNullOrEmpty(indent))
                            indent = "    ";
                        newBlock.Add($"{indent}image: \"cover.jpg\"");
                        seenImage = true;
                    }
                    continue;
                }

                if (CoverRegex.ImageLine.IsMatch(stripped) && !stripped.StartsWith('#'))
                    seenImage = true;
                newBlock.Add(bl);
            }

            if (!seenImage)
                newBlock.Insert(0, "    image: \"cover.jpg\"");
            outLines.AddRange(newBlock);
            continue;
        }

        outLines.Add(line);
        i++;
    }

    var sb = string.Join("\n", outLines);
    if (fmRaw.EndsWith("\n", StringComparison.Ordinal))
        sb += "\n";
    return sb;
}

static void RenderCover(string title, string description, string outPath)
{
    Directory.CreateDirectory(Path.GetDirectoryName(outPath)!);

    using var bmp = new SKBitmap(Width, Height);
    using var canvas = new SKCanvas(bmp);
    canvas.Clear(SKColor.Parse("#003366"));

    var titleFace = SKTypeface.FromFamilyName("Arial", new SKFontStyle(SKFontStyleWeight.Bold, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright))
                  ?? SKTypeface.Default;

    using var paint = new SKPaint
    {
        IsAntialias = true,
        Color = SKColors.White,
        Style = SKPaintStyle.Fill,
    };

    var maxTitleW = Width * TitleMaxFrac;
    var titleSize = TitleSizeStart;
    using var titleFont = new SKFont(titleFace, titleSize);
    while (titleSize >= TitleSizeMin)
    {
        titleFont.Size = titleSize;
        titleFont.MeasureText(title, out var bounds);
        if (bounds.Width <= maxTitleW)
            break;
        titleSize -= 2f;
    }

    titleFont.Size = Math.Max(titleSize, TitleSizeMin);
    titleFont.MeasureText(title, out _);
    var fm = titleFont.Metrics;
    var titleBlockHeight = fm.Descent - fm.Ascent;
    var baselineY = Height / 2f - titleBlockHeight / 2f - fm.Ascent;

    canvas.DrawText(title, Width / 2f, baselineY, SKTextAlign.Center, titleFont, paint);

    var descTrim = description.Trim();
    if (descTrim.Length > 0)
    {
        var subFace = SKTypeface.FromFamilyName("Arial", new SKFontStyle(SKFontStyleWeight.Bold, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright))
                      ?? SKTypeface.Default;
        using var subFont = new SKFont(subFace, SubtitleSize);
        var sub = TruncateSubtitle(LimitWords(descTrim, SubtitleMaxWords), subFont, Width * SubtitleMaxFrac);
        var sy = Height - Padding - subFont.Metrics.Descent;
        var sx = Width - Padding;
        canvas.DrawText(sub, sx, sy, SKTextAlign.Right, subFont, paint);
    }

    using var img = SKImage.FromBitmap(bmp);
    using var data = img.Encode(SKEncodedImageFormat.Jpeg, 92);
    using var fs = File.OpenWrite(outPath);
    data.SaveTo(fs);
}

static string LimitWords(string text, int maxWords)
{
    if (maxWords <= 0 || string.IsNullOrWhiteSpace(text))
        return string.Empty;
    var words = Regex.Split(text.Trim(), @"\s+");
    if (words.Length <= maxWords)
        return string.Join(" ", words);
    return string.Join(" ", words.Take(maxWords));
}

static string TruncateSubtitle(string text, SKFont font, float maxWidth)
{
    font.MeasureText(text, out var b);
    if (b.Width <= maxWidth)
        return text;

    const string ell = "…";
    while (text.Length > 1)
    {
        text = text[..^1].TrimEnd();
        var candidate = text + ell;
        font.MeasureText(candidate, out b);
        if (b.Width <= maxWidth)
            return candidate;
    }

    return ell;
}

internal static class CoverRegex
{
    internal static readonly Regex CoverLine = new(@"^cover:\s*$", RegexOptions.Compiled);
    internal static readonly Regex CommentedImage = new(@"^#\s*image:\s*", RegexOptions.Compiled);
    internal static readonly Regex ImageLine = new(@"^image:\s*", RegexOptions.Compiled);
}
