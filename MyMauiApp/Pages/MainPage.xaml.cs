using MyMauiApp.Models;
using MyMauiApp.PageModels;

namespace MyMauiApp.Pages
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