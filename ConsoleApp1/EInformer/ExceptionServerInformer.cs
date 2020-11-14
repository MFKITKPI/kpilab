using System;

namespace ConsoleApp1.EInformer
{
    public class ExceptionServerInformer : IExceptionInformer
    {
        private ushort _sendErrorCounter;

        public bool Inform(Exception exception)
        {
                
            _sendErrorCounter++;

            return true;
        }

        public ushort GetErrors()
        {
            return _sendErrorCounter;
        }
    }
}