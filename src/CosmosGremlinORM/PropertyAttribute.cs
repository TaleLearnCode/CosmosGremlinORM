using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosGremlinORM
{

	/// <summary>
	/// Attributes for defining a graph property.
	/// </summary>
	/// <seealso cref="System.Attribute" />
	[AttributeUsage(AttributeTargets.Property)]
	public class PropertyAttribute : Attribute
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

		public PropertyAttribute()
		{
			IsRequired = false;
			IncludeInGraph = true;
		}

	}

}