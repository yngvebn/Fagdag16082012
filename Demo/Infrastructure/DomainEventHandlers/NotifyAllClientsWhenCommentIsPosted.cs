using Demo.Infrastructure.DomainEvents;
using Demo.Infrastructure.Hubs;
using DomainEventExtensions;
using SignalR;

namespace Demo.Infrastructure.DomainEventHandlers
{
    public class NotifyAllClientsWhenCommentIsPosted: IDomainEventHandler<CommentWasPosted>
    {
        public void Handle(CommentWasPosted domainEvent)
        {
            dynamic hubContext = GlobalHost.ConnectionManager.GetHubContext<CommentHub>().Clients;
            hubContext.newCommentAdded(domainEvent.Comment);
        }
    }
}