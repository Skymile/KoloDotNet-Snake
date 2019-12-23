using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetSnake
{
	internal class Grid
	{
		public Grid(int size)
		{
			// W konstruktorze ustawiamy wartości początkowe
			// pól tej instancji

			this.Size = size;
			this.snake = new Queue<int>();

			this.snake.Enqueue(1);
			this.snake.Enqueue(2);
			this.snake.Enqueue(3);
			// Robimy węża o długości 3 kratek

			SetApple();
			// Ustawiamy jabłko na dowolne niezajęte pole
		}

		private static readonly Dictionary<char, DirectionType> keyToDirection = new Dictionary<char, DirectionType>
		{
			{ 'W', DirectionType.Up    },
			{ 'S', DirectionType.Down  },
			{ 'A', DirectionType.Left  },
			{ 'D', DirectionType.Right },
		};
		// Jest to mapa => dla 'W' będzie DirectionType.Up i tak dalej

		private static readonly Dictionary<char, DirectionType> keyToReverseDirection = new Dictionary<char, DirectionType>
		{
			{ 'W', DirectionType.Down  },
			{ 'S', DirectionType.Up    },
			{ 'A', DirectionType.Right },
			{ 'D', DirectionType.Left  },
		};
		// Tutaj mapujemy wartości przeciwne, by nasz zaskroniec nie mógł zrobić obrotu o 180 stopni

		public bool Step()
		{
			// Metoda która ma się wywołać co krok
		    char c = char.ToUpper(Console.ReadKey().KeyChar);
			// pobieramy nowy znak od użytkownika, 
			// metoda Console.ReadKey() czeka aż użytkownik kliknie dowolny klawisz

			if (keyToDirection.TryGetValue(c, out var dir) &&
				// Jeżeli kliknęliśmy któryś z zaimplementowanych, czyli WSAD
				keyToReverseDirection.TryGetValue(c, out var rev))
				// Jeżeli odwrotny istnieje
			{
				this.snake.Dequeue();
				// Usuwamy ogon, odrośnie przy głowie
				// dzięki temu wygląda jakby się poruszał 
				// bo z jednej strony się zmniejsza a z drugiej wydłuża

				if (this.direction != rev)
					// jeżeli poprzedni nie jest odwrotny do klikniętego
					// jeżeli idziemy w kierunku lewym (A) to nie możemy 
					// teraz obrócić się o 180 stopni w prawo (D)
					this.direction = dir;

				int nextHead = this.head;
				switch (this.direction)
				// teraz część najgłupsza związana z poruszaniem się
				// grzechotnika tam gdzie trzeba
				// Down i Up to u nas przesunięcie o +1 i -1
				// Lewy i prawy to u nas przesunięcia o -Rozmiar i +Rozmiar
				// Oprócz tego ma się jeszcze zawijać i 
				// nie wychodzić poza zakres [0, Rozmiar * Rozmiar)
				{
					case DirectionType.Up:
						if (nextHead % this.Size == 0)
							// Dzięki temu ifowi Up zmienia tylko resztę z dzielenia
								// Zakładając, że rozmiar wynosi 8 i 
								// jesteśmy na 8 indeksie (nextHead jest równe 8)
								// Poruszanie się po Y u nas jest w zakresie [8, 15]
								// if (n % 8 == 0) // prawda
								//     n += 8 // jest 16
								// --n; // jest 15
							nextHead += this.Size;
						--nextHead;
						break;
					case DirectionType.Down:
						++nextHead;
						if (nextHead % this.Size == 0)
							// Dzięki temu ifowi Down zmienia tylko resztę z dzielenia
								// Zakładając, że rozmiar wynosi 8 i 
								// jesteśmy na 15 indeksie (nextHead jest równe 15)
								// Poruszanie się po Y u nas jest w zakresie [8, 15]
								// ++n; // jest 16
								// if (n % 8 == 0) // prawda
								//     n -= 8 // jest 8
							nextHead -= this.Size;
						break;
					case DirectionType.Left:
						nextHead -= this.Size;
						if (nextHead < 0)
							// Po odjęciu jeżeli jest ujemne, dodanie całej długości załawi wyjście poza zakres
							nextHead += this.Size * this.Size;	
						break;
					case DirectionType.Right:
						nextHead += this.Size;
						nextHead %= this.Size * this.Size;
						// Reszta z dzielenia załatwi nam wyjście poza zakres
						break;
				}

				if (this.snake.Contains(nextHead) || 
					// jeśli zderzyliśmy się z samym sobą
					this.walls.Contains(nextHead))
					// albo ścianą
					return false;
					// to sygnalizujemy przegraną

				this.head = nextHead;
				
				if (this.head == this.apple)
				{
					this.snake.Enqueue(this.head);
					SetApple();
				}

				this.snake.Enqueue(this.head);
				// Dzięki temu wygląda jakby się poruszał bo wydłuża się przy głowie
			}

			return true;
		}

		public void Display()
		{
			char[] array = new char[this.Size * this.Size];
			// Tworzymy pustą tablicę

			foreach (int i in this.snake)
				array[i] = 'x';
				// Ustawiamy węża tam gdzie trzeba
			array[this.apple] = '&';
			// i jabłko
			foreach (int i in this.walls)
				array[i] = '#';
				// i ściany

			var sb = new StringBuilder();

			for (int i = 0; i < this.Size; i++)
			{
				sb.Append('[');
				for (int j = 0; j < this.Size; j++)
				{
					sb.Append(array[i + j * this.Size])
					  .Append(' ');
					// możnaby j + i * this.Size by obrócić
					// tworzona jest cała plansza na podstawie współrzędnych
				}
				sb.AppendLine("]");
			}

			Console.Clear(); 
			// czyścimy ekran by wyglądało jakby wąż się poruszał
			Console.WriteLine(sb);
			// i wypisujemy na ekran
		}

		private void SetApple()
		{
			var rnd = new Random();
			// Klasa odpowiedzialna za losowanie
			int cap = this.Size * this.Size;
			// Ma wylosować wartość od 0 do cap

			while (true)
			{
				int value = rnd.Next(0, cap);
				// Losowanie nowej wartości

				if (!this.snake.Contains(value) && 
					!this.walls.Contains(value))
					// jeżeli ten indeks nie istnieje w wężu i ścianach, 
					// czyli jest to puste pole
				{
					this.apple = value;
					// nowe jabłko ustawiamy na te pole
					return;
					// i wychodzimy z funkcji i zarazem z pętli
				}
			}
		}

		public int Size { get; }
		private int head = 3;
		private int apple = -1;

		private readonly Queue<int> snake;
		private readonly List<int> walls = new List<int>
		{
			32, 33, 34, 35, 36, 39
		};

		private DirectionType direction = DirectionType.Down;
	}
}
