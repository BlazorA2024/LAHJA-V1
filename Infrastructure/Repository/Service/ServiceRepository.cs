
using AutoMapper;
using Domain.Wrapper;
using Infrastructure.DataSource.Seeds;

using Domain.ShareData.Base;
using Infrastructure.Models.BaseFolder.Response;
using Infrastructure.DataSource.ApiClient.Service;
using Domain.Repository.Service;
using Shared.Settings;
using Infrastructure.Models.Service.Response;
using Domain.Entities.Service.Response;
using Domain.Entities.Service.Request;
using Infrastructure.Models.Service.Request;
using System.Text.Json.Serialization;


namespace Infrastructure.Repository.Services
{

    public class ServiceRepository : IServiceRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly ServiceApiClient _servicesApiClient;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public ServiceRepository(
            IMapper mapper,
            SeedsPlans seedsPlans,
            ApplicationModeService appModeService,
            ServiceApiClient ServicesApiClient)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;

            this._servicesApiClient = ServicesApiClient;
        }
      
        public async Task<Result<List<ServiceResponse>>> GetAllAsync()
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<List<ServiceResponseModel>>>(
                 async () => await _servicesApiClient.GetAllAsync(),
                  async () => Result<List<ServiceResponseModel>>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<List<ServiceResponse>>(response.Data) : null;
                return Result<List<ServiceResponse>>.Success(result);
            }
            else
            {
                return Result<List<ServiceResponse>>.Fail(response.Messages);
            }


        }
        public async Task<Result<ServiceResponse>> GetOneAsync(string id)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<ServiceResponseModel>>(
                 async () => await _servicesApiClient.GetOneAsync(id),
                  async () => Result<ServiceResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<ServiceResponse>(response.Data) : null;
                return Result<ServiceResponse>.Success(result);
            }
            else
            {
                return Result<ServiceResponse>.Fail(response.Messages);
            }


        }
        public async Task<Result<ServiceResponse>> UpdateAsync(ServiceRequest request)
        {
            var model = _mapper.Map<ServiceRequestModel>(request);

            var response = await ExecutorAppMode.ExecuteAsync<Result<ServiceResponseModel>>(
                 async () => await _servicesApiClient.UpdateAsync(model),
                  async () => Result<ServiceResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<ServiceResponse>(response.Data) : null;
                return Result<ServiceResponse>.Success(result);
            }
            else
            {
                return Result<ServiceResponse>.Fail(response.Messages);
            }



        }
        public async Task<Result<ServiceResponse>> CreateAsync(ServiceRequest request)
        {
            var model = _mapper.Map<ServiceRequestModel>(request);

            var response = await ExecutorAppMode.ExecuteAsync<Result<ServiceResponseModel>>(
                 async () => await _servicesApiClient.CreateAsync(model),
                  async () => Result<ServiceResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<ServiceResponse>(response.Data) : null;
                return Result<ServiceResponse>.Success(result);
            }
            else
            {
                return Result<ServiceResponse>.Fail(response.Messages);
            }



        }
        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<DeleteResponseModel>>(
                 async () => await _servicesApiClient.DeleteAsync(id),
                  async () => Result<DeleteResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<DeleteResponse>(response.Data) : null;
                return Result<DeleteResponse>.Success(result);
            }
            else
            {
                return Result<DeleteResponse>.Fail(response.Messages);
            }
        }


   

      
    } 
}
