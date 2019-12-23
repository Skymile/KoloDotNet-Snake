using System;

// Menu
// Punkty
// Czas
// Wątki
// Edytor map
// Większe mapy
// WPF/Unity 2D/Avalonia/Winforms/GTK#
// 3D (Unity 3D)

namespace DotNetSnake
{
	class Program
	{
		static void Main()
		{
			// Zaczynamy program od tego miejsca

			var grid = new Grid(8);
			// Tworzymy nową instancje klasy grid, zatem wywoływany 
			// jest jej konstruktor Grid(int size)

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
