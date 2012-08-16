using System.Collections.Generic;
using Demo.Infrastructure.DomainEvents;
using Demo.Models;
using DomainEventExtensions;
using SignalR.Hubs;

namespace Demo.Infrastructure.Hubs
{
    public class CommentHub: Hub
    {
        private readonly IDomainEvents _domainEvents;

        public CommentHub(IDomainEvents domainEvents)
        {
            _domainEvents = domainEvents;
        }

        public List<CommentViewModel> GetComments()
        {
            return MvcApplication.Comments;
        }

        public void PostComment(CommentViewModel commentViewModel)
        {
            _domainEvents.Raise<CommentWasPosted>(msg =>
                {
                    msg.Comment = commentViewModel;
                });
        }
    }
}