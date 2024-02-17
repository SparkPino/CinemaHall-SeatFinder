using BestPlaces.CinemaCreator.Models;

namespace BestPlaces.CinemaCreator.CinemaCreatorModels
{
	public class ProportionHandler
	{
		private readonly List<Proportion> listOfProportios;

		public ProportionHandler()
		{
			listOfProportios = new List<Proportion>();
		}

		public void MakeRow(int Quantity, SeatType TypeSeats )
		{
			listOfProportios.Add(new Proportion(Quantity, TypeSeats));
		}

		public List<Proportion> GetProportionList()
		{
			return listOfProportios;
		}
	}
}
