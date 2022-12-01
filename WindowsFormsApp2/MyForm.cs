using ClassLibraryForArray1;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class MyForm : Form
    {
        private static IntArray ArrayFirst;
        private static IntArray ArraySecond;

        private static int startRandom = -10;
        private static int endRandom = 10;
        public MyForm()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.ColumnHeadersVisible = false;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView1.RowCount = 1;
            dataGridView2.RowCount = 1;
            dataGridView3.RowCount = 1;

            dataGridView1.ColumnCount = 10;
            dataGridView2.ColumnCount = 10;
            dataGridView3.ColumnCount = 10;

            numericUpDown3.Value = startRandom;
            numericUpDown4.Value = endRandom;

            ArrayFirst = new IntArray(10);
            ArraySecond = new IntArray(10);

            notifyIcon1.Icon = new System.Drawing.Icon(@"E:\C#\Лаба1(на самом деле 2)\ikonka.ico");
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = "Операция прошла успешно";
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    ArrayFirst[i] = Convert.ToInt32(dataGridView1.Rows[0].Cells[i].Value);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода числа", "Ошибка");
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    dataGridView1.Rows[0].Cells[i].Value = ArrayFirst[i];
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = (int)numericUpDown1.Value;
            ArrayFirst = new IntArray((int)numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            dataGridView2.ColumnCount = (int)numericUpDown2.Value;
            ArraySecond = new IntArray((int)numericUpDown2.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayFirst = IntArray.RandomIntArray(ArrayFirst.Length, startRandom, endRandom);
            for (int i = 0; i < ArrayFirst.Length; i++)
                dataGridView1.Rows[0].Cells[i].Value = ArrayFirst[i];
            notifyIcon1.BalloonTipText = "Заполнение массива 1 случайными значениями";
            notifyIcon1.ShowBalloonTip(3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArraySecond = IntArray.RandomIntArray(ArraySecond.Length, startRandom, endRandom);
            for (int i = 0; i < ArraySecond.Length; i++)
                dataGridView2.Rows[0].Cells[i].Value = ArraySecond[i];
            notifyIcon1.BalloonTipText = "Заполнение массива 2 случайными значениями";
            notifyIcon1.ShowBalloonTip(3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayFirst = IntArray.ArrayFromTextFile(path1.Text);
                dataGridView1.ColumnCount = ArrayFirst.Length;
                numericUpDown1.Value = ArrayFirst.Length;
                for (int i = 0; i < ArrayFirst.Length; i++)
                    dataGridView1.Rows[0].Cells[i].Value = ArrayFirst[i];
                notifyIcon1.BalloonTipText = "Заполнение массива 1 из файла";
                notifyIcon1.ShowBalloonTip(3);
            }
            catch
            {
                MessageBox.Show("Ошибка чтения файла", "Ошибка");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ArraySecond = IntArray.ArrayFromTextFile(path2.Text);
                dataGridView2.ColumnCount = ArraySecond.Length;
                numericUpDown2.Value = ArraySecond.Length;
                for (int i = 0; i < ArraySecond.Length; i++)
                    dataGridView2.Rows[0].Cells[i].Value = ArraySecond[i];
                notifyIcon1.BalloonTipText = "Заполнение массива 2 из файла";
                notifyIcon1.ShowBalloonTip(3);
            }
            catch
            {
                MessageBox.Show("Ошибка чтения файла", "Ошибка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int summ = 0;
            for (int i = 0; i < ArrayFirst.Length; i++)
            {
                summ += ArrayFirst[i];
            }
            textBox1.Text = Convert.ToString(summ);
            notifyIcon1.BalloonTipText = "Подсчёт суммы элементов массива 1";
            notifyIcon1.ShowBalloonTip(3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int summ = 0;
            for (int i = 0; i < ArraySecond.Length; i++)
            {
                summ += ArraySecond[i];
            }
            textBox2.Text = Convert.ToString(summ);
            notifyIcon1.BalloonTipText = "Подсчёт суммы элементов массива 2";
            notifyIcon1.ShowBalloonTip(3);
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ArrayFirst.Length == ArraySecond.Length)
            {
                dataGridView3.ColumnCount = dataGridView2.ColumnCount;
                IntArray arr = ArrayFirst + ArraySecond;
                for (int i = 0; i < ArrayFirst.Length; i++)
                {
                    dataGridView3.Rows[0].Cells[i].Value = arr[i];
                }
                notifyIcon1.BalloonTipText = "Подсчёт суммы массива 1 и массива 2";
                notifyIcon1.ShowBalloonTip(3);
            }
            else
            {
                MessageBox.Show("Длины массивов не совпадают", "Ошибка");
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ArrayFirst.Length == ArraySecond.Length)
            {
                dataGridView3.ColumnCount = dataGridView2.ColumnCount;
                IntArray arr = ArrayFirst - ArraySecond;
                for (int i = 0; i < ArrayFirst.Length; i++)
                {
                    dataGridView3.Rows[0].Cells[i].Value = arr[i];
                }
                notifyIcon1.BalloonTipText = "Подсчёт разности массива 1 и массива 2";
                notifyIcon1.ShowBalloonTip(3);
            }
            else
            {
                MessageBox.Show("Длины массивов не совпадают", "Ошибка");
            }
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ArrayFirst.Length != 0)
            {
                dataGridView1.ColumnCount = IntArray.Sort6(ArrayFirst).Length;
                for (int i = 0; i < IntArray.Sort6(ArrayFirst).Length; i++)
                {
                    dataGridView1.Rows[0].Cells[i].Value = IntArray.Sort6(ArrayFirst)[i];
                }
            }
            else
            {
                MessageBox.Show("Длина массива 1 равна нулю", "Ошибка");
            }
            if (ArraySecond.Length != 0)
            {
                dataGridView2.ColumnCount = IntArray.Sort6(ArraySecond).Length;
                for (int i = 0; i < IntArray.Sort6(ArraySecond).Length; i++)
                {
                    dataGridView2.Rows[0].Cells[i].Value = IntArray.Sort6(ArraySecond)[i];
                }
            }
            else
            {
                MessageBox.Show("Длина массива 2 равна нулю", "Ошибка");
            }
            notifyIcon1.BalloonTipText = "Перестройка массива 1 и массива 2 таким образом, чтобы сначала шли\nположительные значения, затем отрицательные, а в конце - нули.";
            notifyIcon1.ShowBalloonTip(3);
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView2.ColumnCount; i++)
                    ArraySecond[i] = Convert.ToInt32(dataGridView2.Rows[0].Cells[i].Value);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода числа", "Ошибка");
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    dataGridView2.Rows[0].Cells[i].Value = ArraySecond[i];
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Value >= endRandom)
            {
                MessageBox.Show("Ошибка ввода числа", "Ошибка");
                numericUpDown3.Value = startRandom;
            }
            else
            {
                startRandom = (int)Math.Ceiling(numericUpDown3.Value);
                numericUpDown3.Value = startRandom;
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown4.Value <= startRandom)
            {
                MessageBox.Show("Ошибка ввода числа", "Ошибка");
                numericUpDown4.Value = endRandom;
            }
            else
            {

                endRandom = (int)Math.Ceiling(numericUpDown4.Value);
                numericUpDown4.Value = endRandom;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                int scal = Convert.ToInt32(textBox3.Text);
                ArrayFirst += scal;
                ArraySecond += scal;
                dataGridView1.ColumnCount = ArrayFirst.Length;
                for (int i = 0; i < ArrayFirst.Length; i++)
                {
                    dataGridView1.Rows[0].Cells[i].Value = ArrayFirst[i];
                }
                dataGridView2.ColumnCount = ArraySecond.Length;
                for (int i = 0; i < ArraySecond.Length; i++)
                {
                    dataGridView2.Rows[0].Cells[i].Value = ArraySecond[i];
                }
                notifyIcon1.BalloonTipText = "Сложение массива 1 и массива 2 со скаляром";
                notifyIcon1.ShowBalloonTip(3);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода числа", "Ошибка");
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                int scal = Convert.ToInt32(textBox3.Text);
                scal += ArrayFirst;
                textBox3.Text = scal.ToString();
                notifyIcon1.BalloonTipText = "Сложение скаляра с элементами массива 1";
                notifyIcon1.ShowBalloonTip(3);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода числа", "Ошибка");
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                int scal = Convert.ToInt32(textBox3.Text);
                ArrayFirst -= scal;
                ArraySecond -= scal;
                dataGridView1.ColumnCount = ArrayFirst.Length;
                for (int i = 0; i < ArrayFirst.Length; i++)
                {
                    dataGridView1.Rows[0].Cells[i].Value = ArrayFirst[i];
                }
                dataGridView2.ColumnCount = ArraySecond.Length;
                for (int i = 0; i < ArraySecond.Length; i++)
                {
                    dataGridView2.Rows[0].Cells[i].Value = ArraySecond[i];
                }
                notifyIcon1.BalloonTipText = "Вычитание скаляра из массива 1 и массива 2";
                notifyIcon1.ShowBalloonTip(3);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода числа", "Ошибка");
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                int scal = Convert.ToInt32(textBox3.Text);
                scal -= ArrayFirst;
                textBox3.Text = scal.ToString();
                notifyIcon1.BalloonTipText = "Вычитание из скаляра элементов массива 1";
                notifyIcon1.ShowBalloonTip(3);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода числа", "Ошибка");
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ++ArrayFirst;
            ++ArraySecond;
            dataGridView1.ColumnCount = ArrayFirst.Length;
            for (int i = 0; i < ArrayFirst.Length; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = ArrayFirst[i];
            }
            dataGridView2.ColumnCount = ArraySecond.Length;
            for (int i = 0; i < ArraySecond.Length; i++)
            {
                dataGridView2.Rows[0].Cells[i].Value = ArraySecond[i];
            }
            notifyIcon1.BalloonTipText = "Увеличение всех элементов массива 1 и массива 2 на 1";
            notifyIcon1.ShowBalloonTip(3);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            --ArrayFirst;
            --ArraySecond;
            dataGridView1.ColumnCount = ArrayFirst.Length;
            for (int i = 0; i < ArrayFirst.Length; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = ArrayFirst[i];
            }
            dataGridView2.ColumnCount = ArraySecond.Length;
            for (int i = 0; i < ArraySecond.Length; i++)
            {
                dataGridView2.Rows[0].Cells[i].Value = ArraySecond[i];
            }
            notifyIcon1.BalloonTipText = "Уменьшение всех элементов массива 1 и массива 2 на 1";
            notifyIcon1.ShowBalloonTip(3);
        }
    }
}
