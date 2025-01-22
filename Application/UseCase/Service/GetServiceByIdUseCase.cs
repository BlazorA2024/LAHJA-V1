using Domain.Entities.Service.Response;
using Domain.Repository.Service;
using Domain.Wrapper;

namespace Application.UseCase.Service
{
    public class GetServiceByIdUseCase
    {
        private readonly IServiceRepository repository;

        public GetServiceByIdUseCase(IServiceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<ServiceResponse>> ExecuteAsync(string id)
        {
            return await repository.GetOneAsync(id);
        }
    }


}
