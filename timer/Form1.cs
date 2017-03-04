using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIMER;

namespace timer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            CTimer abc = new CTimer(textBox2.Text, textBox1.Text);
            DateTime current = DateTime.UtcNow;
            TimeSpan timer = abc.get_sought().Subtract(current);
            //MessageBox.Show(timer.ToString(""), "Time left", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            label4.Text = timer.ToString("");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //Создание объекта типа Диалог Выбора Файла
            dialog.InitialDirectory = "C://";
            //Стартовая директория
            //Создание фильтра для файлов. до символа | указывается отображаемый в меню текст, после, формат файлов которые будут отображены в окне диалога
            dialog.Filter = "xml files (*.xml)|*.xml";
            dialog.ShowDialog();
            //Вызов диалога выбора файла
            String file_name = dialog.FileName;
            //Получение выбранного имени файла

            /*XmlDocument load = new XmlDocument;

            load.Load(file_name);

            foreach(XmlNode Timer_name in load.DocumentElement.ChildNodes)
            {

            }*/
        }
    }
}
