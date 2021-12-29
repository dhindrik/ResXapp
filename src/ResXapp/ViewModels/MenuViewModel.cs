namespace ResXapp.ViewModels;

public class MenuViewModel : ViewModel
{
    public MenuViewModel()
    {
    }

    public ICommand Open => new TinyCommand(async() =>
    {
        await Navigation.NavigateToAsync(nameof(MainViewModel));
    });
}

