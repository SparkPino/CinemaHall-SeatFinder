namespace BestPlaces.CinemaCreator.Models
{
	public class Row
    {
      
        public List<Seat> Seats { get; set; }

        public Row()
        {
	        Seats = new List<Seat>();
        }
    }
}
