using Microsoft.AspNetCore.Components;
using SkullJocks.BenAdmin.App.Contracts;
using SkullJocks.BenAdmin.App.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.App.Pages
{
    public partial class CustomerOverview
    {
        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public HttpClient HttpClient { get; set; }

        public ICollection<CustomerListVm> Customers { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Customers = await CustomerDataService.GetAllCustomers();
        }

        protected void AddNewCustomer()
        {
            NavigationManager.NavigateTo("/customerdetails");
        }
    }
}
