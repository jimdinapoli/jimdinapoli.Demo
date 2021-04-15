using Microsoft.AspNetCore.Components;
using SkullJocks.BenAdmin.App.Contracts;
using SkullJocks.BenAdmin.App.Services.Base;
using SkullJocks.BenAdmin.App.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.App.Pages
{
    public partial class CustomerEdit
    {
        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }

        [Inject]
        public ICustomerTypeDataService CustomerTypeDataService { get; set; }

        [Parameter]
        public string CustomerId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CustomerDetailVm CustomerDetailVm { get; set; } = new CustomerDetailVm();

        public ObservableCollection<CustomerTypeVm> CustomerTypes{ get; set; }
            = new ObservableCollection<CustomerTypeVm>();

        private Guid SelectedCustomerId = Guid.Empty;
        public string SelectedCustomerTypeId { get; set; }

        protected string Message = string.Empty;


        protected override async Task OnInitializedAsync()
        {
            var list = await CustomerTypeDataService.GetAllCustomerTypes();
            CustomerTypes = new ObservableCollection<CustomerTypeVm>(list);
            SelectedCustomerTypeId = CustomerTypes.FirstOrDefault().CustomerTypeId.ToString();

            if (Guid.TryParse(CustomerId, out SelectedCustomerId))
            {
                CustomerDetailVm = await CustomerDataService.GetCustomerById(SelectedCustomerId);
                SelectedCustomerTypeId = CustomerDetailVm.CustomerTypeId.ToString();
            }
        }

        protected async Task HandleValidSubmit()
        {
            CustomerDetailVm.CustomerTypeId = Guid.Parse(SelectedCustomerTypeId);
            ApiResponse<Guid> response;

            if (SelectedCustomerId == Guid.Empty)
            {
                response = await CustomerDataService.CreateCustomer(CustomerDetailVm);
            }
            else
            {
                response = await CustomerDataService.UpdateCustomer(CustomerDetailVm);
            }
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo("/customeroverview");
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/customeroverview");
        }
    }
}
