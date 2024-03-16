namespace practica1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.botonCalcular = new System.Windows.Forms.Button();
            this.lbResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(163, 119);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(136, 22);
            this.txt1.TabIndex = 0;
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(163, 200);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(136, 22);
            this.txt2.TabIndex = 1;
            // 
            // botonCalcular
            // 
            this.botonCalcular.Location = new System.Drawing.Point(183, 281);
            this.botonCalcular.Name = "botonCalcular";
            this.botonCalcular.Size = new System.Drawing.Size(75, 23);
            this.botonCalcular.TabIndex = 2;
            this.botonCalcular.Text = "Calcular";
            this.botonCalcular.UseVisualStyleBackColor = true;
            this.botonCalcular.Click += new System.EventHandler(this.botonCalcular_Click);
            // 
            // lbResultado
            // 
            this.lbResultado.AutoSize = true;
            this.lbResultado.Location = new System.Drawing.Point(198, 332);
            this.lbResultado.Name = "lbResultado";
            this.lbResultado.Size = new System.Drawing.Size(0, 16);
            this.lbResultado.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 533);
            this.Controls.Add(this.lbResultado);
            this.Controls.Add(this.botonCalcular);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Button botonCalcular;
        private System.Windows.Forms.Label lbResultado;
    }
}

