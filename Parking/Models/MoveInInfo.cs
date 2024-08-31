namespace Parking.Models
{
    public class MoveInInfo
    {
        public DateTime MoveInDate { get; set; }
        public string TruckOrTrailers { get; set; }
        public decimal RateApprovedPerSpot { get; set; }
        public string LocationAppliedFor { get; set; }
        public bool IsCarrierBasedInOntario { get; set; }
        public string StateOrProvince { get; set; }
    }
}
