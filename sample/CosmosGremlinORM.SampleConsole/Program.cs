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
				Name = "Test Event 2020 4",
				LocationName = "Louisville, KY",
				StartDate = new DateTime(2020, 7, 1),
				EndDate = new DateTime(2020, 7, 2),
				About = "This is a really cool event",
				ThisIsANumber = 189,
				RegistrationSiteUri = new Uri("https://www.talelearncode.com")
			};

			//Console.WriteLine(GetAddVertexGremlin<EventDetail>(eventDetail));

			Console.WriteLine(Vertex.Save<EventDetail>(eventDetail));

		}


		public static string GetAddVertexGremlin<T>(T testValue)
		{
			VertexAttribute vertexAttribute = (VertexAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(VertexAttribute));

			var gremlin = new StringBuilder($"g.addV('{(vertexAttribute != null && (!string.IsNullOrWhiteSpace(vertexAttribute.Label)) ? vertexAttribute.Label : typeof(T).Name)}')");

			foreach (var property in typeof(T).GetProperties())
			{
				if (property.GetValue(testValue) != default && IsValidType(property.PropertyType))
				{
					string key = property.Name;
					var propertyAttibutes = property.GetCustomAttributes(true);
					if (propertyAttibutes.Length > 0)
						foreach (var propertyAttribute in propertyAttibutes)
						{
							if (propertyAttribute.GetType() == typeof(GraphPropertyAttribute))
							{
								var graphPropertyAttribute = (GraphPropertyAttribute)Attribute.GetCustomAttribute(property, typeof(GraphPropertyAttribute), true);
								key = (string.IsNullOrWhiteSpace(graphPropertyAttribute.Key)) ? CasedString(property.Name, vertexAttribute.PropertyNamingPolicy) : graphPropertyAttribute.Key;
							}
						}

					if (property.PropertyType == typeof(bool))
						gremlin.Append($".property('{key}', {property.GetValue(testValue).ToString().ToLower()})");
					else
					{
						var isNumeric = CheckAndGetNumber(property.GetValue(testValue));
						if (isNumeric.Item1)
							gremlin.Append($".property('{key}', {isNumeric.Item2})");
						else
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

		private static Tuple<bool, string> CheckAndGetNumber(object testValue)
		{

			var returnValue = new Tuple<bool, string>(false, string.Empty);
			bool isFloat = float.TryParse(testValue.ToString(), out var floatNumber);
			if (isFloat)
			{
				bool isLong = long.TryParse(testValue.ToString(), out var longNumber);
				if (isLong)
					returnValue = new Tuple<bool, string>(true, longNumber.ToString());
				else
					returnValue = new Tuple<bool, string>(true, floatNumber.ToString());
			}

			bool isDecimal = decimal.TryParse(testValue.ToString(), out var decimalNumber);
			if (isDecimal)
				returnValue = new Tuple<bool, string>(true, decimalNumber.ToString());

			return returnValue;

		}

		private static bool IsValidType(Type type)
		{
			// TODO: Look at a better of figuring out what is a valid type
			if (type.IsPrimitive)
				return true;
			else if (type == typeof(string))
				return true;
			else if (type == typeof(DateTime))
				return true;
			else if (type == typeof(Uri))
				return true;
			else
				return false;
		}

	}

}