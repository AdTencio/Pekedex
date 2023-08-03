namespace ConexionesDB
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
            this.dgvPokemones = new System.Windows.Forms.DataGridView();
            this.picboxPokemon = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.btnEliminarFisico = new System.Windows.Forms.Button();
            this.btnEliminarLogico = new System.Windows.Forms.Button();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblCampo = new System.Windows.Forms.Label();
            this.cBoxCampo = new System.Windows.Forms.ComboBox();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.cBoxCriterio = new System.Windows.Forms.ComboBox();
            this.lblFiltroAv = new System.Windows.Forms.Label();
            this.txtFiltroAv = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokemones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPokemones
            // 
            this.dgvPokemones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPokemones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPokemones.Location = new System.Drawing.Point(55, 51);
            this.dgvPokemones.MultiSelect = false;
            this.dgvPokemones.Name = "dgvPokemones";
            this.dgvPokemones.RowHeadersWidth = 51;
            this.dgvPokemones.RowTemplate.Height = 24;
            this.dgvPokemones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPokemones.Size = new System.Drawing.Size(951, 324);
            this.dgvPokemones.TabIndex = 0;
            this.dgvPokemones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPokemones_CellContentClick);
            this.dgvPokemones.SelectionChanged += new System.EventHandler(this.dgvPokemones_SelectionChanged);
            // 
            // picboxPokemon
            // 
            this.picboxPokemon.Location = new System.Drawing.Point(1012, 51);
            this.picboxPokemon.Name = "picboxPokemon";
            this.picboxPokemon.Size = new System.Drawing.Size(282, 324);
            this.picboxPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxPokemon.TabIndex = 1;
            this.picboxPokemon.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(83, 410);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(186, 25);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar Pokemon";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(325, 410);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(186, 25);
            this.BtnModificar.TabIndex = 3;
            this.BtnModificar.Text = "Modificar Pokemon";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // btnEliminarFisico
            // 
            this.btnEliminarFisico.Location = new System.Drawing.Point(571, 410);
            this.btnEliminarFisico.Name = "btnEliminarFisico";
            this.btnEliminarFisico.Size = new System.Drawing.Size(186, 25);
            this.btnEliminarFisico.TabIndex = 4;
            this.btnEliminarFisico.Text = "Eliminar Pokemon";
            this.btnEliminarFisico.UseVisualStyleBackColor = true;
            this.btnEliminarFisico.Click += new System.EventHandler(this.btnEliminarFisico_Click);
            // 
            // btnEliminarLogico
            // 
            this.btnEliminarLogico.Location = new System.Drawing.Point(792, 410);
            this.btnEliminarLogico.Name = "btnEliminarLogico";
            this.btnEliminarLogico.Size = new System.Drawing.Size(186, 25);
            this.btnEliminarLogico.TabIndex = 5;
            this.btnEliminarLogico.Text = "Eliminar Logico";
            this.btnEliminarLogico.UseVisualStyleBackColor = true;
            this.btnEliminarLogico.Click += new System.EventHandler(this.btnEliminarLogico_Click);
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(771, 464);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(121, 24);
            this.btnFiltro.TabIndex = 6;
            this.btnFiltro.Text = "Buscar";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(101, 16);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(36, 16);
            this.lblFiltro.TabIndex = 7;
            this.lblFiltro.Text = "Filtro";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(143, 13);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(245, 22);
            this.txtFiltro.TabIndex = 8;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(102, 468);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(51, 16);
            this.lblCampo.TabIndex = 9;
            this.lblCampo.Text = "Campo";
            // 
            // cBoxCampo
            // 
            this.cBoxCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCampo.FormattingEnabled = true;
            this.cBoxCampo.Location = new System.Drawing.Point(175, 464);
            this.cBoxCampo.Name = "cBoxCampo";
            this.cBoxCampo.Size = new System.Drawing.Size(121, 24);
            this.cBoxCampo.TabIndex = 10;
            this.cBoxCampo.SelectedIndexChanged += new System.EventHandler(this.cBoxCampo_SelectedIndexChanged);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(325, 468);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(49, 16);
            this.lblCriterio.TabIndex = 11;
            this.lblCriterio.Text = "Criterio";
            // 
            // cBoxCriterio
            // 
            this.cBoxCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCriterio.FormattingEnabled = true;
            this.cBoxCriterio.Location = new System.Drawing.Point(398, 464);
            this.cBoxCriterio.Name = "cBoxCriterio";
            this.cBoxCriterio.Size = new System.Drawing.Size(121, 24);
            this.cBoxCriterio.TabIndex = 12;
            // 
            // lblFiltroAv
            // 
            this.lblFiltroAv.AutoSize = true;
            this.lblFiltroAv.Location = new System.Drawing.Point(548, 468);
            this.lblFiltroAv.Name = "lblFiltroAv";
            this.lblFiltroAv.Size = new System.Drawing.Size(52, 16);
            this.lblFiltroAv.TabIndex = 13;
            this.lblFiltroAv.Text = "FiltroAv";
            // 
            // txtFiltroAv
            // 
            this.txtFiltroAv.Location = new System.Drawing.Point(621, 465);
            this.txtFiltroAv.Name = "txtFiltroAv";
            this.txtFiltroAv.Size = new System.Drawing.Size(121, 22);
            this.txtFiltroAv.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 500);
            this.Controls.Add(this.txtFiltroAv);
            this.Controls.Add(this.lblFiltroAv);
            this.Controls.Add(this.cBoxCriterio);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.cBoxCampo);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.btnEliminarLogico);
            this.Controls.Add(this.btnEliminarFisico);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.picboxPokemon);
            this.Controls.Add(this.dgvPokemones);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokemones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPokemon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPokemones;
        private System.Windows.Forms.PictureBox picboxPokemon;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button btnEliminarFisico;
        private System.Windows.Forms.Button btnEliminarLogico;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.ComboBox cBoxCampo;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.ComboBox cBoxCriterio;
        private System.Windows.Forms.Label lblFiltroAv;
        private System.Windows.Forms.TextBox txtFiltroAv;
    }
}

