using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApp1.EDefinition;

namespace ConsoleApp1
{
    public class EDefinitionFile : IExceptionDefinition
    {

        private static List<string> _eList;

        public bool DExceptions(Exception e)
        {
            return _eList != null && _eList.Contains(e.GetType().ToString());
        }

        public EDefinitionFile()
        {
            _eList = new List<string>();

            using var reader = new StreamReader(@"D:\KPI\КПІ-3\Lab01\ConsoleApp1\ConsoleApp1\config.txt");

            string line;
            while ((line = reader.ReadLine()) != null) _eList.Add(line);
        }
    }
}