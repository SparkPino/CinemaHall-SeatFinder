namespace BestPlaces.CinemaCreator.Models
{
	public enum SeatType
    {
        Regular,
        Double,
        Special,
        EmptyPlace
    }

    public class Seat
    {
        public int SeatNumber { get; set; }
        public bool IsFree { get; set; }
        public SeatType SeatType { get; set; }
        public int NumberOfRow { get; set; }
    }
}

