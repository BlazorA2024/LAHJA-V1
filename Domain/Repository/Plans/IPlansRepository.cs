﻿using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Plans
{
    public interface IPlansRepository
    {
        public Task<Result<IEnumerable<PlanResponse>>> getAllPlansAsync();
        public Task<Result<PlanResponse>> getPlanByIdAsync(string id);
        public Task<Result<PlanInfoResponse>> GetPlanInfoByIdAsync(string id);
        public Task<Result<IEnumerable<PlansContainerResponse>>> getAllPlansContainerAsync();
        public Task<Result<IEnumerable<SubscriptionPlan>>> getSubscriptionsPlansAsync(string containerId);
        public Task<Result<IEnumerable<SubscriptionPlan>>> getAllSubscriptionsPlansAsync(int skip = 0, int take = 0);
        public Task<Result<IEnumerable<PlanFeature>>> getSubscriptionsPlansFeaturesAsync(string planId);
        public Task<Result<SubscriptionPlan>> getOneSubscriptionsPlanAsync(string planId);
        public Task<Result<IEnumerable<ContainerPlans>>> getAllContainersPlansAsync();
        public Task<Result<IEnumerable<PlansGroupResponse>>> getPlansGroupAsync();
        public Task<Result<PlanResponse>> createPlanAsync(PlanCreate request);
        public Task<Result<PlanResponse>> updatePlanAsync(PlanUpdate request);
        Task<Result<IEnumerable<SubscriptionPlan>>> getBasicSubscriptionsPlansAsync();


    }
}
