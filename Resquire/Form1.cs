namespace Resquire;

public partial class Form1 : Form
{
    private string saveDirectory = string.Empty;
    private System.Windows.Forms.Timer statusTimer = new();
    private System.Windows.Forms.Timer autoSaveTimer = new();
    private int requirementCount = 0;
    private int sessionCount = 0;
    private List<string> recentFiles = new();
    private int currentTheme = 0;
    private bool isResizing = false;
    private int quickActionsPanelWidth = 188;
    private readonly Dictionary<string, (Color bg, Color fg, Color accent, Color dark)> themes = new()
    {
        { "Matrix", (Color.Black, Color.Lime, Color.DarkGreen, Color.FromArgb(16, 16, 16)) },
        { "Cyberpunk", (Color.FromArgb(20, 20, 40), Color.Cyan, Color.Blue, Color.FromArgb(40, 40, 80)) },
        { "Fire", (Color.FromArgb(40, 20, 0), Color.Orange, Color.Red, Color.FromArgb(60, 30, 0)) },
        { "Ocean", (Color.FromArgb(0, 20, 40), Color.LightBlue, Color.DarkBlue, Color.FromArgb(0, 30, 60)) },
        { "Forest", (Color.FromArgb(20, 40, 20), Color.LightGreen, Color.Green, Color.FromArgb(30, 60, 30)) }
    };
    private readonly Dictionary<string, string> templates = new()
    {
        { "XML Requirement", "<requirementTitle>Requirement: {filename}</requirementTitle>\n\n<requirement>{content}</requirement>\n\n<avoid>{avoid}</avoid>" }
    };

    public Form1()
    {
        InitializeComponent();
        LoadSettings();
        InitializeForm();
        InitializeStatusTimer();
        InitializeAutoSaveTimer();
        RestoreDraft();
    }

    private void InitializeForm()
    {
        cmbTemplate.Items.AddRange(templates.Keys.ToArray());
        cmbTemplate.SelectedIndex = 0;
        lblDirectory.Text = $"SAVE_DIR: {saveDirectory}";
        this.FormClosing += Form1_FormClosing;
        this.Resize += Form1_Resize;
        this.KeyPreview = true;
        this.KeyDown += Form1_KeyDown;
        this.Load += (s, e) => {
            AdjustTextBoxSizes();
            LoadRecentFiles();
            UpdateStats();
            ApplyTheme(); // Apply saved theme
            SetupQuickActionsResizing();
            ResizeQuickActionsPanel(); // Position buttons correctly on startup
            UpdateTitleBar();
        };
    }

    private void LoadSettings()
    {
        try
        {
            string settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Resquire");
            string settingsFile = Path.Combine(settingsPath, "settings.json");
            
            if (File.Exists(settingsFile))
            {
                string json = File.ReadAllText(settingsFile);
                var settings = System.Text.Json.JsonSerializer.Deserialize<System.Text.Json.JsonElement>(json);
                
                if (settings.TryGetProperty("saveDirectory", out var dirProp))
                {
                    string savedDir = dirProp.GetString() ?? @"C:\Projects";
                    saveDirectory = Directory.Exists(savedDir) ? savedDir : @"C:\Projects";
                }
                else
                {
                    saveDirectory = @"C:\Projects";
                }
                
                if (settings.TryGetProperty("theme", out var themeProp))
                {
                    currentTheme = Math.Max(0, Math.Min(themeProp.GetInt32(), themes.Count - 1));
                }
            }
            else
            {
                saveDirectory = @"C:\Projects";
                currentTheme = 0;
            }
        }
        catch
        {
            saveDirectory = @"C:\Projects";
            currentTheme = 0;
        }
    }

