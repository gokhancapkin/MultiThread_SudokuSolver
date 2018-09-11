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
using System.Threading;

namespace MultiThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] sudokuOrj = new int[9, 9];
        OpenFileDialog file = new OpenFileDialog();
        static Thread thread1 = new Thread(cozum1);
        static Thread thread2 = new Thread(cozum2);
        static Thread thread3 = new Thread(cozum3);
        private void DosyaSec_Click(object sender, EventArgs e)
        {
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            file.Filter = "Txt dosyası | *.txt";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.Title = "Yüklenecek Sudokuyu Seçiniz";

            if (file.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string dosyaYolu = file.FileName;
            FileStream dosya = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(dosya);
            string sudoku = sr.ReadLine();
            int satir = 0, sutun = 0;
            while(sudoku !=null)
            {
                string karakter;
                for( int i = 0; i < 9 ; i++ )
                {
                    karakter = sudoku.Substring(i, 1);
                    if(karakter != "*")
                    {
                        sudokuOrj[satir, sutun] = Convert.ToInt32(sudoku.Substring(i, 1));
                    }
                    else
                    {
                        sudokuOrj[satir, sutun] = -1;
                    }
                    sutun++;
                    
                }
                sudoku = sr.ReadLine();
                sutun = 0;
                satir++;

            }
            ekranaBas();
        }
        private void ekranaBas()
        {
            for(int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.Write("  "+sudokuOrj[j, i]);
                }
                Console.WriteLine("");
            }
                
        }
        static private void cozum1()
        {

        }
        static private void cozum2()
        {

        }
        static private void cozum3()
        {

        }


        
    }
}
