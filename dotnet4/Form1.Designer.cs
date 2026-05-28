namespace dotnet2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelLibraryPath = new System.Windows.Forms.Label();
            this.textBoxLibraryPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseLibrary = new System.Windows.Forms.Button();
            this.buttonLoadLibrary = new System.Windows.Forms.Button();
            this.labelClasses = new System.Windows.Forms.Label();
            this.listBoxClasses = new System.Windows.Forms.ListBox();
            this.labelConstructor = new System.Windows.Forms.Label();
            this.comboBoxConstructors = new System.Windows.Forms.ComboBox();
            this.labelConstructorParameters = new System.Windows.Forms.Label();
            this.panelConstructorParameters = new System.Windows.Forms.Panel();
            this.labelMethod = new System.Windows.Forms.Label();
            this.comboBoxMethods = new System.Windows.Forms.ComboBox();
            this.labelObjectProperties = new System.Windows.Forms.Label();
            this.panelObjectProperties = new System.Windows.Forms.Panel();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLibraryPath
            // 
            this.labelLibraryPath.AutoSize = true;
            this.labelLibraryPath.Location = new System.Drawing.Point(12, 15);
            this.labelLibraryPath.Name = "labelLibraryPath";
            this.labelLibraryPath.Size = new System.Drawing.Size(118, 13);
            this.labelLibraryPath.TabIndex = 0;
            this.labelLibraryPath.Text = "Путь к библиотеке";
            // 
            // textBoxLibraryPath
            // 
            this.textBoxLibraryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLibraryPath.Location = new System.Drawing.Point(136, 12);
            this.textBoxLibraryPath.Name = "textBoxLibraryPath";
            this.textBoxLibraryPath.Size = new System.Drawing.Size(500, 20);
            this.textBoxLibraryPath.TabIndex = 1;
            // 
            // buttonBrowseLibrary
            // 
            this.buttonBrowseLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseLibrary.Location = new System.Drawing.Point(642, 10);
            this.buttonBrowseLibrary.Name = "buttonBrowseLibrary";
            this.buttonBrowseLibrary.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseLibrary.TabIndex = 2;
            this.buttonBrowseLibrary.Text = "Обзор...";
            this.buttonBrowseLibrary.UseVisualStyleBackColor = true;
            this.buttonBrowseLibrary.Click += new System.EventHandler(this.buttonBrowseLibrary_Click);
            // 
            // buttonLoadLibrary
            // 
            this.buttonLoadLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadLibrary.Location = new System.Drawing.Point(723, 10);
            this.buttonLoadLibrary.Name = "buttonLoadLibrary";
            this.buttonLoadLibrary.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadLibrary.TabIndex = 3;
            this.buttonLoadLibrary.Text = "Загрузить";
            this.buttonLoadLibrary.UseVisualStyleBackColor = true;
            this.buttonLoadLibrary.Click += new System.EventHandler(this.buttonLoadLibrary_Click);
            // 
            // labelClasses
            // 
            this.labelClasses.AutoSize = true;
            this.labelClasses.Location = new System.Drawing.Point(12, 50);
            this.labelClasses.Name = "labelClasses";
            this.labelClasses.Size = new System.Drawing.Size(44, 13);
            this.labelClasses.TabIndex = 4;
            this.labelClasses.Text = "Классы";
            // 
            // listBoxClasses
            // 
            this.listBoxClasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxClasses.FormattingEnabled = true;
            this.listBoxClasses.IntegralHeight = false;
            this.listBoxClasses.Location = new System.Drawing.Point(15, 66);
            this.listBoxClasses.Name = "listBoxClasses";
            this.listBoxClasses.Size = new System.Drawing.Size(180, 374);
            this.listBoxClasses.TabIndex = 5;
            this.listBoxClasses.SelectedIndexChanged += new System.EventHandler(this.listBoxClasses_SelectedIndexChanged);
            // 
            // labelConstructor
            // 
            this.labelConstructor.AutoSize = true;
            this.labelConstructor.Location = new System.Drawing.Point(210, 50);
            this.labelConstructor.Name = "labelConstructor";
            this.labelConstructor.Size = new System.Drawing.Size(67, 13);
            this.labelConstructor.TabIndex = 6;
            this.labelConstructor.Text = "Конструктор";
            // 
            // comboBoxConstructors
            // 
            this.comboBoxConstructors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxConstructors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConstructors.FormattingEnabled = true;
            this.comboBoxConstructors.Location = new System.Drawing.Point(213, 66);
            this.comboBoxConstructors.Name = "comboBoxConstructors";
            this.comboBoxConstructors.Size = new System.Drawing.Size(585, 21);
            this.comboBoxConstructors.TabIndex = 7;
            this.comboBoxConstructors.SelectedIndexChanged += new System.EventHandler(this.comboBoxConstructors_SelectedIndexChanged);
            // 
            // labelConstructorParameters
            // 
            this.labelConstructorParameters.AutoSize = true;
            this.labelConstructorParameters.Location = new System.Drawing.Point(210, 95);
            this.labelConstructorParameters.Name = "labelConstructorParameters";
            this.labelConstructorParameters.Size = new System.Drawing.Size(143, 13);
            this.labelConstructorParameters.TabIndex = 8;
            this.labelConstructorParameters.Text = "Параметры конструктора";
            // 
            // panelConstructorParameters
            // 
            this.panelConstructorParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelConstructorParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConstructorParameters.Location = new System.Drawing.Point(213, 111);
            this.panelConstructorParameters.Name = "panelConstructorParameters";
            this.panelConstructorParameters.Size = new System.Drawing.Size(585, 66);
            this.panelConstructorParameters.TabIndex = 9;
            // 
            // labelMethod
            // 
            this.labelMethod.AutoSize = true;
            this.labelMethod.Location = new System.Drawing.Point(210, 185);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(39, 13);
            this.labelMethod.TabIndex = 10;
            this.labelMethod.Text = "Метод";
            // 
            // comboBoxMethods
            // 
            this.comboBoxMethods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMethods.FormattingEnabled = true;
            this.comboBoxMethods.Location = new System.Drawing.Point(213, 201);
            this.comboBoxMethods.Name = "comboBoxMethods";
            this.comboBoxMethods.Size = new System.Drawing.Size(585, 21);
            this.comboBoxMethods.TabIndex = 11;
            this.comboBoxMethods.SelectedIndexChanged += new System.EventHandler(this.comboBoxMethods_SelectedIndexChanged);
            // 
            // labelObjectProperties
            // 
            this.labelObjectProperties.AutoSize = true;
            this.labelObjectProperties.Location = new System.Drawing.Point(210, 234);
            this.labelObjectProperties.Name = "labelObjectProperties";
            this.labelObjectProperties.Size = new System.Drawing.Size(103, 13);
            this.labelObjectProperties.TabIndex = 20;
            this.labelObjectProperties.Text = "Свойства объекта";
            // 
            // panelObjectProperties
            // 
            this.panelObjectProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelObjectProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelObjectProperties.Location = new System.Drawing.Point(213, 250);
            this.panelObjectProperties.Name = "panelObjectProperties";
            this.panelObjectProperties.Size = new System.Drawing.Size(585, 40);
            this.panelObjectProperties.TabIndex = 21;
            // 
            // buttonExecute
            // 
            this.buttonExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExecute.Location = new System.Drawing.Point(683, 302);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(115, 27);
            this.buttonExecute.TabIndex = 14;
            this.buttonExecute.Text = "Выполнить";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.textBoxResult);
            this.panelFooter.Controls.Add(this.labelResult);
            this.panelFooter.Controls.Add(this.textBoxStatus);
            this.panelFooter.Controls.Add(this.labelStatus);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 440);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(8);
            this.panelFooter.Size = new System.Drawing.Size(810, 140);
            this.panelFooter.TabIndex = 22;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(11, 10);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(44, 13);
            this.labelStatus.TabIndex = 15;
            this.labelStatus.Text = "Статус";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Location = new System.Drawing.Point(61, 7);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(734, 20);
            this.textBoxStatus.TabIndex = 16;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(11, 36);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(59, 13);
            this.labelResult.TabIndex = 17;
            this.labelResult.Text = "Результат";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResult.Location = new System.Drawing.Point(11, 52);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResult.Size = new System.Drawing.Size(784, 75);
            this.textBoxResult.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 580);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelObjectProperties);
            this.Controls.Add(this.labelObjectProperties);
            this.Controls.Add(this.comboBoxMethods);
            this.Controls.Add(this.labelMethod);
            this.Controls.Add(this.panelConstructorParameters);
            this.Controls.Add(this.labelConstructorParameters);
            this.Controls.Add(this.comboBoxConstructors);
            this.Controls.Add(this.labelConstructor);
            this.Controls.Add(this.listBoxClasses);
            this.Controls.Add(this.labelClasses);
            this.Controls.Add(this.buttonLoadLibrary);
            this.Controls.Add(this.buttonBrowseLibrary);
            this.Controls.Add(this.textBoxLibraryPath);
            this.Controls.Add(this.labelLibraryPath);
            this.MinimumSize = new System.Drawing.Size(700, 520);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Летательные аппараты — рефлексия";
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelLibraryPath;
        private System.Windows.Forms.TextBox textBoxLibraryPath;
        private System.Windows.Forms.Button buttonBrowseLibrary;
        private System.Windows.Forms.Button buttonLoadLibrary;
        private System.Windows.Forms.Label labelClasses;
        private System.Windows.Forms.ListBox listBoxClasses;
        private System.Windows.Forms.Label labelConstructor;
        private System.Windows.Forms.ComboBox comboBoxConstructors;
        private System.Windows.Forms.Label labelConstructorParameters;
        private System.Windows.Forms.Panel panelConstructorParameters;
        private System.Windows.Forms.Label labelMethod;
        private System.Windows.Forms.ComboBox comboBoxMethods;
        private System.Windows.Forms.Label labelObjectProperties;
        private System.Windows.Forms.Panel panelObjectProperties;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.TextBox textBoxResult;
    }
}
