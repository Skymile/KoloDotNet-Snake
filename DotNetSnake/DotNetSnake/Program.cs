using System;
using System.Text;

namespace DotNetSnake
{
	class Program
	{
		private static int size = 4;

		static void Main(string[] args)
		{
			Display();
		}

		private static void Display()
		{
			var sb = new StringBuilder();

			for (int i = 0; i < 9; i++)
				sb.Append(i);
			int j = 0;
			while (j < 9)
			{
				sb.Append(j);
				++j;
			}

			int k = 0;
			do
			{
				sb.Append(k);
				++k;
			} while (k < 9);

			Console.WriteLine(sb);
		}
	}
}
