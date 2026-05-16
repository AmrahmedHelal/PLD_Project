

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using com.calitha.goldparser;
namespace PLDTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            p=new MyParser("OOP2.cgt",listboxOutput,listBox2);
        }
        MyParser p;
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            listboxOutput.Items.Clear();
            listBox2.Items.Clear();
           p.Parse(txtInput.Text);
        }

    }
}
