using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarking;

[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser(false)]
public class Benchmarks
{
    private IEnumerable<int>? items;

    [Params(100)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        items = Enumerable.Range(1, 100).ToArray();
    }

    [Benchmark]
    public int Max() => items!.Max();

    [Benchmark]
    public int Min() => items!.Min();

    [Benchmark]
    public double Average() => items!.Average();

    [Benchmark]
    public int Sum() => items!.Sum();

    [Benchmark]
    public int MyMax()
    {
        var biggest = int.MinValue;
        foreach (var item in items!)
        {
            if (item > biggest)
            {
                biggest = item;
            }
        }
        return biggest;
    }

}
