using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleHashCode.Algorithms
{
    public class FakeAlgorithm : Algorithm
    {
        Dictionary<string, Slice> hashSlices;
        List<Slice> slices;
        int c,r,l,h;
        int[][] matrix;

        public FakeAlgorithm(int c, int r, int l, int h, int[][] matrix)
        {
            this.c = c;
            this.r = r;
            this.l = l;
            this.h = h;
            this.matrix = matrix;
            hashSlices = new Dictionary<string, Slice>();
            slices = new List<Slice>();
        }

        public Slice[] getResult()
        {
            return slices.ToArray();
        }

        private bool isATomato(int value)
        {
            return value == 0;
        }

        private bool haveSlice(int r0, int c0, int r1, int c1)
        {

            var key = r0.ToString() + c0.ToString() + r1.ToString() + c1.ToString();
            if (!hashSlices.ContainsKey(key))
            {
                hashSlices[key] = new Slice();
            }
            else
            {
                return false;
            }

            var countCols = (c1 - c0) + 1;
            var countRows = (r1 - r0) + 1;

            if (countRows * countCols > this.h)
            {
                return false;
            }

            var mushCount = 0;
            var tomCount = 0;

            for (var row = 0; row < countRows; row++)
            {
                for (var col = 0; col < countCols; col++)
                {

                    var finalRow = row + r0;
                    var finalCol = col + c0;

                    if (isATomato(matrix[finalRow][finalCol]))
                    {
                        tomCount++;
                    }
                    else
                    {
                        mushCount++;
                    }

                    if (mushCount >= this.l && tomCount >= this.l)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        private int getInitialRow()
        {
            var lastRow = slices.Count > 0 ? slices.Last().r1 : 0;

            return lastRow;
        }

        private int getInitialCol()
        {
            var lastCol = slices.Count > 0 ? slices.Last().c2 : 0;

            return lastCol;
        }


        public void cut(int r0, int c0, int r1, int c1)
        {
            /*
            if (haveSolution())
            {
                return;
            }*/

            if (c1 >= this.c || r1 >= this.r || r0 >= this.r || c0 >= this.c)
            {
                return;
            }

            int rfinal = r1;
            int cfinal = c1;

            if (haveSlice(r0, c0, r1, c1))
            {
                var slice = new Slice();

                slice.c1 = c0;
                slice.r1 = r0;
                slice.c2 = c1;
                slice.r2 = r1;

                slices.Add(slice);

                //saveDistributedSolution(slice);
            }
            else
            {
                cut(r0, c0, rfinal + 1, cfinal);
                cut(r0, c0, rfinal, cfinal + 1);
                cut(r0 + 1, c0, rfinal + 1, cfinal);
                cut(r0, c0 + 1, rfinal, cfinal + 1);
            }
        }

    }
}
