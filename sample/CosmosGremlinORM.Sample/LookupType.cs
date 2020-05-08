using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosGremlinORM.Sample
{

	public abstract class LookupType : Vertex
	{

		[Property(IsRequired = true)]
		public string Name { get; set; }

		[Property(IsRequired = true)]
		public int SortOrder { get; set; }

	}

}