using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLiberyDataBaseAndDataGredView;
using System.Data.OleDb;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
namespace _2_ЛАБА_ПРОГА_БАЗА_ДАННЫХ
{
   
    public partial class DataForm : Form
    {

        List<Imgsing> imgs = new List<Imgsing>();
        List<Imgsing> imgsFil = new List<Imgsing>();
        DataBase dsfgdfgdfg = new DataBase();
        int selectedRow;
        int UserID;
        static List<string> img;
        static string panh = "Картинки";
        enum RowState
        {
            Existed,
            New,
            Modifiet,
            ModifietNew,
            Deleted
        }
        static int datagridcolums = 0;
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("idInformation ", "№");
            dataGridView1.Columns.Add("id", "id Пользователя");
            dataGridView1.Columns.Add("Name", "Наименование");
            dataGridView1.Columns.Add("Count", "Количество");
            dataGridView1.Columns.Add("bool", "Чекбокс");
            dataGridView1.Columns.Add("isNew", string.Empty);
            datagridcolums = 6;
        }

        const int Columns0 = 0;
        const int Columns1 = 1;
        const int Columns2 = 2;
        const int Columns3 = 3;
        const int Columns4 = 4;
        const int Columns5 = 5;
        const int Columns6 = 6;


        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(Columns0), record.GetInt32(Columns1), record.GetString(Columns2), record.GetInt32(Columns3), record.GetInt32(Columns4), RowState.ModifietNew);//, record.GetInt32(Columns4)
        }

        private void ImageAdd(int i)
        {
            
        }
        private void ImageMass()
        {
            imgsFil.Clear();
           // comboBox1.Items.Clear();
            string path = panh + "/Images.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string s = reader.ReadLine();
                int i = 0;
                while (s != null) // 
                {
                    Imgsing a = new Imgsing { punhImgs = s, number = i++ };
                    imgsFil.Add(a);
                    s = reader.ReadLine();
                    //comboBox1.Items.Add(a);
                }

            }
        }

        class Imgsing
        {
            public int number { get; set; }
            public string punhImgs { get; set; }
        }
        private void RefreshDataGrid(DataGridView dgv)
        { //Временно, реализовать id пользовател
            dgv.Rows.Clear();
            string queryString = $"SELECT * FROM `UserDDD` WHERE id = '{UserID}'";
            if (UserID < 1)
            {
                MessageBox.Show("Упс, что-то пошло не так");
                return;
            }
            SQLiteCommand command = new SQLiteCommand(queryString, dsfgdfgdfg.getConnection());
            //command.Parameters.Add("@id", .VarChar).Value = Convert.ToString(UserID);


            dsfgdfgdfg.openConnection();
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = "Images";
            imgColumn.Width = 58;
            if (dataGridView1.Columns.Count == datagridcolums)
            {
                DataGridViewCheckBoxColumn ggggg = new DataGridViewCheckBoxColumn();
                dataGridView1.Columns.Insert(Columns6, ggggg);
                dataGridView1.Columns.Add(imgColumn);
            }

            SQLiteDataReader reader = command.ExecuteReader();
            int i = 0;


            // imgColumn.AutoSizeMode = (DataGridViewAutoSizeColumnMode)AutoSizeMode.GrowAndShrink;

            //image.;
            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
                int bbb = reader.GetInt32(Columns4);
                bool a = false;
                if (bbb == 1)
                    a = true;
                //   DataGridViewCheckBoxCell checkBox = new DataGridViewCheckBoxCell(a);
                string pathIm = panh + "//";
                pathIm += reader["Img"].ToString();
                Bitmap bitmap;
                try
                {
                    bitmap = new Bitmap(pathIm);
                }
                catch
                {
                    bitmap = new Bitmap(panh + "//Eror.png");
                }
                Imgsing sd = new Imgsing { number = i, punhImgs = pathIm };
                dataGridView1.Rows[i].Cells["Images"].Value = new Bitmap(bitmap, 58, 25);
                if(dataGridView1.RowCount > imgs.Count())
                     imgs.Add(sd);
                dataGridView1.Rows[i++].Cells[Columns6].Value = a;
                // dataGridView1.Rows(Columns4, checkBox);
                //    dataGridView1.Rows.RemoveAt(Columns4);
            }

            reader.Close();
            dataGridView1.Columns[Columns0].Visible = false;
            dataGridView1.Columns[Columns4].Visible = false;
            dataGridView1.Columns[Columns5].Visible = false;

            comboBox1.DataSource = imgsFil;
            comboBox1.DisplayMember = "punhImgs";
            comboBox1.ValueMember = "punhImgs";
        }

        public DataForm(int id = -1)
        {
            InitializeComponent();
            UserID = id;

        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            comboBox1.DisplayMember = "punhImgs";
            comboBox1.ValueMember = "punhImgs";
            ImageMass();
            RefreshDataGrid(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2Create createfrm = new Form2Create(UserID);
            createfrm.Show();
        }
        int globa;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            globa = e.RowIndex;
            selectedRow = e.RowIndex;
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox1Name.Text = row.Cells[Columns2].Value.ToString();
                textBox2Count.Text = row.Cells[Columns3].Value.ToString();
                CherChahnge();
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            //if(dataGridView1.Columns.Count != datagridcolums)
            //    ChekGred();
        }

        private void DeletedRow()
        {
            if(dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Выберите объект, который хотите удалить");
                return;
            }
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;

            if(dataGridView1.Rows[index].Cells[Columns0].Value.ToString() != String.Empty)
            {
                dataGridView1.Rows[index].Cells[Columns5].Value = RowState.Deleted;
            }
        }
        private void button1Delete_Click(object sender, EventArgs e)
        {
            DeletedRow();
        }

        private void Update()
        {
            dsfgdfgdfg.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[Columns5].Value;

                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    string idInf = Convert.ToString(dataGridView1.Rows[index].Cells[Columns0].Value);

                    string deleteQuery =  $"DELETE FROM UserDDD WHERE idInformation  = '{idInf}' ";

                    SQLiteCommand command = new SQLiteCommand(deleteQuery, dsfgdfgdfg.getConnection());
                   // command.Parameters.Add("@idInf", OleDbType.VarChar).Value = idInf;
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка запроса к базе данных");
                    }
                }

                if(rowState == RowState.Modifiet)
                {
                    string id = dataGridView1.Rows[index].Cells[Columns0].Value.ToString();
                    string idUser = dataGridView1.Rows[index].Cells[Columns1].Value.ToString();
                    string name = dataGridView1.Rows[index].Cells[Columns2].Value.ToString();
                    string count = dataGridView1.Rows[index].Cells[Columns3].Value.ToString();

                    string changeQuery =  $"UPDATE `UserDDD` SET Name = '{name}', Count = '{count}' WHERE idInformation = '{id}'";
                    SQLiteCommand command = new SQLiteCommand(changeQuery, dsfgdfgdfg.getConnection());
                  //  command.Parameters.Add("@Na", OleDbType.VarChar).Value = name;
                  //  command.Parameters.Add("@Co", OleDbType.VarChar).Value = count;
                  //  command.Parameters.Add("@idInf", OleDbType.VarChar).Value = id;

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка запроса к базе данных");
                    }
                }
            }

        dsfgdfgdfg.closeConnection();
        }

        private void button4Save_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Change();
        }

        private void Change()
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Выберите объект, который хотите изменить");
                return;
            }
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            if(dataGridView1.Rows[selectedRowIndex].Cells[Columns0].Value.ToString() != string.Empty)
            {
                string id = dataGridView1.Rows[selectedRowIndex].Cells[Columns0].Value.ToString();
                string idUser = dataGridView1.Rows[selectedRowIndex].Cells[Columns1].Value.ToString();
                string name = textBox1Name.Text;
                string count = textBox2Count.Text;
              //string bb = dataGridView1.Rows[selectedRowIndex].Cells[Columns4].Value.ToString();

                dataGridView1.Rows[selectedRowIndex].SetValues(id, idUser, name, count);
                dataGridView1.Rows[selectedRowIndex].Cells[Columns5].Value = RowState.Modifiet;


            }
        }

        void ChekGred(int index)
        {
            string queryString = $"SELECT * FROM `UserDDD` WHERE idInformation = '{index}'";
            SQLiteCommand command = new SQLiteCommand(queryString, dsfgdfgdfg.getConnection());
            dsfgdfgdfg.openConnection();

            SQLiteDataReader reader = command.ExecuteReader();
            bool a = false;
            while (reader.Read())
            {
                if(reader["bool"].ToString() == "1");
                    a = true;
            }

            reader.Close();

            DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn(a);
            dataGridView1.Columns.Insert(Columns4, checkBox);

            if(dataGridView1.Columns.Count != datagridcolums)
                dataGridView1.Columns.RemoveAt(Columns4);

        }

        void CherChahnge()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

         
            string id = dataGridView1.Rows[selectedRowIndex].Cells[Columns0].Value.ToString();
            string idUser = dataGridView1.Rows[selectedRowIndex].Cells[Columns1].Value.ToString();
            string name = dataGridView1.Rows[selectedRowIndex].Cells[Columns2].Value.ToString();
            string count = dataGridView1.Rows[selectedRowIndex].Cells[Columns3].Value.ToString();
            string bb = dataGridView1.Rows[selectedRowIndex].Cells[Columns4].Value.ToString();
            var ccc = dataGridView1.Rows[selectedRowIndex].Cells[Columns4];

            string selectedState = comboBox1.SelectedIndex.ToString();
            int a = Int32.Parse(selectedState);
            string sf = imgs[a].punhImgs;
            Image ss = new Bitmap(sf);

            pictureBox2.Image = new Bitmap(ss, 60, 60);

            bool bv = false;
            if (dataGridView1.Rows[selectedRowIndex].Cells[Columns4].Value.ToString() == "1")
            {
                bv = true;
                bb = "0";
            }
            else
                bb = "1";
            string changeQuery = $"UPDATE `UserDDD` SET bool = '{bb}' WHERE idInformation = '{id}'";
            SQLiteCommand command = new SQLiteCommand(changeQuery, dsfgdfgdfg.getConnection());
            //SQLiteDataReader reader;
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса к базе данных");
            }

            dataGridView1.Rows[selectedRowIndex].SetValues(id, idUser, name, count, bb);
            //dataGridView1.Columns.RemoveAt(Columns4);
            //DataGridViewCheckBoxCell checkBox = new DataGridViewCheckBoxCell();
            dataGridView1.Rows[selectedRowIndex].Cells[Columns6].Value = !bv;
            //DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn(bv);
            //dataGridView1.Columns.Insert(Columns4, checkBox);

            //if(dataGridView1.Columns.Count != datagridcolums)
            //    dataGridView1.Columns.RemoveAt(Columns4);

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rsss = "Картинки/Eror.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sss = openFileDialog1.FileName;
                int lll = sss.Length - 1;
                while (true)
                {
                    if (sss[lll--] == '\\')
                    {
                        break;
                    }
                }
                sss = sss.Substring(lll + 2, sss.Length - lll - 2);
                rsss = "Картинки/" + sss;
                Image bitmap = new Bitmap(openFileDialog1.FileName);
                bitmap.Save(rsss);

                string path = panh + "/Images.txt";
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(sss);
                }
            }
            ImageMass();
            Imgsing a = new Imgsing { number = imgsFil.Count, punhImgs = rsss };
            //comboBox1.Items.Add(a);
            //comboBox1.Items.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedIndex.ToString();
            int a = Int32.Parse(selectedState);
            string sf = imgsFil[a].punhImgs;
            string ff = panh + '/' + sf;
            Image ss = new Bitmap(ff);
            pictureBox2.Image = new Bitmap(ss, 60, 60);
            try
            {
              //  if(globa == 0) 
              var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
                if (selectedRowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];
                    row.Cells["Images"].Value = pictureBox2.Image;

                    string id = dataGridView1.Rows[selectedRowIndex].Cells[Columns0].Value.ToString();
                    string changeQuery = $"UPDATE `UserDDD` SET Img = '{sf}' WHERE idInformation = '{id}'";
                    SQLiteCommand command = new SQLiteCommand(changeQuery, dsfgdfgdfg.getConnection());
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка запроса к базе данных");
                    }
                }
            }
            catch
            {
               // MessageBox.Show("gsfijs");
            }
            RefreshDataGrid(dataGridView1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;

            
           
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                {
                    wsh.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            }
           
            exApp.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;
            int i = 0;
            try
            {
                 i = dataGridView1.CurrentCell.RowIndex;

           




                for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                {
                    wsh.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            

            exApp.Visible = true;
            }
            catch
            {
                MessageBox.Show("Выберите строку");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;


            
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                bool a = Convert.ToBoolean(dataGridView1.Rows[i].Cells[Columns6].Value);
                if (!a) continue;
                for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                {
                    wsh.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            }

            exApp.Visible = true;
        }
    }
}
