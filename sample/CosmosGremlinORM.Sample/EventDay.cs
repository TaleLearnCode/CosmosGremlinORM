using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosGremlinORM.Sample
{

	[Vertex("EventDay")]
	public class EventDay : Vertex
	{

		[Property(IsRequired = true)]
		public DateTime Date { get; set; }

		[Property(IsRequired = true)]
		public int StartTimeOffset { get; set; }

		[Property(IsRequired = true)]
		public int EndDateTime { get; set; }

		// TODO: If no value in graph; set value to the Date
		[Property(IsRequired = false)]
		public string Title { get; set; }

	}

}