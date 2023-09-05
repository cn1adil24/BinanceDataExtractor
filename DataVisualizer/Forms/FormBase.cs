using DataManipulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataVisualizer
{
    public abstract partial class FormBase : Form
    {
        protected DelimitedHandler DelimitedHandler;

        public FormBase(DelimitedHandler delimitedHandler)
        {
            InitializeComponent();

            DelimitedHandler = delimitedHandler;
            buttonApply.Click += ButtonApply_Click;
            numericUpDownRecordCount.ValueChanged += NumericUpDownRecordCount_ValueChanged;
            checkBoxReadBottom.CheckedChanged += CheckBoxReadReverse_CheckedChanged;
        }

        protected int RecordCount => (int)numericUpDownRecordCount.Value;

        protected bool ReadLast => checkBoxReadBottom.Checked;

        protected abstract void ApplyChanges();

        protected IEnumerable<object> GetValues(string columnName)
        {
            if (ReadLast)
                return DelimitedHandler.GetColumnRange(columnName).Skip(Math.Max(0, DelimitedHandler.Count - RecordCount));
            else
                return DelimitedHandler.GetColumnRange(columnName).Take(RecordCount);
        }

        protected void NumericUpDownRecordCount_ValueChanged(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        protected void CheckBoxReadReverse_CheckedChanged(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        protected void ButtonApply_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }
    }
}
