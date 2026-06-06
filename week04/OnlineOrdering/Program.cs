using System;
using System.Collections.Generic;

namespace ProductOrders
{
    // ==========================================
    // 1. ADDRESS CLASS
    // ==========================================
    public class Address
    {
        private string _streetAddress;
        private string _city;
        private string _stateProvince;
        private string _country;

        public Address(string streetAddress, string city, string stateProvince, string country)
        {
            _streetAddress = streetAddress;
            _city = city;
            _stateProvince = stateProvince;
            _country = country;
        }

        // Returns true if the country is USA (case-insensitive checks)
        public bool IsInUSA()
        {
            string countryUpper = _country.Trim().ToUpper();
            return countryUpper == "USA" || countryUpper == "UNITED STATES" || countryUpper == "UNITED STATES OF AMERICA";
        }

        // Returns all fields properly aligned with newline characters
        public string GetFullAddressString()
        {
            return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
        }

        // Getters and Setters
        public string StreetAddress { get => _streetAddress; set => _streetAddress = value; }
        public string City { get => _city; set => _city = value; }
        public string StateProvince { get => _stateProvince; set => _stateProvince = value; }
        public string Country { get => _country; set => _country = value; }
    }

    // ==========================================
    // 2. CUSTOMER CLASS
    // ==========================================
    public class Customer
    {
        private string _name;
        private Address _address; // Composition relationship

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        // Delegates responsibility to the internal Address object
        public bool LivesInUSA()
        {
            return _address.IsInUSA();
        }

        // Getters and Setters
        public string Name { get => _name; set => _name = value; }
        public Address CustomerAddress { get => _address; set => _address = value; }
    }

    // ==========================================
    // 3. PRODUCT CLASS
    // ==========================================
    public class Product
    {
        private string _name;
        private string _productId;
        private double _price;
        private int _quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        // Calculates unit price multiplied by quantity
        public double CalculateTotalCost()
        {
            return _price * _quantity;
        }

        // Getters and Setters
        public string Name { get => _name; set => _name = value; }
        public string ProductId { get => _productId; set => _productId = value; }
        public double Price { get => _price; set => _price = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
    }

    // ==========================================
    // 4. ORDER CLASS
    // ==========================================
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // Sums product totals and adds a flat shipping rate based on destination location
        public double CalculateOrderTotal()
        {
            double totalProductCost = 0;
            foreach (Product product in _products)
            {
                totalProductCost += product.CalculateTotalCost();
            }

            double shippingCost = _customer.LivesInUSA() ? 5.00 : 35.00;
            return totalProductCost + shippingCost;
        }

        // Formats a list displaying Name and ID of every packed item
        public string GetPackingLabel()
        {
            string label = "--- PACKING LABEL ---\n";
            foreach (Product product in _products)
            {
                label += $"Product: {product.Name} (ID: {product.ProductId})\n";
            }
            return label;
        }

        // Formats the delivery recipient's name and multi-line physical location
        public string GetShippingLabel()
        {
            string label = "--- SHIPPING LABEL ---\n";
            label += $"Recipient: {_customer.Name}\n";
            label += _customer.CustomerAddress.GetFullAddressString() + "\n";
            return label;
        }
    }

    // ==========================================
    // 5. MAIN PROGRAM EXECUTION
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            // ---------------------------------------------------
            // ORDER 1: Domestic Customer (USA)
            // ---------------------------------------------------
            Address address1 = new Address("1600 Amphitheatre Pkwy", "Mountain View", "CA", "USA");
            Customer customer1 = new Customer("Jane Doe", address1);
            Order order1 = new Order(customer1);

            // Adding 3 items to Order 1
            order1.AddProduct(new Product("Wireless Mouse", "M102", 25.50, 2));   // $51.00
            order1.AddProduct(new Product("Mechanical Keyboard", "K504", 89.99, 1)); // $89.99
            order1.AddProduct(new Product("USB-C Hub", "H311", 15.00, 3));         // $45.00
            // Total products: $185.99 + $5.00 Domestic Shipping = $190.99

            // ---------------------------------------------------
            // ORDER 2: International Customer (Non-USA)
            // ---------------------------------------------------
            Address address2 = new Address("Champ de Mars, 5 Avenue Anatole France", "Paris", "Île-de-France", "France");
            Customer customer2 = new Customer("Jean-Pierre", address2);
            Order order2 = new Order(customer2);

            // Adding 2 items to Order 2
            order2.AddProduct(new Product("UltraWide Monitor", "MON-34", 349.99, 1)); // $349.99
            order2.AddProduct(new Product("HDMI 2.1 Cable", "CBL-06", 12.50, 2));      // $25.00
            // Total products: $374.99 + $35.00 International Shipping = $409.99

            // ---------------------------------------------------
            // DISPLAY RESULTS
            // ---------------------------------------------------
            Console.WriteLine("==================================================");
            Console.WriteLine("                  PROCESSING ORDER 1              ");
            Console.WriteLine("==================================================");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.CalculateOrderTotal():F2}");
            Console.WriteLine();

            Console.WriteLine("==================================================");
            Console.WriteLine("                  PROCESSING ORDER 2              ");
            Console.WriteLine("==================================================");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.CalculateOrderTotal():F2}");
            Console.WriteLine("==================================================");
        }
    }
}