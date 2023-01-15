using Drivo.MAUI.Views;

namespace Drivo.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("SignIn", typeof(SignInPage));
            Routing.RegisterRoute("CourseModule", typeof(CourseModulePage));
            Routing.RegisterRoute("ExternalExamAdd", typeof(ExternalExamAddPage));

            InitializeComponent();
        }
    }
}