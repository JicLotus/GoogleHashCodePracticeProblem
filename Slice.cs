using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleHashCode
{
    public class Slice
    {
        public int c1 { get; set; }
        public int r1 { get; set; }
        public int c2 { get; set; }
        public int r2 { get; set; }

        public int getCels()
        {
            var countCols = (c2 - c1) + 1;
            var countRows = (r2 - r1) + 1;

            return countRows * countCols;
        }

        public bool touch(Slice slice)
        {

            /*if (this.r1 == slice.r1 && this.r2 == slice.r2  && (this.c1 > slice.c2 || this.c2 <slice.c1))
            {
                return false;
            }

            if (this.c1 == slice.c1 && this.c2 == slice.c2 && (this.r1 > slice.r2 || this.r2 < slice.r1))
            {
                return false;
            }

            if (this.c1>slice.c2 && this.r1 > slice.r2)
            {
                return false;
            }

            if (this.c2<slice.c1 && this.r1 > slice.r2)
            {
                return false;
            }

            if (this.r2<slice.r1 && this.c2<slice.c1)
            {
                return false;
            }

            if (this.c1>slice.c2 && this.r2 <slice.r1)
            {
                return false;
            }*/


            if (this.c2 < slice.c1)
            {
                return false;
            }

            if (this.r2 < slice.r1)
            {
                return false;
            }

            if (this.c1 > slice.c2)
            {
                return false;
            }

            if (this.r1 > slice.r2)
            {
                return false;
            }
            

            return true;
        }

    }
}
