namespace ResXapp.ViewModels;

public class MainViewModel : ViewModel
{
    private readonly IResxService resxService;
    private readonly IFileService fileService;

    public MainViewModel(IResxService resxService, IFileService fileService)
    {
        this.resxService = resxService;
        this.fileService = fileService;
    }

    public async override Task Initialize()
    {
        await base.Initialize();

        if(!Items.Any())
        {
            await Open();
        }
    }

    public async Task Open()
    {
        var files = await fileService.OpenFiles();

        var translations = resxService.ReadData(files);

        var result = new List<TextViewModel>();

        foreach (var item in translations)
        {
            foreach (var translation in item.Translations)
            {
                var current = result.SingleOrDefault(x => x.Key == translation.Key);

                if (current == null)
                {
                    current = new TextViewModel() { Key = translation.Key };
                    result.Add(current);
                }

                current.Translations.Add(new TranslationViewModel() { Language = item.Name, Text = translation.Value.Value });
            }
        }

        foreach (var item in result)
        {
            item.Translations = item.Translations.OrderBy(x => x.Language).ToList();
        }


        Items = new ObservableCollection<TextViewModel>(result);
    }

    private ObservableCollection<TextViewModel> items = new();
    public ObservableCollection<TextViewModel> Items
    {
        get => items;
        set
        {
            Set(ref items, value);
            RaisePropertyChanged(nameof(ShowAdd));
            RaisePropertyChanged(nameof(ShowSave));
        }
    }
    public bool ShowAdd => Items.Any();
    public bool ShowSave => Items.Any();

    private bool addIsOpen;
    public bool AddIsOpen
    {
        get => addIsOpen;
        set => Set(ref addIsOpen, value);
    }

    public ICommand Add => new Command(() =>
    {
        AddIsOpen = true;
    });
}

public class TextViewModel : ViewModel
{
    private string key;
    public string Key
    {
        get => key;
        set => key = value;
    }

    private List<TranslationViewModel> translations = new();
    public List<TranslationViewModel> Translations
    {
        get => translations;
        set => Set(ref translations, value);
    }
}

public class TranslationViewModel : ViewModel
{
    public string Language { get; set; }

    private string text;

    public string Text
    {
        get => text;
        set => Set(ref text, value);
    }
}
