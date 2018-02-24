using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleHashCode.Algorithms
{
    public class Unificator
    {


        List<List<Slice>> distributedSolution;
        public List<Slice> finalSolution { get; set; }
        //Dictionary<int, List<Slice>> theSumOfSlices;
        int r, c;

        public Unificator(int r,int c)
        {
            this.r = r;
            this.c = c;

            //theSumOfSlices = new Dictionary<int, List<Slice>>();
            distributedSolution = new List<List<Slice>>();
        }

        public Slice[] getSolution()
        {
            if (finalSolution == null) return null;
            return finalSolution.ToArray();
        }


        public void saveDistributedSolution(Slice _slice)
        {
            bool doesTouch = false;

            List<List<Slice>> distributedSolutionTemp = new List<List<Slice>>();
            distributedSolutionTemp.AddRange(distributedSolution);

            foreach (List<Slice> TheSlices in distributedSolutionTemp)
            {
                List<Slice> tempSlices = new List<Slice>();

                foreach (Slice slice in TheSlices)
                {
                    if (slice.touch(_slice))
                    {
                        doesTouch = true;
                        break;
                    }
                    else
                    {
                        tempSlices.Add(slice);
                        doesTouch = false;
                    }
                }

                if (!doesTouch)
                {
                    tempSlices.Add(_slice);
                    //distributedSolutionTemp.Add(tempSlices);
                    distributedSolution.Add(tempSlices);

                    int totalSum = tempSlices.Sum(x => x.getCels());


                    int totalMatix = this.r * this.c;

                    if (totalSum== totalMatix)
                    {
                        finalSolution = tempSlices;
                        return;
                    }

                    //theSumOfSlices[totalSum] = tempSlices;

                    //if (haveSolution())
                    //{
                    //    return;
                    //}
                }
            }

            //distributedSolution.AddRange(distributedSolutionTemp);

            var list = new List<Slice>();
            list.Add(_slice);
            distributedSolution.Add(list);
        }

       /* public bool haveSolution()
        {
            int totalMatix = this.r * this.c;
            bool haveSolution = theSumOfSlices.ContainsKey(totalMatix);

            if (haveSolution)
            {
                finalSolution = theSumOfSlices[totalMatix];
                return true;
            }

            return false;
        }*/

    }
}
