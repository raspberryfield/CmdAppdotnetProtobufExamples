using System;
using Google.Protobuf.Examples.Person;
using Google.Protobuf;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CreateFile();

            //Read from file.
            Person female;
            using (var input = File.OpenRead("lena.dat"))
            {
                female = Person.Parser.ParseFrom(input);
            }

            Console.WriteLine("Name: " + female.Name);
            Console.WriteLine("Age: " + female.Age);


            Console.ReadLine();
        }

        static void CreateFile()
        {
            Person lena = new Person { Name = "Lena", Age = 32 };
            try
            {
                using (var output = File.Create("lena.dat"))
                {
                    lena.WriteTo(output);
                }
                Console.WriteLine("File created!");
            }
            catch
            {
                Console.WriteLine("Something went wrong with file creation.");
            }
            //"C:\\repos\\CmdAppdotnetProtobufExamples\\ProtobufExamples\\ConsoleApp1\\bin\\Debug\\netcoreapp3.1\\john.dat"
        }
    }
}
