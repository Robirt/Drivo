using Drivo.Entities;
using Drivo.MAUI.Services;
using System.Windows.Input;

namespace Drivo.MAUI.ViewModels;

public class ExternalExamAddPageViewModel : ViewModelBase
{
    public ExternalExamAddPageViewModel(ExternalExamsService externalExamsService, UserService userService)
    {
        ExternalExamsService = externalExamsService;
        UserService = userService;

        AddExternaExamCommand = new Command(AddExternalExamAsync);
    }

    private ExternalExamsService ExternalExamsService { get; }
    private UserService UserService { get; }

    public ICommand AddExternaExamCommand { get; set; }

    private ExternalExamEntity externalExam;

    public ExternalExamEntity ExternalExam
    {
        get
        {
            return externalExam;
        }

        set
        {
            if (externalExam == value) return;
            externalExam = value;
            OnPropertyChanged(nameof(ExternalExam));
        }
    }

    private async void AddExternalExamAsync()
    {
        ExternalExam.StudentId = (await UserService.GetUserAsync()).Id;

        var actionResponse = await ExternalExamsService.AddExternalExamsAsync(ExternalExam);
        if (actionResponse.IsSucceeded) await Shell.Current.GoToAsync("Profile");
    }
}
