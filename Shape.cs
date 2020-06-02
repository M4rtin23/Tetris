using System;
namespace Tetris{
	class Shape{
		int x, y;
		int[] subX = new int[4], subY = new int[4];

		public Shape(int x, int y){
			this.x = x;
			this.y = y;
			subX[0] = 0;
			subY[0] = 0;
			shape3();
		}

		public void Update(){
			if(!Console.KeyAvailable){
				if(collition()){
					place();
					selectShape(new Random(x*y).Next(1, 7));
					//restart position.
					x = Board.Width/2;
					y = -2;
				}else{
					y++;
				}
				draw();
			}else{
				switch(Console.ReadKey(true).Key){
					case ConsoleKey.A:
						if(checkLeft()){
							x--;
						}
						break;
			
					case ConsoleKey.D:
						if(checkRight()){
							x++;
						}
						break;
			
					case ConsoleKey.S:
						rotate();
						break;
				}
			}
		}

		private void draw(){
			for(int i = 0; i < 4; i++){
				if(subY[i] + y >= 0){
					Console.SetCursorPosition(subX[i]+x, subY[i]+y);
					Console.WriteLine(1);
				}
			}
		}

		private void rotate(){
			for(int i = 0; i < 4; i++){
				int sy = subY[i];
				subY[i] = subX[i];
				subX[i] = -sy;
			}
			rearrange();
		}

		private bool collition(){
			bool result = false;
			for(int i = 0; i < 4; i++){
				if(subY[i]+y+1 == Board.Height){
					result = true;
					goto END;
				}
			}
			for(int i = 0; i < 4; i++){
				if(subY[i] + y >= 0){
					if(Program.Board1.Units[subY[i]+y+1][subX[i]+x]){
						result = true;
						goto END;
					}
				}
			}
			END:
			return result;
		}

		private bool checkLeft(){
			bool result = true;
			for(int i = 0; i < 4; i++){
				if(subX[i] + x < 1){
					result = false;
					goto END;
				}
			}
			if(isInside())
			for(int i = 0; i < 4; i++){
				if(Program.Board1.Units[subY[i]+y][subX[i]+x-1]){
					result = false;
					goto END;
				}
			}
			END:
			return result;
		}

		private bool checkRight(){
			bool result = true;
			for(int i = 0; i < 4; i++){
				if(subX[i]+x > Board.Width-2){
					result = false;
					goto END;
				}
			}
			if(isInside())
			for(int i = 0; i < 4; i++){
				if(Program.Board1.Units[subY[i]+y][subX[i]+x+1]){
					result = false;
					goto END;
				}
			}
			END:
			return result;
		}

		private void place(){
			for(int i = 0; i < 4; i++){
				Program.Board1.Units[subY[i]+y][subX[i]+x] = true;
			}
		}

		private void rearrange(){
			START:
			for(int i = 0; i < 4; i++){
				if(subX[i] + x > Board.Width-1){
					x--;
					goto START;
				}
			}
			for(int i = 0; i < 4; i++){
				if(subX[i] + x < 1){
					x++;
					goto START;
				}
			}
		}

		private bool isInside(){
			bool result = true;
			for(int i = 0; i < 4; i++){
				if(subY[i]+y < 0){
					result = false;
					break;
				}
			}
			return result;
		}

		#region shapes
		void shape1(){
			subX[1] = 1;
			subY[1] = 0;
			subX[3] = 2;
			subX[2] = -1;
			subY[2] = 0;
			subY[3] = 0;
		}
		void shape2(){
			subX[1] = -1;
			subY[1] = -1;
			subX[2] = -1;
			subY[2] = 0;
			subX[3] = 0;
			subY[3] = -1;
		}
		void shape3(){
			subX[1] = 1;
			subY[1] = 0;
			subX[2] = -1;
			subY[2] = 0;
			subX[3] = 0;
			subY[3] = -1;
		}
		void shape4(){
			subX[1] = 1;
			subY[1] = 0;
			subX[2] = -1;
			subY[2] = 0;
			subX[3] = 1;
			subY[3] = -1;
		}
		void shape5(){
			subX[1] = 0;
			subY[1] = -1;
			subX[2] = -1;
			subY[2] = 0;
			subX[3] = 1;
			subY[3] = -1;
		}
		void shape6(){
			subX[1] = 1;
			subY[1] = 0;
			subX[2] = -1;
			subY[2] = 0;
			subX[3] = -1;
			subY[3] = -1;
		}
		void shape7(){
			subX[1] = -1;
			subY[1] = -1;
			subX[2] = 1;
			subY[2] = 0;
			subX[3] = 0;
			subY[3] = -1;
		}
		void selectShape(int number){
			switch(number){
				case 1:
					shape1();
				break;
				case 2:
					shape2();
				break;
				case 3:
					shape3();
				break;
				case 4:
					shape4();
				break;
				case 5:
					shape5();
				break;
				case 6:
					shape6();
				break;
				case 7:
					shape7();
				break;
			}
		}
		#endregion
	}
}