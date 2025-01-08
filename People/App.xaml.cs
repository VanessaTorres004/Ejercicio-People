﻿using People;
using VanessaTorresPeople.Services;

namespace VanessaTorresPeople;

public partial class App : Application
{
    public static PersonRepository PersonRepo { get; private set; }

    public App(PersonRepository repo)
    {

        InitializeComponent();
        PersonRepo = repo;
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        return new Window(new AppShell());
    }
}