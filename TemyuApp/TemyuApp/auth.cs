using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TemyuApp
{
    public partial class auth : Form
    {
        public auth()
        {
            InitializeComponent();
        }

        // Выход из приложения
        private void auth_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void auth_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(30, 57, 52, 49);
            pictureBox2.BackColor = Color.FromArgb(30, 57, 52, 49);

            log_panel.BackColor = Color.FromArgb(220, 57, 52, 49);
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);
            label2.BackColor = Color.FromArgb(0, 0, 0, 0);
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0, 0);
            pictureBox2.BackColor = Color.FromArgb(0, 0, 0, 0);

            this.MinimumSize = new Size(361, 332);
            this.MaximumSize = new Size(361, 332);
        }

        // Вход
        private void log_b_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                data_base db = new data_base();

                string querystring = $"select user_login, user_password from users where user_login='{login_tb.Text}' and user_password='{pass_tb.Text}' ";
                SqlCommand command = new SqlCommand(querystring, db.GetConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    main main_form = new main();
                    main_form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка входа");
                }
            }
            catch { MessageBox.Show("Отсутствует соединение с сервером или базой данных", "Ошибка"); }
        }

        private void guest_b_Click(object sender, EventArgs e)
        {
            try
            {
                main main_form = new main();
                main_form.Show();

                main_form.Clients_b.Enabled = false;        main_form.Orders_b.Enabled = false;
                main_form.TZ_b.Enabled = false;             main_form.Projects_b.Enabled = false;
                main_form.Projectempl_b.Enabled = false;    main_form.Test_rep_b.Enabled = false;
                main_form.Employees_b.Enabled = false;      main_form.Positions_b.Enabled = false;
                main_form.users_b.Enabled = false;          main_form.Calendar_b.Enabled = false;

                main_form.Clients_b.BackgroundImage = Image.FromFile("img/button3.png");
                main_form.Orders_b.BackgroundImage = Image.FromFile("img/button3.png");
                main_form.TZ_b.BackgroundImage = Image.FromFile("img/button3.png");
                main_form.Projects_b.BackgroundImage = Image.FromFile("img/button3.png");
                main_form.Projectempl_b.BackgroundImage = Image.FromFile("img/button3.png");
                main_form.Test_rep_b.BackgroundImage = Image.FromFile("img/button3.png");
                main_form.Employees_b.BackgroundImage = Image.FromFile("img/button3.png");
                main_form.Positions_b.BackgroundImage = Image.FromFile("img/button3.png");
                main_form.users_b.BackgroundImage = Image.FromFile("img/button3.png");
                main_form.Calendar_b.BackgroundImage = Image.FromFile("img/button3.png");

                this.Hide();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                data_base db = new data_base();

                db.openConnection();
                db.checkConnection();

                MessageBox.Show(db.check_c);
            }
            catch { MessageBox.Show("Отсутствует соединение с сервером или базой данных", "Ошибка"); }
        }
    }
}
