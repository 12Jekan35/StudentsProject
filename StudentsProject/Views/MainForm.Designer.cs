
namespace StudentsProject.Views
{
    partial class MainForm
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
            this.openSpecialtiesButton = new System.Windows.Forms.Button();
            this.openGroupsButton = new System.Windows.Forms.Button();
            this.openStudentsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openSpecialtiesButton
            // 
            this.openSpecialtiesButton.Location = new System.Drawing.Point(13, 13);
            this.openSpecialtiesButton.Name = "openSpecialtiesButton";
            this.openSpecialtiesButton.Size = new System.Drawing.Size(110, 23);
            this.openSpecialtiesButton.TabIndex = 0;
            this.openSpecialtiesButton.Text = "Специальности";
            this.openSpecialtiesButton.UseVisualStyleBackColor = true;
            this.openSpecialtiesButton.Click += new System.EventHandler(this.openSpecialtiesButton_Click);
            // 
            // openGroupsButton
            // 
            this.openGroupsButton.Location = new System.Drawing.Point(13, 42);
            this.openGroupsButton.Name = "openGroupsButton";
            this.openGroupsButton.Size = new System.Drawing.Size(110, 23);
            this.openGroupsButton.TabIndex = 1;
            this.openGroupsButton.Text = "Группы";
            this.openGroupsButton.UseVisualStyleBackColor = true;
            this.openGroupsButton.Click += new System.EventHandler(this.openGroupsButton_Click);
            // 
            // openStudentsButton
            // 
            this.openStudentsButton.Location = new System.Drawing.Point(13, 71);
            this.openStudentsButton.Name = "openStudentsButton";
            this.openStudentsButton.Size = new System.Drawing.Size(110, 23);
            this.openStudentsButton.TabIndex = 2;
            this.openStudentsButton.Text = "Студенты";
            this.openStudentsButton.UseVisualStyleBackColor = true;
            this.openStudentsButton.Click += new System.EventHandler(this.openStudentsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(137, 102);
            this.Controls.Add(this.openStudentsButton);
            this.Controls.Add(this.openGroupsButton);
            this.Controls.Add(this.openSpecialtiesButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openSpecialtiesButton;
        private System.Windows.Forms.Button openGroupsButton;
        private System.Windows.Forms.Button openStudentsButton;
    }
}