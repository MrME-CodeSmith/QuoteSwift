# QuoteSwift

QuoteSwift is a Windows Forms application for creating and managing pump quotes. It allows users to maintain parts, pumps, businesses and customers and to generate quotes that can be exported to Microsoft Excel.
Quote data is now serialized as JSON.

The application keeps all loaded parts, pumps, businesses and quotes in an
`ApplicationData` object which is passed to forms and view-models when needed.
Earlier versions used a `Pass` helper class for this role.

## Prerequisites

- **.NET Framework 4.8** or later
- Visual Studio 2019 (or newer) with the *.NET desktop development* workload installed.  Alternatively, the project can be built with the `msbuild` or `dotnet` command line tools.

## Building the project

1. Clone this repository.
2. Open `QuoteSwift.sln` in Visual Studio and build the solution, **or** from a Developer Command Prompt run:

   ```bash
   msbuild QuoteSwift.sln
   ```

All projects (the main application and supporting library) are built together.

## Running the application

After a successful build the main executable can be found in `QuoteSwift/bin/Debug` (or `bin/Release` if you built in Release mode). Launch `QuoteSwift.exe` to start the quoting application.

## Exporting quotes to Excel

Quotes are exported directly from the application using `QuoteTemplate.xlsx`. When you choose to export a quote you will be prompted for the location to save the generated workbook.

## MVVM structure

The WinForms UI follows an MVVM style approach. Each form has a corresponding
view model class under the `ViewModels/` folder. View models expose properties
that forms bind to, and commands implemented via the `RelayCommand` class. This
binding is set up when the form is created so that controls automatically update
as properties change.

Navigation between forms is handled by the `NavigationService` which constructs
view models, opens the appropriate form and persists updated data back into the
`ApplicationData` object.

When contributing new functionality please follow the existing MVVM pattern:
add a view model for new forms, bind controls to view model properties and use
`RelayCommand` for button logic.

## License

This project is released under the MIT License. See [LICENSE](LICENSE) for details.
