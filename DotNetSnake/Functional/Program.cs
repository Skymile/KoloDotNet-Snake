using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional
{
	class Randomizer
	{
		public static IEnumerable<int> GetRandomNumbers(
				int count, 
				int cap,
				int seed = 0
			)
		{
			var random = new Random(seed);
			for (int i = 0; i < count; i++)
				yield return random.Next() % cap;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			foreach (int i in 
					Randomizer
						.GetRandomNumbers(16, 10, 0)
						.Where(i => i % 2 == 0)
				)
			{
				Console.WriteLine(i);
			}
			Console.ReadLine();
		}
	}
}
