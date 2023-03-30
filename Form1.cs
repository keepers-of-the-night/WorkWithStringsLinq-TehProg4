using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TehProg4
{
    public partial class Form1 : Form
    {
        List<string> s = new List<string>() { "C:\\Windows", "C:\\Program Files", "C:\\Program Files (x86)/Autodesk/Autodesk Desktop App", "D:\\Student" }; 
        List<string> extention = new List<string>() { ".exlm", ".exlx" };
        int k = 1;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < s.Count; i++)
            {
                listBox1.Items.Add(s[i]); // заполняю listBox1 путями к папке
            }
            for (int i = 0; i < extention.Count; i++)
            {
                listBox3.Items.Add(extention[i]); // заполняю listBox3 расширениями
            }
        }

        private void button3_Click(object sender, EventArgs e) // Найти
        {
            int lb1 = listBox1.Items.Count, ls = s.Count, le = extention.Count, lb2 = listBox2.Items.Count;
            for (int i = 0; i < lb1; i++)
            {
                if (ls > i) //если длинна строки меньше длинны listBox'а
                    s[i] = Convert.ToString(listBox1.Items[i]);
                else
                    s.Add(Convert.ToString(listBox1.Items[i]));
            }
            for (int i = 0; i < lb2; i++)
            {
                if (le > i) //если длинна строки меньше длинны listBox'а
                    extention[i] = Convert.ToString(listBox3.Items[i]);
                else
                    extention.Add(Convert.ToString(listBox3.Items[i]));
            }
            Search();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=null)
                listBox1.Items.Add(textBox1.Text); // добавляю строку в listBox1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int t = Convert.ToInt32(listBox1.SelectedIndex.ToString());
            if(t!=-1)
                listBox1.Items.RemoveAt(t); // удаляю выбранную строку из listBox1
        }
        private void Search()
        {
            for(int i = 0; i < s.Count; i++)
            {
                string[] allfiles = Directory.GetFiles(s[i]);
                for (int j = 0; j < extention.Count; j++)
                {
                    var needfiles = allfiles.Where(p => p.ToUpper().EndsWith(extention[j])).OrderBy(p => p);
                    foreach (string str in needfiles)
                    {
                        string Str = string.Join(str, k);
                        listBox2.Items.Add(str);
                        k++;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null)
                listBox3.Items.Add(textBox2.Text); // добавляю строку в listBox3
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int t = Convert.ToInt32(listBox3.SelectedIndex.ToString());
            if (t != -1)
                listBox3.Items.RemoveAt(t); // удаляю выбранную строку из listBox1
        }
    }
}
