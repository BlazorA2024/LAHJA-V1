using AutoMapper;
using Domain;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Models.BaseFolder.Response;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.ApiClient.Plans
{
    using System.Collections.Generic;

    public class Service
    {
        public string ServiceId { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public int NumberRequests { get; set; }
        public string Processor { get; set; }
        public string ConnectionType { get; set; }
    }

    public class Plan
    {
        public string ProductId { get; set; }
        public string BillingPeriod { get; set; }
        public decimal Amount { get; set; }
        public bool Active { get; set; }
        public List<Service> Services { get; set; }
    }

    public class Product
    {
        public string ProductName { get; set; }
        public List<Plan> Plans { get; set; }
    }




    public class PlansApiClient
    {


        private readonly ClientFactory _clientFactory;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public PlansApiClient(
            ClientFactory clientFactory, 
            IMapper mapper, 
            IConfiguration config)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
            _config = config;
        }



        private async Task<PlansClient> GetApiClient()
        {

            var client = await _clientFactory.CreateClientWithAuthAsync<PlansClient>("ApiClient");
            return client;
        }
         async Task<IEnumerable<Product>> Main()
        {
            string url = "https://asg.tryasp.net/api/Plans/Group";
            string token = "CfDJ8ILMRnV4v7xFu3bH5i6L83k9g7J5a2A-qYqkBGGUP7wnkOqZA1XLZpil7BK99AkAQTrSfC8iIlZLV4UTRsqjLkBHqAPgYACMHkztZz7f5yIxOMXZC1KMTN58t_WG9u8lVEEZxHIRDRK6nbu3xsj3OFhBLmFcREq0TseLqPD4mz1HWtRRNUdtfr4-Dgpk2zmwtzXLjasZduxkwSjogPQ5bqYH6hSGIEz2I7zJseUQAlZVUOg5bdn2khkJse5RsbXBOb0Rr_H9WjwfyoX1CfV4Fd1JOywA4eriWUmCPR6K8SxJ2QlaH_kGVURcj23YyMVxB7vM7ugE0HaNRU6faELEWWzDVgefC57MiJ2qSyUNuLCPoq2LhFgzy6VDkjaKWJeywwExXe4BvZbG1vLPCcJRvZ6HyDe-qMlGdlm3_mqv7_oLbVHndDdORqC3FX9a3_Fz4MN3u2gTyN-oQxs8rk6vInRkmHrQIv7scsBxVxNY1GecQmpjUKf09Lr5CK9FzmT2OcYEQmZTPTHELCAkwJEJ_4OEOyxh_-fpW4xtKn38ZkXqI9c4dXcIycDRvkMI6eFL724yqwJl3IxLPX_nDdzMcgA5ufEYJox9mIIt2BbuUir1CGNWmskiNGxfTWBwByfqJ9FG4gZmhw3wQdUlZUxJ884MOWj51pYXDstTWtFYtilxFpSfS1mJ1iGDRSQKm6DQpA1rTBZhLj7bxyem5RxMDY2c9_NCuFOFRlULwpR5nXEoxsmdq2K50SXPxEF7NZTt-I7HZVWt1BhfEcAPKO9tAjD9O0tycYV2ctQ3tuFPza7tcw6UlgoDJaS8YKq2K2TB9wZlFZAUazgpKFQzoKjmn1yNl8rO3Wwm-6DSXZPRp1JR";

            using (HttpClient client = new HttpClient())
            {
                // إعداد الترويسة Authorization
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    // إرسال الطلب
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Request successful!");
                        string responseData = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseData);

                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseData);
                        return products;

                        //// طباعة البيانات
                        //foreach (var product in products)
                        //{
                        //    Console.WriteLine($"Product Name: {product.ProductName}");
                        //    foreach (var plan in product.Plans)
                        //    {
                        //        Console.WriteLine($"  Plan ID: {plan.ProductId}, Billing Period: {plan.BillingPeriod}, Amount: {plan.Amount}");
                        //        foreach (var service in plan.Services)
                        //        {
                        //            Console.WriteLine($"    Service: {service.Name}, Processor: {service.Processor}, Requests: {service.NumberRequests}");
                        //        }
                        //    }
                        //}

                    }
                    else
                    {
                        Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                return null;
            }
        }
    
    public async Task<Result<IEnumerable<ContainerPlansModel>>> getAllContainersPlansAsync(int skip = 0, int take = 0)
        {
            try
            {

                var client = await GetApiClient();
                var response = await client.GetPlansAsync();

                var resModel = _mapper.Map<List<ContainerPlansModel>>(response);
                return Result<IEnumerable<ContainerPlansModel>>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<IEnumerable<ContainerPlansModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }
        public async Task<Result<IEnumerable<PlanResponseModel>>> getAllPlansAsync()
        {
            try
            {

                var client = await GetApiClient();
                var response = await client.GetPlansAsync();


                var resModel = _mapper.Map<IEnumerable<PlanResponseModel>>(response);
                return Result<IEnumerable<PlanResponseModel>>.Success();

            }
            catch (ApiException e)
            {

                return Result<IEnumerable<PlanResponseModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

        public async Task<Result<PlanResponseModel>> createPlanAsync(PlanCreateModel request)
        {
            try
            {
                var model = _mapper.Map<PlanCreate>(request);
                var client = await GetApiClient();
                var response = await client.CreatePlanAsync(model);


                var resModel = _mapper.Map<PlanResponseModel>(response);
                return Result<PlanResponseModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<PlanResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }    
        
        public async Task<Result<PlanResponseModel>> updatePlanAsync(PlanUpdateModel request)
        {
            try
            {
                var model = _mapper.Map<PlanUpdate>(request);
                var client = await GetApiClient();
                var response = await client.UpdatePlanAsync(request.Id,model);


                var resModel = _mapper.Map<PlanResponseModel>(response);
                return Result<PlanResponseModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<PlanResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        } 
        public async Task<Result<DeleteResponseModel>> DeletePlanAsync(string id)
        {
            try
            {
              
                var client = await GetApiClient();
                var response = await client.DeletePlanAsync(id);


                var resModel = _mapper.Map<DeleteResponseModel>(response);
                return Result<DeleteResponseModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<DeleteResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }
        public async Task<Result<IEnumerable<PlansGroupModel>>> getPlansGroupAsync(int skip=0,int take=0)
        {
            try
            {

                var client = await GetApiClient();
                var response =  await client.AsGroupAsync();


                var resModel = _mapper.Map<IEnumerable<PlansGroupModel>>(response);
                return Result<IEnumerable<PlansGroupModel>>.Success();

            }
            catch (ApiException e)
            {

                return Result<IEnumerable<PlansGroupModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

 
        
        public async Task<Result<IEnumerable<SubscriptionPlanModel>>> getAllSubscriptionsPlansAsync(int skip = 0, int take = 0)
        {
            try
            {

                var client = await GetApiClient();
                var response = await client.GetPlansAsync();
                if(response == null)
                    return Result<IEnumerable<SubscriptionPlanModel>>.Success();


                var resModel = _mapper.Map<IEnumerable<SubscriptionPlanModel>>(response);
                return Result<IEnumerable<SubscriptionPlanModel>>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<IEnumerable<SubscriptionPlanModel>>.Fail(e.Response,httpCode:e.StatusCode);

            }



        }

        public async Task<Result<PlanResponseModel>> getPlanByIdAsync(string id)
        {
            try
            {

                var client = await GetApiClient();
                var response = await client.GetPlanAsync(id);
                var resModel = _mapper.Map<PlanResponseModel>(response);
                return Result<PlanResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<PlanResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }
    }
}
