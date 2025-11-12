---
title: "Prepare for Java Interview"
author: "Aayush Bhardwaj"
weight: 110
date: 2025-11-12
lastmod: 2025-11-12
dateString: November 2025  
description: "General Question"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "codefrydev", "Java", "CFD"]
keywords: [ "codefrydev", "Java", "CFD"]
---

title: "Prepa## Collections Framework Deep Dive

### 1️⃣ Why does HashMap allow one null key but Hashtable doesn't?

**Short Answer:** HashMap was designed for modern multi-threaded applications with null-safe design; Hashtable predates this and was optimized for thread-safety by rejecting nulls outright.

**Detailed Explanation:**

Hashtable uses the `hashCode()` method on every key. If you pass null, it throws a `NullPointerException` immediately—no comparison, no storage. This is intentional: it forces you to know your data upfront.

HashMap, being newer (Java 1.2+), allows null keys and values. It handles null by treating it as a special case:

```java
// Internally, HashMap does something like this:
static final int hash(Object key) {
    int h;
    return (key == null) ? 0 : (h = key.hashCode()) ^ (h >>> 16);
}
```

When key is null, it computes hash as 0 and stores it in bucket 0. There's only one null key slot, so you get one null key maximum.

**Why this matters:**
- **Hashtable (legacy):** Fail-fast approach—null is an error, catch it early.
- **HashMap (modern):** Permissive approach—handle nulls gracefully in code.

**Code Example:**
```java
HashMap<String, Integer> map = new HashMap<>();
map.put(null, 1);  // ✅ Works
map.put("key", 2); // ✅ Works

Hashtable<String, Integer> table = new Hashtable<>();
table.put(null, 1); // ❌ NullPointerException
```

---

### 2️⃣ What happens internally when we call put() in a HashMap?

**Short Answer:** HashMap computes the hash of the key, finds the bucket, then either inserts a new entry or updates an existing one.

**Step-by-Step Process:**

1. **Hash Calculation:** Calls `hash(key)` to get a hash code.
2. **Bucket Index:** Uses `hash & (capacity - 1)` to find the bucket (fast modulo using bitwise AND).
3. **Traverse Chain:** If using separate chaining (internal to HashMap via linked lists or red-black trees), traverse to find the key.
4. **Insert or Update:** If key exists, update value; if not, create new Node and insert.
5. **Resize Check:** If size exceeds load factor (default 0.75), resize the array.

**Code Walkthrough:**
```java
HashMap<String, Integer> map = new HashMap<>();
map.put("name", 25);

// Internally:
// 1. hash("name") → 3573285 (or similar)
// 2. index = 3573285 & (16 - 1) = 5 (initial capacity is 16)
// 3. bucket[5]: if null, create new entry; if occupied, traverse chain
// 4. entry = new Node("name", 25, hash)
// 5. Check: size=1, capacity=16, 1 > 16*0.75? No, no resize.
```

**Resize Logic:**
```java
// When size exceeds threshold:
if (++size > threshold) {
    resize(); // New capacity = old capacity * 2
    // All existing entries re-hashed and redistributed
}
```

**Key Insight:** HashMap trades memory (larger array) for speed (O(1) average lookup). Resizing is expensive but infrequent—amortized O(1).

---

### 3️⃣ How does a Set actually prevent duplicates?

**Short Answer:** Sets use `equals()` and `hashCode()` methods. Two objects are duplicates if `equals()` returns true for them.

**How It Works:**

When you add an element to a HashSet:

```java
HashSet<String> set = new HashSet<>();
set.add("apple");
set.add("apple"); // Won't be added; size stays 1

// Internally:
// 1. hash("apple") → some value
// 2. Check if element with same hash already exists
// 3. If yes, call equals() to confirm it's the same object
// 4. If equals() returns true, skip adding (duplicate)
// 5. If equals() returns false, add it (hash collision, different object)
```

**Code Example with Custom Objects:**

```java
public class Student {
    private int id;
    private String name;
    
    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        Student student = (Student) obj;
        return id == student.id && Objects.equals(name, student.name);
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(id, name);
    }
}

// Usage:
Set<Student> students = new HashSet<>();
students.add(new Student(1, "Alice"));
students.add(new Student(1, "Alice")); // Won't add; duplicate
```

**TreeSet (Order-Based):**
```java
TreeSet<String> set = new TreeSet<>();
set.add("apple");
set.add("apple"); // Won't add; uses compareTo() instead of hashCode()
```

---

### 4️⃣ What's the difference between fail-fast and fail-safe iterators?

**Short Answer:**
- **Fail-fast:** Throws `ConcurrentModificationException` if collection is modified during iteration.
- **Fail-safe:** Creates a copy; safe to modify original collection during iteration (but you iterate over old data).

**Fail-Fast Example (HashMap, ArrayList):**

```java
List<String> list = new ArrayList<>(Arrays.asList("a", "b", "c"));

for (String item : list) {
    if (item.equals("b")) {
        list.remove("b"); // ❌ ConcurrentModificationException!
    }
}

// Iterator tracks expected modification count (modCount)
// When list is modified, modCount changes → exception thrown
```

**Fail-Safe Example (CopyOnWriteArrayList, ConcurrentHashMap):**

```java
List<String> list = new CopyOnWriteArrayList<>(Arrays.asList("a", "b", "c"));

for (String item : list) {
    if (item.equals("b")) {
        list.remove("b"); // ✅ Works! Iterates over snapshot
    }
}
// Iterator is based on a snapshot; safe to modify original
```

**Why Fail-Fast?**
- Catches bugs early—helps you find concurrent modification issues.
- Better performance (no copying overhead).

**Why Fail-Safe?**
- Multi-threaded environments where locks are expensive.
- Trade-off: memory overhead and slightly stale data.

---

### 5️⃣ How does TreeMap maintain its order?

**Short Answer:** TreeMap uses a **Red-Black Tree** (a self-balancing binary search tree). Keys are kept sorted by natural order or a custom `Comparator`.

**How It Works:**

```java
TreeMap<String, Integer> map = new TreeMap<>();
map.put("zebra", 1);
map.put("apple", 2);
map.put("mango", 3);

// Internally: Red-Black Tree structure
//         mango
//        /      \
//     apple    zebra
//
// Iteration order: apple → mango → zebra (ascending)
```

**Properties:**
- **O(log n) operations:** Put, get, remove all take logarithmic time (balanced tree).
- **Sorted:** Iterating keys always returns in sorted order.
- **Comparable or Comparator:** Keys must be comparable.

**Custom Ordering:**

