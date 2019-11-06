using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetSnake
{
	class Program
	{
		private static int size = 8;
		
		static void Main(string[] args)
		{
			var q = new Queue<int>();

			q.Enqueue(1);
			q.Enqueue(2);
			q.Enqueue(3);

			Display(q);

			char c = Console.ReadKey().KeyChar;

			;


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
