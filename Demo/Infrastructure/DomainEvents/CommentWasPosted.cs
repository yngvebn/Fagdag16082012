using Demo.Models;
using DomainEventExtensions;

namespace Demo.Infrastructure.DomainEvents
{
    public class CommentWasPosted: IDomainEvent
    {
        public CommentViewModel Comment { get; set; }
    }
}