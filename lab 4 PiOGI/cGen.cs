using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4_PiOGI
{
    //0 - empty
    //1-8 - mines around
    //9 - mine
    public class cGen
    {
        int[,] field; 
        int minCount;

        Random rng = new Random();
        public cGen(int N)
      {
            field = new int[N, N];
            minCount = (N * N) / 6;
      }

        bool chekEmpty()
        {
            bool res = false;

            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 9)
                    {
                        res = false; 

                        int l = i - 1;
                        if (l < 0) l = 0;
                        int r = i + 1;
                        if (r >= field.GetLength(0)) r = field.GetLength(0) - 1;

                        int u = j - 1;
                        if (u < 0) u = 0;
                        int d = j + 1;
                        if (d >= field.GetLength(1)) d = field.GetLength(1) - 1;

                        for (int i1 = l; i1 <= r; i1++)
                            for (int j1 = u; j1 <= d; j1++)
                            {
                               if (field[i1, j1] == 0)
                                {
                                    res = true;
                                    break;
                                }
                            }
                        if (res == false)
                            return false;
                    }
                }
            return true;
        }

        void plantMines()
        {
            for (int i = 0; i < minCount; )
            {
                int x = rng.Next(0, field.GetLength(0));
                int y = rng.Next(0, field.GetLength(1));

                if (field[x, y] == 9) continue;

                field[x, y] = 9;

                if (chekEmpty() == false)
                {
                    field[x, y] = 0;
                    continue;
                }
                i++;
            }
        }
        void calculateCells()
        {
            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                {
                   if  (field[i, j] == 0)
                    {
                        int l = i - 1;
                        if (l < 0) l = 0;
                        int r = i + 1;
                        if (r >= field.GetLength(0)) r = field.GetLength(0) - 1;

                        int u = j - 1;
                        if (u < 0) u = 0;
                        int d = j + 1;
                        if (d >= field.GetLength(1)) d = field.GetLength(1) - 1;

                        int sum = 0;

                        for (int i1 = l; i1 <= r; i1++)
                            for (int j1 = u; j1 <= d; j1++)
                            {
                                if (field[i1, j1] == 9) sum++;
                            }
                        field[i, j] = sum;
                    }
                }
        }

        public void generate()
        {
            plantMines();
            calculateCells();
        }
        public int getCell(int i, int j)
        {
            return field[i, j];
        }
    }
}
  
