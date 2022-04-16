
namespace TGS.Views {
    partial class ListPage {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListPage));
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.btn_MenuLogout = new FontAwesome.Sharp.IconButton();
            this.btn_MenuOptions = new FontAwesome.Sharp.IconButton();
            this.btn_MenuPacientes = new FontAwesome.Sharp.IconButton();
            this.btn_MenuChat = new FontAwesome.Sharp.IconButton();
            this.btn_MenuCalendar = new FontAwesome.Sharp.IconButton();
            this.btn_MenuHome = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.img_LogoMenu = new System.Windows.Forms.PictureBox();
            this.btn_MenuHamburger = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_TitleBar = new System.Windows.Forms.Panel();
            this.lbl_Date = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_Minimize = new FontAwesome.Sharp.IconButton();
            this.btn_Maximize = new FontAwesome.Sharp.IconButton();
            this.btn_Close = new FontAwesome.Sharp.IconButton();
            this.pnl_Content = new System.Windows.Forms.Panel();
            this.tb_List = new System.Windows.Forms.TableLayoutPanel();
            this.lv_List = new System.Windows.Forms.ListView();
            this.lbl_ListTitle = new System.Windows.Forms.Label();
            this.pnl_Filter = new System.Windows.Forms.Panel();
            this.tb_Filter = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Filter = new System.Windows.Forms.Label();
            this.txt_Filter = new System.Windows.Forms.TextBox();
            this.btn_Register = new FontAwesome.Sharp.IconButton();
            this.pnl_Menu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_LogoMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_TitleBar.SuspendLayout();
            this.pnl_Content.SuspendLayout();
            this.tb_List.SuspendLayout();
            this.pnl_Filter.SuspendLayout();
            this.tb_Filter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Menu
            // 
            this.pnl_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(130)))), ((int)(((byte)(219)))));
            this.pnl_Menu.Controls.Add(this.btn_MenuLogout);
            this.pnl_Menu.Controls.Add(this.btn_MenuOptions);
            this.pnl_Menu.Controls.Add(this.btn_MenuPacientes);
            this.pnl_Menu.Controls.Add(this.btn_MenuChat);
            this.pnl_Menu.Controls.Add(this.btn_MenuCalendar);
            this.pnl_Menu.Controls.Add(this.btn_MenuHome);
            this.pnl_Menu.Controls.Add(this.panel1);
            this.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Menu.Location = new System.Drawing.Point(0, 0);
            this.pnl_Menu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_Menu.Name = "pnl_Menu";
            this.pnl_Menu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pnl_Menu.Size = new System.Drawing.Size(263, 881);
            this.pnl_Menu.TabIndex = 0;
            // 
            // btn_MenuLogout
            // 
            this.btn_MenuLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MenuLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_MenuLogout.FlatAppearance.BorderSize = 0;
            this.btn_MenuLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MenuLogout.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_MenuLogout.ForeColor = System.Drawing.Color.White;
            this.btn_MenuLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btn_MenuLogout.IconColor = System.Drawing.Color.White;
            this.btn_MenuLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_MenuLogout.IconSize = 30;
            this.btn_MenuLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuLogout.Location = new System.Drawing.Point(0, 814);
            this.btn_MenuLogout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_MenuLogout.Name = "btn_MenuLogout";
            this.btn_MenuLogout.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btn_MenuLogout.Size = new System.Drawing.Size(263, 47);
            this.btn_MenuLogout.TabIndex = 7;
            this.btn_MenuLogout.Tag = "Logout";
            this.btn_MenuLogout.Text = "  Logout";
            this.btn_MenuLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_MenuLogout.UseVisualStyleBackColor = true;
            this.btn_MenuLogout.Click += new System.EventHandler(this.btn_MenuLogout_Click);
            // 
            // btn_MenuOptions
            // 
            this.btn_MenuOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MenuOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MenuOptions.FlatAppearance.BorderSize = 0;
            this.btn_MenuOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MenuOptions.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_MenuOptions.ForeColor = System.Drawing.Color.White;
            this.btn_MenuOptions.IconChar = FontAwesome.Sharp.IconChar.Sun;
            this.btn_MenuOptions.IconColor = System.Drawing.Color.White;
            this.btn_MenuOptions.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_MenuOptions.IconSize = 30;
            this.btn_MenuOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuOptions.Location = new System.Drawing.Point(0, 501);
            this.btn_MenuOptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_MenuOptions.Name = "btn_MenuOptions";
            this.btn_MenuOptions.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btn_MenuOptions.Size = new System.Drawing.Size(263, 101);
            this.btn_MenuOptions.TabIndex = 6;
            this.btn_MenuOptions.Tag = "Options";
            this.btn_MenuOptions.Text = "  Configurações";
            this.btn_MenuOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_MenuOptions.UseVisualStyleBackColor = true;
            this.btn_MenuOptions.Click += new System.EventHandler(this.btn_MenuOptions_Click);
            // 
            // btn_MenuPacientes
            // 
            this.btn_MenuPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MenuPacientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MenuPacientes.FlatAppearance.BorderSize = 0;
            this.btn_MenuPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MenuPacientes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_MenuPacientes.ForeColor = System.Drawing.Color.White;
            this.btn_MenuPacientes.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            this.btn_MenuPacientes.IconColor = System.Drawing.Color.White;
            this.btn_MenuPacientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_MenuPacientes.IconSize = 30;
            this.btn_MenuPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuPacientes.Location = new System.Drawing.Point(0, 400);
            this.btn_MenuPacientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_MenuPacientes.Name = "btn_MenuPacientes";
            this.btn_MenuPacientes.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btn_MenuPacientes.Size = new System.Drawing.Size(263, 101);
            this.btn_MenuPacientes.TabIndex = 5;
            this.btn_MenuPacientes.Tag = "Patients";
            this.btn_MenuPacientes.Text = "  Pacientes";
            this.btn_MenuPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuPacientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_MenuPacientes.UseVisualStyleBackColor = true;
            this.btn_MenuPacientes.Click += new System.EventHandler(this.btn_MenuPacientes_Click);
            // 
            // btn_MenuChat
            // 
            this.btn_MenuChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MenuChat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MenuChat.FlatAppearance.BorderSize = 0;
            this.btn_MenuChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MenuChat.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_MenuChat.ForeColor = System.Drawing.Color.White;
            this.btn_MenuChat.IconChar = FontAwesome.Sharp.IconChar.CommentDots;
            this.btn_MenuChat.IconColor = System.Drawing.Color.White;
            this.btn_MenuChat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_MenuChat.IconSize = 30;
            this.btn_MenuChat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuChat.Location = new System.Drawing.Point(0, 299);
            this.btn_MenuChat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_MenuChat.Name = "btn_MenuChat";
            this.btn_MenuChat.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btn_MenuChat.Size = new System.Drawing.Size(263, 101);
            this.btn_MenuChat.TabIndex = 4;
            this.btn_MenuChat.Tag = "Chat";
            this.btn_MenuChat.Text = "  Chat";
            this.btn_MenuChat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuChat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_MenuChat.UseVisualStyleBackColor = true;
            this.btn_MenuChat.Click += new System.EventHandler(this.btn_MenuChat_Click);
            // 
            // btn_MenuCalendar
            // 
            this.btn_MenuCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MenuCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MenuCalendar.FlatAppearance.BorderSize = 0;
            this.btn_MenuCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MenuCalendar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_MenuCalendar.ForeColor = System.Drawing.Color.White;
            this.btn_MenuCalendar.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.btn_MenuCalendar.IconColor = System.Drawing.Color.White;
            this.btn_MenuCalendar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_MenuCalendar.IconSize = 30;
            this.btn_MenuCalendar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuCalendar.Location = new System.Drawing.Point(0, 198);
            this.btn_MenuCalendar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_MenuCalendar.Name = "btn_MenuCalendar";
            this.btn_MenuCalendar.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btn_MenuCalendar.Size = new System.Drawing.Size(263, 101);
            this.btn_MenuCalendar.TabIndex = 3;
            this.btn_MenuCalendar.Tag = "Calendar";
            this.btn_MenuCalendar.Text = "  Calendário";
            this.btn_MenuCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuCalendar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_MenuCalendar.UseVisualStyleBackColor = true;
            this.btn_MenuCalendar.Click += new System.EventHandler(this.btn_MenuCalendar_Click);
            // 
            // btn_MenuHome
            // 
            this.btn_MenuHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MenuHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MenuHome.FlatAppearance.BorderSize = 0;
            this.btn_MenuHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MenuHome.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_MenuHome.ForeColor = System.Drawing.Color.White;
            this.btn_MenuHome.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.btn_MenuHome.IconColor = System.Drawing.Color.White;
            this.btn_MenuHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_MenuHome.IconSize = 30;
            this.btn_MenuHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuHome.Location = new System.Drawing.Point(0, 97);
            this.btn_MenuHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_MenuHome.Name = "btn_MenuHome";
            this.btn_MenuHome.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btn_MenuHome.Size = new System.Drawing.Size(263, 101);
            this.btn_MenuHome.TabIndex = 2;
            this.btn_MenuHome.Tag = "Home";
            this.btn_MenuHome.Text = "  Home";
            this.btn_MenuHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_MenuHome.UseVisualStyleBackColor = true;
            this.btn_MenuHome.Click += new System.EventHandler(this.btn_MenuHome_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.img_LogoMenu);
            this.panel1.Controls.Add(this.btn_MenuHamburger);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 97);
            this.panel1.TabIndex = 0;
            // 
            // img_LogoMenu
            // 
            this.img_LogoMenu.Image = ((System.Drawing.Image)(resources.GetObject("img_LogoMenu.Image")));
            this.img_LogoMenu.Location = new System.Drawing.Point(38, 16);
            this.img_LogoMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.img_LogoMenu.Name = "img_LogoMenu";
            this.img_LogoMenu.Size = new System.Drawing.Size(119, 67);
            this.img_LogoMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_LogoMenu.TabIndex = 2;
            this.img_LogoMenu.TabStop = false;
            // 
            // btn_MenuHamburger
            // 
            this.btn_MenuHamburger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MenuHamburger.FlatAppearance.BorderSize = 0;
            this.btn_MenuHamburger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MenuHamburger.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.btn_MenuHamburger.IconColor = System.Drawing.Color.White;
            this.btn_MenuHamburger.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_MenuHamburger.IconSize = 30;
            this.btn_MenuHamburger.Location = new System.Drawing.Point(187, 16);
            this.btn_MenuHamburger.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_MenuHamburger.Name = "btn_MenuHamburger";
            this.btn_MenuHamburger.Size = new System.Drawing.Size(69, 80);
            this.btn_MenuHamburger.TabIndex = 1;
            this.btn_MenuHamburger.UseVisualStyleBackColor = true;
            this.btn_MenuHamburger.Click += new System.EventHandler(this.btn_MenuHamburger_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnl_TitleBar
            // 
            this.pnl_TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.pnl_TitleBar.Controls.Add(this.lbl_Date);
            this.pnl_TitleBar.Controls.Add(this.lbl_Title);
            this.pnl_TitleBar.Controls.Add(this.btn_Minimize);
            this.pnl_TitleBar.Controls.Add(this.pictureBox1);
            this.pnl_TitleBar.Controls.Add(this.btn_Maximize);
            this.pnl_TitleBar.Controls.Add(this.btn_Close);
            this.pnl_TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TitleBar.Location = new System.Drawing.Point(263, 0);
            this.pnl_TitleBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_TitleBar.Name = "pnl_TitleBar";
            this.pnl_TitleBar.Size = new System.Drawing.Size(1182, 97);
            this.pnl_TitleBar.TabIndex = 1;
            this.pnl_TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_TitleBar_MouseDown);
            // 
            // lbl_Date
            // 
            this.lbl_Date.AutoSize = true;
            this.lbl_Date.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(88)))), ((int)(((byte)(145)))));
            this.lbl_Date.Location = new System.Drawing.Point(106, 48);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(123, 37);
            this.lbl_Date.TabIndex = 6;
            this.lbl_Date.Text = "--/--/----";
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(88)))), ((int)(((byte)(145)))));
            this.lbl_Title.Location = new System.Drawing.Point(96, 4);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(95, 47);
            this.lbl_Title.TabIndex = 5;
            this.lbl_Title.Text = "Title";
            // 
            // btn_Minimize
            // 
            this.btn_Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Minimize.FlatAppearance.BorderSize = 0;
            this.btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Minimize.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btn_Minimize.IconColor = System.Drawing.Color.White;
            this.btn_Minimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Minimize.IconSize = 20;
            this.btn_Minimize.Location = new System.Drawing.Point(1027, 0);
            this.btn_Minimize.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            this.btn_Minimize.Name = "btn_Minimize";
            this.btn_Minimize.Size = new System.Drawing.Size(51, 33);
            this.btn_Minimize.TabIndex = 12;
            this.btn_Minimize.UseVisualStyleBackColor = false;
            this.btn_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
            // 
            // btn_Maximize
            // 
            this.btn_Maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Maximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(130)))), ((int)(((byte)(219)))));
            this.btn_Maximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Maximize.FlatAppearance.BorderSize = 0;
            this.btn_Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Maximize.IconChar = FontAwesome.Sharp.IconChar.ExternalLinkAlt;
            this.btn_Maximize.IconColor = System.Drawing.Color.White;
            this.btn_Maximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Maximize.IconSize = 20;
            this.btn_Maximize.Location = new System.Drawing.Point(1079, 0);
            this.btn_Maximize.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btn_Maximize.Name = "btn_Maximize";
            this.btn_Maximize.Size = new System.Drawing.Size(51, 33);
            this.btn_Maximize.TabIndex = 11;
            this.btn_Maximize.UseVisualStyleBackColor = false;
            this.btn_Maximize.Click += new System.EventHandler(this.btn_Maximize_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(74)))), ((int)(((byte)(130)))));
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btn_Close.IconColor = System.Drawing.Color.White;
            this.btn_Close.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Close.IconSize = 20;
            this.btn_Close.Location = new System.Drawing.Point(1130, 0);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(0, 4, 3, 4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(51, 33);
            this.btn_Close.TabIndex = 10;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pnl_Content
            // 
            this.pnl_Content.Controls.Add(this.tb_List);
            this.pnl_Content.Controls.Add(this.pnl_Filter);
            this.pnl_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Content.Location = new System.Drawing.Point(263, 97);
            this.pnl_Content.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_Content.Name = "pnl_Content";
            this.pnl_Content.Size = new System.Drawing.Size(1182, 784);
            this.pnl_Content.TabIndex = 2;
            // 
            // tb_List
            // 
            this.tb_List.ColumnCount = 3;
            this.tb_List.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tb_List.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 98F));
            this.tb_List.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tb_List.Controls.Add(this.lv_List, 1, 1);
            this.tb_List.Controls.Add(this.lbl_ListTitle, 1, 0);
            this.tb_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_List.Location = new System.Drawing.Point(0, 161);
            this.tb_List.Name = "tb_List";
            this.tb_List.RowCount = 3;
            this.tb_List.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tb_List.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91F));
            this.tb_List.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tb_List.Size = new System.Drawing.Size(1182, 623);
            this.tb_List.TabIndex = 3;
            // 
            // lv_List
            // 
            this.lv_List.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.lv_List.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_List.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lv_List.FullRowSelect = true;
            this.lv_List.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_List.HideSelection = false;
            this.lv_List.Location = new System.Drawing.Point(14, 53);
            this.lv_List.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lv_List.MultiSelect = false;
            this.lv_List.Name = "lv_List";
            this.lv_List.Size = new System.Drawing.Size(1152, 558);
            this.lv_List.TabIndex = 2;
            this.lv_List.UseCompatibleStateImageBehavior = false;
            this.lv_List.View = System.Windows.Forms.View.Details;
            this.lv_List.ItemActivate += new System.EventHandler(this.lv_List_ItemActivate);
            // 
            // lbl_ListTitle
            // 
            this.lbl_ListTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(130)))), ((int)(((byte)(219)))));
            this.lbl_ListTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ListTitle.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_ListTitle.ForeColor = System.Drawing.Color.White;
            this.lbl_ListTitle.Location = new System.Drawing.Point(14, 0);
            this.lbl_ListTitle.Name = "lbl_ListTitle";
            this.lbl_ListTitle.Size = new System.Drawing.Size(1152, 49);
            this.lbl_ListTitle.TabIndex = 1;
            this.lbl_ListTitle.Text = "Title";
            this.lbl_ListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_Filter
            // 
            this.pnl_Filter.BackColor = System.Drawing.Color.Transparent;
            this.pnl_Filter.Controls.Add(this.tb_Filter);
            this.pnl_Filter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Filter.Location = new System.Drawing.Point(0, 0);
            this.pnl_Filter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_Filter.Name = "pnl_Filter";
            this.pnl_Filter.Size = new System.Drawing.Size(1182, 161);
            this.pnl_Filter.TabIndex = 0;
            // 
            // tb_Filter
            // 
            this.tb_Filter.ColumnCount = 4;
            this.tb_Filter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tb_Filter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tb_Filter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tb_Filter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tb_Filter.Controls.Add(this.label1, 0, 0);
            this.tb_Filter.Controls.Add(this.lbl_Filter, 1, 1);
            this.tb_Filter.Controls.Add(this.txt_Filter, 1, 2);
            this.tb_Filter.Controls.Add(this.btn_Register, 2, 1);
            this.tb_Filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Filter.Location = new System.Drawing.Point(0, 0);
            this.tb_Filter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_Filter.Name = "tb_Filter";
            this.tb_Filter.RowCount = 4;
            this.tb_Filter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tb_Filter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tb_Filter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tb_Filter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tb_Filter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tb_Filter.Size = new System.Drawing.Size(1182, 161);
            this.tb_Filter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 4);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // lbl_Filter
            // 
            this.lbl_Filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Filter.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Filter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(88)))), ((int)(((byte)(145)))));
            this.lbl_Filter.Location = new System.Drawing.Point(62, 4);
            this.lbl_Filter.Name = "lbl_Filter";
            this.lbl_Filter.Size = new System.Drawing.Size(703, 75);
            this.lbl_Filter.TabIndex = 1;
            this.lbl_Filter.Text = "Filtro";
            this.lbl_Filter.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txt_Filter
            // 
            this.txt_Filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Filter.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Filter.Location = new System.Drawing.Point(62, 83);
            this.txt_Filter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Filter.Name = "txt_Filter";
            this.txt_Filter.Size = new System.Drawing.Size(703, 37);
            this.txt_Filter.TabIndex = 8;
            this.txt_Filter.TextChanged += new System.EventHandler(this.txt_Filter_TextChanged);
            // 
            // btn_Register
            // 
            this.btn_Register.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(130)))), ((int)(((byte)(219)))));
            this.btn_Register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Register.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Register.ForeColor = System.Drawing.Color.White;
            this.btn_Register.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btn_Register.IconColor = System.Drawing.Color.White;
            this.btn_Register.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Register.IconSize = 26;
            this.btn_Register.Location = new System.Drawing.Point(959, 7);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(160, 47);
            this.btn_Register.TabIndex = 9;
            this.btn_Register.Text = "Cadastrar";
            this.btn_Register.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Register.UseVisualStyleBackColor = false;
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // ListPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1445, 881);
            this.Controls.Add(this.pnl_Content);
            this.Controls.Add(this.pnl_TitleBar);
            this.Controls.Add(this.pnl_Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ListPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Resize += new System.EventHandler(this.Home_Resize);
            this.pnl_Menu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img_LogoMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_TitleBar.ResumeLayout(false);
            this.pnl_TitleBar.PerformLayout();
            this.pnl_Content.ResumeLayout(false);
            this.tb_List.ResumeLayout(false);
            this.pnl_Filter.ResumeLayout(false);
            this.tb_Filter.ResumeLayout(false);
            this.tb_Filter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Menu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnl_TitleBar;
        private System.Windows.Forms.Panel pnl_Content;
        private FontAwesome.Sharp.IconButton btn_MenuLogout;
        private FontAwesome.Sharp.IconButton btn_MenuOptions;
        private FontAwesome.Sharp.IconButton btn_MenuPacientes;
        private FontAwesome.Sharp.IconButton btn_MenuChat;
        private FontAwesome.Sharp.IconButton btn_MenuCalendar;
        private FontAwesome.Sharp.IconButton btn_MenuHome;
        private FontAwesome.Sharp.IconButton btn_MenuHamburger;
        private FontAwesome.Sharp.IconButton btn_Minimize;
        private FontAwesome.Sharp.IconButton btn_Maximize;
        private FontAwesome.Sharp.IconButton btn_Close;
        private System.Windows.Forms.Label lbl_Date;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.PictureBox img_LogoMenu;
        private System.Windows.Forms.Panel pnl_Filter;
        private System.Windows.Forms.TableLayoutPanel tb_Filter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Filter;
        private System.Windows.Forms.TextBox txt_Filter;
        private FontAwesome.Sharp.IconButton btn_Register;
        private System.Windows.Forms.ListView lv_List;
        private System.Windows.Forms.Label lbl_ListTitle;
        private System.Windows.Forms.TableLayoutPanel tb_List;
    }
}