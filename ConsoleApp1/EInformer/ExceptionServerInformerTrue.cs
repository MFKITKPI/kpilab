using System;

namespace ConsoleApp1.EInformer
{
    public class ExceptionServerInformerTrue : IExceptionInformer
    {
        private ushort _sendErrorCounter;

        public bool Inform(Exception exception)
        {
            return true;
        }

        public ushort GetErrors()
        {
            return _sendErrorCounter;
        }
    }
}