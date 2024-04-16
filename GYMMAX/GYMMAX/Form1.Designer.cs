namespace GYMMAX
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prestamosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeDePrestamosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeDeAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeDeDiscosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeMaterialDidacticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prestamosPorAlumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prestamosPorDiscoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.preferenciasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(582, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prestamosToolStripMenuItem,
            this.alumnosToolStripMenuItem,
            this.discosToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // prestamosToolStripMenuItem
            // 
            this.prestamosToolStripMenuItem.Name = "prestamosToolStripMenuItem";
            this.prestamosToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.prestamosToolStripMenuItem.Text = "Inscripciones";
            this.prestamosToolStripMenuItem.Click += new System.EventHandler(this.prestamosToolStripMenuItem_Click);
            // 
            // alumnosToolStripMenuItem
            // 
            this.alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            this.alumnosToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.alumnosToolStripMenuItem.Text = "Clientes";
            this.alumnosToolStripMenuItem.Click += new System.EventHandler(this.alumnosToolStripMenuItem_Click);
            // 
            // discosToolStripMenuItem
            // 
            this.discosToolStripMenuItem.Name = "discosToolStripMenuItem";
            this.discosToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.discosToolStripMenuItem.Text = "Planes";
            this.discosToolStripMenuItem.Click += new System.EventHandler(this.discosToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informeDePrestamosToolStripMenuItem,
            this.informeDeAlumnosToolStripMenuItem,
            this.informeDeDiscosToolStripMenuItem,
            this.informeDeUsuariosToolStripMenuItem,
            this.reporteDeMaterialDidacticoToolStripMenuItem,
            this.prestamosPorAlumnoToolStripMenuItem,
            this.prestamosPorDiscoToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // informeDePrestamosToolStripMenuItem
            // 
            this.informeDePrestamosToolStripMenuItem.Name = "informeDePrestamosToolStripMenuItem";
            this.informeDePrestamosToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.informeDePrestamosToolStripMenuItem.Text = "Informe de inscripciones";
            this.informeDePrestamosToolStripMenuItem.Click += new System.EventHandler(this.informeDePrestamosToolStripMenuItem_Click);
            // 
            // informeDeAlumnosToolStripMenuItem
            // 
            this.informeDeAlumnosToolStripMenuItem.Name = "informeDeAlumnosToolStripMenuItem";
            this.informeDeAlumnosToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.informeDeAlumnosToolStripMenuItem.Text = "Informe de clientes";
            this.informeDeAlumnosToolStripMenuItem.Click += new System.EventHandler(this.informeDeAlumnosToolStripMenuItem_Click);
            // 
            // informeDeDiscosToolStripMenuItem
            // 
            this.informeDeDiscosToolStripMenuItem.Name = "informeDeDiscosToolStripMenuItem";
            this.informeDeDiscosToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.informeDeDiscosToolStripMenuItem.Text = "Informe de planes";
            this.informeDeDiscosToolStripMenuItem.Click += new System.EventHandler(this.informeDeDiscosToolStripMenuItem_Click);
            // 
            // informeDeUsuariosToolStripMenuItem
            // 
            this.informeDeUsuariosToolStripMenuItem.Name = "informeDeUsuariosToolStripMenuItem";
            this.informeDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.informeDeUsuariosToolStripMenuItem.Text = "Informe de usuarios";
            this.informeDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.informeDeUsuariosToolStripMenuItem_Click);
            // 
            // reporteDeMaterialDidacticoToolStripMenuItem
            // 
            this.reporteDeMaterialDidacticoToolStripMenuItem.Name = "reporteDeMaterialDidacticoToolStripMenuItem";
            this.reporteDeMaterialDidacticoToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.reporteDeMaterialDidacticoToolStripMenuItem.Text = "Reporte general";
            this.reporteDeMaterialDidacticoToolStripMenuItem.Click += new System.EventHandler(this.reporteDeMaterialDidacticoToolStripMenuItem_Click);
            // 
            // prestamosPorAlumnoToolStripMenuItem
            // 
            this.prestamosPorAlumnoToolStripMenuItem.Name = "prestamosPorAlumnoToolStripMenuItem";
            this.prestamosPorAlumnoToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.prestamosPorAlumnoToolStripMenuItem.Text = "Inscripciones por cliente";
            this.prestamosPorAlumnoToolStripMenuItem.Click += new System.EventHandler(this.prestamosPorAlumnoToolStripMenuItem_Click);
            // 
            // prestamosPorDiscoToolStripMenuItem
            // 
            this.prestamosPorDiscoToolStripMenuItem.Name = "prestamosPorDiscoToolStripMenuItem";
            this.prestamosPorDiscoToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.prestamosPorDiscoToolStripMenuItem.Text = "Inscripciones por plan";
            this.prestamosPorDiscoToolStripMenuItem.Click += new System.EventHandler(this.prestamosPorDiscoToolStripMenuItem_Click);
            // 
            // preferenciasToolStripMenuItem
            // 
            this.preferenciasToolStripMenuItem.Name = "preferenciasToolStripMenuItem";
            this.preferenciasToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.preferenciasToolStripMenuItem.Text = "Preferencias";
            this.preferenciasToolStripMenuItem.Click += new System.EventHandler(this.preferenciasToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GYMMAX.Properties.Resources.logogymmax1;
            this.pictureBox1.Location = new System.Drawing.Point(141, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 275);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "GYMMAX";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prestamosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeDePrestamosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeDeAlumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeDeDiscosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeMaterialDidacticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prestamosPorAlumnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prestamosPorDiscoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

