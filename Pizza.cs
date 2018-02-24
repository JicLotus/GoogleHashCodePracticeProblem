using GoogleHashCode.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleHashCode
{
    public class Pizza
    {
        int[][] matrix;
        Algorithm algoritmo;
        Unificator unificator;

        public Pizza(int R,int C,int L,int H)
        {
            matrix = new int[R][];
            for(int i= 0; i<R;i++)
            {
                matrix[i] = new int[C];
            }
            algoritmo = new TheNewOne(R,C,H,L,matrix);
            unificator = new Unificator(R, C);
        }

        public void add(int r,int c, string value)
        {
            var binValue = value == "T" ? 0 : 1;
            matrix[r][c] = binValue;
        }
        
        
        public Slice[] cut()
        {
            algoritmo.cut(0, 0, 0, 0);

            
            int count = 0;
            var slices = algoritmo.getResult();


            
            /*foreach (Slice slice in slices)
            {
                unificator.saveDistributedSolution(slice);
                unificator.haveSolution();
                count++;
            }
            unificator.haveSolution();

            return unificator.getSolution();*/
            return slices;
        }

    }
}
