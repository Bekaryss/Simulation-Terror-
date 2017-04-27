using LiveCharts;
using LiveCharts.Wpf;
using MetroFramework.Forms;
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
using System.Windows.Media;
using TerrorismStatistics.Models;

namespace TerrorismStatistics
{
    public partial class Form1 : MetroForm
    {
        bool countryShow = false;
        public Form1()
        {
            InitializeComponent();
            ShowCountry();
            ShowUsa();
            ShowAR();
            ShowFrance();
            ThreadMethod();
        }

        private void ShowCountry()
        {
            var values = new Dictionary<string, double>();
            ProbabilityCalculator pc = new ProbabilityCalculator();
            List<Country> countries = pc.GetAllCountry();

            foreach (var cur in countries)
            {
                values[cur.Id] = cur.Probability;
            }

            gm_Country.GradientStopCollection = new GradientStopCollection
                {
                    new GradientStop(System.Windows.Media.Color.FromRgb(30,144,255), 0),
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 255, 0), .25),
                    new GradientStop(System.Windows.Media.Color.FromRgb(240,128,128), .5),
                    new GradientStop(System.Windows.Media.Color.FromRgb(255,0,0), .75),
                    new GradientStop(System.Windows.Media.Color.FromRgb(139,0,0), 1)
                };

            gm_Country.EnableZoomingAndPanning = true;
            gm_Country.HeatMap = values;
            gm_Country.Source = "Maps/World.xml";
            gm_Country.Visible = true;
            gm_Country.Update();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            
            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private void ShowUsa()
        {
            var values = new Dictionary<string, double>();
            ProbabilityCalculator pc = new ProbabilityCalculator();
            List<City> cities = pc.GetAllCities("usa");

            foreach (var cur in cities)
            {
                values[cur.Id] = cur.Probability;
            }

            gm_France.GradientStopCollection = new GradientStopCollection
                {
                    new GradientStop(System.Windows.Media.Color.FromRgb(30,144,255), 0),
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 255, 0), .25),
                    new GradientStop(System.Windows.Media.Color.FromRgb(240,128,128), .5),
                    new GradientStop(System.Windows.Media.Color.FromRgb(255,0,0), .75),
                    new GradientStop(System.Windows.Media.Color.FromRgb(139,0,0), 1)
                };

            gm_USA.EnableZoomingAndPanning = true;
            gm_USA.HeatMap = values;
            gm_USA.Source = "Maps/United States of America.xml";
            gm_USA.Visible = true;
            gm_USA.Visible = true;
            gm_USA.Update();
        }

        private void ShowAR()
        {
            var values = new Dictionary<string, double>();
            ProbabilityCalculator pc = new ProbabilityCalculator();
            List<City> cities = pc.GetAllCities("argentina");

            foreach (var cur in cities)
            {
                values[cur.Id] = cur.Probability;
            }

            gm_France.GradientStopCollection = new GradientStopCollection
                {
                    new GradientStop(System.Windows.Media.Color.FromRgb(30,144,255), 0),
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 255, 0), .25),
                    new GradientStop(System.Windows.Media.Color.FromRgb(240,128,128), .5),
                    new GradientStop(System.Windows.Media.Color.FromRgb(255,0,0), .75),
                    new GradientStop(System.Windows.Media.Color.FromRgb(139,0,0), 1)
                };

            gm_AR.EnableZoomingAndPanning = true;
            gm_AR.HeatMap = values;
            gm_AR.Source = "Maps/Argentina.xml";
            gm_AR.Visible = true;
            gm_AR.Visible = true;
            gm_AR.Update();
        }

        private void ShowFrance()
        {
            var values = new Dictionary<string, double>();
            ProbabilityCalculator pc = new ProbabilityCalculator();
            List<City> cities = pc.GetAllCities("france");

            foreach (var cur in cities)
            {
                values[cur.Id] = cur.Probability;
            }

            gm_France.GradientStopCollection = new GradientStopCollection
                {
                    new GradientStop(System.Windows.Media.Color.FromRgb(30,144,255), 0),
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 255, 0), .25),
                    new GradientStop(System.Windows.Media.Color.FromRgb(240,128,128), .5),
                    new GradientStop(System.Windows.Media.Color.FromRgb(255,0,0), .75),
                    new GradientStop(System.Windows.Media.Color.FromRgb(139,0,0), 1)
                };

            gm_France.EnableZoomingAndPanning = true;
            gm_France.HeatMap = values;
            gm_France.Source = "Maps/France.xml";
            gm_France.Visible = true;
            gm_France.Update();
        }

        public void ThreadMethod()
        {
            Thread t = new Thread(new ThreadStart(ShowText));
            t.Start();
        }

        public void ShowText()
        {
            Parser pc = new Parser();
            List<TerrorAttack> ta = pc.LoadFirst();
            for (int i=0; i<ta.Count; i++)
            {
                if(i % 2 == 0)
                {
                    Random r = new Random();
                    pictureBox1.Image = Bitmap.FromFile("data/terror/" + r.Next(1, 10) + ".jpg");
                }             
                string s = "City: " + ta[i].City + Environment.NewLine + Environment.NewLine + ta[i].Description + Environment.NewLine + Environment.NewLine + "Weapon: " + ta[i].Weapon;
                UpdateText(s);
                Thread.Sleep(3000);

            }
        }
        private delegate void MyDelegate(string s);
        private void UpdateText(string s)
        {
            if (this.textBox1.InvokeRequired)
            {
                MyDelegate d = new MyDelegate(UpdateText);
                this.Invoke(d, new object[] { s });
            }
            else
            {
                this.textBox1.Text = s;
            }                        
        }

        private void btn_Country_Click(object sender, EventArgs e)
        {
            if (countryShow == false)
            {
                ShowCountry();
                countryShow = true;
            }
            else
            {
                countryShow = false;
                gm_Country.Visible = false;
            }
           

        }
    }
}


