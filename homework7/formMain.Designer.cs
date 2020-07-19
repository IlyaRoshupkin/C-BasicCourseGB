namespace homework7
{
    partial class formMain
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
            this.btnCommand1 = new System.Windows.Forms.Button();
            this.btnCommand2 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.labelNumber = new System.Windows.Forms.Label();
            this.lblNameOfCounter = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblRemind = new System.Windows.Forms.Label();
            this.lblStepsRest = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCansel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCommand1
            // 
            this.btnCommand1.Enabled = false;
            this.btnCommand1.Location = new System.Drawing.Point(157, 11);
            this.btnCommand1.Name = "btnCommand1";
            this.btnCommand1.Size = new System.Drawing.Size(93, 30);
            this.btnCommand1.TabIndex = 0;
            this.btnCommand1.Text = "+1";
            this.btnCommand1.UseVisualStyleBackColor = true;
            this.btnCommand1.Click += new System.EventHandler(this.btnCommand1_Click);
            // 
            // btnCommand2
            // 
            this.btnCommand2.Enabled = false;
            this.btnCommand2.Location = new System.Drawing.Point(157, 47);
            this.btnCommand2.Name = "btnCommand2";
            this.btnCommand2.Size = new System.Drawing.Size(93, 30);
            this.btnCommand2.TabIndex = 1;
            this.btnCommand2.Text = "x2";
            this.btnCommand2.UseVisualStyleBackColor = true;
            this.btnCommand2.Click += new System.EventHandler(this.btnCommand2_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(157, 83);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(93, 30);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Очистить";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(12, 18);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(16, 17);
            this.labelNumber.TabIndex = 3;
            this.labelNumber.Text = "1";
            // 
            // lblNameOfCounter
            // 
            this.lblNameOfCounter.AutoSize = true;
            this.lblNameOfCounter.Location = new System.Drawing.Point(12, 198);
            this.lblNameOfCounter.Name = "lblNameOfCounter";
            this.lblNameOfCounter.Size = new System.Drawing.Size(162, 17);
            this.lblNameOfCounter.TabIndex = 4;
            this.lblNameOfCounter.Text = "Количество операций: ";
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(180, 198);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(16, 17);
            this.lblCounter.TabIndex = 5;
            this.lblCounter.Text = "0";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(12, 84);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(78, 30);
            this.btnPlay.TabIndex = 6;
            this.btnPlay.Text = "Играть";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblRemind
            // 
            this.lblRemind.AutoSize = true;
            this.lblRemind.Location = new System.Drawing.Point(12, 172);
            this.lblRemind.Name = "lblRemind";
            this.lblRemind.Size = new System.Drawing.Size(75, 17);
            this.lblRemind.TabIndex = 7;
            this.lblRemind.Text = "Осталось:";
            // 
            // lblStepsRest
            // 
            this.lblStepsRest.AutoSize = true;
            this.lblStepsRest.Location = new System.Drawing.Point(93, 172);
            this.lblStepsRest.Name = "lblStepsRest";
            this.lblStepsRest.Size = new System.Drawing.Size(16, 17);
            this.lblStepsRest.TabIndex = 8;
            this.lblStepsRest.Text = "0";
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(64, 48);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(16, 17);
            this.lblTask.TabIndex = 9;
            this.lblTask.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Цель:";
            // 
            // btnCansel
            // 
            this.btnCansel.Enabled = false;
            this.btnCansel.Location = new System.Drawing.Point(157, 119);
            this.btnCansel.Name = "btnCansel";
            this.btnCansel.Size = new System.Drawing.Size(93, 29);
            this.btnCansel.TabIndex = 11;
            this.btnCansel.Text = "Отменить";
            this.btnCansel.UseVisualStyleBackColor = true;
            this.btnCansel.Click += new System.EventHandler(this.btnCansel_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 248);
            this.Controls.Add(this.btnCansel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.lblStepsRest);
            this.Controls.Add(this.lblRemind);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblNameOfCounter);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCommand2);
            this.Controls.Add(this.btnCommand1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formMain";
            this.Text = "Удвоитель";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCommand1;
        private System.Windows.Forms.Button btnCommand2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Label lblNameOfCounter;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblRemind;
        private System.Windows.Forms.Label lblStepsRest;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCansel;
    }
}

