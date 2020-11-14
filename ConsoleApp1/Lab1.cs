using System;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace ConsoleApp1
{
    public class Lab1
    {
        static void Main(string[] args)
        {
            ExeptionManager.Handle(new ArgumentOutOfRangeException());
            ExeptionManager.showErrors();
            Functions f = new Functions();
    
        }
    }
    public class Functions
    {
        public int Div(int a, int b)
        {
            return a / b;
        }
        public void readFile(string path)
        {
            File.ReadAllText(path);
        }
        public int Mass(int i, int j)
        {
            int[] mass = new int[i];
            for (int k = 0; k < mass.Length; k++)
            {
                mass[k] = 2;
            }
            return mass[j];
        }
    }
    public class ExeptionManager
    {
        public static int fatal { get; private set; } = 0;
        public static int notFatal { get; private set; } = 0;


        public static void Handle(Exception exception)
        {
            if (isFatal(exception))
            {
                fatal++;
            }
            if (isNotFatal(exception))
            {
                notFatal++;
            }
        }
        public static void showErrors()
        {
            Console.WriteLine("Fatal Errors: {0}\nNot Fatal Errors: {1}", fatal, notFatal);
        }

        public static bool isFatal(Exception e)
        {
            if (e.GetType() == typeof(ArgumentOutOfRangeException) ||
                e.GetType() == typeof(FileNotFoundException))
            { 
                return true; 
            }
            else return false;
        }

        public static bool isNotFatal(Exception e)
        {
            if (e.GetType() == typeof(DivideByZeroException))
            {
                return true;
            }
            else return false;
        }
    }
}
