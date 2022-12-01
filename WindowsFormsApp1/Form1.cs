using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;
using CauchyMethods;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Настройки элемента dataGridView под именем solutionTable
            solutionTable.RowHeadersVisible = true;
            solutionTable.ColumnHeadersVisible = false;
            solutionTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            solutionTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            solutionTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            solutionTable.AllowUserToAddRows = false;
            solutionTable.AllowUserToDeleteRows = false;
            solutionTable.ReadOnly = true;
            solutionTable.RowCount = 2;
            solutionTable.Rows[0].HeaderCell.Value = "x";
            solutionTable.Rows[1].HeaderCell.Value = "y";

            //Установка максимального количества символов у полей ввода
            startYValue.MaxLength = 10;
            iterMax.MaxLength = 10;
            leftBorder.MaxLength = 10;
            rightBorder.MaxLength = 10;

            //Деактивация кнопки calculation при начальной загрузке формы
            calculation.Enabled = false;
        }

        //Обработка события нажатия клавиш для поля ввода startYValue
        private void StartYValueKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ' ' && e.KeyChar == '\b' ||
                  (char.IsNumber(e.KeyChar) || (e.KeyChar == '-' && startYValue.TextLength == 0) ||
                   (!startYValue.Text.Contains(',') && e.KeyChar == ',' && startYValue.TextLength >= 1 && !startYValue.Text.Contains('-')) ||
                   (!startYValue.Text.Contains(',') && e.KeyChar == ',' && startYValue.TextLength >= 2 && startYValue.Text.Contains('-'))
                  )
               )
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //Обработка события нажатия клавиш для поля ввода iterMax
        private void IterMaxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ' ' && e.KeyChar == '\b' || (char.IsNumber(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //Обработка события нажатия клавиш для поля ввода leftBorder
        private void LeftBorderKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ' ' && e.KeyChar == '\b' ||
                  (char.IsNumber(e.KeyChar) || (e.KeyChar == '-' && leftBorder.TextLength == 0) ||
                   (!leftBorder.Text.Contains(',') && e.KeyChar == ',' && leftBorder.TextLength >= 1 && !leftBorder.Text.Contains('-')) ||
                   (!leftBorder.Text.Contains(',') && e.KeyChar == ',' && leftBorder.TextLength >= 2 && leftBorder.Text.Contains('-'))
                  )
               )
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //Обработка события нажатия клавиш для поля ввода rightBorder
        private void RightBorderKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ' ' && e.KeyChar == '\b' ||
                  (char.IsNumber(e.KeyChar) || (e.KeyChar == '-' && rightBorder.TextLength == 0) ||
                   (!rightBorder.Text.Contains(',') && e.KeyChar == ',' && rightBorder.TextLength >= 1 && !rightBorder.Text.Contains('-')) ||
                   (!rightBorder.Text.Contains(',') && e.KeyChar == ',' && rightBorder.TextLength >= 2 && rightBorder.Text.Contains('-'))
                  )
               )
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //Обработка события изменения текста в полях ввода для активации кнопки calculation только в определённых случаях
        private void CheckTextChanged(object sender, EventArgs e)
        {
            if ((startYValue.Text != "") && (iterMax.Text != "") && (leftBorder.Text != "") && (rightBorder.Text != "")
                && (startYValue.Text[startYValue.TextLength - 1] != ',') && (startYValue.Text[startYValue.TextLength - 1] != '-')
                && (leftBorder.Text[leftBorder.TextLength - 1] != ',') && (leftBorder.Text[leftBorder.TextLength - 1] != '-')
                && (rightBorder.Text[rightBorder.TextLength - 1] != ',') && (rightBorder.Text[rightBorder.TextLength - 1] != '-'))
            {
                calculation.Enabled = true;
            }
            else
            {
                calculation.Enabled = false;
            }
        }

        //Обработка события нажатия кнопки calculation
        private void CalculationClick(object sender, EventArgs e)
        {
            //Перевод условий, вписанных в поля ввода, в необходимые числовые форматы
            double aValue = Convert.ToDouble(leftBorder.Text);
            double bValue = Convert.ToDouble(rightBorder.Text);
            double yValue = Convert.ToDouble(startYValue.Text);
            int nValue = Convert.ToInt32(iterMax.Text);

            //Создание настроек элемента zedGraph под именем solutionGraph
            GraphPane pane = solutionGraph.GraphPane;
            pane.XAxis.Title.Text = "Ось X";
            pane.YAxis.Title.Text = "Ось Y";
            pane.CurveList.Clear();
            PointPairList list = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();

            //Создание экземпляра класса условий задачи Коши
            CauchyConditions cauCon = new CauchyConditions(aValue, bValue, yValue, nValue);

            //Увеличение количества столбцов таблицы solutionTable в соответствии со значением количества итераций
            solutionTable.ColumnCount = cauCon.Iterations;

            //Инициализация двумерного массива с двумя строками и количеством столбцов, соответствующему количеству итераций,
            //для записи решения задачи Коши
            double[,] solution = new double[2, cauCon.Iterations];

            //Решение задачи Коши при выборе метода Эйлера
            if (eulerOption.Checked == true)
            {
                //Установка заголовка для solutionGraph как "Метод Эйлера"
                pane.Title.Text = "Метод Эйлера";

                //Решение задачи Коши методом Эйлера для функции производной (x - y)^2 + 1
                if (squareOption.Checked == true)
                {
                    solution = Methods.Euler(cauCon, (x, y) => Derivative.Square(cauCon.A, cauCon.Y));
                }
                //Решение задачи Коши методом Эйлера для функции производной x^2 + y
                if (simpleSquareOption.Checked == true)
                {
                    solution = Methods.Euler(cauCon, (x, y) => Derivative.SimpleSquare(cauCon.A, cauCon.Y));
                }

                //Запись значений двумерного массива solution в таблицу solutionTable
                for (int i = 0; i < solutionTable.RowCount; i++)
                {
                    for (int j = 0; j < solutionTable.ColumnCount; j++)
                    {
                        solutionTable.Rows[i].Cells[j].Value = solution[i, j];
                    }
                }

                //Запись  значений двумерного массива solution в список точек list графика solutionGraph
                for (int i = 0; i < solutionTable.ColumnCount; i++)
                {
                    list.Add(solution[0, i], solution[1, i]);
                }

                //Отрисовка интегральной кривой зелёного цвета, подписанной как "Метод Эйлера",
                //в соответствии со значениями множества точек list
                LineItem myCurve = pane.AddCurve("Метод Эйлера", list, Color.Green, SymbolType.None);
                solutionGraph.AxisChange();
                solutionGraph.Invalidate();
            }

            //Решение задачи Коши при выборе модифицированного метода Эйлера
            if (modifEulerOption.Checked == true)
            {
                //Установка заголовка для solutionGraph как "Модифицированный метод Эйлера"
                pane.Title.Text = "Модифицированный метод Эйлера";

                //Решение задачи Коши модифицированным методом Эйлера для функции производной (x - y)^2 + 1
                if (squareOption.Checked == true)
                {
                    solution = Methods.ModifiedEuler(cauCon, (x, y) => Derivative.Square(cauCon.A, cauCon.Y));
                }
                //Решение задачи Коши модифицированным методом Эйлера для функции производной x^2 + y
                if (simpleSquareOption.Checked == true)
                {
                    solution = Methods.ModifiedEuler(cauCon, (x, y) => Derivative.SimpleSquare(cauCon.A, cauCon.Y));
                }

                //Запись значений двумерного массива solution в таблицу solutionTable
                for (int i = 0; i < solutionTable.RowCount; i++)
                {
                    for (int j = 0; j < solutionTable.ColumnCount; j++)
                    {
                        solutionTable.Rows[i].Cells[j].Value = solution[i, j];
                    }
                }

                //Запись  значений двумерного массива solution в список точек list графика solutionGraph
                for (int i = 0; i < solutionTable.ColumnCount; i++)
                {
                    list.Add(solution[0, i], solution[1, i]);
                }

                //Отрисовка интегральной кривой синего цвета, подписанной как "Модифицированный метод Эйлера",
                //в соответствии со значениями множества точек list
                LineItem myCurve = pane.AddCurve("Модифицированный метод Эйлера", list, Color.Blue, SymbolType.None);
                solutionGraph.AxisChange();
                solutionGraph.Invalidate();
            }

            //Решение задачи Коши при выборе метода Рунге-Кутты
            if (rungeKuttaOption.Checked == true)
            {
                //Установка заголовка для solutionGraph как "Метод Рунге-Кутты"
                pane.Title.Text = "Метод Рунге-Кутты";

                //Решение задачи Коши методом Рунге-Кутты для функции производной (x - y)^2 + 1
                if (squareOption.Checked == true)
                {
                    solution = Methods.RungeKutta(cauCon, (x, y) => Derivative.Square(cauCon.A, cauCon.Y));
                }
                //Решение задачи Коши методом Рунге-Кутты для функции производной x^2 + y
                if (simpleSquareOption.Checked == true)
                {
                    solution = Methods.RungeKutta(cauCon, (x, y) => Derivative.SimpleSquare(cauCon.A, cauCon.Y));
                }

                //Запись значений двумерного массива solution в таблицу solutionTable
                for (int i = 0; i < solutionTable.RowCount; i++)
                {
                    for (int j = 0; j < solutionTable.ColumnCount; j++)
                    {
                        solutionTable.Rows[i].Cells[j].Value = solution[i, j];
                    }
                }

                //Запись  значений двумерного массива solution в список точек list графика solutionGraph
                for (int i = 0; i < solutionTable.ColumnCount; i++)
                {
                    list.Add(solution[0, i], solution[1, i]);
                }

                //Отрисовка интегральной кривой красного цвета, подписанной как "Метод Рунге-Кутты",
                //в соответствии со значениями множества точек list
                LineItem myCurve = pane.AddCurve("Метод Рунге-Кутты", list, Color.Red, SymbolType.None);
                solutionGraph.AxisChange();
                solutionGraph.Invalidate();
            }

            //Решение задачи Коши всеми тремя методами с целью их наглядного сравнения
            if (compareOption.Checked == true)
            {
                //Установка заголовка для solutionGraph как "Сравнение методов"
                pane.Title.Text = "Сравнение методов";

                //Создание дополнительных экземпляров класса условий задачи Коши
                CauchyConditions cauCon2 = new CauchyConditions(aValue, bValue, yValue, nValue);
                CauchyConditions cauCon3 = new CauchyConditions(aValue, bValue, yValue, nValue);

                //Инициализация дополнительных двумерных массивов с двумя строками и количеством столбцов, соответствующему количеству итераций,
                //для записи решений задачи Коши разными методами
                double[,] solution1 = new double[2, cauCon.Iterations];
                double[,] solution2 = new double[2, cauCon.Iterations];
                double[,] solution3 = new double[2, cauCon.Iterations];

                //Решение задачи Коши всеми методами для функции производной (x - y)^2 + 1
                if (squareOption.Checked == true)
                {
                    solution1 = Methods.Euler(cauCon, (x, y) => Derivative.Square(cauCon.A, cauCon.Y));
                    solution2 = Methods.ModifiedEuler(cauCon2, (x, y) => Derivative.Square(cauCon2.A, cauCon2.Y));
                    solution3 = Methods.RungeKutta(cauCon3, (x, y) => Derivative.Square(cauCon3.A, cauCon3.Y));
                }
                //Решение задачи Коши всеми методами для функции производной x^2 + y
                if (simpleSquareOption.Checked == true)
                {
                    solution1 = Methods.Euler(cauCon, (x, y) => Derivative.SimpleSquare(cauCon.A, cauCon.Y));
                    solution2 = Methods.ModifiedEuler(cauCon2, (x, y) => Derivative.SimpleSquare(cauCon2.A, cauCon2.Y));
                    solution3 = Methods.RungeKutta(cauCon3, (x, y) => Derivative.SimpleSquare(cauCon3.A, cauCon3.Y));
                }

                //Запись в первые две строки таблицы solutionTable решение задачи Коши методом Эйлера
                //и окрашивание второй строки таблицы, содержащей значения y, в зелёный цвет
                for (int i = 0; i < solutionTable.ColumnCount; i++)
                {
                    solutionTable.Rows[0].Cells[i].Value = solution1[0, i];
                    solutionTable.Rows[1].Cells[i].Value = solution1[1, i];
                    solutionTable.Rows[1].Cells[i].Style.BackColor = System.Drawing.Color.Green;
                }
                //Запись в третью строку таблицы solutionTable значений y решения задачи Коши модифицированным методом Эйлера
                //и окрашивание данной строки в синий цвет
                for (int i = 0; i < solutionTable.ColumnCount; i++)
                {
                    solutionTable.Rows[2].Cells[i].Value = solution2[1, i];
                    solutionTable.Rows[2].Cells[i].Style.BackColor = System.Drawing.Color.Blue;
                }
                //Запись в четвёртую строку таблицы solutionTable значений y решения задачи Коши методом Рунге-Кутты
                //и окрашивание данной строки в красный цвет
                for (int i = 0; i < solutionTable.ColumnCount; i++)
                {
                    solutionTable.Rows[3].Cells[i].Value = solution3[1, i];
                    solutionTable.Rows[3].Cells[i].Style.BackColor = System.Drawing.Color.Red;
                }

                //Запись значений двумерных массивов solution1, solution2 и solution3 в списки точек list, list2 и list3 графика solutionGraph соответственно
                for (int i = 0; i < solutionTable.ColumnCount; i++)
                {
                    list.Add(solution1[0, i], solution1[1, i]);
                    list2.Add(solution2[0, i], solution2[1, i]);
                    list3.Add(solution3[0, i], solution3[1, i]);
                }

                //Отрисовка интегральных кривых зелёного, синего и красного цвета, подписанных как "Метод Эйлера",
                //"Модифицированный метод Эйлера" и "Метод Рунге-Кутты" соответственно,
                //в соответствии со значениями множества точек list, list2 и list3
                LineItem myCurve1 = pane.AddCurve("Метод Эйлера", list, Color.Green, SymbolType.None);
                LineItem myCurve2 = pane.AddCurve("Модифицированный метод Эйлера", list2, Color.Blue, SymbolType.None);
                LineItem myCurve3 = pane.AddCurve("Метод Рунге-Кутты", list3, Color.Red, SymbolType.None);
                solutionGraph.AxisChange();
                solutionGraph.Invalidate();
            }
        }

        //Обработка события выбора метода сравнения методов
        private void CompareOption_CheckedChanged(object sender, EventArgs e)
        {
            //Установка четырёх строк у таблицы решений solutionTable
            solutionTable.RowCount = 4;
            //Установка заголовка первой строки "x"
            solutionTable.Rows[0].HeaderCell.Value = "x";
            //Установка заголовков второй, третьей и четвёртой строк "y"
            for (int i = 1; i < solutionTable.RowCount; i++) {
                 solutionTable.Rows[i].HeaderCell.Value = "y";
            }
            for (int i = 0; i < solutionTable.RowCount; i++)
            {
                for (int j = 0; j < solutionTable.ColumnCount; j++)
                {
                    //Значения в таблице solutionTable стираются и ячейки окрашиваются в белый цвет
                    solutionTable.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                    solutionTable.Rows[i].Cells[j].Value = "";
                }
            }
        }

        //Обработка события перевыбора метода (любого, кроме сравнения методов)
        private void MethodOption_CheckedChanged(object sender, EventArgs e)
        {
            //Установка двух строк у таблицы решений solutionTable
            solutionTable.RowCount = 2;
            //Установка заголовка первой строки "x"
            solutionTable.Rows[0].HeaderCell.Value = "x";
            //Установка заголовка второй строки "y"
            solutionTable.Rows[1].HeaderCell.Value = "y";
            for (int i = 0; i < solutionTable.RowCount; i++)
            {
                for (int j = 0; j < solutionTable.ColumnCount; j++)
                {
                    //Значения в таблице solutionTable стираются и ячейки окрашиваются в белый цвет
                    solutionTable.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                    solutionTable.Rows[i].Cells[j].Value = "";
                }
            }
        }

        //Обработка события перевыбора функции производной
        private void DerivativeOption_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < solutionTable.RowCount; i++)
            {
                for (int j = 0; j < solutionTable.ColumnCount; j++)
                {
                    //Значения в таблице solutionTable стираются и ячейки окрашиваются в белый цвет
                    solutionTable.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                    solutionTable.Rows[i].Cells[j].Value = "";
                }
            }
        }
    }
}
