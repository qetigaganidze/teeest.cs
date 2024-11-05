using System;
using System.Collections.Generic;

// Base class Employee (Encapsulation, Inheritance)
public class Employee
{
    // Encapsulated fields with public properties
    public string Name { get; set; }
    public int EmployeeId { get; set; }
    public decimal Salary { get; set; }

    // Constructor to initialize employee properties
    public Employee(string name, int employeeId, decimal salary)
    {
        Name = name;
        EmployeeId = employeeId;
        Salary = salary;
    }

    // Method to display basic employee information
    public virtual void DisplayEmployeeInfo()
    {
        Console.WriteLine($"Employee ID: {EmployeeId}, Name: {Name}, Salary: {Salary:C}");
    }
}

// Derived class RegularEmployee (Inheritance)
public class RegularEmployee : Employee
{
    // Constructor calls base constructor
    public RegularEmployee(string name, int employeeId, decimal salary)
        : base(name, employeeId, salary)
    { }

    // Overriding to display info (Polymorphism)
    public override void DisplayEmployeeInfo()
    {
        base.DisplayEmployeeInfo();
        Console.WriteLine("Position: Regular Employee");
    }
}

// Derived class Manager (Inheritance, Polymorphism)
public class Manager : Employee
{
    public double BonusRate { get; set; }

    // Constructor calls base constructor
    public Manager(string name, int employeeId, decimal salary, double bonusRate)
        : base(name, employeeId, salary)
    {
        BonusRate = bonusRate;
    }

    // Method to calculate total compensation (including bonus) (Encapsulation, Polymorphism)
    public decimal CalculateTotalCompensation()
    {
        return Salary + (decimal)(Salary * BonusRate / 100);
    }

    // Overriding to display info (Polymorphism)
    public override void DisplayEmployeeInfo()
    {
        base.DisplayEmployeeInfo();
        Console.WriteLine($"Position: Manager, Bonus Rate: {BonusRate}%");
    }
}

// Product class
public class Product
{
    // Encapsulated fields with public properties
    public string Name { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }

    // Constructor to initialize product properties
    public Product(string name, int productId, decimal price)
    {
        Name = name;
        ProductId = productId;
        Price = price;
    }

    // Method to display product info
    public void DisplayProductInfo()
    {
        Console.WriteLine($"Product ID: {ProductId}, Name: {Name}, Price: {Price:C}");
    }
}

// Order class (with total price calculation)
public class Order
{
    public int OrderId { get; set; }
    public List<Product> Products { get; set; }
    public Employee ProcessedBy { get; set; }

    // Constructor to initialize order properties
    public Order(int orderId, Employee processedBy)
    {
        OrderId = orderId;
        Products = new List<Product>();
        ProcessedBy = processedBy;
    }

    // Method to add product to order
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    // Property to calculate the total price of the order (Encapsulation)
    public decimal TotalPrice
    {
        get
        {
            decimal total = 0;
            foreach (var product in Products)
            {
                total += product.Price;
            }
            return total;
        }
    }

    // Method to display order summary
    public void DisplayOrderSummary()
    {
        Console.WriteLine($"Order ID: {OrderId}");
        Console.WriteLine($"Processed by: {ProcessedBy.Name} ({ProcessedBy.GetType().Name})");
        Console.WriteLine("Products in Order:");
        foreach (var product in Products)
        {
            product.DisplayProductInfo();
        }
        Console.WriteLine($"Total Price: {TotalPrice:C}\n");
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        // Create employees
        var employee1 = new RegularEmployee("Alice Johnson", 1001, 50000);
        var manager1 = new Manager("Bob Smith", 1002, 75000, 10);

        // Create products
        var product1 = new Product("Smartphone", 101, 599.99m);
        var product2 = new Product("Laptop", 102, 1299.99m);
        var product3 = new Product("Tablet", 103, 399.99m);

        // Create orders
        var order1 = new Order(5001, employee1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        var order2 = new Order(5002, manager1);
        order2.AddProduct(product3);

        // Display employee info and order summary
        Console.WriteLine("Employee Information:");
        employee1.DisplayEmployeeInfo();
        Console.WriteLine();
        manager1.DisplayEmployeeInfo();
        Console.WriteLine();

        Console.WriteLine("Order Summary:");
        order1.DisplayOrderSummary();
        order2.DisplayOrderSummary();

        // Extra Challenge: Calculate Manager's Total Compensation
        Console.WriteLine($"Manager {manager1.Name}'s Total Compensation: {manager1.CalculateTotalCompensation():C}");
    }
}
