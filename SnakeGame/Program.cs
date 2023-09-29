using System;
using System.Threading;
using System.Threading.Tasks;


namespace Prog2400_Mid_Term
{
   public class Snake
    {
        int height=15;
        int width = 25;

        int[] x = new int[50];
        int[] y = new int[50];

        int foodX;
        int foodY;

        int parts = 3;

        int score;
        bool lost;
      

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'W';

        Random rd = new Random();

        public Snake()
        {
            x[0] = 5;
            y[0] = 5;
            Console.CursorVisible = false;
            foodX = rd.Next(2, (width - 2));
            foodY = rd.Next(2, (height - 2));
        }

        public void WhiteBoard()
        {
            Console.Clear();
            for(int i=1; i<=(width+2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (width + 2); i++)
            {
                Console.SetCursorPosition(i, (height+2));
                Console.Write("-");
            }
            for (int i = 1; i <= (height + 1); i++)
            {
                Console.SetCursorPosition(i, (height+2));
                Console.Write("|");
            }
            for (int i = 1; i <= (height + 1); i++)
            {
                Console.SetCursorPosition((width+2), i);
                Console.Write("|");
            }
        }
        public void input()
        {
            if(Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }
    
        public void WritePoint(int x, int y)
        {
            Console.SetCursorPosition(x,y);
            Console.Write("*");
        }

        public void GameLogic()
        {
            if(x[0]==foodX)
            {
                if(y[0]==foodY)
                {
                    parts++;
                    score += 100;
                    foodX = rd.Next(2, (width - 2));
                    foodY = rd.Next(2, (height - 2));
                }
            }
            for(int i=parts; i>1; i--)
            {
                x[i - 1] = x[i-2];
                y[i - 1] = y[i - 2];
            }
            switch(key)
            {
                case 'w':
                    y[0]--;
                    break;

                case 's':
                    y[0]++;
                    break;

                case 'd':
                    x[0]++;
                    break;

                case 'a':
                    x[0]--;
                    break;
            }
            for(int i=0; i<=(parts-1); i++)
            {
                WritePoint(x[i], y[i]);
                WritePoint(foodX, foodY);

            }
            Thread.Sleep(100);
        }
        void Shift()
        {
            for(int i=parts+1; i>1; i--)
            {
                x[i - 1] = x[i - 2];
                y[i - 1] = y[i - 2];
            }
        }
        void Setup()
        {
            height = 26;
            width = 26;

            x = new int[50];
            y = new int[50];

            x[0] = 10;
            y[0] = 10;
            x[1] = 10;
            y[1] = 11;
            x[2] = 10;
            y[2] = 12;

            foodX = 10;
            foodY = 3;

            score = 0;
            keyInfo = new ConsoleKeyInfo();

            lost = false;

        }

        static void Main(string[] args)
        {
            Snake snake = new Snake();
            while (true)
            {
                snake.WhiteBoard();
                snake.input();
                snake.GameLogic();
               
            }  
            Console.ReadKey();
        }
    }
}
