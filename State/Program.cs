using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ModifiedState modifiedState = new ModifiedState();
            DeletedState deletedState = new DeletedState();
            modifiedState.DoAction(context);
            deletedState.DoAction(context); 
             
            Console.WriteLine(context.GetState());
            Console.Read();
        }
    }

    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Modified");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Modified";
        }
    }
     
    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Deleted");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Deleted";
        }
    }

    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Added");
            context.SetState(this); 
        }

        public override string ToString()
        {
            return "Added";
        }
    }
    interface IState
    {
        void DoAction(Context context);    
    }

    class Context
    {
        private IState _state;

        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }

    }
}
