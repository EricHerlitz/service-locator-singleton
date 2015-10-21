using System;
using sls.core;
using sls.core.Implementations;
using sls.core.Interfaces;

namespace sls.consoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = ServiceLocator.Instance.Resolve<IServiceA>();
            a.Message = "Hello";

            var b = ServiceLocator.Instance.Resolve<IServiceB>();
            b.Number = 150;

            var c = ServiceLocator.Instance.Resolve<ClassA>();
            c.Check();

            Console.Read();
        }
    }
}
