using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3_Inheritance_Cars
{
    class Vehicle
    {
        public string make;
        public string model;
        public int price;
        public Boolean sold;
        


        public static int numberOfVehicles;

        
        public Vehicle(string make, string model, int price)
        {
            this.make = make;
            this.model = model;
            this.price = price;
            this.sold = false;

            Vehicle.numberOfVehicles++;
        }

        //record the sale of a vehicle
        public void Sold(bool isSold, int price)
        {
            this.sold = isSold;
            this.price = price;
            //adjust the number of vehicles
            if (this is Car)
            {
                Car.numberOfCars--;
                Console.WriteLine("The " + this.make + " " + this.model + " has been sold.");
                Console.WriteLine();
            }
            if (this is Bike)
            {
                Bike.numberOfBikes--;
                Console.WriteLine("The " + this.make + " " + this.model + " has been sold.");
                Console.WriteLine();
            }
            
        }

        //list all the cars
        public static void DisplayAllVehicles(List<Vehicle> allVehicles)
        {
            int totalValueSold = 0;
            int totalValueInStock = 0;

            foreach (Vehicle item in allVehicles)
            {
                Console.WriteLine("The details of this vehicle are: ");
                Console.Write("Make and model: {0} {1}, \nPrice: £{2:N0}.", item.make, item.model, item.price);  //:N0 formats the number
                if (item.sold)
                {
                    Console.WriteLine("\nThis vehicle has been sold.");
                    totalValueSold += item.price;
                }
                else
                {
                    Console.WriteLine("\nThis vehicle is unsold.");
                    totalValueInStock += item.price;
                }
                Console.WriteLine();
            }
            Console.WriteLine("The total value of vehicles sold is: £{0:N0}.", totalValueSold);
            Console.WriteLine("The total value of vehicles still in stock is: £{0:N0}.", totalValueInStock);
            Console.WriteLine();
        }

    }

    class Car : Vehicle
        {
            public string type;
            public static int numberOfCars;

        public Car(string make, string model, int price) : base(make, model, price)
            {
                this.type = "car";

                Car.numberOfCars++;
                Car.numberOfVehicles++;
            }
        }

        class Bike : Vehicle
        {
            public string type;
            public static int numberOfBikes;

            public Bike(string make, string model, int price) : base(make, model, price)
            {
                this.type = "bike";

                Bike.numberOfBikes++;
                Bike.numberOfVehicles++;
            }
        }


    class Program
    {
        static void Main(string[] args)
        {

            List<Vehicle> allVehicles = new List<Vehicle>();

            Car.numberOfVehicles = 0;
            //add cars using the constructor
            Car car1 = new Car("RollsRoyce", "Silver Cloud", 35000);
            allVehicles.Add(car1);

            Car car2 = new Car("Aston Martin", "DB5", 750000);
            allVehicles.Add(car2);

            Car car3 = new Car("Reliant", "Robin", 550);
            allVehicles.Add(car3);


            Bike.numberOfVehicles = 0;
            //add bikes using the constructor
            Bike bike1 = new Bike("Yamaha", "Great Bike", 15000);
            allVehicles.Add(bike1);

            Bike bike2 = new Bike("Harley Davison", "Chopper", 20000);
            allVehicles.Add(bike2);

            

            //display cars data
            Console.WriteLine("Total number of cars in stock is: {0}", Car.numberOfCars);
            Console.WriteLine("Total number of bikes in stock is: {0}", Bike.numberOfBikes);
            Console.WriteLine();

            Vehicle.DisplayAllVehicles(allVehicles);

            //record the sale of a vehicle
            car3.Sold(true, 350);
            bike2.Sold(true, 18000);

            //display cars data
            Console.WriteLine("Total number of cars in stock is: {0}", Car.numberOfCars);
            Console.WriteLine("Total number of bikes in stock is: {0}", Bike.numberOfBikes);
            Console.WriteLine();

            Vehicle.DisplayAllVehicles(allVehicles);


        }
    }
}
