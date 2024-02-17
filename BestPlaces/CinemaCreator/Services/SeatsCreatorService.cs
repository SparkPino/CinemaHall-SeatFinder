using BestPlaces.CinemaCreator.Models;

namespace BestPlaces.CinemaCreator.CinemaCreatorModels
{
	public record Proportion(int Quantity, SeatType SeatType);

	public class SeatsCreatorService
	{
		public readonly int NumberOfRows = 11;
		private int seatNumberCounter = 0;

		public IEnumerable<Seat> AddSeats(List<Proportion> settings, int NumberOfRows)
		{
			for (int i = 0; i <= settings.Count - 1; i++)
			{
				for (int j = 0; j < settings[i].Quantity; j++)
				{
					seatNumberCounter++;
					if (settings[i].SeatType == SeatType.EmptyPlace)
					{
						seatNumberCounter--;
						yield return new Seat
						{
							IsFree = true,
							SeatType = settings[i].SeatType,
							NumberOfRow = NumberOfRows

						};
					}
					else
					{
						yield return new Seat
						{
							IsFree = true,
							SeatType = settings[i].SeatType,
							SeatNumber = seatNumberCounter,
							NumberOfRow = NumberOfRows

						};
					}

				}


			}
			seatNumberCounter = 0;
		}

	}






}
