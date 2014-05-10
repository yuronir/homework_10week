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

namespace IOTest
{
    public partial class Form1 : Form
    {
        string fullpath = "";

        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.FileName = "CheckCheck";
            saveFileDialog1.DefaultExt = "txt";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "OPEN FILE";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fullpath = openFileDialog1.FileName;

                StreamReader r = new StreamReader(fullpath, Encoding.GetEncoding("euc-kr"));

                while (!r.EndOfStream)
                {
                    textBox1.Text += r.ReadLine() + "\r\n";
                }

                r.Close();

                toolStripStatusLabel1.Text = "로딩 완료! 현재 연 파일 : " + fullpath;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fullpath = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(fullpath, false, Encoding.GetEncoding("euc-kr")); //append true:내용추가, false:덮어쓰기

                sw.Write(textBox1.Text);

                sw.Close();

                toolStripStatusLabel1.Text = "저장 완료! 저장된 경로 : " + fullpath;
            }
        }
    }
}
