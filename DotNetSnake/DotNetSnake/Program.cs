using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetSnake
{
	class Program
	{
		private static int size = 8;

		static void Test()
		{
			int[] tab = new int[4];
			int[] bb =
			{
				1, 2, 3, 4
			};
			int[][] tab1 = new int[4][];
			tab1[0] = new int[5] { 1, 2, 3, 4, 5 };
			int[,,,,,,,,,] bg;

			var list = new List<int>();

			var queue = new Queue<int>();
			// 123
			// 23
			// 234

			var stack = new Stack<int>();
			// 123
			// 23
			// 423

			var linkedlist = new LinkedList<int>();
			// 1 <-> 2 <-> 3 <-> 4 <-> 5 <-> 6

			var dict = new Dictionary<string, int>();
			dict.Add("asda", 8);
			dict.Add("asdd", 8);
			dict.Add("asde", 8);

			dict["asda"] = 4;


		}

		static void Main(string[] args)
		{
			var q = new Queue<int>();


			q.Enqueue(1);
			q.Enqueue(2);
			q.Enqueue(3);

			Display(q);

			char c = char.ToUpper(Console.ReadKey().KeyChar);

			switch (c)
			{
				case 'W':
					q.Dequeue();
					q.Enqueue(4);
					break;
				case 'S':

					break;
				case 'A':

					break;
				case 'D':

					break;
			}
			Display(q);

		}

		private static void Display(Queue<int> queue)
		{
			char[] array = new char[size * size];

			foreach (int i in queue)
				array[i] = 'x';

			var sb = new StringBuilder();

			for (int i = 0; i < size; i++)
			{
				sb.Append('[');
				for (int j = 0; j < size; j++)
				{
					sb.Append(array[i + j * size])
					  .Append(' ');
				}
				sb.AppendLine("]");
			}

			Console.WriteLine(sb);
		}
	}
}
