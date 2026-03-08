using CommunityToolkit.Mvvm.Input;
using MyMauiApp.Models;

namespace MyMauiApp.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}