    private void SaveSettings()
    {
        try
        {
            string settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Resquire");
            Directory.CreateDirectory(settingsPath);
            string settingsFile = Path.Combine(settingsPath, "settings.json");
            
            var settings = new
            {
                saveDirectory = saveDirectory,
                theme = currentTheme
            };
            
            string json = System.Text.Json.JsonSerializer.Serialize(settings, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(settingsFile, json);
        }
        catch
        {
            // Ignore save errors
        }
    }

    private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
    {
        SaveSettings();
    }

    private void Form1_Resize(object? sender, EventArgs e)
    {
        AdjustTextBoxSizes();
        ResizeQuickActionsPanel();
    }

    private void AdjustTextBoxSizes()
    {
        if (txtContent == null || txtAvoid == null || lblAvoid == null) return;
        
        // Calculate available space between content label and controls at bottom
        int topSpace = txtContent.Top;
        int bottomSpace = this.ClientSize.Height - cmbTemplate.Top + 20; // Add some padding
        int availableHeight = this.ClientSize.Height - topSpace - bottomSpace;
        
        // Split the space roughly 50/50
        int contentHeight = availableHeight / 2 - 10; // 10px gap
        int avoidHeight = availableHeight - contentHeight - 28; // Account for label and spacing
        
        // Ensure minimum sizes
        contentHeight = Math.Max(contentHeight, 80);
        avoidHeight = Math.Max(avoidHeight, 60);
        
        // Update content box
        txtContent.Height = contentHeight;
        
        // Update avoid label and box positions
        int avoidLabelTop = txtContent.Bottom + 8;
        int avoidBoxTop = avoidLabelTop + lblAvoid.Height + 2;
        
        lblAvoid.Top = avoidLabelTop;
        txtAvoid.Top = avoidBoxTop;
        txtAvoid.Height = avoidHeight;
    }

    private void InitializeStatusTimer()
    {
        statusTimer.Interval = 3000;
        statusTimer.Tick += (s, e) => 
        {
            lblStatus.Text = "";
            statusTimer.Stop();
        };
    }

    private void InitializeAutoSaveTimer()
    {
        autoSaveTimer.Interval = 30000; // 30 seconds
        autoSaveTimer.Tick += (s, e) => AutoSaveDraft();
        autoSaveTimer.Start();
    }

    private void AutoSaveDraft()
    {
        if (string.IsNullOrWhiteSpace(txtContent.Text) && string.IsNullOrWhiteSpace(txtAvoid.Text))
            return;
            
        try
        {
            string draftPath = GetDraftFilePath();
            var draftData = new
            {
                content = txtContent.Text,
                avoid = txtAvoid.Text,
                timestamp = DateTime.Now
            };
            
            string json = System.Text.Json.JsonSerializer.Serialize(draftData, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(draftPath, json);
        }
        catch
        {
            // Ignore auto-save errors
        }
    }

    private void RestoreDraft()
    {
        try
        {
            string draftPath = GetDraftFilePath();
            if (!File.Exists(draftPath)) return;
            
            string json = File.ReadAllText(draftPath);
            var draftData = System.Text.Json.JsonSerializer.Deserialize<System.Text.Json.JsonElement>(json);
            
            if (draftData.TryGetProperty("content", out var content))
                txtContent.Text = content.GetString() ?? "";
                
            if (draftData.TryGetProperty("avoid", out var avoid))
                txtAvoid.Text = avoid.GetString() ?? "";
                
            if (draftData.TryGetProperty("timestamp", out var timestamp))
            {
                DateTime.TryParse(timestamp.GetString(), out var draftTime);
                if (DateTime.Now - draftTime < TimeSpan.FromHours(24)) // Only restore if < 24 hours old
                {
                    ShowStatus($"[DRAFT_RESTORED] {draftTime:HH:mm}", Color.Orange);
                }
            }
        }
        catch
        {
            // Ignore restore errors
        }
    }

    private string GetDraftFilePath()
    {
        string draftDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Resquire");
        Directory.CreateDirectory(draftDir);
        return Path.Combine(draftDir, "draft.json");
    }

    private void ClearDraft()
    {
        try
        {
            string draftPath = GetDraftFilePath();
            if (File.Exists(draftPath))
                File.Delete(draftPath);
        }
        catch
        {
            // Ignore clear errors
        }
    }

    private void LoadRecentFiles()
    {
        try
        {
            string recentPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Resquire", "recent.txt");
            if (File.Exists(recentPath))
            {
                recentFiles = File.ReadAllLines(recentPath).Take(10).ToList();
                UpdateRecentFilesList();
            }
        }
        catch
        {
            // Ignore load errors
        }
    }

    private void AddToRecentFiles(string filePath)
    {
        recentFiles.Remove(filePath); // Remove if already exists
        recentFiles.Insert(0, filePath); // Add to top
        if (recentFiles.Count > 10) recentFiles.RemoveAt(10); // Keep only 10
        
        UpdateRecentFilesList();
        SaveRecentFiles();
    }

    private void UpdateRecentFilesList()
    {
        lstRecentFiles.Items.Clear();
        foreach (var file in recentFiles)
        {
            string fileName = Path.GetFileName(file);
            if (fileName.Length > 25)
                fileName = fileName.Substring(0, 22) + "...";
            lstRecentFiles.Items.Add(fileName);
        }
    }

    private void SaveRecentFiles()
    {
        try
        {
            string recentPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Resquire", "recent.txt");
            File.WriteAllLines(recentPath, recentFiles);
        }
        catch
        {
            // Ignore save errors
        }
    }

    private void UpdateStats()
    {
        lblStats.Text = $"SESSION: {sessionCount}\nTOTAL: {requirementCount}";
    }

    private void lstRecentFiles_DoubleClick(object sender, EventArgs e)
    {
        if (lstRecentFiles.SelectedIndex >= 0 && lstRecentFiles.SelectedIndex < recentFiles.Count)
        {
            string filePath = recentFiles[lstRecentFiles.SelectedIndex];
            if (File.Exists(filePath))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
        }
    }

    private void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode >= Keys.F1 && e.KeyCode <= Keys.F5)
        {
            int themeIndex = e.KeyCode - Keys.F1;
            if (themeIndex < themes.Count)
            {
                currentTheme = themeIndex;
                ApplyTheme();
                e.Handled = true;
            }
        }
    }

