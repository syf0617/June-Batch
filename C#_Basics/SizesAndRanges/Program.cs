Console.WriteLine("Type    | Bytes Used | Min Value                           | Max Value");
Console.WriteLine(new string('-', 92));

Console.WriteLine("{0,-7} | {1,10} | {2,33} | {3,33}", "sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
Console.WriteLine("{0,-7} | {1,10} | {2,33} | {3,33}", "byte", sizeof(byte), byte.MinValue, byte.MaxValue);
Console.WriteLine("{0,-7} | {1,10} | {2,33} | {3,33}", "short", sizeof(short), short.MinValue, short.MaxValue);
Console.WriteLine("{0,-7} | {1,10} | {2,33} | {3,33}", "ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
Console.WriteLine("{0,-7} | {1,10} | {2,33} | {3,33}", "int", sizeof(int), int.MinValue, int.MaxValue);
Console.WriteLine("{0,-7} | {1,10} | {2,33} | {3,33}", "uint", sizeof(uint), uint.MinValue, uint.MaxValue);
Console.WriteLine("{0,-7} | {1,10} | {2,33} | {3,33}", "long", sizeof(long), long.MinValue, long.MaxValue);
Console.WriteLine("{0,-7} | {1,10} | {2,33} | {3,33}", "ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
Console.WriteLine("{0,-7} | {1,10} | {2,33} | {3,33}", "float", sizeof(float), float.MinValue, float.MaxValue);
Console.WriteLine("{0,-7} | {1,10} | {2,33} | {3,33}", "double", sizeof(double), double.MinValue, double.MaxValue);
Console.WriteLine("{0,-7} | {1,10} | {2,33} | {3,33}", "decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);