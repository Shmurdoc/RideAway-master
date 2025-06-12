namespace RideAway.Application.DTOs.Driver
{
    /// <summary>
    /// DTO for driver earnings and payout processing.
    /// </summary>
    public class EarningsDTO
    {
        public Guid DriverId { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal PendingPayout { get; set; }
        public DateTime LastPayoutDate { get; set; }
    }
}
