using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Newtonsoft.Json;

namespace SerializerNonGenericCollectionSupport
{
    [JsonExporterAttribute.Full]
    [MemoryDiagnoser]
    public class System_Immutable
    {
        private static IImmutableList<string> _iimmutablelist;
        private static IImmutableStack<string> _iimmutablestack;
        private static IImmutableQueue<string> _iimmutablequeue;
        private static IImmutableSet<string> _iimmutableset;
        private static IImmutableDictionary<string, string> _iimmutabledictionary;
        private static ImmutableArray<string> _immutablearray;
        private static ImmutableList<string> _immutablelist;
        private static ImmutableStack<string> _immutablestack;
        private static ImmutableQueue<string> _immutablequeue;
        private static ImmutableSortedSet<string> _immutablesortedset;
        private static ImmutableHashSet<string> _immutablehashset;
        private static ImmutableDictionary<string, string> _immutabledictionary;
        private static ImmutableSortedDictionary<string, string> _immutablesorteddictionary;

        private static string _jsonListString;
        private static string _jsonDictString;

        [Params(2, 50, 100)]
        public int ElementCount;

        [GlobalSetup]
        public void Setup()
        {
            List<string> list = new List<string> { };
            Dictionary<string, string> dict = new Dictionary<string, string> { };

            for (int i = 0; i < ElementCount; i++)
            {
                list.Add($"hello{i}");
                dict.Add($"hello{i}", $"world{i}");
            }

            _iimmutablelist = ImmutableList.CreateRange(list);
            _iimmutablestack = ImmutableStack.CreateRange(list);
            _iimmutablequeue = ImmutableQueue.CreateRange(list);
            _iimmutableset = ImmutableHashSet.CreateRange(list);
            _iimmutabledictionary = ImmutableDictionary.CreateRange(dict);
            _immutablearray = ImmutableArray.CreateRange(list);
            _immutablelist = ImmutableList.CreateRange(list);
            _immutablestack = ImmutableStack.CreateRange(list);
            _immutablequeue = ImmutableQueue.CreateRange(list);
            _immutablesortedset = ImmutableSortedSet.CreateRange(list);
            _immutablehashset = ImmutableHashSet.CreateRange(list);
            _immutabledictionary = ImmutableDictionary.CreateRange(dict);
            _immutablesorteddictionary = ImmutableSortedDictionary.CreateRange(dict);

            _jsonListString = System.Text.Json.JsonSerializer.Serialize(list);
            _jsonDictString = System.Text.Json.JsonSerializer.Serialize(dict);
        }

        [Benchmark]
        public IImmutableList<string> DeserializeIImmutableList()
        {
            return System.Text.Json.JsonSerializer.Deserialize<IImmutableList<string>>(_jsonListString);
        }

        [Benchmark]
        public IImmutableStack<string> DeserializeIImmutableStack()
        {
            return System.Text.Json.JsonSerializer.Deserialize<IImmutableStack<string>>(_jsonListString);
        }

        [Benchmark]
        public IImmutableQueue<string> DeserializeIImmutableQueue()
        {
            return System.Text.Json.JsonSerializer.Deserialize<IImmutableQueue<string>>(_jsonListString);
        }

        [Benchmark]
        public IImmutableSet<string> DeserializeIImmutableSet()
        {
            return System.Text.Json.JsonSerializer.Deserialize<IImmutableSet<string>>(_jsonListString);
        }

        [Benchmark]
        public IImmutableDictionary<string, string> DeserializeIImmutableDictionary()
        {
            return System.Text.Json.JsonSerializer.Deserialize<IImmutableDictionary<string, string>>(_jsonDictString);
        }

        [Benchmark]
        public ImmutableList<string> DeserializeImmutableList()
        {
            return System.Text.Json.JsonSerializer.Deserialize<ImmutableList<string>>(_jsonListString);
        }

        [Benchmark]
        public ImmutableStack<string> DeserializeImmutableStack()
        {
            return System.Text.Json.JsonSerializer.Deserialize<ImmutableStack<string>>(_jsonListString);
        }

        [Benchmark]
        public ImmutableQueue<string> DeserializeImmutableQueue()
        {
            return System.Text.Json.JsonSerializer.Deserialize<ImmutableQueue<string>>(_jsonListString);
        }

        [Benchmark]
        public ImmutableSortedSet<string> DeserializeImmutableSortedSet()
        {
            return System.Text.Json.JsonSerializer.Deserialize<ImmutableSortedSet<string>>(_jsonListString);
        }

        [Benchmark]
        public ImmutableHashSet<string> DeserializeImmutableHashSet()
        {
            return System.Text.Json.JsonSerializer.Deserialize<ImmutableHashSet<string>>(_jsonListString);
        }

        [Benchmark]
        public IImmutableDictionary<string, string> DeserializeIImmutableDictionary()
        {
            return System.Text.Json.JsonSerializer.Deserialize<IImmutableDictionary<string, string>>(_jsonDictString);
        }

        [Benchmark]
        public ImmutableDictionary<string, string> DeserializeImmutableDictionary()
        {
            return System.Text.Json.JsonSerializer.Deserialize<ImmutableDictionary<string, string>>(_jsonDictString);
        }

        [Benchmark]
        public ImmutableSortedDictionary<string, string> DeserializeImmutableSortedDictionary()
        {
            return System.Text.Json.JsonSerializer.Deserialize<ImmutableSortedDictionary<string, string>>(_jsonDictString);
        }

        [Benchmark]
        public byte[] SerializeIImmutableList()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_immutablelist);
        }

        [Benchmark]
        public byte[] SerializeIImmutableStack()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_iimmutablestack);
        }

        [Benchmark]
        public byte[] SerializeIImmutableQueue()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_iimmutablequeue);
        }

        [Benchmark]
        public byte[] SerializeIImmutableSet()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_iimmutableset);
        }

        [Benchmark]
        public byte[] SerializeIImmutableDictionary()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_iimmutabledictionary);
        }

        [Benchmark]
        public byte[] SerializeImmutableList()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_immutablelist);
        }

        [Benchmark]
        public byte[] SerializeImmutableStack()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_immutablestack);
        }

        [Benchmark]
        public byte[] SerializeImmutableQueue()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_immutablequeue);
        }

        [Benchmark]
        public byte[] SerializeImmutableSortedSet()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_immutablesortedset);
        }

        [Benchmark]
        public byte[] SerializeImmutableHashSet()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_immutablehashset);
        }

        [Benchmark]
        public byte[] SerializeImmutableDictionary()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_immutabledictionary);
        }

        [Benchmark]
        public byte[] SerializeImmutableSortedDictionary()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_immutablesorteddictionary);
        }
    }

    [JsonExporterAttribute.Full]
    [MemoryDiagnoser]
    public class JsonDotNet_Immutable
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

            _jsonString = System.Text.Json.JsonSerializer.ToString(_ilist);
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
}
