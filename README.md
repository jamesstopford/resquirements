# Resquire v1.0

A Windows Forms application for rapidly creating structured requirement files with templates and auto-naming for LLM agent consumption.

![Resquire Icon](Resquire/reqsuire_icon.ico)

## Features

### Core Functionality
- **Quick Requirement Creation** - Write content and avoid sections with structured XML output
- **Auto-Save Drafts** - Work-in-progress saved every 30 seconds, restored on startup
- **Smart File Naming** - Automatic timestamped filenames based on content
- **Boilerplate Support** - Persistent boilerplate text that remains across saves

### UI & Themes
- **5 Hacker Themes** - Switch with F1-F5 hotkeys (Matrix, Cyberpunk, Fire, Ocean, Forest)
- **Responsive Layout** - Resizable interface with mouse-draggable Quick Actions panel
- **Progress Tracking** - Visual progress bar showing total requirements created

### Project Management
- **Quick Projects** - Save and switch between project directories instantly
- **Recent Files** - Track and open recently created requirement files
- **Auto Cleanup** - Removes missing files/projects from lists automatically
- **Project Name Detection** - Automatically extracts project names for title bar

### Productivity Features
- **Keyboard Shortcuts** - Ctrl+Enter navigation (Content → Avoid → Save)
- **Directory Persistence** - Remembers last working directory and settings
- **Theme Persistence** - Saves preferred theme across sessions
- **Right-Click Context** - Remove projects from Quick Projects list

## Getting Started

### Prerequisites
- Windows 10/11
- .NET 9.0 Runtime

### Installation
1. Download the latest release
2. Extract the ZIP file
3. Run `Resquire.exe`

### Building from Source
```bash
git clone https://github.com/your-username/resquire.git
cd resquire
dotnet build
dotnet run --project Resquire
```

## Usage

### Creating a Requirement
1. **Content** - Enter your requirement description
2. **Avoid** - Specify what to avoid or constraints
3. **Boilerplate** - Add persistent project context (optional)
4. **Save** - Use Ctrl+Enter or click SAVE

### Keyboard Shortcuts
- `Ctrl+Enter` - Navigate Content → Avoid → Save
- `F1-F5` - Switch themes (Matrix, Cyberpunk, Fire, Ocean, Forest)
- `Alt+F4` - Close application

### Project Management
- Use **Browse** to select project directory
- Click **+** to add current directory to Quick Projects
- **Double-click** Quick Projects to switch directories
- **Right-click** Quick Projects to remove entries

## File Structure

```
Resquire/
├── Form1.cs              # Main application logic
├── Form1.Designer.cs     # UI layout and controls
├── Program.cs            # Application entry point
├── reqsuire_icon.ico     # Application icon
└── Resquire.csproj       # Project configuration
```

## Output Format

Generated files use XML structure:
```xml
<general>Your boilerplate content</general>

<requirementTitle>Requirement: filename</requirementTitle>

<requirement>Your requirement content</requirement>

<avoid>Things to avoid</avoid>
```

## Configuration

Settings are automatically saved to:
`%APPDATA%/Resquire/settings.json`

Includes:
- Last working directory
- Current theme selection
- Boilerplate content
- Quick Projects list
- Recent files list

## Special Features

### Project Name Detection
Automatically detects project names by looking for:
- Parent directory of `Resquirements` folder
- Parent directory of `Requirements` folder
- Removes "AmstedDigital." prefix if present

### Auto-Save Draft
- Saves work every 30 seconds
- Restores on application startup
- Only restores drafts less than 24 hours old

### Theme System
Five carefully crafted themes optimized for readability:
- **F1 Matrix** - Classic green on black
- **F2 Cyberpunk** - Blue/cyan futuristic
- **F3 Fire** - Orange/red warm tones
- **F4 Ocean** - Blue aquatic theme
- **F5 Forest** - Green nature theme

## Development

### Architecture
- **Single Form Application** - All logic in `Form1.cs` for simplicity
- **Settings Persistence** - JSON-based configuration
- **Embedded Resources** - Icon embedded in executable
- **Modern .NET** - Uses .NET 9.0 with Windows Forms

### Key Components
- Templates system for output formatting
- Theme engine with persistent selection
- File management with cleanup
- Responsive UI layout system

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly on Windows
5. Submit a pull request

## License

[Add your license here]

## Changelog

### v1.0.0
- Initial release
- Core requirement creation functionality
- 5 theme system with F1-F5 hotkeys
- Quick Projects and Recent Files
- Auto-save drafts and settings persistence
- Boilerplate support
- Responsive UI with resizable panels
- Auto cleanup of missing files/projects
- Project name detection and title bar updates
- Right-click context menus
- Alt+F4 support

## Credits

Built with ❤️ using:
- .NET 9.0
- Windows Forms
- C# 13

---

*Resquire - Because requirements should be quick, structured, and beautiful.*