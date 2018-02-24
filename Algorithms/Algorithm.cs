using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleHashCode.Algorithms
{
    public interface Algorithm
    {
        void cut(int r0, int c0, int r1, int c1);
        Slice[] getResult();
    }
}
