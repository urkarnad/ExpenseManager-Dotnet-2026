using ExpenswsManager.MyMauiApp.Models;

namespace ExpenswsManager.MyMauiApp.Pages
{
    public partial class ProjectDetailPage : ContentPage
    {
        public ProjectDetailPage(ProjectDetailPageModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}
