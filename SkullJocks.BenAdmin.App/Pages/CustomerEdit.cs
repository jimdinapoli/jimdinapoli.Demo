using Microsoft.AspNetCore.Components;
using SkullJocks.BenAdmin.App.Contracts;
using SkullJocks.BenAdmin.App.ViewModels;
using System;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.App.Pages
{
    public partial class CustomerEdit
    {
        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }

        [Parameter]
        public string CustomerId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CustomerDetailVm Customer { get; set; } = new CustomerDetailVm();

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            var isExisting = Guid.TryParse(CustomerId, out _);

            if (!isExisting) //new customer is being created
            {
                //add some defaults
                Customer = new CustomerDetailVm
                {
                    CustomerId = Guid.Empty
                };
            }
            else
            {
                Customer = await CustomerDataService.GetCustomerById(Guid.Parse(CustomerId));
            }
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Customer.CustomerId == Guid.Empty)
            {
                var addedCustomer = await CustomerDataService.CreateCustomer(Customer);
                if (addedCustomer != null)
                {
                    StatusClass = "alert-success";
                    Message = "New customer added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new customer. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await CustomerDataService.UpdateCustomer(Customer);
                StatusClass = "alert-success";
                Message = "Customer updated successfully.";
                Saved = true;

            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "Error Please try again.";
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/customeroverview");
        }
    }
}
