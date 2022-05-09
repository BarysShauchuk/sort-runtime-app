using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sort_runtime_app
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void CreateArray(ref int[] array)
        {
            var rand = new Random();

            for (int ctr = 0; ctr < array.Length; ctr++)
            {
                array[ctr] = rand.Next(-1000, 1000);
            }
        }

        public static void BubleSort(int[] arr)
        {
            for (int i = arr.Length; i > 0; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int k = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = k;
                    }
                }
            }
        }

        public static void InsertionSort(int[] arr)
        {
            int key, j;
            for(int i = 0; i < arr.Length; i++)
            {
                key = arr[i];
                j = i - 1;
                while(j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public static int[] SelectionSort(int[] arr)
        {
            int min_idx;
            for(int i = 0; i < arr.Length - 1; i++)
            {
                min_idx = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min_idx]) min_idx = j;
                }
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }
    }
}
