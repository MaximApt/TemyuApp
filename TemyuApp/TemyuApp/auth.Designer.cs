
namespace TemyuApp
{
    partial class auth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(auth));
            this.log_panel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.guest_b = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pass_tb = new System.Windows.Forms.TextBox();
            this.login_tb = new System.Windows.Forms.TextBox();
            this.log_b = new System.Windows.Forms.Button();
            this.log_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // log_panel
            // 
            this.log_panel.Controls.Add(this.button1);
            this.log_panel.Controls.Add(this.guest_b);
            this.log_panel.Controls.Add(this.label2);
            this.log_panel.Controls.Add(this.label1);
            this.log_panel.Controls.Add(this.pictureBox2);
            this.log_panel.Controls.Add(this.pictureBox1);
            this.log_panel.Controls.Add(this.pass_tb);
            this.log_panel.Controls.Add(this.login_tb);
            this.log_panel.Controls.Add(this.log_b);
            this.log_panel.Location = new System.Drawing.Point(34, 12);
            this.log_panel.Name = "log_panel";
            this.log_panel.Size = new System.Drawing.Size(277, 268);
            this.log_panel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(53, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Проверка соединения";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // guest_b
            // 
            this.guest_b.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guest_b.BackgroundImage")));
            this.guest_b.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guest_b.FlatAppearance.BorderSize = 0;
            this.guest_b.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.guest_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guest_b.Location = new System.Drawing.Point(53, 176);
            this.guest_b.Name = "guest_b";
            this.guest_b.Size = new System.Drawing.Size(171, 25);
            this.guest_b.TabIndex = 6;
            this.guest_b.TabStop = false;
            this.guest_b.Text = "Гостевой режим";
            this.guest_b.UseVisualStyleBackColor = true;
            this.guest_b.Click += new System.EventHandler(this.guest_b_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(53, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(53, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox2.Image = global::TemyuApp.Properties.Resources.pass_icon;
            this.pictureBox2.Location = new System.Drawing.Point(17, 88);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Image = global::TemyuApp.Properties.Resources.log_icon;
            this.pictureBox1.Location = new System.Drawing.Point(17, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pass_tb
            // 
            this.pass_tb.Location = new System.Drawing.Point(53, 98);
            this.pass_tb.Name = "pass_tb";
            this.pass_tb.PasswordChar = '*';
            this.pass_tb.Size = new System.Drawing.Size(204, 20);
            this.pass_tb.TabIndex = 2;
            // 
            // login_tb
            // 
            this.login_tb.Location = new System.Drawing.Point(53, 48);
            this.login_tb.Name = "login_tb";
            this.login_tb.Size = new System.Drawing.Size(204, 20);
            this.login_tb.TabIndex = 1;
            // 
            // log_b
            // 
            this.log_b.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("log_b.BackgroundImage")));
            this.log_b.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.log_b.FlatAppearance.BorderSize = 0;
            this.log_b.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.log_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log_b.Location = new System.Drawing.Point(53, 145);
            this.log_b.Name = "log_b";
            this.log_b.Size = new System.Drawing.Size(171, 25);
            this.log_b.TabIndex = 0;
            this.log_b.TabStop = false;
            this.log_b.Text = "Вход";
            this.log_b.UseVisualStyleBackColor = true;
            this.log_b.Click += new System.EventHandler(this.log_b_Click);
            // 
            // auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TemyuApp.Properties.Resources.auth_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(345, 293);
            this.Controls.Add(this.log_panel);
            this.Name = "auth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход в базу данных";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.auth_FormClosed);
            this.Load += new System.EventHandler(this.auth_Load);
            this.log_panel.ResumeLayout(false);
            this.log_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel log_panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox pass_tb;
        private System.Windows.Forms.TextBox login_tb;
        private System.Windows.Forms.Button guest_b;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button log_b;
    }
}