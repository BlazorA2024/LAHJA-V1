
using Domain.Entities.Profile;
using Domain.ShareData.Base.Auth;
using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Models.BaseFolder.Response;
using Infrastructure.Models.Payment.Request;
using Infrastructure.Models.Payment.Response;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Price.Request;
using Infrastructure.Models.Price.Response;
using Infrastructure.Models.Product.Request;
using Infrastructure.Models.Product.Response;
using Infrastructure.Models.Service.Request;
using Infrastructure.Models.Service.Response;
using Infrastructure.Models.Setting.Request;
using Infrastructure.Models.Subscriptions.Request;
using Infrastructure.Models.Subscriptions.Response;
using Infrastructure.Nswag;


namespace Infrastructure.Mappings.Plans
{

    public class InfrastructureRemoteMappingConfig : AutoMapper.Profile
    {
        public InfrastructureRemoteMappingConfig()
        {

            /// Auth
            /// 

            CreateMap<ProfileModelAiResponse,ModelAiResponse>().ReverseMap();

            CreateMap<ProfileSpaceResponse, SpaceResponse>().ReverseMap();
            CreateMap<ProfileServiceResponse, ServiceResponse>().ReverseMap();
            CreateMap<ProfileSubscriptionResponse, SubscriptionResponse>().ReverseMap();

            CreateMap<AccessTokenResponse, AccessTokenResponseModel>().ReverseMap();
            CreateMap<RefreshRequestModel, RefreshRequest>().ReverseMap();
            //CreateMap<ConfirmationEmailModel, ConfirmationEmailRequest>().ReverseMap();
            CreateMap<ResendConfirmationEmailRequest, ResendConfirmationEmailModel>().ReverseMap();
            CreateMap<ResetPasswordRequest, ResetPasswordRequestModel>().ReverseMap();
         

            CreateMap<LoginRequestModel, LoginRequest>().ReverseMap();
            CreateMap<RegisterRequestModel,  RegisterRequest>()
                 .ForMember(dest => dest.FirsName, opt => opt.MapFrom(src => src.FirstName))
                //.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => "string"))
                //.ForMember(dest => dest.ConfirmPassword, opt => opt.MapFrom(src => src.Password))
                //.ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => "string"))
                .ReverseMap();

            CreateMap<LoginResponseModel, AccessTokenResponse>().ReverseMap();

            CreateMap<ConfirmationEmailModel, ConfirmEmailRequest>().ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgetPasswordRequestModel>().ReverseMap();



            CreateMap<DeletedResponse, DeleteResponseModel>().ReverseMap();


            /// Payment
            CreateMap<PaymentCheckoutRequestModel, CheckoutOptions>().ReverseMap();
            CreateMap<PaymentCheckoutResponseModel, CheckoutResponse>().ReverseMap();
            CreateMap<SessionCreateModel, SessionCreate>().ReverseMap();


            /// Price
            CreateMap<PriceCreate, PriceCreateRequestModel>().ReverseMap();
            CreateMap<PriceUpdate, PriceUpdateRequestModel>().ReverseMap();
            CreateMap<PriceResponse, PriceResponseModel>().ReverseMap();


            /// Product

            CreateMap<ProductResponseModel, ProductResponse>().ReverseMap();
            CreateMap<ProductCreateModel, ProductCreate>().ReverseMap();
            CreateMap<ProductUpdateModel, ProductUpdate>().ReverseMap();
            //CreateMap<ProductSearchRequestModel, Product>().ReverseMap();
            /// Profile
            //CreateMap<ProfileResponseModel, >().ReverseMap();



            //// Subscriptions 
            CreateMap<SubscriptionResponse, SubscriptionResponseModel>().ReverseMap();
            CreateMap<PlanResponse, SubscriptionPlanModel>().ReverseMap();
      
 

            //// Settings 
            //CreateMap<object, SettingResponseModel>().ReverseMap();
            CreateMap<SettingUpdate, SettingUpdateModel>().ReverseMap();
            CreateMap<SettingCreate, SettingCreateModel>().ReverseMap();


            //// Billing
            //CreateMap< ,CardDetailsResponseModel>().ReverseMap();
            //CreateMap< ,BillingDetailsResponseModel>().ReverseMap();
            //CreateMap< ,CardDetailsRequestModel>().ReverseMap();
            //CreateMap< ,BillingDataRequestModel>().ReverseMap();

            //// Service
            CreateMap<ServiceResponse, ServiceResponseModel>().ReverseMap();
            CreateMap<ServiceCreate, ServiceRequestModel>().ReverseMap();
            CreateMap<ServiceUpdate, ServiceRequestModel>().ReverseMap();



        }
    }
}
