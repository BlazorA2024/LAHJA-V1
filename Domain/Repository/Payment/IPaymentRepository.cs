using Domain.Entities.Payment.Response;
using Domain.Entities.Payment;
using Domain.Wrapper;
using Domain.Entities.Payment.Request;

namespace Domain.Repository.Payment
{
    public interface IPaymentRepository
    {
        Task<Result<PaymentCheckoutResponse>> getPaymentCheckoutPage(PaymentCheckoutRequest request);
        Task<Result<PaymentCheckoutResponse>> getPaymentCheckOutManage(SessionCreate request);
    }

}
