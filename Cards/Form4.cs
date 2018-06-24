using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Cards
{
    public partial class Form4 : Form
    {
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;

        public Form4()
        {
            InitializeComponent();
            textBox1.Text = Form2.Word;
            textBox2.Text = Form2.Translate;

            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();

            dbFileName = "cards.sqlite";
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;
                m_sqlCmd.CommandText = "UPDATE Cards SET word=\"" + textBox1.Text + "\", translate=\"" + textBox2.Text + "\" WHERE id=" + Form2.Id + "";
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                m_dbConn.Close();
            }
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
