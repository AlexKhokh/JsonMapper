using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JsonMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args.Count())
            {
                // предполагаем, что файлы по заданному пути есть, права есть и т.п. 
                case 0: { Console.WriteLine("Path to json file must be specified. No continuation of work. Press any key for exit."); Console.ReadKey(); break; }
                case 1:
                    {
                        new Executor(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppData/schemamapper.json"),
                                 new Mapper(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppData/mappers.js"))).Execute(args[0]); Console.ReadKey(); break;
                    }
                default: { Console.WriteLine("Too many args specified. No continuation of work. Press any key for exit."); Console.ReadKey(); break; }
            }           
        }      
    }
}
