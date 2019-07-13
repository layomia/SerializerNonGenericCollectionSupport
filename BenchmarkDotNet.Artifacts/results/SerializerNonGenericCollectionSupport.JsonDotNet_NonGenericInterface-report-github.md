``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700 CPU 3.60GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview7-012291
  [Host]     : .NET Core 3.0.0-preview7-27806-02 (CoreCLR 4.700.19.30601, CoreFX 4.700.19.30601), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0-preview7-27806-02 (CoreCLR 4.700.19.30601, CoreFX 4.700.19.30601), 64bit RyuJIT


```
|                               Method | ElementCount |        Mean |        Error |       StdDev |      Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------------------- |------------- |------------:|-------------:|-------------:|------------:|-------:|-------:|------:|----------:|
|                     **DeserializeIList** |            **2** |    **706.8 ns** |    **14.090 ns** |    **36.370 ns** |    **691.9 ns** | **0.6571** |      **-** |     **-** |    **2752 B** |
|               DeserializeICollection |            2 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
|               DeserializeIDictionary |            2 |    927.7 ns |    18.081 ns |    28.150 ns |    922.0 ns | 0.7038 |      - |     - |    2952 B |
|              SerializeIList_ToString |            2 |    490.9 ns |     9.871 ns |     8.751 ns |    488.4 ns | 0.3328 |      - |     - |    1392 B |
|        SerializeIEnumerable_ToString |            2 |    463.6 ns |     4.227 ns |     3.954 ns |    462.0 ns | 0.3328 |      - |     - |    1392 B |
|        SerializeICollection_ToString |            2 |    476.6 ns |     9.300 ns |    13.920 ns |    471.3 ns | 0.3328 |      - |     - |    1392 B |
|        SerializeIDictionary_ToString |            2 |    598.8 ns |     5.070 ns |     4.743 ns |    596.7 ns | 0.3443 |      - |     - |    1440 B |
|        DeserializeIEnumerableWrapper |            2 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
|              DeserializeIListWrapper |            2 |    670.6 ns |    19.896 ns |    18.610 ns |    665.1 ns | 0.6628 |      - |     - |    2776 B |
|        DeserializeICollectionWrapper |            2 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
|        DeserializeIDictionaryWrapper |            2 |    941.6 ns |    10.935 ns |     8.538 ns |    942.8 ns | 0.7105 |      - |     - |    2976 B |
|       SerializeIListWrapper_ToString |            2 |    470.8 ns |    11.648 ns |    12.946 ns |    465.7 ns | 0.3328 |      - |     - |    1392 B |
| SerializeIEnumerableWrapper_ToString |            2 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
| SerializeICollectionWrapper_ToString |            2 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
| SerializeIDictionaryWrapper_ToString |            2 |  1,206.4 ns |    11.254 ns |    10.527 ns |  1,203.9 ns | 0.3624 |      - |     - |    1520 B |
|                     **DeserializeIList** |           **50** |  **5,930.7 ns** |    **65.180 ns** |    **57.781 ns** |  **5,918.3 ns** | **1.3657** |      **-** |     **-** |    **5728 B** |
|               DeserializeICollection |           50 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
|               DeserializeIDictionary |           50 | 11,794.7 ns |   151.936 ns |   142.121 ns | 11,797.3 ns | 2.6703 |      - |     - |   11200 B |
|              SerializeIList_ToString |           50 |  4,008.0 ns |    88.560 ns |   207.006 ns |  3,929.3 ns | 0.6943 |      - |     - |    2920 B |
|        SerializeIEnumerable_ToString |           50 |  3,993.2 ns |    84.795 ns |   165.387 ns |  3,938.3 ns | 0.6943 |      - |     - |    2920 B |
|        SerializeICollection_ToString |           50 |  3,902.5 ns |    38.891 ns |    36.379 ns |  3,906.7 ns | 0.6943 |      - |     - |    2920 B |
|        SerializeIDictionary_ToString |           50 |  6,621.5 ns |    24.531 ns |    20.485 ns |  6,621.6 ns | 1.1902 |      - |     - |    5008 B |
|        DeserializeIEnumerableWrapper |           50 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
|              DeserializeIListWrapper |           50 |  5,863.5 ns |    52.719 ns |    46.734 ns |  5,846.7 ns | 1.3733 |      - |     - |    5752 B |
|        DeserializeICollectionWrapper |           50 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
|        DeserializeIDictionaryWrapper |           50 | 14,844.2 ns | 1,182.449 ns | 3,486.478 ns | 13,184.8 ns | 2.6703 |      - |     - |   11224 B |
|       SerializeIListWrapper_ToString |           50 |  4,369.0 ns |   223.556 ns |   619.471 ns |  4,137.5 ns | 0.6943 |      - |     - |    2920 B |
| SerializeIEnumerableWrapper_ToString |           50 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
| SerializeICollectionWrapper_ToString |           50 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
| SerializeIDictionaryWrapper_ToString |           50 | 22,789.4 ns |   452.861 ns | 1,224.335 ns | 22,383.8 ns | 1.6479 |      - |     - |    7008 B |
|                     **DeserializeIList** |          **100** | **10,958.9 ns** |    **50.428 ns** |    **47.171 ns** | **10,936.4 ns** | **2.0905** |      **-** |     **-** |    **8776 B** |
|               DeserializeICollection |          100 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
|               DeserializeIDictionary |          100 | 25,902.1 ns | 1,157.207 ns | 3,338.805 ns | 24,499.4 ns | 4.9438 | 0.0305 |     - |   20768 B |
|              SerializeIList_ToString |          100 |  7,843.4 ns |   155.026 ns |   267.412 ns |  7,800.6 ns | 1.1902 |      - |     - |    5016 B |
|        SerializeIEnumerable_ToString |          100 |  7,895.8 ns |   151.443 ns |   185.986 ns |  7,880.3 ns | 1.1902 |      - |     - |    5016 B |
|        SerializeICollection_ToString |          100 |  7,433.3 ns |   145.730 ns |   143.127 ns |  7,378.4 ns | 1.1978 |      - |     - |    5016 B |
|        SerializeIDictionary_ToString |          100 | 13,539.6 ns |   298.327 ns |   855.956 ns | 13,175.3 ns | 2.1667 |      - |     - |    9128 B |
|        DeserializeIEnumerableWrapper |          100 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
|              DeserializeIListWrapper |          100 | 11,208.8 ns |    64.324 ns |    60.169 ns | 11,200.8 ns | 2.0905 |      - |     - |    8800 B |
|        DeserializeICollectionWrapper |          100 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
|        DeserializeIDictionaryWrapper |          100 | 23,626.3 ns |   469.393 ns | 1,186.216 ns | 23,290.4 ns | 4.9438 |      - |     - |   20792 B |
|       SerializeIListWrapper_ToString |          100 |  7,723.1 ns |   153.969 ns |   321.391 ns |  7,696.8 ns | 1.1902 |      - |     - |    5016 B |
| SerializeIEnumerableWrapper_ToString |          100 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
| SerializeICollectionWrapper_ToString |          100 |          NA |           NA |           NA |          NA |      - |      - |     - |         - |
| SerializeIDictionaryWrapper_ToString |          100 | 44,108.5 ns |   878.167 ns | 1,793.863 ns | 43,851.0 ns | 3.1128 |      - |     - |   13129 B |

Benchmarks with issues:
  JsonDotNet_NonGenericInterface.DeserializeICollection: DefaultJob [ElementCount=2]
  JsonDotNet_NonGenericInterface.DeserializeIEnumerableWrapper: DefaultJob [ElementCount=2]
  JsonDotNet_NonGenericInterface.DeserializeICollectionWrapper: DefaultJob [ElementCount=2]
  JsonDotNet_NonGenericInterface.SerializeIEnumerableWrapper_ToString: DefaultJob [ElementCount=2]
  JsonDotNet_NonGenericInterface.SerializeICollectionWrapper_ToString: DefaultJob [ElementCount=2]
  JsonDotNet_NonGenericInterface.DeserializeICollection: DefaultJob [ElementCount=50]
  JsonDotNet_NonGenericInterface.DeserializeIEnumerableWrapper: DefaultJob [ElementCount=50]
  JsonDotNet_NonGenericInterface.DeserializeICollectionWrapper: DefaultJob [ElementCount=50]
  JsonDotNet_NonGenericInterface.SerializeIEnumerableWrapper_ToString: DefaultJob [ElementCount=50]
  JsonDotNet_NonGenericInterface.SerializeICollectionWrapper_ToString: DefaultJob [ElementCount=50]
  JsonDotNet_NonGenericInterface.DeserializeICollection: DefaultJob [ElementCount=100]
  JsonDotNet_NonGenericInterface.DeserializeIEnumerableWrapper: DefaultJob [ElementCount=100]
  JsonDotNet_NonGenericInterface.DeserializeICollectionWrapper: DefaultJob [ElementCount=100]
  JsonDotNet_NonGenericInterface.SerializeIEnumerableWrapper_ToString: DefaultJob [ElementCount=100]
  JsonDotNet_NonGenericInterface.SerializeICollectionWrapper_ToString: DefaultJob [ElementCount=100]
