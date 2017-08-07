using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_ClassesObjectsFields_Cars
{
    class Car
    {
        public string make;
        public string model;
        public int wheels;
        public int price;     
        public bool sold;
        

        public static int numberOfCars;

    public Car(string make, string model, int wheels, int price)
    {
        this.make = make;
        this.model = model;
        this.wheels = wheels;
        this.price = price; 
        this.sold = false;
        
        Car.numberOfCars++;
    }


    public static void DisplayAllCars(List<Car>carsList)
    {

            int totalValueSold = 0;
            int totalValueInStock = 0;

            foreach (Car c in carsList)
            {
                Console.WriteLine("The details of this car are: ");
                Console.WriteLine("Make and model: {0} {1}, wheels: {2}, price: £{3:N0}.", c.make, c.model, c.wheels, c.price);
                if (c.sold)
                {
                    Console.WriteLine("This car has been sold.");
                    totalValueSold += c.price;
                }
                else
                {
                    Console.WriteLine("This car is available.");
                    totalValueInStock += c.price;
                }
                Console.WriteLine();
            }
            Console.WriteLine("The total value of cars sold is: £{0:N0}.", totalValueSold);
            Console.WriteLine("The total value of cars in stock is: £{0:N0}.", totalValueInStock);
            
        }

    public void Sold(int price)
    {
         this.sold = true;
         this.price = price;
            Car.numberOfCars--;
            Console.WriteLine("The {0} has been sold for £{1:N0}.", make, price);
            
    }

    }


    class Program
    {
        static void Main(string[] args)
        {
            
            Car.numberOfCars = 0;

            //my cars

            Car car1 = new Car("Ford", "Focus", 4, 20000);
    
            Car car2 = new Car("Reliant", "Robin", 3, 1000);
 
            Car car3 = new Car("BMW", "i8", 4, 105000);
            

            // list

            List<Car> carsList = new List<Car>();
            carsList.Add(car1);
            carsList.Add(car2);
            carsList.Add(car3);

            // display

            Console.WriteLine("Total number of cars is: {0}", Car.numberOfCars);
            Console.WriteLine();


            Car.DisplayAllCars(carsList);
            

            car3.Sold(90000);

            Console.WriteLine();

            //total price

            Console.WriteLine("Total number of cars is: {0}", Car.numberOfCars);
            Console.WriteLine();

            Car.DisplayAllCars(carsList);

        }
    }
}
