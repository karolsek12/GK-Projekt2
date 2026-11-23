namespace GK_Projekt2
{
    partial class DocumentationForm
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
            documentationTextBox = new TextBox();
            SuspendLayout();
            // 
            // documentationTextBox
            // 
            documentationTextBox.BackColor = SystemColors.Window;
            documentationTextBox.Dock = DockStyle.Fill;
            documentationTextBox.Font = new Font("Segoe UI", 12F);
            documentationTextBox.Location = new Point(8, 8);
            documentationTextBox.Multiline = true;
            documentationTextBox.Name = "documentationTextBox";
            documentationTextBox.ReadOnly = true;
            documentationTextBox.ScrollBars = ScrollBars.Vertical;
            documentationTextBox.Size = new Size(784, 434);
            documentationTextBox.TabIndex = 0;
            // 
            // DocumentationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(documentationTextBox);
            MinimumSize = new Size(320, 240);
            Name = "DocumentationForm";
            Padding = new Padding(8);
            Text = "Documentation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox documentationTextBox;
    }
}
