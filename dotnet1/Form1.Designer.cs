namespace dotnet1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.groupOperations = new System.Windows.Forms.GroupBox();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.labelValueName = new System.Windows.Forms.Label();
            this.labelValueCategory = new System.Windows.Forms.Label();
            this.labelValueSize = new System.Windows.Forms.Label();
            this.labelValuePath = new System.Windows.Forms.Label();
            this.labelNewValueName = new System.Windows.Forms.Label();
            this.labelNewValuePath = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.textBoxNewName = new System.Windows.Forms.TextBox();
            this.textBoxNewPath = new System.Windows.Forms.TextBox();
            this.buttonRename = new System.Windows.Forms.Button();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupInfo.SuspendLayout();
            this.groupOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.textBoxPath);
            this.groupInfo.Controls.Add(this.textBoxSize);
            this.groupInfo.Controls.Add(this.textBoxCategory);
            this.groupInfo.Controls.Add(this.textBoxName);
            this.groupInfo.Controls.Add(this.labelValuePath);
            this.groupInfo.Controls.Add(this.labelValueSize);
            this.groupInfo.Controls.Add(this.labelValueCategory);
            this.groupInfo.Controls.Add(this.labelValueName);
            this.groupInfo.Location = new System.Drawing.Point(253, 12);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(322, 202);
            this.groupInfo.TabIndex = 0;
            this.groupInfo.TabStop = false;
            this.groupInfo.Text = "Информация о выбраном файле";
            // 
            // groupOperations
            // 
            this.groupOperations.Controls.Add(this.buttonAdd);
            this.groupOperations.Controls.Add(this.buttonCopy);
            this.groupOperations.Controls.Add(this.buttonRename);
            this.groupOperations.Controls.Add(this.buttonMove);
            this.groupOperations.Controls.Add(this.textBoxNewPath);
            this.groupOperations.Controls.Add(this.textBoxNewName);
            this.groupOperations.Controls.Add(this.labelNewValuePath);
            this.groupOperations.Controls.Add(this.labelNewValueName);
            this.groupOperations.Location = new System.Drawing.Point(253, 220);
            this.groupOperations.Name = "groupOperations";
            this.groupOperations.Size = new System.Drawing.Size(322, 202);
            this.groupOperations.TabIndex = 1;
            this.groupOperations.TabStop = false;
            this.groupOperations.Text = "Операции";
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(12, 12);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(213, 433);
            this.listBoxFiles.TabIndex = 2;
            // 
            // labelValueName
            // 
            this.labelValueName.AutoSize = true;
            this.labelValueName.Location = new System.Drawing.Point(6, 32);
            this.labelValueName.Name = "labelValueName";
            this.labelValueName.Size = new System.Drawing.Size(32, 13);
            this.labelValueName.TabIndex = 0;
            this.labelValueName.Text = "Имя:";
            // 
            // labelValueCategory
            // 
            this.labelValueCategory.AutoSize = true;
            this.labelValueCategory.Location = new System.Drawing.Point(6, 58);
            this.labelValueCategory.Name = "labelValueCategory";
            this.labelValueCategory.Size = new System.Drawing.Size(63, 13);
            this.labelValueCategory.TabIndex = 1;
            this.labelValueCategory.Text = "Категория:";
            // 
            // labelValueSize
            // 
            this.labelValueSize.AutoSize = true;
            this.labelValueSize.Location = new System.Drawing.Point(6, 84);
            this.labelValueSize.Name = "labelValueSize";
            this.labelValueSize.Size = new System.Drawing.Size(49, 13);
            this.labelValueSize.TabIndex = 2;
            this.labelValueSize.Text = "Размер:";
            // 
            // labelValuePath
            // 
            this.labelValuePath.AutoSize = true;
            this.labelValuePath.Location = new System.Drawing.Point(6, 110);
            this.labelValuePath.Name = "labelValuePath";
            this.labelValuePath.Size = new System.Drawing.Size(82, 13);
            this.labelValuePath.TabIndex = 3;
            this.labelValuePath.Text = "Расположение";
            // 
            // labelNewValueName
            // 
            this.labelNewValueName.AutoSize = true;
            this.labelNewValueName.Location = new System.Drawing.Point(6, 21);
            this.labelNewValueName.Name = "labelNewValueName";
            this.labelNewValueName.Size = new System.Drawing.Size(65, 13);
            this.labelNewValueName.TabIndex = 0;
            this.labelNewValueName.Text = "Новое имя:";
            // 
            // labelNewValuePath
            // 
            this.labelNewValuePath.AutoSize = true;
            this.labelNewValuePath.Location = new System.Drawing.Point(6, 78);
            this.labelNewValuePath.Name = "labelNewValuePath";
            this.labelNewValuePath.Size = new System.Drawing.Size(69, 13);
            this.labelNewValuePath.TabIndex = 1;
            this.labelNewValuePath.Text = "Новый путь:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(103, 29);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(103, 55);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.ReadOnly = true;
            this.textBoxCategory.Size = new System.Drawing.Size(100, 20);
            this.textBoxCategory.TabIndex = 5;
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(103, 81);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.ReadOnly = true;
            this.textBoxSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxSize.TabIndex = 6;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(103, 107);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(100, 20);
            this.textBoxPath.TabIndex = 7;
            // 
            // textBoxNewName
            // 
            this.textBoxNewName.Location = new System.Drawing.Point(103, 18);
            this.textBoxNewName.Name = "textBoxNewName";
            this.textBoxNewName.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewName.TabIndex = 6;
            // 
            // textBoxNewPath
            // 
            this.textBoxNewPath.Location = new System.Drawing.Point(103, 75);
            this.textBoxNewPath.Name = "textBoxNewPath";
            this.textBoxNewPath.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewPath.TabIndex = 7;
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(103, 44);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(100, 23);
            this.buttonRename.TabIndex = 3;
            this.buttonRename.Text = "Переименовать";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(103, 101);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(100, 23);
            this.buttonMove.TabIndex = 4;
            this.buttonMove.Text = "Переместить";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(207, 101);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(100, 23);
            this.buttonCopy.TabIndex = 8;
            this.buttonCopy.Text = "Копировать";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(9, 149);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(307, 23);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Добавить тестовый файл";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 450);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.groupOperations);
            this.Controls.Add(this.groupInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            this.groupOperations.ResumeLayout(false);
            this.groupOperations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelValuePath;
        private System.Windows.Forms.Label labelValueSize;
        private System.Windows.Forms.Label labelValueCategory;
        private System.Windows.Forms.Label labelValueName;
        private System.Windows.Forms.GroupBox groupOperations;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.TextBox textBoxNewPath;
        private System.Windows.Forms.TextBox textBoxNewName;
        private System.Windows.Forms.Label labelNewValuePath;
        private System.Windows.Forms.Label labelNewValueName;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.Button buttonAdd;
    }
}

