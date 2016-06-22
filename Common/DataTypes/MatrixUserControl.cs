using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace Common
{
    namespace DataTypes
    {
        internal partial class MatrixUserControl : UserControl
        {
            private List<List<object>> _objects = new List<List<object>>();
            private Type _genericType;
            private string _defaultValue;
            private int _lastColumnRightClick;
            private int _lastRowRightClick;
            private bool _dataWasSet = false;
            public MatrixUserControl()
            {
                InitializeComponent();
            }
            public void SetData<T>(string defValue, T[,] arr)
            {
                _defaultValue = defValue;
                //for (int i = 0; i < arr.GetLength(1); i++)
                    //dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                _genericType = typeof(T);
                _objects = new List<List<object>>();
                //dataGridView1.Rows.Add(arr.GetLength(0));                
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    _objects.Add(new List<object>());
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        //dataGridView1[j, i].Value = arr[i, j].ToString();
                        //dataGridView1[j, i].ContextMenuStrip = contextMenuStrip1;
                        _objects[i].Add(arr[i, j]);
                    }
                }
                dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
                _dataWasSet = true;
                refreshDataGrid();
            }

            #region Change data event
            public class ChangeDataEventArgs
            {
                private object[,] arr;
                public object[,] Data
                { get { return arr; } set { arr = value; } }
                public ChangeDataEventArgs(object[,] arrr)
                {
                    arr = arrr;
                }
            }
            public delegate void ChangeDataDelegate(object sender, ChangeDataEventArgs e);
            public event ChangeDataDelegate ChangeDataEvent;
            private void OnChangeData()
            {
                if (ChangeDataEvent != null)
                {
                    object[,] objects = new object[_objects.Count, _objects[0].Count];
                    for (int i = 0; i < _objects.Count; i++)
                    {
                        for (int j = 0; j < _objects[0].Count; j++)
                        {
                            objects[i, j] = _objects[i][j];
                        }
                    }
                    ChangeDataEvent(this, new ChangeDataEventArgs(objects));
                }
            }
            #endregion
            void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.Button != MouseButtons.Right) return;
                _lastColumnRightClick = e.ColumnIndex;
                _lastRowRightClick = e.RowIndex;
                contextMenuStrip1.Items[0].Text = string.Format("({0};{1})", e.RowIndex, e.ColumnIndex);
             //   contextMenuStrip1.Show(e.Location);
            }

            private void button1_Click(object sender, EventArgs e)
            {
                OnChangeData();
            }

            private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                if (!_dataWasSet) return;
                object[] args = new object[1];
                args[0] = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();

                object returnValue = _defaultValue;
                try
                {
                    returnValue = _genericType.InvokeMember("Parse", System.Reflection.BindingFlags.InvokeMethod,
                          null, _objects[0][0], args);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Неможливо пропарсити данні. Можливо ви не правильно ввели данні в поле. {0}", ex.Message));
                    refreshDataGrid();
                    return;
                }
                _objects[e.ColumnIndex][e.RowIndex] = returnValue;
            }

            private void addColumnToolStripMenuItem_Click(object sender, EventArgs e)
            {

                List<object> list = new List<object>();
                for (int i = 0; i < _objects[0].Count; i++) list.Add(_defaultValue);
                _objects.Insert(_lastColumnRightClick, list);
                
                refreshDataGrid();
                _lastColumnRightClick++;
            }

            private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
            {
                for (int i = 0; i < _objects.Count; i++)
                {
                    _objects[i].Insert(_lastRowRightClick, _defaultValue);
                }
                refreshDataGrid();
                _lastRowRightClick++;
            }

            private void rowвлівоToolStripMenuItem_Click(object sender, EventArgs e)
            {
                // _row up
                // _row - 1 down
                if (_lastRowRightClick == 0) return;
                for (int i = 0; i < _objects.Count; i++)
                {
                    object to = _objects[i][_lastRowRightClick];
                    _objects[i][_lastRowRightClick] = _objects[i][_lastRowRightClick - 1];
                    _objects[i][_lastRowRightClick - 1] = to;
                }

                _lastRowRightClick--;
                refreshDataGrid();
                
            }

            private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
            {
                refreshDataGrid();
            }

            private void rebindContextStrip()
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        dataGridView1[j, i].ContextMenuStrip = contextMenuStrip1;
                    }
                }
                
            }
            private const int _maxRowsOrColumns = 15;
            private void refreshDataGrid()
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                if ((_objects.Count > _maxRowsOrColumns) ||
                    (_objects[0].Count > _maxRowsOrColumns))
                {
                    label1.Visible = true;
                    return;
                }
                else
                    label1.Visible = false;
                for (int i = 0; i < _objects.Count; i++)
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                dataGridView1.Rows.Add(_objects[0].Count);
                for (int i = 0; i < _objects.Count; i++)
                {
                    for (int j = 0; j < _objects[i].Count; j++)
                    {
                        dataGridView1[i, j].Value = _objects[i][j].ToString();
                    }
                }
                rebindContextStrip();
                try
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[_lastRowRightClick].Cells[_lastColumnRightClick].Selected = true;
                    
                }
                catch
                {
                }
            }

            private void очиститиВсеToolStripMenuItem_Click(object sender, EventArgs e)
            {
                _objects.Clear();

                List<object> list = new List<object>();
                list.Add(_defaultValue);
                _objects.Add(list);

                _lastColumnRightClick = 0;
                _lastRowRightClick = 0;
                refreshDataGrid();
            }

            private void columnвлівоToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                if (_lastColumnRightClick == 0) return;
                List<object> listo = listo = _objects[_lastColumnRightClick];
                _objects[_lastColumnRightClick] = _objects[_lastColumnRightClick - 1];
                _objects[_lastColumnRightClick - 1] = listo;
                _lastColumnRightClick--;
                refreshDataGrid();
            }

            private void columnвправоToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                if (_lastColumnRightClick == _objects.Count - 1) return;
                List<object> listo = listo = _objects[_lastColumnRightClick + 1];
                _objects[_lastColumnRightClick + 1] = _objects[_lastColumnRightClick];
                _objects[_lastColumnRightClick] = listo;
                _lastColumnRightClick++;
                refreshDataGrid();
            }

            private void acceptToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (_objects.Count == 1) return;

                _objects.RemoveAt(_lastColumnRightClick);
                _lastColumnRightClick--;
                refreshDataGrid();
            }

            private void видалитиРядокToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (_objects[0].Count == 1) return;

                for (int i = 0; i < _objects.Count; i++)
                {
                    _objects[i].RemoveAt(_lastRowRightClick);
                }
                _lastRowRightClick--;
                refreshDataGrid();
            }

            private void rowвнизToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (_lastRowRightClick == _objects[0].Count - 1) return;
                for (int i = 0; i < _objects.Count; i++)
                {
                    object to = _objects[i][_lastRowRightClick + 1];
                    _objects[i][_lastRowRightClick + 1] = _objects[i][_lastRowRightClick];
                    _objects[i][_lastRowRightClick] = to;
                }

                _lastRowRightClick++;
                refreshDataGrid();
            }

            private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                object value = dataGridView1[e.ColumnIndex, e.RowIndex];
            }

        }
    }
}