using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Asignment
{
    class SmartPhone:Device
    {
        public SmartPhone(string brand, string model):base(brand,model)
        {
        }
        public override string ToString()
        {
            return string.Format("{0} {1} (Smart Phone)", Brand, Model);
        }
    }
}
