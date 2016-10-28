using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace chartUpdate
{
    public class chartUpdater
    {



        public chartUpdater(Chart chartControl)
        {
            chart = chartControl;

        }

        private Chart chart { get; set; }
        

    
        private double[] cpuArray = new double[60];

        public void getPerformanceCounters()
        {
            var cpuPerfCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

            while (true)
            {
                cpuArray[cpuArray.Length - 1] = Math.Round(cpuPerfCounter.NextValue(), 0);

                Array.Copy(cpuArray, 1, cpuArray, 0, cpuArray.Length - 1);

                if (chart.IsHandleCreated)
                {
                    chart.Invoke((MethodInvoker)delegate { UpdateCpuChart(); });
                }
                else
                {
                    //......
                }

                Thread.Sleep(1000);
            }


        }


        private void UpdateCpuChart()
        {
            chart.Series["Series1"].Points.Clear();

            for (int i = 0; i < cpuArray.Length - 1; ++i)
            {
                chart.Series["Series1"].Points.AddY(cpuArray[i]);
            }
        }




    }
}
