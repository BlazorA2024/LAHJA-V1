﻿using Application.UseCase.Plans;
using Application.UseCase.Plans.Get;
using Domain.Entities.Plans.Response;
using Domain.Wrapper;
using Infrastructure.Models.Profile.Response;

namespace Application.Services.Plans
{
    public class PlansService
    {
        private readonly GetAllPlansUseCase getAllPlansUseCase;
        private readonly PlanUpdateUseCase planUpdateUseCase;
        private readonly PlanCreateUseCase planCreateUseCase;
        private readonly GetPlansGroupUseCase getPlansGroupUseCase;
        private readonly GetPlanByIdUseCase getPlanByIdUseCase;
        private readonly GetPlanInfoByIdUseCase getPlanInfoByIdUseCase;
        private readonly GetAllPlansContainersUseCase getAllPlansContainersUseCase;
        private readonly GetAllContainersPlansUseCase _getAllContainersPlansUseCase;
        private readonly GetSubscriptionPlansUseCase getSubscriptionPlansUseCase;
        private readonly GetSubscriptionPlanFeaturesUseCase getSubscriptionPlanFeaturesUseCase;
        private readonly GetAllSubscriptionsPlansUseCase getAllSubscriptionsPlansUseCase;
        private readonly GetOneSubscriptionPlanUseCase getOneSubscriptionPlanUseCase;

        public PlansService(
            GetAllPlansUseCase getAllPlansUseCase,
            PlanUpdateUseCase planUpdateUseCase,
            GetPlanByIdUseCase getPlanByIdUseCase,
            GetAllPlansContainersUseCase getAllPlansContainersUseCase,
            GetPlansGroupUseCase getPlansGroupUseCase,
            GetPlanInfoByIdUseCase getPlanInfoByIdUseCase,
            GetAllContainersPlansUseCase getAllContainersPlansUseCase,
            GetSubscriptionPlanFeaturesUseCase getSubscriptionPlanFeaturesUseCase,
            GetSubscriptionPlansUseCase getSubscriptionPlansUseCase,
            GetAllSubscriptionsPlansUseCase getAllSubscriptionsPlansUseCase,
            GetOneSubscriptionPlanUseCase getOneSubscriptionPlanUseCase,
            PlanCreateUseCase planCreateUseCase)
        {

            this.planUpdateUseCase = planUpdateUseCase;
            this.getAllPlansUseCase = getAllPlansUseCase;
            this.getPlanByIdUseCase = getPlanByIdUseCase;
            this.getAllPlansContainersUseCase = getAllPlansContainersUseCase;
            this.getPlansGroupUseCase = getPlansGroupUseCase;
            this.getPlanInfoByIdUseCase = getPlanInfoByIdUseCase;
            this._getAllContainersPlansUseCase = getAllContainersPlansUseCase;
            this.getSubscriptionPlanFeaturesUseCase = getSubscriptionPlanFeaturesUseCase;
            this.getSubscriptionPlansUseCase = getSubscriptionPlansUseCase;
            this.getAllSubscriptionsPlansUseCase = getAllSubscriptionsPlansUseCase;
            this.getOneSubscriptionPlanUseCase = getOneSubscriptionPlanUseCase;
            this.planCreateUseCase = planCreateUseCase;
        }

        public async Task<Result<IEnumerable<PlanResponse>>> getAllPlansAsync()
        {
            return await getAllPlansUseCase.ExecuteAsync();

        }
      


        public async Task<Result<IEnumerable<PlansContainerResponse>>> getAllPlansContainersAsync()
        {
            return await getAllPlansContainersUseCase.ExecuteAsync();

        } 
        
        public async Task<Result<IEnumerable<ContainerPlans>>> getAllContainersPlansUseCase()
        {
            return await _getAllContainersPlansUseCase.ExecuteAsync();

        } 
        public async Task<Result<IEnumerable<PlansGroupResponse>>> getPlansGroupAsync()
        {
            return await getPlansGroupUseCase.ExecuteAsync();

        }
        public async Task<Result<PlanResponse>> planCreateAsync(PlanCreate request)
        {
            return await planCreateUseCase.ExecuteAsync(request);

        }
        public async Task<Result<PlanResponse>> planUpdateAsync(PlanUpdate request)
        {
            return await planUpdateUseCase.ExecuteAsync(request);

        }
        public async Task<Result<IEnumerable<SubscriptionPlan>>> getAllSubscriptionsPlansAsync(int skip = 0, int take = 0)
        {
            return await getAllSubscriptionsPlansUseCase.ExecuteAsync(skip,take);

        }
        public async Task<Result<IEnumerable<SubscriptionPlan>>> getSubscriptionsPlansAsync(string containerId)
        {
            return await getSubscriptionPlansUseCase.ExecuteAsync(containerId);

        }
        public async Task<Result<IEnumerable<PlanFeature>>> getSubscriptionsPlansFeaturesAsync(string planId)
        {
            return await getSubscriptionPlanFeaturesUseCase.ExecuteAsync(planId);

        }
        public async Task<Result<SubscriptionPlan>> getOneSubscriptionPlanAsync(string planId)
        {
            return await getOneSubscriptionPlanUseCase.ExecuteAsync(planId);

        }
        public async Task<Result<PlanResponse>> getPlanByIdAsync(string id)
        {
            return await getPlanByIdUseCase.ExecuteAsync(id);

        }
        public async Task<Result<PlanInfoResponse>> getPlanInfoByIdAsync(string id)
        {
            return await getPlanInfoByIdUseCase.ExecuteAsync(id);

        }
    } 
}
