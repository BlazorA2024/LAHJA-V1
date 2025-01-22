using Application.UseCase.Plans;
using Domain.Entities.Profile;
using Domain.Wrapper;

namespace Application.Services.Profile
{
    public class ProfileService
    {
        private readonly GetProfileUseCase getProfileUseCase;
        private readonly CreateProfileUseCase _createProfileUseCase;
        private readonly UpdateProfileUseCase _updateProfileUseCase;
        private readonly DeleteProfileUseCase _deleteProfileUseCase;


        public ProfileService(GetProfileUseCase getProfileUseCase, CreateProfileUseCase createProfileUseCase, UpdateProfileUseCase updateProfileUseCase, DeleteProfileUseCase deleteProfileUseCase)
        {
            this.getProfileUseCase = getProfileUseCase;
            _createProfileUseCase = createProfileUseCase;
            _updateProfileUseCase = updateProfileUseCase;
            _deleteProfileUseCase = deleteProfileUseCase;
        }

        public async Task<Result<ProfileResponse>> getProfileAsync()
        {
            return await getProfileUseCase.ExecuteAsync();

        }

        public async Task<Result<ProfileResponse>> CreateAsync(ProfileRequest request)
        {
            return await _createProfileUseCase.ExecuteAsync(request);

        }
        public async Task<Result<ProfileResponse>> UpdateAsync(ProfileRequest request)
        {
            return await _updateProfileUseCase.ExecuteAsync(request);

        }

        public async Task<Result<bool>> DeleteAsync(string profileId)
        {
            return await _deleteProfileUseCase.ExecuteAsync(profileId);

        }



    }
}
