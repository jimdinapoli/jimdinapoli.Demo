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
    public partial class CustomerDetails
    {
        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }

        [Inject]
        public ICustomerTypeDataService CustomerTypeDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CustomerDetailVm Customer { get; set; } =
            new CustomerDetailVm() { };

        public ObservableCollection<CustomerTypeVm> CustomerTypes { get; set; }
            = new ObservableCollection<CustomerTypeVm>();

        public string Message { get; set; }

        public string SelectedCustomerTypeId { get; set; }

        [Parameter]
        public string CustomerId { get; set; }
        public Guid SelectedCustomerId = Guid.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(CustomerId, out SelectedCustomerId))
            {
                Customer = await CustomerDataService.GetCustomerById(SelectedCustomerId);
                SelectedCustomerTypeId = Customer.CustomerTypeId.ToString();
            }

            var list = await CustomerTypeDataService.GetAllCustomerTypes();
            CustomerTypes = new ObservableCollection<CustomerTypeVm>(list);
            SelectedCustomerTypeId = CustomerTypes.FirstOrDefault().CustomerTypeId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            Customer.CustomerTypeId = Guid.Parse(SelectedCustomerTypeId);
            ApiResponse<Guid> response;

            if (SelectedCustomerId == Guid.Empty)
            {
                response = await CustomerDataService.CreateCustomer(Customer);
            }
            else
            {
                response = await CustomerDataService.UpdateCustomer(Customer);
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
    }
}
