using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Infrastructure.DomainEvents;
using Demo.Models;
using DomainEventExtensions;

namespace Demo.Controllers
{
    public class TestController : Controller
    {
        private readonly IDomainEvents _domainEvents;
        //
        // GET: /Api/

        public TestController(IDomainEvents domainEvents)
        {
            _domainEvents = domainEvents;
        }

        [HttpPost]
        public void PostComment(string text)
        {
            _domainEvents.Raise<CommentWasPosted>(msg =>
                {
                    msg.Comment = new CommentViewModel() {Text = text};
                });
        }

    }
}
