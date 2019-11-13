using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetSnake
{
	public enum DirectionType
	{
		Left, Right, Up, Down
	}

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

		private static void ChangeDirection(ref DirectionType direction)
		{
			if (direction == DirectionType.)
		}

		private static readonly Dictionary<char, DirectionType> keyToDirection = new Dictionary<char, DirectionType>
		{
			{ 'W', DirectionType.Up    },
			{ 'S', DirectionType.Down  },
			{ 'A', DirectionType.Left  },
			{ 'D', DirectionType.Right },
		};

		private static readonly Dictionary<char, DirectionType> keyToReverseDirection = new Dictionary<char, DirectionType>
		{
			{ 'W', DirectionType.Down  },
			{ 'S', DirectionType.Up    },
			{ 'A', DirectionType.Right },
			{ 'D', DirectionType.Left  },
		};

		public void Step()
		{
			char c = char.ToUpper(Console.ReadKey().KeyChar);

			switch (c)
			{
				case 'W':
					if (this.direction == DirectionType.Down)
						break;
					this.direction = DirectionType.Up;
					this.snake.Dequeue();
					this.snake.Enqueue(--this.head);
					break;
				case 'S':
					if (this.direction == DirectionType.Up)
						break;
					this.direction = DirectionType.Down;
					this.snake.Dequeue();
					this.snake.Enqueue(++this.head);
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

			Console.Clear();
			Console.WriteLine(sb);
		}

		public int Size { get; }
		private int head = 3;

		private readonly Queue<int> snake;
		private DirectionType direction = DirectionType.Down;
	}

	class Program
	{
		static void Main(string[] args)
		{
			var grid = new Grid(8);

			while (true)
			{
				grid.Display();
				grid.Step();
			}

			Console.ReadLine();
		} 
	}
}
// 01234567
//  123    
//   234  
