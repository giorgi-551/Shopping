using System;
using System.Collections.Generic;

abstract class Product
{
    public string Name { get; }
    public double BasePrice { get; }

    protected Product(string name, double basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }

    public abstract double FinalPrice();
}

class FoodProduct : Product
{
    public FoodProduct(string name, double basePrice)
        : base(name, basePrice) { }

    public override double FinalPrice()
    {
        return BasePrice * 1.05;
    }
}

class ElectronicProduct : Product
{
    public ElectronicProduct(string name, double basePrice)
        : base(name, basePrice) { }

    public override double FinalPrice()
    {
        return BasePrice * 1.18;
    }
}

class Customer
{
    public int Id { get; }
    public string Name { get; }
    public bool Premium { get; }

    public Customer(int id, string name, bool premium)
    {
        Id = id;
        Name = name;
        Premium = premium;
    }
}

class ShoppingCart
{
    private readonly List<Product> _products = new List<Product>();
    public Customer Customer { get; }

    public ShoppingCart(Customer customer)
    {
        Customer = customer;
    }

    public void AddProduct(Product p)
    {
        _products.Add(p);
    }

    public bool RemoveProduct(string name)
    {
        var product = _products.Find(p => p.Name == name);
        if (product != null)
        {
            _products.Remove(product);
            return true;
        }
        return false;
    }

    public void CopyTo(ShoppingCart other)
    {
        foreach (var p in _products)
        {
            other.AddProduct(p);
        }
    }

    public void MoveTo(ShoppingCart other)
    {
        foreach (var p in _products)
        {
            other.AddProduct(p);
        }
        _products.Clear();
    }

    public double TotalPrice()
    {
        double total = 0;
        foreach (var p in _products)
        {
            total += p.FinalPrice();
        }

        if (Customer.Premium)
            total *= 0.90;

        return total;
    }

    public IReadOnlyList<Product> GetProducts()
    {
        return _products.AsReadOnly();
    }
}

class Program
{
    static void Main()
    {
        var apple = new FoodProduct("Apple", 1.00);
        var bread = new FoodProduct("Bread", 2.50);
        var laptop = new ElectronicProduct("Laptop", 1200);
        var headphones = new ElectronicProduct("Headphones", 150);

        var cust1 = new Customer(1, "Giorgi", false);
        var cust2 = new Customer(2, "Mariam", true); 
        var cust3 = new Customer(3, "Nika", false);

        var cart1 = new ShoppingCart(cust1);
        var cart2 = new ShoppingCart(cust2);
        var cart3 = new ShoppingCart(cust3);

        cart1.AddProduct(apple);
        cart1.AddProduct(bread);
        cart1.AddProduct(laptop);
        cart1.AddProduct(headphones);

        cart1.CopyTo(cart2);

        cart1.MoveTo(cart3);

        Console.WriteLine("Cart 1 Total: " + cart1.TotalPrice());
        Console.WriteLine("Cart 2 Total (premium discount): " + cart2.TotalPrice());
        Console.WriteLine("Cart 3 Total: " + cart3.TotalPrice());
    }
}
