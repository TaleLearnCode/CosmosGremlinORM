using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CosmosGremlinORM.Sample
{

	[Vertex("Event")]
	public class EventDetail : Vertex
	{

		[Property(IsRequired = true)]
		public string Name { get; set; }

		[Property(IsRequired = false)]
		public string About { get; set; }

		[Property(IsRequired = false)]
		public string LocationName { get; set; }

		[Property(IsRequired = false)]
		public PostalAddress Location { get; set; }

		[Property(IsRequired = true)]
		public DateTime StartDate { get; set; }

		[Property(IsRequired = true)]
		public DateTime EndDate { get; set; }

		[Property(IsRequired = false)]
		public List<EventDay> EventDays { get; } = new List<EventDay>();

		[Property(IsRequired = false)]
		public Uri RegistrationSiteUri { get; set; }

	}

}