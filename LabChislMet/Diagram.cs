using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LabChislMet
{
    public partial class Diagram : Form
    {
        ArrayList x;
        ArrayList y;
        ArrayList z;
        public Diagram(ArrayList _x, ArrayList _y , ArrayList _z)
        {
           
            InitializeComponent();
            x = _x;
            y = _y;
            z = _z;

}

        private void Diagram_Load(object sender, EventArgs e)
        {
            
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline; // тут сами поизменяет/повыбирайте тип вывода графика
            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].Name = "func";
            chart1.ChartAreas[0].AxisX.Title = "Количество n";
            chart1.ChartAreas[0].AxisY.Title = "Количество e";
            

            for (int i = 0; i < x.Count; i++)
                chart1.Series[0].Points.AddXY(x[i], y[i]);

            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline; // тут сами поизменяет/повыбирайте тип вывода графика
            chart2.Series[0].Color = Color.Red;
            chart2.Series[0].Name = "func";
            chart2.ChartAreas[0].AxisX.Title = "Количество n";
            chart2.ChartAreas[0].AxisY.Title = "Количество eRevA";

            for (int i = 0; i < x.Count; i++)
                chart2.Series[0].Points.AddXY(x[i], z[i]);


}
    }
}
