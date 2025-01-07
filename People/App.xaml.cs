using People.Services;

namespace People;

public partial class App : Application
{
	public static PersonRepository PersonRepo { get; private set; }

	public App(PersonRepository repo)
	{
		InitializeComponent();
        PersonRepo = repo;
        // TODO: Initialize the PersonRepository property with the PersonRespository singleton object

    }

	protected override Window CreateWindow(IActivationState activationState)
	{
		return new Window(new AppShell());
	}
}