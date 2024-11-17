using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstWeekTask
{
    class CarsStore
    {
        private string ownerName;
        private string location;
        private string storeName;
        private int quantity = 0;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string StoreName
        {
            get { return storeName; }
            set { storeName = value; }

        }
        public string OwnerName
        {
            get { return ownerName; }
            set { ownerName = value; }

        }
        public string Location
        {
            get { return location; }
            set { location = value; }

        }

        public CarsStore(string store, string location, string owner)
        {
            StoreName = store;
            OwnerName = owner;
            Location = location;

        }

        public void addToStore(int num)
        {
            Quantity= Quantity+num;
        }
        public void viewStore(CarsStore store)
        {
            Console.WriteLine($"Store Name: {StoreName}\n Owner: {OwnerName}\n Location: {Location}\n Cars Quantity: {Quantity}");
        }
    }
    class Car
    {
        private string carName;
        private double carPrice;

        public string CarName
        {
            get { return carName; }
            set { carName = value; }
        }
        public double CarPrice
        {
            get { return carPrice; }
            set { carPrice = value; }
        }

        public Car(string name, double price)
        {
            carName = name;
            carPrice = price;
        }
        public void displayCar()
        {
            Console.WriteLine($"Car Name is {CarName}");
            Console.WriteLine($"Car Price is {CarPrice}");

        }
    }

    class CarOnSale : Car
    {
        private double disscount;
        private double finalPrice;
        public double Disscount
        {
            get { return disscount; }
            set { disscount = value; }
        }
        public double FinalPrice
        {
            get { return finalPrice; }
            set { finalPrice = value; } 
        }
        public CarOnSale(string name, double price, double sale) : base(name, price)
        {
            disscount = sale;
        }

        public void View()
        {
            Disscount = Disscount/100;
            FinalPrice = CarPrice * (Disscount);
            Console.WriteLine($"The Disscount is : {Disscount} \n The Final Price for the Car: {FinalPrice}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CarsStore> stores = new List<CarsStore>();
            List<Car> cars = new List<Car>();
            int ch = 0;
            while (true)
            {
                Console.WriteLine("Main Menu ");
                Console.WriteLine("1.Add New Store ");
                Console.WriteLine("2.Add Cars to a Store");
                Console.WriteLine("3. View Stores");
                Console.WriteLine("4. Add New Car");
                Console.WriteLine("5. View Car");
                Console.WriteLine("6. Get The Sale!");
                Console.WriteLine("7. Excersise 2");
                Console.WriteLine("8. Exit");
                Console.WriteLine("Please Enter your choice");
                ch = Convert.ToInt32(Console.ReadLine());
                switch(ch)
                {
                    case 1:
                        {
                            string stName, stLocation, stOwner;
                            Console.WriteLine("Please Enter Store Information:");
                            Console.WriteLine("Store Name: ");
                            stName = Console.ReadLine();
                            Console.WriteLine("Owner: ");
                            stOwner = Console.ReadLine();
                            Console.WriteLine("Location: ");
                            stLocation = Console.ReadLine();

                            CarsStore store = new CarsStore(stName.ToLower(),stLocation, stOwner);
                            stores.Add(store);
                            break;
                        }
                    case 2:
                        {
                            int num = 0;
                            string stName;
                            
                            Console.WriteLine("Enter The Name of the store:");
                            stName= Console.ReadLine();
                            Console.WriteLine("Enter The Number of Cars To Add to the store:");
                            num= Convert.ToInt32(Console.ReadLine());
                            foreach (CarsStore st in stores)
                            {
                                if(st.StoreName==stName.ToLower())
                                {
                                    st.addToStore(num);
                                }
                                else continue;
                            }

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Stores:");
                            foreach (CarsStore store in stores)
                            {
                                Console.WriteLine($"Store Name: {store.StoreName} ");
                                Console.WriteLine($"Owner: {store.OwnerName} ");
                                Console.WriteLine($"Location: {store.Location} ");
                                Console.WriteLine($"Cars in Store: {store.Quantity} ");
                                Console.WriteLine("_______________________________________");
                            }
                            break;
                        }
                    case 4:
                        {
                            string carName;
                            double price = 0;
                            Console.WriteLine("Enter Car information:");
                            Console.WriteLine("Car Name");
                            carName = Console.ReadLine().ToLower();
                            Console.WriteLine("Car Price");
                            price = Convert.ToDouble(Console.ReadLine());
                            Car car = new  Car(carName, price);
                            cars.Add(car);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Cars: ");
                            foreach (Car car in cars)
                            {
                                car.displayCar();
                                Console.WriteLine("_____________");
                            }
                            break;
                        }
                    case 6:
                        {
                            double disscount = 0;
                            string carName;
                            Console.WriteLine("Enter The Car Name");
                            carName = Console.ReadLine().ToLower();
                            Console.WriteLine("Enter The Disscount (as a Number : 50 , 80, 3)");    
                            disscount=Convert.ToDouble(Console.ReadLine());
                            
                            foreach (Car car in cars)
                            {
                                if(car.CarName.ToLower()== carName)
                                {
                                    CarOnSale carS = new CarOnSale(car.CarName, car.CarPrice, disscount);
                                    carS.View();
                                    Console.WriteLine("__________________");
                                }
                                else continue;
                            }

                            break;
                        }
                    case 7:
                        {
                            double num1 = 0, num2 = 0;
                            double? result = 0; ;
                            char symbol = ' ';
                           

                            Console.WriteLine("Enter The opperation Symbol:( * , / , + , - , ^ for Power, # for square root) ");
                            symbol=Convert.ToChar(Console.ReadLine());

                            

                            switch (symbol)
                            {
                                case '*':
                                    Console.WriteLine("Enter 2 Numbers");
                                    Console.WriteLine("Number 1:");
                                    num1 = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Number 2:");
                                    num2 = Convert.ToDouble(Console.ReadLine());
                                    result = num1 * num2;
                                    Console.WriteLine($"{num1} × {num2} = {result}");
                                    break;
                                case '/':
                                    Console.WriteLine("Enter 2 Numbers");
                                    Console.WriteLine("Number 1:");
                                    num1 = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Number 2:");
                                    num2 = Convert.ToDouble(Console.ReadLine());
                                    result = num1 / num2;
                                    Console.WriteLine($"{num1} / {num2} = {result}");
                                    break;
                                case '+':
                                    Console.WriteLine("Enter 2 Numbers");
                                    Console.WriteLine("Number 1:");
                                    num1 = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Number 2:");
                                    num2 = Convert.ToDouble(Console.ReadLine());
                                    result = num1 + num2;
                                    Console.WriteLine($"{num1} + {num2} = {result}");
                                    break;
                                case '-':
                                    Console.WriteLine("Enter 2 Numbers");
                                    Console.WriteLine("Number 2:");
                                    num1 = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Number 2:");
                                    num2 = Convert.ToDouble(Console.ReadLine());
                                    result = num1 - num2;
                                    Console.WriteLine($"{num1} - {num2} = {result}");
                                    break;
                                case '^':
                                    Console.WriteLine("Enter 2 Numbers");
                                    Console.WriteLine("Number 1:");
                                    num1 = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Number 2:");
                                    num2 = Convert.ToDouble(Console.ReadLine());
                                    result = Math.Pow(num1, num2);
                                    Console.WriteLine($"{num1} ^ {num2} = {result}");
                                    break;
                                case '#':
                                  
                                    Console.WriteLine("Enter the Number:");
                                    num1 = Convert.ToDouble(Console.ReadLine());
                                    result = Math.Sqrt(num1);
                                    Console.WriteLine($"{num1} Square Root = {result}");
                                    break;
                                default:
                                    Console.WriteLine("Not Compatable Operation");
                                    break;


                            }

                            break;
                        }
                    case 8:
                        return ;
                    default:
                        Console.WriteLine("Not a Choice!");
                        break;
                   
                }


            }



        }
    }
}
