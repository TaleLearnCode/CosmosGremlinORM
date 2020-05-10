using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace CosmosGremlinORM
{

	/// <summary>
	/// Attributes for defining a graph property.
	/// </summary>
	/// <seealso cref="System.Attribute" />
	[AttributeUsage(AttributeTargets.Property)]
	public class GraphPropertyAttribute : Attribute
	{

		/// <summary>
		/// Gets or sets the name of the key for the property.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the property key name.
		/// </value>
		public string Key { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the property value is required within the graph.
		/// </summary>
		/// <value>
		///   <c>true</c> if the value of the property is required within the graph; otherwise, <c>false</c>.
		/// </value>
		public bool IsRequired { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether property is included in the graph document.
		/// </summary>
		/// <value>
		///   <c>true</c> if property is included in the graph document; otherwise, <c>false</c>.
		/// </value>
		public bool IncludeInGraph { get; set; }

		public GraphPropertyAttribute()
		{
			IsRequired = false;
			IncludeInGraph = true;
		}

		public static GraphPropertyAttribute GetGraphPropertyAttribute(PropertyInfo propertyInfo)
		{
			if (propertyInfo is null) return new GraphPropertyAttribute();
			var graphPropertyAttribute = new GraphPropertyAttribute();
			foreach (var attribute in propertyInfo.CustomAttributes)
			{
				if (attribute.AttributeType == typeof(GraphPropertyAttribute))
				{
					foreach (var namedArgument in attribute.NamedArguments)
					{
						switch (namedArgument.MemberName)
						{
							case "Key":
								graphPropertyAttribute.Key = namedArgument.TypedValue.ToString().Replace("\"", string.Empty);
								break;
							case "IsRequired":
								graphPropertyAttribute.IsRequired = (bool)namedArgument.TypedValue.Value;
								break;
							case "IncludeInGraph":
								graphPropertyAttribute.IsRequired = (bool)namedArgument.TypedValue.Value;
								break;
						}
					}
				}
			}
			return graphPropertyAttribute;
		}
	}

}