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
            panel1 = new Panel();
            btn_Volver = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(54, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(406, 201);
            panel1.TabIndex = 0;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(57, 18);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(75, 23);
            btn_Volver.TabIndex = 1;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // FormSelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 327);
            Controls.Add(btn_Volver);
            Controls.Add(panel1);
            Name = "FormSelector";
            Text = "FormSelector";
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_Volver;
    }
}