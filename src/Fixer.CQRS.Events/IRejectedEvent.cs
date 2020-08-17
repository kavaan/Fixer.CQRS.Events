using System;
using System.Collections.Generic;
using System.Text;

namespace Fixer.CQRS.Events
{
    public interface IRejectedEvent : IEvent
    {
        string Reason { get; }
        string Code { get; }
    }
}
