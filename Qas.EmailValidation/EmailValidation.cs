using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Qas.EmailValidation.Enums;
using Qas.EmailValidation.Helpers;
using Qas.EmailValidation.Models;

namespace Qas.EmailValidation
{
    public static class EmailValidation
    {
        public static EmailValidationOutputModel ValidateEmail(string email)
        {
            var jsonInput = new EmailValidationInputModel {EmailAddress = email};
            var jsonContent = JsonConvert.SerializeObject(jsonInput, Formatting.None);
            var requestContent = Encoding.UTF8.GetBytes(jsonContent);
            var authenticationRequest =
                WebRequest.Create(new Uri(EmailValidaitonSettings.EmailValidationEndpoint));
            authenticationRequest.Method = WebRequestMethods.Http.Post;
            authenticationRequest.ContentType = "application/json";
            authenticationRequest.Headers.Add("Auth-Token", EmailValidaitonSettings.AuthToken);

            using (var stream = authenticationRequest.GetRequestStream())
            {
                stream.Write(requestContent, 0, requestContent.Length);

                using (var authenticationResponse = authenticationRequest.GetResponse())
                {
                    var responseUrl = authenticationResponse.ResponseUri.ToString();
                    try
                    {
                        var myValidationResult = Retry.Do(() => GetValidationResponseString(responseUrl), TimeSpan.FromMilliseconds(EmailValidaitonSettings.RetryDelayMiliseconds), EmailValidaitonSettings.RetryCount);
                        var myEmailValidationOutput = JsonConvert.DeserializeObject<EmailValidationOutputModel>(myValidationResult);
                        myEmailValidationOutput.Success = true;
                        return myEmailValidationOutput;
                    }
                    catch (Exception ex)
                    {
                        // QAS Error On n Tries.
                        var errorOutput = new EmailValidationOutputModel
                        {
                            Email = email,
                            Certainty = Certainty.Unknown,
                            Success = false
                        };

                        return errorOutput;
                    }
                }
            }
        }

        private static string GetValidationResponseString(string validationUri)
        {
            var resultUri = new Uri(validationUri);
            var validationRequest = WebRequest.Create(resultUri);
            validationRequest.Method = WebRequestMethods.Http.Get;
            validationRequest.ContentType = "application/json";
            validationRequest.Headers.Add("Auth-Token", EmailValidaitonSettings.AuthToken);

            using (var myValidationResponse = validationRequest.GetResponse())
            {
                using (var myValidationResponseStream = myValidationResponse.GetResponseStream())
                {
                    if (myValidationResponseStream == null) return string.Empty;
                    var reader = new StreamReader(myValidationResponseStream, Encoding.UTF8);
                    var responseString = reader.ReadToEnd();
                    return responseString;
                }
            }
        }
    }
}