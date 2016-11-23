namespace Cloud.Domain
{
    public class AjaxResponse<T>
    {
        public bool Success { get; set; }
        public object Result { get; set; }
    }
}