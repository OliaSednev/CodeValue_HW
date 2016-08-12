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

namespace PrimesCalculator
{
    public partial class PrimesCalculatorForm : Form
    {
        private ObservableCollection<int> primesCollection = new ObservableCollection<int>();
        private Calculator primesCalculator = new Calculator();
        private CancellationTokenSource cancellationTokenSource;
        private SynchronizationContext synchronizationContext = SynchronizationContext.Current;
        
        public PrimesCalculatorForm()
        {
            InitializeComponent();
        }        
        
        private void calculate_button_Click(object sender, EventArgs e)
        {
            primesCollection.Clear();
            result.Items.Clear();
            result.Items.Add("Calculating . . .");
            calculate_button.Enabled = false;

            int first, last=0;
            cancellationTokenSource = new CancellationTokenSource();
            var tokenSource = cancellationTokenSource.Token;
            
            bool isOk = int.TryParse(first_txtBox.Text, out first) &&
                int.TryParse(last_textBox.Text, out last) &&
                first > -1 && last > -1;
            if (!isOk)
            {
                MessageBox.Show("Please enter only positive numbers!!!");
            }

            else
            {
                Task.Run(() =>
                {
                    var p = primesCalculator.PrimesCalculator(first, last, tokenSource.WaitHandle);
                    primesCollection = new ObservableCollection<int>(p);

                    UpdateCollection(primesCollection);

                }, tokenSource);
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
