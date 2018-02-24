using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleHashCode.Algorithms
{
    public class TheNewOne : Algorithm
    {
        int r, c,h,l;
        List<Slice> slices;
        int[][] matrix;
        public Dictionary<int, List<Slice>> hashDimentions { get; set; }

        
        private int firstValueTomato = 0, secondValueTomato = 0, tValueTomato = 0, fValueTomato = 0, fifValueTomato = 0;
        private int firstValueMash = 0, secondValueMash = 0, tValueMash = 0, fValueMash = 0, fifValueMash = 0;

        public TheNewOne(int r, int c, int h, int l, int[][] matrix)
        {
            this.r = r;
            this.c = c;
            this.h = h;
            this.l = l;
            this.matrix = matrix;
            slices = new List<Slice>();
            hashDimentions = new Dictionary<int, List<Slice>>();
            
        }
        
        private bool isATomato(int value)
        {
            return value == 0;
        }

        private void addSlice(int c0,int r0,int c1, int r1, ref int tomatoValue, ref int mashValue)
        {
            var countCols = (c1 - c0) + 1;
            var countRows = (r1 - r0) + 1;

            if (countRows * countCols > this.h)
            {
                tomatoValue = 0;
                mashValue = 0;
                return;
            }
            

            var slice = new Slice();

            slice.c1 = c0;
            slice.r1 = r0;
            slice.c2 = c1;
            slice.r2 = r1;

            var key = countRows * countCols;
            if (!hashDimentions.ContainsKey(key))
            {
                hashDimentions[key] = new List<Slice>();
            }

            hashDimentions[key].Add(slice);

            slices.Add(slice);
        }


        private void insertValidSlice(int value,ref int tomatoValue, ref int mashValue,int c1,int r1, int c2, int r2)
        {
            if (isATomato(value))
            {
                tomatoValue++;
            }
            else
            {
                mashValue++;
            }

            if (tomatoValue >= this.l && mashValue >= this.l)
            {
                addSlice(c1, r1, c2, r2,ref tomatoValue,ref mashValue);
            }
        }


        private void first(int col,int row, int inc)
        {
            int firstValue;

            if (col + inc < this.matrix[row].Length)
            {
                firstValue = this.matrix[row][col + inc];
                insertValidSlice(firstValue,ref firstValueTomato, ref firstValueMash,col,row,col+inc,row);
            }
        }



        private void second(int col,int row,int inc)
        {
            int secondValue;
            
            if (row + inc < this.matrix.Length)
            {
                secondValue = this.matrix[row + inc][col];
                
                insertValidSlice(secondValue, ref secondValueTomato, ref secondValueMash,col,row,col,row+inc);
            }
        }


        private void third(int col,int row,int inc)
        {
            int tvalue;

            if (row + inc < this.matrix.Length && col + inc < this.matrix[row + inc].Length)
            {
                tvalue = this.matrix[row + inc][col + inc];
                insertValidSlice(tvalue, ref tValueTomato, ref tValueMash, col, row, col + inc, row + inc);
            }
        }



        private void fourth(int col,int row,int inc)
        {
            int fvalue, fifvalue;

            for (int secondInc = 0; secondInc < this.h; secondInc++)
            {
                
                if (row + secondInc < this.matrix.Length && col + inc < this.matrix[row + secondInc].Length)
                {
                    fvalue = this.matrix[row + secondInc][col + inc];

                    insertValidSlice(fvalue, ref fValueTomato, ref fValueMash, col, row, col + inc, row + secondInc);
                }

                if (row + inc < this.matrix.Length && col + secondInc < this.matrix[row + inc].Length)
                {
                    fifvalue = this.matrix[row + inc][col + secondInc];   
                    insertValidSlice(fifvalue, ref fifValueTomato, ref fifValueMash, col, row, col + secondInc, row + inc);
                }
                
            }
        }


        public void checkSlice(int row,int col)
        {
            firstValueTomato = 0;
            secondValueTomato = 0;
            tValueTomato = 0;
            firstValueMash = 0;
            secondValueMash = 0;
            tValueMash = 0;

            fValueTomato = 0;
            fifValueTomato = 0;
            fValueMash = 0;
            fifValueMash = 0;

            for (int inc=0; inc < this.h; inc++)
            {
                //first(col,row,inc);
                //second(col, row, inc);
                //third(col,row,inc);
                fourth(col,row,inc);
            }
        }
        

        public void cut(int r0, int c0, int r1, int c1)
        {
            for (int row = 0; row < this.r; row++)
            {
                for (int col = 0; col < this.c; col++)
                {
                    checkSlice(row,col);
                }
            }
        }
        
        public Slice[] getResult()
        {
            var slices2 = hashDimentions[5].ToArray();
            var u = new Unificator(this.r,this.c);
            foreach (Slice slice in slices2)
            {
                u.saveDistributedSolution(slice);
            }
            
            return slices2;
            //return slices.ToArray();
        }


    }
}
