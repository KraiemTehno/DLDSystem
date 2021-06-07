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
    public partial class SelectUser : Form
    {
        public int selectedUserId;
        private SQLManager sqlManager;
        public SelectUser(SQLManager sqlManager)
        {
            InitializeComponent();
            this.sqlManager = sqlManager;
            UpdateListUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedUserId = (comboBox1.SelectedItem as User).Id;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void UpdateListUsers()
        {
            comboBox1.DataSource = sqlManager.GetAllUsers().ToArray();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void SelectUser_Shown(object sender, EventArgs e)
        {
            UpdateListUsers();
        }
    }
}
