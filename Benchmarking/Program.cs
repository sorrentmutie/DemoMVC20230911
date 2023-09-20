// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Benchmarking;

Console.WriteLine("Hello, World!");

//var items = Enumerable.Range(1,100).ToArray();

//var max = items.Max();
//var min = items.Min();
//var average = items.Average();
//var sum = items.Sum();

BenchmarkRunner.Run<Benchmarks>();