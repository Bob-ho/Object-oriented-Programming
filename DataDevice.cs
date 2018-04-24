using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Asignment
{
    class DataDevice:Device
    {
        public DataDevice(string brand,string model):base(brand,model)
        {
        }
        public override string ToString()
        {
            return string.Format("{0} {1} (Data Only)", Brand, Model);
        }
    }
}
