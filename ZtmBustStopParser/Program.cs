using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebService.Models;

namespace ZtmBustStopParser
{
	class Program
	{

		static void Main(string[] args)
		{
			using (var db = new BusContext())
			{
				string line = null, name = null, city = null;
				int? id = null;
				bool zpSection = false;
				StreamReader streamReader = new StreamReader(@"C:\RA150525.TXT", Encoding.GetEncoding("windows-1250"));
				while ((line = streamReader.ReadLine()) != null)
				{
					if (zpSection == false)
					{
						var regex = new Regex(@"^\*ZP\s2344");
						if (regex.IsMatch(line))
						{
							zpSection = true;
						}
					}
					else
					{
						var regex = new Regex(@"^\s{3}(\d{4})\s{3}(.*),\s+--\s{2}(.*)\s*");
						var regex_busstop =
							new Regex(@"^\s{9}(\d{4}(\d{2}))\s{3}.*Ul\.\/Pl\.:\s(.+),\s+Kier\.\:\s(.*),\s+Y=\s(.*)\s+X=\s(.*)\s{2}");
						if (regex.IsMatch(line))
						{
							var result = regex.Match(line);
							id = Int32.Parse(result.Groups[1].ToString());
							name = result.Groups[2].ToString();
							city = result.Groups[3].ToString();


							Console.WriteLine(line);
						}
						else if (regex_busstop.IsMatch(line))
						{
							var result = regex_busstop.Match(line);

							var newBus = new BusStopEntity();
							newBus.City =	city;
							newBus.Direction = result.Groups[4].ToString();
							newBus.Id = Int32.Parse(result.Groups[1].ToString());
							newBus.Street = result.Groups[3].ToString();
							newBus.Number = result.Groups[2].ToString();
							newBus.Name =name;
							newBus.Lat = Double.Parse(result.Groups[5].ToString().Replace('.', ','));
							newBus.Long = Double.Parse(result.Groups[6].ToString().Replace('.', ','));
							db.BusStops.Add(newBus);
							db.SaveChanges();
						}
					}

				}
				streamReader.Close();
				Console.ReadKey();
				
			}
		}
	}
}
