﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
	public class BusStopListItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Number { get; set; }
		public string Direction { get; set; }
	}
}