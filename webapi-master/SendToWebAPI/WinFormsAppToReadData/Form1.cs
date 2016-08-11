using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendToWebAPI;
using SendToWebAPI.Models;

namespace WinFormsAppToReadData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startReadingButton_Click(object sender, EventArgs e)
        {
            MyTimer timer = new MyTimer();
            timer.StartWriting();
        }
    }
}
