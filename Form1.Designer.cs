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
            sidePanel = new Panel();
            Light_Color = new Button();
            label9 = new Label();
            Y_Slider = new TrackBar();
            label8 = new Label();
            X_Slider = new TrackBar();
            label7 = new Label();
            ControlID = new ComboBox();
            label6 = new Label();
            label4 = new Label();
            Bezier_z = new TrackBar();
            Bezier_Curve = new Label();
            Del_Normal = new Button();
            Set_Normal = new Button();
            Image_Button = new Button();
            Color_Button = new Button();
            label5 = new Label();
            CurveID = new ComboBox();
            n_slider = new TrackBar();
            Move_Light = new CheckBox();
            m_slider = new TrackBar();
            label3 = new Label();
            label2 = new Label();
            kd_slider = new TrackBar();
            label1 = new Label();
            ks_slider = new TrackBar();
            Draw_Bezier = new CheckBox();
            Draw_Poly = new CheckBox();
            Draw_Mesh = new CheckBox();
            Fill_Triangles = new CheckBox();
            graphicsBox = new PictureBox();
            mainLayout = new TableLayoutPanel();
            Color_Dialog = new ColorDialog();
            Open_Image = new OpenFileDialog();
            colorDialog1 = new ColorDialog();
            Bezier_File = new OpenFileDialog();
            sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Y_Slider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)X_Slider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Bezier_z).BeginInit();
            ((System.ComponentModel.ISupportInitialize)n_slider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)m_slider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kd_slider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ks_slider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)graphicsBox).BeginInit();
            mainLayout.SuspendLayout();
            SuspendLayout();
            // 
            // sidePanel
            // 
            sidePanel.Controls.Add(Light_Color);
            sidePanel.Controls.Add(label9);
            sidePanel.Controls.Add(Y_Slider);
            sidePanel.Controls.Add(label8);
            sidePanel.Controls.Add(X_Slider);
            sidePanel.Controls.Add(label7);
            sidePanel.Controls.Add(ControlID);
            sidePanel.Controls.Add(label6);
            sidePanel.Controls.Add(label4);
            sidePanel.Controls.Add(Bezier_z);
            sidePanel.Controls.Add(Bezier_Curve);
            sidePanel.Controls.Add(Del_Normal);
            sidePanel.Controls.Add(Set_Normal);
            sidePanel.Controls.Add(Image_Button);
            sidePanel.Controls.Add(Color_Button);
            sidePanel.Controls.Add(label5);
            sidePanel.Controls.Add(CurveID);
            sidePanel.Controls.Add(n_slider);
            sidePanel.Controls.Add(Move_Light);
            sidePanel.Controls.Add(m_slider);
            sidePanel.Controls.Add(label3);
            sidePanel.Controls.Add(label2);
            sidePanel.Controls.Add(kd_slider);
            sidePanel.Controls.Add(label1);
            sidePanel.Controls.Add(ks_slider);
            sidePanel.Controls.Add(Draw_Bezier);
            sidePanel.Controls.Add(Draw_Poly);
            sidePanel.Controls.Add(Draw_Mesh);
            sidePanel.Controls.Add(Fill_Triangles);
            sidePanel.Dock = DockStyle.Fill;
            sidePanel.Location = new Point(700, 0);
            sidePanel.Margin = new Padding(0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(176, 700);
            sidePanel.TabIndex = 2;
            // 
            // Light_Color
            // 
            Light_Color.Location = new Point(3, 583);
            Light_Color.Name = "Light_Color";
            Light_Color.Size = new Size(75, 23);
            Light_Color.TabIndex = 30;
            Light_Color.Text = "Light Color";
            Light_Color.UseVisualStyleBackColor = true;
            Light_Color.Click += Light_Color_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(103, 546);
            label9.Name = "label9";
            label9.Size = new Size(44, 15);
            label9.TabIndex = 29;
            label9.Text = "y (-1:1)";
            // 
            // Y_Slider
            // 
            Y_Slider.Location = new Point(5, 546);
            Y_Slider.Maximum = 100;
            Y_Slider.Name = "Y_Slider";
            Y_Slider.Size = new Size(104, 45);
            Y_Slider.TabIndex = 28;
            Y_Slider.TabStop = false;
            Y_Slider.Value = 100;
            Y_Slider.Scroll += Y_Slider_Scroll;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(103, 504);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 27;
            label8.Text = "x (-1:1)";
            // 
            // X_Slider
            // 
            X_Slider.Location = new Point(5, 504);
            X_Slider.Maximum = 100;
            X_Slider.Name = "X_Slider";
            X_Slider.Size = new Size(104, 45);
            X_Slider.TabIndex = 26;
            X_Slider.TabStop = false;
            X_Slider.Value = 100;
            X_Slider.Scroll += X_Slider_Scroll;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(57, 469);
            label7.Name = "label7";
            label7.Size = new Size(92, 15);
            label7.TabIndex = 25;
            label7.Text = "Control Point ID";
            // 
            // ControlID
            // 
            ControlID.FormattingEnabled = true;
            ControlID.Location = new Point(5, 466);
            ControlID.Name = "ControlID";
            ControlID.Size = new Size(39, 23);
            ControlID.TabIndex = 24;
            ControlID.SelectedIndexChanged += ControlID_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(103, 415);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 23;
            label6.Text = "z (-1:1)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(103, 212);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 22;
            label4.Text = "n (1-20)";
            // 
            // Bezier_z
            // 
            Bezier_z.Location = new Point(5, 415);
            Bezier_z.Maximum = 100;
            Bezier_z.Name = "Bezier_z";
            Bezier_z.Size = new Size(104, 45);
            Bezier_z.TabIndex = 20;
            Bezier_z.TabStop = false;
            Bezier_z.Value = 100;
            Bezier_z.Scroll += Bezier_z_Scroll;
            // 
            // Bezier_Curve
            // 
            Bezier_Curve.AutoSize = true;
            Bezier_Curve.Location = new Point(3, 387);
            Bezier_Curve.Name = "Bezier_Curve";
            Bezier_Curve.Size = new Size(105, 15);
            Bezier_Curve.TabIndex = 19;
            Bezier_Curve.Text = "Light Bezier Curve:";
            // 
            // Del_Normal
            // 
            Del_Normal.Enabled = false;
            Del_Normal.Location = new Point(89, 346);
            Del_Normal.Name = "Del_Normal";
            Del_Normal.Size = new Size(75, 23);
            Del_Normal.TabIndex = 18;
            Del_Normal.Text = "Del Normal";
            Del_Normal.UseVisualStyleBackColor = true;
            Del_Normal.Click += Del_Normal_Click;
            // 
            // Set_Normal
            // 
            Set_Normal.Location = new Point(3, 346);
            Set_Normal.Name = "Set_Normal";
            Set_Normal.Size = new Size(75, 23);
            Set_Normal.TabIndex = 17;
            Set_Normal.Text = "Set Normal";
            Set_Normal.UseVisualStyleBackColor = true;
            Set_Normal.Click += Set_Normal_Click;
            // 
            // Image_Button
            // 
            Image_Button.Location = new Point(89, 317);
            Image_Button.Name = "Image_Button";
            Image_Button.Size = new Size(75, 23);
            Image_Button.TabIndex = 16;
            Image_Button.Text = "Set Image";
            Image_Button.UseVisualStyleBackColor = true;
            Image_Button.Click += Image_Button_Click;
            // 
            // Color_Button
            // 
            Color_Button.Location = new Point(3, 317);
            Color_Button.Name = "Color_Button";
            Color_Button.Size = new Size(75, 23);
            Color_Button.TabIndex = 15;
            Color_Button.Text = "Set Color";
            Color_Button.UseVisualStyleBackColor = true;
            Color_Button.Click += Color_Button_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(57, 291);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 14;
            label5.Text = "Curve ID";
            // 
            // CurveID
            // 
            CurveID.FormattingEnabled = true;
            CurveID.Location = new Point(3, 288);
            CurveID.Name = "CurveID";
            CurveID.Size = new Size(39, 23);
            CurveID.TabIndex = 13;
            CurveID.SelectedIndexChanged += CurveID_SelectedIndexChanged;
            // 
            // n_slider
            // 
            n_slider.Location = new Point(3, 212);
            n_slider.Maximum = 20;
            n_slider.Minimum = 1;
            n_slider.Name = "n_slider";
            n_slider.Size = new Size(104, 45);
            n_slider.TabIndex = 11;
            n_slider.TabStop = false;
            n_slider.Value = 20;
            n_slider.Scroll += n_slider_Scroll;
            // 
            // Move_Light
            // 
            Move_Light.AutoSize = true;
            Move_Light.Checked = true;
            Move_Light.CheckState = CheckState.Checked;
            Move_Light.Location = new Point(3, 263);
            Move_Light.Name = "Move_Light";
            Move_Light.Size = new Size(86, 19);
            Move_Light.TabIndex = 3;
            Move_Light.Text = "Move Light";
            Move_Light.UseVisualStyleBackColor = true;
            Move_Light.CheckedChanged += Move_Light_CheckedChanged;
            // 
            // m_slider
            // 
            m_slider.Location = new Point(3, 176);
            m_slider.Maximum = 100;
            m_slider.Minimum = 1;
            m_slider.Name = "m_slider";
            m_slider.Size = new Size(104, 45);
            m_slider.TabIndex = 10;
            m_slider.TabStop = false;
            m_slider.Value = 1;
            m_slider.Scroll += m_slider_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(103, 176);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 9;
            label3.Text = "m (1-100)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 140);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 7;
            label2.Text = "kd (0.0-1.0)";
            // 
            // kd_slider
            // 
            kd_slider.Location = new Point(3, 140);
            kd_slider.Maximum = 100;
            kd_slider.Name = "kd_slider";
            kd_slider.Size = new Size(104, 45);
            kd_slider.TabIndex = 6;
            kd_slider.TabStop = false;
            kd_slider.Value = 50;
            kd_slider.Scroll += kd_slider_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 103);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 5;
            label1.Text = "ks (0.0-1.0)";
            // 
            // ks_slider
            // 
            ks_slider.Location = new Point(3, 103);
            ks_slider.Maximum = 100;
            ks_slider.Name = "ks_slider";
            ks_slider.Size = new Size(104, 45);
            ks_slider.TabIndex = 4;
            ks_slider.TabStop = false;
            ks_slider.Value = 50;
            ks_slider.Scroll += ks_slider_Scroll;
            // 
            // Draw_Bezier
            // 
            Draw_Bezier.AutoSize = true;
            Draw_Bezier.Checked = true;
            Draw_Bezier.CheckState = CheckState.Checked;
            Draw_Bezier.Location = new Point(3, 78);
            Draw_Bezier.Name = "Draw_Bezier";
            Draw_Bezier.Size = new Size(87, 19);
            Draw_Bezier.TabIndex = 3;
            Draw_Bezier.Text = "Draw Bezier";
            Draw_Bezier.UseVisualStyleBackColor = true;
            Draw_Bezier.CheckedChanged += Draw_Bezier_CheckedChanged;
            // 
            // Draw_Poly
            // 
            Draw_Poly.AutoSize = true;
            Draw_Poly.Checked = true;
            Draw_Poly.CheckState = CheckState.Checked;
            Draw_Poly.Location = new Point(3, 53);
            Draw_Poly.Name = "Draw_Poly";
            Draw_Poly.Size = new Size(79, 19);
            Draw_Poly.TabIndex = 2;
            Draw_Poly.Text = "Draw Poly";
            Draw_Poly.UseVisualStyleBackColor = true;
            Draw_Poly.CheckedChanged += Draw_Poly_CheckedChanged;
            // 
            // Draw_Mesh
            // 
            Draw_Mesh.AutoSize = true;
            Draw_Mesh.Checked = true;
            Draw_Mesh.CheckState = CheckState.Checked;
            Draw_Mesh.Location = new Point(3, 28);
            Draw_Mesh.Name = "Draw_Mesh";
            Draw_Mesh.Size = new Size(85, 19);
            Draw_Mesh.TabIndex = 1;
            Draw_Mesh.Text = "Draw Mesh";
            Draw_Mesh.UseVisualStyleBackColor = true;
            Draw_Mesh.CheckedChanged += Draw_Mesh_CheckedChanged;
            // 
            // Fill_Triangles
            // 
            Fill_Triangles.AutoSize = true;
            Fill_Triangles.Checked = true;
            Fill_Triangles.CheckState = CheckState.Checked;
            Fill_Triangles.Location = new Point(3, 3);
            Fill_Triangles.Name = "Fill_Triangles";
            Fill_Triangles.Size = new Size(90, 19);
            Fill_Triangles.TabIndex = 0;
            Fill_Triangles.Text = "Fill Triangles";
            Fill_Triangles.UseVisualStyleBackColor = true;
            Fill_Triangles.CheckedChanged += Fill_Triangles_CheckedChanged;
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
            // Open_Image
            // 
            Open_Image.FileName = "Opened_Image";
            // 
            // Bezier_File
            // 
            Bezier_File.FileName = "Open_Bezier_File";
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
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Y_Slider).EndInit();
            ((System.ComponentModel.ISupportInitialize)X_Slider).EndInit();
            ((System.ComponentModel.ISupportInitialize)Bezier_z).EndInit();
            ((System.ComponentModel.ISupportInitialize)n_slider).EndInit();
            ((System.ComponentModel.ISupportInitialize)m_slider).EndInit();
            ((System.ComponentModel.ISupportInitialize)kd_slider).EndInit();
            ((System.ComponentModel.ISupportInitialize)ks_slider).EndInit();
            ((System.ComponentModel.ISupportInitialize)graphicsBox).EndInit();
            mainLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel sidePanel;
        private TrackBar n_slider;
        private CheckBox Move_Light;
        private TrackBar m_slider;
        private Label label3;
        private Label label2;
        private TrackBar kd_slider;
        private Label label1;
        private TrackBar ks_slider;
        private CheckBox Draw_Bezier;
        private CheckBox Draw_Poly;
        private CheckBox Draw_Mesh;
        private CheckBox Fill_Triangles;
        private PictureBox graphicsBox;
        private TableLayoutPanel mainLayout;
        private Label label5;
        private ComboBox CurveID;
        private Button Color_Button;
        private ColorDialog Color_Dialog;
        private Button Image_Button;
        private OpenFileDialog Open_Image;
        private Button Del_Normal;
        private Button Set_Normal;
        private ColorDialog colorDialog1;
        private TrackBar Bezier_z;
        private Label Bezier_Curve;
        private Label label4;
        private Label label6;
        private Label label9;
        private TrackBar Y_Slider;
        private Label label8;
        private TrackBar X_Slider;
        private Label label7;
        private ComboBox ControlID;
        private Button Light_Color;
        private OpenFileDialog Bezier_File;
    }
}
