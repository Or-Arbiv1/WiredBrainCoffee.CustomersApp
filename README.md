---
Wired Brain Coffee — Customers App

A small WPF desktop application for managing a list of customers, built with .NET 7 and a clean MVVM architecture. The project was created while learning WPF/MVVM (based on the Wired Brain Coffee sample domain) and is intentionally focused: it demonstrates the core patterns of a maintainable desktop app rather than a full production feature set.

▎ Status: Learning / portfolio project. The data layer is an in-memory mock, so the app runs end-to-end without any external database or configuration.

---
Features

- View customers — loads a list of customers into a master/detail UI.
- Add a customer — creates a new entry and selects it for editing.
- Edit details — first name, last name, and an "Is Developer" flag, with live two-way binding.
- Delete a customer — enabled only when a customer te gating).
- Toggle navigation side — moves the navigation pan of the window.

---
Architecture

The app follows the Model–View–ViewModel (MVVM) pattern with a clear separation of concerns:

WiredBrainCoffee.CustomersApp/
├── Model/
│   └── Customer.cs                  # Plain domain model (Id, FirstName, LastName, IsDeveloper)
├── Data/
│   └── CustomerDataProvider.cs      # ICustomerDataProvider + in-memory mock implementation
├── ViewModel/
│   ├── ViewModelBase.cs             # INotifyPropertyChanged base class
│   ├── CustomersViewModel.cs        # List, add, delete, load, navigation logic
│   └── CustomerItemViewModel.cs     # Wraps a single Customer for binding
├── Command/
│   └── DelegateCommand.cs           # ICommand relay implementation with CanExecute support
├── Converter/
│   └── NavigationSideToGridColumnConverter.cs
├── Controls/                        # Reusable XAML controls (e.g. HeaderControl)
├── Resources/                       # Brushes and converter resource dictionaries
└── View/                            # CustomersView and related XAML

Key design points

- Data access behind an interface — ICustomerDataPrthe data source, so the mock provider could be
swapped for a real database or API without touching
- Command pattern — user actions are exposed as DelegateCommand instances rather than code-behind event handlers, keeping the views thin.
- Observable state — ObservableCollection<T> and INotifyPropertyChanged drive automatic UI updates.
- Value converters — UI layout (navigation side) ish an IValueConverter.

---
Tech Stack

- Language: C#
- Framework: .NET 7 (net7.0-windows)
- UI: WPF (Windows Presentation Foundation)
- Pattern: MVVM
- Nullable reference types: enabled

---
Getting Started

Prerequisites

- Windows
- .NET 7 SDK (https://dotnet.microsoft.com/download/dotnet/7.0)
- Optional: Visual Studio 2022 (with the .NET desktop development workload)

Run from the command line

git clone https://github.com/Or-Arbiv1/WiredBrainCo
cd WiredBrainCoffee.CustomersApp
dotnet run --project WiredBrainCoffee.CustomersApp

Run from Visual Studio


---
Notes & Possible Next Steps

This is a focused sample; natural extensions would include:

- Replacing the mock CustomerDataProvider with a real persistence layer (e.g. EF Core / SQLite).
- Adding a dependency-injection container to wire up providers and view models.
- Adding unit tests around the ViewModels and commands.
- Input validation for the customer fields.

---
License

This project is provided as-is for learning and portfolio purposes.

---
