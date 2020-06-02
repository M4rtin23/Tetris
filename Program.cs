using System;
namespace Tetris{
	class Program{
		public static Board Board1 = new Board();
		static void Main(string[] args){
			Shape shape = new Shape(9, 5);
			Console.CursorVisible = false;

			for(int t = 0; true; t++){
				t = t % 12000000;
				if(t == 0){
					Console.Clear();
					for(int i = 0; i < Board.Width; i++){
						Console.SetCursorPosition(i, Board.Height);
						Console.Write("═");
					}
					for(int i = 0; i < Board.Height; i++){
						Console.SetCursorPosition(Board.Width, i);
						Console.Write("║");
					}

					shape.Update();
					Board1.Draw();
				}
			}
		}
	}
}
