using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosGremlinORM.Sample
{

	[Vertex("EventDay")]
	public class EventDay : Vertex
	{

		[GraphProperty(IsRequired = true)]
		public DateTime Date { get; set; }

		[GraphProperty(IsRequired = true)]
		public int StartTimeOffset { get; set; }

		[GraphProperty(IsRequired = true)]
		public int EndDateTime { get; set; }

		// TODO: If no value in graph; set value to the Date
		[GraphProperty(IsRequired = false)]
		public string Title { get; set; }

	}

}