```java
// Sort by string length, then alphabetically
TreeMap<String, Integer> map = new TreeMap<>(
    (s1, s2) -> {
        if (s1.length() != s2.length()) {
            return s1.length() - s2.length();
        }
        return s1.compareTo(s2);
    }
);

map.put("apple", 1);   // length 5
map.put("car", 2);     // length 3
map.put("balloon", 3); // length 7

// Iteration: car → apple → balloon
```

**When to Use:**
- Need sorted keys with guaranteed order.
- Range queries (e.g., `tailMap()`, `headMap()`).
- Avoid if you only care about speed; HashMap is faster for non-sorted data.

---

### 6️⃣ Why is ConcurrentHashMap faster than Hashtable?

**Short Answer:** ConcurrentHashMap uses **segmentation** (bucket-level locks) instead of full table locks. Multiple threads can access different segments simultaneously.

**Hashtable (Full Lock):**

```java
// Entire table locked for any operation
public synchronized V put(K key, V value) { ... }
public synchronized V get(Object key) { ... }

// If 10 threads try to access different buckets:
// Only 1 thread works; others wait.
```

**ConcurrentHashMap (Segment Locks):**

```java
// Modern implementation uses fine-grained locks (since Java 8, uses CAS + Locks)
// Each segment of the table has its own lock

// If 10 threads access different segments:
// 10 threads work simultaneously! (or most of them)

ConcurrentHashMap<String, Integer> map = new ConcurrentHashMap<>();
// Threads can call put(), get() concurrently on different keys
```

**Performance Comparison:**

```
Operation              | Hashtable | ConcurrentHashMap
put() with contention  | Slow      | Fast (segment-level lock)
get() with contention  | Slow      | Fast (mostly lock-free)
Multiple threads       | Serialized| Parallelized
```

**Key Insight:**
- **Hashtable:** Thread-safe but bottleneck—one lock for entire map.
- **ConcurrentHashMap:** Thread-safe with throughput—distributed locks.

**Code Example:**

```java
// Hashtable: 10 threads put to different keys
Hashtable<String, Integer> table = new Hashtable<>();
// 📊 Throughput: ~100 ops/sec

// ConcurrentHashMap: same scenario
ConcurrentHashMap<String, Integer> cmap = new ConcurrentHashMap<>();
// 📊 Throughput: ~10000 ops/sec (100x faster!)
```

---

### 7️⃣ What happens if we override equals() but not hashCode()?

**Short Answer:** Violates the HashMap/Set contract. Objects that are equal (by `equals()`) must have the same `hashCode()`. If not, they'll be placed in different buckets, breaking duplicate detection.

**The Problem:**

```java
public class Person {
    private String name;
    private int age;
    
    @Override
    public boolean equals(Object obj) {
        if (!(obj instanceof Person)) return false;
        Person p = (Person) obj;
        return this.name.equals(p.name) && this.age == p.age;
    }
    
    // ❌ NO hashCode() override!
    // Default: uses object identity (memory address)
}

// Usage:
Set<Person> set = new HashSet<>();
Person p1 = new Person("Alice", 25);
Person p2 = new Person("Alice", 25);

set.add(p1);
set.add(p2);

System.out.println(set.size()); // ❌ 2 (should be 1!)
System.out.println(p1.equals(p2)); // ✅ true (but didn't help!)
```

**Why This Happens:**

```java
// p1 and p2 are equal, but have different hashCodes:
p1.hashCode() // → 123456 (default: based on memory)
p2.hashCode() // → 654321 (different memory address)

// HashMap logic:
// 1. Compute hashCode for p1 → 123456, store in bucket 123456
// 2. Compute hashCode for p2 → 654321, store in bucket 654321
// 3. Result: same object in two buckets! Duplicate not detected.
```

**Correct Implementation:**

```java
@Override
public int hashCode() {
    return Objects.hash(name, age); // ✅ Same hash for equal objects
}

// Now:
set.add(p1); // bucket X
set.add(p2); // same bucket X, equals() returns true → skipped
set.size(); // ✅ 1 (correct!)
```

**The Contract:**
- If `a.equals(b)` is true, then `a.hashCode() == b.hashCode()`.
- Always override both together or neither.

---

### 8️⃣ When should we use CopyOnWriteArrayList over a synchronized List?

**Short Answer:** Use `CopyOnWriteArrayList` when reads far outnumber writes. Use synchronized list when writes are frequent.

**CopyOnWriteArrayList (Write-Heavy Cost, Read-Light Cost):**

```java
CopyOnWriteArrayList<String> list = new CopyOnWriteArrayList<>();

// add(): Creates a new array copy (expensive)
list.add("item"); // O(n) — copies entire array

// get(): No locks (very fast)
String item = list.get(0); // O(1) — lock-free

// ✅ Perfect for: read-heavy scenarios (10 reads per 1 write)
// ❌ Bad for: write-heavy scenarios (1000 writes per second)
```

**Synchronized List (All Operations Locked):**

```java
List<String> list = Collections.synchronizedList(new ArrayList<>());

// add(): Lock acquired (moderate cost)
list.add("item"); // O(1) — but wait for lock

// get(): Lock acquired (has overhead)
String item = list.get(0); // O(1) — but wait for lock

// ✅ Balanced when reads and writes are similar
// ❌ Not ideal for heavy reads (unnecessary lock overhead)
```

**Real-World Example:**

```java
// Scenario: Event listeners (mostly read, occasionally add)
CopyOnWriteArrayList<EventListener> listeners = 
    new CopyOnWriteArrayList<>();

// Listener registration (rare):
listeners.add(newListener); // O(n), but rare → acceptable

// Event firing (frequent):
for (EventListener listener : listeners) {
    listener.onEvent(event); // O(1), lock-free → fast!
}

// vs. synchronized:
// Every iteration would acquire locks → slower for frequent reads
```

**Performance Comparison:**

```
Scenario: 1000 reads, 10 writes

CopyOnWriteArrayList:
  Reads:  1000 * O(1) lock-free   = Fast
  Writes: 10 * O(n) array copies  = Acceptable (rare)
  Total:  ✅ Good

Synchronized List:
  Reads:  1000 * O(1) + lock      = OK
  Writes: 10 * O(1) + lock        = OK
  Total:  ✅ OK but lock contention
```

**Decision Matrix:**
- **Read-heavy (100:1):** Use `CopyOnWriteArrayList`.
- **Balanced (1:1):** Use `Collections.synchronizedList()`.
- **Write-heavy (1:100):** Use regular `ArrayList` + manual sync if needed.

---

### 9️⃣ How does LinkedHashMap maintain insertion order?

**Short Answer:** LinkedHashMap extends HashMap and adds a **doubly-linked list** to track insertion order (or access order if configured).

