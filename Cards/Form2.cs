using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Cards
{
    public partial class Form2 : Form
    {
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;

        public static string Id;
        public static string Word;
        public static string Translate;

        public Form2()
        {
            InitializeComponent();
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();

            dbFileName = "cards.sqlite";

            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            Fill();
        }
        public void Fill()
        {

            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;

            DataTable dTable = new DataTable();
            String sqlQuery;

            //if (m_dbConn.State != ConnectionState.Open)
            //{
            //    MessageBox.Show("Open connection with database");
            //    return;
            //}

            try
            {
                sqlQuery = "SELECT id, word, translate FROM Cards";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();

                    for (int i = 0; i < dTable.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add(dTable.Rows[i].ItemArray);
                        //MessageBox.Show(dTable.Rows[i].ItemArray[1].ToString());
                    }
                }
                //else
                //    MessageBox.Show("Database is empty");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                m_dbConn.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            Fill();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                Id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Word = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Translate = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

                Form4 form4 = new Form4();
                form4.ShowDialog();
                Fill();
            }
            catch
            {
                ;
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                //m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;
                m_sqlCmd.CommandText = "DELETE FROM Cards WHERE  id=" + dataGridView1.SelectedRows[0].Cells[0].Value + "";
                //m_sqlCmd.CommandText = "DELETE FROM Cards WHERE ( id=" + dataGridView1.SelectedCells[0].Value + " OR word='" + dataGridView1.SelectedCells[0].Value.ToString() + "' OR translate='" + dataGridView1.SelectedCells[0].Value.ToString() + ")";
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            catch
            {
                ;
            }
            finally
            {
                m_dbConn.Close();
                dataGridView1.Rows.Clear();
                Fill();
            }
        }
    }
}
