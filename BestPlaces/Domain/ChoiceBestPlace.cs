using BestPlaces.CinemaCreator.Models;

namespace BestPlaces.BiznesLogic
{

	public class BestPlace
	{
		private int _bestNumberOfRow { get; set; }
		private int _bestNumberOfSeat { get; set; }

		private readonly List<SeatRatingModel> _seatRating = new();

		public List<SeatRatingModel> GetTwoBestSeats(List<Row> cinemaHall)
		{
			_bestNumberOfRow = cinemaHall.Count / 2 + 1;

			GenerateSeatScoresInRow(cinemaHall);

			return FindBestSeatHandler(cinemaHall).ToList();

		}

		public IEnumerable<SeatRatingModel> FindBestSeatHandler(List<Row> cinemaHall)
		{

			List<List<SeatRatingModel>> middleFreeSeatsInRowList = new List<List<SeatRatingModel>>();


			for (int i = _bestNumberOfRow; i <= cinemaHall.Count; i++)
			{
				var seatsInActualRow = _seatRating.Where(a => a.Row == i).ToList();

				var firstRowResult = FindBestSeatsInRow(seatsInActualRow);

				middleFreeSeatsInRowList.Add(firstRowResult);

			}
			for (int j = _bestNumberOfRow; j >= 0; j--)
			{
				var seatsInActualRow = _seatRating.Where(a => a.Row == j).ToList();

				var secondRowResult = FindBestSeatsInRow(seatsInActualRow);

				middleFreeSeatsInRowList.Add(secondRowResult);
			}

			var sortedSeats =
				middleFreeSeatsInRowList.SelectMany(a => a)
				.OrderBy(a => a.Row).ThenBy(a => a.NumberOfSeat).Distinct();


			var middleBestSeats = sortedSeats.Skip(sortedSeats.Count() / 2).Take(2);

			if (middleBestSeats.Any(a => a.IsDoble))
			{
				return middleBestSeats.Where(a => a.IsDoble = true).Take(1);
			}

			return middleBestSeats;

		}

		public List<SeatRatingModel> FindBestSeatsInRow(List<SeatRatingModel> list)
		{
			List<SeatRatingModel> ratingList = new List<SeatRatingModel>();
			ArgumentNullException.ThrowIfNull(list);

			var freeSeats = list.Where(seat => seat.IsFree);

			var sortedSeats = freeSeats.OrderBy(seat => Math.Abs(seat.Rating)).ThenBy(seat => seat.NumberOfSeat).ToList();

			var bestSeat = sortedSeats.FirstOrDefault();

			if (bestSeat == null || sortedSeats.Count <= 1)
			{
				return new List<SeatRatingModel>();
			}
			else
			{
				ratingList.Add(bestSeat);
			}

			var leftNeighbor = sortedSeats.FirstOrDefault(seat => seat.NumberOfSeat == bestSeat.NumberOfSeat - 1);
			var rightNeighbor = sortedSeats.FirstOrDefault(seat => seat.NumberOfSeat == bestSeat.NumberOfSeat + 1);

			if (leftNeighbor != null)
				ratingList.Add(leftNeighbor);
			if (rightNeighbor != null)
				ratingList.Add(rightNeighbor);

			return ratingList;
		}




		public void GenerateSeatScoresInRow(List<Row> cinemaHall)
		{
			foreach (var row in cinemaHall)
			{
				_bestNumberOfSeat = row.Seats.Count / 2;

				for (int i = 0; i < row.Seats.Count; i++)
				{
					var rating = row.Seats[i].SeatNumber - _bestNumberOfSeat;
					bool IsDoble = true;
					if (row.Seats[i].SeatType != SeatType.EmptyPlace)
					{

						if (row.Seats[i].SeatType != SeatType.Double)
						{
							IsDoble = false;
						}

						_seatRating.Add(new SeatRatingModel()
						{
							NumberOfSeat = row.Seats[i].SeatNumber,
							Row = row.Seats[i].NumberOfRow,
							Rating = rating,
							IsFree = row.Seats[i].IsFree,
							IsDoble = IsDoble
						});
					}

				}

			}
		}

	}
}
