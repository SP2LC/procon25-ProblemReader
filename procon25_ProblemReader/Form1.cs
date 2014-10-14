using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace procon25_ProblemReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp;
            int x=-1;
            int y = -1;
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            string fn = openFileDialog1.FileName;
            textBox1.Text = fn;
            if (File.Exists(fn))
            {
                XmlTextReader reader = null;
                try
                {
                    reader = new XmlTextReader(fn);
                    //ストリームからノードを読み取る
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            switch (reader.LocalName)
                            {
                                case "Height":
                                    label1.Text += reader.ReadString() ;
                                    break;
                                case "Width":
                                    label2.Text += reader.ReadString();
                                    break;
                                case "SwapCost":
                                    label3.Text += reader.ReadString();
                                    break;
                                case "SelectCost":
                                    label4.Text += reader.ReadString();
                                    break;
                                case "Maxval":
                                    label5.Text += reader.ReadString();
                                    break;
                                case "MaxSelections":
                                    label6.Text += reader.ReadString();
                                    break;
                                case "X":
                                    temp = int.Parse(reader.ReadString());
                                    if (x <= temp) x = temp;
                                    break;
                                case "Y":
                                    temp = int.Parse(reader.ReadString());
                                    if (y <= temp) y = temp;
                                    break;
                            }
                        }
                    }

                    label7.Text += (y+1);
                    label8.Text += (x+1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    reader.Close();
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
