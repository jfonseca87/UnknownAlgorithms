# UnknownAlgorithms

A .NET 8 console application that implements four lesser-known but efficient **search algorithms** in pure C#. While the `Main` method only prints "Hello, World!", the project provides complete, documented implementations of each algorithm suitable for study, reference, or integration.

## Technologies / Libraries

- **.NET 8** (Console Application)
- No external dependencies

## Implemented Algorithms

### Jump Search (`JumpSearch`)
- **Time complexity:** O(√n)
- **Space complexity:** O(1)
- Divides the sorted array into blocks of size √n, jumps ahead by block size, then performs a linear search within the identified block.

### Interpolation Search (`InterpolationSearch`)
- **Time complexity:** O(log log n) average, O(n) worst
- **Space complexity:** O(1)
- Like binary search but probes at a position calculated from the value's distribution (works best on uniformly distributed, sorted data).

### Exponential Search (`ExponentialSearch`)
- **Time complexity:** O(log n)
- **Space complexity:** O(1)
- Finds a range by repeatedly doubling the index (1, 2, 4, 8...), then performs binary search on the found range. Useful for unbounded/infinite lists.

### Fibonacci Search (`FibonacciSearch`)
- **Time complexity:** O(log n)
- **Space complexity:** O(1)
- Uses Fibonacci numbers to divide the array into unequal partitions, avoiding the division operation used in binary search. Good for cases where division is expensive.

## How to Run

```bash
dotnet run --project UnknownAlgorithms
```

The algorithms are defined as `static` methods in the `Program` class. To use them, call the desired method with a sorted array/list and the target value, e.g.:
```csharp
int[] sorted = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
int index = Program.JumpSearch(sorted, 23); // returns 5
```
