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

namespace assignment_2
{
    public partial class Form1 : Form
    {
        class row
        {
            public double time;
            public double current;
            public double dcurrent;
            public double charge;
        }
        List<row> table = new List<row>();
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateCurrent()
        {
            for (int i = 1; 1 < table.Count; i++) 
            {
                double dQ = table[i].charge - table[i - 1].charge;
                double dt = table[i].time - table[i - 1].time;
                table[i].current = dQ / dt;
            }
        }

        private void calculateCurrent()
        {
            for (int i = 1; 1 < table.Count; i++)
            {
                double dQ = table[i].charge - table[i - 1].charge;
                double dt = table[i].time - table[i - 1].time;
                table[i].current = dQ / dt;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "CSV Files|*.csv";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        string line = sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            table.Add(new row());
                            string[] r = sr.ReadLine().Split(',');
                            table.Last().time = double.Parse(r[0]);
                            table.Last().charge = double.Parse(r[1]);
                        }
                    }
                    calculateCurrent();
                } 
                catch (IOException)
                {
                    MessageBox.Show(openFileDialog1.FileName + "failed to open.");
                }
                catch (FormatException)
                {
                    MessageBox.Show(openFileDialog1.FileName + "is not in the required format");
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show(openFileDialog1.FileName + "is not in the required format");
                }
                catch
                {
                    MessageBox.Show(openFileDialog1.FileName + "has rows that have the same time");
                }
            }
        }
    }
}







