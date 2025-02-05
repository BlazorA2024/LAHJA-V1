using AutoMapper;
using Domain.Entities.Profile;
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

        public  async  Task<ICollection<ProfileSubscriptionResponse>> SubscriptionsAsync()
        {
            var client = await GetApiClient();

            var response = await client.SubscriptionsAsync();
            var resModel = _mapper.Map<ICollection<ProfileSubscriptionResponse>>(response);

            return resModel;

        }

        public async Task<ICollection<ProfileModelAiResponse>> ModelAisAsync()
        {
            var client = await GetApiClient();

            var response = await client.ModelAisAsync(); 
            var resModel = _mapper.Map<ICollection<ProfileModelAiResponse>>(response);

            return resModel;

        }

        public async Task<ICollection<ProfileServiceResponse>> ServicesAsync()
        {
            var client = await GetApiClient();

            var response = await client.ServicesAsync();
            var resModel = _mapper.Map<ICollection<ProfileServiceResponse>>(response);

            return resModel;
         

        }

        public async Task<ICollection<ProfileServiceResponse>> ServicesModelAiAsync(string modelAiId)
        {
            var client = await GetApiClient();

            var response = await client.ServicesModelAiAsync(modelAiId);
            var resModel = _mapper.Map<ICollection<ProfileServiceResponse>>(response);

            return resModel;
       

        }

        public async Task<ICollection<ProfileSpaceResponse>> SpacesSubscriptionAsync(string subscriptionId)
        {
            var client = await GetApiClient();

            var response = await client.SpacesSubscriptionAsync(subscriptionId);
            var resModel = _mapper.Map<ICollection<ProfileSpaceResponse>>(response);

            return resModel;
      

        }


        public async Task<ProfileSpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId)
        {
            var client = await GetApiClient();

            var response = await client.SpaceSubscriptionAsync(subscriptionId, spaceId);
            var resModel = _mapper.Map<ProfileSpaceResponse>(response);

            return resModel;
           
        }



        public async Task<ICollection<RequestResponse>> RequestsServiceAsync(string serviceId)
        {
            var client = await GetApiClient();

            var response = await client.RequestsServiceAsync(serviceId);
            return response;

        }



    }
}
