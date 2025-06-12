namespace RideAway.Application.DTOs.Payment
{
    /// <summary>
    /// DTO for driver payout processing.
    /// </summary>
    public class PayoutDTO
    {
        public Guid DriverId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PayoutDate { get; set; }
        public string? BankAccount { get; set; }
        public string? Status { get; set; }
    }
}
