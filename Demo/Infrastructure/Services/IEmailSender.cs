using System.Collections.Generic;

namespace Demo.Infrastructure.Services
{
    public interface IEmailSender
    {
        void SendMail(IEnumerable<string> emails);
    }

    public class EmailSender : IEmailSender
    {
        public void SendMail(IEnumerable<string> emails)
        {
            // do something
        }
    }
}