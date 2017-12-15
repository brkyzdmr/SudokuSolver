using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAZLAB_2
{
    class PossibilityArray
    {
        private BitArray data = new BitArray(9);
        private int x;
        private int y;

        public PossibilityArray(BitArray data, int x, int y)
        {
            this.data = data;
            this.x = x;
            this.y = y;
        }

        public BitArray GetValue()
        {
            return data;
        }

        public void SetValue(int x, int y, int val)
        {
            this.x = x;
            this.y = y;
            this.data[val] = true;
        }       
    }
}
