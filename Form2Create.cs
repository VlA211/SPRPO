using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLiberyDataBaseAndDataGredView;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;

namespace _2_ЛАБА_ПРОГА_БАЗА_ДАННЫХ
{
    public partial class Form2Create : Form
    {
        int id;
        DataBase db = new DataBase();
        public Form2Create(int id=-1)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button4Save_Click(object sender, EventArgs e)
        {
            string Name = textBox1Name.Text;
            string count = textBox2Count.Text;
            if (Name == "")
            {
                MessageBox.Show("Введите наименование объекта");
                return;
            }
            if (count == "")
            {
                MessageBox.Show("Введите количество объектов");
                return;
            }

            string createQuary = $"INSERT INTO `UserDDD` (`id`, `Name`, `Count`) VALUES ('{id}', '{Name}', '{count}');";

            SQLiteCommand command = new SQLiteCommand(createQuary, db.getConnection());
        //    command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToString(id);
         //   command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = Name;
         //   command.Parameters.Add("@Count", MySqlDbType.VarChar).Value = count;

            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
            MessageBox.Show("Запись успешно создана");

            this.Close();
        }

        private void Form2Create_Load(object sender, EventArgs e)
        {

        }
    }
}
