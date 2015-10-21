using sls.core.Interfaces;

namespace sls.core.Implementations
{
    [Inject(type: typeof(IServiceB), singleton: true)]
    public class ServiceB : IServiceB
    {
        public int Number { get; set; }
    }
}