**How It Works:**

```java
LinkedHashMap<String, Integer> map = new LinkedHashMap<>();
map.put("first", 1);
map.put("second", 2);
map.put("third", 3);

// HashMap internally:
//   bucket[0] → hash table (fast lookup)
//   bucket[1]
//   ...
//
// LinkedHashMap additionally:
//   ┌─────────────────────────────┐
//   │ Node (first)  → Node (second) → Node (third) │
//   └─────────────────────────────┘
//   Doubly-linked list (tracks order)

// Iteration:
for (String key : map.keySet()) {
    System.out.println(key);
}
// Output: first, second, third (insertion order ✅)
```

**Two Modes:**

```java
// 1. Insertion Order (default)
LinkedHashMap<String, Integer> map = new LinkedHashMap<>();
map.put("a", 1);
map.put("b", 2);
// Iteration: a → b (insertion order)

// 2. Access Order (LRU cache behavior)
LinkedHashMap<String, Integer> lruMap = 
    new LinkedHashMap<String, Integer>(16, 0.75f, true) {
        @Override
        protected boolean removeEldestEntry(Map.Entry eldest) {
            return size() > 3; // Max 3 entries
        }
    };

lruMap.put("a", 1);
lruMap.put("b", 2);
lruMap.put("c", 3);
System.out.println(lruMap.get("a")); // Access "a", moves to end
lruMap.put("d", 4); // Removes eldest (LRU: "b")
// Remaining: a (most recent) → c → d
```

**Real-World: LRU Cache**

```java
// Simple LRU cache using LinkedHashMap
class LRUCache<K, V> extends LinkedHashMap<K, V> {
    private final int capacity;
    
    public LRUCache(int capacity) {
        super(capacity, 0.75f, true); // Access order
        this.capacity = capacity;
    }
    
    @Override
    protected boolean removeEldestEntry(Map.Entry eldest) {
        return size() > capacity;
    }
}

LRUCache<String, String> cache = new LRUCache<>(2);
cache.put("user1", "data1");
cache.put("user2", "data2");
cache.put("user1", "data1"); // Moves user1 to end
cache.put("user3", "data3"); // Removes user2 (LRU)
// Cache: user1, user3
```

**Performance:**
- **O(1) get/put:** HashMap performance (doubly-linked list is constant overhead).
- **Ordered iteration:** Slight memory overhead (pointers for each node).

---

### 🔟 How does PriorityQueue work internally?

**Short Answer:** PriorityQueue uses a **min-heap** (or max-heap) to maintain elements in priority order. Smallest element is always at the root.

**Internal Structure:**

```java
PriorityQueue<Integer> queue = new PriorityQueue<>();
queue.add(5);
queue.add(2);
queue.add(8);
queue.add(1);

// Internally: min-heap (array-based)
//            [1, 2, 8, 5]
//            
//            Visual tree:
//               1 (root, min)
//              / \
//             2   8
//            /
//           5

// poll(): Returns 1 (min), reorganizes heap
// peek(): Returns 1 without removing
// add(): Adds element, maintains heap property
```

**How add() Works:**

```java
// When adding 3 to [1, 2, 8, 5]:
// 1. Add at end: [1, 2, 8, 5, 3]
// 2. Bubble up: Compare parent 2 with 3 → 3 > 2, stop
// 3. Result: [1, 2, 8, 5, 3] (heap property maintained)

queue.add(3);
System.out.println(queue.peek()); // Still 1
```

**How poll() Works:**

```java
// Remove min (root) from [1, 2, 8, 5]:
// 1. Move last element to root: [5, 2, 8]
// 2. Bubble down: Compare 5 with children (2, 8)
//    - 2 is smaller, swap: [2, 5, 8]
// 3. Compare 5 with child (8) → 5 < 8, stop
// 4. Result: [2, 5, 8]

int min = queue.poll();
System.out.println(min); // 1
System.out.println(queue.peek()); // Now 2
```

**Custom Priority (Max-Heap):**

```java
// Default: min-heap (ascending order)
PriorityQueue<Integer> minHeap = new PriorityQueue<>();
minHeap.add(5);
minHeap.add(2);
System.out.println(minHeap.poll()); // 2 (min)

// Max-heap (descending order)
PriorityQueue<Integer> maxHeap = new PriorityQueue<>((a, b) -> b - a);
maxHeap.add(5);
maxHeap.add(2);
System.out.println(maxHeap.poll()); // 5 (max)
```

**Real-World: Task Scheduler**

```java
class Task implements Comparable<Task> {
    private String name;
    private int priority; // 1 = high, 10 = low
    
    @Override
    public int compareTo(Task other) {
        return Integer.compare(this.priority, other.priority);
    }
}

PriorityQueue<Task> scheduler = new PriorityQueue<>();
scheduler.add(new Task("High task", 1));
scheduler.add(new Task("Low task", 10));

// Process highest priority first:
while (!scheduler.isEmpty()) {
    Task task = scheduler.poll();
    System.out.println("Processing: " + task.name);
}
// Output: High task, Low task
```

**Complexity:**
- **add():** O(log n) — bubble up.
- **poll():** O(log n) — bubble down.
- **peek():** O(1) — no change.
- **Creation from array:** O(n) — heapify.a Interview"
author: "Aayush Bhardwaj"
weight: 110
date: 2025-03-01
lastmod: 2025-03-01
dateString: March 2024  
description: "General Question"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "codefrydev", "Java", "CFD"]
keywords: [ "codefrydev", "Java", "CFD"]
---

1️⃣ Why does HashMap allow one null key but Hashtable doesn’t?
2️⃣ What happens internally when we call put() in a HashMap?
3️⃣ How does a Set actually prevent duplicates?
4️⃣ What’s the difference between fail-fast and fail-safe iterators?
5️⃣ How does TreeMap maintain its order?
6️⃣ Why is ConcurrentHashMap faster than Hashtable?
7️⃣ What happens if we override equals() but not hashCode()?
8️⃣ When should we use CopyOnWriteArrayList over a synchronized List?
9️⃣ How does LinkedHashMap maintain insertion order?
🔟 How does PriorityQueue work internally?






---

## Advanced Java Concepts

### 1. What is Eager and Lazy Loading in Java?

**Short Answer:**
- **Eager Loading:** Load resources immediately when application starts.
- **Lazy Loading:** Load resources on-demand (when first accessed).

**Eager Loading (Load Everything Upfront):**

