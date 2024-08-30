namespace RestaurantAPI.Helpers
{
    public class APIResponse
    {
        public int StatusCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public int pageNumber { get; set; }
    }

}
