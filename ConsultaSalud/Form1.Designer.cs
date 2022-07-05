
namespace ConsultaSalud
{
    partial class Padre
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Padre));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGrid = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personaViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCargarInformacion = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel11 = new System.Windows.Forms.Panel();
            this.Exit = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Buscar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.submenudescarga = new System.Windows.Forms.Panel();
            this.bunifuFlatButton4 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.bunifuFlatButton3 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.submenu = new System.Windows.Forms.Panel();
            this.process_igss_salud = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ProcessIGSS = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Process_igss = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.process = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Excel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Mensaje = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip(this.components);
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.mySqlDataAdapter2 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personaViewModelBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.submenudescarga.SuspendLayout();
            this.panel9.SuspendLayout();
            this.submenu.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1155, 687);
            this.panel1.TabIndex = 0;
            this.bunifuToolTip1.SetToolTip(this.panel1, "");
            this.bunifuToolTip1.SetToolTipIcon(this.panel1, null);
            this.bunifuToolTip1.SetToolTipTitle(this.panel1, "");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGrid);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(258, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(897, 687);
            this.panel3.TabIndex = 1;
            this.bunifuToolTip1.SetToolTip(this.panel3, "");
            this.bunifuToolTip1.SetToolTipIcon(this.panel3, null);
            this.bunifuToolTip1.SetToolTipTitle(this.panel3, "");
            // 
            // dataGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGrid.DataSource = this.personaViewModelBindingSource;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.DoubleBuffered = true;
            this.dataGrid.EnableHeadersVisualStyles = false;
            this.dataGrid.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.dataGrid.HeaderForeColor = System.Drawing.Color.White;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid.Size = new System.Drawing.Size(897, 687);
            this.dataGrid.TabIndex = 0;
            this.bunifuToolTip1.SetToolTip(this.dataGrid, "");
            this.bunifuToolTip1.SetToolTipIcon(this.dataGrid, null);
            this.bunifuToolTip1.SetToolTipTitle(this.dataGrid, "");
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codigo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "nombre";
            this.dataGridViewTextBoxColumn2.FillWeight = 250F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 320;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "dpi";
            this.dataGridViewTextBoxColumn3.HeaderText = "DPI";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 175;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "fecha";
            this.dataGridViewTextBoxColumn4.HeaderText = "Fecha Nacimiento";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 175;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "telefono";
            this.dataGridViewTextBoxColumn5.HeaderText = "Telefono";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // personaViewModelBindingSource
            // 
            this.personaViewModelBindingSource.DataSource = typeof(ConsultaSalud.PersonaViewModel);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCargarInformacion);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.submenudescarga);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.submenu);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 687);
            this.panel2.TabIndex = 0;
            this.bunifuToolTip1.SetToolTip(this.panel2, "");
            this.bunifuToolTip1.SetToolTipIcon(this.panel2, null);
            this.bunifuToolTip1.SetToolTipTitle(this.panel2, "");
            // 
            // btnCargarInformacion
            // 
            this.btnCargarInformacion.Active = false;
            this.btnCargarInformacion.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(128)))), ((int)(((byte)(159)))));
            this.btnCargarInformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnCargarInformacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargarInformacion.BorderRadius = 0;
            this.btnCargarInformacion.ButtonText = "Cargar Informacion";
            this.btnCargarInformacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarInformacion.DisabledColor = System.Drawing.Color.Gray;
            this.btnCargarInformacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCargarInformacion.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCargarInformacion.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnCargarInformacion.Iconimage")));
            this.btnCargarInformacion.Iconimage_right = null;
            this.btnCargarInformacion.Iconimage_right_Selected = null;
            this.btnCargarInformacion.Iconimage_Selected = null;
            this.btnCargarInformacion.IconMarginLeft = 25;
            this.btnCargarInformacion.IconMarginRight = 0;
            this.btnCargarInformacion.IconRightVisible = true;
            this.btnCargarInformacion.IconRightZoom = 0D;
            this.btnCargarInformacion.IconVisible = true;
            this.btnCargarInformacion.IconZoom = 90D;
            this.btnCargarInformacion.IsTab = false;
            this.btnCargarInformacion.Location = new System.Drawing.Point(0, 454);
            this.btnCargarInformacion.Margin = new System.Windows.Forms.Padding(5);
            this.btnCargarInformacion.Name = "btnCargarInformacion";
            this.btnCargarInformacion.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnCargarInformacion.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnCargarInformacion.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCargarInformacion.selected = false;
            this.btnCargarInformacion.Size = new System.Drawing.Size(258, 53);
            this.btnCargarInformacion.TabIndex = 16;
            this.btnCargarInformacion.Text = "Cargar Informacion";
            this.btnCargarInformacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargarInformacion.Textcolor = System.Drawing.Color.White;
            this.btnCargarInformacion.TextFont = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bunifuToolTip1.SetToolTip(this.btnCargarInformacion, "Cargar Informacion");
            this.bunifuToolTip1.SetToolTipIcon(this.btnCargarInformacion, null);
            this.bunifuToolTip1.SetToolTipTitle(this.btnCargarInformacion, "Cargar Informacion");
            this.btnCargarInformacion.Click += new System.EventHandler(this.bunifuFlatButton1_Click_1);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.Exit);
            this.panel11.Controls.Add(this.Buscar);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 354);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(258, 100);
            this.panel11.TabIndex = 10;
            this.bunifuToolTip1.SetToolTip(this.panel11, "");
            this.bunifuToolTip1.SetToolTipIcon(this.panel11, null);
            this.bunifuToolTip1.SetToolTipTitle(this.panel11, "");
            // 
            // Exit
            // 
            this.Exit.Active = false;
            this.Exit.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Exit.BorderRadius = 0;
            this.Exit.ButtonText = "Salir";
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.DisabledColor = System.Drawing.Color.Gray;
            this.Exit.Dock = System.Windows.Forms.DockStyle.Top;
            this.Exit.Iconcolor = System.Drawing.Color.Transparent;
            this.Exit.Iconimage = ((System.Drawing.Image)(resources.GetObject("Exit.Iconimage")));
            this.Exit.Iconimage_right = null;
            this.Exit.Iconimage_right_Selected = null;
            this.Exit.Iconimage_Selected = null;
            this.Exit.IconMarginLeft = 0;
            this.Exit.IconMarginRight = 0;
            this.Exit.IconRightVisible = true;
            this.Exit.IconRightZoom = 0D;
            this.Exit.IconVisible = true;
            this.Exit.IconZoom = 90D;
            this.Exit.IsTab = false;
            this.Exit.Location = new System.Drawing.Point(0, 50);
            this.Exit.Margin = new System.Windows.Forms.Padding(5);
            this.Exit.Name = "Exit";
            this.Exit.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.Exit.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.Exit.OnHoverTextColor = System.Drawing.Color.White;
            this.Exit.selected = false;
            this.Exit.Size = new System.Drawing.Size(258, 50);
            this.Exit.TabIndex = 14;
            this.Exit.Text = "Salir";
            this.Exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Exit.Textcolor = System.Drawing.Color.White;
            this.Exit.TextFont = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bunifuToolTip1.SetToolTip(this.Exit, "Salir");
            this.bunifuToolTip1.SetToolTipIcon(this.Exit, null);
            this.bunifuToolTip1.SetToolTipTitle(this.Exit, "Salir");
            this.Exit.Click += new System.EventHandler(this.Exit_Click_1);
            // 
            // Buscar
            // 
            this.Buscar.Active = false;
            this.Buscar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.Buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Buscar.BorderRadius = 0;
            this.Buscar.ButtonText = "Buscar Persona";
            this.Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Buscar.DisabledColor = System.Drawing.Color.Gray;
            this.Buscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Buscar.Iconcolor = System.Drawing.Color.Transparent;
            this.Buscar.Iconimage = ((System.Drawing.Image)(resources.GetObject("Buscar.Iconimage")));
            this.Buscar.Iconimage_right = null;
            this.Buscar.Iconimage_right_Selected = null;
            this.Buscar.Iconimage_Selected = null;
            this.Buscar.IconMarginLeft = 0;
            this.Buscar.IconMarginRight = 0;
            this.Buscar.IconRightVisible = true;
            this.Buscar.IconRightZoom = 0D;
            this.Buscar.IconVisible = true;
            this.Buscar.IconZoom = 90D;
            this.Buscar.IsTab = false;
            this.Buscar.Location = new System.Drawing.Point(0, 0);
            this.Buscar.Margin = new System.Windows.Forms.Padding(5);
            this.Buscar.Name = "Buscar";
            this.Buscar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.Buscar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.Buscar.OnHoverTextColor = System.Drawing.Color.White;
            this.Buscar.selected = false;
            this.Buscar.Size = new System.Drawing.Size(258, 50);
            this.Buscar.TabIndex = 13;
            this.Buscar.Text = "Buscar Persona";
            this.Buscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Buscar.Textcolor = System.Drawing.Color.White;
            this.Buscar.TextFont = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bunifuToolTip1.SetToolTip(this.Buscar, "Buscar Persona");
            this.bunifuToolTip1.SetToolTipIcon(this.Buscar, null);
            this.bunifuToolTip1.SetToolTipTitle(this.Buscar, "Buscar Persona");
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // submenudescarga
            // 
            this.submenudescarga.Controls.Add(this.bunifuFlatButton4);
            this.submenudescarga.Dock = System.Windows.Forms.DockStyle.Top;
            this.submenudescarga.Location = new System.Drawing.Point(0, 302);
            this.submenudescarga.Name = "submenudescarga";
            this.submenudescarga.Size = new System.Drawing.Size(258, 52);
            this.submenudescarga.TabIndex = 9;
            this.bunifuToolTip1.SetToolTip(this.submenudescarga, "");
            this.bunifuToolTip1.SetToolTipIcon(this.submenudescarga, null);
            this.bunifuToolTip1.SetToolTipTitle(this.submenudescarga, "");
            // 
            // bunifuFlatButton4
            // 
            this.bunifuFlatButton4.Active = false;
            this.bunifuFlatButton4.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.bunifuFlatButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.bunifuFlatButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton4.BorderRadius = 0;
            this.bunifuFlatButton4.ButtonText = "Descargar Excel";
            this.bunifuFlatButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton4.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuFlatButton4.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton4.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton4.Iconimage")));
            this.bunifuFlatButton4.Iconimage_right = null;
            this.bunifuFlatButton4.Iconimage_right_Selected = null;
            this.bunifuFlatButton4.Iconimage_Selected = null;
            this.bunifuFlatButton4.IconMarginLeft = 25;
            this.bunifuFlatButton4.IconMarginRight = 0;
            this.bunifuFlatButton4.IconRightVisible = true;
            this.bunifuFlatButton4.IconRightZoom = 0D;
            this.bunifuFlatButton4.IconVisible = true;
            this.bunifuFlatButton4.IconZoom = 90D;
            this.bunifuFlatButton4.IsTab = false;
            this.bunifuFlatButton4.Location = new System.Drawing.Point(0, 0);
            this.bunifuFlatButton4.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuFlatButton4.Name = "bunifuFlatButton4";
            this.bunifuFlatButton4.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.bunifuFlatButton4.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.bunifuFlatButton4.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton4.selected = false;
            this.bunifuFlatButton4.Size = new System.Drawing.Size(258, 52);
            this.bunifuFlatButton4.TabIndex = 11;
            this.bunifuFlatButton4.Text = "Descargar Excel";
            this.bunifuFlatButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton4.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton4.TextFont = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuToolTip1.SetToolTip(this.bunifuFlatButton4, "Descargar");
            this.bunifuToolTip1.SetToolTipIcon(this.bunifuFlatButton4, null);
            this.bunifuToolTip1.SetToolTipTitle(this.bunifuFlatButton4, "Descargar");
            this.bunifuFlatButton4.Click += new System.EventHandler(this.bunifuFlatButton4_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.bunifuFlatButton3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 252);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(258, 50);
            this.panel9.TabIndex = 8;
            this.bunifuToolTip1.SetToolTip(this.panel9, "");
            this.bunifuToolTip1.SetToolTipIcon(this.panel9, null);
            this.bunifuToolTip1.SetToolTipTitle(this.panel9, "");
            // 
            // bunifuFlatButton3
            // 
            this.bunifuFlatButton3.Active = false;
            this.bunifuFlatButton3.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.bunifuFlatButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.bunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton3.BorderRadius = 0;
            this.bunifuFlatButton3.ButtonText = "Buscar en Base de Datos Local";
            this.bunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton3.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton3.Iconimage")));
            this.bunifuFlatButton3.Iconimage_right = null;
            this.bunifuFlatButton3.Iconimage_right_Selected = null;
            this.bunifuFlatButton3.Iconimage_Selected = null;
            this.bunifuFlatButton3.IconMarginLeft = 0;
            this.bunifuFlatButton3.IconMarginRight = 0;
            this.bunifuFlatButton3.IconRightVisible = true;
            this.bunifuFlatButton3.IconRightZoom = 0D;
            this.bunifuFlatButton3.IconVisible = true;
            this.bunifuFlatButton3.IconZoom = 90D;
            this.bunifuFlatButton3.IsTab = false;
            this.bunifuFlatButton3.Location = new System.Drawing.Point(0, 0);
            this.bunifuFlatButton3.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuFlatButton3.Name = "bunifuFlatButton3";
            this.bunifuFlatButton3.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.bunifuFlatButton3.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.bunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton3.selected = false;
            this.bunifuFlatButton3.Size = new System.Drawing.Size(258, 50);
            this.bunifuFlatButton3.TabIndex = 10;
            this.bunifuFlatButton3.Text = "Buscar en Base de Datos Local";
            this.bunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton3.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton3.TextFont = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuToolTip1.SetToolTip(this.bunifuFlatButton3, "Descargar");
            this.bunifuToolTip1.SetToolTipIcon(this.bunifuFlatButton3, null);
            this.bunifuToolTip1.SetToolTipTitle(this.bunifuFlatButton3, "Descargar");
            this.bunifuFlatButton3.Click += new System.EventHandler(this.bunifuFlatButton3_Click);
            // 
            // submenu
            // 
            this.submenu.Controls.Add(this.process_igss_salud);
            this.submenu.Controls.Add(this.ProcessIGSS);
            this.submenu.Controls.Add(this.Process_igss);
            this.submenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.submenu.Location = new System.Drawing.Point(0, 100);
            this.submenu.Name = "submenu";
            this.submenu.Size = new System.Drawing.Size(258, 152);
            this.submenu.TabIndex = 7;
            this.bunifuToolTip1.SetToolTip(this.submenu, "");
            this.bunifuToolTip1.SetToolTipIcon(this.submenu, null);
            this.bunifuToolTip1.SetToolTipTitle(this.submenu, "");
            // 
            // process_igss_salud
            // 
            this.process_igss_salud.Active = false;
            this.process_igss_salud.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(128)))), ((int)(((byte)(159)))));
            this.process_igss_salud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.process_igss_salud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.process_igss_salud.BorderRadius = 0;
            this.process_igss_salud.ButtonText = "Procesar IGSS Y Salud";
            this.process_igss_salud.Cursor = System.Windows.Forms.Cursors.Hand;
            this.process_igss_salud.DisabledColor = System.Drawing.Color.Gray;
            this.process_igss_salud.Dock = System.Windows.Forms.DockStyle.Top;
            this.process_igss_salud.Iconcolor = System.Drawing.Color.Transparent;
            this.process_igss_salud.Iconimage = ((System.Drawing.Image)(resources.GetObject("process_igss_salud.Iconimage")));
            this.process_igss_salud.Iconimage_right = null;
            this.process_igss_salud.Iconimage_right_Selected = null;
            this.process_igss_salud.Iconimage_Selected = null;
            this.process_igss_salud.IconMarginLeft = 25;
            this.process_igss_salud.IconMarginRight = 0;
            this.process_igss_salud.IconRightVisible = true;
            this.process_igss_salud.IconRightZoom = 0D;
            this.process_igss_salud.IconVisible = true;
            this.process_igss_salud.IconZoom = 90D;
            this.process_igss_salud.IsTab = false;
            this.process_igss_salud.Location = new System.Drawing.Point(0, 100);
            this.process_igss_salud.Margin = new System.Windows.Forms.Padding(5);
            this.process_igss_salud.Name = "process_igss_salud";
            this.process_igss_salud.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.process_igss_salud.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.process_igss_salud.OnHoverTextColor = System.Drawing.Color.White;
            this.process_igss_salud.selected = false;
            this.process_igss_salud.Size = new System.Drawing.Size(258, 53);
            this.process_igss_salud.TabIndex = 14;
            this.process_igss_salud.Text = "Procesar IGSS Y Salud";
            this.process_igss_salud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.process_igss_salud.Textcolor = System.Drawing.Color.White;
            this.process_igss_salud.TextFont = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bunifuToolTip1.SetToolTip(this.process_igss_salud, "Procesar IGSS Y Salud");
            this.bunifuToolTip1.SetToolTipIcon(this.process_igss_salud, null);
            this.bunifuToolTip1.SetToolTipTitle(this.process_igss_salud, "Procesar IGSS Y Salud");
            this.process_igss_salud.Click += new System.EventHandler(this.process_igss_salud_Click);
            // 
            // ProcessIGSS
            // 
            this.ProcessIGSS.Active = false;
            this.ProcessIGSS.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(128)))), ((int)(((byte)(159)))));
            this.ProcessIGSS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ProcessIGSS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProcessIGSS.BorderRadius = 0;
            this.ProcessIGSS.ButtonText = "Procesar Salud";
            this.ProcessIGSS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProcessIGSS.DisabledColor = System.Drawing.Color.Gray;
            this.ProcessIGSS.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProcessIGSS.Iconcolor = System.Drawing.Color.Transparent;
            this.ProcessIGSS.Iconimage = ((System.Drawing.Image)(resources.GetObject("ProcessIGSS.Iconimage")));
            this.ProcessIGSS.Iconimage_right = null;
            this.ProcessIGSS.Iconimage_right_Selected = null;
            this.ProcessIGSS.Iconimage_Selected = null;
            this.ProcessIGSS.IconMarginLeft = 25;
            this.ProcessIGSS.IconMarginRight = 0;
            this.ProcessIGSS.IconRightVisible = true;
            this.ProcessIGSS.IconRightZoom = 0D;
            this.ProcessIGSS.IconVisible = true;
            this.ProcessIGSS.IconZoom = 90D;
            this.ProcessIGSS.IsTab = false;
            this.ProcessIGSS.Location = new System.Drawing.Point(0, 50);
            this.ProcessIGSS.Margin = new System.Windows.Forms.Padding(5);
            this.ProcessIGSS.Name = "ProcessIGSS";
            this.ProcessIGSS.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ProcessIGSS.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ProcessIGSS.OnHoverTextColor = System.Drawing.Color.White;
            this.ProcessIGSS.selected = false;
            this.ProcessIGSS.Size = new System.Drawing.Size(258, 50);
            this.ProcessIGSS.TabIndex = 13;
            this.ProcessIGSS.Text = "Procesar Salud";
            this.ProcessIGSS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProcessIGSS.Textcolor = System.Drawing.Color.White;
            this.ProcessIGSS.TextFont = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bunifuToolTip1.SetToolTip(this.ProcessIGSS, "Procesar Salud");
            this.bunifuToolTip1.SetToolTipIcon(this.ProcessIGSS, null);
            this.bunifuToolTip1.SetToolTipTitle(this.ProcessIGSS, "Procesar Salud");
            this.ProcessIGSS.Click += new System.EventHandler(this.process_Click);
            // 
            // Process_igss
            // 
            this.Process_igss.Active = false;
            this.Process_igss.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(128)))), ((int)(((byte)(159)))));
            this.Process_igss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.Process_igss.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Process_igss.BorderRadius = 0;
            this.Process_igss.ButtonText = "Procesar IGSS";
            this.Process_igss.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Process_igss.DisabledColor = System.Drawing.Color.Gray;
            this.Process_igss.Dock = System.Windows.Forms.DockStyle.Top;
            this.Process_igss.Iconcolor = System.Drawing.Color.Transparent;
            this.Process_igss.Iconimage = ((System.Drawing.Image)(resources.GetObject("Process_igss.Iconimage")));
            this.Process_igss.Iconimage_right = null;
            this.Process_igss.Iconimage_right_Selected = null;
            this.Process_igss.Iconimage_Selected = null;
            this.Process_igss.IconMarginLeft = 25;
            this.Process_igss.IconMarginRight = 0;
            this.Process_igss.IconRightVisible = true;
            this.Process_igss.IconRightZoom = 0D;
            this.Process_igss.IconVisible = true;
            this.Process_igss.IconZoom = 90D;
            this.Process_igss.IsTab = false;
            this.Process_igss.Location = new System.Drawing.Point(0, 0);
            this.Process_igss.Margin = new System.Windows.Forms.Padding(15, 5, 5, 5);
            this.Process_igss.Name = "Process_igss";
            this.Process_igss.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.Process_igss.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.Process_igss.OnHoverTextColor = System.Drawing.Color.White;
            this.Process_igss.selected = false;
            this.Process_igss.Size = new System.Drawing.Size(258, 50);
            this.Process_igss.TabIndex = 12;
            this.Process_igss.Text = "Procesar IGSS";
            this.Process_igss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Process_igss.Textcolor = System.Drawing.Color.White;
            this.Process_igss.TextFont = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bunifuToolTip1.SetToolTip(this.Process_igss, "Procesar IGSS");
            this.bunifuToolTip1.SetToolTipIcon(this.Process_igss, null);
            this.bunifuToolTip1.SetToolTipTitle(this.Process_igss, "Procesar IGSS");
            this.Process_igss.Click += new System.EventHandler(this.ProcessIGSS_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.process);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 50);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(258, 50);
            this.panel7.TabIndex = 6;
            this.bunifuToolTip1.SetToolTip(this.panel7, "");
            this.bunifuToolTip1.SetToolTipIcon(this.panel7, null);
            this.bunifuToolTip1.SetToolTipTitle(this.panel7, "");
            // 
            // process
            // 
            this.process.Active = false;
            this.process.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.process.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.process.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.process.BorderRadius = 0;
            this.process.ButtonText = "Procesar Archivo";
            this.process.Cursor = System.Windows.Forms.Cursors.Hand;
            this.process.DisabledColor = System.Drawing.Color.Gray;
            this.process.Dock = System.Windows.Forms.DockStyle.Top;
            this.process.Iconcolor = System.Drawing.Color.Transparent;
            this.process.Iconimage = ((System.Drawing.Image)(resources.GetObject("process.Iconimage")));
            this.process.Iconimage_right = null;
            this.process.Iconimage_right_Selected = null;
            this.process.Iconimage_Selected = null;
            this.process.IconMarginLeft = 0;
            this.process.IconMarginRight = 0;
            this.process.IconRightVisible = true;
            this.process.IconRightZoom = 0D;
            this.process.IconVisible = true;
            this.process.IconZoom = 90D;
            this.process.IsTab = false;
            this.process.Location = new System.Drawing.Point(0, 0);
            this.process.Margin = new System.Windows.Forms.Padding(5);
            this.process.Name = "process";
            this.process.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.process.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.process.OnHoverTextColor = System.Drawing.Color.White;
            this.process.selected = false;
            this.process.Size = new System.Drawing.Size(258, 50);
            this.process.TabIndex = 9;
            this.process.Text = "Procesar Archivo";
            this.process.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.process.Textcolor = System.Drawing.Color.White;
            this.process.TextFont = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bunifuToolTip1.SetToolTip(this.process, "Procesar Archivo");
            this.bunifuToolTip1.SetToolTipIcon(this.process, null);
            this.bunifuToolTip1.SetToolTipTitle(this.process, "Procesar Archivo");
            this.process.Click += new System.EventHandler(this.process_Click_1);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.Excel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(258, 50);
            this.panel6.TabIndex = 5;
            this.bunifuToolTip1.SetToolTip(this.panel6, "");
            this.bunifuToolTip1.SetToolTipIcon(this.panel6, null);
            this.bunifuToolTip1.SetToolTipTitle(this.panel6, "");
            // 
            // Excel
            // 
            this.Excel.Active = false;
            this.Excel.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.Excel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.Excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Excel.BorderRadius = 0;
            this.Excel.ButtonText = "Cargar Archivo";
            this.Excel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Excel.DisabledColor = System.Drawing.Color.Gray;
            this.Excel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Excel.Iconcolor = System.Drawing.Color.Transparent;
            this.Excel.Iconimage = ((System.Drawing.Image)(resources.GetObject("Excel.Iconimage")));
            this.Excel.Iconimage_right = null;
            this.Excel.Iconimage_right_Selected = null;
            this.Excel.Iconimage_Selected = null;
            this.Excel.IconMarginLeft = 0;
            this.Excel.IconMarginRight = 0;
            this.Excel.IconRightVisible = true;
            this.Excel.IconRightZoom = 0D;
            this.Excel.IconVisible = true;
            this.Excel.IconZoom = 90D;
            this.Excel.IsTab = false;
            this.Excel.Location = new System.Drawing.Point(0, 0);
            this.Excel.Margin = new System.Windows.Forms.Padding(5);
            this.Excel.Name = "Excel";
            this.Excel.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.Excel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(98)))));
            this.Excel.OnHoverTextColor = System.Drawing.Color.White;
            this.Excel.selected = false;
            this.Excel.Size = new System.Drawing.Size(258, 50);
            this.Excel.TabIndex = 8;
            this.Excel.Text = "Cargar Archivo";
            this.Excel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Excel.Textcolor = System.Drawing.Color.White;
            this.Excel.TextFont = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bunifuToolTip1.SetToolTip(this.Excel, "Cargar Archivo");
            this.bunifuToolTip1.SetToolTipIcon(this.Excel, null);
            this.bunifuToolTip1.SetToolTipTitle(this.Excel, "Cargar Archivo");
            this.Excel.Click += new System.EventHandler(this.Excel_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Mensaje);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 598);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(258, 89);
            this.panel4.TabIndex = 4;
            this.bunifuToolTip1.SetToolTip(this.panel4, "");
            this.bunifuToolTip1.SetToolTipIcon(this.panel4, null);
            this.bunifuToolTip1.SetToolTipTitle(this.panel4, "");
            // 
            // Mensaje
            // 
            this.Mensaje.AutoEllipsis = false;
            this.Mensaje.CursorType = null;
            this.Mensaje.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Mensaje.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mensaje.Location = new System.Drawing.Point(0, 89);
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Mensaje.Size = new System.Drawing.Size(258, 0);
            this.Mensaje.TabIndex = 0;
            this.Mensaje.Text = null;
            this.Mensaje.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Mensaje.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.bunifuToolTip1.SetToolTip(this.Mensaje, "");
            this.bunifuToolTip1.SetToolTipIcon(this.Mensaje, null);
            this.bunifuToolTip1.SetToolTipTitle(this.Mensaje, "");
            // 
            // bunifuToolTip1
            // 
            this.bunifuToolTip1.Active = true;
            this.bunifuToolTip1.AlignTextWithTitle = false;
            this.bunifuToolTip1.AllowAutoClose = false;
            this.bunifuToolTip1.AllowFading = true;
            this.bunifuToolTip1.AutoCloseDuration = 5000;
            this.bunifuToolTip1.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuToolTip1.BorderColor = System.Drawing.Color.Gainsboro;
            this.bunifuToolTip1.ClickToShowDisplayControl = false;
            this.bunifuToolTip1.ConvertNewlinesToBreakTags = true;
            this.bunifuToolTip1.DisplayControl = null;
            this.bunifuToolTip1.EntryAnimationSpeed = 350;
            this.bunifuToolTip1.ExitAnimationSpeed = 200;
            this.bunifuToolTip1.GenerateAutoCloseDuration = false;
            this.bunifuToolTip1.IconMargin = 6;
            this.bunifuToolTip1.InitialDelay = 0;
            this.bunifuToolTip1.Name = "bunifuToolTip1";
            this.bunifuToolTip1.Opacity = 1D;
            this.bunifuToolTip1.OverrideToolTipTitles = false;
            this.bunifuToolTip1.Padding = new System.Windows.Forms.Padding(10);
            this.bunifuToolTip1.ReshowDelay = 100;
            this.bunifuToolTip1.ShowAlways = true;
            this.bunifuToolTip1.ShowBorders = false;
            this.bunifuToolTip1.ShowIcons = true;
            this.bunifuToolTip1.ShowShadows = true;
            this.bunifuToolTip1.Tag = null;
            this.bunifuToolTip1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuToolTip1.TextForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuToolTip1.TextMargin = 2;
            this.bunifuToolTip1.TitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bunifuToolTip1.TitleForeColor = System.Drawing.Color.Black;
            this.bunifuToolTip1.ToolTipPosition = new System.Drawing.Point(0, 0);
            this.bunifuToolTip1.ToolTipTitle = null;
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // mySqlDataAdapter2
            // 
            this.mySqlDataAdapter2.DeleteCommand = null;
            this.mySqlDataAdapter2.InsertCommand = null;
            this.mySqlDataAdapter2.SelectCommand = null;
            this.mySqlDataAdapter2.UpdateCommand = null;
            // 
            // Padre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 687);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Padre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas";
            this.Load += new System.EventHandler(this.Padre_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personaViewModelBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.submenudescarga.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.submenu.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dpiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private Bunifu.UI.WinForms.BunifuToolTip bunifuToolTip1;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.UI.WinForms.BunifuLabel Mensaje;
        private System.Windows.Forms.Panel panel11;
        private Bunifu.Framework.UI.BunifuFlatButton Exit;
        private Bunifu.Framework.UI.BunifuFlatButton Buscar;
        private System.Windows.Forms.Panel submenudescarga;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton4;
        private System.Windows.Forms.Panel panel9;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton3;
        private System.Windows.Forms.Panel submenu;
        private Bunifu.Framework.UI.BunifuFlatButton process_igss_salud;
        private Bunifu.Framework.UI.BunifuFlatButton ProcessIGSS;
        private Bunifu.Framework.UI.BunifuFlatButton Process_igss;
        private System.Windows.Forms.Panel panel7;
        private Bunifu.Framework.UI.BunifuFlatButton process;
        private System.Windows.Forms.Panel panel6;
        private Bunifu.Framework.UI.BunifuFlatButton Excel;
        private System.Windows.Forms.BindingSource personaViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn saludDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn igssDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter2;
        private Bunifu.Framework.UI.BunifuFlatButton btnCargarInformacion;
    }
}

