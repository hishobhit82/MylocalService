using MyLocalEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace MyLocalService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyLocalService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select MyLocalService.svc or MyLocalService.svc.cs at the Solution Explorer and start debugging.
	public class MyLocalService : IMyLocalService
	{		
		public ServiceResult<Person> GetData(int value)
		{
			var persons = new List<Person>();

			using (var sw = new StreamReader(@"F:\Code\Persons.csv"))
			{
				while (!sw.EndOfStream)
				{
					if (value == 0) break;

					var line = sw.ReadLine().Split(',');

					var personObj = new Person()
					{
						Name = line[0],
						Age = Convert.ToInt32(line[1].Substring(3, line[1].Length - 3)),
						City = line[2],
						Qualities = Person.GetQualities(line[3])
					};

					persons.Add(personObj);

					value--;
				}
			};

			var result = new ServiceResult<Person>(persons.ToArray());
			return result;

		}
	}
}