```java
public class DatabaseConnection {
    // Eager: Connection created at class load time
    private static final DatabaseConnection instance = new DatabaseConnection();
    
    private DatabaseConnection() {
        System.out.println("Connecting to database...");
        // Expensive operation: opens DB connection
    }
    
    public static DatabaseConnection getInstance() {
        return instance;
    }
}

// At startup: Connection is established immediately ✅
```

**Lazy Loading (Load When Needed):**

```java
public class DatabaseConnection {
    // Lazy: Connection created on first access
    private static DatabaseConnection instance;
    
    private DatabaseConnection() {
        System.out.println("Connecting to database...");
    }
    
    public static DatabaseConnection getInstance() {
        if (instance == null) {
            instance = new DatabaseConnection(); // Created on first call
        }
        return instance;
    }
}

// First call to getInstance(): Connection is established ✅
// Subsequent calls: Use existing connection ✅
```

**Thread-Safe Lazy Loading (Best Practice):**

```java
public class DatabaseConnection {
    private static DatabaseConnection instance;
    
    private DatabaseConnection() {}
    
    // Synchronized block: thread-safe but has overhead
    public static synchronized DatabaseConnection getInstance() {
        if (instance == null) {
            instance = new DatabaseConnection();
        }
        return instance;
    }
}

// Even better: Bill Pugh Singleton Pattern (lazy + thread-safe + no sync overhead)
public class DatabaseConnection {
    private DatabaseConnection() {}
    
    private static class Holder {
        static final DatabaseConnection INSTANCE = new DatabaseConnection();
    }
    
    public static DatabaseConnection getInstance() {
        return Holder.INSTANCE; // Loaded on first access, thread-safe
    }
}
```

**Real-World Example: Spring Lazy Beans**

```java
@Configuration
public class AppConfig {
    
    // Eager: Created at startup
    @Bean
    public UserService userService() {
        return new UserService();
    }
    
    // Lazy: Created on first injection
    @Bean
    @Lazy
    public EmailService emailService() {
        return new EmailService();
    }
}
```

**When to Use:**

| Scenario | Use |
|----------|-----|
| Critical resource needed at start | Eager (fail fast if unavailable) |
| Expensive resource rarely used | Lazy (save startup time) |
| Large dataset loaded once | Eager |
| Large dataset loaded per request | Lazy |

---

### 2. What are the SOLID principles in Java? Explain them with examples.

**Short Answer:** SOLID is an acronym for five design principles that make code maintainable, flexible, and scalable.

#### **S — Single Responsibility Principle (SRP)**

*A class should have only one reason to change.*

```java
// ❌ Bad: Class has two responsibilities
class User {
    private String name;
    
    public void saveToDatabase() { /* DB logic */ }
    public void sendEmail() { /* Email logic */ }
}

// ✅ Good: Separate classes, one responsibility each
class User {
    private String name;
    // Only user data, no business logic
}

class UserRepository {
    public void save(User user) { /* DB logic */ }
}

class EmailService {
    public void send(User user) { /* Email logic */ }
}
```

**Benefit:** If DB logic changes, `UserRepository` changes, not `User`. If email logic changes, `EmailService` changes. Each class is focused.

---

#### **O — Open/Closed Principle (OCP)**

*Classes should be open for extension, closed for modification.*

```java
// ❌ Bad: Must modify existing class to add new payment type
class PaymentProcessor {
    public void processPayment(String type, double amount) {
        if (type.equals("credit")) {
            // Credit card logic
        } else if (type.equals("paypal")) {
            // PayPal logic
        } else if (type.equals("bitcoin")) {
            // Bitcoin logic (requires modifying existing method!)
        }
    }
}

// ✅ Good: Add new types without modifying existing code
interface PaymentMethod {
    void process(double amount);
}

class CreditCardPayment implements PaymentMethod {
    @Override
    public void process(double amount) { /* Credit logic */ }
}

class PayPalPayment implements PaymentMethod {
    @Override
    public void process(double amount) { /* PayPal logic */ }
}

class BitcoinPayment implements PaymentMethod {
    @Override
    public void process(double amount) { /* Bitcoin logic */ }
}

class PaymentProcessor {
    public void processPayment(PaymentMethod method, double amount) {
        method.process(amount); // Works for any new payment type
    }
}

// Add new payment type without modifying PaymentProcessor:
PaymentProcessor processor = new PaymentProcessor();
processor.processPayment(new BitcoinPayment(), 100);
```

**Benefit:** Adding Bitcoin payment doesn't touch existing code → no risk of breaking credit/PayPal logic.

---

#### **L — Liskov Substitution Principle (LSP)**

*A subclass should be usable wherever its superclass is used.*

```java
// ❌ Bad: Bird can fly, but Penguin (a bird) cannot
class Bird {
    public void fly() { System.out.println("Flying..."); }
}

class Penguin extends Bird {
    @Override
    public void fly() {
        throw new UnsupportedOperationException("Penguins can't fly!");
    }
}

// Code breaks if you treat Penguin as Bird:
void makeBirdFly(Bird bird) {
    bird.fly(); // ❌ Throws exception if bird is Penguin
}

// ✅ Good: Proper hierarchy
interface Animal {
    void move();
}

interface FlyingAnimal extends Animal {
    void fly();
}

class Sparrow implements FlyingAnimal {
    @Override
    public void move() { System.out.println("Hopping..."); }
    @Override
    public void fly() { System.out.println("Flying..."); }
}

class Penguin implements Animal {
    @Override
    public void move() { System.out.println("Waddling..."); }
}

// Now can safely use:
void makeBirdFly(FlyingAnimal bird) {
    bird.fly(); // Always safe
}
```

**Benefit:** No surprises—if a type implements an interface, it truly supports all its contracts.

---

#### **I — Interface Segregation Principle (ISP)**

*Clients should not depend on interfaces they don't use.*

```java
// ❌ Bad: Worker must implement methods it doesn't need
interface Worker {
    void work();
    void eat();
    void manage();
}

class Robot implements Worker {
    @Override
    public void work() { /* Robot works */ }
    
    @Override
    public void eat() { /* Robot doesn't eat! */ }
    
    @Override
    public void manage() { /* Robot doesn't manage! */ }
}

// ✅ Good: Segregate into focused interfaces
interface Workable {
    void work();
}

interface Eatable {
    void eat();
}

interface Manageable {
    void manage();
}

class Human implements Workable, Eatable, Manageable {
    @Override
    public void work() { /* work */ }
    @Override
    public void eat() { /* eat */ }
    @Override
    public void manage() { /* manage */ }
}

class Robot implements Workable {
    @Override
    public void work() { /* work */ }
    // No forced empty methods!
}
```

**Benefit:** Classes implement only what they need. Robot doesn't waste code on unused methods.

---

