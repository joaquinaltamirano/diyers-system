namespace Diyers_System
{
    partial class FormSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelector));
            flowLayoutPanel1 = new FlowLayoutPanel();
            btn_Cerrar = new ReaLTaiizor.Controls.Button();
            btn_Volver = new ReaLTaiizor.Controls.Button();
            lbl_Atributo = new Label();
            lbl_Titulo = new Label();
            button1 = new ReaLTaiizor.Controls.Button();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Location = new Point(23, 113);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(447, 179);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // btn_Cerrar
            // 
            btn_Cerrar.BackColor = Color.White;
            btn_Cerrar.BorderColor = Color.White;
            btn_Cerrar.EnteredBorderColor = Color.FromArgb(239, 192, 74);
            btn_Cerrar.EnteredColor = Color.FromArgb(239, 192, 74);
            btn_Cerrar.Font = new Font("Microsoft Sans Serif", 12F);
            btn_Cerrar.Image = (Image)resources.GetObject("btn_Cerrar.Image");
            btn_Cerrar.ImageAlign = ContentAlignment.MiddleCenter;
            btn_Cerrar.InactiveColor = Color.White;
            btn_Cerrar.Location = new Point(453, -1);
            btn_Cerrar.Name = "btn_Cerrar";
            btn_Cerrar.PressedBorderColor = Color.White;
            btn_Cerrar.PressedColor = Color.White;
            btn_Cerrar.Size = new Size(48, 45);
            btn_Cerrar.TabIndex = 38;
            btn_Cerrar.TextAlignment = StringAlignment.Center;
            btn_Cerrar.Click += btn_Cerrar_Click;
            // 
            // btn_Volver
            // 
            btn_Volver.BackColor = Color.White;
            btn_Volver.BorderColor = Color.White;
            btn_Volver.EnteredBorderColor = Color.FromArgb(239, 192, 74);
            btn_Volver.EnteredColor = Color.FromArgb(239, 192, 74);
            btn_Volver.Font = new Font("Microsoft Sans Serif", 12F);
            btn_Volver.Image = (Image)resources.GetObject("btn_Volver.Image");
            btn_Volver.ImageAlign = ContentAlignment.MiddleCenter;
            btn_Volver.InactiveColor = Color.White;
            btn_Volver.Location = new Point(0, 0);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.PressedBorderColor = Color.White;
            btn_Volver.PressedColor = Color.White;
            btn_Volver.Size = new Size(48, 45);
            btn_Volver.TabIndex = 40;
            btn_Volver.TextAlignment = StringAlignment.Center;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // lbl_Atributo
            // 
            lbl_Atributo.AutoSize = true;
            lbl_Atributo.Font = new Font("MADE TOMMY", 21.7499962F, FontStyle.Bold);
            lbl_Atributo.ForeColor = Color.FromArgb(56, 56, 56);
            lbl_Atributo.Location = new Point(53, 66);
            lbl_Atributo.Name = "lbl_Atributo";
            lbl_Atributo.Size = new Size(181, 36);
            lbl_Atributo.TabIndex = 41;
            lbl_Atributo.Text = "CATEGORÍA";
            // 
            // lbl_Titulo
            // 
            lbl_Titulo.AutoSize = true;
            lbl_Titulo.Font = new Font("MADE TOMMY", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Titulo.ForeColor = Color.FromArgb(44, 30, 155);
            lbl_Titulo.Location = new Point(49, 10);
            lbl_Titulo.Name = "lbl_Titulo";
            lbl_Titulo.Size = new Size(131, 26);
            lbl_Titulo.TabIndex = 43;
            lbl_Titulo.Text = "CATEGORÍA";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.BorderColor = Color.White;
            button1.EnteredBorderColor = Color.FromArgb(44, 30, 155);
            button1.EnteredColor = Color.FromArgb(44, 30, 155);
            button1.Font = new Font("Microsoft Sans Serif", 12F);
            button1.Image = null;
            button1.ImageAlign = ContentAlignment.MiddleCenter;
            button1.InactiveColor = Color.FromArgb(239, 192, 74);
            button1.Location = new Point(34, 66);
            button1.Name = "button1";
            button1.PressedBorderColor = Color.FromArgb(239, 192, 74);
            button1.PressedColor = Color.FromArgb(239, 192, 74);
            button1.Size = new Size(16, 36);
            button1.TabIndex = 52;
            button1.TextAlignment = StringAlignment.Center;
            // 
            // FormSelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(503, 304);
            Controls.Add(button1);
            Controls.Add(lbl_Titulo);
            Controls.Add(lbl_Atributo);
            Controls.Add(btn_Volver);
            Controls.Add(btn_Cerrar);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormSelector";
            Text = "FormSelector";
            Load += FormSelector_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private ReaLTaiizor.Controls.Button btn_Cerrar;
        private ReaLTaiizor.Controls.Button btn_Volver;
        private Label lbl_Atributo;
        private Label lbl_Titulo;
        private ReaLTaiizor.Controls.Button button1;
    }
}