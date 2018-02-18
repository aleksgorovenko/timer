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
using СTIMER;

namespace timer
{
    public partial class Form1 : Form
    {

        CTimer[] all = new CTimer[128];
        int all_i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        int check(string st)//проверка наличия таймера в списке
        {
            int i = 0, count = 0;
            while ((i < all_i))
            {
                if (String.Compare(all[i].get_name(), st) == 0) count++;
                i++;
            }
            return count;
        }

        private void button1_Click(object sender, EventArgs e)//Запуск таймера 
        {
            timer1.Start();            
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)//Сохранение списка таймеров в xml файле
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = "c:\\";
            save.Filter = "xml files (*.xml)|*.xml";
            save.ShowDialog();
            string file_name = save.FileName;
            XmlWriterSettings sett = new XmlWriterSettings();
            sett.Indent = true;
            sett.IndentChars = " ";
            sett.NewLineChars = "\n";

            XmlWriter output = XmlWriter.Create(file_name, sett);

            output.WriteStartElement("Timers");
            for (int i = 0; i < all_i; i++)
            {
                output.WriteStartElement("Timer");
                output.WriteElementString("Name", all[i].get_name());
                output.WriteElementString("Time", all[i].get_sought().ToString("dd/HH/mm/ss"));
                output.WriteEndElement();
            }
            output.WriteEndElement();
            output.Flush();
            output.Close();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)//Загрузка списка таймеров из xml файла
        {
            timer1.Stop();
            label1.Text = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C://";
            dialog.Filter = "xml files (*.xml)|*.xml";
            dialog.ShowDialog();
            String file_name = dialog.FileName;

            XmlDocument load = new XmlDocument();

            load.Load(file_name);

            foreach(XmlNode Timer in load.DocumentElement.ChildNodes)
            {
                for (int i = 0; i < Timer.ChildNodes.Count; i++)
                {
                    string name = null;
                    string time = null;
                    if (String.Compare(Timer.ChildNodes.Item(i).Name, "Name") == 0)
                    {
                        name = Timer.ChildNodes.Item(i).InnerText;
                        i++;
                    }
                    if (String.Compare(Timer.ChildNodes.Item(i).Name, "Time") == 0)
                        time = Timer.ChildNodes.Item(i).InnerText;
                    if ((name != null) && (time != null))
                    {
                        if (check(name) == 0)
                        {
                            all[all_i] = new CTimer(name, time);
                            all_i++;
                        }
                    }
                }
            }
            comboBox1.Items.Clear();
            for (int i = 0; i < all_i; i++)
                comboBox1.Items.Add(all[i].get_name());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//Выбор таймера из списка 
        {
            textBox2.Text = comboBox1.Text;
            int i = 0;
            while (String.Compare(comboBox1.Text, all[i].get_name()) != 0)
                i++;
            dateTimePicker1.Value = all[i].get_sought();
        }

        private void timer1_Tick(object sender, EventArgs e)//Отображение оставшегося времени до окончания таймера
        {
            timer1.Interval = 1;
            DateTime current = DateTime.Now;
            TimeSpan timer = new TimeSpan();
            all[all_i] = new CTimer(textBox2.Text, dateTimePicker1.Value);
            timer = all[all_i].get_sought().Subtract(current);
            label1.Text = timer.ToString(@"dd\.hh\:mm\:ss");

            if (check(all[all_i].get_name()) == 0)
            {
                comboBox1.Items.Add(all[all_i].get_name());
                all_i++;
            }
        }

        private void Stop_Click(object sender, EventArgs e)//Останвка отсчета таймера
        {
            timer1.Stop();
            label1.Hide();
        }
    }
}