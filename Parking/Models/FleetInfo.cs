namespace Parking.Models
{
    public class FleetInfo
    {
        public DateTime LastBouncedCheckOrMissedPayment { get; set; }
        public bool HasBouncedCheckOrMissedPayment { get; set; }
        public string BouncedCheckExplanation { get; set; }
        public bool HasInternalFleetRepairShop { get; set; }
        public bool WillPerformMaintenanceOnProperties { get; set; }
        public FleetComposition FleetComposition { get; set; }
    }
}
