using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottPlot;

namespace RareCrew
{
    internal class MyPieChart
    {
        internal static void generateChart(SortedList<int, string> parsedData)
        {
           
            Plot myPlot = new();
            List<PieSlice> slices = new List<PieSlice>();
            int i = 0;

            Color[] colors = { Colors.Red, Colors.Orange, Colors.Gold, Colors.Green, Colors.Blue, 
                Colors.Violet, Colors.Black, Colors.Coral, Colors.Cyan, Colors.Magenta, Colors.Aqua };


            foreach (var pair in parsedData)
            {
                slices.Add(new PieSlice { Value = pair.Key, FillColor = colors[i], Label = pair.Value });
                i++;
                if (i == colors.Length)
                    i = 0;
            }

            myPlot.Layout.Frameless();

            var pie = myPlot.Add.Pie(slices);
            pie.ShowSliceLabels = true;
            pie.SliceLabelDistance = 1.2;

            int width = 650, height = 500;
            myPlot.SavePng("../../../PieChart.png", width, height);

        }
    }
}
