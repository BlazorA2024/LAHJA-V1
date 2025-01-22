using Domain.Entities.Service.Response;
using Domain.Repository.Service;
using Domain.Wrapper;

namespace Application.UseCase.Service
{
    public class GetAllServicesUseCase
    {
        private readonly IServiceRepository repository;

        public GetAllServicesUseCase(IServiceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<List<ServiceResponse>>> ExecuteAsync()
        {
            return await repository.GetAllAsync();
        }
    }

}
