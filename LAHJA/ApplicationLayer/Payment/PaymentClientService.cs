﻿using Application.Services.Plans;
using AutoMapper;
using Domain.Wrapper;
using LAHJA.Helpers.Services;
using Domain.Entities.Payment.Response;
using Domain.Entities.Payment;
using Domain.Entities.Payment.Request;

namespace LAHJA.ApplicationLayer.Payment
{
    public class PaymentClientService
    {
        private readonly PaymentService paymentService;
        private readonly TokenService tokenService;
        private readonly IMapper _mapper;



        public PaymentClientService(PaymentService paymentService, IMapper mapper, TokenService tokenService)
        {

            this.paymentService = paymentService;
            _mapper = mapper;
            this.tokenService = tokenService;
        }




        public async Task<Result<PaymentCheckoutResponse>> getPaymentCheckOutPage(PaymentCheckoutRequest request)
        {

            var result=await paymentService.getPaymentCheckOut(request);
            return result;

       

        }     
        
        public async Task<Result<PaymentCheckoutResponse>> getPaymentCheckOutManage(SessionCreate request)
        {

            var result=await paymentService.getPaymentCheckOutManage(request);
            return result;

       
        }

    }
}
