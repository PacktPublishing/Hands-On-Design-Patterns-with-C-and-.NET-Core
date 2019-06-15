using System;

namespace FlixOne.CQRS.Domain.Entity
{
    public class CommandResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public override string ToString() => $"Id:{Id}, Success:{Success}, Message:{Message}";
    }
}
