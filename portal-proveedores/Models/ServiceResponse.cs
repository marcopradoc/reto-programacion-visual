namespace portal_proveedores.Models
{
    public class ServiceResponse<T>
    {
        public T Result { get; set; }
        public bool HasError { get; set; }
        public string Message { get; set; }

        public ServiceResponse()
        {
            HasError = false;
        }
    }
}