    private void ApplyTheme()
    {
        var themeEntry = themes.ElementAt(currentTheme);
        string themeName = themeEntry.Key;
        var colors = themeEntry.Value;
        
        // Apply theme to form and controls
        this.BackColor = colors.bg;
        
        // Text boxes
        txtContent.BackColor = colors.bg;
        txtContent.ForeColor = colors.fg;
        txtAvoid.BackColor = colors.bg;
        txtAvoid.ForeColor = colors.fg;
        
        // ComboBox
        cmbTemplate.BackColor = colors.bg;
        cmbTemplate.ForeColor = colors.fg;
        
        // Buttons
        btnSave.BackColor = colors.accent;
        btnSave.ForeColor = colors.fg;
        btnSelectDirectory.BackColor = colors.accent;
        btnSelectDirectory.ForeColor = colors.fg;
        
        // Labels
        lblContent.ForeColor = colors.fg;
        lblAvoid.ForeColor = colors.fg;
        lblTemplate.ForeColor = colors.fg;
        lblDirectory.ForeColor = colors.dark;
        lblDirectory.BackColor = colors.bg; // Ensure proper background
        lblStatus.ForeColor = colors.fg;
        
        // Quick Actions Panel
        pnlQuickActions.BackColor = colors.dark;
        lblQuickActions.ForeColor = colors.fg;
        lstRecentFiles.BackColor = colors.bg;
        lstRecentFiles.ForeColor = colors.dark;
        lblStats.ForeColor = colors.dark;
        
        // Progress bar
        pnlProgressBar.BackColor = colors.bg;
        UpdateProgressBar(); // Refresh progress pills with new color
        
        ShowStatus($"[THEME] {themeName.ToUpper()} (F{currentTheme + 1})", colors.fg);
    }

