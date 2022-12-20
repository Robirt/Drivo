namespace Drivo.MAUI.ViewModels;

public class ResourcesPageViewModel : ViewModelBase
{
    public ResourcesPageViewModel()
    {
        Resources = new List<ResourceEntity>();

        Resources.Add(new(1, "A1", "Znak ostrzegający o ostrym skręcie w prawo", "https://ltesty.pl/images/znaki/znaki/big/A-1.png"));
        Resources.Add(new(2, "A2", "Znak ostrzegający o ostrym skręcie w prawo", "https://ltesty.pl/images/znaki/znaki/big/A-1.png"));
        Resources.Add(new(3, "A3", "Znak ostrzegający o ostrym skręcie w prawo", "https://ltesty.pl/images/znaki/znaki/big/A-1.png"));
    }

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

public class ResourceEntity
{
    public ResourceEntity()
    {

    }

    public ResourceEntity(int id, string name, string content, string imageUri)
    {
        Id = id;
        Name = name;
        Content = content;
        ImageUrl = imageUri;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }

    public string ImageUrl { get; set; }
}
