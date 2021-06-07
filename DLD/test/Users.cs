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

namespace test
{
    public partial class Users : Form
    {
        private SQLManager sqlManager;
        public Users(SQLManager sqlManager)
        {
            InitializeComponent();
            this.sqlManager = sqlManager;
            UpdateListUsers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (new AddUser(sqlManager).ShowDialog() == DialogResult.OK)
                UpdateListUsers();
        }

        private void UpdateListUsers()
        {
            listView1.Items.Clear();
            listView1.Items.AddRange(sqlManager.GetAllUsers().Select(x => new ListViewItem { Text = x.Name, ImageKey = x.Id.ToString() }).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userId = GetSelectedUserId();
            if (userId == -1)
            {
                MessageBox.Show("Пользователь не выбран", "Ошибка");
                return;
            }

            sqlManager.DeleteUser(userId);
            UpdateListUsers();
        }
        private int GetSelectedUserId()
        {
            if (listView1.SelectedItems.Count == 0) return -1;

            return int.Parse(listView1.SelectedItems[0].ImageKey);
        }
    }
}