    private void SetupQuickActionsResizing()
    {
        pnlQuickActions.MouseMove += (s, e) => {
            if (!isResizing && e.X <= 5) // Near left edge when not already resizing
            {
                pnlQuickActions.Cursor = Cursors.SizeWE;
            }
            else if (!isResizing)
            {
                pnlQuickActions.Cursor = Cursors.Default;
            }
            
            // Handle resize dragging
            if (isResizing)
            {
                // Calculate new width based on global mouse position
                int mouseXGlobal = pnlQuickActions.Left + e.X;
                int newWidth = this.ClientSize.Width - mouseXGlobal - 12; // 12px margin
                newWidth = Math.Max(150, Math.Min(400, newWidth)); // Min 150, Max 400
                
                if (newWidth != quickActionsPanelWidth)
                {
                    quickActionsPanelWidth = newWidth;
                    ResizeQuickActionsPanel();
                }
            }
        };
        
        pnlQuickActions.MouseDown += (s, e) => {
            if (e.X <= 5 && e.Button == MouseButtons.Left)
            {
                isResizing = true;
                pnlQuickActions.Capture = true;
                pnlQuickActions.Cursor = Cursors.SizeWE;
            }
        };
        
        pnlQuickActions.MouseUp += (s, e) => {
            if (isResizing)
            {
                isResizing = false;
                pnlQuickActions.Capture = false;
                pnlQuickActions.Cursor = e.X <= 5 ? Cursors.SizeWE : Cursors.Default;
            }
        };
    }
    
    private void ResizeQuickActionsPanel()
    {
        int panelLeft = this.ClientSize.Width - quickActionsPanelWidth - 12;
        pnlQuickActions.Left = panelLeft;
        pnlQuickActions.Width = quickActionsPanelWidth;
        
        // Adjust other controls
        int availableWidth = panelLeft - 24; // Account for margins
        txtContent.Width = availableWidth;
        txtAvoid.Width = availableWidth;
        pnlProgressBar.Width = availableWidth;
        
        // Reposition buttons to be left of the Quick Actions panel
        int buttonX = panelLeft - 87; // 75px button width + 12px margin
        btnSave.Left = buttonX;
        btnSelectDirectory.Left = buttonX;
        
        // Adjust status and directory label widths to not overlap buttons
        lblStatus.Width = buttonX - lblStatus.Left - 12;
        lblDirectory.Width = buttonX - lblDirectory.Left - 12;
    }

    private void UpdateTitleBar()
    {
        string projectName = ExtractProjectName(saveDirectory);
        this.Text = $"RESQUIRE v1.0 - [{projectName}]";
    }