#### **D — Dependency Inversion Principle (DIP)**

*High-level modules should not depend on low-level modules. Both should depend on abstractions.*

```java
// ❌ Bad: UserService directly depends on MySQLDatabase
class MySQLDatabase {
    public void save(User user) { /* MySQL save */ }
}

class UserService {
    private MySQLDatabase db = new MySQLDatabase(); // Hard-coded dependency
    
    public void registerUser(User user) {
        db.save(user);
    }
}

// Switching to PostgreSQL requires changing UserService!

// ✅ Good: Depend on abstraction (interface)
interface Database {
    void save(User user);
}

class MySQLDatabase implements Database {
    @Override
    public void save(User user) { /* MySQL save */ }
}

class PostgreSQLDatabase implements Database {
    @Override
    public void save(User user) { /* PostgreSQL save */ }
}

class UserService {
    private Database db; // Depends on abstraction
    
    // Inject concrete implementation (constructor injection)
    public UserService(Database db) {
        this.db = db;
    }
    
    public void registerUser(User user) {
        db.save(user);
    }
}

// Usage:
UserService service = new UserService(new PostgreSQLDatabase());
// Easily switch DB without modifying UserService!
```

**Benefit:** Loose coupling. Swap implementations without changing high-level logic.

---

### 3. How to create an Immutable class in Java?

**Short Answer:** Make the class `final`, all fields `private final`, prevent field modification, and provide no setters.

**Step-by-Step Guide:**

```java
public final class ImmutableStudent {
    private final String name;
    private final int age;
    private final List<String> courses; // Mutable field!
    
    // 1. Constructor (only way to initialize)
    public ImmutableStudent(String name, int age, List<String> courses) {
        this.name = name;
        this.age = age;
        // 2. Defensive copy to prevent external modification
        this.courses = new ArrayList<>(courses);
    }
    
    // 3. Getters only (no setters)
    public String getName() {
        return name;
    }
    
    public int getAge() {
        return age;
    }
    
    // 4. Return defensive copy of mutable fields
    public List<String> getCourses() {
        return new ArrayList<>(courses); // Not the internal list!
    }
    
    // 5. Override equals and hashCode (important!)
    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof ImmutableStudent)) return false;
        ImmutableStudent student = (ImmutableStudent) o;
        return age == student.age &&
                name.equals(student.name) &&
                courses.equals(student.courses);
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(name, age, courses);
    }
    
    // 6. toString() for debugging
    @Override
    public String toString() {
        return "ImmutableStudent{" +
                "name='" + name + '\'' +
                ", age=" + age +
                ", courses=" + courses +
                '}';
    }
}

// Usage:
ImmutableStudent student = new ImmutableStudent("Alice", 20, 
    Arrays.asList("Java", "Spring"));

// ✅ Can't modify:
// student.name = "Bob"; // ❌ Compilation error (final field)
// student.courses.add("Python"); // ❌ Gets a copy, not internal list

List<String> courses = student.getCourses();
courses.add("Python"); // Doesn't affect original!
System.out.println(student.getCourses()); // Still [Java, Spring]
```

**Using Records (Java 14+):**

```java
// Simpler! Records are immutable by default
public record ImmutableStudent(String name, int age, List<String> courses) {}

// Generates: final class, final fields, immutable getters, equals, hashCode, toString!
```

**Using Collections.unmodifiable...:**

```java
public final class ImmutableStudent {
    private final String name;
    private final List<String> courses;
    
    public ImmutableStudent(String name, List<String> courses) {
        this.name = name;
        // Immutable list (throws exception on modification)
        this.courses = Collections.unmodifiableList(new ArrayList<>(courses));
    }
    
    public List<String> getCourses() {
        return courses; // Safe to return directly (already immutable)
    }
}
```

**Benefits:**
- **Thread-safe:** No synchronization needed.
- **Can be cached:** Immutable objects can be reused.
- **Hashable:** Safe to use as HashMap keys or in HashSet.
- **Easier to reason about:** State never changes.

---

### 4. What is the N+1 problem and how do you resolve it?

**Short Answer:** N+1 problem occurs when fetching related data requires 1 initial query + N additional queries (where N = number of records). Result: performance bottleneck.

**Example of N+1 Problem:**

```java
// Database schema:
// Author (id, name)
// Book (id, title, author_id)

@Entity
public class Author {
    @Id
    private Long id;
    private String name;
    
    @OneToMany(mappedBy = "author")
    private List<Book> books; // Lazy loaded by default
}

@Entity
public class Book {
    @Id
    private Long id;
    private String title;
    
    @ManyToOne
    private Author author;
}

// ❌ N+1 Problem:
List<Author> authors = authorRepository.findAll(); // Query 1: SELECT * FROM Author
for (Author author : authors) {
    System.out.println(author.getBooks()); // Query 2, 3, 4... (N additional queries!)
    // For each author, a separate query is executed to fetch books
}
// Total queries: 1 + N (if 100 authors, then 101 queries!)
```

**Solution 1: Eager Loading (@Fetch)**

```java
@Entity
public class Author {
    @OneToMany(mappedBy = "author", fetch = FetchType.EAGER)
    // Or: @Fetch(FetchMode.JOIN)
    private List<Book> books;
}

// Usage:
List<Author> authors = authorRepository.findAll(); // 1 query with JOIN
for (Author author : authors) {
    System.out.println(author.getBooks()); // Already loaded
}
// Total: 1 query ✅
```

**Solution 2: Explicit JOIN Query (JPQL)**

```java
@Repository
public interface AuthorRepository extends JpaRepository<Author, Long> {
    @Query("SELECT DISTINCT a FROM Author a LEFT JOIN FETCH a.books")
    List<Author> findAllWithBooks();
}

// Usage:
List<Author> authors = authorRepository.findAllWithBooks(); // 1 query with JOIN
// Total: 1 query ✅
```

**Solution 3: Native Query with Projection**

```java
// If you only need specific fields, avoid fetching unnecessary data
@Query(value = 
    "SELECT a.id, a.name, COUNT(b.id) as book_count " +
    "FROM Author a LEFT JOIN Book b ON a.id = b.author_id " +
    "GROUP BY a.id, a.name", 
    nativeQuery = true)
List<AuthorDTO> findAuthorsWithBookCount();
```

**Solution 4: Batch Loading**

```java
@Entity
public class Author {
    @OneToMany(mappedBy = "author", fetch = FetchType.LAZY)
    @BatchSize(size = 10) // Load 10 at a time
    private List<Book> books;
}

// Usage:
List<Author> authors = authorRepository.findAll(); // Query 1
for (Author author : authors) {
    System.out.println(author.getBooks()); // Queries 2, 3, etc. (batched per 10)
}
// Total: ~1 + (N / 10) queries (better than 1 + N)
```

