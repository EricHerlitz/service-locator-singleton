using System;
using sls.core.Interfaces;

namespace sls.core.Implementations
{
    public class ClassA
    {
        private readonly IServiceA _serviceA;
        private readonly IServiceB _serviceB;

        public ClassA(IServiceA a, IServiceB b)
        {
            _serviceA = a;
            _serviceB = b;
        }

        public void Check()
        {
            Console.WriteLine($"Message: {_serviceA.Message}");
            Console.WriteLine($"Number: {_serviceB.Number}");
        }
    }
}
