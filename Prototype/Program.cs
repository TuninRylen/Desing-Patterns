﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1= new Customer { FirstName = "Ugur", LastName = "Celik", City = "Sakarya", ID = 1};

            Customer customer2 = (Customer)customer1.Clone();

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer1.FirstName);

            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class Customer : Person
    {
        public string City { get; set; }    

        public override Person Clone()
        {
            return (Person) MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
