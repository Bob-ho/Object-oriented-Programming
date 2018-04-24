
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Project1_Asignment
{
    static class SystemDB
    {
        #region Phone Data
        private static List<DeviceInventory> _Phones = new List<DeviceInventory>();
        public static ReadOnlyCollection<DeviceInventory> Phones
        {
            get { return _Phones.AsReadOnly(); }
        }

        public static void Register(DeviceInventory phone)
        {
            bool exists = false;
            foreach (DeviceInventory pi in _Phones)
            {
                if (phone.Device == pi.Device)
                {
                    exists = true;
                    break;
                }
            }

            if (exists == false)
                _Phones.Add(phone);
        }



        #endregion
        #region Customer Data
        private static List<Customer> _Customers = new List<Customer>();
        public static ReadOnlyCollection<Customer> Customers
        {
            get { return _Customers.AsReadOnly(); }
        }

        public static void Register(Customer customer)
        {
            if (_Customers.Contains(customer) == false)
                _Customers.Add(customer);
        }
        #endregion



        #region Connection Data
        private static Dictionary<Customer, List<Connection>> _Connections = new Dictionary<Customer, List<Connection>>();
        public static ReadOnlyCollection<Connection> Connections
        {
            get
            {
                IEnumerable<Connection> result = _Connections.Values.SelectMany(list => list);
                return result.ToList<Connection>().AsReadOnly();
            }
        }

        public static void Register(Connection connection)
        {
            List<Connection> list = null;

            if (_Connections.ContainsKey(connection.Customer) == false)
                _Connections.Add(connection.Customer, list = new List<Connection>());
            else
                list = _Connections[connection.Customer];

            list.Add(connection);
        }
        #endregion

        public static void DumpConnections(TextWriter textWriter, string prefix)
        {
            foreach (Connection conn in Connections)
            {
                textWriter.WriteLine("{0}{1}", prefix == null ? "" : prefix, conn);
            }
        }

        public static void DumpCustomers(TextWriter textWriter, string prefix)
        {
            foreach (Customer cust in _Customers)
            {
                if (_Connections.ContainsKey(cust))
                {
                    textWriter.WriteLine("{0}{1}", prefix == null ? "" : prefix, cust);
                    foreach (Connection conn in _Connections[cust])
                        Console.WriteLine("{0}\t{1}", prefix == null ? "" : prefix, conn);
                }
            }
        }
    }
}
