namespace Application.Wrappers
{
    public class Response<T>
    {

        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public Dictionary<string, string[]> errors { get; set; }

        public T Data { get; set; }


        public Response()
        {
            Succeeded= false;
        }
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }


        public Response(T data, string message = null)
        {
            Succeeded= true;
            Message= message;
            Data= data;
        }

      
       
    }
}
