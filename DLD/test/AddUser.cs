using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.Managers;
using test.Models;

namespace test
{
    public partial class AddUser : Form
    {
        private SQLManager sqlManager;
        public AddUser(SQLManager sqlManager)
        {
            InitializeComponent();
            this.sqlManager = sqlManager;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sqlManager.GetAllUsers().Any(x=>x.Name == textBox1.Text))
            {
                MessageBox.Show("Такой пользовтаель уже существует.", "Ошибка");
                return;
            }

            sqlManager.WriteUser(new User { Name = textBox1.Text });
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
