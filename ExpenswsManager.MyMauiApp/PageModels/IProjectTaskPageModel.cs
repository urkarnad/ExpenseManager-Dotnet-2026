using CommunityToolkit.Mvvm.Input;
using ExpenswsManager.MyMauiApp.Models;

namespace ExpenswsManager.MyMauiApp.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}