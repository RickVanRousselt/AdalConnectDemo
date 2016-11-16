using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AdalConnectDemo2
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void BtnConnect_OnClick(object sender, RoutedEventArgs e)
        {
            AuthenticationContext ac = new AuthenticationContext("https://login.windows.net/common",new TokenCache());
            PlatformParameters platformParameters = new PlatformParameters(PromptBehavior.Auto, false);

            //Fill in the client id on the next line
            //To get a client ID create a new app in the azure management portal https://msdn.microsoft.com/en-us/library/azure/ee460782.aspx
            //For more information on this visit https://docs.microsoft.com/en-us/azure/active-directory/active-directory-authentication-scenarios

            AuthenticationResult ar = await ac.AcquireTokenAsync("https://graph.microsoft.com", "ef5878f8-2737-46d4-8c73-f1765e43ffbd", new Uri("http://rick"), platformParameters);
            txtName.Text = ar.UserInfo.GivenName;
            TxtToken.Text = ar.AccessToken;
        }
    }
}
