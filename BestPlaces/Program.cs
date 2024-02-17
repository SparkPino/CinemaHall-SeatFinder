using BestPlaces.BiznesLogic;
using BestPlaces.CinemaCreator;
using BestPlaces.CinemaCreator.Models;

namespace BestPlaces
{
	static class Programm
	{
		static void Main(string[] args)
		{
			var CinemaHall = new CinemaBuilder().CreateCinemaHall();
			var TwoBestPlace = new BestPlace().GetTwoBestSeats(CinemaHall);
			Console.ReadKey();

		}
	}
}