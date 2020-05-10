using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosGremlinORM.Sample
{

	[Vertex("PostalAddress")]
	public class PostalAddress : Vertex
	{

		public PostalAddressType PostalAddressType { get; set; }

		[GraphProperty(IsRequired = false)]
		public string AddressLine1 { get; set; }

		[GraphProperty(IsRequired = false)]
		public string AddressLine2 { get; set; }

		[GraphProperty(IsRequired = true)]
		public string City { get; set; }

		[GraphProperty(IsRequired = false)]
		public string CountryDivision { get; set; }

		[GraphProperty(IsRequired = false)]
		public string Country { get; set; }

		[GraphProperty(IsRequired = false)]
		public string PostalCode { get; set; }

	}

}