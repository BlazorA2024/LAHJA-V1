using AutoMapper;
using Domain.Entities.Payment;
using Domain.Entities.Payment.Response;
using Domain.Wrapper;
using LAHJA.ApplicationLayer.Payment;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LAHJA.Data.UI.Templates.Payment
{

    public class DataBuildPaymentBase {

        public string PlanId  { get; set; }
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; } 
    }


    public interface IBuilderPaymentComponent<T> : IBuilderComponents<T>
    {

        public Func<T, Task> SubmitPaymentCheckOut { get; set; }




    }



    public interface IBuilderPaymentApi<T> : IBuilderApi<T>
    {


        //Task<Result<List<InputCategory>>> OnInitialize();


        Task<Result<PaymentCheckoutResponse>> getPaymentCheckoutUrlAsync(T data);


    }

    public abstract class BuilderPaymentApi<T, E> : BuilderApi<T, E>, IBuilderPaymentApi<E>
    {

        public BuilderPaymentApi(IMapper mapper, T service) : base(mapper, service)
        {

        }

        //public abstract Task<Result<List<InputCategory>>> OnInitialize();

        public abstract Task<Result<PaymentCheckoutResponse>> getPaymentCheckoutUrlAsync(E data);




    }
    public class BuilderPaymentComponent<T> : IBuilderPaymentComponent<T>
    {
        public Func<T, Task> SubmitPaymentCheckOut { get; set; }
    }


    public class TemplatePaymentShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderPaymentApi<E> builderApi;
        private readonly IBuilderPaymentComponent<E> builderComponents;
        public IBuilderPaymentComponent<E> BuilderComponents { get => builderComponents; }
        public TemplatePaymentShare(

               IMapper mapper,
               AuthService AuthService,
                T client,
                IBuilderPaymentComponent<E> builderComponents,
                NavigationManager navigation,
                IDialogService dialogService,
                ISnackbar snackbar


            ) : base(mapper, AuthService, client)
        {



            builderComponents = new BuilderPaymentComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;


        }

    }

     
    public class BuilderPaymentApiClient : BuilderPaymentApi<PaymentClientService, DataBuildPaymentBase>, IBuilderPaymentApi<DataBuildPaymentBase>
    {
        public BuilderPaymentApiClient(IMapper mapper, PaymentClientService service) : base(mapper, service)
        {
        }


        public override async Task<Result<PaymentCheckoutResponse>> getPaymentCheckoutUrlAsync(DataBuildPaymentBase data)
        {

            var model = Mapper.Map<PaymentCheckoutRequest>(data);
            var res = await Service.getPaymentCheckOutPage(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<PaymentCheckoutResponse>(res.Data);
                    return Result<PaymentCheckoutResponse>.Success(map);

                }
                catch (Exception e)
                {
                    return Result<PaymentCheckoutResponse>.Fail();
                }
            }
            else
            {
                return Result<PaymentCheckoutResponse>.Fail(res.Messages);
            }
        }
    }


    public class TemplatePayment : TemplatePaymentShare<PaymentClientService, DataBuildPaymentBase>
    {

   
        public List<string> Errors { get => _errors; }

   


        public TemplatePayment(
            IMapper mapper,
            AuthService AuthService,
            PaymentClientService client,
            IBuilderPaymentComponent<DataBuildPaymentBase> builderComponents,
            NavigationManager navigation,
            IDialogService dialogService,
            ISnackbar snackbar) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.SubmitPaymentCheckOut = onSubmitPaymentCheckOut;
       

            this.builderApi = new BuilderPaymentApiClient(mapper, client);

            //Task.FromResult(OnInitialize());

        }



        public async Task onSubmitPaymentCheckOut(DataBuildPaymentBase data) {
            
            data.SuccessUrl = $"{navigation.BaseUri}settings";
            data.CancelUrl = $"{navigation.BaseUri}settings/billing";
			var res=await  builderApi.getPaymentCheckoutUrlAsync(data);
            if (res.Succeeded && res.Data!=null && !string.IsNullOrEmpty(res.Data.url)) {
                navigation.NavigateTo(res.Data.url,true);
            }
            else
            {
                Snackbar.Add("Field Option ! Please try anther once or again login ", Severity.Error);
            }

        } 

        public async Task<Result<PaymentCheckoutResponse>> getPaymentCheckoutUrlPage(DataBuildPaymentBase DataBuildPaymentBase)
        {
      
               return await builderApi.getPaymentCheckoutUrlAsync(DataBuildPaymentBase);

        }

   


    }

}