**Comparison:**

| Solution | Queries | When to Use |
|----------|---------|------------|
| Eager Loading | 1-2 | Small related data, always needed |
| JOIN FETCH | 1 | Specific queries where you need related data |
| Batch Loading | 1 + N/batch_size | Large datasets, moderate related data |
| Lazy Loading | 1 + N | ❌ Avoid (N+1 problem!) |

---

### 5. Explain about design patterns with examples.

**Short Answer:** Design patterns are proven solutions to common coding problems. They're templates for writing maintainable, reusable code.

#### **Creational Patterns (Object Creation)**

**Singleton Pattern:**

```java
// Ensure only one instance of a class exists
public class DatabaseConnection {
    private static DatabaseConnection instance;
    
    private DatabaseConnection() {} // Private constructor
    
    public static synchronized DatabaseConnection getInstance() {
        if (instance == null) {
            instance = new DatabaseConnection();
        }
        return instance;
    }
}

DatabaseConnection db1 = DatabaseConnection.getInstance();
DatabaseConnection db2 = DatabaseConnection.getInstance();
System.out.println(db1 == db2); // true (same instance)
```

**Factory Pattern:**

```java
// Create objects without specifying exact classes
interface Shape {
    void draw();
}

class Circle implements Shape {
    @Override public void draw() { System.out.println("Drawing Circle"); }
}

class Rectangle implements Shape {
    @Override public void draw() { System.out.println("Drawing Rectangle"); }
}

class ShapeFactory {
    public static Shape createShape(String type) {
        return switch(type) {
            case "CIRCLE" -> new Circle();
            case "RECTANGLE" -> new Rectangle();
            default -> throw new IllegalArgumentException("Unknown shape");
        };
    }
}

// Usage:
Shape shape = ShapeFactory.createShape("CIRCLE"); // Create without knowing class
shape.draw();
```

**Builder Pattern:**

```java
// Build complex objects step-by-step
public class User {
    private final String name;
    private final String email;
    private final String phone;
    private final String address;
    
    private User(Builder builder) {
        this.name = builder.name;
        this.email = builder.email;
        this.phone = builder.phone;
        this.address = builder.address;
    }
    
    public static class Builder {
        private String name;
        private String email;
        private String phone;
        private String address;
        
        public Builder name(String name) {
            this.name = name;
            return this;
        }
        
        public Builder email(String email) {
            this.email = email;
            return this;
        }
        
        public Builder phone(String phone) {
            this.phone = phone;
            return this;
        }
        
        public Builder address(String address) {
            this.address = address;
            return this;
        }
        
        public User build() {
            return new User(this);
        }
    }
}

// Usage:
User user = new User.Builder()
    .name("Alice")
    .email("alice@example.com")
    .phone("123456")
    .build(); // Clear, flexible construction
```

#### **Structural Patterns (Object Composition)**

**Adapter Pattern:**

```java
// Use incompatible interfaces together
interface MediaPlayer {
    void play(String audioType, String fileName);
}

interface AdvancedMediaPlayer {
    void playVlc(String fileName);
    void playMp4(String fileName);
}

class VlcPlayer implements AdvancedMediaPlayer {
    @Override public void playVlc(String fileName) { System.out.println("Playing VLC: " + fileName); }
    @Override public void playMp4(String fileName) {}
}

// Adapter: makes AdvancedMediaPlayer work with MediaPlayer interface
class MediaAdapter implements MediaPlayer {
    private AdvancedMediaPlayer advancedPlayer;
    
    public MediaAdapter(AdvancedMediaPlayer player) {
        this.advancedPlayer = player;
    }
    
    @Override
    public void play(String audioType, String fileName) {
        if ("vlc".equals(audioType)) {
            advancedPlayer.playVlc(fileName);
        }
    }
}

// Usage:
MediaPlayer player = new MediaAdapter(new VlcPlayer());
player.play("vlc", "song.vlc");
```

**Decorator Pattern:**

```java
// Add behavior to objects dynamically
interface Coffee {
    double getCost();
    String getDescription();
}

class SimpleCoffee implements Coffee {
    @Override public double getCost() { return 2.0; }
    @Override public String getDescription() { return "Simple Coffee"; }
}

abstract class CoffeeDecorator implements Coffee {
    protected Coffee coffee;
    
    public CoffeeDecorator(Coffee coffee) {
        this.coffee = coffee;
    }
}

class MilkDecorator extends CoffeeDecorator {
    public MilkDecorator(Coffee coffee) { super(coffee); }
    
    @Override public double getCost() { return coffee.getCost() + 0.5; }
    @Override public String getDescription() { return coffee.getDescription() + ", Milk"; }
}

class SugarDecorator extends CoffeeDecorator {
    public SugarDecorator(Coffee coffee) { super(coffee); }
    
    @Override public double getCost() { return coffee.getCost() + 0.2; }
    @Override public String getDescription() { return coffee.getDescription() + ", Sugar"; }
}

// Usage:
Coffee coffee = new SimpleCoffee();
coffee = new MilkDecorator(coffee);
coffee = new SugarDecorator(coffee);
System.out.println(coffee.getDescription()); // Simple Coffee, Milk, Sugar
System.out.println(coffee.getCost()); // 2.7
```

#### **Behavioral Patterns (Object Interaction)**

**Observer Pattern:**

```java
// Objects notify others of state changes
interface Observer {
    void update(String event);
}

class EventManager {
    private List<Observer> observers = new ArrayList<>();
    
    public void subscribe(Observer observer) {
        observers.add(observer);
    }
    
    public void notifyObservers(String event) {
        for (Observer observer : observers) {
            observer.update(event);
        }
    }
}

class User implements Observer {
    private String name;
    
    public User(String name) { this.name = name; }
    
    @Override public void update(String event) {
        System.out.println(name + " received: " + event);
    }
}

// Usage:
EventManager manager = new EventManager();
manager.subscribe(new User("Alice"));
manager.subscribe(new User("Bob"));
manager.notifyObservers("System update!"); // Both users notified
```

**Strategy Pattern:**

