using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabChislMet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton2.Checked = true;
            comboBox1.Items.Add("Гильберта");
            comboBox1.Items.Add("Матрица 2");
            comboBox1.Items.Add("Матрица 3");
            comboBox1.Items.Add("Матрица 4");
            comboBox1.Items.Add("Матрица 5");
            comboBox1.Items.Add("Матрица 6");
            comboBox1.Items.Add("Матрица 7");
            comboBox1.Items.Add("Матрица 8");
            comboBox1.Items.Add("Матрица 9");
            comboBox1.Items.Add("Матрица 10");
            comboBox1.SelectedIndex = 0;
        }
        int n;
        string s = "";
        double maxEr = 0;
        double time = 0;
        
        double[,] a;
        double[,] revA;
        int counter;
        double detA;
        double errorRevA;

        ArrayList masN = new ArrayList();
        ArrayList masE = new ArrayList();
        ArrayList masErRevA = new ArrayList();

        private void button1_Click(object sender, EventArgs e)
        {
            detA = 0;


            masN.Clear();
            masE.Clear();
            masErRevA.Clear();

            textBox2.Text = "";
            textBox1.Text = "";
            try
            {
                textBox2.Text = "n\te\t\ttime\tNтеор\tNпракт\tdetA\t\tErRevA\r\n";
                if (radioButton1.Checked)
                {
                    counter = 0;
                    readMatrix();
                    func(n);

                    textBox2.AppendText(n.ToString() + "\t" + maxEr.ToString("G2", CultureInfo.InvariantCulture) + "\t\t" + time 
                        + "\t" + "\t" + counter + "\t"+ detA.ToString("G2", CultureInfo.InvariantCulture) + 
                        "\t\t" + errorRevA.ToString("G2", CultureInfo.InvariantCulture) + "\r\n");
                    masN.Add(n);
                    masE.Add(maxEr);
                    masErRevA.Add(errorRevA);

                }
                else if (radioButton2.Checked)
                {
                    for (int i = 5; i <= 100; i += 5)
                    {
                        calcAndPrint(i);
                    }

                }
                else if (radioButton3.Checked)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        for (int i = 4; i <= 40; i += 4)
                        {
                            calcAndPrint(i);
                        }
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        for (int i = 4; i <= 40; i += 4)
                        {
                            calcAndPrint(i);
                        }
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        calcAndPrint(7);
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        for (int i = 4; i <= 40; i += 4)
                        {
                            calcAndPrint(i);
                        }
                    }
                    else if (comboBox1.SelectedIndex == 4)
                    {
                        for (int i = 4; i <= 40; i += 4)
                        {
                            calcAndPrint(i);
                        }
                    }
                    else if (comboBox1.SelectedIndex == 5)
                    {
                        calcAndPrint(8);
                    }
                    else if (comboBox1.SelectedIndex == 6)
                    {
                        for (int i = 4; i <= 40; i += 4)
                        {
                            calcAndPrint(i);
                        }
                    }
                    else if (comboBox1.SelectedIndex == 7)//8
                    {
                        for (int i = 4; i <= 40; i += 4)
                        {
                            calcAndPrint(i);
                        }
                    }
                    else if (comboBox1.SelectedIndex == 8)
                    {
                        for (int i = 4; i <= 40; i += 4)
                        {
                            calcAndPrint(i);
                        }
                    }
                    else if (comboBox1.SelectedIndex == 9)
                    {
                        calcAndPrint(4);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введите корректное значение\r\n" + ex);
            }
        }

        private void readMatrix()
        {

            string s = textBox3.Text;
            s.Trim('\r');
            string[] mas = s.Split('\n');
            string[] mas1;
            n = mas.Length;
            a = new double[n, n];
            for (int i = 0; i < mas.Length; i++)
            {
                mas1 = mas[i].Split(' ');

                for (int j = 0; j < n; j++)
                {
                    a[i, j] = Convert.ToDouble(mas1[j]);
                }
            }


        }

        private void generMatrix(int n)
        {
            if (radioButton3.Checked)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    a = new double[n, n];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            a[i, j] = (double)(1) / ((i + 1) + (j + 1) - 1);
                        }

                    }
                }
                else if (comboBox1.SelectedIndex == 1)
                {

                    a = new double[n, n];
                    for (int i = 0; i < n; i++)
                    {
                        a[i, i] = 1;
                    }
                    for (int i = 0; i < n - 1; i++)
                    {
                        a[i, i + 1] = 1;
                    }

                }
                else if (comboBox1.SelectedIndex == 2)
                {

                    a = new double[n, n];
                    double[,] b = { { 5,4,7,5,6,7,5},
                        {4,12,8,7,8,8,6 },
                         { 7,8,10,9,8,7,7},
                          { 5,7,9,11,9,7,5},
                           {6,8,8,9,10,8,9 },
                            { 7,8,7,7,8,10,10},
                             { 5,6,7,5,9,10,10} };
                    a = b;



                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    a = new double[n, n];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (i == j)
                            {
                                a[i, j] = 0.01 / ((n + 1) - (i + 1) + 1) / ((i + 1) + 1);
                            }
                            else if (i < j)
                            {
                                a[i, j] = 0;
                            }
                            else if (i > j)
                            {
                                a[i, j] = (i + 1) * ((n + 1) - (j + 1));
                            }
                        }

                    }
                }
                else if (comboBox1.SelectedIndex == 4)
                {
                    a = new double[n, n];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (i == j)
                            {
                                a[i, j] = 0.01 / ((n + 1) - (i + 1) + 1) / ((i + 1) + 1);
                            }
                            else if (i < j)
                            {
                                a[i, j] = (j + 1) * ((n + 1) - (i + 1));
                            }
                            else if (i > j)
                            {
                                a[i, j] = (i + 1) * ((n + 1) - (j + 1));
                            }
                        }

                    }
                }
                else if (comboBox1.SelectedIndex == 5)
                {
                    double tet = 3.13;
                    a = new double[n, n];
                    double[,] b = {
                                        //R                                                      S                        T
                        { Math.Cos(tet)/Math.Sin(tet),1/Math.Sin(tet)   ,1-Math.Cos(tet)/Math.Sin(tet),1/Math.Sin(tet)  ,1,1,   1,1},
                        { -1/Math.Sin(tet),Math.Cos(tet)/Math.Sin(tet)  ,-1/Math.Sin(tet) ,1+Math.Cos(tet)/Math.Sin(tet) ,1,1,  1,1},

                         { 1-Math.Cos(tet)/Math.Sin(tet),1/Math.Sin(tet)    ,Math.Cos(tet)/Math.Sin(tet),1/Math.Sin(tet) ,   1-Math.Cos(tet)/Math.Sin(tet),1/Math.Sin(tet),1,1},
                         { -1/Math.Sin(tet) ,1+Math.Cos(tet)/Math.Sin(tet)  ,-1/Math.Sin(tet),Math.Cos(tet)/Math.Sin(tet),  -1/Math.Sin(tet) ,1+Math.Cos(tet)/Math.Sin(tet),1,1},

                           { 1,1,1-Math.Cos(tet)/Math.Sin(tet),1/Math.Sin(tet)      ,Math.Cos(tet)/Math.Sin(tet),1/Math.Sin(tet)   ,1-Math.Cos(tet)/Math.Sin(tet),1/Math.Sin(tet) },
                           { 1,1,-1/Math.Sin(tet) ,1+Math.Cos(tet)/Math.Sin(tet)    ,-1/Math.Sin(tet),Math.Cos(tet)/Math.Sin(tet)  ,-1/Math.Sin(tet) ,1+Math.Cos(tet)/Math.Sin(tet)},

                    { 1,1,1,1,1-Math.Cos(tet)/Math.Sin(tet),1/Math.Sin(tet)    ,Math.Cos(tet)/Math.Sin(tet),1/Math.Sin(tet)},
                    { 1,1,1,1,-1/Math.Sin(tet) ,1+Math.Cos(tet)/Math.Sin(tet)  ,-1/Math.Sin(tet),Math.Cos(tet)/Math.Sin(tet)}};

                    a = b;

                }
                else if (comboBox1.SelectedIndex == 6)
                {
                    a = new double[n, n];
                    double alpha = 0.5;
                    for (int i = 0; i < n; i++)
                    {
                        a[i, i] = Math.Pow(alpha, Math.Abs((n + 1) - 2 * (i + 1)) / 2);
                    }
                    for (int j = 0; j < n; j++)
                    {
                        a[0, j] = a[0, 0] / Math.Pow(alpha, (j + 1));
                        a[j, 0] = a[0, 0] / Math.Pow(alpha, (j + 1));

                        a[n - 1, j] = a[n - 1, n - 1] / Math.Pow(alpha, (j + 1));
                        a[j, n - 1] = a[n - 1, n - 1] / Math.Pow(alpha, (j + 1));
                    }

                }
                else if (comboBox1.SelectedIndex == 7) //8
                {
                    double h = 0.001;
                    a = new double[n, n];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            a[i, j] = Math.Exp((i + 1) * (j + 1) * h);
                        }

                    }
                }
                else if (comboBox1.SelectedIndex == 8)
                {
                    double c = 100000;
                    a = new double[n, n];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            a[i, j] = c + Math.Log((i + 1) * (j + 1), 2);
                        }

                    }
                }
                else if (comboBox1.SelectedIndex == 9)
                {
                    a = new double[n, n];
                    double[,] b = { { 0.00009143,0,0,0},
                        {0.8762,0.00007156,0,0 },
                         { 0.7943,0.8143,0.00009504,0},
                          { 0.8017,0.6123,0.7165,0.00007123} };
                    a = b;
                }

            }
            else if (radioButton2.Checked)
            {
                Random rand = new Random();
                a = new double[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = (rand.NextDouble() - 0.5) * 200;
                    }

                }
            }

        }

        private void func(int _n)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            n = _n;
            s = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s += a[i, j].ToString("0.000", CultureInfo.InvariantCulture) + "\t";
                }
                s += "\r\n";
            }
            s += "\r\n";
            ClLogic cl = new ClLogic();
            a = cl.resultSLAU(a, n);
            int[] q = cl.getQ();

            double[] myX = cl.getMyX();
            double[] b = cl.getB();
            double[] w = cl.getW();
            double[] x = cl.getX();

            for (int j = 0; j < n; j++)
            {
                s += (q[j] + 1) + "\t";
            }
            s += "\r\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s += a[i, j].ToString("0.000", CultureInfo.InvariantCulture) + "\t";
                }
                s += "\r\n";
            }
            printDash();
            s += "Вектор x (свой):";
            printDash2();
            for (int j = 0; j < n; j++)
            {
                s += myX[j].ToString("0.000", CultureInfo.InvariantCulture) + "\r\n";
            }
            printDash();
            s += "Вектор b:";
            printDash2();
            for (int j = 0; j < n; j++)
            {
                s += b[j].ToString("0.000", CultureInfo.InvariantCulture) + "\r\n";
            }
            printDash();
            s += "Вектор w:";
            printDash2();
            for (int j = 0; j < n; j++)
            {
                s += w[j].ToString("0.000", CultureInfo.InvariantCulture) + "\r\n";
            }

            printDash();
            s += "Вектор x:";
            printDash2();
            for (int j = 0; j < n; j++)
            {
                s += x[j].ToString() + "\r\n";
            }
            myStopwatch.Stop();
            printDash2();
            s += "Время расчётов: " + Convert.ToDouble(myStopwatch.ElapsedMilliseconds) / 1000 + " секунд\r\n";
            time = Convert.ToDouble(myStopwatch.ElapsedMilliseconds) / 1000;
            maxEr = cl.getMaxEr();
            counter += cl.getCounter();
            revA = cl.CalcReverseMatrix(a, n);

            s += "Максимальная ошибка: "+ maxEr.ToString("G2", CultureInfo.InvariantCulture) + "\r\n";

            s += "Обратная матрица\r\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s += revA[i, j].ToString("0.000", CultureInfo.InvariantCulture) + "\t";
                }
                s += "\r\n";
            }

            textBox1.AppendText(s);

            detA = cl.getDetA();
            errorRevA = cl.getErRevA();
        }

        private void printDash()
        {
            for (int i = 0; i < n / 4; i++)
            {
                s += "--------";
            }
        }
        private void printDash2()
        {
            for (int i = 0; i < n / 2; i++)
            {
                s += "--------";
            }
            s += "\r\n";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
            comboBox1.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            comboBox1.Enabled = true;
        }

        private void calcAndPrint(int i)
        {

            counter = 0;
            generMatrix(i);
            func(i);
            textBox2.AppendText(i.ToString() + "\t" + maxEr.ToString("G2", CultureInfo.InvariantCulture) +
                "\t\t" + time + "\t" + "\t" + counter + "\t" + detA.ToString("G2", CultureInfo.InvariantCulture) + 
                "\t\t" + errorRevA.ToString("G2", CultureInfo.InvariantCulture) + "\r\n");
            masN.Add(n);
            masE.Add(maxEr);
            masErRevA.Add(errorRevA);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 0) {
                string destFilename = "text.txt";
                if (!File.Exists(destFilename))
                {
                    File.Create(destFilename);
                }
                using (StreamWriter writer = File.AppendText(destFilename))
                {

                    if (radioButton1.Checked)
                    {
                        writer.WriteLine("С клавиатуры");
                    } else if (radioButton2.Checked)
                    {
                        writer.WriteLine("Случайно");
                    } else
                    {
                        writer.WriteLine(comboBox1.SelectedItem);
                    }
                    writer.WriteLine(textBox2.Text);

                    DialogResult result = MessageBox.Show("Открыть?", "Отчет сформирован", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes) 
                    {
                        Process.Start("text.txt");
                    }
                }

            }else
            {
                MessageBox.Show("Сделайте рассчеты","Инфо");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Diagram diag = new Diagram(masN, masE, masErRevA);
                diag.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }
    }
}
