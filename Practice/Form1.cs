using System;
using System.ServiceProcess;
using System.Diagnostics;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Process Killer v3.1.2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] processes;
            processes = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process instance in processes)
            {
                listBox1.Items.Add(instance.ProcessName);
            }
        }

        private void Kill_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName(textBox1.Text))
            {
                process.Kill();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] processes;
            processes = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process instance in processes)
            {
                listBox1.Items.Add(instance.ProcessName);
            }
        }

        private void Find_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                int index = listBox1.FindString(textBox1.Text);
                if (index != -1)
                    listBox1.SetSelected(index, true);
                else
                    MessageBox.Show("This process was not found among the running ones.");
            }
        }
    }
}
