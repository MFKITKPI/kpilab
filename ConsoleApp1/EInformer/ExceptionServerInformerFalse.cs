using System;

namespace ConsoleApp1.EInformer
{
    public class ExceptionServerInformerFalse : IExceptionInformer
    {
        private ushort _sendErrorCounter;

        public ushort GetErrors()
        {
            return _sendErrorCounter;
        }

        public bool Inform(Exception exception)
        {
            _sendErrorCounter++;
            return false;
        }
    }
}