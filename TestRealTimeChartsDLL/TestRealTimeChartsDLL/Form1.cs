using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

using chartUpdate;

namespace TestRealTimeCharts
{
    public partial class Form1 : Form
    {
    

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            chartUpdater cUpdater = new chartUpdater(cpuChart);

            var t1 = System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                cUpdater.getPerformanceCounters();
            });
        }
    }
}