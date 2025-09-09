using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void crtlTrafficLight1_Load(object sender, EventArgs e)
        {
            crtlTrafficLight1.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            crtlTrafficLight1.LightChanged += CrtlTrafficLight1_LightChanged;
        }

        private void CrtlTrafficLight1_LightChanged(object sender, TrafficLightEventArgs e)
        {
            MessageBox.Show(e.CurrentLight + " is on!");
        }
    }
}
