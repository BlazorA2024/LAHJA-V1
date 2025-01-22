using Domain.Entities.Subscriptions.Request;
using Domain.Entities.Subscriptions.Response;
using Domain.Repository.Subscriptions;
using Domain.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class CreateSubscriptionUseCase
    {
        private readonly ISubscriptionsRepository repository;
        public CreateSubscriptionUseCase(ISubscriptionsRepository repository)
        {

            this.repository = repository;
        }

        public async Task<Result<SubscriptionResponse>> ExecuteAsync(SubscriptionRequest request)
        {

            return await repository.CreateAsync(request);

        }
    }  






}
