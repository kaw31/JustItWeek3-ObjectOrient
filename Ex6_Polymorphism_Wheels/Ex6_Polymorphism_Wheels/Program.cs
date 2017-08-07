using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex6_Polymorphism_Wheels
{
    class Vehicle
    {
        public virtual void Wheels()
        {
            Console.WriteLine("Car has 4 wheels.");
        }
    }
    class Bike : Vehicle
    {
        public override void Wheels()
        {
            Console.WriteLine("Bike has 2 wheels.");
        }
    }
    class Lorry : Vehicle
    {
        public new void Wheels()
        {
            Console.WriteLine("Lorry has 18 wheels.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(new Vehicle());
            vehicles.Add(new Bike());          //bike that has been cast as a vehicle
            vehicles.Add(new Lorry());           //lorry that has been cast as a vehicle

            foreach (Vehicle p in vehicles)
            {
                p.Wheels();
            }

            Lorry lorry1 = new Lorry();
            lorry1.Wheels();
        }
    }
}
