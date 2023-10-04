using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee Ali = new Employee { Name = "Ali"};

            Employee Kerim = new Employee { Name = "Kerim" };

            Ali.AddSubordinate(Kerim);

            Employee Kerem = new Employee { Name = "Kerem" };

            Ali.AddSubordinate(Kerem);

            Contractor Kazım = new Contractor { Name = "kazım" };
            Kerem.AddSubordinate(Kazım);

            Employee Cafer = new Employee { Name = "Cafer" };

            Kerim.AddSubordinate(Cafer);

            Console.WriteLine("{0}",Ali.Name);
            foreach (Employee manager in Ali)
            {
                Console.WriteLine("  {0}",manager.Name);

                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}",employee.Name);
                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { set;  get; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name {  set; get; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
