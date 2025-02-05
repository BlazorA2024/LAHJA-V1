using AutoMapper;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Profile.Response;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.ApiClient.Profile
{
    public class ProfileApiClient: BuildApiClient<ProfileClient>
    {

        public ProfileApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config)
            : base(clientFactory, mapper, config)
        {
        }

        public async Task<Result<ProfileResponseModel>> getProfileAsync()
        {
            try
            {

                var client = await GetApiClient(); 
                //var response = await client.PlansGetAsync(id);
                //var resModel = _mapper.Map<ProfileResponseModel>(response);
                return Result<ProfileResponseModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<ProfileResponseModel>.Fail(e.Response);

            }



        }

        public  async  Task<ICollection<SubscriptionResponse>> SubscriptionsAsync()
        {
            var client = await GetApiClient();

            var response = await client.SubscriptionsAsync();
            return response;

        }

        public async Task<ICollection<ModelAiResponse>> ModelAisAsync()
        {
            var client = await GetApiClient();

            var response = await client.ModelAisAsync();
            return response;

        }

        public async Task<ICollection<ServiceResponse>> ServicesAsync()
        {
            var client = await GetApiClient();

            var response = await client.ServicesAsync();
            return response;

        }

        public async Task<ICollection<ServiceResponse>> ServicesModelAiAsync(string modelAiId)
        {
            var client = await GetApiClient();

            var response = await client.ServicesModelAiAsync(modelAiId);
            return response;

        }

        public async Task<ICollection<SpaceResponse>> SpacesSubscriptionAsync(string subscriptionId)
        {
            var client = await GetApiClient();

            var response = await client.SpacesSubscriptionAsync(subscriptionId);
            return response;

        }


        public async Task<SpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId)
        {
            var client = await GetApiClient();

            var response = await client.SpaceSubscriptionAsync(subscriptionId, spaceId);
            return response;

        }



        public async Task<ICollection<RequestResponse>> RequestsServiceAsync(string serviceId)
        {
            var client = await GetApiClient();

            var response = await client.RequestsServiceAsync(serviceId);
            return response;

        }



    }
}
