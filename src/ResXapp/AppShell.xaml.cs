namespace ResXapp;

public partial class AppShell
{
    public AppShell(MenuViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}
