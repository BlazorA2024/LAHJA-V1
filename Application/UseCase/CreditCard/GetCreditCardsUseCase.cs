using Application.UseCase.Plans;
using Application.UseCase.Plans.Get;
using Domain;
using Domain.Entities.Billing.Response;
using Domain.Entities.Payment;
using Domain.Entities.Payment.Request;
using Domain.Entities.Payment.Response;
using Domain.Entities.Plans.Response;
using Domain.Repository.Billing;
using Domain.Repository.CreditCard;
using Domain.Repository.Payment;
using Domain.ShareData.Base;
using Domain.Wrapper;
using Infrastructure.Models.Profile.Response;

namespace Application.Services.Plans
{
    public class GetCreditCardsUseCase
    {

        private readonly ICreditCardRepository repository;
        public GetCreditCardsUseCase(ICreditCardRepository repository)
        {

            this.repository = repository;
        }
    

        public async Task<Result<List<CardDetailsResponse>>> ExecuteAsync()
        {

            return await repository.GetAllAsync();

        }


    }



}