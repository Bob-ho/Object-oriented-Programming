using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Asignment
{
    class Device
    {
        protected Device(string brand, string model)
        {
            _Brand = brand;
            _Model = model;
        }
        private string _Brand;
        public string Brand
        {
            get { return _Brand; }
        }

       
        private string _Model;
        public string Model
        {
            get { return _Model; }
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", Brand, Model);
        }

        


    }
}
