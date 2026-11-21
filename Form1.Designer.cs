namespace GK_Projekt2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            mainLayout = new TableLayoutPanel();
            graphicsBox = new PictureBox();
            sidePanel = new Panel();
            mainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)graphicsBox).BeginInit();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            mainLayout.Controls.Add(graphicsBox, 0, 0);
            mainLayout.Controls.Add(sidePanel, 1, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Margin = new Padding(0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 1;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(876, 700);
            mainLayout.TabIndex = 0;
            // 
            // graphicsBox
            // 
            graphicsBox.BackColor = Color.White;
            graphicsBox.BorderStyle = BorderStyle.FixedSingle;
            graphicsBox.Dock = DockStyle.Fill;
            graphicsBox.Location = new Point(0, 0);
            graphicsBox.Margin = new Padding(0);
            graphicsBox.Name = "graphicsBox";
            graphicsBox.Size = new Size(700, 700);
            graphicsBox.SizeMode = PictureBoxSizeMode.StretchImage;
            graphicsBox.TabIndex = 1;
            graphicsBox.TabStop = false;
            // 
            // sidePanel
            // 
            sidePanel.Dock = DockStyle.Fill;
            sidePanel.Location = new Point(700, 0);
            sidePanel.Margin = new Padding(0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(176, 700);
            sidePanel.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(876, 700);
            Controls.Add(mainLayout);
            MaximumSize = new Size(892, 739);
            MinimumSize = new Size(892, 739);
            Name = "Form1";
            Text = "Form1";
            mainLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)graphicsBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.PictureBox graphicsBox;
        private System.Windows.Forms.Panel sidePanel;
    }
}
