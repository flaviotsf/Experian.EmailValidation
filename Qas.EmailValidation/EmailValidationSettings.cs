using System;
using System.Configuration;
namespace Qas.EmailValidation
{
    /// <summary>
    /// This class returns the parameters needed to initialize QAS Email Validation. Make sure you add those two keys to your AppSettings.
    /// </summary>
    public static class EmailValidaitonSettings
    {


        private const string EmailValidationEndpointKey = "Qas.EmailValidation.Endpoint";

        private const string AuthTokenKey = "Qas.EmailValidation.AuthToken";

        private const string RetryDelayKey = "Qas.EmailValidation.Retry.Delay";

        private const string RetryCountKey = "Qas.EmailValidation.Retry.Count";

        public static string EmailValidationEndpoint
        {
            get { return ConfigurationManager.AppSettings[EmailValidationEndpointKey]; }
        }

        public static string AuthToken
        {
            get { return ConfigurationManager.AppSettings[AuthTokenKey]; }
        }

        public static int RetryDelayMiliseconds
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[RetryDelayKey]))
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings[RetryDelayKey]);
                }

                return 5000;

            }
        }

        public static int RetryCount
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[RetryCountKey]))
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings[RetryCountKey]);
                }

                return 5;
            }
        }

    }
}
