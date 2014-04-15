using Newtonsoft.Json;

namespace Qas.EmailValidation.Models
{
    public class EmailValidationInputModel
    {
        [JsonProperty("email")]
        public string EmailAddress { get; set; }
    }
}
