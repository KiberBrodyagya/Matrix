using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix
{
    class Matrix
    {
        public int size;
        public int[,] C;
        /*public int[,] values;
        public int RowSize;
        public int ColumnSize;*/

        public int this[int i, int j]
        {
            get
            {
                return C[i, j];
            }
            set
            {
                C[i, j] = value;
            }
        }

        public Matrix(int[,] a)
        {
            this.C = a;
            this.size = this.C.GetLength(0);
        }

        public Matrix(int size)
        {
            this.size = size;
            this.C = new int[size, size];
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.size);
            for (int i = 0; i < A.size; i++)
            {
                for (int j = 0; j < B.size; j++)
                {
                    C[i, j] = 0;
                    for (int k = 0; k < A.size; k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return C;
        }

        public static Matrix operator *(Matrix A, int numb)
        {
            Matrix C = new Matrix(A.size);
            for (int i = 0; i < C.size; i++)
            {
                for (int j = 0; j < C.size; j++)
                {
                    C[i, j] = A[i, j] * numb;
                }
            }
            return C;
        }

        public void ToString(DataGridView dgv)
        {
            dgv.RowCount = size;
            dgv.ColumnCount = size;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    dgv.Rows[i].Cells[j].Value = this[i, j];
                }
            }
        }
    }
}
