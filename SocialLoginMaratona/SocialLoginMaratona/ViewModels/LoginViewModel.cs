using SocialLoginMaratona.Helpers;
using SocialLoginMaratona.Services;
using SocialLoginMaratona.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SocialLoginMaratona.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        AzureService azureService;
        INavigation navigation;

        ICommand loginCommand;

        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));

        public string Title => "Social Login Demo";

        public LoginViewModel(INavigation nav)
        {
            azureService = DependencyService.Get<AzureService>();
            navigation = nav;
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (/*IsBusy || */!(await LoginAsync())) return;

            await PushAsync<RootViewModel>();
            RemovePageFromStack();
        }

        private void RemovePageFromStack()
        {
            var existingPages = navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page.GetType() == typeof(LoginPage))
                {
                    navigation.RemovePage(page);
                }
            }
        }

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn) return Task.FromResult(true);

            return azureService.LoginAsync();
        }
    }
}
