using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    class Game
    {
        
        private int per;

        public int[,] puzzle {
            get;
            private set;
        }
        public Game()
        {
            puzzle = new int[4, 4];
            StartGame();
        }
        public void StartGame(bool isNew = true)
        {
            if (isNew)
            {
                Random rnd = new Random();
                per = rnd.Next();
            }
            Random random = new Random(per);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    puzzle[i, j] = i * 4 + j;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int tmp = random.Next(16);

                    swap(ref puzzle[i, j],ref puzzle[tmp / 4, tmp % 4]);
                }
            }
        }
       public void swap(ref int i, ref int j)
        {
            int tmp = i;
            i = j;
            j = tmp;
        }
        public bool isPlayable()
        {
            int N;
            N = calcN() + getZeroRow() + 1;
            if (N % 2 != 0)
            {
                return false;
            }
            return true;   
        }
        int calcN()
        {
            int N = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = i * 4 + j + 1; k < 16; k++)
                    {
                        if (puzzle[i, j] > puzzle[k / 4, k % 4] & puzzle[k / 4, k % 4] > 0)
                            N++;
                    }
                }
            }
            return N;
        }

        public int getZeroRow()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (puzzle[i, j] == 0)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        public int getZeroColumn()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (puzzle[i, j] == 0)
                        return j;
                }
            }
            return -1;
        }

        public bool isFinished()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 3 & j == 3)
                    {
                        break;
                    }
                    if (puzzle[i, j] != 4 * i + j + 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
