using Drivo.MAUI.Views;

namespace Drivo.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
        }
    }
}