using CosmosGremlinORM.Sample;
using System;

namespace CosmosGremlinORM.SampleConsole
{

	public class Program
	{
		static void Main(string[] args)
		{

			var eventDetail = new EventDetail()
			{
				Name = "Test Event 2020",
				LocationName = "Louisville, KY",
				StartDate = new DateTime(2020, 7, 1),
				EndDate = new DateTime(2020, 7, 2)
			};

			Console.WriteLine(eventDetail.Id);

			// g.addV('Event').property('name', 'Test Event 2020').property('locationName', 'Louisville, KY').property('StartDate', '2020-07-01').property('EndDate', '2020-07-02')

		}
	}

}