using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using MyLiberyDataBaseAndDataGredView;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
namespace _2_ЛАБА_ПРОГА_БАЗА_ДАННЫХ
{
    public partial class Вход : Form
    {

        public Вход()
        {
            InitializeComponent();
        }

        private void entry_Click(object sender, EventArgs e)
        {

            string user_login = "";
            string user_password = "";

            using (SQLiteConnection con = new SQLiteConnection("Data Source=MyBase.db"))
            {
                try
                {
                    con.Open();
                    string loginQuery = $"SELECT * FROM UserData WHERE Password = '{user_password}' AND Login = '{user_login}'";
                    SQLiteCommand command = new SQLiteCommand();//.getConnection());
                    command.Connection = con;
                    command.CommandText = loginQuery;
                    SQLiteDataReader de = command.ExecuteReader();
                    int a = 0;
                    int id = -1;
                    while (de.Read())
                    {
                        a++;
                        id = de.GetInt32(0);
                    }

                    if (a == 1)
                    {
                        //db.openConnection();

                        //db.closeConnection();
                        MessageBox.Show("Успешный вход");
                        DataForm Dfrm = new DataForm(id);
                        this.Hide();
                        Dfrm.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        if (a > 0)
                            MessageBox.Show("Несколько человек имеют такие данные");
                        else
                            MessageBox.Show("Неверный логин или пароль");
                    }

                    //while (de.Read())
                    //{

                    //    MessageBox.Show($"Hello, {de["id"]}!");

                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не получилось установить соединение с базой данных!",ex.Message);
                }
            }


            // int id = -1;
            //DataBase db = new DataBase();
            //using (var connection = new SqliteConnection("Data Source=D:/Users/User/User/MyBase.db"))
            //{

            //    string loginQuery = $"SELECT * FROM UserData";// WHERE Login = {user_login} AND Password = {user_password}";
            //    connection.Open();
            //    try
            //    {
            //        SqliteCommand command = new SqliteCommand();//.getConnection());
            //        command.Connection = connection;
            //        command.CommandText = loginQuery;
            //        SqliteDataReader reader = command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            var name = reader.GetString(0);

            //            Console.WriteLine($"Hello, {name}!");

            //        }
            //    }
            //    catch
            //    {
            //        // MessageBox.Show("Ошибка подключения к базе данных");
            //    }
            //    finally
            //    {
            //        // db.closeConnection();
            //    }
            //    Console.Read();

            //    //string user_login = labelLogin.Text;
            //    //string user_password = labelPassword.Text;
            //    //// int id = -1;
            //    ////DataBase db = new DataBase();
            //    //using (var db = new SqliteConnection("Data Source=D:/Users/User/User/Новая папка (2)/2_ЛАБА_ПРОГА_БАЗА_ДАННЫХ ACSESS/bin/Debug/MyBase.db"))
            //    //{

            //    //    string loginQuery = $"SELECT * FROM UserData WHERE Login = {user_login} AND Password = {user_password}";

            //    //    //   command.Parameters.Add("@uL", OleDbType.VarChar).Value = user_login;
            //    //    //  command.Parameters.Add("@uP", OleDbType.VarChar).Value = user_password;
            //    //    //db.openConnection();
            //    //    db.Open();
            //    //    try
            //    //    {
            //    //        SqliteCommand command = new SqliteCommand(loginQuery, db);//.getConnection());
            //    //        SqliteDataReader reader = command.ExecuteReader();
            //    //        if (reader.FieldCount == 1)
            //    //        {
            //    //            //db.openConnection();
            //    //            db.Open();
            //    //            int id = reader.GetInt32(0);

            //    //            //db.closeConnection();
            //    //            MessageBox.Show("Успешный вход");
            //    //            DataForm Dfrm = new DataForm(id);
            //    //            this.Hide();
            //    //            Dfrm.ShowDialog();
            //    //            this.Show();
            //    //        }
            //    //        else
            //    //        {
            //    //            if (reader.FieldCount > 0)
            //    //                MessageBox.Show("Несколько человек имеют такие данные");
            //    //            else
            //    //                MessageBox.Show("Неверный логин или пароль");
            //    //        }
            //    //    }
            //    //    catch
            //    //    {
            //    //        MessageBox.Show("Ошибка подключения к базе данных");
            //    //    }
            //    //    finally
            //    //    {
            //    //       // db.closeConnection();
            //    //    }
            //    //}
            //}

        }

        private void Вход_Load(object sender, EventArgs e)
        {

        }
    } 
}
