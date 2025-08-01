namespace Resquire;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.TextBox txtContent;
    private System.Windows.Forms.TextBox txtAvoid;
    private System.Windows.Forms.ComboBox cmbTemplate;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnSelectDirectory;
    private System.Windows.Forms.Label lblDirectory;
    private System.Windows.Forms.Label lblTemplate;
    private System.Windows.Forms.Label lblContent;
    private System.Windows.Forms.Label lblAvoid;
    private System.Windows.Forms.TextBox txtBoilerplate;
    private System.Windows.Forms.Label lblBoilerplate;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.Panel pnlProgressBar;
    private System.Windows.Forms.Panel pnlQuickActions;
    private System.Windows.Forms.Label lblQuickActions;
    private System.Windows.Forms.ListBox lstRecentFiles;
    private System.Windows.Forms.Label lblStats;
    private System.Windows.Forms.ListBox lstQuickProjects;
    private System.Windows.Forms.Label lblQuickProjects;
    private System.Windows.Forms.Button btnAddProject;
    private System.Windows.Forms.ContextMenuStrip contextMenuQuickProjects;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.txtContent = new System.Windows.Forms.TextBox();
        this.txtAvoid = new System.Windows.Forms.TextBox();
        this.cmbTemplate = new System.Windows.Forms.ComboBox();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnSelectDirectory = new System.Windows.Forms.Button();
        this.lblDirectory = new System.Windows.Forms.Label();
        this.lblTemplate = new System.Windows.Forms.Label();
        this.lblContent = new System.Windows.Forms.Label();
        this.lblAvoid = new System.Windows.Forms.Label();
        this.txtBoilerplate = new System.Windows.Forms.TextBox();
        this.lblBoilerplate = new System.Windows.Forms.Label();
        this.lblStatus = new System.Windows.Forms.Label();
        this.pnlProgressBar = new System.Windows.Forms.Panel();
        this.pnlQuickActions = new System.Windows.Forms.Panel();
        this.lblQuickActions = new System.Windows.Forms.Label();
        this.lstRecentFiles = new System.Windows.Forms.ListBox();
        this.lblStats = new System.Windows.Forms.Label();
        this.lstQuickProjects = new System.Windows.Forms.ListBox();
        this.lblQuickProjects = new System.Windows.Forms.Label();
        this.btnAddProject = new System.Windows.Forms.Button();
        this.contextMenuQuickProjects = new System.Windows.Forms.ContextMenuStrip();
        this.SuspendLayout();
        // 
        // txtContent
        // 
        this.txtContent.AcceptsReturn = true;
        this.txtContent.AcceptsTab = true;
        this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.txtContent.BackColor = System.Drawing.Color.Black;
        this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtContent.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.txtContent.ForeColor = System.Drawing.Color.Lime;
        this.txtContent.Location = new System.Drawing.Point(12, 35);
        this.txtContent.Multiline = true;
        this.txtContent.Name = "txtContent";
        this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtContent.Size = new System.Drawing.Size(576, 150);
        this.txtContent.TabIndex = 0;
        this.txtContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContent_KeyDown);
        // 
        // cmbTemplate
        // 
        // 
        // txtAvoid
        // 
        this.txtAvoid.AcceptsReturn = true;
        this.txtAvoid.AcceptsTab = true;
        this.txtAvoid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.txtAvoid.BackColor = System.Drawing.Color.Black;
        this.txtAvoid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtAvoid.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.txtAvoid.ForeColor = System.Drawing.Color.Lime;
        this.txtAvoid.Location = new System.Drawing.Point(12, 208);
        this.txtAvoid.Multiline = true;
        this.txtAvoid.Name = "txtAvoid";
        this.txtAvoid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtAvoid.Size = new System.Drawing.Size(576, 127);
        this.txtAvoid.TabIndex = 1;
        this.txtAvoid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAvoid_KeyDown);
        // 
        // cmbTemplate
        // 
        this.cmbTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.cmbTemplate.BackColor = System.Drawing.Color.Black;
        this.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.cmbTemplate.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.cmbTemplate.ForeColor = System.Drawing.Color.Lime;
        this.cmbTemplate.FormattingEnabled = true;
        this.cmbTemplate.Location = new System.Drawing.Point(12, 361);
        this.cmbTemplate.Name = "cmbTemplate";
        this.cmbTemplate.Size = new System.Drawing.Size(200, 23);
        this.cmbTemplate.TabIndex = 2;
        // 
        // btnSave
        // 
        this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnSave.BackColor = System.Drawing.Color.DarkGreen;
        this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSave.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnSave.ForeColor = System.Drawing.Color.Lime;
        this.btnSave.Location = new System.Drawing.Point(713, 361);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(75, 23);
        this.btnSave.TabIndex = 3;
        this.btnSave.Text = "SAVE";
        this.btnSave.UseVisualStyleBackColor = false;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // btnSelectDirectory
        // 
        this.btnSelectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnSelectDirectory.BackColor = System.Drawing.Color.DarkGreen;
        this.btnSelectDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSelectDirectory.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnSelectDirectory.ForeColor = System.Drawing.Color.Lime;
        this.btnSelectDirectory.Location = new System.Drawing.Point(713, 390);
        this.btnSelectDirectory.Name = "btnSelectDirectory";
        this.btnSelectDirectory.Size = new System.Drawing.Size(60, 23);
        this.btnSelectDirectory.TabIndex = 4;
        this.btnSelectDirectory.Text = "BROWSE";
        this.btnSelectDirectory.UseVisualStyleBackColor = false;
        this.btnSelectDirectory.Click += new System.EventHandler(this.btnSelectDirectory_Click);
        // 
        // btnAddProject
        // 
        this.btnAddProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnAddProject.BackColor = System.Drawing.Color.DarkGreen;
        this.btnAddProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnAddProject.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnAddProject.ForeColor = System.Drawing.Color.Lime;
        this.btnAddProject.Location = new System.Drawing.Point(778, 390);
        this.btnAddProject.Name = "btnAddProject";
        this.btnAddProject.Size = new System.Drawing.Size(23, 23);
        this.btnAddProject.TabIndex = 12;
        this.btnAddProject.Text = "+";
        this.btnAddProject.UseVisualStyleBackColor = false;
        this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
        // 
        // lblDirectory
        // 
        this.lblDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.lblDirectory.AutoSize = false;
        this.lblDirectory.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblDirectory.ForeColor = System.Drawing.Color.DarkGreen;
        this.lblDirectory.Location = new System.Drawing.Point(12, 394);
        this.lblDirectory.Name = "lblDirectory";
        this.lblDirectory.Size = new System.Drawing.Size(695, 15);
        this.lblDirectory.TabIndex = 5;
        this.lblDirectory.Text = "SAVE_DIR: ";
        // 
        // lblTemplate
        // 
        this.lblTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.lblTemplate.AutoSize = true;
        this.lblTemplate.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTemplate.ForeColor = System.Drawing.Color.Lime;
        this.lblTemplate.Location = new System.Drawing.Point(12, 343);
        this.lblTemplate.Name = "lblTemplate";
        this.lblTemplate.Size = new System.Drawing.Size(77, 14);
        this.lblTemplate.TabIndex = 6;
        this.lblTemplate.Text = "TEMPLATE:";
        // 
        // lblContent
        // 
        this.lblContent.AutoSize = true;
        this.lblContent.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblContent.ForeColor = System.Drawing.Color.Lime;
        this.lblContent.Location = new System.Drawing.Point(12, 17);
        this.lblContent.Name = "lblContent";
        this.lblContent.Size = new System.Drawing.Size(70, 14);
        this.lblContent.TabIndex = 7;
        this.lblContent.Text = "CONTENT:";
        // 
        // lblAvoid
        // 
        this.lblAvoid.AutoSize = true;
        this.lblAvoid.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblAvoid.ForeColor = System.Drawing.Color.Lime;
        this.lblAvoid.Location = new System.Drawing.Point(12, 190);
        this.lblAvoid.Name = "lblAvoid";
        this.lblAvoid.Size = new System.Drawing.Size(49, 14);
        this.lblAvoid.TabIndex = 8;
        this.lblAvoid.Text = "AVOID:";
        // 
        // txtBoilerplate
        // 
        this.txtBoilerplate.AcceptsReturn = true;
        this.txtBoilerplate.AcceptsTab = true;
        this.txtBoilerplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.txtBoilerplate.BackColor = System.Drawing.Color.Black;
        this.txtBoilerplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtBoilerplate.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.txtBoilerplate.ForeColor = System.Drawing.Color.Lime;
        this.txtBoilerplate.Location = new System.Drawing.Point(12, 355);
        this.txtBoilerplate.Multiline = true;
        this.txtBoilerplate.Name = "txtBoilerplate";
        this.txtBoilerplate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtBoilerplate.Size = new System.Drawing.Size(576, 80);
        this.txtBoilerplate.TabIndex = 9;
        // 
        // lblBoilerplate
        // 
        this.lblBoilerplate.AutoSize = true;
        this.lblBoilerplate.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblBoilerplate.ForeColor = System.Drawing.Color.Lime;
        this.lblBoilerplate.Location = new System.Drawing.Point(12, 337);
        this.lblBoilerplate.Name = "lblBoilerplate";
        this.lblBoilerplate.Size = new System.Drawing.Size(105, 14);
        this.lblBoilerplate.TabIndex = 10;
        this.lblBoilerplate.Text = "BOILERPLATE:";
        // 
        // lblStatus
        // 
        this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.lblStatus.AutoSize = false;
        this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblStatus.ForeColor = System.Drawing.Color.Green;
        this.lblStatus.Location = new System.Drawing.Point(220, 364);
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(400, 15);
        this.lblStatus.TabIndex = 9;
        this.lblStatus.Text = "";
        // 
        // pnlProgressBar
        // 
        this.pnlProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.pnlProgressBar.BackColor = System.Drawing.Color.Black;
        this.pnlProgressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlProgressBar.Location = new System.Drawing.Point(12, 415);
        this.pnlProgressBar.Name = "pnlProgressBar";
        this.pnlProgressBar.Size = new System.Drawing.Size(576, 8);
        this.pnlProgressBar.TabIndex = 10;
        // 
        // pnlQuickActions
        // 
        this.pnlQuickActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.pnlQuickActions.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
        this.pnlQuickActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlQuickActions.Location = new System.Drawing.Point(600, 12);
        this.pnlQuickActions.Name = "pnlQuickActions";
        this.pnlQuickActions.Size = new System.Drawing.Size(188, 410);
        this.pnlQuickActions.TabIndex = 11;
        this.pnlQuickActions.Controls.Add(this.lblQuickActions);
        this.pnlQuickActions.Controls.Add(this.lstRecentFiles);
        this.pnlQuickActions.Controls.Add(this.lblQuickProjects);
        this.pnlQuickActions.Controls.Add(this.lstQuickProjects);
        this.pnlQuickActions.Controls.Add(this.lblStats);
        // 
        // lblQuickActions
        // 
        this.lblQuickActions.AutoSize = true;
        this.lblQuickActions.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblQuickActions.ForeColor = System.Drawing.Color.Lime;
        this.lblQuickActions.Location = new System.Drawing.Point(8, 8);
        this.lblQuickActions.Name = "lblQuickActions";
        this.lblQuickActions.Size = new System.Drawing.Size(105, 14);
        this.lblQuickActions.TabIndex = 0;
        this.lblQuickActions.Text = "QUICK_ACTIONS";
        // 
        // lstRecentFiles
        // 
        this.lstRecentFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.lstRecentFiles.BackColor = System.Drawing.Color.Black;
        this.lstRecentFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lstRecentFiles.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lstRecentFiles.ForeColor = System.Drawing.Color.DarkGreen;
        this.lstRecentFiles.Location = new System.Drawing.Point(8, 30);
        this.lstRecentFiles.Name = "lstRecentFiles";
        this.lstRecentFiles.Size = new System.Drawing.Size(172, 150);
        this.lstRecentFiles.TabIndex = 1;
        this.lstRecentFiles.DoubleClick += new System.EventHandler(this.lstRecentFiles_DoubleClick);
        // 
        // lblQuickProjects
        // 
        this.lblQuickProjects.AutoSize = true;
        this.lblQuickProjects.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblQuickProjects.ForeColor = System.Drawing.Color.Lime;
        this.lblQuickProjects.Location = new System.Drawing.Point(8, 190);
        this.lblQuickProjects.Name = "lblQuickProjects";
        this.lblQuickProjects.Size = new System.Drawing.Size(112, 14);
        this.lblQuickProjects.TabIndex = 3;
        this.lblQuickProjects.Text = "QUICK_PROJECTS";
        // 
        // lstQuickProjects
        // 
        this.lstQuickProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.lstQuickProjects.BackColor = System.Drawing.Color.Black;
        this.lstQuickProjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lstQuickProjects.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lstQuickProjects.ForeColor = System.Drawing.Color.DarkGreen;
        this.lstQuickProjects.Location = new System.Drawing.Point(8, 210);
        this.lstQuickProjects.Name = "lstQuickProjects";
        this.lstQuickProjects.Size = new System.Drawing.Size(172, 150);
        this.lstQuickProjects.TabIndex = 4;
        this.lstQuickProjects.ContextMenuStrip = this.contextMenuQuickProjects;
        this.lstQuickProjects.DoubleClick += new System.EventHandler(this.lstQuickProjects_DoubleClick);
        // 
        // lblStats
        // 
        this.lblStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.lblStats.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblStats.ForeColor = System.Drawing.Color.DarkGreen;
        this.lblStats.Location = new System.Drawing.Point(8, 380);
        this.lblStats.Name = "lblStats";
        this.lblStats.Size = new System.Drawing.Size(172, 25);
        this.lblStats.TabIndex = 2;
        this.lblStats.Text = "SESSION: 0\nTOTAL: 0";
        // 
        // contextMenuQuickProjects
        // 
        this.contextMenuQuickProjects.BackColor = System.Drawing.Color.Black;
        this.contextMenuQuickProjects.ForeColor = System.Drawing.Color.Lime;
        this.contextMenuQuickProjects.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
        this.contextMenuQuickProjects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            new System.Windows.Forms.ToolStripMenuItem("Remove Project", null, this.removeProjectToolStripMenuItem_Click)
        });
        this.contextMenuQuickProjects.Name = "contextMenuQuickProjects";
        this.contextMenuQuickProjects.Size = new System.Drawing.Size(150, 26);
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Black;
        this.ClientSize = new System.Drawing.Size(800, 435);
        this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.Controls.Add(this.pnlQuickActions);
        this.Controls.Add(this.pnlProgressBar);
        this.Controls.Add(this.lblStatus);
        this.Controls.Add(this.lblAvoid);
        this.Controls.Add(this.txtBoilerplate);
        this.Controls.Add(this.lblBoilerplate);
        this.Controls.Add(this.lblContent);
        this.Controls.Add(this.lblTemplate);
        this.Controls.Add(this.lblDirectory);
        this.Controls.Add(this.btnAddProject);
        this.Controls.Add(this.btnSelectDirectory);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.cmbTemplate);
        this.Controls.Add(this.txtAvoid);
        this.Controls.Add(this.txtContent);
        this.Text = "RESQUIRE v1.0 - [REQUIREMENT_GENERATOR]";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}