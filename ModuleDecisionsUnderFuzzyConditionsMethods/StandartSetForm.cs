using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FuzzySets;
using Common;
using Modules.DecisionsUnderFuzzyConditionsMethods.Properties;

namespace Modules.DecisionsUnderFuzzyConditionsMethods
{
    public partial class StandartSetForm : Form
    {
        public StandartSetForm()
        {
            InitializeComponent();
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.ValueType = typeof(string);
                col.ReadOnly = true;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgwMain.Columns.Add(col);
            }
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.ValueType = typeof(double);
                col.ReadOnly = false;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgwMain.Columns.Add(col);
            }
        }
        static StandartSet sType;
        private static FuzzySet1D res;
        public static FuzzySet1D GetSet(StandartSet setType)
        {
            sType = setType;
            StandartSetForm form = new StandartSetForm();
            switch (setType)
            {
                case StandartSet.NormalDistribution:
                    #region Нормальное распределение
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(string);
                            cell.Value = "m";
                            cell.Style.Font = new Font("Symbol", 10.0f, FontStyle.Bold);
                            cell.Style.BackColor = SystemColors.Info;
                            row.Cells.Add(cell);
                        }
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(double);
                            cell.Value = 0.0;
                            cell.Style.Font = new Font("Courier New", 10.0f);
                            row.Cells.Add(cell);
                        }
                        form.dgwMain.Rows.Add(row);
                    }
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(string);
                            cell.Value = "s";
                            cell.Style.BackColor = SystemColors.Info;
                            cell.Style.Font = new Font("Symbol", 10.0f, FontStyle.Bold);
                            row.Cells.Add(cell);
                        }
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(double);
                            cell.Value = 1.0;
                            cell.Style.Font = new Font("Courier New", 10.0f);
                            row.Cells.Add(cell);
                        }
                        form.dgwMain.Rows.Add(row);
                    }
                    form.pbExample.Image = Resources.normaD1;
                    #endregion
                    form.lblCaption.Text = "Нормальний розподіл";
                    break;
                case StandartSet.Triangle:
                    #region  Треугольник
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(string);
                            cell.Value = "d";
                            cell.Style.Font = new Font("Arial", 10.0f, FontStyle.Bold);
                            cell.Style.BackColor = SystemColors.Info;
                            row.Cells.Add(cell);
                        }
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(double);
                            cell.Value = 5.0;
                            cell.Style.Font = new Font("Courier New", 10.0f);
                            row.Cells.Add(cell);
                        }
                        form.dgwMain.Rows.Add(row);
                    }
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(string);
                            cell.Value = "s";
                            cell.Style.BackColor = SystemColors.Info;
                            cell.Style.Font = new Font("Arial", 10.0f, FontStyle.Bold);
                            row.Cells.Add(cell);
                        }
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(double);
                            cell.Value = 3.0;
                            cell.Style.Font = new Font("Courier New", 10.0f);
                            row.Cells.Add(cell);
                        }
                        form.dgwMain.Rows.Add(row);
                    }
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(string);
                            cell.Value = "h";
                            cell.Style.BackColor = SystemColors.Info;
                            cell.Style.Font = new Font("Arial", 10.0f, FontStyle.Bold);
                            row.Cells.Add(cell);
                        }
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(double);
                            cell.Value = 1.0;
                            cell.Style.Font = new Font("Courier New", 10.0f);
                            row.Cells.Add(cell);
                        }
                        form.dgwMain.Rows.Add(row);
                    }
                    form.pbExample.Image = Resources.tr;
                    #endregion
                    form.lblCaption.Text = "Трикутна множина";
                    break;
                case StandartSet.Trapeze:
                    #region  Трапеция
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(string);
                            cell.Value = "d";
                            cell.Style.Font = new Font("Arial", 10.0f, FontStyle.Bold);
                            cell.Style.BackColor = SystemColors.Info;
                            row.Cells.Add(cell);
                        }
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(double);
                            cell.Value = 5.0;
                            cell.Style.Font = new Font("Courier New", 10.0f);
                            row.Cells.Add(cell);
                        }
                        form.dgwMain.Rows.Add(row);
                    }
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(string);
                            cell.Value = "s";
                            cell.Style.BackColor = SystemColors.Info;
                            cell.Style.Font = new Font("Arial", 10.0f, FontStyle.Bold);
                            row.Cells.Add(cell);
                        }
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(double);
                            cell.Value = 3.0;
                            cell.Style.Font = new Font("Courier New", 10.0f);
                            row.Cells.Add(cell);
                        }
                        form.dgwMain.Rows.Add(row);
                    }
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(string);
                            cell.Value = "h";
                            cell.Style.BackColor = SystemColors.Info;
                            cell.Style.Font = new Font("Arial", 10.0f, FontStyle.Bold);
                            row.Cells.Add(cell);
                        }
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(double);
                            cell.Value = 1.0;
                            cell.Style.Font = new Font("Courier New", 10.0f);
                            row.Cells.Add(cell);
                        }
                        form.dgwMain.Rows.Add(row);
                    }
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(string);
                            cell.Value = "H";
                            cell.Style.BackColor = SystemColors.Info;
                            cell.Style.Font = new Font("Arial", 10.0f, FontStyle.Bold);
                            row.Cells.Add(cell);
                        }
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.ValueType = typeof(double);
                            cell.Value = 1.0;
                            cell.Style.Font = new Font("Courier New", 10.0f);
                            row.Cells.Add(cell);
                        }
                        form.dgwMain.Rows.Add(row);
                    }
                    form.pbExample.Image = Resources.tra;
                    #endregion
                    form.lblCaption.Text = "Трапецієподібна множина";
                    break;
            }
            form.ShowDialog();
            return res;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            res = null;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            switch (sType)
            {
                case StandartSet.NormalDistribution:
                    res = FuzzySet1D.CreateNormalDistribution((double)dgwMain.Rows[0].Cells[1].Value,
                (double)dgwMain.Rows[1].Cells[1].Value);
                    break;
                case StandartSet.Triangle:
                    res = FuzzySet1D.CreateTriangle(
                        (double)dgwMain.Rows[0].Cells[1].Value,
                (double)dgwMain.Rows[1].Cells[1].Value,
                (double)dgwMain.Rows[2].Cells[1].Value);
                    break;
                case StandartSet.Trapeze:
                    res = FuzzySet1D.CreateTrapeze(
                        (double)dgwMain.Rows[0].Cells[1].Value,
                (double)dgwMain.Rows[1].Cells[1].Value,
                (double)dgwMain.Rows[2].Cells[1].Value,
                (double)dgwMain.Rows[3].Cells[1].Value);
                    break;
            }
            Close();
        }
    }
}