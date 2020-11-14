using System;

namespace ConsoleApp1.EInformer
{
    public interface IExceptionInformer
    {
        public ushort GetErrors();
        public bool Inform(Exception exception);
    }
}