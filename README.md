# QuoteSwift

QuoteSwift is a Windows Forms application for creating and managing pump quotes. It allows users to maintain parts, pumps, businesses and customers and to generate quotes that can be exported to Microsoft Excel.

## Prerequisites

- **.NET Framework 4.8** or later
- Visual Studio 2019 (or newer) with the *.NET desktop development* workload installed.  Alternatively, the project can be built with the `msbuild` or `dotnet` command line tools.

## Building the project

1. Clone this repository.
2. Open `QuoteSwift.sln` in Visual Studio and build the solution, **or** from a Developer Command Prompt run:

   ```bash
   msbuild QuoteSwift.sln
   ```

All projects (the main application, supporting library and the `ExportToExcel` tool) are built together.

## Running the application

After a successful build the main executable can be found in `QuoteSwift/bin/Debug` (or `bin/Release` if you built in Release mode). Launch `QuoteSwift.exe` to start the quoting application.

## Exporting quotes to Excel

The solution also builds an auxiliary program `ExportToExcel/ExportToExcel.exe`. When a quote is exported from the main application this utility is launched automatically and converts the quote to an Excel file using `QuoteTemplate.xlsx`.

To run the tool manually copy the serialized `ExportQuote.json` (created by the main application) into the same directory as `ExportToExcel.exe` and execute:

```bash
ExportToExcel.exe
```

You will be prompted for a location to save the generated workbook.

## License

This project is released under the MIT License. See [LICENSE](LICENSE) for details.
