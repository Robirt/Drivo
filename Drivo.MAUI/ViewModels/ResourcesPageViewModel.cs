using Drivo.Entities;
using Drivo.MAUI.Services;
using System.Net.Http;

namespace Drivo.MAUI.ViewModels;

public class ResourcesPageViewModel : ViewModelBase
{
    public ResourcesPageViewModel(UserService userService, HttpClient httpClient)
    {
        UserService = userService;
        HttpClient = httpClient;    
 
        Resources = new List<ResourceEntity>();

    }
    private UserService UserService { get; }
    private HttpClient HttpClient { get; }
    private List<ResourceEntity> resources;
    public List<ResourceEntity> Resources
    {
        get
        {
            return resources;
        }

        set
        {
            if (resources == value) return;
            resources = value;
            OnPropertyChanged(nameof(Resources));
        }
    }
}

