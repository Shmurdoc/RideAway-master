using RideAway.Domain.Entities.Enum;
using RideAway.Domain.Value_Object;

namespace RideAway.Application.DTOs
{
    // This file is now obsolete. All payment-related DTOs have been moved to DTOs/Payment/ for DDD compliance.
    public class PaymentResultDTO
    {
        public bool IsSuccessful { get; set; }
        public string TransactionReference { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string? FailureReason { get; set; }
    }

    public class CreatePaymentRequestDTO : PaymentResultDTO
    {
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; }
        public Guid UserId { get; set; }
        public Guid RideId { get; set; }
        public PaymentStatus Status { get; set; }
    }

    public class PaymentDTO : CreatePaymentRequestDTO
    {
        
    }
}
