namespace SudokuSolverWindowsForms
{
    partial class Form1
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
            this.BtnFileUpload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnFileUpload
            // 
            this.BtnFileUpload.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BtnFileUpload.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.BtnFileUpload.FlatAppearance.BorderSize = 2;
            this.BtnFileUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFileUpload.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFileUpload.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnFileUpload.Location = new System.Drawing.Point(286, 12);
            this.BtnFileUpload.Name = "BtnFileUpload";
            this.BtnFileUpload.Size = new System.Drawing.Size(243, 37);
            this.BtnFileUpload.TabIndex = 0;
            this.BtnFileUpload.Text = "Click To Select Text File";
            this.BtnFileUpload.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnFileUpload.UseVisualStyleBackColor = false;
            this.BtnFileUpload.Click += new System.EventHandler(this.BtnFileUpload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnFileUpload);
            this.Name = "Form1";
            this.Text = "SudokuSolverBackground";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnFileUpload;
    }
}

