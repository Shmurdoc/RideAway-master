namespace RideAway.Application.DTOs.Payment
{
    /// <summary>
    /// DTO for payment result.
    /// </summary>
    public class PaymentResultDTO
    {
        public bool IsSuccessful { get; set; }
        public string TransactionReference { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string? FailureReason { get; set; }
    }

    /// <summary>
    /// DTO for creating a payment request.
    /// </summary>
    public class CreatePaymentRequestDTO
    {
        public decimal Amount { get; set; }
        public RideAway.Domain.Entities.Enum.PaymentMethod Method { get; set; }
        public Guid UserId { get; set; }
        public Guid RideId { get; set; }
        public RideAway.Domain.Entities.Enum.PaymentMethod Status { get; set; }
    }

    /// <summary>
    /// DTO for payment details.
    /// </summary>
    public class PaymentDTO : PaymentResultDTO
    {
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
        public Guid RideId { get; set; }
        public RideAway.Domain.Entities.Enum.PaymentMethod Method { get; set; }
        public RideAway.Domain.Entities.Enum.PaymentMethod Status { get; set; }
    }
}
