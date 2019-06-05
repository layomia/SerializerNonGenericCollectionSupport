using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using Newtonsoft.Json;

namespace SerializerNonGenericCollectionSupport
{
    [JsonExporterAttribute.Full]
    [MemoryDiagnoser]
    public class ReadNonGenericCollection
    {
        private static readonly IList _ilist = new List<string>();
        private static IEnumerable _ienumerable = new List<string>();
        private static ICollection _icollection = new List<string>();

        private static string _jsonString;

        [Params(2, 50, 100)]
        public int ElementCount;

        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < ElementCount; i++)
            {
                _ilist.Add($"hello{i}");
            }

            _ienumerable = _ilist;
            _icollection = _ilist;

            _jsonString = System.Text.Json.Serialization.JsonSerializer.ToString(_ilist);
        }

        [Benchmark]
        public IEnumerable DeserializeIEnumerable()
        {
            return System.Text.Json.Serialization.JsonSerializer.Parse<IEnumerable>(_jsonString);
        }

        [Benchmark]
        public IList DeserializeIList()
        {
            return System.Text.Json.Serialization.JsonSerializer.Parse<IList>(_jsonString);
        }

        [Benchmark]
        public ICollection DeserializeICollection()
        {
            return System.Text.Json.Serialization.JsonSerializer.Parse<ICollection>(_jsonString);
        }

        [Benchmark]
        public byte[] SerializeIList_ToBytes()
        {
            return System.Text.Json.Serialization.JsonSerializer.ToUtf8Bytes(_ilist);
        }

        [Benchmark]
        public byte[] SerializeIEnumerable_ToBytes()
        {
            return System.Text.Json.Serialization.JsonSerializer.ToUtf8Bytes(_ienumerable);
        }

        [Benchmark]
        public byte[] SerializeICollection_ToBytes()
        {
            return System.Text.Json.Serialization.JsonSerializer.ToUtf8Bytes(_icollection);
        }
    }

    [JsonExporterAttribute.Full]
    [MemoryDiagnoser]
    public class JsonDotNet_ReadGenericCollection
    {
        private static readonly IList _ilist = new List<string>();
        private static IEnumerable _ienumerable = new List<string>();
        private static ICollection _icollection = new List<string>();

        private static string _jsonString;

        [Params(2, 50, 100)]
        public int ElementCount;

        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < ElementCount; i++)
            {
                _ilist.Add($"hello{i}");
            }

            _ienumerable = _ilist;
            _icollection = _ilist;

            _jsonString = System.Text.Json.Serialization.JsonSerializer.ToString(_ilist);
        }

        [Benchmark]
        public IEnumerable DeserializeIEnumerable()
        {
            return JsonConvert.DeserializeObject<IEnumerable>(_jsonString);
        }

        [Benchmark]
        public IList DeserializeIList()
        {
            return JsonConvert.DeserializeObject<IList>(_jsonString);
        }

        [Benchmark]
        public ICollection DeserializeICollection()
        {
            return JsonConvert.DeserializeObject<ICollection>(_jsonString);
        }

        [Benchmark]
        public string SerializeIList_ToBytes()
        {
            return JsonConvert.SerializeObject(_ilist);
        }

        [Benchmark]
        public string SerializeIEnumerable_ToBytes()
        {
            return JsonConvert.SerializeObject(_ienumerable);
        }

        [Benchmark]
        public string SerializeICollection_ToBytes()
        {
            return JsonConvert.SerializeObject(_icollection);
        }
    }

    public class Program
    {
        static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
