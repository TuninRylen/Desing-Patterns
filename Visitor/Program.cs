using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager ugurcan = new Manager { Name = "Ugur", Salary = 1000 };
            Manager aysenur = new Manager { Name = "Aysenur", Salary = 1200 };

            Worker worker1 = new Worker { Name = "slave1", Salary = 100};
            Worker worker2 = new Worker { Name = "slave2", Salary = 100 };
            Worker worker3 = new Worker { Name = "slave3", Salary = 100 };

            ugurcan.Subordinates.Add(aysenur);
            aysenur.Subordinates.Add(worker1);
            aysenur.Subordinates.Add(worker2);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(ugurcan);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayriseVisitor payriseVisitor = new PayriseVisitor();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payriseVisitor);

            Console.ReadLine();
        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firsEmployee)
        {
            Employee = firsEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }

        public List<EmployeeBase> Subordinates { get; set; }

        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);

    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine($"{worker.Name} paid {worker.Salary}");
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine($"{manager.Name} paid {manager.Salary}");
        }
    }

    class PayriseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine($"{worker.Name} salary increased to {worker.Salary * (decimal)1.1}");
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine($"{manager.Name} salary increased to {manager.Salary * (decimal)1.1}");
        }
    }
}
