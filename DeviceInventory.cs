using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Asignment
{
    class DeviceInventory
    {
          public DeviceInventory(Device device,decimal price)
        {
            _Device = device;
            _Price = price;
        }
    
        private Device _Device;
        public Device Device
        {
            get { return _Device; }
        }
        private decimal _Price;
        public decimal Price
        {
            get { return _Price; }
        }
        public override string ToString()
        {
            return string.Format("{0}: {1:c}", _Device, _Price);
        }
    }
}
