# Agent Instructions

This repository contains **QuoteSwift**, a Windows Forms application built with C# and .NET Framework 4.8. It helps manage pump quotes, parts and customer information. A companion utility **ExportToExcel** converts serialized quote data into Excel workbooks.

## Repository layout
- **QuoteSwift.sln** – Visual Studio solution including the main WinForms app, a supporting class library (`MainProgramLibrary`) and the `ExportToExcel` tool.
- **MainProgramLibrary/** – Core business classes (Quote, Pump, Business, etc.).
- **ExportToExcel/** – Auxiliary console application invoked when a quote is exported.
- **Controls/** – Custom user controls, e.g. `NumericTextBox`.
- JSON files such as `BusinessList.json`, `MandatoryParts.json` and `NonMandatoryParts.json` hold data used by the application.

## Building
1. Open the solution in Visual Studio (2019 or newer) **or** from a Developer Command Prompt run:
   ```bash
   msbuild QuoteSwift.sln
   ```
2. All projects build together. After a successful build the main executable will be in `QuoteSwift/bin/Debug` (or `bin/Release`).

## Running
Launch `QuoteSwift.exe` to start the quoting application. When exporting a quote, the main program calls `ExportToExcel/ExportToExcel.exe` to generate an Excel file from `QuoteTemplate.xlsx`.

To run the export tool manually copy the serialized `ExportQuote.json` into the same directory as the tool and execute:
```bash
ExportToExcel.exe
```
You will be prompted for a location to save the workbook.

## Code guidelines
- Target framework: **.NET Framework 4.8**.
- Keep code in the existing C# coding style (PascalCase for public members, camelCase for locals, etc.).
- The solution does not currently include an automated test suite.
- After modifying code, compile the solution with `msbuild QuoteSwift.sln` to ensure it builds successfully.

## Contributing
1. Create descriptive commit messages summarizing the change.
2. Ensure the application still builds before committing.
3. Update documentation and JSON files when adding or modifying parts, pumps or other entities.
4. Use pull requests to propose changes.
