using Application.UseCase.Plans;
using Application.UseCase.Plans.Get;
using Domain.Entities.Payment;
using Domain.Entities.Payment.Request;
using Domain.Entities.Payment.Response;
using Domain.Entities.Plans.Response;
using Domain.Wrapper;
using Infrastructure.Models.Profile.Response;

namespace Application.Services.Plans
{
    public class PaymentService
    {
        private readonly GetPaymentCheckOutUseCase getPaymentCheckOutUseCase;
        private readonly GetPaymentCheckOutManageUseCase getPaymentCheckOutManageUseCase;


        public PaymentService(GetPaymentCheckOutUseCase getPaymentCheckOutUseCase, GetPaymentCheckOutManageUseCase getPaymentCheckOutManage)
        {
            this.getPaymentCheckOutUseCase = getPaymentCheckOutUseCase;
            this.getPaymentCheckOutManageUseCase = getPaymentCheckOutManage;
        }

        public async Task<Result<PaymentCheckoutResponse>> getPaymentCheckOut(PaymentCheckoutRequest  request)
        {
            return await getPaymentCheckOutUseCase.ExecuteAsync(request);

        }

        public async Task<Result<PaymentCheckoutResponse>> getPaymentCheckOutManage(SessionCreate request)
        {
            return await getPaymentCheckOutManageUseCase.ExecuteAsync(request);

        }




    } 
}
