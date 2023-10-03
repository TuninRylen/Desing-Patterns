using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager( new LoggerFactory2());
            customerManager.Save();

            Console.ReadLine();
        } 
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new UgLogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new AyLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }
   
    public class UgLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with UgLogger");
        }
    }
    public class AyLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with AyLogger");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            //newleme operaysonunu minimalize hale getirdik. Bağımlılıklardan arındırıldı. Bu desing patternın amacı da bu zaten.
            ILogger logger = _loggerFactory.CreateLogger(); 
            logger.Log();
        }
    }

}
