using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosGremlinORM
{

	public class Vertex
	{

		/// <summary>
		/// Gets or sets the identifier of the vertex document.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the vertex document identifier.
		/// </value>
		[GraphProperty(Key = "id")]
		public string Id { get; set; } = Guid.NewGuid().ToString();

		/// <summary>
		/// Gets or sets the key of the partition where the document is stored.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the value of the key for the partition where the document is stored.
		/// </value>
		public string PartitionKey { get; set; }

	}

}