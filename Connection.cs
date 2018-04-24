using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Asignment
{
    class Connection
    {
         
        public Connection(Customer customer, Device device)
        {
            if (SystemDB.Customers.Contains(customer))
                {                    
                    foreach (DeviceInventory phoneDB in SystemDB.Phones)
                    {
                        if (phoneDB.Device == device)
                        {
                            if (customer.ApplyCharge(phoneDB.Price))
                            {
                                _Customer = customer;
                                _Device = device;
                                _DeviceNumber = Utility.AllocatePhoneNumber();
                                SystemDB.Register(this);
                                Customer.Register(this);
                            }
                        }
                    }

                }
            } //end construct            
        private Customer _Customer = null;
        public Customer Customer
        {
            get { return _Customer; }
        }
        private Device _Device = null;
        public Device Device
        {
            get { return _Device; }
        }
        private string _DeviceNumber = "INVALID";
        public string DeviceNumber
        {
            get { return _DeviceNumber; }
        }
        public override string ToString()
        {
            return string.Format("{0},{1}", DeviceNumber, Device);
        }
    }
}
