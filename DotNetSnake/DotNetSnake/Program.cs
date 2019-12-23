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
