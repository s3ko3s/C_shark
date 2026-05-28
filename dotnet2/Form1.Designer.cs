namespace dotnet2
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
            this.labelRunwayLength = new System.Windows.Forms.Label();
            this.labelTypeFlyingMachine = new System.Windows.Forms.Label();
            this.textBoxRunwayLength = new System.Windows.Forms.TextBox();
            this.comboBoxTypeFlyingMachine = new System.Windows.Forms.ComboBox();
            this.buttonFly = new System.Windows.Forms.Button();
            this.buttonLand = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelRunwayLength
            // 
            this.labelRunwayLength.AutoSize = true;
            this.labelRunwayLength.Location = new System.Drawing.Point(12, 28);
            this.labelRunwayLength.Name = "labelRunwayLength";
            this.labelRunwayLength.Size = new System.Drawing.Size(131, 13);
            this.labelRunwayLength.TabIndex = 0;
            this.labelRunwayLength.Text = "Длина взлетной полосы";
            // 
            // labelTypeFlyingMachine
            // 
            this.labelTypeFlyingMachine.AutoSize = true;
            this.labelTypeFlyingMachine.Location = new System.Drawing.Point(12, 62);
            this.labelTypeFlyingMachine.Name = "labelTypeFlyingMachine";
            this.labelTypeFlyingMachine.Size = new System.Drawing.Size(121, 13);
            this.labelTypeFlyingMachine.TabIndex = 1;
            this.labelTypeFlyingMachine.Text = "Тип воздушного судна";
            // 
            // textBoxRunwayLength
            // 
            this.textBoxRunwayLength.Location = new System.Drawing.Point(161, 28);
            this.textBoxRunwayLength.Name = "textBoxRunwayLength";
            this.textBoxRunwayLength.Size = new System.Drawing.Size(128, 20);
            this.textBoxRunwayLength.TabIndex = 2;
            // 
            // comboBoxTypeFlyingMachine
            // 
            this.comboBoxTypeFlyingMachine.FormattingEnabled = true;
            this.comboBoxTypeFlyingMachine.Location = new System.Drawing.Point(161, 54);
            this.comboBoxTypeFlyingMachine.Name = "comboBoxTypeFlyingMachine";
            this.comboBoxTypeFlyingMachine.Size = new System.Drawing.Size(128, 21);
            this.comboBoxTypeFlyingMachine.TabIndex = 3;
            // 
            // buttonFly
            // 
            this.buttonFly.Location = new System.Drawing.Point(15, 130);
            this.buttonFly.Name = "buttonFly";
            this.buttonFly.Size = new System.Drawing.Size(128, 23);
            this.buttonFly.TabIndex = 4;
            this.buttonFly.Text = "Взлететь";
            this.buttonFly.UseVisualStyleBackColor = true;
            this.buttonFly.Click += new System.EventHandler(this.buttonFly_Click);
            // 
            // buttonLand
            // 
            this.buttonLand.Location = new System.Drawing.Point(160, 130);
            this.buttonLand.Name = "buttonLand";
            this.buttonLand.Size = new System.Drawing.Size(129, 23);
            this.buttonLand.TabIndex = 5;
            this.buttonLand.Text = "Приземлиться";
            this.buttonLand.UseVisualStyleBackColor = true;
            this.buttonLand.Click += new System.EventHandler(this.buttonLane_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 170);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(93, 13);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "Состояние судна";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(15, 186);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(274, 20);
            this.textBoxStatus.TabIndex = 7;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(15, 92);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(274, 21);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonLand);
            this.Controls.Add(this.buttonFly);
            this.Controls.Add(this.comboBoxTypeFlyingMachine);
            this.Controls.Add(this.textBoxRunwayLength);
            this.Controls.Add(this.labelTypeFlyingMachine);
            this.Controls.Add(this.labelRunwayLength);
            this.Name = "Form1";
            this.Text = "Летательный аппарат";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRunwayLength;
        private System.Windows.Forms.Label labelTypeFlyingMachine;
        private System.Windows.Forms.TextBox textBoxRunwayLength;
        private System.Windows.Forms.ComboBox comboBoxTypeFlyingMachine;
        private System.Windows.Forms.Button buttonFly;
        private System.Windows.Forms.Button buttonLand;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Button buttonCreate;
    }
}

