# Map / Reduce / Filter in LINQ
> https://stackoverflow.com/questions/428798/map-and-reduce-in-net
> 
**Map** is `Select`:
```cs
Enumerable.Range(1, 10).Select(x => x + 2);
```
**Reduce** is `Aggregate`:

```cs
Enumerable.Range(1, 10).Aggregate(0, (acc, x) => acc + x);
```
**Filter** is `Where`:

```cs
Enumerable.Range(1, 10).Where(x => x % 2 == 0);
```
