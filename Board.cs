using System;
namespace Tetris{
	class Board{
		public bool[][] Units;
		public static int Width = 15, Height = 20;
		
		public Board(){
			Units = new bool[Height][];
			for(int y = 0; y < Height; y++){
				Units[y] = new bool[Width];
			}
		}

		public void Draw(){
			for(int y = 0; y < Height; y++){
				for(int x = 0; x < Width; x++){
					if(Units[y][x]){
						Console.SetCursorPosition(x, y);
						Console.WriteLine(0);
					}
				}

				bool temp = true;
				//Checks if line is full.
				for(int i = 0; i < Width; i++){
					temp = temp && Units[y][i];
				}
				//Converts the full line into an empty one.
				if(temp){
					for(int i = 0; i < Width; i++){
						Units[y][i] = false;
					}
				}
				//Reuses variable
				temp = true;
				//Checks if there is an empty line.
				for(int i = 0; i < Width; i++){
					temp = temp && !Units[y][i];
				}
				//Moves lines from top to buttom to fill the gap.
				if(temp){
					for(int i = y; i > 0; i--){
						Units[i] = Units[i-1];
						Units[0] = new bool[Width];
					}
				}
			}
		}
	}
}