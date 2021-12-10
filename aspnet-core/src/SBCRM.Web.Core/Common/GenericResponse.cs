namespace SBCRM.Web.Common
{
    public class GenericResponse<T>
    {
        public GenericError Error { get; set; }
        public T Result { get; set; }
        public bool Success { get; set; }
        public string TargetUrl { get; set; }
    }

    public class GenericError
    {
        public int Code { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public string ValidationErrors { get; set; }
    }
}
