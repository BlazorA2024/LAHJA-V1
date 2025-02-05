using Application.Services.Profile;
using Application.UseCase.Plans;
using AutoMapper;
using Domain.Entities.Profile;
using Domain.Wrapper;
using Infrastructure.Nswag;
using LAHJA.Helpers.Services;

namespace LAHJA.ApplicationLayer.Profile
{
    public class ProfileClientService
    {
        private readonly ProfileService profileService;
        private readonly TokenService tokenService;
        private readonly IMapper _mapper;

        public ProfileClientService(ProfileService profileService,
            IMapper mapper,
            TokenService tokenService)
        {

            this.profileService = profileService;
            _mapper = mapper;
            this.tokenService = tokenService;
        }


        //public async Task<ICollection<SubscriptionResponse>> SubscriptionsAsync()
        //{

        //    return await profileService.SubscriptionsAsync();
        //}

            //public async Task<Result<ProfileResponse>> GetProfileAsync()
            //{

            //    return await profileService.getProfileAsync();

            //    //if ( result.Succeeded)
            //    //{
            //    //    var res = result.Data;
            //    //    var data = _mapper.Map<List<PlansFeture>>(res);
            //    //    int i = 0;
            //    //foreach (var item in data)
            //    //{
            //    //    item.Services = _mapper.Map<List<ProfileResponse>>(res[i].SubscriptionFeatures);
            //    //    item.numberOfServices = _mapper.Map<List<NumberOfService>>(res[i++].TechnicalFeatures);
            //    //}
            //    //    return Result<List<PlansFeture>>.Success(data);
            //    //}
            //    //else
            //    //{
            //    //    return Result<List<PlansFeture>>.Fail();
            //    //}

            //}

            //public async Task<Result<ProfileResponse>> CreateAsync(ProfileRequest request)
            //{
            //    return await profileService.CreateAsync(request);

            //}
            //public async Task<Result<ProfileResponse>> UpdateAsync(ProfileRequest request)
            //{
            //    return await profileService.UpdateAsync(request);

            //}

            //public async Task<Result<bool>> DeleteAsync(string profileId)
            //{
            //    return await profileService.DeleteAsync(profileId);

            //}

        }
}
