namespace Diyers_System
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            btn_verProductos = new ReaLTaiizor.Controls.FoxButton();
            foxButton1 = new ReaLTaiizor.Controls.FoxButton();
            foxButton2 = new ReaLTaiizor.Controls.FoxButton();
            foxButton3 = new ReaLTaiizor.Controls.FoxButton();
            pictureBox1 = new PictureBox();
            btn_Cerrar = new ReaLTaiizor.Controls.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_verProductos
            // 
            btn_verProductos.BackColor = Color.Transparent;
            btn_verProductos.BaseColor = Color.FromArgb(249, 249, 249);
            btn_verProductos.BorderColor = Color.FromArgb(193, 193, 193);
            btn_verProductos.DisabledBaseColor = Color.FromArgb(15, 30, 19);
            btn_verProductos.DisabledBorderColor = Color.FromArgb(15, 30, 19);
            btn_verProductos.DisabledTextColor = Color.White;
            btn_verProductos.DownColor = Color.FromArgb(232, 232, 232);
            btn_verProductos.EnabledCalc = true;
            btn_verProductos.Font = new Font("MADE TOMMY", 11.9999981F, FontStyle.Bold);
            btn_verProductos.ForeColor = Color.FromArgb(56, 56, 56);
            btn_verProductos.Location = new Point(108, 259);
            btn_verProductos.Name = "btn_verProductos";
            btn_verProductos.OverColor = Color.FromArgb(224, 224, 224);
            btn_verProductos.Size = new Size(281, 40);
            btn_verProductos.TabIndex = 0;
            btn_verProductos.Text = "VER PRODUCTOS";
            btn_verProductos.Click += btn_verProductos_Click;
            // 
            // foxButton1
            // 
            foxButton1.BackColor = Color.Transparent;
            foxButton1.BaseColor = Color.FromArgb(249, 249, 249);
            foxButton1.BorderColor = Color.FromArgb(193, 193, 193);
            foxButton1.DisabledBaseColor = Color.FromArgb(249, 249, 249);
            foxButton1.DisabledBorderColor = Color.FromArgb(209, 209, 209);
            foxButton1.DisabledTextColor = Color.FromArgb(166, 178, 190);
            foxButton1.DownColor = Color.FromArgb(232, 232, 232);
            foxButton1.Enabled = false;
            foxButton1.EnabledCalc = false;
            foxButton1.Font = new Font("MADE TOMMY", 11.9999981F, FontStyle.Bold);
            foxButton1.ForeColor = Color.FromArgb(56, 56, 56);
            foxButton1.Location = new Point(108, 315);
            foxButton1.Name = "foxButton1";
            foxButton1.OverColor = Color.FromArgb(242, 242, 242);
            foxButton1.Size = new Size(281, 40);
            foxButton1.TabIndex = 1;
            foxButton1.Text = "COTIZAR";
            // 
            // foxButton2
            // 
            foxButton2.BackColor = Color.Transparent;
            foxButton2.BaseColor = Color.FromArgb(249, 249, 249);
            foxButton2.BorderColor = Color.FromArgb(193, 193, 193);
            foxButton2.DisabledBaseColor = Color.FromArgb(249, 249, 249);
            foxButton2.DisabledBorderColor = Color.FromArgb(209, 209, 209);
            foxButton2.DisabledTextColor = Color.FromArgb(166, 178, 190);
            foxButton2.DownColor = Color.FromArgb(232, 232, 232);
            foxButton2.Enabled = false;
            foxButton2.EnabledCalc = false;
            foxButton2.Font = new Font("MADE TOMMY", 11.9999981F, FontStyle.Bold);
            foxButton2.ForeColor = Color.FromArgb(56, 56, 56);
            foxButton2.Location = new Point(108, 372);
            foxButton2.Name = "foxButton2";
            foxButton2.OverColor = Color.FromArgb(242, 242, 242);
            foxButton2.Size = new Size(281, 40);
            foxButton2.TabIndex = 2;
            foxButton2.Text = "PEDIDOS";
            // 
            // foxButton3
            // 
            foxButton3.BackColor = Color.Transparent;
            foxButton3.BaseColor = Color.FromArgb(249, 249, 249);
            foxButton3.BorderColor = Color.FromArgb(193, 193, 193);
            foxButton3.DisabledBaseColor = Color.FromArgb(249, 249, 249);
            foxButton3.DisabledBorderColor = Color.FromArgb(209, 209, 209);
            foxButton3.DisabledTextColor = Color.FromArgb(166, 178, 190);
            foxButton3.DownColor = Color.FromArgb(232, 232, 232);
            foxButton3.Enabled = false;
            foxButton3.EnabledCalc = false;
            foxButton3.Font = new Font("MADE TOMMY", 11.9999981F, FontStyle.Bold);
            foxButton3.ForeColor = Color.FromArgb(56, 56, 56);
            foxButton3.Location = new Point(108, 429);
            foxButton3.Name = "foxButton3";
            foxButton3.OverColor = Color.FromArgb(242, 242, 242);
            foxButton3.Size = new Size(281, 40);
            foxButton3.TabIndex = 3;
            foxButton3.Text = "EXPORTAR";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(37, 60);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(431, 183);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // btn_Cerrar
            // 
            btn_Cerrar.BackColor = Color.FromArgb(247, 236, 234);
            btn_Cerrar.BorderColor = Color.FromArgb(247, 236, 234);
            btn_Cerrar.EnteredBorderColor = Color.FromArgb(239, 192, 74);
            btn_Cerrar.EnteredColor = Color.FromArgb(239, 192, 74);
            btn_Cerrar.Font = new Font("Microsoft Sans Serif", 12F);
            btn_Cerrar.Image = (Image)resources.GetObject("btn_Cerrar.Image");
            btn_Cerrar.ImageAlign = ContentAlignment.MiddleCenter;
            btn_Cerrar.InactiveColor = Color.FromArgb(247, 236, 234);
            btn_Cerrar.Location = new Point(463, -1);
            btn_Cerrar.Name = "btn_Cerrar";
            btn_Cerrar.PressedBorderColor = Color.FromArgb(247, 236, 234);
            btn_Cerrar.PressedColor = Color.FromArgb(247, 236, 234);
            btn_Cerrar.Size = new Size(48, 45);
            btn_Cerrar.TabIndex = 38;
            btn_Cerrar.TextAlignment = StringAlignment.Center;
            btn_Cerrar.Click += btn_Cerrar_Click_1;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 236, 234);
            ClientSize = new Size(510, 542);
            Controls.Add(btn_Cerrar);
            Controls.Add(pictureBox1);
            Controls.Add(foxButton3);
            Controls.Add(foxButton2);
            Controls.Add(foxButton1);
            Controls.Add(btn_verProductos);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Menu";
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.FoxButton btn_verProductos;
        private ReaLTaiizor.Controls.FoxButton foxButton1;
        private ReaLTaiizor.Controls.FoxButton foxButton2;
        private ReaLTaiizor.Controls.FoxButton foxButton3;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.Button btn_Cerrar;
    }
}