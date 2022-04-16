
namespace TGS.Views.Components {
    partial class MyMsgBox {
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
            this.components = new System.ComponentModel.Container();
            this.pnl_MsgBox = new System.Windows.Forms.Panel();
            this.tb_MsgBox = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_MsgBoxMessage = new System.Windows.Forms.Label();
            this.tb_MsgBoxButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Yes = new FontAwesome.Sharp.IconButton();
            this.btn_No = new FontAwesome.Sharp.IconButton();
            this.lbl_MsgBoxTitle = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnl_MsgBox.SuspendLayout();
            this.tb_MsgBox.SuspendLayout();
            this.tb_MsgBoxButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_MsgBox
            // 
            this.pnl_MsgBox.BackColor = System.Drawing.Color.Transparent;
            this.pnl_MsgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_MsgBox.Controls.Add(this.tb_MsgBox);
            this.pnl_MsgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_MsgBox.Location = new System.Drawing.Point(0, 0);
            this.pnl_MsgBox.Name = "pnl_MsgBox";
            this.pnl_MsgBox.Size = new System.Drawing.Size(286, 181);
            this.pnl_MsgBox.TabIndex = 17;
            // 
            // tb_MsgBox
            // 
            this.tb_MsgBox.ColumnCount = 3;
            this.tb_MsgBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tb_MsgBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tb_MsgBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tb_MsgBox.Controls.Add(this.lbl_MsgBoxMessage, 1, 1);
            this.tb_MsgBox.Controls.Add(this.tb_MsgBoxButtons, 1, 2);
            this.tb_MsgBox.Controls.Add(this.lbl_MsgBoxTitle, 0, 0);
            this.tb_MsgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_MsgBox.Location = new System.Drawing.Point(0, 0);
            this.tb_MsgBox.Name = "tb_MsgBox";
            this.tb_MsgBox.RowCount = 4;
            this.tb_MsgBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tb_MsgBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tb_MsgBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tb_MsgBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tb_MsgBox.Size = new System.Drawing.Size(284, 179);
            this.tb_MsgBox.TabIndex = 0;
            // 
            // lbl_MsgBoxMessage
            // 
            this.lbl_MsgBoxMessage.AutoSize = true;
            this.lbl_MsgBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_MsgBoxMessage.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_MsgBoxMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(88)))), ((int)(((byte)(145)))));
            this.lbl_MsgBoxMessage.Location = new System.Drawing.Point(31, 17);
            this.lbl_MsgBoxMessage.Name = "lbl_MsgBoxMessage";
            this.lbl_MsgBoxMessage.Size = new System.Drawing.Size(221, 107);
            this.lbl_MsgBoxMessage.TabIndex = 0;
            this.lbl_MsgBoxMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_MsgBoxButtons
            // 
            this.tb_MsgBoxButtons.ColumnCount = 3;
            this.tb_MsgBoxButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tb_MsgBoxButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tb_MsgBoxButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tb_MsgBoxButtons.Controls.Add(this.btn_Yes, 0, 0);
            this.tb_MsgBoxButtons.Controls.Add(this.btn_No, 2, 0);
            this.tb_MsgBoxButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_MsgBoxButtons.Location = new System.Drawing.Point(31, 127);
            this.tb_MsgBoxButtons.Name = "tb_MsgBoxButtons";
            this.tb_MsgBoxButtons.RowCount = 1;
            this.tb_MsgBoxButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb_MsgBoxButtons.Size = new System.Drawing.Size(221, 38);
            this.tb_MsgBoxButtons.TabIndex = 1;
            // 
            // btn_Yes
            // 
            this.btn_Yes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(130)))), ((int)(((byte)(219)))));
            this.btn_Yes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Yes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Yes.FlatAppearance.BorderSize = 0;
            this.btn_Yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Yes.IconChar = FontAwesome.Sharp.IconChar.ThumbsUp;
            this.btn_Yes.IconColor = System.Drawing.Color.Lime;
            this.btn_Yes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Yes.IconSize = 34;
            this.btn_Yes.Location = new System.Drawing.Point(0, 0);
            this.btn_Yes.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.Size = new System.Drawing.Size(99, 38);
            this.btn_Yes.TabIndex = 0;
            this.btn_Yes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Yes.UseVisualStyleBackColor = false;
            this.btn_Yes.Click += new System.EventHandler(this.btn_Yes_Click);
            // 
            // btn_No
            // 
            this.btn_No.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(130)))), ((int)(((byte)(219)))));
            this.btn_No.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_No.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_No.FlatAppearance.BorderSize = 0;
            this.btn_No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_No.IconChar = FontAwesome.Sharp.IconChar.ThumbsDown;
            this.btn_No.IconColor = System.Drawing.Color.Red;
            this.btn_No.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_No.IconSize = 34;
            this.btn_No.Location = new System.Drawing.Point(121, 0);
            this.btn_No.Margin = new System.Windows.Forms.Padding(0);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(100, 38);
            this.btn_No.TabIndex = 1;
            this.btn_No.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_No.UseVisualStyleBackColor = false;
            this.btn_No.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // lbl_MsgBoxTitle
            // 
            this.tb_MsgBox.SetColumnSpan(this.lbl_MsgBoxTitle, 3);
            this.lbl_MsgBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_MsgBoxTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_MsgBoxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(88)))), ((int)(((byte)(145)))));
            this.lbl_MsgBoxTitle.Location = new System.Drawing.Point(3, 0);
            this.lbl_MsgBoxTitle.Name = "lbl_MsgBoxTitle";
            this.lbl_MsgBoxTitle.Size = new System.Drawing.Size(278, 17);
            this.lbl_MsgBoxTitle.TabIndex = 2;
            // 
            // timer
            // 
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MyMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(286, 181);
            this.Controls.Add(this.pnl_MsgBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyMsgBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MyMsgBox";
            this.pnl_MsgBox.ResumeLayout(false);
            this.tb_MsgBox.ResumeLayout(false);
            this.tb_MsgBox.PerformLayout();
            this.tb_MsgBoxButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_MsgBox;
        private System.Windows.Forms.TableLayoutPanel tb_MsgBox;
        private System.Windows.Forms.Label lbl_MsgBoxMessage;
        private System.Windows.Forms.TableLayoutPanel tb_MsgBoxButtons;
        private FontAwesome.Sharp.IconButton btn_Yes;
        private FontAwesome.Sharp.IconButton btn_No;
        private System.Windows.Forms.Label lbl_MsgBoxTitle;
        private System.Windows.Forms.Timer timer;
    }
}