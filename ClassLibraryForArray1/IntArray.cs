using System;
using System.Collections.Generic;
using System.IO;

namespace ClassLibraryForArray1
{
    public class IntArray
    {
        private int[] a; //закрытый одномерный массив

        private int length; //закрытая длина

        public delegate void EventDelegate(string message);

        public static EventDelegate Notify;

        public int Length //свойство Длина массива
        {
            get => length;

            set
            {
                length = value;
            }
        }

        public IntArray(int length) //конструктор 1 для создания массива заданной длины length
        {
            Length = length;
            a = new int[length];
        }

        public IntArray(params int[] array) //конструктор 2 с переменным числом параметров
        {
            Length = array.Length;
            a = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                a[i] = array[i];
            }
        }

        public int this[int i] // Индексатор
        {
            get
            {
                if (i < a.Length) {
                    return a[i];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (i < a.Length)
                {
                    a[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public static IntArray RandomIntArray(int length, int a, int b)
        {
            try
            {
                IntArray arr = new IntArray(length);

                var rand = new Random();
                for (int i = 0; i < length; i++)
                {
                    arr[i] = rand.Next(a, b + 1);
                }
                Notify?.Invoke("Создание массива длины length и заполнение его случайными целыми числами в диапазоне от a до b");
                return arr;
            }
            catch
            {
                IntArray arr = new IntArray(length);
                return arr;
            }
        }

        public static IntArray ArrayFromTextFile(string fileName)
        {
            try
            {
                List<int> list = new List<int>();
                int i = 0;
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        list.Add(Convert.ToInt32(line));
                        i++;
                    }
                }
                IntArray arr = new IntArray(list.Count);
                for (int j = 0; j < list.Count; j++)
                {
                    arr[j] = Convert.ToInt32(list[j]);
                }
                Notify?.Invoke("Создание массива из текстового файла с именем " + fileName);
                return arr;
            }
            catch
            {
                throw new FileNotFoundException();
            }
        }

        public static void ArrayToTextFile(IntArray arr, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        sw.WriteLine(arr[i]);
                    }
                }
                Notify?.Invoke("Вывод массива в текстовый файл с именем " + fileName);
            }
            catch
            {
                throw new DirectoryNotFoundException();
            }
        }

        public static int SumArray(IntArray arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Notify?.Invoke("Вычисление суммы элементов массива");
            return sum;
        }

        public static IntArray operator ++(IntArray arr)
        {
            IntArray arrResult = arr;
            for (int i = 0; i < arr.Length; i++)
            {
                arrResult[i] += 1;
            }
            Notify?.Invoke("Инкремент: увеличение на 1 всех элементов массива");
            return arrResult;
        }

        public static IntArray operator +(IntArray x, int y)
        {
            IntArray arrResult = x;
            for (int i = 0; i < x.Length; i++)
            {
                arrResult[i] += y;
            }
            Notify?.Invoke("Сложение массива со скаляром");
            return arrResult;
        }

        public static int operator +(int x, IntArray y)
        {
            int z = x;
            for (int i = 0; i < y.Length; i++)
            {
                z += y[i];
            }
            Notify?.Invoke("Сложение скаляра с массивом");
            return z;
        }

        public static IntArray operator +(IntArray x, IntArray y)
        {
            if (x.Length != y.Length)
            {
                throw new Exception("the lengths of the arrays are not equal");
            }
            IntArray z = new IntArray(x.Length);
            for (int i = 0; i < y.Length; i++)
            {
                z[i] = x[i] + y[i];
            }
            Notify?.Invoke("Сложение двух массивов");
            return z;
        }

        public static IntArray operator --(IntArray arr)
        {
            IntArray arrResult = arr;
            for (int i = 0; i < arr.Length; i++)
            {
                arrResult[i] -= 1;
            }
            Notify?.Invoke("Декремент: уменьшение на 1 всех элементов массива");
            return arrResult;
        }

        public static IntArray operator -(IntArray x, int y)
        {
            IntArray arrResult = x;
            for (int i = 0; i < x.Length; i++)
            {
                arrResult[i] -= y;
            }
            Notify?.Invoke("Вычитание из массива скаляра");
            return arrResult;
        }

        public static int operator -(int x, IntArray y)
        {
            int z = x;
            for (int i = 0; i < y.Length; i++)
            {
                z -= y[i];
            }
            Notify?.Invoke("Вычитание из скаляра массива");
            return z;
        }

        public static IntArray operator -(IntArray x, IntArray y)
        {
            if (x.Length != y.Length)
            {
                throw new Exception("the lengths of the arrays are not equal");
            }
            IntArray z = new IntArray(x.Length);
            for (int i = 0; i < y.Length; i++)
            {
                z[i] = x[i] - y[i];
            }
            Notify?.Invoke("Вычитание из одного массива другого");
            return z;
        }

        public static IntArray Sort6(IntArray arr)
        {
            IntArray arrResult = arr;
            for (int i = 0; i < arrResult.Length; i++)
            {
                for (int j = 0; j < arrResult.Length - 1; j++)
                {
                    if (arrResult[j] < arrResult[j + 1])
                    {
                        int t = arrResult[j + 1];
                        arrResult[j + 1] = arrResult[j];
                        arrResult[j] = t;
                    }
                }
            }
            IntArray sort = arrResult;
            int k = 0;
            for (int i = 0; i < arrResult.Length - k; i++)
            {
                if (arrResult[i] == 0)
                {
                    for (int j = i; j < arrResult.Length - 1; j++)
                    {
                        sort[j] = arrResult[j + 1];
                    }
                    i--;
                    k++;
                }
            }
            for (int j = arrResult.Length - 1; j >= arrResult.Length - k; j--)
            {
                sort[j] = 0;
            }
            Notify?.Invoke("Перестройка массива таким образом, чтобы в нём сначала шли\nположительные значения, затем отрицательные, а в конце - нули.");
            return sort;
        }
    }
}

