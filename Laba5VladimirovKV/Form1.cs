using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Laba5VladimirovKV
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBox2.Clear();// освобождаем textBox2
			textBox3.Clear(); // освобождаем textBox3
							  // Создаем объект диалогового окна для открытия файла
			OpenFileDialog ofd = new OpenFileDialog();
			//назначаем заголовок диалогового окна открытия файла
			ofd.Title = "Выберите файл с числовым массивом";
			ofd.InitialDirectory = @"C:\";// начальный путь для поиска файла
										  // Создаем фильтр для отображаемых типов файлов
			ofd.Filter = "txt file (*.txt)|*.txt|all files (*.*)|*.*";
			// открываем окно для сохранения файла командой ofd.ShowDialog() 
			//и проверяем, нажата ли кнопка "Открыть" в этом окне, т.е.достигнут ли результат "ОК"
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				using (StreamReader sr = new StreamReader(ofd.FileName)) //открываем файл для чтения
				{//считываем весь текст из файла и записываем его в textBox2
					textBox2.Text = sr.ReadToEnd();
				}
				textBox6.Text = ofd.FileName;// в textBox6 записываем имя файла
				button3.Enabled = true; // делаем активной кнопку button3
				button4.Enabled = true;
				button5.Enabled = true;
			}

		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox2.Clear(); // освобождаем textBox2
			textBox3.Clear(); // освобождаем textBox3
			int n = CorrectInput(textBox1);// получаем числовое значение из textBox1
			if (n < 1) // проверка допустимости значения, введенного пользователем
			{
				n = 1;
				// замена значения, введенного пользователем в textBox1
				textBox1.Text = String.Format("{0}", n);
			}
			SaveFileDialog sfd = new SaveFileDialog();// Создаем диалоговое окно для открытия файла
			sfd.Title = "Выберите файл для записи массива";//задаем заголовок диалогового окна
			sfd.InitialDirectory = @"C:\";// задаем начальный путь для сохранения файла
										  // Создаем фильтр для отображаемых типов файлов
			sfd.Filter = "txt file (*.txt)|*.txt|all files (*.*)|*.*";
			Random r = new Random(); //создаем объект для работы с псевдослучайными числами

			// открываем окно для сохранения файла командой sfd.ShowDialog() 
			//и проверяем, нажата ли кнопка "Сохранить" в этом окне, т.е.достигнут ли результат "ОК"
			if (sfd.ShowDialog() == DialogResult.OK)
			{// открываем файл для записи (дозапись исключена)
				using (StreamWriter sw = new StreamWriter(sfd.FileName))
				{
					for (int i = 0; i < n - 1; i++) // цикл для записи n-1 числа
						sw.WriteLine(r.Next(-500, 500));  //запись чисел в файл построчно
														  //запись одного числа в файл без символа перехода на новую строку
					sw.Write(r.Next(-500, 500));
				}
			}

		}

		private void button3_Click(object sender, EventArgs e)
		{
			textBox3.Clear(); // освобождаем textBox3
			int min = CorrectInput(textBox4);// получаем числовое значение из textBox4
			int max = CorrectInput(textBox5);// получаем числовое значение из textBox5
			if (min > max)// проверка допустимости значения, введенного пользователем
				textBox3.Text = String.Format("Диапазон задан некорректно");
			else
			{
				int x, k = 0;
				foreach (string line in textBox2.Lines)// цикл по всем строкам в textBox2
				{
					x = Int32.Parse(line); // перевод одной строки line из textBox2 в число х
					if (x >= min && x <= max)
					{// добавление строки, содержащей найденное число, в textBox3
						textBox3.AppendText(line + Environment.NewLine);
						k++;
					}
				}
				if (k == 0) // проверка, найдено ли хоть одно число в указанном диапазоне
					textBox3.Text = String.Format("В массиве нет значений, принадлежащих указанному диапазону");
			}

		}

		private void button4_Click(object sender, EventArgs e)
		{
			int x;
			int CountEvens = 0;
			int CountOdd = 0;
			foreach (string line in textBox2.Lines)// цикл по всем строкам в textBox2
			{
				x = Int32.Parse(line); // перевод одной строки line из textBox2 в число х
				if ((x%2)==0)
				{
					CountEvens++;
				}
				else
				{
					CountOdd++;
				}
			}
			if (CountEvens > CountOdd)
			{
				textBox7.Text = "Больше всего Четных.";
			}
			else if(CountOdd > CountEvens)
			{
				textBox7.Text = "Больше всего Нечетных.";
			}
			else if(CountEvens == CountOdd)
			{
				textBox7.Text = "Чётных и Нечётных одинаковое кол-во.";
			}
			
		}

		private void button5_Click(object sender, EventArgs e)
		{
			int x, Max = Int32.Parse(textBox2.Lines[0]);
			bool EvensCheck = false;
			foreach (string line in textBox2.Lines)// цикл по всем строкам в textBox2
			{
				x = Int32.Parse(line); // перевод одной строки line из textBox2 в число х

				if ((x % 2) == 0)
				{
					Max = x;
					EvensCheck = true;
					break;
				}
			}
			if (EvensCheck)
			{
				foreach (string line in textBox2.Lines)// цикл по всем строкам в textBox2
				{
					x = Int32.Parse(line); // перевод одной строки line из textBox2 в число х

					if ((x % 2) == 0)
					{
						if (x > Max)
							Max = x;
					}
				}
				textBox8.Text = "Наибольшая Чётная - " + Max;
			}
			else
			{
				textBox8.Text = "Чётных нет...";
			}
		}

		static int CorrectInput(TextBox TextBox)
		{

			if (TextBox.Text != "")
			{


				if (IsNum(TextBox.Text))
				{
					int Value;
					Value = Convert.ToInt32(TextBox.Text);

					if (Value < 0) Value = 0;
					TextBox.Text = String.Format("{0}", Value);

					return Value;
				}
				else
				{
					TextBox.Text = "0";
				}
			}

			return 0;
		}

		static bool IsNum(string s) //Проверяем строчку состоит она из цифр или других символов
		{
			foreach (char c in s)
			{
				if (!Char.IsDigit(c)) return false;
			}
			return true;
		}
	}
}
