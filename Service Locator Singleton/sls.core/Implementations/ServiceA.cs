using sls.core.Interfaces;

namespace sls.core.Implementations
{
    [Inject(type: typeof(IServiceA), singleton: true)]
    public class ServiceA : IServiceA
    {
        public string Message { get; set; }
    }
}
