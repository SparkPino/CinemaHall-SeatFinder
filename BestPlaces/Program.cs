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
            Console.WriteLine("Here are the top 2 best seats in the cinema:");
            TwoBestPlace.ForEach(a=> Console.WriteLine($"Row:{a.Row}, Seat:{a.NumberOfSeat}"));
        }
	}
}