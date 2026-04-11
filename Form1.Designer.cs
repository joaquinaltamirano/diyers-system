namespace Diyers_System
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
            SuspendLayout();
            // 
            // lbl_Dolar
            // 
            lbl_Dolar.AutoSize = true;
            lbl_Dolar.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Dolar.Location = new Point(54, 25);
            lbl_Dolar.Name = "lbl_Dolar";
            lbl_Dolar.Size = new Size(115, 40);
            lbl_Dolar.TabIndex = 0;
            lbl_Dolar.Text = "DÓLAR";
            // 
            // txt_Dolar
            // 
            txt_Dolar.Enabled = false;
            txt_Dolar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_Dolar.Location = new Point(63, 71);
            txt_Dolar.Name = "txt_Dolar";
            txt_Dolar.Size = new Size(153, 29);
            txt_Dolar.TabIndex = 1;
            txt_Dolar.Text = "1433";
            // 
            // btn_Editar
            // 
            btn_Editar.Location = new Point(222, 71);
            btn_Editar.Name = "btn_Editar";
            btn_Editar.Size = new Size(53, 29);
            btn_Editar.TabIndex = 2;
            btn_Editar.Text = "Editar";
            btn_Editar.UseVisualStyleBackColor = true;
            btn_Editar.Click += button1_Click;
            // 
            // lbl_Categoria
            // 
            lbl_Categoria.AutoSize = true;
            lbl_Categoria.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Categoria.Location = new Point(63, 140);
            lbl_Categoria.Name = "lbl_Categoria";
            lbl_Categoria.Size = new Size(176, 40);
            lbl_Categoria.TabIndex = 3;
            lbl_Categoria.Text = "CATEGORÍA";
            // 
            // btn_Ferreteria
            // 
            btn_Ferreteria.Location = new Point(72, 199);
            btn_Ferreteria.Name = "btn_Ferreteria";
            btn_Ferreteria.Size = new Size(63, 66);
            btn_Ferreteria.TabIndex = 4;
            btn_Ferreteria.Text = "Ferreteria";
            btn_Ferreteria.UseVisualStyleBackColor = true;
            // 
            // btnPintura
            // 
            btnPintura.Location = new Point(149, 199);
            btnPintura.Name = "btnPintura";
            btnPintura.Size = new Size(64, 66);
            btnPintura.TabIndex = 5;
            btnPintura.Text = "Pintura";
            btnPintura.UseVisualStyleBackColor = true;
            // 
            // btn_Maderera
            // 
            btn_Maderera.Location = new Point(228, 199);
            btn_Maderera.Name = "btn_Maderera";
            btn_Maderera.Size = new Size(57, 66);
            btn_Maderera.TabIndex = 6;
            btn_Maderera.Text = "Maderera";
            btn_Maderera.UseVisualStyleBackColor = true;
            // 
            // btn_Construccion
            // 
            btn_Construccion.Location = new Point(362, 199);
            btn_Construccion.Name = "btn_Construccion";
            btn_Construccion.Size = new Size(59, 66);
            btn_Construccion.TabIndex = 8;
            btn_Construccion.Text = "Construccion";
            btn_Construccion.UseVisualStyleBackColor = true;
            // 
            // btn_Instalaciones
            // 
            btn_Instalaciones.Location = new Point(296, 199);
            btn_Instalaciones.Name = "btn_Instalaciones";
            btn_Instalaciones.Size = new Size(57, 66);
            btn_Instalaciones.TabIndex = 7;
            btn_Instalaciones.Text = "Instalaciones";
            btn_Instalaciones.UseVisualStyleBackColor = true;
            // 
            // btn_agregarCategoria
            // 
            btn_agregarCategoria.Enabled = false;
            btn_agregarCategoria.Location = new Point(436, 199);
            btn_agregarCategoria.Name = "btn_agregarCategoria";
            btn_agregarCategoria.Size = new Size(59, 66);
            btn_agregarCategoria.TabIndex = 9;
            btn_agregarCategoria.Text = "+";
            btn_agregarCategoria.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(396, 72);
            button6.Name = "button6";
            button6.Size = new Size(188, 29);
            button6.TabIndex = 10;
            button6.Text = "Exportar Datos";
            button6.UseVisualStyleBackColor = true;
            // 
            // txt_Busqueda
            // 
            txt_Busqueda.Enabled = false;
            txt_Busqueda.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_Busqueda.Location = new Point(72, 295);
            txt_Busqueda.Name = "txt_Busqueda";
            txt_Busqueda.Size = new Size(349, 29);
            txt_Busqueda.TabIndex = 11;
            // 
            // button7
            // 
            button7.Location = new Point(368, 295);
            button7.Name = "button7";
            button7.Size = new Size(53, 29);
            button7.TabIndex = 12;
            button7.Text = "Buscar";
            button7.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(72, 385);
            listView1.Name = "listView1";
            listView1.Size = new Size(349, 287);
            listView1.TabIndex = 13;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Tile;
            listView1.DoubleClick += listView1_DoubleClick;
            listView1.KeyDown += listView1_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(72, 353);
            label1.Name = "label1";
            label1.Size = new Size(80, 21);
            label1.TabIndex = 14;
            label1.Text = "Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(348, 353);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 749);
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
            Name = "Form1";
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
    }
}
