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
            lbl_Dolar = new Label();
            txt_Dolar = new TextBox();
            btn_Editar = new Button();
            lbl_Categoria = new Label();
            btn_Ferreteria = new Button();
            btnPintura = new Button();
            btn_Maderera = new Button();
            btn_Construccion = new Button();
            btn_Instalaciones = new Button();
            btn_agregarCategoria = new Button();
            button6 = new Button();
            txt_Busqueda = new TextBox();
            button7 = new Button();
            listView1 = new ListView();
            label1 = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            btnTodas = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            button1 = new Button();
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
            lbl_Categoria.Location = new Point(53, 147);
            lbl_Categoria.Name = "lbl_Categoria";
            lbl_Categoria.Size = new Size(181, 36);
            lbl_Categoria.TabIndex = 3;
            lbl_Categoria.Text = "CATEGORÍA";
            // 
            // btn_Ferreteria
            // 
            btn_Ferreteria.Location = new Point(72, 206);
            btn_Ferreteria.Name = "btn_Ferreteria";
            btn_Ferreteria.Size = new Size(63, 66);
            btn_Ferreteria.TabIndex = 4;
            btn_Ferreteria.TabStop = false;
            btn_Ferreteria.Text = "Ferreteria";
            btn_Ferreteria.UseVisualStyleBackColor = true;
            btn_Ferreteria.Click += btn_Ferreteria_Click;
            // 
            // btnPintura
            // 
            btnPintura.Location = new Point(149, 206);
            btnPintura.Name = "btnPintura";
            btnPintura.Size = new Size(64, 66);
            btnPintura.TabIndex = 5;
            btnPintura.TabStop = false;
            btnPintura.Text = "Pintura";
            btnPintura.UseVisualStyleBackColor = true;
            btnPintura.Click += btnPintura_Click;
            // 
            // btn_Maderera
            // 
            btn_Maderera.Location = new Point(228, 206);
            btn_Maderera.Name = "btn_Maderera";
            btn_Maderera.Size = new Size(57, 66);
            btn_Maderera.TabIndex = 6;
            btn_Maderera.TabStop = false;
            btn_Maderera.Text = "Maderera";
            btn_Maderera.UseVisualStyleBackColor = true;
            btn_Maderera.Click += btn_Maderera_Click;
            // 
            // btn_Construccion
            // 
            btn_Construccion.Location = new Point(362, 206);
            btn_Construccion.Name = "btn_Construccion";
            btn_Construccion.Size = new Size(59, 66);
            btn_Construccion.TabIndex = 8;
            btn_Construccion.TabStop = false;
            btn_Construccion.Text = "Construccion";
            btn_Construccion.UseVisualStyleBackColor = true;
            btn_Construccion.Click += btn_Construccion_Click;
            // 
            // btn_Instalaciones
            // 
            btn_Instalaciones.Location = new Point(296, 206);
            btn_Instalaciones.Name = "btn_Instalaciones";
            btn_Instalaciones.Size = new Size(57, 66);
            btn_Instalaciones.TabIndex = 7;
            btn_Instalaciones.TabStop = false;
            btn_Instalaciones.Text = "Instalaciones";
            btn_Instalaciones.UseVisualStyleBackColor = true;
            btn_Instalaciones.Click += btn_Instalaciones_Click;
            // 
            // btn_agregarCategoria
            // 
            btn_agregarCategoria.Enabled = false;
            btn_agregarCategoria.Location = new Point(436, 206);
            btn_agregarCategoria.Name = "btn_agregarCategoria";
            btn_agregarCategoria.Size = new Size(59, 66);
            btn_agregarCategoria.TabIndex = 9;
            btn_agregarCategoria.TabStop = false;
            btn_agregarCategoria.Text = "+";
            btn_agregarCategoria.UseVisualStyleBackColor = true;
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
            txt_Busqueda.Location = new Point(72, 302);
            txt_Busqueda.Name = "txt_Busqueda";
            txt_Busqueda.Size = new Size(349, 26);
            txt_Busqueda.TabIndex = 11;
            txt_Busqueda.TextChanged += txt_Busqueda_TextChanged;
            txt_Busqueda.KeyDown += txt_Busqueda_KeyDown;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(239, 192, 74);
            button7.FlatStyle = FlatStyle.Flat;
            button7.Location = new Point(368, 302);
            button7.Name = "button7";
            button7.Size = new Size(53, 27);
            button7.TabIndex = 12;
            button7.TabStop = false;
            button7.Text = "Buscar";
            button7.UseVisualStyleBackColor = false;
            // 
            // listView1
            // 
            listView1.BackColor = Color.FromArgb(247, 236, 234);
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
            label1.ForeColor = Color.FromArgb(56, 56, 56);
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
            label2.ForeColor = Color.FromArgb(56, 56, 56);
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
            // btnTodas
            // 
            btnTodas.Location = new Point(296, 158);
            btnTodas.Name = "btnTodas";
            btnTodas.Size = new Size(125, 29);
            btnTodas.TabIndex = 18;
            btnTodas.TabStop = false;
            btnTodas.Text = "TOODAS";
            btnTodas.UseVisualStyleBackColor = true;
            btnTodas.Click += button1_Click_1;
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
            panel6.Location = new Point(33, 146);
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
            button1.Size = new Size(54, 41);
            button1.TabIndex = 25;
            button1.TabStop = false;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_2;
            // 
            // form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 236, 234);
            ClientSize = new Size(583, 749);
            Controls.Add(button1);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnTodas);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(button7);
            Controls.Add(txt_Busqueda);
            Controls.Add(button6);
            Controls.Add(btn_agregarCategoria);
            Controls.Add(btn_Construccion);
            Controls.Add(btn_Instalaciones);
            Controls.Add(btn_Maderera);
            Controls.Add(btnPintura);
            Controls.Add(btn_Ferreteria);
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
        private Button btn_Ferreteria;
        private Button btnPintura;
        private Button btn_Maderera;
        private Button btn_Construccion;
        private Button btn_Instalaciones;
        private Button btn_agregarCategoria;
        private Button button6;
        private TextBox txt_Busqueda;
        private Button button7;
        private ListView listView1;
        private Label label1;
        private Label label2;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private Button btnTodas;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Button button1;
    }
}
