using DataManipulator;
using System;
using System.Windows.Forms;

namespace DataVisualizer
{
    public partial class Form1 : Form
    {
        private DelimitedHandler DelimitedHandler;
        private FormBase _CurrentForm;

        public Form1()
        {
            InitializeComponent();
            buttonPreview.Click += ButtonPreview_Click;
            buttonVisualize.Click += ButtonVisualize_Click;

            DelimitedHandler = new DelimitedHandler("C:\\Binance\\result-transformed-gmt5.csv");

            ReadFile();
        }

        private void ReadFile() => DelimitedHandler.ReadFile();

        private void ButtonVisualize_Click(object sender, EventArgs e)
        {
            try
            {
                _CurrentForm?.Dispose();
                _CurrentForm = new EchartsForm(DelimitedHandler);
                _CurrentForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonPreview_Click(object sender, EventArgs e)
        {
            try
            {
                _CurrentForm?.Dispose();
                _CurrentForm = new GridViewForm(DelimitedHandler);
                _CurrentForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
