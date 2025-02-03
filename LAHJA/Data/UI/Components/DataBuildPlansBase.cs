using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LAHJA.Data.UI.Components
{

	public class DataBuildUserSubscriptionInfo
	{
		public string Id { get; set; }
		public string BillingPeriod { get; set; }
		public DateTime StartDate { get; set; }
		public string Status { get; set; }
		public bool CancelAtPeriodEnd { get; set; }
		public string ProductName { get; set; }
		public int NumberRequests { get; set; }
		public decimal Amount { get; set; }
		public bool Active { get; set; }
		public string Description { get; set; }
		public DateTime UpdatedAt { get; set; }
		public DateTime CreatedAt { get; set; }
	}
	public class DataBuildPlansBase
        {
            public string CategoryId { get; set; }
            public string PlanId { get; set; }
        }

    public  class CardStateCount<T>
    {

        public T Value { get; set; }

        public string Label { get; set; } = "Label";
        public string Class { get; set; }= "";


    }



    public  class CardActionTabel
    {
        public string Name { set; get; } = "Name";
        public string? Tag { set; get; }

        public string? Icon { set; get; }


          
        public bool IsMudChip { set; get; }=true;
        

        public Color Color { set; get; } = Color.Default;


    }

    public  class GroupActionTabels
    {

        public List<CardActionTabel>? Actions { get;set; }
        public Func<CardActionTabel, Task>? ChipClicked { get; set; }

    }
    public class DataBuildSpace
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Ram { get; set; }
        public int CpuCores { get; set; }
        public int DiskSpace { get; set; }
        public bool IsGpu { get; set; }
        public bool IsGlobal { get; set; }
        public int Bandwidth { get; set; }
    }
    public class PlanCreateStartData
    {
        public string Label { set; get; } = "create";

        public string Description { get; set; }= "Features are monetizable capabilities that can be linked to products, granting purchasing customers an entitlement to the feature through Stripe.";

        public string Titel { set; get; } = "Start by adding a feature";
    }

    public  class HandleCallback<T, E>
    {

        public static Func<T,E> Delegate(Func<T, E> func)
        {

            return func;
        }
    }

     public  class EventBuildTabelCard<T>
    {
        public EventCallback<T> OnRowClicked { get; set; }
        public EventCallback<HashSet<T>> OnSelectedItemsChanged { get; set; }
        public EventCallback<string> OnSearch { get; set; }
        public EventCallback<SortDirection> OnSortChanged { get; set; }
        public EventCallback<int> OnPageChanged { get; set; }
        public Func<T, int, string>? OnRowRender { get; set; }
    }
    public  class DataAndEventBuildTabelCard<T>
    {
         public List<T> DataBuild { get; set; } = new();
       public bool FixedHeader { get; set; } = true;
       public bool MultiSelection { get; set; } = false;

        // الأحداث كـ Parameters
        public  EventBuildTabelCard<T>? Events { set; get; }
        public List<string> LabelColumns { get; set; } = new();
    }

}
