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

        private static readonly IDictionary _idictionary = new Dictionary<string, string>();

        private static string _jsonListString;
        private static string _jsonDictString;

        [Params(2, 50, 100)]
        public int ElementCount;

        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < ElementCount; i++)
            {
                _ilist.Add($"hello{i}");
                _idictionary.Add($"hello{i}", $"world{i}");
            }

            _ienumerable = _ilist;
            _icollection = _ilist;

            _jsonListString = System.Text.Json.JsonSerializer.ToString(_ilist);
            _jsonDictString = System.Text.Json.JsonSerializer.ToString(_idictionary);
        }

        //[Benchmark]
        //public IEnumerable DeserializeIEnumerable()
        //{
        //    return System.Text.Json.JsonSerializer.Parse<IEnumerable>(_jsonListString);
        //}

        //[Benchmark]
        //public IList DeserializeIList()
        //{
        //    return System.Text.Json.JsonSerializer.Parse<IList>(_jsonListString);
        //}

        //[Benchmark]
        //public ICollection DeserializeICollection()
        //{
        //    return System.Text.Json.JsonSerializer.Parse<ICollection>(_jsonListString);
        //}

        //[Benchmark]
        //public IList<string> DeserializeGenericIList()
        //{
        //    return System.Text.Json.JsonSerializer.Parse<IList<string>>(_jsonListString);
        //}


        [Benchmark]
        public Stack DeserializeStack()
        {
            return System.Text.Json.JsonSerializer.Parse<Stack>(_jsonListString);
        }

        [Benchmark]
        public Queue DeserializeQueue()
        {
            return System.Text.Json.JsonSerializer.Parse<Queue>(_jsonListString);
        }

        [Benchmark]
        public ArrayList DeserializeArrayList()
        {
            return System.Text.Json.JsonSerializer.Parse<ArrayList>(_jsonListString);
        }

        [Benchmark]
        public Stack<string> DeserializeGenericStack()
        {
            return System.Text.Json.JsonSerializer.Parse<Stack<string>>(_jsonListString);
        }

        [Benchmark]
        public Queue<string> DeserializeGenericQueue()
        {
            return System.Text.Json.JsonSerializer.Parse<Queue<string>>(_jsonListString);
        }

        [Benchmark]
        public HashSet<string> DeserializeGenericHashSet()
        {
            return System.Text.Json.JsonSerializer.Parse<HashSet<string>>(_jsonListString);
        }

        [Benchmark]
        public LinkedList<string> DeserializeGenericLinkedList()
        {
            return System.Text.Json.JsonSerializer.Parse<LinkedList<string>>(_jsonListString);
        }

        [Benchmark]
        public SortedSet<string> DeserializeGenericSortedSet()
        {
            return System.Text.Json.JsonSerializer.Parse<SortedSet<string>>(_jsonListString);
        }

        //[Benchmark]
        //public IDictionary DeserializeIDictionary()
        //{
        //    return System.Text.Json.JsonSerializer.Parse<IDictionary>(_jsonDictString);
        //}

        [Benchmark]
        public IDictionary DeserializeHashtable()
        {
            return System.Text.Json.JsonSerializer.Parse<Hashtable>(_jsonDictString);
        }

        [Benchmark]
        public IDictionary DeserializeSortedList()
        {
            return System.Text.Json.JsonSerializer.Parse<SortedList>(_jsonDictString);
        }

        //[Benchmark]
        //public byte[] SerializeIList_ToBytes()
        //{
        //    return System.Text.Json.JsonSerializer.ToUtf8Bytes(_ilist);
        //}

        //[Benchmark]
        //public byte[] SerializeIEnumerable_ToBytes()
        //{
        //    return System.Text.Json.JsonSerializer.ToUtf8Bytes(_ienumerable);
        //}

        //[Benchmark]
        //public byte[] SerializeICollection_ToBytes()
        //{
        //    return System.Text.Json.JsonSerializer.ToUtf8Bytes(_icollection);
        //}
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

    public class Program
    {
        static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
