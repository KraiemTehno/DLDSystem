using DLDBussinesLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLD.Admin
{
    public partial class Investigation : Form
    {
        public Investigation(InvestigationView form)
        {
            InitializeComponent();
            label1.Text += $" {form.DocumentName}";
            groupBox1.Text += $" {form.Id}";
            label3.Text += $" {form.DateInvastigation}";
            label4.Text += $" {form.PageNumber+1}";
            dataGridView1.DataSource = form.ReportItemsView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
