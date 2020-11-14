using System;

namespace ConsoleApp1.EDefinition
{
    public static class EDefinitionFactory
    {
        public static IExceptionDefinition CreateSimpleEDefinition()
        {
            return new EDefinitionFile();
        }

        public static IExceptionDefinition CreateStubEDefinitionTrue()
        {
            return new EDefinitionTrue();
        }

        public static IExceptionDefinition CreateStubEDefinitionFalse()
        {
            return new EDefinitionFalse();
        }
    }

    public class EDefinitionTrue : IExceptionDefinition
    {
        public bool DExceptions(Exception e)
        {
            return true; //all exception are fatal
        }
    }
    public class EDefinitionFalse : IExceptionDefinition
    {
        public bool DExceptions(Exception e)
        {
            return false; //all exception aren't fatal
        }
    }
}