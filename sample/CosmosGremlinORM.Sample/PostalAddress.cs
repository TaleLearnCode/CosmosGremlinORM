using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosGremlinORM.Sample
{

	[Vertex("PostalAddress")]
	public class PostalAddress : Vertex
	{

		public PostalAddressType PostalAddressType { get; set; }

		[Property(IsRequired = false)]
		public string AddressLine1 { get; set; }

		[Property(IsRequired = false)]
		public string AddressLine2 { get; set; }

		[Property(IsRequired = true)]
		public string City { get; set; }

		[Property(IsRequired = false)]
		public string CountryDivision { get; set; }

		[Property(IsRequired = false)]
		public string Country { get; set; }

		[Property(IsRequired = false)]
		public string PostalCode { get; set; }

	}

}