    private string ExtractProjectName(string directoryPath)
    {
        try
        {
            if (string.IsNullOrEmpty(directoryPath))
                return "REQUIREMENT_GENERATOR";
            
            // Look for "Resquirements" folder in the path
            string normalizedPath = directoryPath.Replace('/', '\\');
            
            // Check if current directory contains "Resquirements" or "Requirements"
            if (Directory.Exists(Path.Combine(directoryPath, "Resquirements")) ||
                Directory.Exists(Path.Combine(directoryPath, "Requirements")))
            {
                // Current directory is the project directory
                return Path.GetFileName(directoryPath).ToUpper();
            }
            
            // Check if current directory IS "Resquirements" or "Requirements"
            string currentDirName = Path.GetFileName(directoryPath);
            if (string.Equals(currentDirName, "Resquirements", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(currentDirName, "Requirements", StringComparison.OrdinalIgnoreCase))
            {
                // Get parent directory as project name
                string? parentPath = Path.GetDirectoryName(directoryPath);
                if (!string.IsNullOrEmpty(parentPath))
                {
                    return Path.GetFileName(parentPath).ToUpper();
                }
            }
            
            // Fallback: use the current directory name
            return Path.GetFileName(directoryPath).ToUpper();
        }
        catch
        {
            return "REQUIREMENT_GENERATOR";
        }
    }

    private void txtContent_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.Enter)
        {
            e.Handled = true;
            txtAvoid.Focus();
        }
    }

    private void txtAvoid_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.Enter)
        {
            e.Handled = true;
            SaveFile();
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        SaveFile();
    }

    private void SaveFile()
    {
        if (string.IsNullOrWhiteSpace(txtContent.Text))
        {
            ShowStatus("Please enter some content.", Color.Orange);
            return;
        }

        string selectedTemplate = cmbTemplate.SelectedItem?.ToString() ?? "XML Requirement";
        string template = templates[selectedTemplate];
        
        string title = ExtractTitle(txtContent.Text);
        string fileName = GenerateFileName(title);
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
        
        string formattedContent = template
            .Replace("{filename}", fileNameWithoutExtension)
            .Replace("{content}", txtContent.Text.Trim())
            .Replace("{avoid}", txtAvoid.Text.Trim());
        string filePath = Path.Combine(saveDirectory, fileName);

        try
        {
            File.WriteAllText(filePath, formattedContent);
            requirementCount++;
            sessionCount++;
            UpdateProgressBar();
            AddToRecentFiles(filePath);
            UpdateStats();
            ShowStatus($"✓ Saved: {fileName} [#{requirementCount}]", Color.Lime);
            ClearDraft();
            txtContent.Clear();
            txtAvoid.Clear();
            txtContent.Focus();
        }
        catch (Exception ex)
        {
            ShowStatus($"✗ Error: {ex.Message}", Color.Red);
        }
    }

    private void ShowStatus(string message, Color color)
    {
        lblStatus.Text = message;
        lblStatus.ForeColor = color;
        statusTimer.Stop();
        statusTimer.Start();
    }

    private void UpdateProgressBar()
    {
        pnlProgressBar.Controls.Clear();
        int pillWidth = 8;
        int pillHeight = 6;
        int spacing = 2;
        int maxPills = (pnlProgressBar.Width - 4) / (pillWidth + spacing);
        
        for (int i = 0; i < Math.Min(requirementCount, maxPills); i++)
        {
            var themeColors = themes.ElementAt(currentTheme).Value;
            var pill = new Panel
            {
                BackColor = themeColors.fg,
                Size = new Size(pillWidth, pillHeight),
                Location = new Point(2 + i * (pillWidth + spacing), 1)
            };
            pnlProgressBar.Controls.Add(pill);
        }
    }

    private void btnSelectDirectory_Click(object sender, EventArgs e)
    {
        using var folderDialog = new FolderBrowserDialog();
        
        // Always try the current saveDirectory first, then fallback to C:\Projects
        string startPath = saveDirectory;
        if (!Directory.Exists(startPath))
        {
            startPath = @"C:\Projects";
            if (!Directory.Exists(startPath))
            {
                startPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
        }
        
        folderDialog.SelectedPath = startPath;
        folderDialog.Description = "Select directory to save requirement files";

        if (folderDialog.ShowDialog() == DialogResult.OK)
        {
            saveDirectory = folderDialog.SelectedPath;
            lblDirectory.Text = $"SAVE_DIR: {saveDirectory}";
            UpdateTitleBar();
        }
    }

    private string ExtractTitle(string content)
    {
        var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length > 0)
        {
            string firstLine = lines[0].Trim();
            if (firstLine.Length > 50)
                firstLine = firstLine.Substring(0, 47) + "...";
            return firstLine;
        }
        return "Untitled";
    }

    private string GenerateFileName(string title)
    {
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string safeName = string.Join("_", title.Split(Path.GetInvalidFileNameChars()));
        return $"{timestamp}_{safeName}.txt";
    }
}