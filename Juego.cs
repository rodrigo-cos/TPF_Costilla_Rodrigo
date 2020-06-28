
using System;

namespace juegoIA
{
	class Juego
	{
		public static void Main(string[] args)
		{
			char seleccionar;
			do{
			Console.Clear();
			Game game = new Game();
			game.play();
			Console.WriteLine("¿Desea jugar otra partida? (S/N)");
			seleccionar=char.Parse(Console.ReadLine());
			
			} while(seleccionar=='S'||seleccionar=='s');
		}
	}
}