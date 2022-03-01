using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Data;

namespace TemyuApp
{
    enum RowState
    {
        Existed,
        New,
        Modifief,
        ModifiedNew,
        Deleted
    }
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        int selectedRow;

        // Вызов записей из БД
        // Клиенты
        public void clients_columns()
        {
            clients.Columns.Add("id", "id");
            clients.Columns.Add("family_name", "Фамилия");
            clients.Columns.Add("name_", "Имя");
            clients.Columns.Add("patronymic", "Отчество");
            clients.Columns.Add("organization", "Организация");
            clients.Columns.Add("phone", "Телефон");
            clients.Columns.Add("email", "Эл.почта");
            clients.Columns.Add("new", String.Empty);
        }
        public void ReadSingleRow1(DataGridView dwg1, IDataRecord record)
        {
            dwg1.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), RowState.ModifiedNew);
        }
        public void clients_refreshData(DataGridView dwg1)
        {
            dwg1.Rows.Clear(); data_base db = new data_base();
            string querystring1 = $"select * from clients";
            SqlCommand command1 = new SqlCommand(querystring1, db.GetConnection()); db.openConnection();
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                ReadSingleRow1(clients, reader1);
            }
            reader1.Close();
        }

        // Заказы
        public void orders_columns()
        {
            orders.Columns.Add("id", "id");
            orders.Columns.Add("client", "Клиент");
            orders.Columns.Add("status", "Статус");
            orders.Columns.Add("date_of_accept", "Дата принятия");
            orders.Columns.Add("closing_date", "Дата закрытия");
            orders.Columns.Add("deadline", "Срок выполнения");
            orders.Columns.Add("new", String.Empty);
        }
        public void ReadSingleRow2(DataGridView dwg2, IDataRecord record2)
        {
            dwg2.Rows.Add(record2.GetInt32(0), record2.GetString(1), record2.GetString(2), record2.GetDateTime(3), record2.GetDateTime(4), record2.GetDateTime(5), RowState.ModifiedNew);
        }
        public void orders_refreshData(DataGridView dwg2)
        {
            dwg2.Rows.Clear(); data_base db = new data_base();
            string querystring2 = $"select * from orders";
            SqlCommand command2 = new SqlCommand(querystring2, db.GetConnection()); db.openConnection();
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                ReadSingleRow2(orders, reader2);
            }
            reader2.Close();
        }

        // Технические задания
        public void tz_columns()
        {
            tz.Columns.Add("id", "id");
            tz.Columns.Add("order_id", "id заказа");
            tz.Columns.Add("content", "Содержание");
            tz.Columns.Add("new", String.Empty);
        }
        public void ReadSingleRow3(DataGridView dwg3, IDataRecord record3)
        {
            dwg3.Rows.Add(record3.GetInt32(0), record3.GetInt32(1), record3.GetString(2), RowState.ModifiedNew);
        }
        public void tz_refreshData(DataGridView dwg3)
        {
            dwg3.Rows.Clear(); data_base db = new data_base();
            string querystring3 = $"select * from tz";
            SqlCommand command3 = new SqlCommand(querystring3, db.GetConnection()); db.openConnection();
            SqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                ReadSingleRow3(tz, reader3);
            }
            reader3.Close();
        }

        // Проекты
        public void projects_columns()
        {
            projects.Columns.Add("id", "id");
            projects.Columns.Add("project_name", "Наименование");
            projects.Columns.Add("tz_id", "id тз");
            projects.Columns.Add("project_status", "Статус проекта");
            projects.Columns.Add("current_version", "Текущая версия");
            projects.Columns.Add("new", String.Empty);
        }
        public void ReadSingleRow4(DataGridView dwg4, IDataRecord record4)
        {
            dwg4.Rows.Add(record4.GetInt32(0), record4.GetString(1), record4.GetInt32(2), record4.GetString(3), record4.GetString(4), RowState.ModifiedNew);
        }
        public void projects_refreshData(DataGridView dwg4)
        {
            dwg4.Rows.Clear(); data_base db = new data_base();
            string querystring4 = $"select * from projects";
            SqlCommand command4 = new SqlCommand(querystring4, db.GetConnection()); db.openConnection();
            SqlDataReader reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {
                ReadSingleRow4(projects, reader4);
            }
            reader4.Close();
        }

        // Работа над проектами
        public void work_columns()
        {
            work.Columns.Add("id", "id");
            work.Columns.Add("employee", "Сотрудник");
            work.Columns.Add("project_name", "Наименование проекта");
            work.Columns.Add("role_", "Роль в проекта");
            work.Columns.Add("new", String.Empty);
        }
        public void ReadSingleRow5(DataGridView dwg5, IDataRecord record5)
        {
            dwg5.Rows.Add(record5.GetInt32(0), record5.GetString(1), record5.GetString(2), record5.GetString(3), RowState.ModifiedNew);
        }
        public void work_refreshData(DataGridView dwg5)
        {
            dwg5.Rows.Clear(); data_base db = new data_base();
            string querystring5 = $"select * from project_work";
            SqlCommand command5 = new SqlCommand(querystring5, db.GetConnection()); db.openConnection();
            SqlDataReader reader5 = command5.ExecuteReader();
            while (reader5.Read())
            {
                ReadSingleRow5(work, reader5);
            }
            reader5.Close();
        }

        // Календарные планы
        public void calendar_columns()
        {
            calendar.Columns.Add("id", "id");
            calendar.Columns.Add("project_name", "Наименование проекта");
            calendar.Columns.Add("work_name", "Наименование работ");
            calendar.Columns.Add("plan_start", "Плановая дата начала");
            calendar.Columns.Add("fact_start", "Фактическая дата начала");
            calendar.Columns.Add("plan_end", "Плановая дата завершения");
            calendar.Columns.Add("fact_end", "Фактическая дата завершения");
            calendar.Columns.Add("new", String.Empty);
        }
        public void ReadSingleRow6(DataGridView dwg6, IDataRecord record6)
        {
            dwg6.Rows.Add(record6.GetInt32(0), record6.GetString(1), record6.GetString(2), record6.GetDateTime(3), record6.GetDateTime(4), record6.GetDateTime(5), record6.GetDateTime(6), RowState.ModifiedNew);
        }
        public void calendar_refreshData(DataGridView dwg1)
        {
            dwg1.Rows.Clear(); data_base db = new data_base();
            string querystring6 = $"select * from calendar_plan";
            SqlCommand command6 = new SqlCommand(querystring6, db.GetConnection()); db.openConnection();
            SqlDataReader reader6 = command6.ExecuteReader();
            while (reader6.Read())
            {
                ReadSingleRow6(calendar, reader6);
            }
            reader6.Close();
        }

        // Отчёты о тестировании
        public void test_columns()
        {
            test_rep.Columns.Add("id", "id");
            test_rep.Columns.Add("project_name", "Наименование проекта");
            test_rep.Columns.Add("employee", "Сотрудник");
            test_rep.Columns.Add("content", "Содержание");
            test_rep.Columns.Add("date_", "Дата написания");
            test_rep.Columns.Add("new", String.Empty);
        }
        public void ReadSingleRow7(DataGridView dwg7, IDataRecord record7)
        {
            dwg7.Rows.Add(record7.GetInt32(0), record7.GetString(1), record7.GetString(2), record7.GetString(3), record7.GetDateTime(4), RowState.ModifiedNew);
        }
        public void test_refreshData(DataGridView dwg7)
        {
            dwg7.Rows.Clear(); data_base db = new data_base();
            string querystring7 = $"select * from test_reports";
            SqlCommand command7 = new SqlCommand(querystring7, db.GetConnection()); db.openConnection();
            SqlDataReader reader7 = command7.ExecuteReader();
            while (reader7.Read())
            {
                ReadSingleRow7(test_rep, reader7);
            }
            reader7.Close();
        }

        // Сотрудники
        public void employee_columns()
        {
            employees.Columns.Add("id", "id");
            employees.Columns.Add("family_name", "Фамилия");
            employees.Columns.Add("name", "Имя");
            employees.Columns.Add("patronymic", "Отчество");
            employees.Columns.Add("position_name", "Должность");
            employees.Columns.Add("specialization", "Специализация");
            employees.Columns.Add("new", String.Empty);
        }
        public void ReadSingleRow8(DataGridView dwg8, IDataRecord record8)
        {
            dwg8.Rows.Add(record8.GetInt32(0), record8.GetString(1), record8.GetString(2), record8.GetString(3), record8.GetString(4), record8.GetString(5), RowState.ModifiedNew);
        }
        public void employee_refreshData(DataGridView dwg8)
        {
            dwg8.Rows.Clear(); data_base db = new data_base();
            string querystring8 = $"select * from employees";
            SqlCommand command8 = new SqlCommand(querystring8, db.GetConnection()); db.openConnection();
            SqlDataReader reader8 = command8.ExecuteReader();
            while (reader8.Read())
            {
                ReadSingleRow8(employees, reader8);
            }
            reader8.Close();
        }

        // Должности
        public void positions_columns()
        {
            positions.Columns.Add("id", "id");
            positions.Columns.Add("position_name", "Наименование должности");
            positions.Columns.Add("new", String.Empty);
        }
        public void ReadSingleRow9(DataGridView dwg9, IDataRecord record9)
        {
            dwg9.Rows.Add(record9.GetInt32(0), record9.GetString(1), RowState.ModifiedNew);
        }
        public void positions_refreshData(DataGridView dwg9)
        {
            dwg9.Rows.Clear(); data_base db = new data_base();
            string querystring9 = $"select * from positions";
            SqlCommand command9 = new SqlCommand(querystring9, db.GetConnection()); db.openConnection();
            SqlDataReader reader9 = command9.ExecuteReader();
            while (reader9.Read())
            {
                ReadSingleRow9(positions, reader9);
            }
            reader9.Close();
        }

        // Пользователи
        public void users_columns()
        {
            users.Columns.Add("id", "id");
            users.Columns.Add("family_name", "Фамилия");
            users.Columns.Add("name", "Имя");
            users.Columns.Add("patronymic", "Отчество");
            users.Columns.Add("user_login", "Логин");
            users.Columns.Add("user_password", "Пароль");
            users.Columns.Add("user_role", "Роль в системе");
            users.Columns.Add("new", String.Empty);
        }
        public void ReadSingleRow10(DataGridView dwg10, IDataRecord record10)
        {
            dwg10.Rows.Add(record10.GetInt32(0), record10.GetString(1), record10.GetString(2), record10.GetString(3), record10.GetString(4), record10.GetString(5), record10.GetString(6), RowState.ModifiedNew);
        }
        public void users_refreshData(DataGridView dwg10)
        {
            dwg10.Rows.Clear(); data_base db = new data_base();
            string querystring10 = $"select * from users";
            SqlCommand command10 = new SqlCommand(querystring10, db.GetConnection()); db.openConnection();
            SqlDataReader reader10 = command10.ExecuteReader();
            while (reader10.Read())
            {
                ReadSingleRow10(users, reader10);
            }
            reader10.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Определение размеров элементов datagridview
            employees.Size = new Size(930, 490);    clients.Size = new Size(930, 490);
            orders.Size = new Size(930, 490);       tz.Size = new Size(930, 490);
            projects.Size = new Size(930, 490);     work.Size = new Size(930, 490);
            test_rep.Size = new Size(930, 490);     positions.Size = new Size(930, 490);
            users.Size = new Size(930, 490);        calendar.Size = new Size(930, 490);

            // Определение расположения элементов datagridview
            employees.Location = new Point(198, 89); clients.Location = new Point(198, 89);
            orders.Location = new Point(198, 89);    tz.Location = new Point(198, 89);
            projects.Location = new Point(198, 89);  work.Location = new Point(198, 89);
            test_rep.Location = new Point(198, 89);  positions.Location = new Point(198, 89);
            users.Location = new Point(198, 89);     calendar.Location = new Point(198, 89);

            Startpicture.Size = new Size(920, 515);
            Startpicture.Location = new Point(205, 64);
            Startpicture.BackColor = Color.FromArgb(100, 69, 65, 41);

            // Фоновый цвет элементов
            panel1.BackColor = Color.FromArgb(100, 69, 65, 41);         Settingsbutton.BackColor = Color.FromArgb(50, 57, 52, 49);
            Closetable.BackColor = Color.FromArgb(50, 57, 52, 49);      Add_b.BackColor = Color.FromArgb(50, 57, 52, 49);
            Correct_b.BackColor = Color.FromArgb(50, 57, 52, 49);       Delete_b.BackColor = Color.FromArgb(50, 57, 52, 49);
            user_panel.BackColor = Color.FromArgb(100, 69, 65, 41);     label1.BackColor = Color.FromArgb(0, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 69, 65, 41);         edit_panel.BackColor = Color.FromArgb(100, 69, 65, 41);
            panel3.BackColor = Color.FromArgb(100, 69, 65, 41);         pictureBox1.BackColor = Color.FromArgb(0, 0, 0, 0);
            label17.BackColor = Color.FromArgb(0, 0, 0, 0);             Settings_panel.BackColor = Color.FromArgb(255, 105, 105, 105);
            label19.BackColor = Color.FromArgb(0, 0, 0, 0);             Add_panel.BackColor = Color.FromArgb(255, 105, 105, 105);
            Add_panel.MinimumSize = new Size(470, 270);                 

            this.WindowState = FormWindowState.Maximized;

            Add_b.FlatAppearance.BorderSize = 0;        Correct_b.FlatAppearance.BorderSize = 0;
            Delete_b.FlatAppearance.BorderSize = 0;     Add_b.FlatStyle = FlatStyle.Flat;
            Correct_b.FlatStyle = FlatStyle.Flat;       Delete_b.FlatStyle = FlatStyle.Flat;
            Closetable.FlatAppearance.BorderSize = 0;   Settingsbutton.FlatAppearance.BorderSize = 0;
            Closetable.FlatStyle = FlatStyle.Flat;      Settingsbutton.FlatStyle = FlatStyle.Flat;
            this.MinimumSize = new Size(1030,635);      Add_panel.Size = new Size(800, 270);

            //Добавление записей в ComboBox'ы
            orders_status_cb.Items.AddRange(new string[] { "В рассмотрении", "Принят", "В процессе реализации", "Выполнен" });
            projects_status_cb.Items.AddRange(new string[] { "Проектирование", "Реализация", "Тестирование", "Внедрение", "Сопровождение", "Закрыт", "Заморожен" });
            work_role_cb.Items.AddRange(new string[] { "Руководитель проекта", "Back-end разработчик", "Front-end разработчик", "Дизайнер", "Тестировщик", "Системный администратор" });
            calendar_works_cb.Items.AddRange(new string[] { "Подготовка", "Проектирование", "Дизайн", "Кодирование", "Тестирование", "Документирование", "Внедрение", "Сопровождение" });
            user_role_cb.Items.AddRange(new string[] { "Администратор", "Руководитель проекта" , "Разработчик", "Тестировщик" });
        }

        // Вызов панели с настройками приложения
        private void Settingsbutton_Click(object sender, EventArgs e)
        {
            if (Settings_panel.Visible == false)
            {
                Settings_panel.Visible = true;
            }
            else
            {
                Settings_panel.Visible = false;
            }
        }

        // Событие для скрытия таблиц и отображения элементов добавления, изменения, поиска и удаления записей.
        public void tableevent(object sender, EventArgs e)
        {
            employees.Hide(); clients.Hide(); test_rep.Hide(); users.Hide(); orders.Hide(); work.Hide(); projects.Hide(); positions.Hide(); tz.Hide(); calendar.Hide();

            Startpicture.Hide(); textBox1.Show(); Searchbutton.Show(); label17.Show(); edit_panel.Show(); panel3.Show(); label19.Show();
        }

        // Кнопки для открытия таблиц

        // Сотрудники
        private void Employees_Click(object sender, EventArgs e)
        {
            tableevent(sender, e);
            employees.Show();
            employees.Columns.Clear(); employee_columns(); employee_refreshData(employees);
        }
        // Клиенты
        private void Clients_b_Click(object sender, EventArgs e)
        {
            tableevent(sender, e);
            clients.Show();
            clients.Columns.Clear(); clients_columns(); clients_refreshData(clients);
        }
        // Заказы
        private void Orders_b_Click(object sender, EventArgs e)
        {
            tableevent(sender, e);
            orders.Show();
            orders.Columns.Clear(); orders_columns(); orders_refreshData(orders);
        }
        // Технические задания
        private void TZ_b_Click(object sender, EventArgs e)
        {
            tableevent(sender, e);
            tz.Show();
            tz.Columns.Clear(); tz_columns(); tz_refreshData(tz);
        }
        // Проекты
        private void Projects_b_Click(object sender, EventArgs e)
        {
            tableevent(sender, e);
            projects.Show();
            projects.Columns.Clear(); projects_columns(); projects_refreshData(projects);
        }
        // Работа над проектами
        private void Projectempl_b_Click(object sender, EventArgs e)
        {
            tableevent(sender, e);
            work.Show();
            work.Columns.Clear(); work_columns(); work_refreshData(work);
        }
        // Должности
        private void Positions_b_Click(object sender, EventArgs e)
        {
            tableevent(sender, e);
            positions.Show();
            positions.Columns.Clear(); positions_columns(); positions_refreshData(positions);
        }
        // Пользователи
        private void users_b_Click(object sender, EventArgs e)
        {
            tableevent(sender, e);
            users.Show();
            users.Columns.Clear(); users_columns(); users_refreshData(users);
        }
        // Отчёты о тестировании
        private void Test_rep_b_Click(object sender, EventArgs e)
        {
            tableevent(sender, e);
            test_rep.Show();
            test_rep.Columns.Clear(); test_columns(); test_refreshData(test_rep);
        }
        // Календарный план
        private void Calendar_b_Click(object sender, EventArgs e)
        {
            tableevent(sender, e);
            calendar.Show();
            calendar.Columns.Clear(); calendar_columns(); calendar_refreshData(calendar);
        }

        // Закрытие таблицы
        private void Closetable_Click(object sender, EventArgs e)
        {
            tableevent(sender, e);
            Startpicture.Show();
            textBox1.Hide();
            Searchbutton.Hide();
            edit_panel.Hide();
            label17.Hide();
            panel3.Hide();
            label19.Hide();
            Add_panel.Hide();
        }

        // Обработчик для возврата на стартовую форму входа
        private void to_auth_b_Click(object sender, EventArgs e)
        {
            auth to_auth = new auth();
            this.Hide();
            to_auth.Show();
        }
        // Обработчик для выхода из приложения
        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Открытие и закрытие панели добавления записей
        private void Add_b_Click(object sender, EventArgs e)
        {
            if (Add_panel.Visible != true)
            { Add_panel.Show(); }
            else { Add_panel.Hide(); }
        }

        // XML документы
        XmlDocument clients_xml_doc = new XmlDocument();
        XmlDocument emp_xml_doc = new XmlDocument();
        XmlDocument projects_xml_doc = new XmlDocument();
        XmlDocument positions_xml_doc = new XmlDocument();

        // Добавление записей в базу данных SQL Server

        // Пользователи
        private void add_row_b_Click(object sender, EventArgs e)
        {
            try
            {
                data_base db = new data_base();
                SqlCommand add_user_command = new SqlCommand("insert into [users] (name_, family_name, patronymic, user_login, user_password, user_role) values " +
                    "(@u_name, @u_fname, @u_patr, @u_login, @u_pass, @u_role)", db.GetConnection());
                {
                    add_user_command.Parameters.AddWithValue("@u_name", user_name_tb.Text);
                    add_user_command.Parameters.AddWithValue("@u_fname", user_familyname_tb.Text);
                    add_user_command.Parameters.AddWithValue("@u_patr", user_otchestvo_tb.Text);
                    add_user_command.Parameters.AddWithValue("@u_login", user_login_tb.Text);
                    add_user_command.Parameters.AddWithValue("@u_pass", user_pass_tb.Text);
                    add_user_command.Parameters.AddWithValue("@u_role", user_role_cb.Text);

                    add_user_command.Connection.Open();
                    add_user_command.ExecuteNonQuery();

                    user_name_tb.Clear(); user_familyname_tb.Clear(); user_otchestvo_tb.Clear(); user_login_tb.Clear(); user_pass_tb.Clear(); user_role_cb.Text=""; label66.Show();
                }
                users.Columns.Clear(); users_columns(); users_refreshData(users);
            }
            catch { MessageBox.Show("Отсутствует соединение с сервером или базой данных", "Ошибка"); }
        }

        // Клиенты
        private void add_client_b_Click(object sender, EventArgs e)
        {
            try
            {
                data_base db = new data_base();
                SqlCommand add_client_command = new SqlCommand("insert into [clients] (name_, family_name, patronymic, organization, email, phone) values " +
                    "(@u_name, @u_fname, @u_patr, @org, @mail, @phone)", db.GetConnection());
                {
                    add_client_command.Parameters.AddWithValue("@u_name", client_name_tb.Text);
                    add_client_command.Parameters.AddWithValue("@u_fname", client_familyname_tb.Text);
                    add_client_command.Parameters.AddWithValue("@u_patr", client_otchestvo_tb.Text);
                    add_client_command.Parameters.AddWithValue("@org", client_company_tb.Text);
                    add_client_command.Parameters.AddWithValue("@mail", client_email_tb.Text);
                    add_client_command.Parameters.AddWithValue("@phone", client_phone_tb.Text);

                    add_client_command.Connection.Open();
                    add_client_command.ExecuteNonQuery();
                } label21.Show();
                clients_xml_doc.Load("xml/clients.xml");
                XmlElement xRoot = clients_xml_doc.DocumentElement;
                XmlElement client_element = clients_xml_doc.CreateElement("client");
                XmlAttribute client_atribute = clients_xml_doc.CreateAttribute("name");

                string client_name = client_familyname_tb.Text + " " + client_name_tb.Text + " " + client_otchestvo_tb.Text;
                XmlText name = clients_xml_doc.CreateTextNode(client_name);
                client_atribute.AppendChild(name);
                client_element.Attributes.Append(client_atribute);
                xRoot.AppendChild(client_element);
                clients_xml_doc.Save("xml/clients.xml");
                clients.Columns.Clear(); clients_columns(); clients_refreshData(clients);
            }
            catch { MessageBox.Show("Отсутствует соединение с сервером или базой данных", "Ошибка"); }
            client_name_tb.Clear(); client_familyname_tb.Clear(); client_otchestvo_tb.Clear(); client_company_tb.Clear(); client_email_tb.Clear(); client_phone_tb.Clear();
        }

        // Заказы
        private void add_order_b_Click(object sender, EventArgs e)
        {
            try
            {
                data_base db = new data_base();
                SqlCommand add_order_command = new SqlCommand("insert into [orders] (client, status, date_of_accept, closing_date, deadline) values " +
                    "(@client, @status, @accept, @close, @deadline)", db.GetConnection());
                {
                    add_order_command.Parameters.AddWithValue("@client", orders_client_cb.Text);
                    add_order_command.Parameters.AddWithValue("@status", orders_status_cb.Text);
                    add_order_command.Parameters.AddWithValue("@accept", orders_acceptdate_tb.Text);
                    add_order_command.Parameters.AddWithValue("@close", orders_closingdate_tb.Text);
                    add_order_command.Parameters.AddWithValue("@deadline", orders_deadline_tb.Text);

                    add_order_command.Connection.Open();
                    add_order_command.ExecuteNonQuery();
                } label58.Show();
                orders.Columns.Clear(); orders_columns(); orders_refreshData(orders);
            }
            catch { MessageBox.Show("Отсутствует соединение с сервером или базой данных", "Ошибка"); }
            orders_client_cb.Text = ""; orders_status_cb.Text = ""; orders_acceptdate_tb.Clear(); orders_closingdate_tb.Clear(); orders_deadline_tb.Clear();
        }

        // Технические задания
        private void add_tz_b_Click(object sender, EventArgs e)
        {
            try
            {
                data_base db = new data_base();
                SqlCommand add_tz_command = new SqlCommand("insert into [tz] (order_id, content) values " +
                    "(@order_id, @cont)", db.GetConnection());
                {
                    add_tz_command.Parameters.AddWithValue("@order_id", tz_order_id_tb.Text);
                    add_tz_command.Parameters.AddWithValue("@cont", tz_content_tb.Text);

                    add_tz_command.Connection.Open();
                    add_tz_command.ExecuteNonQuery();
                } label59.Show();
                tz.Columns.Clear(); tz_columns(); tz_refreshData(tz);
            }
            catch { MessageBox.Show("Отсутствует соединение с сервером или базой данных", "Ошибка"); }
            tz_order_id_tb.Clear(); tz_content_tb.Clear();
        }

        // Проекты
        private void add_project_b_Click(object sender, EventArgs e)
        {
            try
            {
                data_base db = new data_base();
                SqlCommand add_project_command = new SqlCommand("insert into [projects] (project_name, tz_id, project_status, current_version) values " +
                    "(@name, @tz_id, @status, @version)", db.GetConnection());
                {
                    add_project_command.Parameters.AddWithValue("@name", projects_name_tb.Text);
                    add_project_command.Parameters.AddWithValue("@tz_id", projects_tz_id_tb.Text);
                    add_project_command.Parameters.AddWithValue("@status", projects_status_cb.Text);
                    add_project_command.Parameters.AddWithValue("@version", projects_version_tb.Text);

                    add_project_command.Connection.Open();
                    add_project_command.ExecuteNonQuery();
                } label60.Show();
                projects_xml_doc.Load("xml/projects.xml");
                XmlElement xRoot = projects_xml_doc.DocumentElement;
                XmlElement projects_element = projects_xml_doc.CreateElement("project");
                XmlAttribute projects_atribute = projects_xml_doc.CreateAttribute("name");

                string projects_name = projects_name_tb.Text;
                XmlText name = projects_xml_doc.CreateTextNode(projects_name);
                projects_atribute.AppendChild(name);
                projects_element.Attributes.Append(projects_atribute);
                xRoot.AppendChild(projects_element);
                projects_xml_doc.Save("xml/projects.xml");
                projects.Columns.Clear(); projects_columns(); projects_refreshData(projects);
            }
            catch { MessageBox.Show("Отсутствует соединение с сервером или базой данных", "Ошибка"); }
            projects_name_tb.Clear(); projects_tz_id_tb.Clear(); projects_status_cb.Text = ""; projects_version_tb.Text = ""; 
        }

        // Работа над проектами
        private void add_work_b_Click(object sender, EventArgs e)
        {
            try
            {
                data_base db = new data_base();
                SqlCommand add_work_command = new SqlCommand("insert into [project_work] (employee, project_name, role_) values " +
                    "(@emp, @project_name, @role)", db.GetConnection());
                {
                    add_work_command.Parameters.AddWithValue("@emp", work_emp_cb.Text);
                    add_work_command.Parameters.AddWithValue("@project_name", work_project_cb.Text);
                    add_work_command.Parameters.AddWithValue("@role", work_role_cb.Text);

                    add_work_command.Connection.Open();
                    add_work_command.ExecuteNonQuery();
                } label61.Show();
                work.Columns.Clear(); work_columns(); work_refreshData(work);
            }
            catch { MessageBox.Show("Отсутствует соединение с сервером или базой данных", "Ошибка"); }
            work_emp_cb.Text = ""; work_project_cb.Text = ""; work_role_cb.Text = "";
        }

        // Календарные планы
        private void add_calendar_b_Click(object sender, EventArgs e)
        {
            try
            {
                data_base db = new data_base();
                SqlCommand add_plan_command = new SqlCommand("insert into [calendar_plan] (project_name, work_name, plan_start, fact_start, plan_end, fact_end) values " +
                    "(@project, @work, @plan_st, @fact_st, @plan_end, @fact_end)", db.GetConnection());
                {
                    add_plan_command.Parameters.AddWithValue("@project", calendar_project_cb.Text);
                    add_plan_command.Parameters.AddWithValue("@work", calendar_works_cb.Text);
                    add_plan_command.Parameters.AddWithValue("@plan_st", calendar_planstart_tb.Text);
                    add_plan_command.Parameters.AddWithValue("@fact_st", calendar_factstart_tb.Text);
                    add_plan_command.Parameters.AddWithValue("@plan_end", calendar_planend_tb.Text);
                    add_plan_command.Parameters.AddWithValue("@fact_end", calendar_factend_tb.Text);

                    add_plan_command.Connection.Open();
                    add_plan_command.ExecuteNonQuery();
                } label62.Show();
                calendar.Columns.Clear(); calendar_columns(); calendar_refreshData(calendar);
            }
            catch { MessageBox.Show("Отсутствует соединение с сервером или базой данных", "Ошибка"); }
            calendar_project_cb.Text = ""; calendar_works_cb.Text = ""; calendar_planstart_tb.Clear(); calendar_factstart_tb.Clear(); calendar_planend_tb.Clear(); calendar_factend_tb.Clear();
        }

        // Отчёты о тестировании
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                data_base db = new data_base();
                SqlCommand add_test_command = new SqlCommand("insert into [test_reports] (project_name, employee, content, date_) values " +
                    "(@project, @emp, @content, @date)", db.GetConnection());
                {
                    add_test_command.Parameters.AddWithValue("@project", test_project_cb.Text);
                    add_test_command.Parameters.AddWithValue("@emp", test_emp_cb.Text);
                    add_test_command.Parameters.AddWithValue("@content", test_content_tb.Text);
                    add_test_command.Parameters.AddWithValue("@date", test_date_tb.Text);

                    add_test_command.Connection.Open();
                    add_test_command.ExecuteNonQuery(); 
                } label63.Show();
                test_rep.Columns.Clear(); test_columns(); test_refreshData(test_rep);
            }
            catch { MessageBox.Show("Отсутствует соединение с сервером или базой данных", "Ошибка"); }
            test_project_cb.Text = ""; test_emp_cb.Text = ""; test_content_tb.Clear(); test_date_tb.Clear();
        }

        // Сотрудники
        private void add_emp_b_Click(object sender, EventArgs e)
        {
            try
            {
                data_base db = new data_base();
                SqlCommand add_emp_command = new SqlCommand("insert into [employees] (name_, family_name, patronymic, position_name, specialization) values " +
                    "(@name, @fname, @patr, @position, @spec)", db.GetConnection());
                {
                    add_emp_command.Parameters.AddWithValue("@name", emp_name_tb.Text);
                    add_emp_command.Parameters.AddWithValue("@fname", emp_familyname_tb.Text);
                    add_emp_command.Parameters.AddWithValue("@patr", emp_otchestvo_tb.Text);
                    add_emp_command.Parameters.AddWithValue("@position", emp_position_cb.Text);
                    add_emp_command.Parameters.AddWithValue("@spec", emp_spec_tb.Text);

                    add_emp_command.Connection.Open();
                    add_emp_command.ExecuteNonQuery();
                }
                emp_xml_doc.Load("xml/employees.xml");
                XmlElement xRoot = emp_xml_doc.DocumentElement;
                XmlElement emp_element = emp_xml_doc.CreateElement("employee");
                XmlAttribute emp_atribute = emp_xml_doc.CreateAttribute("name");

                string emp_name = emp_familyname_tb.Text + " " + emp_name_tb.Text + " " + emp_otchestvo_tb.Text;
                XmlText name = emp_xml_doc.CreateTextNode(emp_name);
                emp_atribute.AppendChild(name);
                emp_element.Attributes.Append(emp_atribute);
                xRoot.AppendChild(emp_element);
                emp_xml_doc.Save("xml/employees.xml"); label64.Show();
                employees.Columns.Clear(); employee_columns(); employee_refreshData(employees);
            }
            catch { MessageBox.Show("Отсутствует соединение с сервером или базой данных", "Ошибка"); }
            emp_name_tb.Clear(); emp_familyname_tb.Clear(); emp_otchestvo_tb.Clear(); emp_position_cb.Text = ""; emp_spec_tb.Clear();
        }

        // Должности
        private void add_position_b_Click(object sender, EventArgs e)
        {
            try
            {
                data_base db = new data_base();
                SqlCommand add_pos_command = new SqlCommand("insert into [positions] (position_name) values " +
                    "(@position)", db.GetConnection());
                {
                    add_pos_command.Parameters.AddWithValue("@position", position_name_tb.Text);

                    add_pos_command.Connection.Open();
                    add_pos_command.ExecuteNonQuery();
                }
                positions_xml_doc.Load("xml/positions.xml");
                XmlElement xRoot = positions_xml_doc.DocumentElement;
                XmlElement positions_element = positions_xml_doc.CreateElement("position");
                XmlAttribute positions_atribute = positions_xml_doc.CreateAttribute("name");

                string positions_name = position_name_tb.Text;
                XmlText name = positions_xml_doc.CreateTextNode(positions_name);
                positions_atribute.AppendChild(name);
                positions_element.Attributes.Append(positions_atribute);
                xRoot.AppendChild(positions_element);
                positions_xml_doc.Save("xml/positions.xml"); label65.Show();
                positions.Columns.Clear(); positions_columns(); positions_refreshData(positions);
            }
            catch { MessageBox.Show("Отсутствует соединение с сервером или базой данных", "Ошибка"); }
            position_name_tb.Clear();
        }

        // Проверка соединения с SQL Server
        private void sql_check_con_b_Click(object sender, EventArgs e)
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

        // События, происходящие при смене вкладок TabControl (элемент, на котором расположены поля для добавления записей в таблицу)
        private void tabControl1_Click(object sender, EventArgs e)
        {
            try {
                orders_client_cb.Items.Clear();
                work_project_cb.Items.Clear();
                calendar_project_cb.Items.Clear();
                work_emp_cb.Items.Clear();
                test_project_cb.Items.Clear();
                test_emp_cb.Items.Clear();
                emp_position_cb.Items.Clear();

                clients_xml_doc.Load("xml/clients.xml");
                XmlNodeList clients_list = clients_xml_doc.SelectNodes("clients/client");
                foreach (XmlNode clients_node in clients_list) orders_client_cb.Items.Add(clients_node.Attributes["name"].Value);

                projects_xml_doc.Load("xml/projects.xml");
                XmlNodeList projects_list = projects_xml_doc.SelectNodes("projects/project");
                foreach (XmlNode work_project_node in projects_list) work_project_cb.Items.Add(work_project_node.Attributes["name"].Value);
                foreach (XmlNode cal_project_node in projects_list) calendar_project_cb.Items.Add(cal_project_node.Attributes["name"].Value);
                foreach (XmlNode test_project_node in projects_list) test_project_cb.Items.Add(test_project_node.Attributes["name"].Value);

                emp_xml_doc.Load("xml/employees.xml");
                XmlNodeList emp_list = emp_xml_doc.SelectNodes("emp/employee");
                foreach (XmlNode work_emp_node in emp_list) work_emp_cb.Items.Add(work_emp_node.Attributes["name"].Value);
                foreach (XmlNode test_emp_node in emp_list) test_emp_cb.Items.Add(test_emp_node.Attributes["name"].Value);

                positions_xml_doc.Load("xml/positions.xml");
                XmlNodeList pos_list = positions_xml_doc.SelectNodes("positions/position");
                foreach (XmlNode pos_node in pos_list) emp_position_cb.Items.Add(pos_node.Attributes["name"].Value);
                label21.Hide(); label58.Hide(); label59.Hide(); label60.Hide(); label61.Hide(); label62.Hide(); label63.Hide(); label64.Hide(); label65.Hide(); label66.Hide();
            } catch { }
        }

        // Удаление и обновление записей

        //Клиенты
        private void deleteRow1()
        {
            int index = clients.CurrentCell.RowIndex;
            clients.Rows[index].Visible = false;
            if (clients.Rows[index].Cells[0].Value.ToString() == string.Empty)
            { clients.Rows[index].Cells[7].Value = RowState.Deleted; return; }
            clients.Rows[index].Cells[7].Value = RowState.Deleted;
        }
        private void update1()
        {
            data_base db = new data_base(); db.openConnection();
            for (int index = 0; index < clients.Rows.Count; index++)
            {
                var rowState = (RowState)clients.Rows[index].Cells[7].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(clients.Rows[index].Cells[0].Value);
                    var deletequery = $"delete from clients where id = {id}";
                    var command = new SqlCommand(deletequery, db.GetConnection());
                    command.ExecuteNonQuery();
                }
            } db.closeConnection();
        }
        // Заказы
        private void deleteRow2()
        {
            int index = orders.CurrentCell.RowIndex;
            orders.Rows[index].Visible = false;
            if (orders.Rows[index].Cells[0].Value.ToString() == string.Empty)
            { orders.Rows[index].Cells[6].Value = RowState.Deleted; return; }
            orders.Rows[index].Cells[6].Value = RowState.Deleted;
        }
        private void update2()
        {
            data_base db = new data_base(); db.openConnection();
            for (int index = 0; index < orders.Rows.Count; index++)
            {
                var rowState = (RowState)orders.Rows[index].Cells[6].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(orders.Rows[index].Cells[0].Value);
                    var deletequery = $"delete from orders where id = {id}";
                    var command = new SqlCommand(deletequery, db.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }
        // Технические задания
        private void deleteRow3()
        {
            int index = tz.CurrentCell.RowIndex;
            tz.Rows[index].Visible = false;
            if (tz.Rows[index].Cells[0].Value.ToString() == string.Empty)
            { tz.Rows[index].Cells[3].Value = RowState.Deleted; return; }
            tz.Rows[index].Cells[3].Value = RowState.Deleted;
        }
        private void update3()
        {
            data_base db = new data_base(); db.openConnection();
            for (int index = 0; index < tz.Rows.Count; index++)
            {
                var rowState = (RowState)tz.Rows[index].Cells[3].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(tz.Rows[index].Cells[0].Value);
                    var deletequery = $"delete from tz where id = {id}";
                    var command = new SqlCommand(deletequery, db.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }
        // Проекты
        private void deleteRow4()
        {
            int index = projects.CurrentCell.RowIndex;
            projects.Rows[index].Visible = false;
            if (projects.Rows[index].Cells[0].Value.ToString() == string.Empty)
            { projects.Rows[index].Cells[5].Value = RowState.Deleted; return; }
            projects.Rows[index].Cells[5].Value = RowState.Deleted;
        }
        private void update4()
        {
            data_base db = new data_base(); db.openConnection();
            for (int index = 0; index < projects.Rows.Count; index++)
            {
                var rowState = (RowState)projects.Rows[index].Cells[5].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(projects.Rows[index].Cells[0].Value);
                    var deletequery = $"delete from projects where id = {id}";
                    var command = new SqlCommand(deletequery, db.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }
        // Работа над проектами
        private void deleteRow5()
        {
            int index = work.CurrentCell.RowIndex;
            work.Rows[index].Visible = false;
            if (work.Rows[index].Cells[0].Value.ToString() == string.Empty)
            { work.Rows[index].Cells[4].Value = RowState.Deleted; return; }
            work.Rows[index].Cells[4].Value = RowState.Deleted;
        }
        private void update5()
        {
            data_base db = new data_base(); db.openConnection();
            for (int index = 0; index < work.Rows.Count; index++)
            {
                var rowState = (RowState)work.Rows[index].Cells[4].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(work.Rows[index].Cells[0].Value);
                    var deletequery = $"delete from project_work where id = {id}";
                    var command = new SqlCommand(deletequery, db.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }
        // Календарные планы
        private void deleteRow6()
        {
            int index = calendar.CurrentCell.RowIndex;
            calendar.Rows[index].Visible = false;
            if (calendar.Rows[index].Cells[0].Value.ToString() == string.Empty)
            { calendar.Rows[index].Cells[7].Value = RowState.Deleted; return; }
            calendar.Rows[index].Cells[7].Value = RowState.Deleted;
        }
        private void update6()
        {
            data_base db = new data_base(); db.openConnection();
            for (int index = 0; index < calendar.Rows.Count; index++)
            {
                var rowState = (RowState)calendar.Rows[index].Cells[7].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(calendar.Rows[index].Cells[0].Value);
                    var deletequery = $"delete from calendar_plan where id = {id}";
                    var command = new SqlCommand(deletequery, db.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }
        // Отчёты о тестировании
        private void deleteRow7()
        {
            int index = test_rep.CurrentCell.RowIndex;
            test_rep.Rows[index].Visible = false;
            if (test_rep.Rows[index].Cells[0].Value.ToString() == string.Empty)
            { test_rep.Rows[index].Cells[5].Value = RowState.Deleted; return; }
            test_rep.Rows[index].Cells[5].Value = RowState.Deleted;
        }
        private void update7()
        {
            data_base db = new data_base(); db.openConnection();
            for (int index = 0; index < test_rep.Rows.Count; index++)
            {
                var rowState = (RowState)test_rep.Rows[index].Cells[5].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(test_rep.Rows[index].Cells[0].Value);
                    var deletequery = $"delete from test_reports where id = {id}";
                    var command = new SqlCommand(deletequery, db.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }
        // Сотрудники
        private void deleteRow8()
        {
            int index = employees.CurrentCell.RowIndex;
            employees.Rows[index].Visible = false;
            if (employees.Rows[index].Cells[0].Value.ToString() == string.Empty)
            { employees.Rows[index].Cells[6].Value = RowState.Deleted; return; }
            employees.Rows[index].Cells[6].Value = RowState.Deleted;
        }
        private void update8()
        {
            data_base db = new data_base(); db.openConnection();
            for (int index = 0; index < employees.Rows.Count; index++)
            {
                var rowState = (RowState)employees.Rows[index].Cells[6].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(employees.Rows[index].Cells[0].Value);
                    var deletequery = $"delete from employees where id = {id}";
                    var command = new SqlCommand(deletequery, db.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }
        // Должности
        private void deleteRow9()
        {
            int index = positions.CurrentCell.RowIndex;
            positions.Rows[index].Visible = false;
            if (positions.Rows[index].Cells[0].Value.ToString() == string.Empty)
            { positions.Rows[index].Cells[2].Value = RowState.Deleted; return; }
            positions.Rows[index].Cells[2].Value = RowState.Deleted;
        }
        private void update9()
        {
            data_base db = new data_base(); db.openConnection();
            for (int index = 0; index < positions.Rows.Count; index++)
            {
                var rowState = (RowState)positions.Rows[index].Cells[2].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(positions.Rows[index].Cells[0].Value);
                    var deletequery = $"delete from positions where id = {id}";
                    var command = new SqlCommand(deletequery, db.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }
        // Пользователи
        private void deleteRow10()
        {
            int index = users.CurrentCell.RowIndex;
            users.Rows[index].Visible = false;
            if (users.Rows[index].Cells[0].Value.ToString() == string.Empty)
            { users.Rows[index].Cells[7].Value = RowState.Deleted; return; }
            users.Rows[index].Cells[7].Value = RowState.Deleted;
        }
        private void update10()
        {
            data_base db = new data_base(); db.openConnection();
            for (int index = 0; index < users.Rows.Count; index++)
            {
                var rowState = (RowState)users.Rows[index].Cells[7].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(users.Rows[index].Cells[0].Value);
                    var deletequery = $"delete from users where id = {id}";
                    var command = new SqlCommand(deletequery, db.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }
        private void Delete_b_Click(object sender, EventArgs e)
        {
            try
            {
                if (clients.Visible != false)
                { deleteRow1(); }
                if (orders.Visible != false)
                { deleteRow2(); }
                if (tz.Visible != false)
                { deleteRow3(); }
                if (projects.Visible != false)
                { deleteRow4(); }
                if (work.Visible != false)
                { deleteRow5(); }
                if (calendar.Visible != false)
                { deleteRow6(); }
                if (test_rep.Visible != false)
                { deleteRow7(); }
                if (employees.Visible != false)
                { deleteRow8(); }
                if (positions.Visible != false)
                { deleteRow9(); }
                if (users.Visible != false)
                { deleteRow10(); }
            }
            catch { }
        }

        // Сохранение изменений
        private void Correct_b_Click(object sender, EventArgs e)
        {
            try
            {
                if (clients.Visible != false)
                { update1(); }
                if (orders.Visible != false)
                { update2(); }
                if (tz.Visible != false)
                { update3(); }
                if (projects.Visible != false)
                { update4(); }
                if (work.Visible != false)
                { update5(); }
                if (calendar.Visible != false)
                { update6(); }
                if (test_rep.Visible != false)
                { update7(); }
                if (employees.Visible != false)
                { update8(); }
                if (positions.Visible != false)
                { update9(); }
                if (users.Visible != false)
                { update10(); }
            }
            catch { }
        }

        // Поиск записи
        //Клиенты
        private void clients_search(DataGridView dwg)
        {
            dwg.Rows.Clear(); data_base db = new data_base();
            string searchingString = $"select * from clients where concat (id, family_name, name_, patronymic, organization, phone, email) like '%" + textBox1.Text + "%'";
            SqlCommand com = new SqlCommand(searchingString, db.GetConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while(read.Read())
            {
                ReadSingleRow1(dwg, read);
            }
            read.Close();
        }
        // Заказы
        private void orders_search(DataGridView dwg)
        {
            dwg.Rows.Clear(); data_base db = new data_base();
            string searchingString = $"select * from orders where concat (id, client, status, date_of_accept, closing_date, deadline) like '%" + textBox1.Text + "%'";
            SqlCommand com = new SqlCommand(searchingString, db.GetConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow2(dwg, read);
            }
            read.Close();
        }
        // Технические задания
        private void tz_search(DataGridView dwg)
        {
            dwg.Rows.Clear(); data_base db = new data_base();
            string searchingString = $"select * from tz where concat (id, order_id, content) like '%" + textBox1.Text + "%'";
            SqlCommand com = new SqlCommand(searchingString, db.GetConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow3(dwg, read);
            }
            read.Close();
        }
        // Проекты
        private void projects_search(DataGridView dwg)
        {
            dwg.Rows.Clear(); data_base db = new data_base();
            string searchingString = $"select * from projects where concat (id, project_name, tz_id, project_status, current_version) like '%" + textBox1.Text + "%'";
            SqlCommand com = new SqlCommand(searchingString, db.GetConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow4(dwg, read);
            }
            read.Close();
        }
        // Работа над проектами
        private void work_search(DataGridView dwg)
        {
            dwg.Rows.Clear(); data_base db = new data_base();
            string searchingString = $"select * from project_work where concat (id, employee, project_name, role_) like '%" + textBox1.Text + "%'";
            SqlCommand com = new SqlCommand(searchingString, db.GetConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow5(dwg, read);
            }
            read.Close();
        }
        // Календарные планы
        private void calendar_search(DataGridView dwg)
        {
            dwg.Rows.Clear(); data_base db = new data_base();
            string searchingString = $"select * from calendar_plan where concat (id, project_name, work_name, plan_start, fact_start, plan_end, fact_end) like '%" + textBox1.Text + "%'";
            SqlCommand com = new SqlCommand(searchingString, db.GetConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow6(dwg, read);
            }
            read.Close();
        }
        // Тестовые отчётности
        private void test_search(DataGridView dwg)
        {
            dwg.Rows.Clear(); data_base db = new data_base();
            string searchingString = $"select * from test_reports where concat (id, project_name, employee, content, date_) like '%" + textBox1.Text + "%'";
            SqlCommand com = new SqlCommand(searchingString, db.GetConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow7(dwg, read);
            }
            read.Close();
        }
        // Сотрудники
        private void employees_search(DataGridView dwg)
        {
            dwg.Rows.Clear(); data_base db = new data_base();
            string searchingString = $"select * from employees where concat (id, family_name, name_, patronymic, position_name, specialization) like '%" + textBox1.Text + "%'";
            SqlCommand com = new SqlCommand(searchingString, db.GetConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow8(dwg, read);
            }
            read.Close();
        }
        // Должности
        private void position_search(DataGridView dwg)
        {
            dwg.Rows.Clear(); data_base db = new data_base();
            string searchingString = $"select * from positions where concat (id, position_name) like '%" + textBox1.Text + "%'";
            SqlCommand com = new SqlCommand(searchingString, db.GetConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow9(dwg, read);
            }
            read.Close();
        }
        // Пользователи
        private void users_search(DataGridView dwg)
        {
            dwg.Rows.Clear(); data_base db = new data_base();
            string searchingString = $"select * from users where concat (id, family_name, name_, otchestvo, user_login, user_password, user_role) like '%" + textBox1.Text + "%'";
            SqlCommand com = new SqlCommand(searchingString, db.GetConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow10(dwg, read);
            }
            read.Close();
        }
        // Кнопка поиска
        private void Searchbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (clients.Visible != false)
                { clients_search(clients); }

                if (orders.Visible != false)
                { orders_search(orders); }

                if (tz.Visible != false)
                { tz_search(tz); }

                if (projects.Visible != false)
                { projects_search(projects); }

                if (work.Visible != false)
                { work_search(work); }

                if (calendar.Visible != false)
                { calendar_search(calendar); }

                if (test_rep.Visible != false)
                { test_search(test_rep); }

                if (employees.Visible != false)
                { employees_search(employees); }

                if (positions.Visible != false)
                { position_search(positions); }

                if (users.Visible != false)
                { users_search(users); }
            }
            catch { MessageBox.Show("Ошибка", "Ошибка"); }
        }
        // События при изменении текстового поля поиска
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Справка о программе
        private void o_programme_b_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы запустили модуль информационной системы для фирмы по разработке программных продуктов.\n\nЦели приложения:\n- Автоматизация процесса ведения тестовых отчётностей;\n- Ведение календарных планов;\n" +
                "- Упрощение доступа к данным о разрабатываемых проектах\n\nПриложение разработал: Темяшкин Максим Владимирович, 402ИСиП\n2022","Справка");
        }

        // Обработчики событий нажатия на ячейки таблицы

        //Клиенты
        private void clients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = clients.Rows[selectedRow];
                id_tb.Text = row.Cells[0].Value.ToString();
            }
        }

        // Заказы
        private void orders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = orders.Rows[selectedRow];
                id_tb.Text = row.Cells[0].Value.ToString();
            }
        }

        // Технические задания
        private void tz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tz.Rows[selectedRow];
                id_tb.Text = row.Cells[0].Value.ToString();
            }
        }

        // Проекты
        private void projects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = projects.Rows[selectedRow];
                id_tb.Text = row.Cells[0].Value.ToString();
            }
        }

        // Работа над проектами
        private void work_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = work.Rows[selectedRow];
                id_tb.Text = row.Cells[0].Value.ToString();
            }
        }

        // Календарные планы
        private void calendar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = calendar.Rows[selectedRow];
                id_tb.Text = row.Cells[0].Value.ToString();
            }
        }

        // Тестовые отчётности
        private void test_rep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = test_rep.Rows[selectedRow];
                id_tb.Text = row.Cells[0].Value.ToString();
            }
        }

        // Сотрудники
        private void employees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = employees.Rows[selectedRow];
                id_tb.Text = row.Cells[0].Value.ToString();
            }
        }

        // Должности
        private void positions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = positions.Rows[selectedRow];
                id_tb.Text = row.Cells[0].Value.ToString();
            }
        }

        // Пользователи
        private void users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = users.Rows[selectedRow];
                id_tb.Text = row.Cells[0].Value.ToString();
            }
        }
    }
}
