using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CosmosGremlinORM.Sample
{

	[Vertex("event")]
	public class EventDetail : Vertex
	{

		[GraphProperty(Key = "eventId")]
		public string EventId { get { return Id; } }

		[GraphProperty(IsRequired = true)]
		public string Name { get; set; }

		[GraphProperty(IsRequired = false, Key = "About")]
		public string About { get; set; }

		[GraphProperty(IsRequired = false)]
		public string LocationName { get; set; }

		[GraphProperty(IsRequired = false)]
		public PostalAddress Location { get; set; }

		[GraphProperty(IsRequired = true)]
		public DateTime StartDate { get; set; }

		[GraphProperty(IsRequired = true)]
		public DateTime EndDate { get; set; }

		[GraphProperty(IsRequired = false)]
		public List<EventDay> EventDays { get; } = new List<EventDay>();

		[GraphProperty(IsRequired = false)]
		public Uri RegistrationSiteUri { get; set; }

		[GraphProperty(IsRequired = false)]
		public float ThisIsANumber { get; set; }

		public bool CurrentEvent { get; set; }

	}

}