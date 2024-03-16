namespace DiscosPruebaADO
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
            this.dgvDiscos = new System.Windows.Forms.DataGridView();
            this.picBoxPokemon = new System.Windows.Forms.PictureBox();
            this.btAgregar = new System.Windows.Forms.Button();
            this.btModificar = new System.Windows.Forms.Button();
            this.btEliminarFisico = new System.Windows.Forms.Button();
            this.btEliminarLogico = new System.Windows.Forms.Button();
            this.textFiltro = new System.Windows.Forms.TextBox();
            this.lbFiltro = new System.Windows.Forms.Label();
            this.btnFiltroBuscar = new System.Windows.Forms.Button();
            this.lbCampo = new System.Windows.Forms.Label();
            this.textFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.cbCampo = new System.Windows.Forms.ComboBox();
            this.lbCriterio = new System.Windows.Forms.Label();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.lbFiltroAvanzado = new System.Windows.Forms.Label();
            this.btnMostrarFiltroAvanzado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDiscos
            // 
            this.dgvDiscos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDiscos.Location = new System.Drawing.Point(37, 46);
            this.dgvDiscos.MultiSelect = false;
            this.dgvDiscos.Name = "dgvDiscos";
            this.dgvDiscos.RowHeadersWidth = 51;
            this.dgvDiscos.RowTemplate.Height = 24;
            this.dgvDiscos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiscos.Size = new System.Drawing.Size(580, 325);
            this.dgvDiscos.TabIndex = 0;
            this.dgvDiscos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiscos_CellContentClick);
            this.dgvDiscos.SelectionChanged += new System.EventHandler(this.dgvDiscos_SelectionChanged);
            // 
            // picBoxPokemon
            // 
            this.picBoxPokemon.Location = new System.Drawing.Point(636, 46);
            this.picBoxPokemon.Name = "picBoxPokemon";
            this.picBoxPokemon.Size = new System.Drawing.Size(352, 325);
            this.picBoxPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxPokemon.TabIndex = 1;
            this.picBoxPokemon.TabStop = false;
            // 
            // btAgregar
            // 
            this.btAgregar.Location = new System.Drawing.Point(37, 399);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(78, 36);
            this.btAgregar.TabIndex = 2;
            this.btAgregar.Text = "agregar";
            this.btAgregar.UseVisualStyleBackColor = true;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // btModificar
            // 
            this.btModificar.Location = new System.Drawing.Point(121, 400);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(80, 35);
            this.btModificar.TabIndex = 3;
            this.btModificar.Text = "modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btEliminarFisico
            // 
            this.btEliminarFisico.Location = new System.Drawing.Point(381, 400);
            this.btEliminarFisico.Name = "btEliminarFisico";
            this.btEliminarFisico.Size = new System.Drawing.Size(108, 35);
            this.btEliminarFisico.TabIndex = 4;
            this.btEliminarFisico.Text = "eliminar fisico";
            this.btEliminarFisico.UseVisualStyleBackColor = true;
            this.btEliminarFisico.Click += new System.EventHandler(this.btEliminarFisico_Click);
            // 
            // btEliminarLogico
            // 
            this.btEliminarLogico.Location = new System.Drawing.Point(495, 399);
            this.btEliminarLogico.Name = "btEliminarLogico";
            this.btEliminarLogico.Size = new System.Drawing.Size(122, 35);
            this.btEliminarLogico.TabIndex = 5;
            this.btEliminarLogico.Text = "eliminar logico";
            this.btEliminarLogico.UseVisualStyleBackColor = true;
            // 
            // textFiltro
            // 
            this.textFiltro.Location = new System.Drawing.Point(87, 14);
            this.textFiltro.Name = "textFiltro";
            this.textFiltro.Size = new System.Drawing.Size(228, 22);
            this.textFiltro.TabIndex = 6;
            this.textFiltro.TextChanged += new System.EventHandler(this.textFiltro_TextChanged);
            // 
            // lbFiltro
            // 
            this.lbFiltro.AutoSize = true;
            this.lbFiltro.Location = new System.Drawing.Point(34, 20);
            this.lbFiltro.Name = "lbFiltro";
            this.lbFiltro.Size = new System.Drawing.Size(39, 16);
            this.lbFiltro.TabIndex = 7;
            this.lbFiltro.Text = "Filtro:";
            // 
            // btnFiltroBuscar
            // 
            this.btnFiltroBuscar.Location = new System.Drawing.Point(627, 451);
            this.btnFiltroBuscar.Name = "btnFiltroBuscar";
            this.btnFiltroBuscar.Size = new System.Drawing.Size(77, 28);
            this.btnFiltroBuscar.TabIndex = 8;
            this.btnFiltroBuscar.Text = "buscar";
            this.btnFiltroBuscar.UseVisualStyleBackColor = true;
            this.btnFiltroBuscar.Visible = false;
            this.btnFiltroBuscar.Click += new System.EventHandler(this.botonFiltro_Click);
            // 
            // lbCampo
            // 
            this.lbCampo.AutoSize = true;
            this.lbCampo.Location = new System.Drawing.Point(34, 457);
            this.lbCampo.Name = "lbCampo";
            this.lbCampo.Size = new System.Drawing.Size(54, 16);
            this.lbCampo.TabIndex = 9;
            this.lbCampo.Text = "Campo:";
            this.lbCampo.Visible = false;
            // 
            // textFiltroAvanzado
            // 
            this.textFiltroAvanzado.Location = new System.Drawing.Point(512, 454);
            this.textFiltroAvanzado.Name = "textFiltroAvanzado";
            this.textFiltroAvanzado.Size = new System.Drawing.Size(100, 22);
            this.textFiltroAvanzado.TabIndex = 10;
            this.textFiltroAvanzado.Visible = false;
            // 
            // cbCampo
            // 
            this.cbCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampo.FormattingEnabled = true;
            this.cbCampo.Location = new System.Drawing.Point(94, 453);
            this.cbCampo.Name = "cbCampo";
            this.cbCampo.Size = new System.Drawing.Size(121, 24);
            this.cbCampo.TabIndex = 11;
            this.cbCampo.Visible = false;
            this.cbCampo.SelectedIndexChanged += new System.EventHandler(this.cbCampo_SelectedIndexChanged);
            // 
            // lbCriterio
            // 
            this.lbCriterio.AutoSize = true;
            this.lbCriterio.Location = new System.Drawing.Point(221, 457);
            this.lbCriterio.Name = "lbCriterio";
            this.lbCriterio.Size = new System.Drawing.Size(52, 16);
            this.lbCriterio.TabIndex = 12;
            this.lbCriterio.Text = "Criterio:";
            this.lbCriterio.Visible = false;
            // 
            // cbCriterio
            // 
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(279, 453);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(121, 24);
            this.cbCriterio.TabIndex = 13;
            this.cbCriterio.Visible = false;
            // 
            // lbFiltroAvanzado
            // 
            this.lbFiltroAvanzado.AutoSize = true;
            this.lbFiltroAvanzado.Location = new System.Drawing.Point(406, 457);
            this.lbFiltroAvanzado.Name = "lbFiltroAvanzado";
            this.lbFiltroAvanzado.Size = new System.Drawing.Size(100, 16);
            this.lbFiltroAvanzado.TabIndex = 14;
            this.lbFiltroAvanzado.Text = "Filtro Avanzado";
            this.lbFiltroAvanzado.Visible = false;
            // 
            // btnMostrarFiltroAvanzado
            // 
            this.btnMostrarFiltroAvanzado.Location = new System.Drawing.Point(866, 12);
            this.btnMostrarFiltroAvanzado.Name = "btnMostrarFiltroAvanzado";
            this.btnMostrarFiltroAvanzado.Size = new System.Drawing.Size(122, 27);
            this.btnMostrarFiltroAvanzado.TabIndex = 15;
            this.btnMostrarFiltroAvanzado.Text = "Filtro Avanzado";
            this.btnMostrarFiltroAvanzado.UseVisualStyleBackColor = true;
            this.btnMostrarFiltroAvanzado.Click += new System.EventHandler(this.btnMostrarFiltroAvanzado_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 498);
            this.Controls.Add(this.btnMostrarFiltroAvanzado);
            this.Controls.Add(this.lbFiltroAvanzado);
            this.Controls.Add(this.cbCriterio);
            this.Controls.Add(this.lbCriterio);
            this.Controls.Add(this.cbCampo);
            this.Controls.Add(this.textFiltroAvanzado);
            this.Controls.Add(this.lbCampo);
            this.Controls.Add(this.btnFiltroBuscar);
            this.Controls.Add(this.lbFiltro);
            this.Controls.Add(this.textFiltro);
            this.Controls.Add(this.btEliminarLogico);
            this.Controls.Add(this.btEliminarFisico);
            this.Controls.Add(this.btModificar);
            this.Controls.Add(this.btAgregar);
            this.Controls.Add(this.picBoxPokemon);
            this.Controls.Add(this.dgvDiscos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPokemon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDiscos;
        private System.Windows.Forms.PictureBox picBoxPokemon;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Button btEliminarFisico;
        private System.Windows.Forms.Button btEliminarLogico;
        private System.Windows.Forms.TextBox textFiltro;
        private System.Windows.Forms.Label lbFiltro;
        private System.Windows.Forms.Button btnFiltroBuscar;
        private System.Windows.Forms.Label lbCampo;
        private System.Windows.Forms.TextBox textFiltroAvanzado;
        private System.Windows.Forms.ComboBox cbCampo;
        private System.Windows.Forms.Label lbCriterio;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.Label lbFiltroAvanzado;
        private System.Windows.Forms.Button btnMostrarFiltroAvanzado;
    }
}

