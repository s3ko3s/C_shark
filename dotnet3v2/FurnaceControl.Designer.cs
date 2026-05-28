namespace dotnet3v2
{
    partial class FurnaceControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblTempValue;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblMaterialValue;
        private System.Windows.Forms.ProgressBar tempProgress;
        private System.Windows.Forms.ProgressBar materialProgress;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblWorkers;
        private System.Windows.Forms.Button btnAddWorker;
        private System.Windows.Forms.Button btnRemoveWorker;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblName = new Label();
            lblTemp = new Label();
            lblTempValue = new Label();
            lblMaterial = new Label();
            lblMaterialValue = new Label();
            tempProgress = new ProgressBar();
            materialProgress = new ProgressBar();
            btnStart = new Button();
            btnStop = new Button();
            lblWorkers = new Label();
            btnAddWorker = new Button();
            btnRemoveWorker = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            lblName.Location = new Point(9, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(70, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Печь имя";
            // 
            // lblTemp
            // 
            lblTemp.AutoSize = true;
            lblTemp.Location = new Point(9, 38);
            lblTemp.Name = "lblTemp";
            lblTemp.Size = new Size(81, 15);
            lblTemp.TabIndex = 1;
            lblTemp.Text = "Температура:";
            // 
            // lblTempValue
            // 
            lblTempValue.AutoSize = true;
            lblTempValue.Location = new Point(88, 38);
            lblTempValue.Name = "lblTempValue";
            lblTempValue.Size = new Size(26, 15);
            lblTempValue.TabIndex = 2;
            lblTempValue.Text = "0°C";
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Location = new Point(9, 66);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(65, 15);
            lblMaterial.TabIndex = 4;
            lblMaterial.Text = "Материал:";
            // 
            // lblMaterialValue
            // 
            lblMaterialValue.AutoSize = true;
            lblMaterialValue.Location = new Point(88, 66);
            lblMaterialValue.Name = "lblMaterialValue";
            lblMaterialValue.Size = new Size(13, 15);
            lblMaterialValue.TabIndex = 5;
            lblMaterialValue.Text = "0";
            // 
            // tempProgress
            // 
            tempProgress.Location = new Point(131, 38);
            tempProgress.Name = "tempProgress";
            tempProgress.Size = new Size(175, 22);
            tempProgress.TabIndex = 3;
            // 
            // materialProgress
            // 
            materialProgress.Location = new Point(131, 66);
            materialProgress.Name = "materialProgress";
            materialProgress.Size = new Size(175, 22);
            materialProgress.TabIndex = 6;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(312, 38);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(70, 22);
            btnStart.TabIndex = 7;
            btnStart.Text = "Старт";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(312, 66);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(70, 22);
            btnStop.TabIndex = 8;
            btnStop.Text = "Стоп";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblWorkers
            // 
            lblWorkers.AutoSize = true;
            lblWorkers.Location = new Point(9, 98);
            lblWorkers.Name = "lblWorkers";
            lblWorkers.Size = new Size(66, 15);
            lblWorkers.TabIndex = 9;
            lblWorkers.Text = "Рабочих: 0";
            // 
            // btnAddWorker
            // 
            btnAddWorker.Location = new Point(88, 94);
            btnAddWorker.Name = "btnAddWorker";
            btnAddWorker.Size = new Size(26, 23);
            btnAddWorker.TabIndex = 10;
            btnAddWorker.Text = "+";
            btnAddWorker.UseVisualStyleBackColor = true;
            btnAddWorker.Click += btnAddWorker_Click;
            // 
            // btnRemoveWorker
            // 
            btnRemoveWorker.Location = new Point(120, 94);
            btnRemoveWorker.Name = "btnRemoveWorker";
            btnRemoveWorker.Size = new Size(26, 23);
            btnRemoveWorker.TabIndex = 11;
            btnRemoveWorker.Text = "-";
            btnRemoveWorker.UseVisualStyleBackColor = true;
            btnRemoveWorker.Click += btnRemoveWorker_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(312, 94);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(70, 22);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // FurnaceControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnDelete);
            Controls.Add(btnRemoveWorker);
            Controls.Add(btnAddWorker);
            Controls.Add(lblWorkers);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(materialProgress);
            Controls.Add(lblMaterialValue);
            Controls.Add(lblMaterial);
            Controls.Add(tempProgress);
            Controls.Add(lblTempValue);
            Controls.Add(lblTemp);
            Controls.Add(lblName);
            Name = "FurnaceControl";
            Size = new Size(420, 122);
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnDelete;
    }
}