using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PrimesCalculator
{
    public partial class PrimesCalculatorForm : Form
    {
        private ObservableCollection<int> primesCollection = new ObservableCollection<int>();
        private readonly Calculator primesCalculator = new Calculator();
        private readonly CancellationTokenSource cancellationTokenSource= new CancellationTokenSource();
        
        public PrimesCalculatorForm()
        {
            InitializeComponent();
        }

        private async void calculate_button_Click(object sender, EventArgs e)
        {
            int first, last = 0;
            var tokenSource = cancellationTokenSource.Token;

            bool isOk = int.TryParse(first_txtBox.Text, out first) &&
                        int.TryParse(last_textBox.Text, out last) &&
                        first > -1 && last > -1 && first != last && first < last;
            if (!isOk)
            {
                MessageBox.Show("Please enter only positive numbers, when first and last not the same number!!!");
            }
            else
            {
                primesCollection.Clear();
                result.Items.Clear();
                calculate_button.Enabled = false;
                result.Items.Add("Calculating . . .");
                await PrimesCalc(first, last, tokenSource.WaitHandle);
                calculate_button.Enabled = true;
            }
        }

        private async Task PrimesCalc(int first, int last, WaitHandle waitHandle)
        {
            var result = await primesCalculator.AsyncCalc(first, last, waitHandle);
            primesCollection = new ObservableCollection<int>(result);
            UpdateCollection(primesCollection);
            count_label.Text = "Count:" + primesCollection.Count;
            if (!string.IsNullOrEmpty(outputFile_textBox.Text))
            {
                WriteResultToAFile(outputFile_textBox.Text, primesCollection.Count);
            }
        }

        private void WriteResultToAFile(string filePath, int count)
        {
            using (var writer = File.AppendText(filePath + ".txt"))
            {
                writer.WriteLine("There are "+ count +" prime numbers in the current range");
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            if (!cancellationTokenSource.IsCancellationRequested && cancellationTokenSource != null)
            {
                var token = cancellationTokenSource.Token;
                cancellationTokenSource.Cancel();

                token.Register(() =>
                {
                    MessageBox.Show("The action was canceled!");
                });
            }
        }

        private void UpdateCollection(IEnumerable<int> list)
        {
            result.Items.Clear();
            result.BeginUpdate();
            foreach (int i in list)
            {
                result.Items.Add(i);
            }
            result.EndUpdate();
            calculate_button.Enabled = true;
        }

        private void result_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void first_txtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void last_textBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
