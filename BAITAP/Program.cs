using System;
using System.Collections.Generic;
using System.Linq;

// Lớp cha
class Vehicle
{
    public string Brand { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
    public string Color { get; set; }
}

// Lớp thừa kế Car từ Vehicle
class Car : Vehicle
{
    public Car(string brand, int year, string color, double price)
    {
        Brand = brand;
        Year = year;
        Color = color;
        Price = price;
    }
}

// Lớp thừa kế Truck từ Vehicle
class Truck : Vehicle
{
    public string Company { get; set; }

    public Truck(string brand, int year, double price, string color , string company)
    {
        Brand = brand;
        Year = year;
        Price = price;
        Color = color;
        Company = company;
    }
}

class Program
{
    static List<Car> cars = new List<Car>
    {
        new Car("Lamborgini", 2005,"Red", 150000),
        new Car("Honda", 1995,"White", 120000),
        new Car("Ford", 2000,"Black", 180000),
        new Car("Chevrolet", 2020,"Blue", 220000),
        new Car("BMW", 1992,"Red", 90000),
        new Car("Mercedes-Benz", 1982,"Red and Yellow", 90000),
    };
    static List<Truck> trucks = new List<Truck>
    {
        new Truck("Volvo", 2015, 180000,"Red", "ABC Company"),
        new Truck("Ford", 2022, 250000,"Green", "XYZ Company"),
        new Truck("Chevrolet", 2018, 200000,"Black and Red", "123 Company"),
    };
    static void Main()
    {


        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Dislay cars which have the price from 100.000 to 250.000");
            Console.WriteLine("2. Dislay cars which was released the year after 1990");
            Console.WriteLine("3. Total of list of vehicles comes from certain company");
            Console.WriteLine("4. Display the truck from newly created to oldest");
            Console.WriteLine("5. Display the company's name of truck");
            Console.WriteLine("6. Add more data to car list");
            Console.WriteLine("7. Add more data to truck list");
            Console.WriteLine("8. Display all type");
            Console.WriteLine("9. Exit");

            Console.Write("What's your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayCarsPriceRange();
                    break;
                case 2:
                    DisplayCarsWithYearGreaterThan1990();
                    break;
                case 3:
                    DisplayCarsByBrand();
                    break;
                case 4:
                    DisplayTrucksOrderedByYear();
                    break;
                case 5:
                    DisplayTruckCompanies();
                    break;
                case 6:
                    AddCarData();
                    break;
                case 7:
                    AddTruckData();
                    break;
                case 8:
                    Console.WriteLine("Car:");
                    DisplayVehicleList(cars);
                    Console.WriteLine("Truck:");
                    DisplayVehicleList(trucks);
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Your choice is invalid. Please try again.");
                    break;
            }
        }
    }
    static void DisplayCarsPriceRange()
    {
        var filteredCars = cars.Where(car => car.Price >= 100000 && car.Price <= 250000);
        DisplayVehicleList(filteredCars);
    }

    // Hàm hiển thị các xe có năm sản xuất > 1990
    static void DisplayCarsWithYearGreaterThan1990()
    {
        var filteredCars = cars.Where(car => car.Year > 1990);
        DisplayVehicleList(filteredCars);
    }

    // Hàm gom các xe theo hãng sản xuất, tính tổng giá trị theo nhóm
    static void DisplayCarsByBrand()
    {
        var groupedCars = cars.GroupBy(car => car.Brand)
                             .Select(group => new { Brand = group.Key, TotalPrice = group.Sum(car => car.Price) });

        Console.WriteLine("Total of list of vehicles comes from certain company:");
        foreach (var group in groupedCars)
        {
            Console.WriteLine($"Brand: {group.Brand}, Total Price: {group.TotalPrice}");
        }
    }

    // Hàm hiển thị danh sách Truck theo thứ tự năm sản xuất mới nhất
    static void DisplayTrucksOrderedByYear()
    {
        var orderedTrucks = trucks.OrderByDescending(truck => truck.Year);
        DisplayVehicleList(orderedTrucks);
    }

    // Hàm hiển thị tên công ty chủ quản của Truck
    static void DisplayTruckCompanies()
    {
        Console.WriteLine("Display the company's name of truck:");
        foreach (var truck in trucks)
        {
            Console.WriteLine($"Truck: {truck.Brand}, Company: {truck.Company}");
        }
    }

    // Hàm thêm dữ liệu vào danh sách Car
    static void AddCarData()
    {
        Console.Write("Brand: ");
        string brand = Console.ReadLine();

        Console.Write("Date: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Color: ");
        string color = Console.ReadLine();

        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine());

        Car newCar = new Car(brand, year, color, price);
        cars.Add(newCar);
        Console.WriteLine("Added successfully.");
    }

    // Hàm thêm dữ liệu vào danh sách Truck
    static void AddTruckData()
    {
        Console.Write("Brand: ");
        string brand = Console.ReadLine();

        Console.Write("Year: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine());

        Console.Write("Color: ");
        string color = Console.ReadLine();

        Console.Write("Company's name: ");
        string company = Console.ReadLine();

        Truck newTruck = new Truck(brand, year, price, color, company);
        trucks.Add(newTruck);
        Console.WriteLine("Added successfully.");
    }

    // Hàm hiển thị danh sách các xe
    static void DisplayVehicleList(IEnumerable<Vehicle> vehicles)
    {
        Console.WriteLine("List of vehicles:");
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Brand: {vehicle.Brand}, Year: {vehicle.Year}, Price: {vehicle.Price}, Color: {vehicle.Color}");
        }
    }
}
