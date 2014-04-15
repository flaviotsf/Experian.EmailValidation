using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Qas.EmailValidation.Enums;

namespace Qas.EmailValidation.Models
{
    public class EmailValidationOutputModel
    {
        /// <summary>
        ///     The email address  to validate (from API)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Certainty is converted from a string back to an enumeration. Refer to QAS documentation for different statuses
        ///     (from API)
        /// </summary>
        [JsonConverter(typeof (StringEnumConverter))]
        public Certainty Certainty { get; set; }

        /// <summary>
        ///     The return message (from API)
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     A list of possible corrections (from API)
        /// </summary>
        public List<string> Corrections { get; set; }

        /// <summary>
        ///     Returns true if QAS was able to process the validation given any errors and retry counts.
        /// </summary>
        [JsonIgnore]
        public bool Success { get; set; }


        /// <summary>
        ///     Returns true or false if the email is a valid email.
        /// </summary>
        [JsonIgnore]
        public bool IsValidEmail
        {
            get { return Certainty == Certainty.Unknown || Certainty == Certainty.Verified; }
        }
    }
}