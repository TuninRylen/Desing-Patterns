using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());

            productManager.GetAll();

            Console.Read();
        } 
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with log4net");
        }
    }

    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Nlogger");
        }
    }

    public abstract class Cashing
    {
        public abstract void Cashe(string data);
    }

    public class MemCache : Cashing
    {
        public override void Cashe(string data)
        {
            Console.WriteLine("Cashed with MemCache");
        }
    }
    public class RedisCache : Cashing
    {
        public override void Cashe(string data)
        {
            Console.WriteLine("Cash with RedisCache");
        }
    }

    public abstract class CrossCuttinConcernsFactory1
    {
        public abstract Logging CreateLogger();
        public abstract Cashing CreateCashing();

    }

    public class Factory1 : CrossCuttinConcernsFactory1
    {
        public override Cashing CreateCashing()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class Factory2 : CrossCuttinConcernsFactory1
    {
        public override Cashing CreateCashing()
        {
            return new MemCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }

    public class ProductManager
    {

        CrossCuttinConcernsFactory1 _crossCuttinConcernsFactory;

        private Logging _logging;
        private Cashing _cashing;

        public ProductManager(CrossCuttinConcernsFactory1 crossCuttinConcernsFactory)
        {
            _crossCuttinConcernsFactory = crossCuttinConcernsFactory;
            _logging = _crossCuttinConcernsFactory.CreateLogger();
            _cashing = _crossCuttinConcernsFactory.CreateCashing();
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _cashing.Cashe("Data");
            Console.WriteLine("Product listed");
        }
    }
}
