namespace DiscosPruebaADO
{
    partial class frmAltaPokemon
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
            this.lbNumero = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.textNumero = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.lbTipo = new System.Windows.Forms.Label();
            this.lbDebilidad = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.cbDebilidad = new System.Windows.Forms.ComboBox();
            this.lbUrlImagen = new System.Windows.Forms.Label();
            this.textUrlImagen = new System.Windows.Forms.TextBox();
            this.pbPokemon = new System.Windows.Forms.PictureBox();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            this.lbErrorNumero = new System.Windows.Forms.Label();
            this.lbErrorNombre = new System.Windows.Forms.Label();
            this.lbErrorMensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNumero
            // 
            this.lbNumero.AutoSize = true;
            this.lbNumero.Location = new System.Drawing.Point(65, 37);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(58, 16);
            this.lbNumero.TabIndex = 0;
            this.lbNumero.Text = "Numero:";
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(64, 91);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(59, 16);
            this.lbNombre.TabIndex = 1;
            this.lbNombre.Text = "Nombre:";
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Location = new System.Drawing.Point(41, 135);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(82, 16);
            this.lbDescripcion.TabIndex = 2;
            this.lbDescripcion.Text = "Descripcion:";
            // 
            // textNumero
            // 
            this.textNumero.Location = new System.Drawing.Point(130, 34);
            this.textNumero.Name = "textNumero";
            this.textNumero.Size = new System.Drawing.Size(158, 22);
            this.textNumero.TabIndex = 0;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(130, 85);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(158, 22);
            this.textNombre.TabIndex = 1;
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(130, 129);
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(158, 22);
            this.textDescripcion.TabIndex = 2;
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(75, 341);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(82, 39);
            this.botonAceptar.TabIndex = 6;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(199, 340);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(89, 40);
            this.botonCancelar.TabIndex = 7;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Location = new System.Drawing.Point(85, 233);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(38, 16);
            this.lbTipo.TabIndex = 8;
            this.lbTipo.Text = "Tipo:";
            // 
            // lbDebilidad
            // 
            this.lbDebilidad.AutoSize = true;
            this.lbDebilidad.Location = new System.Drawing.Point(54, 279);
            this.lbDebilidad.Name = "lbDebilidad";
            this.lbDebilidad.Size = new System.Drawing.Size(69, 16);
            this.lbDebilidad.TabIndex = 9;
            this.lbDebilidad.Text = "Debilidad:";
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(130, 225);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(158, 24);
            this.cbTipo.TabIndex = 4;
            // 
            // cbDebilidad
            // 
            this.cbDebilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDebilidad.FormattingEnabled = true;
            this.cbDebilidad.Location = new System.Drawing.Point(130, 279);
            this.cbDebilidad.Name = "cbDebilidad";
            this.cbDebilidad.Size = new System.Drawing.Size(158, 24);
            this.cbDebilidad.TabIndex = 5;
            // 
            // lbUrlImagen
            // 
            this.lbUrlImagen.AutoSize = true;
            this.lbUrlImagen.Location = new System.Drawing.Point(51, 179);
            this.lbUrlImagen.Name = "lbUrlImagen";
            this.lbUrlImagen.Size = new System.Drawing.Size(75, 16);
            this.lbUrlImagen.TabIndex = 12;
            this.lbUrlImagen.Text = "Url Imagen:";
            // 
            // textUrlImagen
            // 
            this.textUrlImagen.Location = new System.Drawing.Point(130, 176);
            this.textUrlImagen.Name = "textUrlImagen";
            this.textUrlImagen.Size = new System.Drawing.Size(158, 22);
            this.textUrlImagen.TabIndex = 3;
            this.textUrlImagen.Leave += new System.EventHandler(this.textUrlImagen_Leave);
            // 
            // pbPokemon
            // 
            this.pbPokemon.Location = new System.Drawing.Point(336, 34);
            this.pbPokemon.Name = "pbPokemon";
            this.pbPokemon.Size = new System.Drawing.Size(340, 312);
            this.pbPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPokemon.TabIndex = 14;
            this.pbPokemon.TabStop = false;
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(294, 176);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(25, 23);
            this.btnAgregarImagen.TabIndex = 15;
            this.btnAgregarImagen.Text = "+";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // lbErrorNumero
            // 
            this.lbErrorNumero.AutoSize = true;
            this.lbErrorNumero.ForeColor = System.Drawing.Color.Red;
            this.lbErrorNumero.Location = new System.Drawing.Point(291, 34);
            this.lbErrorNumero.Name = "lbErrorNumero";
            this.lbErrorNumero.Size = new System.Drawing.Size(12, 16);
            this.lbErrorNumero.TabIndex = 16;
            this.lbErrorNumero.Text = "*";
            this.lbErrorNumero.Visible = false;
            // 
            // lbErrorNombre
            // 
            this.lbErrorNombre.AutoSize = true;
            this.lbErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.lbErrorNombre.Location = new System.Drawing.Point(291, 85);
            this.lbErrorNombre.Name = "lbErrorNombre";
            this.lbErrorNombre.Size = new System.Drawing.Size(12, 16);
            this.lbErrorNombre.TabIndex = 17;
            this.lbErrorNombre.Text = "*";
            this.lbErrorNombre.Visible = false;
            // 
            // lbErrorMensaje
            // 
            this.lbErrorMensaje.AutoSize = true;
            this.lbErrorMensaje.ForeColor = System.Drawing.Color.Red;
            this.lbErrorMensaje.Location = new System.Drawing.Point(388, 352);
            this.lbErrorMensaje.Name = "lbErrorMensaje";
            this.lbErrorMensaje.Size = new System.Drawing.Size(244, 32);
            this.lbErrorMensaje.TabIndex = 18;
            this.lbErrorMensaje.Text = "RECUERDE COMPLETAR/CORREGIR\r\nLOS CAMPOS SELECCIONADOS";
            this.lbErrorMensaje.Visible = false;
            // 
            // frmAltaPokemon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 407);
            this.Controls.Add(this.lbErrorMensaje);
            this.Controls.Add(this.lbErrorNombre);
            this.Controls.Add(this.lbErrorNumero);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.pbPokemon);
            this.Controls.Add(this.textUrlImagen);
            this.Controls.Add(this.lbUrlImagen);
            this.Controls.Add(this.cbDebilidad);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.lbDebilidad);
            this.Controls.Add(this.lbTipo);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.textDescripcion);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.textNumero);
            this.Controls.Add(this.lbDescripcion);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.lbNumero);
            this.Name = "frmAltaPokemon";
            this.Text = "Nuevo Pokemon";
            this.Load += new System.EventHandler(this.frmAltaPokemon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPokemon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNumero;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.TextBox textNumero;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.Label lbDebilidad;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.ComboBox cbDebilidad;
        private System.Windows.Forms.Label lbUrlImagen;
        private System.Windows.Forms.TextBox textUrlImagen;
        private System.Windows.Forms.PictureBox pbPokemon;
        private System.Windows.Forms.Button btnAgregarImagen;
        private System.Windows.Forms.Label lbErrorNumero;
        private System.Windows.Forms.Label lbErrorNombre;
        private System.Windows.Forms.Label lbErrorMensaje;
    }
}