using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DotNetTest
{
	class Program
	{
		static void Main(string[] args)
		{
			const int Size = 1_000;

			var list = new Dictionary<int, string>();
			var array = new (int, string)[Size];

			for (int i = 0; i < Size; i++)
				list.Add(i, i.ToString());
			for (int i = 0; i < Size; i++)
				array[i] = (i, i.ToString());

			var sw1 = Stopwatch.StartNew();
			for (int i = 0; i < Size; i++)
				if (list.ContainsKey(i))
					;
			sw1.Stop();

			var sw2 = Stopwatch.StartNew();
			for (int i = 0; i < Size; i++)
				if (array.Contains((i, i.ToString())))	
					;
			sw2.Stop();

			Console.WriteLine(
$"{sw1.ElapsedTicks} {sw2.ElapsedTicks}"
);
			Console.WriteLine("Hello World!");
		}
	}
}
