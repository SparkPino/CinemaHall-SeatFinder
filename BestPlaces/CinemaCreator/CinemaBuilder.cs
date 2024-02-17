using BestPlaces.CinemaCreator.CinemaCreatorModels;
using BestPlaces.CinemaCreator.Models;

namespace BestPlaces.CinemaCreator
{
	public class CinemaBuilder
	{
		private readonly List<Row> _cinemaHallRows;

		private readonly SeatsCreatorService _seatService;

		public CinemaBuilder()
		{
			_seatService = new SeatsCreatorService();
			_cinemaHallRows = new List<Row>();
		}


		/// <summary>
		///Used a switch case to create a static cinema hall, as the task instructed to use the cinema hall layout from the diagram.
		/// </summary>
		private void BuildSeatsInRows()
		{

			for (int i = 0; i < _seatService.NumberOfRows ; i++)
			{
				var setting = new ProportionHandler();


				switch (i + 1)
				{
					case 1:
						setting.MakeRow(10, SeatType.Regular);
						setting.MakeRow(2, SeatType.Special);
						setting.MakeRow(6, SeatType.EmptyPlace);

						break;
					case 2:
					case 3:
					case 4:
					case 5:
						setting.MakeRow(13, SeatType.Regular);
						setting.MakeRow(5, SeatType.EmptyPlace);
						break;
					case 6:
					case 7:
					case 8:
						setting.MakeRow(13, SeatType.Regular);
						setting.MakeRow(2, SeatType.EmptyPlace);
						setting.MakeRow(3, SeatType.Regular);
						break;
					case 9:
					case 10:
						setting.MakeRow(6, SeatType.Double);
						setting.MakeRow(1, SeatType.Regular);
						setting.MakeRow(2, SeatType.EmptyPlace);
						setting.MakeRow(1, SeatType.Double);
						setting.MakeRow(1, SeatType.Regular);
						break;
					case 11:
						setting.MakeRow(9, SeatType.Double);
						break;

				}

				var row = new Row()
				{
					Seats = _seatService.AddSeats(setting.GetProportionList(), i + 1).ToList()
				};

				_cinemaHallRows.Add(row);
			}

		}

		public List<Row> CreateCinemaHall()
		{
			BuildSeatsInRows();
			
			return _cinemaHallRows;
		}

	}
}