```java
// Select algorithm at runtime
interface PaymentStrategy {
    void pay(double amount);
}

class CreditCardPayment implements PaymentStrategy {
    @Override public void pay(double amount) { System.out.println("Paying " + amount + " via Credit Card"); }
}

class PayPalPayment implements PaymentStrategy {
    @Override public void pay(double amount) { System.out.println("Paying " + amount + " via PayPal"); }
}

class PaymentContext {
    private PaymentStrategy strategy;
    
    public void setPaymentStrategy(PaymentStrategy strategy) {
        this.strategy = strategy;
    }
    
    public void checkout(double amount) {
        strategy.pay(amount);
    }
}

// Usage:
PaymentContext context = new PaymentContext();
context.setPaymentStrategy(new CreditCardPayment());
context.checkout(100); // Uses credit card

context.setPaymentStrategy(new PayPalPayment());
context.checkout(50); // Uses PayPal
```

---

### 6. What would happen if we override only either equals() or hashCode() methods in Java?

**Short Answer:** Violates the `equals()`-`hashCode()` contract: if `a.equals(b)` is true, then `a.hashCode() == b.hashCode()`. Breaking it causes bugs in HashMap, HashSet, etc.

**Scenario 1: Override equals() but NOT hashCode()**

```java
public class Student {
    private int id;
    private String name;
    
    @Override
    public boolean equals(Object obj) {
        if (!(obj instanceof Student)) return false;
        Student s = (Student) obj;
        return this.id == s.id && this.name.equals(s.name);
    }
    
    // ❌ NO hashCode() override!
}

// Problem:
Set<Student> set = new HashSet<>();
Student s1 = new Student(1, "Alice");
Student s2 = new Student(1, "Alice"); // Same data as s1

set.add(s1);
set.add(s2); // Should not add (duplicate) but DOES!

System.out.println(set.size()); // 2 (should be 1!)
System.out.println(s1.equals(s2)); // true (but didn't help)

// Why? 
// s1.hashCode() → 123456 (default: based on memory)
// s2.hashCode() → 654321 (different memory)
// HashSet stores both in different buckets → duplicate not detected
```

**Scenario 2: Override hashCode() but NOT equals()**

```java
public class Student {
    private int id;
    private String name;
    
    @Override
    public int hashCode() {
        return Objects.hash(id, name);
    }
    
    // ❌ NO equals() override! Uses default (Object.equals = identity check)
}

// Problem:
Map<Student, Integer> map = new HashMap<>();
Student s1 = new Student(1, "Alice");
Student s2 = new Student(1, "Alice"); // Same data as s1

map.put(s1, 100);
Integer value = map.get(s2); // Tries to find s2

System.out.println(value); // null (should be 100!)

// Why?
// 1. hashCode comparison: s1.hashCode() == s2.hashCode() → true (same hash)
// 2. equals comparison: s1.equals(s2) → false (default = identity, different objects)
// 3. HashMap treats them as different keys!
// 4. s2 is not found, returns null
```

**Correct Implementation (Both):**

```java
public class Student {
    private int id;
    private String name;
    
    @Override
    public boolean equals(Object obj) {
        if (!(obj instanceof Student)) return false;
        Student s = (Student) obj;
        return this.id == s.id && this.name.equals(s.name);
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(id, name); // ✅ Must use same fields as equals()
    }
}

// Now:
Set<Student> set = new HashSet<>();
Student s1 = new Student(1, "Alice");
Student s2 = new Student(1, "Alice");

set.add(s1);
set.add(s2); // Not added; duplicate detected ✅

System.out.println(set.size()); // 1 ✅
```

**The Contract (Golden Rule):**

> If `a.equals(b)` returns true, then `a.hashCode() == b.hashCode()` MUST be true.

Always override both together!

---

### 7. What are OAuth and JWT authentications?

**Short Answer:**
- **OAuth:** Authorization protocol (grants access without sharing passwords).
- **JWT:** Token format (securely transmits user identity).

#### **OAuth (Open Authorization)**

OAuth allows users to authorize apps without giving passwords.

**Real-World Example: "Sign in with Google"**

```
User → Your App → Google Auth Server
  1. User clicks "Sign in with Google"
  2. Your app redirects to Google (with app credentials)
  3. User logs into Google (Google checks password)
  4. User grants permission to your app
  5. Google returns Authorization Code to your app
  6. Your app exchanges code for Access Token
  7. Your app accesses user's profile using Access Token
  8. User is signed in to your app (no password shared!)
```

**OAuth Flow Code Example:**

```java
@RestController
@RequestMapping("/auth")
public class OAuthController {
    
    @GetMapping("/login")
    public String login() {
        // Redirect to Google Auth Server
        String authUrl = "https://accounts.google.com/o/oauth2/auth?" +
            "client_id=YOUR_CLIENT_ID&" +
            "redirect_uri=http://localhost:8080/auth/callback&" +
            "response_type=code&" +
            "scope=openid profile email";
        return "redirect:" + authUrl;
    }
    
    @GetMapping("/callback")
    public String callback(@RequestParam String code) {
        // Exchange code for access token
        String accessToken = exchangeCodeForToken(code);
        
        // Fetch user profile
        UserProfile profile = fetchUserProfile(accessToken);
        
        // Create session for user
        return "redirect:/dashboard";
    }
}
```

#### **JWT (JSON Web Token)**

JWT is a token format: self-contained, signed, and can be verified without a server.

**Structure: Header.Payload.Signature**

```java
// Header: Token type and hashing algorithm
{
  "typ": "JWT",
  "alg": "HS256"
}

// Payload: Claims (user data)
{
  "sub": "user123",
  "name": "Alice",
  "email": "alice@example.com",
  "iat": 1606324800,
  "exp": 1606411200  // Expires in 24 hours
}

// Signature: Securely signed with server's secret key
HMACSHA256(base64(header) + "." + base64(payload), secret)
```

**JWT in Java (Using jjwt Library):**

```java
// Generate JWT
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;

public class JwtUtil {
    private static final String SECRET_KEY = "my-super-secret-key";
    
    public static String generateToken(String userId) {
        return Jwts.builder()
            .setSubject(userId)
            .claim("name", "Alice")
            .claim("email", "alice@example.com")
            .setIssuedAt(new Date())
            .setExpiration(new Date(System.currentTimeMillis() + 86400000)) // 24 hours
            .signWith(SignatureAlgorithm.HS256, SECRET_KEY)
            .compact();
    }
    
    // Verify and extract JWT
    public static String extractUserId(String token) {
        return Jwts.parser()
            .setSigningKey(SECRET_KEY)
            .parseClaimsJws(token)
            .getBody()
            .getSubject();
    }
}

// Usage in REST API:
@RestController
@RequestMapping("/api")
public class UserController {
    
    @PostMapping("/login")
    public String login(@RequestParam String username, @RequestParam String password) {
        // Verify username/password
        if (isValidUser(username, password)) {
            String token = JwtUtil.generateToken(username);
            return token;
        }
        return "Invalid credentials";
    }
    
    @GetMapping("/profile")
    public String profile(@RequestHeader String Authorization) {
        String token = Authorization.replace("Bearer ", "");
        String userId = JwtUtil.extractUserId(token);
        return "User profile: " + userId;
    }
}

// Client usage:
// 1. POST /api/login → GET JWT token
// 2. Use token: GET /api/profile with header: "Authorization: Bearer <token>"
// 3. Server verifies token signature (no DB query!)
```

