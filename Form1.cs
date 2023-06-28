using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace WFA_pr4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Mass<double> mass11 = new Mass<double>();
        public double[] mass1;

        Mass<int> mass22 = new Mass<int>();
        public int[] mass2;

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (domainValues.SelectedIndex == 0)
            {
                
                tbMass.Clear();
                if (tbLower.Text.Length != 0 && tbUpper.Text.Length != 0)
                {
                    if (Convert.ToDouble(tbLower.Text) > Convert.ToDouble(tbUpper.Text))
                        MessageBox.Show("Левая граница должна быть меньше правой", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else 
                    {
                        mass1 = mass11.CreateArrayDouble(mass1, Convert.ToDouble(tbLower.Text), Convert.ToDouble(tbUpper.Text));
                        for (int i = 0; i < 13; i++)
                        {
                            if (i == 12) tbMass.Text += Math.Round(mass1[i], 3).ToString();
                            else tbMass.Text += Math.Round(mass1[i], 3).ToString() + "\n";
                        }
                    }
                }
                else MessageBox.Show("Заполните границы значений","Предупреждение",MessageBoxButtons.OK,MessageBoxIcon.Warning);


                
            }
            else if (domainValues.SelectedIndex == 1)
            {
                tbMass.Clear();
                if (tbLower.Text.Length != 0 && tbUpper.Text.Length != 0)
                {
                    if (Convert.ToDouble(tbLower.Text) > Convert.ToDouble(tbUpper.Text))
                        MessageBox.Show("Левая граница должна быть меньше правой", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        mass2 = mass22.CreateArray(mass2, Convert.ToInt32(tbLower.Text), Convert.ToInt32(tbUpper.Text));
                        for (int i = 0; i < 13; i++)
                        {
                            if (i == 12) tbMass.Text += mass2[i].ToString();
                            else tbMass.Text += mass2[i].ToString() + "\n";
                        }
                    }
                }
                else MessageBox.Show("Заполните границы значений", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Выберите какого типа значения должны быть в массиве", "Предупреждение",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if(tbMass.Text.Length == 0) MessageBox.Show("Создайте массив","Предупреждение",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (domainValues.SelectedIndex == 0)
                {
                    tbMass.Clear();
                    mass11.SortByChoise(mass1);
                    for (int i = 0; i < 13; i++)
                    {
                        if (i == 12) tbMass.Text += Math.Round(mass1[i], 3).ToString();
                        else tbMass.Text += Math.Round(mass1[i], 3).ToString() + "\n";
                    }
                }
                else if (domainValues.SelectedIndex == 1)
                {
                    tbMass.Clear();
                    mass22.SortByChoise(mass2);
                    for (int i = 0; i < 13; i++)
                    {
                        if (i == 12) tbMass.Text += mass2[i].ToString();
                        else tbMass.Text += mass2[i].ToString() + "\n";
                    }
                }
                
            }
        }
        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (tbMass.Text.Length == 0) MessageBox.Show("Создайте массив", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (domainValues.SelectedIndex == 0)
                {
                    tbMass.Clear();
                    mass11.MergeSort(mass1);
                    for (int i = 0; i < 13; i++)
                    {
                        if (i == 12) tbMass.Text += Math.Round(mass1[i], 3).ToString();
                        else tbMass.Text += Math.Round(mass1[i], 3).ToString() + "\n";
                    }
                }
                else if (domainValues.SelectedIndex == 1)
                {
                    tbMass.Clear();
                    mass22.MergeSort(mass2);
                    for (int i = 0; i < 13; i++)
                    {
                        if (i == 12) tbMass.Text += mass2[i].ToString();
                        else tbMass.Text += mass2[i].ToString() + "\n";
                    }
                }
            }
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 45 && number != 44) // цифры, клавиша BackSpace и минус
            {
                e.Handled = true;
            }
        }
    }
}
