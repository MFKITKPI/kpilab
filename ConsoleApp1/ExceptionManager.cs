using System;
using ConsoleApp1.EDefinition;
using ConsoleApp1.EInformer;

namespace ConsoleApp1
{
    public class ExceptionManager
    {
        public int Fatal { get; private set; }
        public int NotFatal { get; private set; }

        private IExceptionDefinition _exceptionDefinition;
        private IExceptionInformer _criticalExceptionInformer = new ExceptionServerInformer();

        public ExceptionManager(IExceptionDefinition exceptionDefinition)
        {
            _exceptionDefinition = exceptionDefinition;
        }

        public void SetDefinition(IExceptionDefinition exceptionDefinition)
        {
            _exceptionDefinition = exceptionDefinition;
        }

        public void SetInformer(IExceptionInformer exceptionInformer)
        {
            _criticalExceptionInformer = exceptionInformer;
        }

        public void Handle(Exception exception)
        {
            if (IsFatal(exception))
            {
                Fatal++;
            }
            else NotFatal++;

            _criticalExceptionInformer.Inform(exception);
        }

        public void ShowErrors()
        {
            Console.WriteLine("Fatal Errors: {0}\nNot Fatal Errors: {1}", Fatal, NotFatal);
            Console.WriteLine("Server Errors: {0}", _criticalExceptionInformer.GetErrors());
        }

        public bool IsFatal(Exception e)
        {
            return _exceptionDefinition.DExceptions(e);
        }
    }
}