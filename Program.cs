using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace SerializerCollectionSupport
{
    public class Program
    {
        //static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
        static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
