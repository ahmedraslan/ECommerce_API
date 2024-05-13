namespace E_Commerce.API.Errors
{

    //This class will represent the response in case of "Validation Error"
    public class ApiValidationErrorResponse : ApiResponse
    {

        public IEnumerable<string> Errors { get; set; }

        public ApiValidationErrorResponse() : base(400)
        {
            Errors = new List<string>();
        }
    }
}
