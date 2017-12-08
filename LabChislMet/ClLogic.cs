using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabChislMet
{
    class ClLogic
    {
        int[] q;
        double[,] a;
        int n;
        double [] myX;
        double[] b;
        double[] w;
        double[] y;
        double[] x;
        double maxEr = 0;
        Random rand = new Random();
        int counter=0;
      
        double[,] revA;
        double[,] startA;
        double detA = 1;
        double[,] e;
        double errorRevA;

        public double[,] CalcReverseMatrix(double[,] _a, int _n)
        {  
            n = _n;
            a = _a;
            revA = new double[n,n];
            for (int i=0;i<n;i++) {

                w = new double[n];
                y = new double[n];
                x = new double[n];

                //генерир B
                b = new double[n];
                b[i] = 1;

                calculateW();
                calculateX();
                //перенос в А
                for(int j=0;j<n;j++)
                {
                    revA[j, i] = x[j];
                }
            }

            calcErrorRevA();

            return revA;
        }

        private void calcErrorRevA()
        {
            double normA = norA(startA);

            //создаём массив
            e = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                e[i, i] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < n; k++)
                    {
                        sum += startA[i, k] * revA[k, j];
                    }
                    e[i, j] -= sum;
                }
            }
            double normRevA = norA(e);

            errorRevA = normRevA / normA;
        }


        private double norA(double [,] mas)
        {
            double normA = 0;
            for(int i=0;i<n;i++)
            {
                double sum = 0;
                for (int j=0;j<n;j++)
                {
                    sum += Math.Abs(mas[i, j]);
                }
                if(sum > normA)
                {
                    normA = sum;
                }
            }
            return normA;
        }

        private double[,] copyA(double[,] _a)
        {
            double[,] mas = new double[n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mas[i, j] = _a[i, j];
                }
            }
            return mas;
        }

        public double[,] resultSLAU(double[,] _a, int _n)
        {
            a = _a;
            n = _n;
            startA = copyA(_a);
            
            q = new int[n];
            myX = new double[n];
            b = new double[n];
            w = new double[n];
            y = new double[n];
            x = new double[n];

            generateMyX();
            calculateB();

            factorization();


            calculateW();
            calculateX();
            calcDetA();
            return a;
        }

        private void generateMyX()
        {
            for (int i = 0; i < n; i++)
            {
                q[i] = i;
                // задаём свой x
                myX[i] = i + 1;
            }
        }

        private void calculateB()
        {
            //умножение на вектор
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    b[i] += a[i, j] * myX[j];
                    counter++;
                }
            }
        }



        private void calculateW()
        {
            for (int i=0;i<n;i++)
            {
                double sum = 0;
                for (int j=0;j<i;j++)
                {
                    sum += a[i, q[j]]*w[j];
                    counter++;
                }
                w[i] = b[i] -sum;
            }
        }

        private void factorization()
        {
            for (int k = 0; k < n; k++)
            {

                pivoting(k);

                for (int j = k; j < n; j++)
                {
                    double sum = 0;
                    for (int m = 0; m < k; m++)
                    {
                        sum += a[k, q[m]] * a[m, q[j]];
                        counter++;
                    }
                    a[k, q[j]] -= sum;
                }

                for (int i = k + 1; i < n; i++)
                {
                    double sum = 0;
                    for (int m = 0; m < k; m++)
                    {
                        sum += a[i, q[m]] * a[m, q[k]];
                        counter++;
                    }
                    a[i, q[k]] -= sum;
                    a[i, q[k]] /= a[k, q[k]];
                    counter++;
                }
            }
        }

        private void calculateX()
        {
            for(int i=n-1;i>=0;i--)
            {
                double sum = 0;
                for(int j=n-1;j>=0;j--)
                {
                    sum += a[i, q[j]] * y[j];
                    counter++;
                }
                y[i] = (w[i] - sum)/a[i,q[i]];
            }

            // восстановление
            for (int j = 0; j < n; j++)
            {

                //поиск в q
                int index = 0;
                for (int i = 0; i < n; i++)
                {
                    if (q[i] == j)
                    {
                        index = i;
                    }
                }

                x[j] = y[index];
            }
            error();
        }

        private void error()
        {
            for (int i=0;i<n;i++)
            {
                if(Math.Abs(myX[i]-x[i]) > maxEr)
                {
                    maxEr = Math.Abs(myX[i] - x[i]);
                }
            }
        }

        private void calcDetA()
        {
            for(int i=0;i<n;i++)
            {
                detA *= a[i, i];
            }
        }

        public double getDetA()
        {
            return detA;
        }

        public double getErRevA()
        {
            return errorRevA;
        }

        public double getMaxEr()
        {
            return maxEr; 
        }

        public int[] getQ()
        {
            return q;
        }

        public double[] getMyX()
        {
            return myX;
        }
        public double[] getB()
        {
            return b;
        }
        public double[] getW()
        {
            return w;
        }
        public double[] getX()
        {
            return x;
        }

        public int getCounter()
        {
            return counter;
        }

        private void pivoting(int k) //поиск макс
        {
            //поиск макс
            double max = 0;
            int jMax = 0;


            for (int j = k; j < n; j++)
            {
                if (Math.Abs(a[k, j]) > max)
                {
                    max = a[k, j];
                    jMax = j;
                }
            }
            // перестановка в р
            int temp = q[k];
            q[k] = q[jMax];
            q[jMax] = temp;

        }


    }
}
