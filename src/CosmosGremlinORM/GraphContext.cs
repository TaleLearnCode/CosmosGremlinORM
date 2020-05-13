using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosGremlinORM
{

	public class GraphContext
	{

		public Uri Endpoint { get; set; }

		public string AuthorizationKey { get; set; }  // TODO: Need to better handle the authorization key

		public int Port { get; set; } = 443;

		public string Database { get; set; }

		public string Graph { get; set; }

		public GraphContext(Uri endpoint, string authorizationKey, string database, string graph, int port = 443)
		{
			Endpoint = endpoint;
			AuthorizationKey = authorizationKey;
			Database = database;
			Graph = graph;
			Port = port;
		}

	}

}