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

			SetApple();
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

		public bool Step()
		{
		    char c = char.ToUpper(Console.ReadKey().KeyChar);
			
			if (keyToDirection.TryGetValue(c, out var dir) &&
				keyToReverseDirection.TryGetValue(c, out var rev))
			{
				this.snake.Dequeue();
				if (this.direction != rev)
					this.direction = dir;

				int nextHead = this.head;
				switch (this.direction)
				{
					case DirectionType.Up:
						if (nextHead % this.Size == 0)
							nextHead += this.Size;
						--nextHead;
						break;
					case DirectionType.Down:
						++nextHead;
						if (nextHead % this.Size == 0)
							nextHead -= this.Size;
						break;
					case DirectionType.Left:
						nextHead -= this.Size;
						if (nextHead < 0)
							nextHead += this.Size * this.Size;	
						break;
					case DirectionType.Right:
						nextHead += this.Size;
						nextHead %= this.Size * this.Size;
						break;
				}

				if (this.snake.Contains(nextHead))
					return false;
				this.head = nextHead;
				
				if (this.head == this.apple)
				{
					this.snake.Enqueue(this.head);
					SetApple();
				}

				this.snake.Enqueue(this.head);
			}

			return true;
		}

		public void Display()
		{
			char[] array = new char[this.Size * this.Size];

			foreach (int i in this.snake)
				array[i] = 'x';
			array[this.apple] = '&';

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

		private void SetApple()
		{
			var rnd = new Random();
			int cap = this.Size * this.Size;

			while (true)
			{
				int value = rnd.Next(0, cap);
				if (!this.snake.Contains(value))
				{
					this.apple = value;
					return;
				}
			}
		}

		public int Size { get; }
		private int head = 3;
		private int apple = -1;

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
				if (!grid.Step())
					break;
			}

			Console.WriteLine("Koniec");
			Console.ReadLine();
		}
	}
}
// 01234567
//  123    
//   234  
