using Domain.Entities.Payment.Request;
using Domain.Entities.Payment.Response;
using Domain.Repository.Payment;
using Domain.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetPaymentCheckOutManageUseCase
    {
        private readonly IPaymentRepository repository;
        public GetPaymentCheckOutManageUseCase(IPaymentRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<PaymentCheckoutResponse>> ExecuteAsync(SessionCreate request)
        {

            return await repository.getPaymentCheckOutManage(request);

        }
    }

}
