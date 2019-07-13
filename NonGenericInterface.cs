using System;
using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Newtonsoft.Json;

namespace SerializerNonGenericCollectionSupport
{
    [JsonExporterAttribute.Full]
    [MemoryDiagnoser]
    public class System_NonGenericInterface
    {
        private static readonly IList _ilist = new List<string>();
        private static IEnumerable _ienumerable = new List<string>();
        private static ICollection _icollection = new List<string>();
        private static readonly IDictionary _idictionary = new Dictionary<string, string>();

        private static IListWrapper _ilistwrapper = new IListWrapper();
        private static IEnumerableWrapper _ienumerablewrapper = new IEnumerableWrapper();
        private static ICollectionWrapper _icollectionwrapper = new ICollectionWrapper();
        private static readonly IDictionaryWrapper _idictionarywrapper = new IDictionaryWrapper();

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

                _ilistwrapper.Add($"hello{i}");
                _idictionarywrapper.Add($"hello{i}", $"world{i}");
            }

            _ienumerable = _ilist;
            _icollection = _ilist;

            // TODO: populate ienumerable, icollection, and idictionary wrappers

            _jsonListString = System.Text.Json.JsonSerializer.ToString(_ilist);
            _jsonDictString = System.Text.Json.JsonSerializer.ToString(_idictionary);
        }

        [Benchmark]
        public void DeserializeIEnumerable()
        {
            System.Text.Json.JsonSerializer.Parse<IEnumerable>(_jsonListString);
        }

        [Benchmark]
        public IList DeserializeIList()
        {
            return System.Text.Json.JsonSerializer.Parse<IList>(_jsonListString);
        }

        [Benchmark]
        public ICollection DeserializeICollection()
        {
            return System.Text.Json.JsonSerializer.Parse<ICollection>(_jsonListString);
        }

        [Benchmark]
        public IDictionary DeserializeIDictionary()
        {
            return System.Text.Json.JsonSerializer.Parse<IDictionary>(_jsonDictString);
        }

        [Benchmark]
        public byte[] SerializeIList_ToBytes()
        {
            return System.Text.Json.JsonSerializer.ToUtf8Bytes(_ilist);
        }

        [Benchmark]
        public byte[] SerializeIEnumerable_ToBytes()
        {
            return System.Text.Json.JsonSerializer.ToUtf8Bytes(_ienumerable);
        }

        [Benchmark]
        public byte[] SerializeICollection_ToBytes()
        {
            return System.Text.Json.JsonSerializer.ToUtf8Bytes(_icollection);
        }

        [Benchmark]
        public byte[] SerializeIDictionary_ToBytes()
        {
            return System.Text.Json.JsonSerializer.ToUtf8Bytes(_idictionary);
        }

        [Benchmark]
        public IEnumerableWrapper DeserializeIEnumerableWrapper()
        {
            return System.Text.Json.JsonSerializer.Parse<IEnumerableWrapper>(_jsonListString);
        }

        [Benchmark]
        public IListWrapper DeserializeIListWrapper()
        {
            return System.Text.Json.JsonSerializer.Parse<IListWrapper>(_jsonListString);
        }

        [Benchmark]
        public ICollectionWrapper DeserializeICollectionWrapper()
        {
            return System.Text.Json.JsonSerializer.Parse<ICollectionWrapper>(_jsonListString);
        }

        [Benchmark]
        public IDictionaryWrapper DeserializeIDictionaryWrapper()
        {
            return System.Text.Json.JsonSerializer.Parse<IDictionaryWrapper>(_jsonDictString);
        }

        [Benchmark]
        public byte[] SerializeIListWrapper_ToBytes()
        {
            return System.Text.Json.JsonSerializer.ToUtf8Bytes(_ilist);
        }

        [Benchmark]
        public byte[] SerializeIEnumerableWrapper_ToBytes()
        {
            return System.Text.Json.JsonSerializer.ToUtf8Bytes(_ienumerablewrapper);
        }

        [Benchmark]
        public byte[] SerializeICollectionWrapper_ToBytes()
        {
            return System.Text.Json.JsonSerializer.ToUtf8Bytes(_icollectionwrapper);
        }

        [Benchmark]
        public byte[] SerializeIDictionaryWrapper_ToBytes()
        {
            return System.Text.Json.JsonSerializer.ToUtf8Bytes(_idictionarywrapper);
        }
    }

    [JsonExporterAttribute.Full]
    [MemoryDiagnoser]
    public class JsonDotNet_NonGenericInterface
    {
        private static readonly IList _ilist = new List<string>();
        private static IEnumerable _ienumerable = new List<string>();
        private static ICollection _icollection = new List<string>();
        private static readonly IDictionary _idictionary = new Dictionary<string, string>();

        private static IListWrapper _ilistwrapper = new IListWrapper();
        private static IEnumerableWrapper _ienumerablewrapper = new IEnumerableWrapper();
        private static ICollectionWrapper _icollectionwrapper = new ICollectionWrapper();
        private static readonly IDictionaryWrapper _idictionarywrapper = new IDictionaryWrapper();

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

                _ilistwrapper.Add($"hello{i}");
                _idictionarywrapper.Add($"hello{i}", $"world{i}");
            }

            _ienumerable = _ilist;
            _icollection = _ilist;

            // TODO: populate ienumerable, icollection, and idictionary wrappers

            _jsonListString = JsonConvert.SerializeObject(_ilist);
            _jsonDictString = JsonConvert.SerializeObject(_idictionary);
        }

        //[Benchmark]
        //public void DeserializeIEnumerable()
        //{
        //    JsonConvert.DeserializeObject<IEnumerable>(_jsonListString);
        //}

        [Benchmark]
        public IList DeserializeIList()
        {
            return JsonConvert.DeserializeObject<IList>(_jsonListString);
        }

        [Benchmark]
        public ICollection DeserializeICollection()
        {
            return JsonConvert.DeserializeObject<ICollection>(_jsonListString);
        }

        [Benchmark]
        public IDictionary DeserializeIDictionary()
        {
            return JsonConvert.DeserializeObject<IDictionary>(_jsonDictString);
        }

        [Benchmark]
        public string SerializeIList_ToString()
        {
            return JsonConvert.SerializeObject(_ilist);
        }

        [Benchmark]
        public string SerializeIEnumerable_ToString()
        {
            return JsonConvert.SerializeObject(_ienumerable);
        }

        [Benchmark]
        public string SerializeICollection_ToString()
        {
            return JsonConvert.SerializeObject(_icollection);
        }

        [Benchmark]
        public string SerializeIDictionary_ToString()
        {
            return JsonConvert.SerializeObject(_idictionary);
        }

        [Benchmark]
        public IEnumerableWrapper DeserializeIEnumerableWrapper()
        {
            return JsonConvert.DeserializeObject<IEnumerableWrapper>(_jsonListString);
        }

        [Benchmark]
        public IListWrapper DeserializeIListWrapper()
        {
            return JsonConvert.DeserializeObject<IListWrapper>(_jsonListString);
        }

        [Benchmark]
        public ICollectionWrapper DeserializeICollectionWrapper()
        {
            return JsonConvert.DeserializeObject<ICollectionWrapper>(_jsonListString);
        }

        [Benchmark]
        public IDictionaryWrapper DeserializeIDictionaryWrapper()
        {
            return JsonConvert.DeserializeObject<IDictionaryWrapper>(_jsonDictString);
        }

        [Benchmark]
        public string SerializeIListWrapper_ToString()
        {
            return JsonConvert.SerializeObject(_ilist);
        }

        [Benchmark]
        public string SerializeIEnumerableWrapper_ToString()
        {
            return JsonConvert.SerializeObject(_ienumerablewrapper);
        }

        [Benchmark]
        public string SerializeICollectionWrapper_ToString()
        {
            return JsonConvert.SerializeObject(_icollectionwrapper);
        }

        [Benchmark]
        public string SerializeIDictionaryWrapper_ToString()
        {
            return JsonConvert.SerializeObject(_idictionarywrapper);
        }
    }

    public class IEnumerableWrapper : IEnumerable
    {
        private readonly List<object> _list;

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }

    public class ICollectionWrapper : ICollection
    {
        private readonly List<object> _list;

        public int Count => _list.Count;

        public bool IsSynchronized => ((ICollection)_list).IsSynchronized;

        public object SyncRoot => ((ICollection)_list).SyncRoot;

        public void CopyTo(Array array, int index)
        {
            ((ICollection)_list).CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return ((ICollection)_list).GetEnumerator();
        }
    }

    public class IListWrapper : IList
    {
        private readonly List<object> _list;

        public IListWrapper()
        {
            _list = new List<object>();
        }

        public object this[int index] { get => ((IList)_list)[index]; set => ((IList)_list)[index] = value; }

        public bool IsFixedSize => ((IList)_list).IsFixedSize;

        public bool IsReadOnly => ((IList)_list).IsReadOnly;

        public int Count => _list.Count;

        public bool IsSynchronized => ((IList)_list).IsSynchronized;

        public object SyncRoot => ((IList)_list).SyncRoot;

        public int Add(object value)
        {
            return ((IList)_list).Add(value);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(object value)
        {
            return ((IList)_list).Contains(value);
        }

        public void CopyTo(Array array, int index)
        {
            ((IList)_list).CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IList)_list).GetEnumerator();
        }

        public int IndexOf(object value)
        {
            return _list.IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            _list.Insert(index, value);
        }

        public void Remove(object value)
        {
            _list.Remove(value);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }
    }

    public class IDictionaryWrapper : IDictionary
    {
        private readonly Dictionary<string, object> _dictionary;

        public IDictionaryWrapper()
        {
            _dictionary = new Dictionary<string, object>();
        }

        public object this[object key] { get => ((IDictionary)_dictionary)[key]; set => ((IDictionary)_dictionary)[key] = value; }

        public bool IsFixedSize => ((IDictionary)_dictionary).IsFixedSize;

        public bool IsReadOnly => ((IDictionary)_dictionary).IsReadOnly;

        public ICollection Keys => ((IDictionary)_dictionary).Keys;

        public ICollection Values => ((IDictionary)_dictionary).Values;

        public int Count => _dictionary.Count;

        public bool IsSynchronized => ((IDictionary)_dictionary).IsSynchronized;

        public object SyncRoot => ((IDictionary)_dictionary).SyncRoot;

        public void Add(object key, object value)
        {
            ((IDictionary)_dictionary).Add(key, value);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Contains(object key)
        {
            return ((IDictionary)_dictionary).Contains(key);
        }

        public void CopyTo(Array array, int index)
        {
            ((IDictionary)_dictionary).CopyTo(array, index);
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return ((IDictionary)_dictionary).GetEnumerator();
        }

        public void Remove(object key)
        {
            ((IDictionary)_dictionary).Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary)_dictionary).GetEnumerator();
        }
    }
}
