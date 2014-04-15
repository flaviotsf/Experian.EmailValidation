using Microsoft.VisualStudio.TestTools.UnitTesting;
using Experian.EmailValidation.Models;

namespace Experian.EmailValidation.Tests
{
    [TestClass]
    public class EmailValidationTests
    {
        [TestMethod]
        public void TestEmailValidation()
        {
            EmailValidationOutputModel output = null;

            // These are invalid emails
            output = EmailValidation.ValidateEmail("johndoe@!av.com");
            Assert.IsTrue(output.Success && !output.IsValidEmail);
            output = EmailValidation.ValidateEmail("johndoe@ggmail.com");
            Assert.IsTrue(output.Success && !output.IsValidEmail);

            output = EmailValidation.ValidateEmail("johndoe@gmail.cm");
            Assert.IsTrue(output.Success && !output.IsValidEmail);

            // These are valid emails
            output = EmailValidation.ValidateEmail("johndoe@astd.org");
            Assert.IsTrue(output.Success && output.IsValidEmail);

            output = EmailValidation.ValidateEmail("john.doe.sampleemail@gmail.com");
            Assert.IsTrue(output.Success && output.IsValidEmail);
        }
    }
}