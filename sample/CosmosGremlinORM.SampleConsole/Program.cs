using CosmosGremlinORM.Sample;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CosmosGremlinORM.SampleConsole
{

	public class Program
	{
		public static void Main(string[] args)
		{

			var eventDetail = new EventDetail()
			{
				Name = "Test Event 2020",
				LocationName = "Louisville, KY",
				StartDate = new DateTime(2020, 7, 1),
				EndDate = new DateTime(2020, 7, 2),
				About = "This is a really cool event"
			};

			//Console.WriteLine(eventDetail.Id);
			Console.WriteLine(GetAddVertexGremlin<EventDetail>(eventDetail));

			// g.addV('Event').property('Name', 'Test Event 2020').property('LocationName', 'Louisville, KY').property('StartDate', '2020-07-01').property('EndDate', '2020-07-02')
			// g.addV('EventDetail').property('Name', 'Test Event 2020').property('LocationName', 'Louisville, KY').property('id', 'c0909637-34a2-4fd1-908a-222fbb40d8fb')
		}


		public static string GetAddVertexGremlin<T>(T testValue)
		{
			VertexAttribute vertextAttribute = (VertexAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(VertexAttribute));

			var gremlin = new StringBuilder($"g.addV('{(vertextAttribute != null && (!string.IsNullOrWhiteSpace(vertextAttribute.Label)) ? vertextAttribute.Label : typeof(T).Name)}')");

			foreach (var property in typeof(T).GetProperties())
			{
				if (property.GetValue(testValue) != default)
				{
					if (property.PropertyType == typeof(string) && !string.IsNullOrWhiteSpace(property.GetValue(testValue).ToString()))
					{
						string key = string.Empty;
						var propertyAttibutes = property.GetCustomAttributes(true);
						if (propertyAttibutes.Length > 0)
							foreach (var propertyAttribute in propertyAttibutes)
							{
								if (propertyAttribute.GetType() == typeof(GraphPropertyAttribute))
								{
									var graphPropertyAttribute = GraphPropertyAttribute.GetGraphPropertyAttribute(property);
									key = (string.IsNullOrWhiteSpace(graphPropertyAttribute.Key)) ? CasedString(property.Name, vertextAttribute.PropertyNamingPolicy) : graphPropertyAttribute.Key;
								}
							}
						gremlin.Append($".property('{key}', '{property.GetValue(testValue)}')");
					}
				}
			}

			return gremlin.ToString();
		}

		private static string CasedString(string input, PropertyNamingPolicy propertyNamingPolicy)
		{
			switch (propertyNamingPolicy)
			{
				case PropertyNamingPolicy.CamelCase:
					input = char.ToLower(input[0]) + input.Substring(1);
					break;
				case PropertyNamingPolicy.PascalCase:
					input = char.ToUpper(input[0]) + input.Substring(1);
					break;
				default:
					break;
			}
			return input;
		}

	}

}