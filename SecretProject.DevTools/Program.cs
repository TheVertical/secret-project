using System;
using CommandLine;

namespace SecretProject.DevTools
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var arguments = Parser.Default.ParseArguments<UpdateOptions>(args);
        }
    }
}
