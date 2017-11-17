using System;
using  Library.Domain.Core;

namespace  Library.Service.Rental.Domain.Events
{
    public class RentBookRequestCreatedEvent : DomainEvent
    {
        public readonly static string Event_RentBookRequestCreatedEvent = "Event_RentBookRequestCreated";

        public RentBookRequestCreatedEvent() : base(Event_RentBookRequestCreatedEvent)
        {

        }

        public Guid BookInventoryId { get; set; }

        public string BookName { get; set; }

        public string ISBN { get; set; }

        public PersonName Name { get; set; }

        public DateTime RentDate { get; set; }
    }
}