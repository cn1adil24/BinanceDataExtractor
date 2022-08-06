using DataManipulator;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DataVisualizer
{
    public partial class GridViewForm : FormBase
    {
        private DataSet _Dataset;

        public GridViewForm(DelimitedHandler delimitedHandler) : base(delimitedHandler)
        {
            InitializeComponent();
            DelimitedHandler = delimitedHandler;

            LoadDataTable();
            Preview();
        }

        protected override void ApplyChanges()
        {
            dataGridView1.DataSource = null;
            Preview();
        }

        private void LoadDataTable()
        {
            _Dataset = DelimitedHandler.GetDataSet();
        }

        public void Preview()
        {
            try
            {
                BindDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            void BindDataSource()
            {
                dataGridView1.DataSource = GetRows(_Dataset).CopyToDataTable();
            }
        }

        private System.Collections.Generic.IEnumerable<DataRow> GetRows(DataSet dataSet)
        {
            if (ReadLast)
                return dataSet.Tables[0].AsEnumerable().Skip(Math.Max(0, DelimitedHandler.Count - RecordCount));
            else
                return dataSet.Tables[0].AsEnumerable().Take(RecordCount);
        }
    }
}
