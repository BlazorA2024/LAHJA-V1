
using AutoMapper;
using Domain.Entities.Payment;
using Domain.Entities.Payment.Request;
using Domain.Entities.Payment.Response;
using Domain.Repository.Payment;
using Domain.Wrapper;
using Infrastructure.DataSource;
using Infrastructure.DataSource.ApiClient.Payment;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Payment.Request;
using Infrastructure.Models.Payment.Response;
using Infrastructure.Models.Plans;
using Shared.Helpers;
using Shared.Settings;

namespace Infrastructure.Repository.Plans
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly PaymentApiClient paymentApiClient;
        private readonly AuthControl authControl;
		private readonly ITokenService tokenService;
		private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
		public PaymentRepository(
			IMapper mapper,
			SeedsPlans seedsPlans,
			ApplicationModeService appModeService,
			PaymentApiClient paymentApiClient,
			AuthControl authControl,
			ITokenService tokenService)
		{

			//seedsPlans = new SeedsPlans();
			_mapper = mapper;
			this.seedsPlans = seedsPlans;
			this.appModeService = appModeService;

			this.paymentApiClient = paymentApiClient;
			this.authControl = authControl;
			this.tokenService = tokenService;
		}



		public async Task<Result<PaymentCheckoutResponse>> getPaymentCheckoutPage(PaymentCheckoutRequest request)
        {
            var model = _mapper.Map<PaymentCheckoutRequestModel>(request);
			var response = await ExecutorAppMode.ExecuteAsync<Result<PaymentCheckoutResponseModel>>(
				 async () => await paymentApiClient.getPaymentCheckOut(model),
				  async () => await paymentApiClient.getPaymentCheckOut(model));

			if (response.Succeeded)
			{
				var result = (response.Data != null) ? _mapper.Map<PaymentCheckoutResponse>(response.Data) : null;
				return Result<PaymentCheckoutResponse>.Success(result);
			}
			else
			{
				return Result<PaymentCheckoutResponse>.Fail(response.Messages);
			}

			//             {


			//var token=  await tokenService.GetTempTokenAsync();
			//                 if (!string.IsNullOrEmpty(token))
			//                 {
			//	  return await paymentApiClient.getPaymentCheckOut(model);
			//  }
			//                 else
			//                 {
			//                     var res = await authControl.loginAsync(new LoginRequestModel
			//                     {
			//                         email = "azzaldeen771211417@gmail.com",
			//                         password = "Test@123"
			//                     });

			//                     if (res.Succeeded)
			//                     {
			//                         if (!string.IsNullOrEmpty(res.Data.accessToken))
			//                         {
			//			  await tokenService.SaveTempTokenAsync(res.Data.accessToken);
			//			  return await paymentApiClient.getPaymentCheckOut(model, res.Data.accessToken);
			//                         }
			//                     }
			//                 }

			//  return Result<PaymentCheckoutResponseModel>.Fail("Error");


			//});





		}

        public async Task<Result<PaymentCheckoutResponse>> getPaymentCheckOutManage(SessionCreate request)
        {

            {
                var model = _mapper.Map<SessionCreateModel>(request);
                var response = await ExecutorAppMode.ExecuteAsync<Result<PaymentCheckoutResponseModel>>(
                     async () => await paymentApiClient.getPaymentCheckOutManage(model),
                      async () => Result<PaymentCheckoutResponseModel>.Success());

                if (response.Succeeded)
                {
                    var result = (response.Data != null) ? _mapper.Map<PaymentCheckoutResponse>(response.Data) : null;
                    return Result<PaymentCheckoutResponse>.Success(result);
                }
                else
                {
                    return Result<PaymentCheckoutResponse>.Fail(response.Messages);
                }
            }



        }
   



    } 
}
