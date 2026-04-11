namespace Diyers_System
{
    partial class form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
            lbl_Dolar = new Label();
            txt_Dolar = new TextBox();
            btn_Editar = new Button();
            lbl_Categoria = new Label();
            button6 = new Button();
            txt_Busqueda = new TextBox();
            listView1 = new ListView();
            label1 = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            button1 = new Button();
            button2 = new Button();
            btn_Ferreteria = new ReaLTaiizor.Controls.RoyalEllipseButton();
            btn_Pintura = new ReaLTaiizor.Controls.RoyalEllipseButton();
            btn_Maderas = new ReaLTaiizor.Controls.RoyalEllipseButton();
            btn_Todas = new ReaLTaiizor.Controls.RoyalEllipseButton();
            btn_Instalaciones = new ReaLTaiizor.Controls.RoyalEllipseButton();
            btnConstruccion = new ReaLTaiizor.Controls.RoyalEllipseButton();
            SuspendLayout();
            // 
            // lbl_Dolar
            // 
            lbl_Dolar.AutoSize = true;
            lbl_Dolar.Font = new Font("MADE TOMMY", 21.7499962F, FontStyle.Bold);
            lbl_Dolar.ForeColor = Color.FromArgb(56, 56, 56);
            lbl_Dolar.Location = new Point(54, 39);
            lbl_Dolar.Name = "lbl_Dolar";
            lbl_Dolar.Size = new Size(114, 36);
            lbl_Dolar.TabIndex = 0;
            lbl_Dolar.Text = "DÓLAR";
            // 
            // txt_Dolar
            // 
            txt_Dolar.BackColor = Color.FromArgb(231, 228, 216);
            txt_Dolar.BorderStyle = BorderStyle.None;
            txt_Dolar.Enabled = false;
            txt_Dolar.Font = new Font("MADE TOMMY", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_Dolar.ForeColor = Color.FromArgb(44, 30, 155);
            txt_Dolar.Location = new Point(62, 85);
            txt_Dolar.Name = "txt_Dolar";
            txt_Dolar.Size = new Size(153, 27);
            txt_Dolar.TabIndex = 1;
            txt_Dolar.Text = "$ 1433";
            // 
            // btn_Editar
            // 
            btn_Editar.BackColor = Color.FromArgb(239, 192, 74);
            btn_Editar.FlatStyle = FlatStyle.Flat;
            btn_Editar.Location = new Point(221, 85);
            btn_Editar.Name = "btn_Editar";
            btn_Editar.Size = new Size(54, 29);
            btn_Editar.TabIndex = 2;
            btn_Editar.TabStop = false;
            btn_Editar.Text = "Editar";
            btn_Editar.UseVisualStyleBackColor = false;
            btn_Editar.Click += button1_Click;
            // 
            // lbl_Categoria
            // 
            lbl_Categoria.AutoSize = true;
            lbl_Categoria.Font = new Font("MADE TOMMY", 21.7499962F, FontStyle.Bold);
            lbl_Categoria.ForeColor = Color.FromArgb(56, 56, 56);
            lbl_Categoria.Location = new Point(53, 161);
            lbl_Categoria.Name = "lbl_Categoria";
            lbl_Categoria.Size = new Size(181, 36);
            lbl_Categoria.TabIndex = 3;
            lbl_Categoria.Text = "CATEGORÍA";
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(239, 192, 74);
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(396, 86);
            button6.Name = "button6";
            button6.Size = new Size(188, 29);
            button6.TabIndex = 10;
            button6.TabStop = false;
            button6.Text = "Exportar Datos";
            button6.UseVisualStyleBackColor = false;
            // 
            // txt_Busqueda
            // 
            txt_Busqueda.BackColor = Color.FromArgb(231, 228, 216);
            txt_Busqueda.BorderStyle = BorderStyle.None;
            txt_Busqueda.CharacterCasing = CharacterCasing.Upper;
            txt_Busqueda.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_Busqueda.Location = new Point(72, 307);
            txt_Busqueda.Name = "txt_Busqueda";
            txt_Busqueda.Size = new Size(349, 26);
            txt_Busqueda.TabIndex = 11;
            txt_Busqueda.TextChanged += txt_Busqueda_TextChanged;
            txt_Busqueda.KeyDown += txt_Busqueda_KeyDown;
            // 
            // listView1
            // 
            listView1.BackColor = Color.FromArgb(247, 236, 234);
            listView1.BorderStyle = BorderStyle.None;
            listView1.Font = new Font("MADE TOMMY", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listView1.ForeColor = Color.FromArgb(56, 56, 56);
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(72, 392);
            listView1.Name = "listView1";
            listView1.Size = new Size(349, 287);
            listView1.TabIndex = 13;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Tile;
            listView1.DoubleClick += listView1_DoubleClick;
            listView1.KeyDown += listView1_KeyDown;
            listView1.MouseClick += listView1_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MADE TOMMY", 11.9999981F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(44, 30, 155);
            label1.Location = new Point(72, 360);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 14;
            label1.Text = "Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MADE TOMMY", 11.9999981F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(44, 30, 155);
            label2.Location = new Point(348, 360);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 15;
            label2.Text = "Detalle";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(357, 680);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(56, 15);
            linkLabel1.TabIndex = 16;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Siguiente";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(73, 681);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(50, 15);
            linkLabel2.TabIndex = 17;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Anterior";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(247, 236, 234);
            panel1.Location = new Point(476, 46);
            panel1.Name = "panel1";
            panel1.Size = new Size(19, 21);
            panel1.TabIndex = 19;
            panel1.Visible = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(56, 56, 56);
            panel2.Location = new Point(501, 46);
            panel2.Name = "panel2";
            panel2.Size = new Size(19, 21);
            panel2.TabIndex = 20;
            panel2.Visible = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(44, 30, 155);
            panel3.Location = new Point(526, 46);
            panel3.Name = "panel3";
            panel3.Size = new Size(19, 21);
            panel3.TabIndex = 21;
            panel3.Visible = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(239, 192, 74);
            panel4.Location = new Point(552, 46);
            panel4.Name = "panel4";
            panel4.Size = new Size(19, 21);
            panel4.TabIndex = 22;
            panel4.Visible = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(239, 192, 74);
            panel5.Location = new Point(33, 39);
            panel5.Name = "panel5";
            panel5.Size = new Size(15, 73);
            panel5.TabIndex = 23;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(239, 192, 74);
            panel6.Location = new Point(33, 160);
            panel6.Name = "panel6";
            panel6.Size = new Size(15, 39);
            panel6.TabIndex = 24;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("MADE TOMMY", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(530, -1);
            button1.Name = "button1";
            button1.Size = new Size(54, 31);
            button1.TabIndex = 25;
            button1.TabStop = false;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_2;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("MADE TOMMY", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(56, 56, 56);
            button2.Location = new Point(477, -1);
            button2.Name = "button2";
            button2.Size = new Size(54, 31);
            button2.TabIndex = 26;
            button2.TabStop = false;
            button2.Text = "-";
            button2.UseVisualStyleBackColor = false;
            // 
            // btn_Ferreteria
            // 
            btn_Ferreteria.BackColor = Color.FromArgb(247, 236, 234);
            btn_Ferreteria.BorderColor = Color.FromArgb(180, 180, 180);
            btn_Ferreteria.BorderThickness = 3;
            btn_Ferreteria.DrawBorder = true;
            btn_Ferreteria.ForeColor = Color.FromArgb(31, 31, 31);
            btn_Ferreteria.HotTrackColor = Color.White;
            btn_Ferreteria.Image = (Image)resources.GetObject("btn_Ferreteria.Image");
            btn_Ferreteria.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageOnly;
            btn_Ferreteria.Location = new Point(65, 216);
            btn_Ferreteria.Name = "btn_Ferreteria";
            btn_Ferreteria.PressedColor = Color.Gainsboro;
            btn_Ferreteria.PressedForeColor = Color.White;
            btn_Ferreteria.Size = new Size(60, 60);
            btn_Ferreteria.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            btn_Ferreteria.TabIndex = 27;
            btn_Ferreteria.Click += btn_Ferreteria_Click;
            // 
            // btn_Pintura
            // 
            btn_Pintura.BackColor = Color.FromArgb(247, 236, 234);
            btn_Pintura.BorderColor = Color.FromArgb(180, 180, 180);
            btn_Pintura.BorderThickness = 3;
            btn_Pintura.DrawBorder = true;
            btn_Pintura.ForeColor = Color.FromArgb(31, 31, 31);
            btn_Pintura.HotTrackColor = Color.White;
            btn_Pintura.Image = (Image)resources.GetObject("btn_Pintura.Image");
            btn_Pintura.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageOnly;
            btn_Pintura.Location = new Point(135, 216);
            btn_Pintura.Name = "btn_Pintura";
            btn_Pintura.PressedColor = Color.Gainsboro;
            btn_Pintura.PressedForeColor = Color.White;
            btn_Pintura.Size = new Size(60, 60);
            btn_Pintura.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            btn_Pintura.TabIndex = 28;
            btn_Pintura.Click += btn_Pintura_Click;
            // 
            // btn_Maderas
            // 
            btn_Maderas.BackColor = Color.FromArgb(247, 236, 234);
            btn_Maderas.BorderColor = Color.FromArgb(180, 180, 180);
            btn_Maderas.BorderThickness = 3;
            btn_Maderas.DrawBorder = true;
            btn_Maderas.ForeColor = Color.FromArgb(31, 31, 31);
            btn_Maderas.HotTrackColor = Color.White;
            btn_Maderas.Image = (Image)resources.GetObject("btn_Maderas.Image");
            btn_Maderas.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageOnly;
            btn_Maderas.Location = new Point(205, 216);
            btn_Maderas.Name = "btn_Maderas";
            btn_Maderas.PressedColor = Color.Gainsboro;
            btn_Maderas.PressedForeColor = Color.White;
            btn_Maderas.Size = new Size(60, 60);
            btn_Maderas.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            btn_Maderas.TabIndex = 29;
            btn_Maderas.Click += btn_Maderas_Click;
            // 
            // btn_Todas
            // 
            btn_Todas.BackColor = Color.FromArgb(247, 236, 234);
            btn_Todas.BorderColor = Color.FromArgb(180, 180, 180);
            btn_Todas.BorderThickness = 3;
            btn_Todas.DrawBorder = true;
            btn_Todas.ForeColor = Color.FromArgb(31, 31, 31);
            btn_Todas.HotTrackColor = Color.White;
            btn_Todas.Image = null;
            btn_Todas.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageOnly;
            btn_Todas.Location = new Point(418, 216);
            btn_Todas.Name = "btn_Todas";
            btn_Todas.PressedColor = Color.Gainsboro;
            btn_Todas.PressedForeColor = Color.White;
            btn_Todas.Size = new Size(60, 60);
            btn_Todas.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            btn_Todas.TabIndex = 32;
            btn_Todas.Text = "Todas";
            btn_Todas.Click += btn_Todas_Click;
            // 
            // btn_Instalaciones
            // 
            btn_Instalaciones.BackColor = Color.FromArgb(247, 236, 234);
            btn_Instalaciones.BorderColor = Color.FromArgb(180, 180, 180);
            btn_Instalaciones.BorderThickness = 3;
            btn_Instalaciones.DrawBorder = true;
            btn_Instalaciones.ForeColor = Color.FromArgb(31, 31, 31);
            btn_Instalaciones.HotTrackColor = Color.White;
            btn_Instalaciones.Image = (Image)resources.GetObject("btn_Instalaciones.Image");
            btn_Instalaciones.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageOnly;
            btn_Instalaciones.Location = new Point(275, 216);
            btn_Instalaciones.Name = "btn_Instalaciones";
            btn_Instalaciones.PressedColor = Color.Gainsboro;
            btn_Instalaciones.PressedForeColor = Color.White;
            btn_Instalaciones.Size = new Size(60, 60);
            btn_Instalaciones.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            btn_Instalaciones.TabIndex = 33;
            btn_Instalaciones.Click += btn_Instalaciones_Click;
            // 
            // btnConstruccion
            // 
            btnConstruccion.BackColor = Color.FromArgb(247, 236, 234);
            btnConstruccion.BorderColor = Color.FromArgb(180, 180, 180);
            btnConstruccion.BorderThickness = 3;
            btnConstruccion.DrawBorder = true;
            btnConstruccion.ForeColor = Color.FromArgb(31, 31, 31);
            btnConstruccion.HotTrackColor = Color.White;
            btnConstruccion.Image = (Image)resources.GetObject("btnConstruccion.Image");
            btnConstruccion.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageOnly;
            btnConstruccion.Location = new Point(345, 216);
            btnConstruccion.Name = "btnConstruccion";
            btnConstruccion.PressedColor = Color.Gainsboro;
            btnConstruccion.PressedForeColor = Color.White;
            btnConstruccion.Size = new Size(60, 60);
            btnConstruccion.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            btnConstruccion.TabIndex = 34;
            btnConstruccion.Click += btnConstruccion_Click;
            // 
            // form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 236, 234);
            ClientSize = new Size(583, 749);
            Controls.Add(btnConstruccion);
            Controls.Add(btn_Instalaciones);
            Controls.Add(btn_Todas);
            Controls.Add(btn_Maderas);
            Controls.Add(btn_Pintura);
            Controls.Add(btn_Ferreteria);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(txt_Busqueda);
            Controls.Add(button6);
            Controls.Add(lbl_Categoria);
            Controls.Add(btn_Editar);
            Controls.Add(txt_Dolar);
            Controls.Add(lbl_Dolar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Dolar;
        private TextBox txt_Dolar;
        private Button btn_Editar;
        private Label lbl_Categoria;
        private Button v;
        private Button btnPintura;
        private Button btn_Maderera;
        private Button btn_Construccion;
        private Button button6;
        private TextBox txt_Busqueda;
        private ListView listView1;
        private Label label1;
        private Label label2;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Button button1;
        private Button button2;
        private ReaLTaiizor.Controls.RoyalEllipseButton btn_Ferreteria;
        private ReaLTaiizor.Controls.RoyalEllipseButton btn_Pintura;
        private ReaLTaiizor.Controls.RoyalEllipseButton btn_Maderas;
        private ReaLTaiizor.Controls.RoyalEllipseButton btn_Todas;
        private ReaLTaiizor.Controls.RoyalEllipseButton royalEllipseButton1;
        private ReaLTaiizor.Controls.RoyalEllipseButton btn_Instalaciones;
        private ReaLTaiizor.Controls.RoyalEllipseButton btnConstruccion;
    }
}
