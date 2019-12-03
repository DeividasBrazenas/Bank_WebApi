namespace Bank.Contracts.Response
{
    using Newtonsoft.Json;

    public class ErrorDetailsResponse
    {
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}