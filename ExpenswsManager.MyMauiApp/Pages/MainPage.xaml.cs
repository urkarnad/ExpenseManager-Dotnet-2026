using ExpenswsManager.MyMauiApp.Models;
using ExpenswsManager.MyMauiApp.PageModels;

namespace ExpenswsManager.MyMauiApp.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}