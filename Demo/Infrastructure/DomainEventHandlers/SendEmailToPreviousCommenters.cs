using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Infrastructure.DomainEvents;
using DomainEventExtensions;

namespace Demo.Infrastructure.DomainEventHandlers
{
    public class SendEmailToPreviousCommenters: IDomainEventHandler<CommentWasPosted>
    {
        public void Handle(CommentWasPosted domainEvent)
        {
            // Send email
        }
    }
}