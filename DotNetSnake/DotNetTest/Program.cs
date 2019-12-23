using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

// Benchmark.NET

// Template Method -- algorytm z wymiennymi krokami
// 1. Przetworzenie obrazu na surową tablice bajtów
// 2. Zamienny // Szarość, czarnobiały, Niblack KMM
// 3. Odwrotne przetworzenie

// Factory -- decydowaniu jaki ma być stworzony obiekt
// Prostokat Trojkat IKsztalt 
// Punkty
// var fac = new Factory();
// fac.Create((1, 2), (2, 3), (3,4))

// Builder -- tworzenie obiektów na podstawie części
// Częściowe dawanie punktów

// Monada -- Automatyzacji i uproszczenia logiki obliczeń
// abstrakcyjny generyczny konstruktor typów obliczeniowych
//
// a.Where()
//  .Select()
// 
// Task.Run(() => a.Where())
//  .ContinueWith()
//  .Select()
//
// a = a.Where()
// if (!a.Empty())
//    return a.Select()
// 
// a.Where()
//   .Select()
//

namespace DotNetTest
{
	public class UnitTestSample
	{
		public int A() => 4;
	}

	class MyClass : IDisposable
	{
		public void Dispose() =>
			this.tab = null;

		private int[] tab = new int[123810];
	}

	class EnumerableImpl : IEnumerable<int>
	{
		public IEnumerator<int> GetEnumerator() => list.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();

		class MyClass : IEnumerator<int>
		{
			public int Current { get; }
			object IEnumerator.Current { get; }

			public void Dispose() => throw new NotImplementedException();
			public bool MoveNext() => throw new NotImplementedException();
			public void Reset() => throw new NotImplementedException();
		}

		List<int> list = new List<int>();
	}

	class Program
	{
		static IEnumerable<int> Range()
		{
			int i = 0;
			while (true)
			{
				yield return i++;
				if (i == 10)
					yield break;
			}
		}

		static void EnumerableTest()
		{
			var eeee = new EnumerableImpl();

			foreach (var i in Range())
			{
				;
			}

			foreach (var i in eeee)
			{

			}

			foreach (var item in new List<int>())
			{

			}
		}

		static void ReaderTest()
		{
			using (var reader = new StreamReader("aa.txt"))
			{
				reader.ReadLine();
			}
			string s = File.ReadAllText("aa.txt");
			using (var writer = new StreamWriter("aa.txt"))
				writer.WriteLine("aa");
			File.WriteAllText("aa.txt", "asdsadasda");
		}

		static void DisposableTest()
		{
			using var test1 = new MyClass();
			using (var test = new MyClass())
			{

			}
		}

		static void BenchmarkingTest()
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

			Console.WriteLine($"{sw1.ElapsedTicks} {sw2.ElapsedTicks}");
		}

		static void Main(string[] args)
		{
			BenchmarkingTest();
			Console.WriteLine("Hello World!");
		}
	}
}
