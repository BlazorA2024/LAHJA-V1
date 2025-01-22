using Application.Services.Auth;
using Application.Services.Plans;
using Application.Services.Profile;
using Application.Services.Prroduct;
using Application.Services.Service;
using Application.Services.Subscriptions;
using Application.UseCase;
using Application.UseCase.Auth;
using Application.UseCase.Plans;
using Application.UseCase.Plans.Get;
using Application.UseCase.Request;
using Application.UseCase.Service;
using Infrastructure.DataSource.ApiClient.Plans;
using Infrastructure.Mappings.Plans;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ApplicationConfigServices
    {
        public static void InstallApplicationConfigServices(this IServiceCollection serviceCollection)
        {

            InstallMapping(serviceCollection);
            InstallUsaCases(serviceCollection);
            InstallServices(serviceCollection);

        }


       private static  void InstallMapping(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationMappingConfig));
        }

        private static void InstallUsaCases(this IServiceCollection serviceCollection)
        {
            /// Auth
            serviceCollection.AddScoped<LoginUseCase>();
            serviceCollection.AddScoped<RegisterUseCase>();
            serviceCollection.AddScoped<ForgetPasswordUseCase>();
            serviceCollection.AddScoped<ResetPasswordUseCase>();
            serviceCollection.AddScoped<ConfirmationEmailUseCase>();
            serviceCollection.AddScoped<ReSendConfirmationEmailUseCase>();
            serviceCollection.AddScoped<RefreshTokinUseCase>();
            serviceCollection.AddScoped<LogoutUseCase>();

            /// Plans
            serviceCollection.AddScoped<GetAllContainersPlansUseCase>();
            serviceCollection.AddScoped<GetPlansGroupUseCase>();
            serviceCollection.AddScoped<GetAllPlansUseCase>();
            serviceCollection.AddScoped<PlanUpdateUseCase>();
            serviceCollection.AddScoped<PlanCreateUseCase>();
            serviceCollection.AddScoped<GetPlanByIdUseCase>();
            serviceCollection.AddScoped<GetPlanInfoByIdUseCase>();
            serviceCollection.AddScoped<GetAllPlansContainersUseCase>();
            serviceCollection.AddScoped<GetSubscriptionPlansUseCase>();
            serviceCollection.AddScoped<GetOneSubscriptionPlanUseCase>();
            serviceCollection.AddScoped<GetSubscriptionPlanFeaturesUseCase>();
            serviceCollection.AddScoped<GetAllSubscriptionsPlansUseCase>();
         


            /// Profile
            serviceCollection.AddScoped<GetProfileUseCase>();
            serviceCollection.AddScoped<CreateProfileUseCase>();
            serviceCollection.AddScoped<UpdateProfileUseCase>();
            serviceCollection.AddScoped<DeleteProfileUseCase>();


            /// Payment
            serviceCollection.AddScoped<GetPaymentCheckOutUseCase>();
            serviceCollection.AddScoped<GetPaymentCheckOutManageUseCase>();

               
            /// Price
            serviceCollection.AddScoped<SearchPriceUseCase>();
            serviceCollection.AddScoped<DeletePriceUseCase>();
            serviceCollection.AddScoped<CreatePriceUseCase>();
            serviceCollection.AddScoped<UpdatePriceUseCase>();


            /// Product
            serviceCollection.AddScoped<CreateProductUseCase>();
            serviceCollection.AddScoped<UpdateProductUseCase>();
            serviceCollection.AddScoped<DeleteProductUseCase>();
            serviceCollection.AddScoped<GetAllProductsUseCase>();
            serviceCollection.AddScoped<SearchProductUseCase>();




            /// Settings
            //serviceCollection.AddScoped<SearchPriceUseCase>();


            /// Subscription
            serviceCollection.AddScoped<HasActiveSubscriptionUseCase>();
            serviceCollection.AddScoped<PauseSubscriptionUseCase>();
            serviceCollection.AddScoped<DeleteSubscriptionUseCase>();
            serviceCollection.AddScoped<ResumeSubscriptionUseCase>();
            serviceCollection.AddScoped<GetAllSubscriptionsUseCase>();
            serviceCollection.AddScoped<CreateSubscriptionUseCase>();
            serviceCollection.AddScoped<UpdateSubscriptionUseCase>();

            //// Credit Card
            serviceCollection.AddScoped<ActiveCreditCardUseCase>();
            serviceCollection.AddScoped<GetCreditCardsUseCase>();
            serviceCollection.AddScoped<CreateCreditCardUseCase>();
            serviceCollection.AddScoped<UpdateCreditCardUseCase>();
            serviceCollection.AddScoped<DeleteCreditCardUseCase>();

            //// Billing
            serviceCollection.AddScoped<GetBillingDetailsUseCase>();
            serviceCollection.AddScoped<CreateBillingDetailsUseCase>();
            serviceCollection.AddScoped<UpdateBillingDetailsUseCase>();
            serviceCollection.AddScoped<DeleteBillingDetailsUseCase>();

            // Services
            serviceCollection.AddScoped<GetAllServicesUseCase>();
            serviceCollection.AddScoped<GetServiceByIdUseCase>();
            serviceCollection.AddScoped<CreateServiceUseCase>();
            serviceCollection.AddScoped<UpdateServiceUseCase>();
            serviceCollection.AddScoped<DeleteServiceUseCase>();

            // Request
            serviceCollection.AddScoped<CreateRequestUseCase>();
            serviceCollection.AddScoped<RequestAllowedUseCase>();
            serviceCollection.AddScoped<CreateEventUseCase>();
            serviceCollection.AddScoped<ResultRequestUseCase>();

        }

        private static void InstallServices(this IServiceCollection serviceCollection)
        {
           
            serviceCollection.AddScoped<PlansService>();
            serviceCollection.AddScoped<WebAuthService>();
            serviceCollection.AddScoped<ProfileService>();
            serviceCollection.AddScoped<PaymentService>();
            serviceCollection.AddScoped<PriceService>();
            serviceCollection.AddScoped<ProductService>();
            serviceCollection.AddScoped<SubscriptionService>();
            serviceCollection.AddScoped<BillingService>();
            serviceCollection.AddScoped<CreditCardService>();
            serviceCollection.AddScoped<LAHJAService>();
            serviceCollection.AddScoped<RequestService>();

        }

    }
}
