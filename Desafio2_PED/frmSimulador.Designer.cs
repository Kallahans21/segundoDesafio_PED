namespace Desafio2_PED
{
    partial class frmSimulador
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSimulador));
            this.pnl_pizaarra = new System.Windows.Forms.Panel();
            this.cmbSeleccionMapa = new System.Windows.Forms.ComboBox();
            this.CMSCrearVertice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoVérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAnchura = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevoNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.ltbRecorrido = new System.Windows.Forms.ListBox();
            this.cmbNodoIncial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProfundidad = new System.Windows.Forms.Button();
            this.salirbtn = new System.Windows.Forms.Button();
            this.CMSCrearVertice.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_pizaarra
            // 
            this.pnl_pizaarra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnl_pizaarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_pizaarra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_pizaarra.Location = new System.Drawing.Point(33, 18);
            this.pnl_pizaarra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl_pizaarra.Name = "pnl_pizaarra";
            this.pnl_pizaarra.Size = new System.Drawing.Size(1767, 564);
            this.pnl_pizaarra.TabIndex = 0;
            this.pnl_pizaarra.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_pizaarra_Paint);
            this.pnl_pizaarra.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnl_pizaarra_MouseClick);
            this.pnl_pizaarra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_pizaarra_MouseDown);
            this.pnl_pizaarra.MouseLeave += new System.EventHandler(this.pnl_pizaarra_MouseLeave);
            this.pnl_pizaarra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_pizaarra_MouseMove);
            this.pnl_pizaarra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_pizaarra_MouseUp);
            // 
            // cmbSeleccionMapa
            // 
            this.cmbSeleccionMapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeleccionMapa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSeleccionMapa.FormattingEnabled = true;
            this.cmbSeleccionMapa.Location = new System.Drawing.Point(634, 162);
            this.cmbSeleccionMapa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSeleccionMapa.Name = "cmbSeleccionMapa";
            this.cmbSeleccionMapa.Size = new System.Drawing.Size(262, 40);
            this.cmbSeleccionMapa.TabIndex = 0;
            this.cmbSeleccionMapa.SelectedIndexChanged += new System.EventHandler(this.cmbSeleccionMapa_SelectedIndexChanged);
            // 
            // CMSCrearVertice
            // 
            this.CMSCrearVertice.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.CMSCrearVertice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoVérticeToolStripMenuItem});
            this.CMSCrearVertice.Name = "CMSCrearVertice";
            this.CMSCrearVertice.Size = new System.Drawing.Size(194, 36);
            // 
            // nuevoVérticeToolStripMenuItem
            // 
            this.nuevoVérticeToolStripMenuItem.Name = "nuevoVérticeToolStripMenuItem";
            this.nuevoVérticeToolStripMenuItem.Size = new System.Drawing.Size(193, 32);
            this.nuevoVérticeToolStripMenuItem.Text = "Nuevo Vértice";
            this.nuevoVérticeToolStripMenuItem.Click += new System.EventHandler(this.nuevoVérticeToolStripMenuItem_Click);
            // 
            // btnAnchura
            // 
            this.btnAnchura.BackColor = System.Drawing.Color.Thistle;
            this.btnAnchura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnchura.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnchura.Location = new System.Drawing.Point(36, 160);
            this.btnAnchura.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAnchura.Name = "btnAnchura";
            this.btnAnchura.Size = new System.Drawing.Size(168, 64);
            this.btnAnchura.TabIndex = 2;
            this.btnAnchura.Text = "Anchura";
            this.btnAnchura.UseVisualStyleBackColor = false;
            this.btnAnchura.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBusqueda);
            this.groupBox2.Controls.Add(this.txtBusqueda);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.menuStrip1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ltbRecorrido);
            this.groupBox2.Controls.Add(this.cmbNodoIncial);
            this.groupBox2.Controls.Add(this.cmbSeleccionMapa);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnAnchura);
            this.groupBox2.Controls.Add(this.btnProfundidad);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(33, 592);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1548, 401);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recorridos";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackColor = System.Drawing.Color.Thistle;
            this.btnBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusqueda.Location = new System.Drawing.Point(325, 250);
            this.btnBusqueda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(168, 64);
            this.btnBusqueda.TabIndex = 0;
            this.btnBusqueda.Text = "Buscar";
            this.btnBusqueda.UseVisualStyleBackColor = false;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(285, 186);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(258, 39);
            this.txtBusqueda.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(362, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Buscar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1174, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Recorrido";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Purple;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoNodoToolStripMenuItem,
            this.eliminarNodoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(4, 29);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1540, 64);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // nuevoNodoToolStripMenuItem
            // 
            this.nuevoNodoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nuevoNodoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoNodoToolStripMenuItem.Image")));
            this.nuevoNodoToolStripMenuItem.Name = "nuevoNodoToolStripMenuItem";
            this.nuevoNodoToolStripMenuItem.Size = new System.Drawing.Size(157, 58);
            this.nuevoNodoToolStripMenuItem.Text = "Nuevo Nodo";
            this.nuevoNodoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.nuevoNodoToolStripMenuItem.Click += new System.EventHandler(this.nuevoNodoToolStripMenuItem_Click);
            // 
            // eliminarNodoToolStripMenuItem
            // 
            this.eliminarNodoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.eliminarNodoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarNodoToolStripMenuItem.Image")));
            this.eliminarNodoToolStripMenuItem.Name = "eliminarNodoToolStripMenuItem";
            this.eliminarNodoToolStripMenuItem.Size = new System.Drawing.Size(171, 58);
            this.eliminarNodoToolStripMenuItem.Text = "Eliminar Nodo";
            this.eliminarNodoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.eliminarNodoToolStripMenuItem.Click += new System.EventHandler(this.eliminarNodoToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(735, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "País:";
            // 
            // ltbRecorrido
            // 
            this.ltbRecorrido.FormattingEnabled = true;
            this.ltbRecorrido.ItemHeight = 25;
            this.ltbRecorrido.Location = new System.Drawing.Point(955, 160);
            this.ltbRecorrido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ltbRecorrido.Name = "ltbRecorrido";
            this.ltbRecorrido.Size = new System.Drawing.Size(555, 154);
            this.ltbRecorrido.TabIndex = 0;
            // 
            // cmbNodoIncial
            // 
            this.cmbNodoIncial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodoIncial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNodoIncial.FormattingEnabled = true;
            this.cmbNodoIncial.Location = new System.Drawing.Point(634, 274);
            this.cmbNodoIncial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbNodoIncial.Name = "cmbNodoIncial";
            this.cmbNodoIncial.Size = new System.Drawing.Size(262, 40);
            this.cmbNodoIncial.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(629, 222);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Departamento de inicio:";
            // 
            // btnProfundidad
            // 
            this.btnProfundidad.BackColor = System.Drawing.Color.Thistle;
            this.btnProfundidad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProfundidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfundidad.Location = new System.Drawing.Point(36, 261);
            this.btnProfundidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProfundidad.Name = "btnProfundidad";
            this.btnProfundidad.Size = new System.Drawing.Size(168, 64);
            this.btnProfundidad.TabIndex = 3;
            this.btnProfundidad.Text = "Profundidad";
            this.btnProfundidad.UseVisualStyleBackColor = false;
            this.btnProfundidad.Click += new System.EventHandler(this.btnProfundidad_Click);
            // 
            // salirbtn
            // 
            this.salirbtn.BackColor = System.Drawing.Color.Thistle;
            this.salirbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.salirbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.salirbtn.Location = new System.Drawing.Point(1632, 741);
            this.salirbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.salirbtn.Name = "salirbtn";
            this.salirbtn.Size = new System.Drawing.Size(168, 64);
            this.salirbtn.TabIndex = 4;
            this.salirbtn.Text = "Salir";
            this.salirbtn.UseVisualStyleBackColor = false;
            this.salirbtn.Click += new System.EventHandler(this.salirbtn_Click);
            // 
            // frmSimulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.salirbtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnl_pizaarra);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmSimulador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "inicio";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CMSCrearVertice.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_pizaarra;
        private System.Windows.Forms.ComboBox cmbSeleccionMapa;
        private System.Windows.Forms.ContextMenuStrip CMSCrearVertice;
        private System.Windows.Forms.ToolStripMenuItem nuevoVérticeToolStripMenuItem;
        private System.Windows.Forms.Button btnAnchura;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProfundidad;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarNodoToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbNodoIncial;
        private System.Windows.Forms.ListBox ltbRecorrido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.Button salirbtn;
    }
}

