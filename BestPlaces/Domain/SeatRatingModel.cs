using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPlaces.BiznesLogic
{
	public class SeatRatingModel
	{
		public int Row { get; set; }
		public int NumberOfSeat { get; set; }

		public int Rating { get; set; }

		public bool IsFree { get; set; }

		public bool IsDoble { get; set; }
	}
}
