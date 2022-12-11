namespace DiApi.Utility
{
    public class Operation : IOperationSingleton, IOperationScoped, IOperationTransient
    {
        public Operation()
        {
            OperationId = Guid.NewGuid().ToString();
        }

        public string OperationId { get; }
    }
}