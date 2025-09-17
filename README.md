# BibleShow Next-Gen

A cross-platform scripture presentation tool for churches and Christian organizations.

## Development Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or Visual Studio Code
- .NET MAUI workload
- Git

## Getting Started

1. Clone the repository:
```bash
git clone https://github.com/yourusername/bible_presentation_software.git
cd bible_presentation_software
```

2. Install the .NET MAUI workload:
```bash
dotnet workload install maui
```

3. Restore dependencies:
```bash
dotnet restore
```

4. Build the solution:
```bash
dotnet build
```

## Project Structure

- `src/BibleShow.Core` - Core business logic and models
- `src/BibleShow.UI` - MAUI-based cross-platform UI
- `src/BibleShow.API` - REST API implementation
- `src/BibleShow.Data` - Data access and migration tools
- `tests/` - Test projects
- `tools/` - Development and migration tools

## Development Guidelines

- Follow C# coding conventions
- Write unit tests for new features
- Keep the codebase clean and maintainable
- Document public APIs
- Use async/await for I/O operations

## License

[Your License Here]