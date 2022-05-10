namespace SSToolkit.Mail.Tests
{
    using System;
    using System.Net.Mail;
    using Xunit;

    public class EmailClientTests
    {
        private EmailClient emailClient;
        [Fact]
        public void EmailClient_Test()
        {
            this.emailClient = new EmailClient(null, null);
            ExceptionAssertion<ArgumentNullException>("SmtpServer cannot be null",
                () => emailClient.SendEmailAsync("from", "to", "subject", "body").Wait());

            this.emailClient = new EmailClient("SMTP", null);
            ExceptionAssertion<ArgumentException>("SmtpPort is not valid",
                () => emailClient.SendEmailAsync("from", "to", "subject", "body").Wait());

            this.emailClient = new EmailClient("SMTP", "Not valid");
            ExceptionAssertion<ArgumentException>("SmtpPort is not valid",
                () => emailClient.SendEmailAsync("from", "to", "subject", "body").Wait());

            this.emailClient = new EmailClient("SMTP", "356");
            ExceptionAssertion<ArgumentException>("From Email ['from'] is not valid",
                () => emailClient.SendEmailAsync("from", "to", "subject", "body").Wait());

            ExceptionAssertion<ArgumentException>("At least one email should be provided as receivers",
                () => emailClient.SendEmailAsync("validfrom@mail.com", null, "subject", "body").Wait());

            ExceptionAssertion<ArgumentException>("CC email ['invalid'] is not valid",
                () => emailClient.SendEmailAsync("validfrom@mail.com", "validto@mail.com", "subject", "body", cc: new [] { "invalid" }).Wait());

            this.emailClient = new EmailClient("SMTP", "356", null, null);
            ExceptionAssertion<ArgumentNullException>("SmtpUsername cannot be null",
                () => emailClient.SendEmailAsync("from", "to", "subject", "body").Wait());

            this.emailClient = new EmailClient("SMTP", "356", "username", null);
            ExceptionAssertion<ArgumentNullException>("SmtpPassword cannot be null",
                () => emailClient.SendEmailAsync("from", "to", "subject", "body").Wait());

            this.emailClient = new EmailClient("SMTP", "356", "username", "password");
            // Valid, should throw System.Net.Mail.SmtpException due to the invalid input data
            ExceptionAssertion<SmtpException>("Failure sending mail",
                () => emailClient.SendEmailAsync("validfrom@mail.com", "validto@mail.com", "subject", "body",
                allowHtml: true, cc: new[] { "validcc@mail.com" }, null).Wait());

            ExceptionAssertion<SmtpException>("Failure sending mail",
                () => emailClient.SendEmailAsync("validfrom@mail.com", "validto@mail.com", "subject", "body",
                allowHtml: true, cc: new [] { "validcc@mail.com"}, new Attachment[] { }).Wait());
        }

        private void ExceptionAssertion<T>(string errorMessage, Action delg)
            where T : Exception
        {
            var ex = Assert.Throws<AggregateException>(delg);
            Assert.NotNull(ex);
            Assert.NotNull(ex.InnerException);
            Assert.Equal(typeof(T), ex.InnerException.GetType());
            Assert.StartsWith(errorMessage, ((T)ex.InnerException).Message);
        }
    }
}