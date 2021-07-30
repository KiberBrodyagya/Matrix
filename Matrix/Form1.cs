using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix
{
    public partial class Form1 : Form
    {
        int size;
        int[,] A;
        int[,] B;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text == "n")
                {
                    return;
                }
                else
                {
                    size = Convert.ToInt32(textBox1.Text);
                }               

                dataGridView1.RowCount = size;
                dataGridView1.ColumnCount = size;
                dataGridView2.RowCount = size;
                dataGridView2.ColumnCount = size;
                dataGridView3.RowCount = size;
                dataGridView3.ColumnCount = size;

                A = new int[size, size];
                B = new int[size, size];

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = random.Next(0, 2);
                        A[i, j] = (int)dataGridView1.Rows[i].Cells[j].Value;
                    }
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = random.Next(0, 2);
                        B[i, j] = (int)dataGridView2.Rows[i].Cells[j].Value;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                A_B();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(textBox2.Text) != 0)
                {
                    A_n();
                }
                else
                {
                    A_1();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void A_n()
        {
            Matrix a = new Matrix(A);
            Matrix C = a * Convert.ToInt32(textBox2.Text);
            C.ToString(dataGridView3);
        }
        void A_1()
        {
            Matrix a = new Matrix(A);
            Matrix C = a * 1;
            C.ToString(dataGridView3);
        }
        void A_B()
        {
            Matrix a = new Matrix(A);
            Matrix b = new Matrix(B);
            Matrix C = a * b;
            C.ToString(dataGridView3);
        }
    }
}
