using System;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Cards
{
    public partial class Form1 : Form
    {
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;

        public Form1()
        {
            InitializeComponent();
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();

            dbFileName = "cards.sqlite";

            if (!File.Exists(dbFileName))
            {
                SQLiteConnection.CreateFile(dbFileName);
                CreateDB();
            }

            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
        }

        bool flag = true;

        private void btn_start_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            btn_start.Text = "Заново";

            Clear_Button();

            int N;

            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;

            DataTable dTable = new DataTable();
            String sqlQuery;

            try
            {
                sqlQuery = "SELECT word, translate FROM Cards";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);
                if (dTable.Rows.Count > 0)
                {
                    N = (dTable.Rows.Count <= 10) ? dTable.Rows.Count : 10;

                    int[] arr1 = new int[N];
                    fill_arr(arr1, -1);
                    fill_arr_Random(arr1, dTable.Rows.Count);

                    int[] arr2 = new int[N * 2];
                    fill_arr(arr2, -1);
                    fill_arr_Random(arr2, 20);

                    for (int i = 0; i < arr2.Length; i += 2)
                    {
                        Btn(i + 1, arr2[i], dTable.Rows[arr1[i / 2]].ItemArray[0].ToString(), 1);
                        Btn(i + 1, arr2[i + 1], dTable.Rows[arr1[i / 2]].ItemArray[1].ToString(), -1);
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                m_dbConn.Close();
            }

            flag = false;
        }

        private void Clear_Button()
        {
            button1.Text = "";
            button1.Tag = -1;

            button2.Text = "";
            button2.Tag = -1;

            button3.Text = "";
            button3.Tag = -1;

            button4.Text = "";
            button4.Tag = -1;

            button5.Text = "";
            button5.Tag = -1;

            button6.Text = "";
            button6.Tag = -1;

            button7.Text = "";
            button7.Tag = -1;

            button8.Text = "";
            button8.Tag = -1;

            button9.Text = "";
            button9.Tag = -1;

            button10.Text = "";
            button10.Tag = -1;

            button11.Text = "";
            button11.Tag = -1;

            button12.Text = "";
            button12.Tag = -1;

            button13.Text = "";
            button13.Tag = -1;

            button14.Text = "";
            button14.Tag = -1;

            button15.Text = "";
            button15.Tag = -1;

            button16.Text = "";
            button16.Tag = -1;

            button17.Text = "";
            button17.Tag = -1;

            button18.Text = "";
            button18.Tag = -1;

            button19.Text = "";
            button19.Tag = -1;

            button20.Text = "";
            button20.Tag = -1;
        }

        void fill_arr(int[] arr, int k)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = k;
            }
        }

        private void btn_cards_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void CreateDB()
        {
            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;

                m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Cards (id INTEGER PRIMARY KEY AUTOINCREMENT, word TEXT, translate TEXT)";
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                //label1.Text = "Disconnected";
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                m_dbConn.Close();
            }
        }

        void Btn(int m, int n, string str, int k)
        {
            switch (n)
            {
                case 0:
                    {
                        button1.Text = str;
                        button1.Tag = m * k;
                        break;
                    }
                case 1:
                    {
                        button2.Text = str;
                        button2.Tag = m * k;
                        break;
                    }
                case 2:
                    {
                        button3.Text = str;
                        button3.Tag = m * k;
                        break;
                    }
                case 3:
                    {
                        button4.Text = str;
                        button4.Tag = m * k;
                        break;
                    }
                case 4:
                    {
                        button5.Text = str;
                        button5.Tag = m * k;
                        break;
                    }
                case 5:
                    {
                        button6.Text = str;
                        button6.Tag = m * k;
                        break;
                    }
                case 6:
                    {
                        button7.Text = str;
                        button7.Tag = m * k;
                        break;
                    }
                case 7:
                    {
                        button8.Text = str;
                        button8.Tag = m * k;
                        break;
                    }
                case 8:
                    {
                        button9.Text = str;
                        button9.Tag = m * k;
                        break;
                    }
                case 9:
                    {
                        button10.Text = str;
                        button10.Tag = m * k;
                        break;
                    }
                case 10:
                    {
                        button11.Text = str;
                        button11.Tag = m * k;
                        break;
                    }
                case 11:
                    {
                        button12.Text = str;
                        button12.Tag = m * k;
                        break;
                    }

                case 12:
                    {
                        button13.Text = str;
                        button13.Tag = m * k;
                        break;
                    }
                case 13:
                    {
                        button14.Text = str;
                        button14.Tag = m * k;
                        break;
                    }
                case 14:
                    {
                        button15.Text = str;
                        button15.Tag = m * k;
                        break;
                    }
                case 15:
                    {
                        button16.Text = str;
                        button16.Tag = m * k;
                        break;
                    }
                case 16:
                    {
                        button17.Text = str;
                        button17.Tag = m * k;
                        break;
                    }
                case 17:
                    {
                        button18.Text = str;
                        button18.Tag = m * k;
                        break;
                    }
                case 18:
                    {
                        button19.Text = str;
                        button19.Tag = m * k;
                        break;
                    }
                case 19:
                    {
                        button20.Text = str;
                        button20.Tag = m * k;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Error ", n.ToString());
                        break;
                    }
            }
        }

        void fill_arr_Random(int[] arr, int k)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int t = -1;
                while (num_in_arr(arr, t))
                    t = (new Random()).Next(0, k);
                arr[i] = t;
            }
        }

        private bool num_in_arr(int[] arr, int t)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == t) return true;
            }
            return false;
        }

        int N1, N2;
        object b1;

        bool ofClearButton()
        {
            if (
                button1.Text == "" &&
                button2.Text == "" &&
                button3.Text == "" &&
                button4.Text == "" &&
                button5.Text == "" &&
                button6.Text == "" &&
                button7.Text == "" &&
                button8.Text == "" &&
                button9.Text == "" &&
                button10.Text == "" &&
                button11.Text == "" &&
                button12.Text == "" &&
                button13.Text == "" &&
                button14.Text == "" &&
                button15.Text == "" &&
                button16.Text == "" &&
                button17.Text == "" &&
                button18.Text == "" &&
                button19.Text == "" &&
                button20.Text == ""
                ) return true;
            else return false;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("         Цель игры – найти пары слов – слово и его перевод.", "Об игре", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void авторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("                Цапко Николай\r\n\n       E-mail: nik.capko@mail.ru", "Авторы", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show((sender as Button).Tag.ToString());

            if (flag)
            {
                N2 = (int)(sender as Button).Tag;

                if (N1 / (double)N2 == -1)
                {
                    (sender as Button).Text = "";
                    (sender as Button).Tag = -1;
                    //MessageBox.Show("");
                    (b1 as Button).Text = "";
                    (b1 as Button).Tag = -1;
                }

                flag = false;
            }
            else
            {
                flag = true;
                N1 = (int)(sender as Button).Tag;
                b1 = sender;
            }
        }
    }
}
