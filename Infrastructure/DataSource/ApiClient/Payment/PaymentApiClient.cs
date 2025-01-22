using AutoMapper;
using Domain.Entities.Payment;
using Domain.Entities.Payment.Response;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Models.Payment.Request;
using Infrastructure.Models.Payment.Response;
using Infrastructure.Models.Plans;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClient.Billing;

namespace Infrastructure.DataSource.ApiClient.Payment
{
    public class PaymentApiClient : BuildApiClient<CheckoutClient>
    {




        public PaymentApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config) : base(clientFactory, mapper, config)
        {
        }

        private async Task<CheckoutClient> GetApiClient(string token="")
        {

            var client = await _clientFactory.CreateClientWithAuthAsync<CheckoutClient>("ApiClient", token);
            return client;
        }
        //async Task<CheckoutResponse> Main(PaymentCheckoutRequestModel request)
        //{


        //    string url = "https://asg.tryasp.net/api/Plans/Group";
        //    string token = "CfDJ8ILMRnV4v7xFu3bH5i6L83k9g7J5a2A-qYqkBGGUP7wnkOqZA1XLZpil7BK99AkAQTrSfC8iIlZLV4UTRsqjLkBHqAPgYACMHkztZz7f5yIxOMXZC1KMTN58t_WG9u8lVEEZxHIRDRK6nbu3xsj3OFhBLmFcREq0TseLqPD4mz1HWtRRNUdtfr4-Dgpk2zmwtzXLjasZduxkwSjogPQ5bqYH6hSGIEz2I7zJseUQAlZVUOg5bdn2khkJse5RsbXBOb0Rr_H9WjwfyoX1CfV4Fd1JOywA4eriWUmCPR6K8SxJ2QlaH_kGVURcj23YyMVxB7vM7ugE0HaNRU6faELEWWzDVgefC57MiJ2qSyUNuLCPoq2LhFgzy6VDkjaKWJeywwExXe4BvZbG1vLPCcJRvZ6HyDe-qMlGdlm3_mqv7_oLbVHndDdORqC3FX9a3_Fz4MN3u2gTyN-oQxs8rk6vInRkmHrQIv7scsBxVxNY1GecQmpjUKf09Lr5CK9FzmT2OcYEQmZTPTHELCAkwJEJ_4OEOyxh_-fpW4xtKn38ZkXqI9c4dXcIycDRvkMI6eFL724yqwJl3IxLPX_nDdzMcgA5ufEYJox9mIIt2BbuUir1CGNWmskiNGxfTWBwByfqJ9FG4gZmhw3wQdUlZUxJ884MOWj51pYXDstTWtFYtilxFpSfS1mJ1iGDRSQKm6DQpA1rTBZhLj7bxyem5RxMDY2c9_NCuFOFRlULwpR5nXEoxsmdq2K50SXPxEF7NZTt-I7HZVWt1BhfEcAPKO9tAjD9O0tycYV2ctQ3tuFPza7tcw6UlgoDJaS8YKq2K2TB9wZlFZAUazgpKFQzoKjmn1yNl8rO3Wwm-6DSXZPRp1JR";

        //    using (HttpClient client = new HttpClient())
        //    {
        //        // إعداد الترويسة Authorization
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        //        try
        //        {

        //            string jsonData = JsonSerializer.Serialize(TextWriter., body);

        //            // إنشاء محتوى الطلب
        //            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //            // إرسال الطلب
        //            HttpResponseMessage response = await client.PostAsAsync(url);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                Console.WriteLine("Request successful!");
        //                string responseData = await response.Content.ReadAsStringAsync();
        //                Console.WriteLine(responseData);

        //                CheckoutResponse products = JsonConvert.DeserializeObject<CheckoutResponse>(responseData);
        //                return products;

                   

        //            }
        //            else
        //            {
        //                Console.WriteLine($"Request failed with status code: {response.StatusCode}");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"An error occurred: {ex.Message}");
        //        }

        //        return null;
        //    }
        //}
        public async Task<Result<PaymentCheckoutResponseModel>> getPaymentCheckOut(PaymentCheckoutRequestModel request,string token="")
        {
            try
            {
                var model = _mapper.Map<CheckoutOptions>(request);
                var client = await GetApiClient(token);
				var response = await client.CreateCheckoutAsync(model);
                //var response = await Main(model);


                var resModel = _mapper.Map<PaymentCheckoutResponseModel>(response);
                return Result<PaymentCheckoutResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<PaymentCheckoutResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }


        public async Task<Result<PaymentCheckoutResponseModel>> getPaymentCheckOutManage(SessionCreateModel request)
        {
            try
            {
                var model = _mapper.Map<SessionCreate>(request);
                var client = await GetApiClient();
                var response = await client.ManageAsync(model);


                var resModel = _mapper.Map<PaymentCheckoutResponseModel>(response);
                return Result<PaymentCheckoutResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<PaymentCheckoutResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

    }
}
