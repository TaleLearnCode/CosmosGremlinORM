using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosGremlinORM.SampleConsole
{

	public class EventContext : GraphContext
	{

		public EventContext(Uri endpoint, string authorizationKey, string database, string graph, int port = 443) : base(endpoint, authorizationKey, database, graph, port)
		{

		}


	}

}