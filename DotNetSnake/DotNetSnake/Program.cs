using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetSnake
{
	class Grid
	{
		public Grid(int size)
		{
			this.Size = size;
			this.snake = new Queue<int>();

			this.snake.Enqueue(1);
			this.snake.Enqueue(2);
			this.snake.Enqueue(3);
		}

		public void Step()
		{
			char c = char.ToUpper(Console.ReadKey().KeyChar);

			switch (c)
			{
				case 'W':
					this.snake.Dequeue();
					this.snake.Enqueue(4);
					break;
				case 'S':

					break;
				case 'A':

					break;
				case 'D':

					break;
			}
		}

		public void Display()
		{
			char[] array = new char[this.Size * this.Size];

			foreach (int i in this.snake)
				array[i] = 'x';

			var sb = new StringBuilder();

			for (int i = 0; i < this.Size; i++)
			{
				sb.Append('[');
				for (int j = 0; j < this.Size; j++)
				{
					sb.Append(array[i + j * this.Size])
					  .Append(' ');
				}
				sb.AppendLine("]");
			}

			Console.WriteLine(sb);
		}

		public int Size { get; }

		private readonly Queue<int> snake;
	}

	class Program
	{
		static void Main(string[] args)
		{
			var grid = new Grid(8);

			grid.Display();



			grid.Display();
		}
	}
}
