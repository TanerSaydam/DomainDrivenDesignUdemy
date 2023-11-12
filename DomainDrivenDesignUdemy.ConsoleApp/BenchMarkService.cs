using BenchmarkDotNet.Attributes;

namespace DomainDrivenDesignUdemy.ConsoleApp;
public class BenchMarkService
{
    [Benchmark(Baseline = true)]
    public void Equals()
    {
        int id = 1;
        Test1 test1 = new() { Id = id };
        Test1 test2 = new() { Id = id };
        Console.WriteLine(test1.Equals(test2));
    }

    [Benchmark]
    public void IEquatable()
    {
        int id = 1;
        Test2 test1 = new() { Id = id };
        Test2 test2 = new() { Id = id };
        Console.WriteLine(test1.Equals(test2));
    }
}

public class Test1
{
    public int Id { get; set; }
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj is not Test1 test1)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return test1.Id == Id;
    }
}

public class Test2 : IEquatable<Test2>
{
    public int Id { get; set; }
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj is not Test2 test2)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return test2.Id == Id;
    }

    public bool Equals(Test2? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other is not Test2 test2)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return test2.Id == Id;
    }
}
