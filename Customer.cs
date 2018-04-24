using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Project1_Asignment
{
    class Customer
    {
       
        public Customer(string name,decimal balance)
        {
            _Name = name;
            _Balance = balance;
        }     

        private string _Name;       
        public string Name
        {
            get { return _Name; }
        }       

        private decimal _Balance;      
        public decimal Balance
        {
            get { return _Balance; }
        }
       
        private List<Connection> _Connections = new List<Connection>();        
        public ReadOnlyCollection <Connection> Connections
        {
            get { return _Connections.AsReadOnly(); }
        }
       
        public bool ApplyCharge(decimal amount)
        {
            bool retur = true;
            if (_Balance >= amount)
                _Balance -= amount;
            else
                retur = false;
            return retur;
        }

        public void Register(Connection connection)
        {
            
            _Connections.Add(connection);
        }
       
        public override string ToString()
        {
            return string.Format("{0}: {1:c}",Name, Balance);
        }
    }
}
