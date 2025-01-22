﻿using Application.Services.Plans;
using AutoMapper;
using Domain.Wrapper;
using LAHJA.Helpers.Services;
using Domain.Entities.Plans.Response;

namespace LAHJA.ApplicationLayer.Plans
{
    public class PlansClientService
    {
        private readonly PlansService plansService;




        public PlansClientService(PlansService plansService)
        {

            this.plansService = plansService;

        }

        public async Task<Result<PlanResponse>> planCreateAsync(PlanCreate request)
        {
            return await plansService.planCreateAsync(request);

        }
        public async Task<Result<PlanResponse>> planUpdateAsync(PlanUpdate request)
        {
            return await plansService.planUpdateAsync(request);

        }

        /// <summary>
        /// New Methods
        /// </summary>
        /// <returns></returns>
        public async Task<Result<IEnumerable<ContainerPlans>>> getAllContainersAsync()
        {


            var result=await plansService.getAllContainersPlansUseCase();

            return result;

            //if (result.Succeeded)
            //{
            //    var res = result.Data.ToList();
            //    var data = _mapper.Map<List<InputCategory>>(res);


            //    //var result2 = await plansService.getSubscriptionsPlansAsync("1");
            //    //var result3 = await plansService.getSubscriptionsPlansFeaturesAsync("1");
            //    //int i = 0;
            //    //foreach (var item in data)
            //    //{
            //    //    //item.TechnicalServices = _mapper.Map<List<PlanTechnicalServiceResponse>>(res[i].SubscriptionFeatures);
            //    //    //item.QuantitativeFeatures = _mapper.Map<List<PlanQuantitativeFeatureResponse>>(res[i++].TechnicalFeatures);
            //    //}

            //    //var dataList = _mapper.Map<List<ContainerPlans>>(data);
            //    //i = 0;
            //    //foreach (var item in dataList)
            //    //{
            //    //    item.TechnologyServices = _mapper.Map<List<TechnologyService>>(data[i].TechnicalServices);
            //    //    foreach (var itm in item.TechnologyServices)
            //    //        itm.TechnicalServices = new List<TechnicalService>
            //    //        {
            //    //            new TechnicalService { Id = $"TS{new Random().Next(999999)}", Name = "Random Tech", Price = (decimal)(new Random().NextDouble() * 1000), Status = "Active" }
            //    //        };

            //    //    item.ServiceDetailsList = _mapper.Map<List<DigitalService>>(data[i++].QuantitativeFeatures);
            //    //}


            //    return Result<List<InputCategory>>.Success(data);
            //}
            //else
            //{
            //    return Result<List<InputCategory>>.Fail();
            //}

        }
        public async Task<Result<IEnumerable<SubscriptionPlan>>> getSubscriptionsPlansAsync(string containerId)
        {
            var result = await plansService.getSubscriptionsPlansAsync(containerId);

            return result;
    

        }

        public async Task<Result<IEnumerable<PlanFeature>>> getSubscriptionPlanFeaturesAsync(string planId)
        {
            var result = await plansService.getSubscriptionsPlansFeaturesAsync(planId);

            return result;
     

        }
        public async Task<Result<SubscriptionPlan>> getOneSubscriptionPlanAsync(string planId)
        {
            var result = await plansService.getOneSubscriptionPlanAsync(planId);
            return result;


        }
        public async Task<Result<IEnumerable<SubscriptionPlan>>> getAllSubscriptionPlansAsync(int skip = 0, int take = 0)
        {
            var result = await plansService.getAllSubscriptionsPlansAsync(skip, take);

            return result;

        }

        //public async Task<Result<List<PlanInfo>>> getAllPlansInfoAsync()
        //{

        //    var result = await plansService.getPlansGroupAsync();

        //    if (result.Succeeded)
        //    {
        //        var res = result.Data.ToList();
        //        var data = _mapper.Map<List<PlanInfoResponse>>(res);
        //        int i = 0;
        //        foreach (var item in data)
        //        {
        //            item.TechnicalServices = _mapper.Map<List<PlanTechnicalServiceResponse>>(res[i].SubscriptionFeatures);
        //            item.QuantitativeFeatures = _mapper.Map<List<PlanQuantitativeFeatureResponse>>(res[i++].TechnicalFeatures);
        //        }

        //        var dataList = _mapper.Map<List<PlanInfo>>(data);
        //        i = 0;
        //        foreach (var item in dataList)
        //        {
        //            item.TechnologyServices = _mapper.Map<List<TechnologyService>>(data[i].TechnicalServices);
        //            foreach (var itm in item.TechnologyServices)
        //                itm.TechnicalServices = new List<TechnicalService>
        //                {
        //                    new TechnicalService { Id = $"TS{new Random().Next(999999)}", Name = "Random Tech", Price = (decimal)(new Random().NextDouble() * 1000), Status = "Active" }
        //                };

        //            item.ServiceDetailsList = _mapper.Map<List<DigitalService>>(data[i++].QuantitativeFeatures);
        //        }


        //        return Result<List<PlanInfo>>.Success(dataList);
        //    }
        //    else
        //    {
        //        return Result<List<PlanInfo>>.Fail();
        //    }

        //}
        //public async Task<Result<List<PlansFeture>>> getPlansGroupAsync()
        //{

        //    var result = await plansService.getPlansGroupAsync();

        //    if (result.Succeeded)
        //    {
        //        var res = result.Data.ToList();
        //        var data = _mapper.Map<List<PlansFeture>>(res);
        //        int i = 0;
        //        foreach (var item in data)
        //        {
        //            item.Services = _mapper.Map<List<Service>>(res[i].SubscriptionFeatures);
        //            item.numberOfServices = _mapper.Map<List<NumberOfService>>(res[i++].TechnicalFeatures);
        //        }


        //        return Result<List<PlansFeture>>.Success(data);
        //    }
        //    else
        //    {
        //        return Result<List<PlansFeture>>.Fail();
        //    }

        //}

        //public async Task<Result<List<InputCategory>>> getAllPlansContainersAsync2()
        //{
        //    var result = await plansService.getAllPlansContainersAsync();


        //    if (result.Succeeded)
        //    {
        //        var data = _mapper.Map<List<InputCategory>>(result.Data.ToList());
        //        return Result<List<InputCategory>>.Success(data);
        //    }
        //    else
        //    {
        //        return Result<List<InputCategory>>.Fail();
        //    }

        //}


        //public async Task<Result<PlanInfo>> getPlanInfoByIdAsync(string id)
        //{
        //    var item= await plansService.getPlanInfoByIdAsync(id);
        //    if (item.Succeeded)
        //    {
        //        var res= _mapper.Map<PlanInfo>(item);
        //        return Result<PlanInfo>.Success(res);
        //    }
        //    else
        //    {
        //        return Result<PlanInfo>.Fail();
        //    }



        //}
    }
}