**OAuth vs. JWT:**

| Aspect | OAuth | JWT |
|--------|-------|-----|
| Purpose | Authorization (grant access) | Authentication (verify identity) |
| Who Manages | Authorization server | Client application |
| Token Type | Opaque (server-side lookup) | Self-contained (can verify locally) |
| Revocation | Immediate (if needed) | Difficult (expires at set time) |
| Use Case | "Sign in with Google/Facebook" | API authentication, microservices |

**Often Combined:**
OAuth gets an authorization code → Exchange for JWT → Use JWT for API calls.

---

### 8. What is the internal working of a HashMap in Java?

*Already covered in detail in Question 2️⃣ (Collections Framework section). See above for complete explanation with diagrams and code examples.*

---

### 9. What is the purpose of @Qualifier and @Primary annotations in Spring?

**Short Answer:**
- **@Primary:** Marks the default bean when multiple of same type exist.
- **@Qualifier:** Explicitly selects which bean to inject by name.

**Problem (Multiple Beans of Same Type):**

```java
@Component
public class MySQLDatabase implements Database {
    @Override public void save() { System.out.println("Saving to MySQL"); }
}

@Component
public class PostgreSQLDatabase implements Database {
    @Override public void save() { System.out.println("Saving to PostgreSQL"); }
}

@Service
public class UserService {
    @Autowired
    private Database database; // ❌ Which one? Spring throws exception!
}
```

**Solution 1: @Primary**

```java
@Component
@Primary // Use this if no other hint given
public class MySQLDatabase implements Database {
    @Override public void save() { System.out.println("Saving to MySQL"); }
}

@Component
public class PostgreSQLDatabase implements Database {
    @Override public void save() { System.out.println("Saving to PostgreSQL"); }
}

@Service
public class UserService {
    @Autowired
    private Database database; // ✅ Injects MySQLDatabase
}
```

**Solution 2: @Qualifier**

```java
@Component("mysqlDb") // Explicit name
public class MySQLDatabase implements Database {
    @Override public void save() { System.out.println("Saving to MySQL"); }
}

@Component("postgresDb")
public class PostgreSQLDatabase implements Database {
    @Override public void save() { System.out.println("Saving to PostgreSQL"); }
}

@Service
public class UserService {
    @Autowired
    @Qualifier("postgresDb") // ✅ Explicitly choose PostgreSQL
    private Database database;
}
```

**Combining @Primary and @Qualifier:**

```java
@Component
@Primary // Default choice
public class MySQLDatabase implements Database {}

@Component
@Qualifier("postgres") // Alternative choice
public class PostgreSQLDatabase implements Database {}

@Service
public class UserService {
    @Autowired
    private Database db1; // ✅ Uses MySQL (Primary)
    
    @Autowired
    @Qualifier("postgres")
    private Database db2; // ✅ Uses PostgreSQL (Qualifier overrides Primary)
}
```

**When to Use:**

| Scenario | Use |
|----------|-----|
| One bean is the obvious choice | @Primary |
| Need explicit, named selection | @Qualifier |
| Multiple configs possible | Both (@Primary as default, @Qualifier for override) |

---

### 10. What is a ConcurrentModificationException and how do you resolve it?

**Short Answer:** Thrown when a collection is modified while iterating over it. Common in multi-threaded code or accidental modifications during loops.

**When It Happens:**

```java
// ❌ Problem 1: Remove while iterating
List<String> list = new ArrayList<>(Arrays.asList("a", "b", "c"));

for (String item : list) {
    if (item.equals("b")) {
        list.remove("b"); // ❌ ConcurrentModificationException!
    }
}

// ❌ Problem 2: Modify in multi-threaded environment
List<String> list = new ArrayList<>(Arrays.asList("a", "b", "c"));

Thread thread1 = new Thread(() -> {
    for (String item : list) {
        System.out.println(item);
    }
});

Thread thread2 = new Thread(() -> {
    list.add("d"); // Modifies while thread1 iterates
});

thread1.start();
thread2.start();
// ❌ ConcurrentModificationException!
```

**Solution 1: Use Iterator's remove()**

```java
// ✅ Correct: Use iterator's remove() method
List<String> list = new ArrayList<>(Arrays.asList("a", "b", "c"));

Iterator<String> iterator = list.iterator();
while (iterator.hasNext()) {
    String item = iterator.next();
    if (item.equals("b")) {
        iterator.remove(); // ✅ Safe way to remove during iteration
    }
}

System.out.println(list); // [a, c]
```

**Solution 2: Use removeIf()**

```java
// ✅ Modern approach (Java 8+)
List<String> list = new ArrayList<>(Arrays.asList("a", "b", "c"));
list.removeIf(item -> item.equals("b")); // Safe, no concurrent exception

System.out.println(list); // [a, c]
```

**Solution 3: Use CopyOnWriteArrayList (Thread-Safe)**

```java
// ✅ Thread-safe alternative
List<String> list = new CopyOnWriteArrayList<>(Arrays.asList("a", "b", "c"));

for (String item : list) {
    if (item.equals("b")) {
        list.remove("b"); // ✅ No exception (iterates over copy)
    }
}

System.out.println(list); // [a, c]
```

**Solution 4: Create a Copy and Iterate**

```java
// ✅ Iterate over copy, modify original
List<String> list = new ArrayList<>(Arrays.asList("a", "b", "c"));

for (String item : new ArrayList<>(list)) { // Iterate over copy
    if (item.equals("b")) {
        list.remove(item); // Modify original
    }
}

System.out.println(list); // [a, c]
```

**Solution 5: Streams (Functional Approach)**

```java
// ✅ Functional, no iteration issues
List<String> list = new ArrayList<>(Arrays.asList("a", "b", "c"));

List<String> filtered = list.stream()
    .filter(item -> !item.equals("b"))
    .collect(Collectors.toList());

System.out.println(filtered); // [a, c]
```

**Comparison:**

| Solution | When to Use |
|----------|------------|
| `iterator.remove()` | Simple remove, traditional code |
| `removeIf()` | Modern, clean, single pass |
| `CopyOnWriteArrayList` | Multi-threaded, read-heavy |
| Copy & iterate | Rare edge cases |
| Streams | Functional style, multiple operations |



