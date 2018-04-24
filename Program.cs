using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Asignment
{
    class Program
    {
        private static void LoadDefaultData()
        {
            //////////////////////////////////////////////////////////////////////
            // Create and Register Phones
            VoiceDevice ssE1205 = new VoiceDevice("Samsung", "Keystone E1205");
            VoiceDevice ssC3520 = new VoiceDevice("Samsung", "C3520 Flip");
            DataDevice aplIPadAir = new DataDevice("Apple", "iPad Air 2 128GB");
            DataDevice aplIPadMini = new DataDevice("Apple", "iPad Mini 3 128GB");
            SmartPhone aplIPhone6 = new SmartPhone("Apple", "iPhone 6 128GB");
            SmartPhone aplIPhone6Plus = new SmartPhone("Apple", "iPhone 6 Plus 128GB");
            SmartPhone ssGalaxy = new SmartPhone("Samsung", "Galaxy S6 128GB");
            SmartPhone ssGalaxyEdge = new SmartPhone("Samsung", "Galaxy S6 Edge 128GB");          

            SystemDB.Register(new DeviceInventory(ssE1205, 55.00M));
            SystemDB.Register(new DeviceInventory(ssC3520, 89.00M));
            SystemDB.Register(new DeviceInventory(aplIPadAir, 1019.00M));
            SystemDB.Register(new DeviceInventory(aplIPadMini, 899.00M));
            SystemDB.Register(new DeviceInventory(aplIPhone6, 1299.00M));
            SystemDB.Register(new DeviceInventory(aplIPhone6Plus, 1449.00M));
            SystemDB.Register(new DeviceInventory(ssGalaxy, 1299.00M));
            SystemDB.Register(new DeviceInventory(ssGalaxyEdge, 1449.00M));

            //////////////////////////////////////////////////////////////////////
            // Create and Register Customers
           Customer fred = new Customer("Freda", 4500.0M);
            Customer wilma = new Customer("Wilma", 2500.0M);
            Customer barney = new Customer("Barney", 1500.0M);
            Customer betty = new Customer("Betty", 500.0M);

            SystemDB.Register(fred);
            SystemDB.Register(wilma);          
            SystemDB.Register(barney);
            SystemDB.Register(betty);
           
            
            //////////////////////////////////////////////////////////////////////
            // Register phone connections
            new Connection(fred, ssE1205);
           new Connection(fred, aplIPadAir);
            new Connection(fred, aplIPhone6);
           new Connection(wilma, ssC3520);
            new Connection(wilma, aplIPadMini);
            new Connection(wilma, aplIPhone6Plus);
            new Connection(barney, ssE1205);
            new Connection(barney, aplIPadAir);
            new Connection(barney, ssGalaxy);
           new Connection(betty, ssC3520);
           new Connection(betty, aplIPadMini);
            new Connection(betty, ssGalaxyEdge);
        }

        static void Main(string[] args)
        {
            LoadDefaultData();

            Console.WriteLine("Customers:");
            SystemDB.DumpCustomers(Console.Out, "\t");
            Console.WriteLine();

            Console.WriteLine("Connections:");
            SystemDB.DumpConnections(Console.Out, "\t");
            Console.WriteLine();
           
        }
    }
}
