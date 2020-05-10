using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosGremlinORM.Sample
{

	public abstract class LookupType : Vertex
	{

		[GraphProperty(IsRequired = true)]
		public string Name { get; set; }

		[GraphProperty(IsRequired = true)]
		public int SortOrder { get; set; }

	}

}