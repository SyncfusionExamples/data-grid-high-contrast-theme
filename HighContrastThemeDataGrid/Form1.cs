using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Styles;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Collections.ObjectModel;
using System;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;
using System.Drawing;
using System.Globalization;
using Syncfusion.WinForms.Input.Enums;

namespace ThemeDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var data = new EmployeeCollection();
            sfDataGrid.DataSource = data.EmployeeDetails;
            
            //Apply high contrast theme to SfDataGrid.
            this.sfDataGrid.ThemeName = "HighContrastBlackTheme";

            NumberFormatInfo numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.CurrencyDecimalDigits = 0;
            numberFormat.CurrencyGroupSizes = new int[] { };
            numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.NumberDecimalDigits = 0;
            numberFormat.NumberGroupSizes = new int[] { };

            this.sfDataGrid.Columns.Add(new GridCheckBoxColumn { MappingName = "Selected", HeaderText = "", AllowCheckBoxOnHeader = true, CheckBoxSize = new Size(13, 13) });
            this.sfDataGrid.Columns.Add(new GridImageColumn() { MappingName = "EmployeeName", HeaderText = "Employee Name", ImageLayout = ImageLayout.None });
            this.sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Designation", HeaderText = "Designation" });
            this.sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Mail", HeaderText = "Mail" });
            this.sfDataGrid.Columns.Add(new GridImageColumn() { MappingName = "Location", TextImageRelation = TextImageRelation.ImageBeforeText, Width = 100 });
            this.sfDataGrid.Columns.Add(new GridTextColumn { MappingName = "Status", HeaderText = "Status" });
            this.sfDataGrid.Columns.Add(new GridImageColumn() { MappingName = "Trustworthiness", HeaderText = "Trustworthiness" });
            this.sfDataGrid.Columns.Add(new GridNumericColumn { MappingName = "Salary", HeaderText = "Salary", FormatMode = FormatMode.Currency, NumberFormatInfo = numberFormat });
            this.sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Address", HeaderText = "Address" });
            this.sfDataGrid.Columns.Add(new GridProgressBarColumn() { MappingName = "SoftwareProficiency", HeaderText = "Software Proficiency", Maximum = 100, Minimum = 0, ValueMode = ProgressBarValueMode.Percentage });          

            sfDataGrid.QueryImageCellStyle += SfDataGrid_QueryImageCellStyle;
            sfDataGrid.QueryCellStyle += SfDataGrid_QueryCellStyle;

            this.sfDataGrid.SelectionController = new CustomSelectionController(this.sfDataGrid);
        }

        private void SfDataGrid_QueryCellStyle(object sender, QueryCellStyleEventArgs e)
        {
            if (e.Column.MappingName == "Status")
            {
                if (e.DisplayText.ToString() == "Active")
                    e.Style.TextColor = Color.Green;
                else
                    e.Style.TextColor = Color.Red;
            }
        }

        private void SfDataGrid_QueryImageCellStyle(object sender, QueryImageCellStyleEventArgs e)
        {
            var employee = (Employee)e.Record;

            if (e.Column.MappingName == "Trustworthiness")
            {
                if (employee.Trustworthiness.ToString() == "Sufficient")
                {
                    e.Image = (Image.FromFile(@"..\..\Images\Sufficient.png"));
                    e.DisplayText = (e.Record as Employee).Trustworthiness.ToString();
                    e.TextImageRelation = TextImageRelation.ImageBeforeText;
                }
                else if (employee.Trustworthiness.ToString() == "Insufficient")
                {
                    e.Image = (Image.FromFile(@"..\..\Images\Insufficient.png"));
                    e.DisplayText = (e.Record as Employee).Trustworthiness.ToString();
                    e.TextImageRelation = TextImageRelation.ImageBeforeText;
                }
                else if (employee.Trustworthiness.ToString() == "Perfect")
                {
                    e.Image = (Image.FromFile(@"..\..\Images\Perfect.png"));
                    e.DisplayText = (e.Record as Employee).Trustworthiness.ToString();
                    e.TextImageRelation = TextImageRelation.ImageBeforeText;
                }
            }
            else if (e.Column.MappingName == "EmployeeName")
            {
                e.Image = employee.Gender == "1" ? (Image.FromFile(@"..\..\Images\Male.png")) : (Image.FromFile(@"..\..\Images\Female.png"));
                e.DisplayText = (e.Record as Employee).EmployeeName.ToString();
                e.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
            else
            {
                e.Image = (Image.FromFile(@"..\..\Images\location.png"));
                e.DisplayText = (e.Record as Employee).Location.ToString();
                e.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
        }
    }
}