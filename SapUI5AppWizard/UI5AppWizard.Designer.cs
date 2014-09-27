namespace UI5AppWizard
{
    partial class UI5AppWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stepWizardControl1 = new AeroWizard.StepWizardControl();
            this.wizardPage1 = new AeroWizard.WizardPage();
            this.LibraryType = new System.Windows.Forms.GroupBox();
            this.mobile = new System.Windows.Forms.RadioButton();
            this.desktop = new System.Windows.Forms.RadioButton();
            this.MainViewType = new AeroWizard.WizardPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.html = new System.Windows.Forms.RadioButton();
            this.json = new System.Windows.Forms.RadioButton();
            this.xml = new System.Windows.Forms.RadioButton();
            this.javascript = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.stepWizardControl1)).BeginInit();
            this.wizardPage1.SuspendLayout();
            this.LibraryType.SuspendLayout();
            this.MainViewType.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // stepWizardControl1
            // 
            this.stepWizardControl1.Location = new System.Drawing.Point(0, 0);
            this.stepWizardControl1.Name = "stepWizardControl1";
            this.stepWizardControl1.Pages.Add(this.wizardPage1);
            this.stepWizardControl1.Pages.Add(this.MainViewType);
            this.stepWizardControl1.Size = new System.Drawing.Size(724, 422);
            this.stepWizardControl1.TabIndex = 0;
            this.stepWizardControl1.Title = "SAP UI5 Application";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.LibraryType);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.NextPage = this.MainViewType;
            this.wizardPage1.Size = new System.Drawing.Size(526, 247);
            this.wizardPage1.TabIndex = 2;
            this.wizardPage1.Text = "Library";
            // 
            // LibraryType
            // 
            this.LibraryType.Controls.Add(this.mobile);
            this.LibraryType.Controls.Add(this.desktop);
            this.LibraryType.Location = new System.Drawing.Point(30, 28);
            this.LibraryType.Name = "LibraryType";
            this.LibraryType.Size = new System.Drawing.Size(479, 196);
            this.LibraryType.TabIndex = 0;
            this.LibraryType.TabStop = false;
            this.LibraryType.Text = "Library";
            // 
            // mobile
            // 
            this.mobile.AutoSize = true;
            this.mobile.Location = new System.Drawing.Point(7, 104);
            this.mobile.Name = "mobile";
            this.mobile.Size = new System.Drawing.Size(77, 24);
            this.mobile.TabIndex = 1;
            this.mobile.TabStop = true;
            this.mobile.Text = "Mobile";
            this.mobile.UseVisualStyleBackColor = true;
            // 
            // desktop
            // 
            this.desktop.AutoSize = true;
            this.desktop.Checked = true;
            this.desktop.Location = new System.Drawing.Point(7, 52);
            this.desktop.Name = "desktop";
            this.desktop.Size = new System.Drawing.Size(85, 24);
            this.desktop.TabIndex = 0;
            this.desktop.TabStop = true;
            this.desktop.Text = "Desktop";
            this.desktop.UseVisualStyleBackColor = true;
            // 
            // MainViewType
            // 
            this.MainViewType.Controls.Add(this.groupBox2);
            this.MainViewType.Name = "MainViewType";
            this.MainViewType.Size = new System.Drawing.Size(526, 247);
            this.MainViewType.TabIndex = 3;
            this.MainViewType.Text = "Initial View Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.html);
            this.groupBox2.Controls.Add(this.json);
            this.groupBox2.Controls.Add(this.xml);
            this.groupBox2.Controls.Add(this.javascript);
            this.groupBox2.Location = new System.Drawing.Point(22, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 202);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type";
            // 
            // html
            // 
            this.html.AutoSize = true;
            this.html.Location = new System.Drawing.Point(7, 157);
            this.html.Name = "html";
            this.html.Size = new System.Drawing.Size(69, 24);
            this.html.TabIndex = 3;
            this.html.TabStop = true;
            this.html.Text = "HTML";
            this.html.UseVisualStyleBackColor = true;
            // 
            // json
            // 
            this.json.AutoSize = true;
            this.json.Location = new System.Drawing.Point(7, 118);
            this.json.Name = "json";
            this.json.Size = new System.Drawing.Size(65, 24);
            this.json.TabIndex = 2;
            this.json.TabStop = true;
            this.json.Text = "JSON";
            this.json.UseVisualStyleBackColor = true;
            // 
            // xml
            // 
            this.xml.AutoSize = true;
            this.xml.Location = new System.Drawing.Point(7, 76);
            this.xml.Name = "xml";
            this.xml.Size = new System.Drawing.Size(59, 24);
            this.xml.TabIndex = 1;
            this.xml.TabStop = true;
            this.xml.Text = "XML";
            this.xml.UseVisualStyleBackColor = true;
            // 
            // javascript
            // 
            this.javascript.AutoSize = true;
            this.javascript.Checked = true;
            this.javascript.Location = new System.Drawing.Point(7, 36);
            this.javascript.Name = "javascript";
            this.javascript.Size = new System.Drawing.Size(94, 24);
            this.javascript.TabIndex = 0;
            this.javascript.TabStop = true;
            this.javascript.Text = "Javascript";
            this.javascript.UseVisualStyleBackColor = true;
            // 
            // SapUI5AppWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 422);
            this.Controls.Add(this.stepWizardControl1);
            this.Name = "UI5AppWizard";
            ((System.ComponentModel.ISupportInitialize)(this.stepWizardControl1)).EndInit();
            this.wizardPage1.ResumeLayout(false);
            this.LibraryType.ResumeLayout(false);
            this.LibraryType.PerformLayout();
            this.MainViewType.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AeroWizard.StepWizardControl stepWizardControl1;
        private AeroWizard.WizardPage wizardPage1;
        private System.Windows.Forms.GroupBox LibraryType;
        private System.Windows.Forms.RadioButton mobile;
        private System.Windows.Forms.RadioButton desktop;
        private AeroWizard.WizardPage MainViewType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton html;
        private System.Windows.Forms.RadioButton json;
        private System.Windows.Forms.RadioButton xml;
        private System.Windows.Forms.RadioButton javascript;
    }
}

