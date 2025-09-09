using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /*
        1. Add counter item
        2. Decrease it
        3. When it becomes 0:
            .change the light;
            .renew light-timer;
        4. 
    */


    public partial class crtlTrafficLight : UserControl
    {
        public crtlTrafficLight()
        {
            InitializeComponent();
        }

        public event EventHandler<TrafficLightEventArgs> LightChanged;
        protected virtual void OnLightChanged(TrafficLightEventArgs e)
        {
            LightChanged?.Invoke(this, e);
        }
        
        public enum enTrafficLights { Red = 0, Orange  = 1, Green = 2 };
        
        public enTrafficLights CurrentLight = enTrafficLights.Red;

        private int _CurrentDuration;

        public int RedDuration { get; set; } = 7;
        public int OrangeDuration { get; set; } = 2;
        public int GreenDuration { get; set; } = 10;

        public void Start()
        {
            CurrentLight = enTrafficLights.Red;
            _SetCurrLightItems();
            
            LightTimer.Start();
        }

        private void _SetCurrLightItems()
        {
            switch (CurrentLight)
            {
                case enTrafficLights.Red:
                    pictureBox1.Image = Properties.Resources.Red;
                    _CurrentDuration = RedDuration;
                    break;
                
                case enTrafficLights.Orange: 
                    pictureBox1.Image = Properties.Resources.Orange;
                    _CurrentDuration = OrangeDuration;
                    break;
                
                case enTrafficLights.Green:
                    pictureBox1.Image= Properties.Resources.Green;
                    _CurrentDuration = GreenDuration;
                    break;
            }

            lblTimer.Text = _CurrentDuration.ToString();
        }

        private void _ChangeEnumLight()
        {
            switch(CurrentLight)
            {
                case enTrafficLights.Red:
                    CurrentLight = enTrafficLights.Green;
                    break;
                case enTrafficLights.Orange:
                    CurrentLight = enTrafficLights.Red;
                    break;
                case enTrafficLights.Green:
                    CurrentLight = enTrafficLights.Orange;
                    break;
                
                default: 
                    CurrentLight = enTrafficLights.Red;
                    break;
            }
        }

        private void LightTimer_Tick(object sender, EventArgs e)
        {

            
            if (_CurrentDuration <= 0)
            {
                _ChangeEnumLight();
                _SetCurrLightItems();
                OnLightChanged(new TrafficLightEventArgs(CurrentLight, _CurrentDuration));
            }
            else 
                _CurrentDuration--;            

            lblTimer.Text = _CurrentDuration.ToString();
        }
    }

    public class TrafficLightEventArgs : EventArgs
    {
        public crtlTrafficLight.enTrafficLights CurrentLight { get; }
        public int LightDuration { get; }

        public TrafficLightEventArgs(crtlTrafficLight.enTrafficLights currentLight, int lightDuration)
        {
            CurrentLight = currentLight;
            LightDuration = lightDuration;
        }
    }
}
