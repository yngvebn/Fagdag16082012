using System;
using System.Linq;
using System.Web;
using Demo.Infrastructure.DomainEvents;
using Demo.Infrastructure.Services;
using DomainEventExtensions;

namespace Demo.Infrastructure.DomainEventHandlers
{
    public class SendEmailToPreviousCommenters: IDomainEventHandler<CommentWasPosted>
    {
        private readonly IEmailSender _emailSender;

        public SendEmailToPreviousCommenters(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void Handle(CommentWasPosted domainEvent)
        {
            var emails = MvcApplication.Comments.Where(c => c.Email != domainEvent.Comment.Email).Select(c => c.Email);
            if(domainEvent.Comment.Text.Contains("Stian Sandberg"))
                return;

            _emailSender.SendMail(emails);
            // Send email
        }
    }
}