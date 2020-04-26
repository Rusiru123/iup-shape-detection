using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapeDetection
{
    public partial class Form1 : Form
    {
        ShapeDetectAssist sda = new ShapeDetectAssist();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sda.OpenInitialImage();
            pictureBox1.ImageLocation ="bilBall.jpg"; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sda.captureShape();
            pictureBox2.ImageLocation = "grayBillmod2.jpg";
        }
    }
}
