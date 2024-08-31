namespace Parking.Models
{
    public class PreviousLandlord
    {
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string LandlordName { get; set; }
        public string SpaceRented { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public bool CanContactForReference { get; set; }
    }
}
