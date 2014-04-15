using Newtonsoft.Json;

namespace Qas.EmailValidation.Models
{
    /// <summary>
    /// Simple definition of the service input
    /// </summary>
    public class EmailValidationInputModel
    {
        [JsonProperty("email")]
        public string EmailAddress { get; set; }
    }
}
