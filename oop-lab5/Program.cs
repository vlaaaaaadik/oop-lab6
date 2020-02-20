using System;
using System.Collections;

namespace oop_lab5
{

    class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public Currency Cost { get; private set; }
        public int Quantity { get; private set; }
        public string Producer { get; private set; }
        public double Weight { get; private set; }

        public Product() 
        {
            Name = "test product";
            Price = 200.00;
            Cost = new Currency();
            Quantity = 50;
            Producer = "vasya pupcin";
            Weight = 0.500;
        }

        public Product(string Name, double Price, string Curr, double Ex, int Quantity, string Producer, double Weight)
        {
            this.Name = Name;
            this.Price = Price;
            Cost = new Currency(Curr, Ex);
            this.Quantity = Quantity;
            this.Producer = Producer;
            this.Weight = Weight;
        }
        ~Product()
        {

        }

        public double GetPriceInUAH()
        {
            return Price * Cost.ExRate;
        }

        public double GetTotalPriceInUAH()
        {
            return Price * Quantity * Cost.ExRate;
        }
        public double GetTotalWeight()
        {
            return Weight * Quantity;
        }
    }

    class Currency
    {
        public string Name { get; private set; }
        public double ExRate { get; private set; }
        public Currency()
        {
            Name = "Долаар";
            ExRate = 8.30;
        }

        public Currency( string Name )
        {
            this.Name = Name;
            ExRate = 1;
        }

        public Currency(string Name, double ExRate)
        {
            this.Name = Name;
            this.ExRate = ExRate;
        }
    }

    class Program
    {
        static Product[] ReadProductsArray(int n)
        {
            ArrayList array = new ArrayList();
            string Name;
            double Price;
            string Curr;
            double Ex;
            int Quantity;
            string Producer;
            double Weight;
            for(int i = 0; i < n; i++)
            {
                Name = Console.ReadLine();
                Price = Convert.ToDouble(Console.ReadLine());
                Curr = Console.ReadLine();
                Ex = Convert.ToDouble(Console.ReadLine());
                Quantity = Convert.ToInt32(Console.ReadLine());
                Producer = Console.ReadLine();
                Weight = Convert.ToDouble(Console.ReadLine());
                array.Add(new Product(Name, Price, Curr, Ex, Quantity, Producer, Weight));
            }

            return (Product[]) array.ToArray();
        }

        static void PrintProduct(Product product)
        {
            Console.WriteLine(product.Name);
            Console.WriteLine(product.Price);
            Console.WriteLine(product.Cost.Name);
            Console.WriteLine(product.Cost.ExRate);
            Console.WriteLine(product.Quantity);
            Console.WriteLine(product.Producer);
            Console.WriteLine(product.Weight);
        }

        static void PrintProducts(Product[] products)
        {
            foreach (var p in products)
            {
                PrintProduct(p);
            }
        }

        static void GetProductsInfo(Product[] products, out Product Cheapest, out Product Priciest)
        {
            int index_min = 0;
            int index_max = 0;
            double min = products[0].Price;
            double max = products[0].Price;
            for(int i = 0; i < products.Length; i++)
            {
                if(products[i].Price < min)
                {
                    min = products[i].Price;
                    index_min = i;
                }
                if(products[i].Price > max)
                {
                    max = products[i].Price;
                    index_max = i;
                }
            }
            Cheapest = products[index_min];
            Priciest = products[index_max];
        }

        static void SortProductsByPrice(Product[] products)
        {
            for(int i = 0; i < products.Length; i++)
            {
                for(int j = 0; j < products.Length; j++)
                {
                    if (products[j].Price < products[j + 1].Price)
                    {
                        Product temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;
                    }
                }
            }
        }
        static void SortProductsByCount(Product[] products)
        {
            for(int i = 0; i < products.Length; i++)
            {
                for(int j = 0; j < products.Length; j++)
                {
                    if (products[j].Quantity < products[j + 1].Quantity)
                    {
                        Product temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}
