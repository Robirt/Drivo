using Drivo.MAUI.Views;

namespace Drivo.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("CourseModule", typeof(CourseModulePage));

            InitializeComponent();
        }
    }
}