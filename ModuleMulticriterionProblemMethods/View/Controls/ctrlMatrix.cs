using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.DataTypes;
using Common.DataTypes;
using System.Data;
using System.Drawing;
using Modules.MulticriterionProblemMethods.Inerfaces;
using System.Collections;
using Modules.MulticriterionProblemMethods.Workflow.Messaging;
using System.ComponentModel;

namespace Modules.MulticriterionProblemMethods.View.Controls
{
    /// <summary>
    /// КонтроL, що показує матрицю критерії/альтернатив.    
    /// </summary>
    internal class ctrlMatrix : UserControl, IMatrixPresenter
    {
        #region Generated code

        public DataGridView _gridView;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._gridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _gridView
            // 
            this._gridView.AllowUserToAddRows = false;
            this._gridView.AllowUserToResizeRows = false;
            this._gridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this._gridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridView.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "null";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridView.DefaultCellStyle = dataGridViewCellStyle2;
            this._gridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridView.EnableHeadersVisualStyles = false;
            this._gridView.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._gridView.Location = new System.Drawing.Point(0, 0);
            this._gridView.MultiSelect = false;
            this._gridView.Name = "_gridView";
            this._gridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._gridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this._gridView.RowHeadersVisible = false;
            this._gridView.RowHeadersWidth = 20;
            this._gridView.ShowCellErrors = false;
            this._gridView.Size = new System.Drawing.Size(311, 280);
            this._gridView.TabIndex = 0;
            this._gridView.CellValueChanged += this._gridView_CellValueChanged;
            this._gridView.DataError += this._gridView_DataError;
            // 
            // ctrlMatrix
            // 
            this.Controls.Add(this._gridView);
            this.Name = "ctrlMatrix";
            this.Size = new System.Drawing.Size(311, 280);
            ((System.ComponentModel.ISupportInitialize)(this._gridView)).EndInit();
            this.ResumeLayout(false);

        }

        public ctrlMatrix()
        {
            InitializeComponent();
        }

        #endregion

        #region Field & properties

        private const string AlternativeNameColumnName = "AlternativeNameColumnName";
        private string AlternativeNameColumnCaption = Properties.Resources.AlternativeNameColumnCaption; //"Альт.\\Крит.";
        private const string DefaultValue = "0";

        private readonly DataTable _matrixTable = new DataTable();
        private bool _hasFirstColumn = false;
        private bool _readOnly = false;
        /// <summary>
        /// Поведінка тільки-для-читання
        /// </summary>
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                _gridView.ReadOnly = value;
            }
        }
        /// <summary>
        /// Матриця
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Matrix Matrix
        {
            get { return _getMatrix(); }
            set { _setMatrix(value); }
        }
        /// <summary>
        /// Альтернативи
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IEnumerable Alternatives
        {
            get
            {
                ArrayList result = new ArrayList();
                foreach (DataRow row in _matrixTable.Rows)
                    result.Add(row[AlternativeNameColumnName]);
                return result;
            }
        }
        /// <summary>
        /// Критерії
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IEnumerable Criteriums
        {
            get
            {
                ArrayList result = new ArrayList();
                foreach (DataColumn column in _matrixTable.Columns)
                    result.Add(column.Caption);
                return result;
            }
        }

        #endregion

        #region Methods


        /// <summary>
        /// Заливка матриці рендомом
        /// </summary>
        public void RandomFill()
        {
            this.UnhighlightMatrix();
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int x = 1; x < _gridView.ColumnCount; x++)
            {
                for (int y = 0; y < _gridView.RowCount; y++)
                {
                    _gridView[x, y].Value= rand.Next(-99, 100);
                }
            }
        }

        /// <summary>
        /// Перевірка значення "ячейки" на коректність, та його виставлення на значення по замовчуванню, якщо це необхідно
        /// </summary>
        /// <param name="rowIndex">Індекс рядка</param>
        /// <param name="columnIndex">Індекс стовпчика</param>
        /// 

        private void _checkCellValue(int rowIndex, int columnIndex)
        {
            if (columnIndex > 0 && columnIndex < _gridView.ColumnCount && rowIndex < _gridView.RowCount && columnIndex != 0)
            {
                int test;
                DataGridViewCell cell = _gridView[columnIndex, rowIndex];
                if (!int.TryParse(cell.Value.ToString(), out test) || int.Parse(cell.Value.ToString()) < 0)
                    cell.Value = DefaultValue;
            }
        }
        /// <summary>
        /// Генерує першу колоночку
        /// </summary>        
        private DataColumn _generateAlternativeNameColumn()
        {
            DataColumn columnResult = new DataColumn(AlternativeNameColumnName, typeof(string));
            columnResult.Caption = AlternativeNameColumnCaption;
            columnResult.AllowDBNull = false;
            return columnResult;
        }
        /// <summary>
        /// Генерує стовпчики для таблиці, яка повинна буде відображати матрицю
        /// </summary>
        private List<DataColumn> _generateColumns(IEnumerable<Criterium> captions)
        {
            _tryAddLaternativeNameColumn();
            List<DataColumn> result = new List<DataColumn>();
            foreach (Criterium criterium in captions)
            {
                DataColumn toAdd = new DataColumn(criterium.Name, typeof(int));
                toAdd.Caption = criterium.Name;

                result.Add(toAdd);
            }

            return result;
        }
        /// <summary>
        /// Заповнює рядок таблиці
        /// </summary>
        private void _fillRow(DataRow rowToFill, Alternative alternative, IEnumerable<Criterium> criteriums)
        {
            rowToFill[AlternativeNameColumnName] = alternative.Name;

            foreach (Criterium criterium in criteriums)
                rowToFill[criterium.Name] = alternative[criterium.Name];
        }
        /// <summary>
        /// Додає (якщо потрібно) колонку, що відображає ім"я.        
        /// </summary>
        private void _tryAddLaternativeNameColumn()
        {
            if (!_hasFirstColumn)
            {
                // temporary saving columns(for inserting first column)
                DataColumn[] columns = new DataColumn[_matrixTable.Columns.Count];
                _matrixTable.Columns.CopyTo(columns, 0);
                // clearing columns
                _matrixTable.Columns.Clear();
                // adding first column
                _matrixTable.Columns.Add(_generateAlternativeNameColumn());
                // adding saved column
                _matrixTable.Columns.AddRange(columns);
                _hasFirstColumn = true;
            }
        }
        /// <summary>
        /// Виводить дані на грід
        /// </summary>
        private void _showData()
        {
            //достатньо 1 раз присвоїти ссилку
            _gridView.DataSource = _matrixTable;

            if (_gridView.Columns.Count != 0 && _hasFirstColumn)
            {
                DataGridViewColumn firstColumn = _gridView.Columns[0];
                firstColumn.DefaultCellStyle = _gridView.ColumnHeadersDefaultCellStyle;
                firstColumn.HeaderText = AlternativeNameColumnCaption;
                firstColumn.Name = AlternativeNameColumnName;
                firstColumn.ReadOnly = true;
            }
        }
        /// <summary>
        /// Виводить на контрол задану матрицю
        /// </summary>
        /// <param name="matrix">Матриця</param>
        private void _setMatrix(Matrix matrix)
        {
            if (matrix == null) return;

            ClearMatrix();
            _matrixTable.Columns.AddRange(_generateColumns(matrix.Criteriums).ToArray());

            foreach (Alternative alternative in matrix.Alternatives)
            {
                DataRow alternativeRow = _matrixTable.NewRow();
                _fillRow(alternativeRow, alternative, matrix.Criteriums);
                _matrixTable.Rows.Add(alternativeRow);
            }

            _fillNeededDefaults();
            _showData();
        }
        /// <summary>
        /// Заповнення значеннями по замовченню
        /// </summary>
        private void _fillNeededDefaults()
        {
            foreach (DataRow row in _matrixTable.Rows)
                foreach (DataColumn column in _matrixTable.Columns)
                {
                    if (column.ColumnName == AlternativeNameColumnName)
                        continue;

                    if (row[column] == DBNull.Value)
                    {
                        row[column] = DefaultValue;
                        continue;
                    }
                    int test;
                    if (!int.TryParse(row[column].ToString(), out test))
                        row[column] = DefaultValue;
                }
        }
        /// <summary>
        /// Повертаж матрицю, що відображається в даний момент на контролі
        /// </summary>
        private Matrix _getMatrix()
        {
            // generating columns
            List<Criterium> criteriums = new List<Criterium>();
            foreach (DataColumn column in _matrixTable.Columns)
            {
                if (column.ColumnName == AlternativeNameColumnName) continue;
                criteriums.Add(new Criterium(column.ColumnName));
            }
            // creating multicriterum matrix
            Matrix matrixResult = new Matrix();
            matrixResult.SetCriteriums(criteriums);
            // generating alternatives
            foreach (DataRow alternativeRow in _matrixTable.Rows)
            {
                // generating alternative
                Alternative alternative = matrixResult.NewAlternative(alternativeRow[AlternativeNameColumnName].ToString());
                // fill alternative
                foreach (Criterium criterium in criteriums)
                    alternative[criterium] = Convert.ToInt32(alternativeRow[criterium.Name]);
                // adding alernative
                matrixResult.AddAlternative(alternative);
            }

            return matrixResult;
        }

        /// <summary>
        /// Очищає матрицю
        /// </summary>
        public void ClearMatrix()
        {
            this.UnhighlightMatrix();

            _matrixTable.Clear();
            DataColumn firstColumn = _matrixTable.Columns.Count > 0 ? _matrixTable.Columns[0] : null;
            _matrixTable.Columns.Clear();
            if (firstColumn != null)
            {
                _matrixTable.Columns.Add(firstColumn);
            }
            _hasFirstColumn = firstColumn != null;
            _showData();

            //_hasFirstColumn = false;
        }
        /// <summary>
        /// Додаэ критерій до матриці
        /// </summary>
        /// <param name="criteriumName">Ім"я критерію</param>
        public void AddCriterium(string criteriumName)
        {
            this.UnhighlightMatrix();
            // creating column
            DataColumn toAdd = new DataColumn(criteriumName);
            // fill column
            toAdd.Caption = criteriumName;
            // adding column
            _matrixTable.Columns.Add(toAdd);
            // fill defaults
            foreach (DataRow row in _matrixTable.Rows)
                row[toAdd] = DefaultValue;
            // show data
            _showData();
        }
        /// <summary>
        /// Додає альтернативу до матриці
        /// </summary>        
        public void AddAlternative(string alternativeName)
        {
            this.UnhighlightMatrix();

            _tryAddLaternativeNameColumn();
            // creating row
            DataRow toAdd = _matrixTable.NewRow();
            // fill row
            foreach (DataColumn column in _matrixTable.Columns)
            {
                if (column.ColumnName != AlternativeNameColumnName)
                    toAdd[column] = DefaultValue;
                else toAdd[column] = alternativeName;
            }
            // adding row
            _matrixTable.Rows.Add(toAdd);
            // show data            
            _showData();
        }

        /// <summary>
        /// Видаляє альтернативу, на якій знаходиться фокус
        /// </summary>
        public void RemoveAlternative()
        {
            if (_gridView.SelectedCells.Count != 0 &&
                Messenger.Current.ShowMessage(MessageKind.Question_Yes_No, "Видалити альтернативу?") == DialogResult.Yes)
            {
                this.UnhighlightMatrix();

                DataRow rowToRemove = ((DataRowView)_gridView.SelectedCells[0].OwningRow.DataBoundItem).Row;
                _matrixTable.Rows.Remove(rowToRemove);
            }
        }
        /// <summary>
        /// Видаляэ критерій, на якому знгаходться фокус
        /// </summary>
        public void RemoveCriterium()
        {
            if (_gridView.SelectedCells.Count != 0 && _gridView.SelectedCells[0].OwningColumn.Name != AlternativeNameColumnName &&
                Messenger.Current.ShowMessage(MessageKind.Question_Yes_No, "Видалити критерій?") == DialogResult.Yes)
            {
                this.UnhighlightMatrix();

                DataColumn columnToRemove = _matrixTable.Columns[_gridView.SelectedCells[0].OwningColumn.Name];
                _matrixTable.Columns.Remove(columnToRemove);
            }
        }
        /// <summary>
        /// Видаляє критерій.
        /// </summary>
        public void RemoveCriterium(Criterium c)
        {
            RemoveCriterium(c.Name);
        }
        /// <summary>
        /// Видаляэ критерій за ім"ям
        /// </summary>
        /// <param name="criteriumName"></param>
        public void RemoveCriterium(string criteriumName)
        {
            this.UnhighlightMatrix();
            _matrixTable.Columns.Remove(criteriumName);
        }

        public void HighlightAlternatives(Alternative[] alts)
        {
            this.UnhighlightMatrix();

            if (alts == null)
            {
                return;
            }

            foreach (string a1 in this.Alternatives)
            {
                foreach (Alternative a2 in alts)
                {
                    if (a2.Name == a1)
                    {
                        this._highlightRow(a1);
                    }
                }
            }
        }

        public void UnhighlightMatrix()
        {
            for (int c = 0; c < _gridView.ColumnCount; c++)
            {
                for (int r = 0; r < _gridView.RowCount; r++)
                {
                    _gridView[c, r].Style.ForeColor = Color.Black;
                    _gridView[c, r].Style.Font = new Font(_gridView[c, r].InheritedStyle.Font, FontStyle.Regular);
                }
            }
        }

        private void _highlightRow(string row)
        {
            if (row == null)
            {
                return;
            }

            for (int r = 0; r < _gridView.RowCount; r++)
            {
                if (_gridView[0, r].Value.ToString() == row)
                {
                    for (int c = 1; c < _gridView.ColumnCount; c++)
                    {
                        _gridView[c, r].Style.ForeColor = Color.Orange;
                        _gridView[c, r].Style.Font = new Font(_gridView[c, r].InheritedStyle.Font, FontStyle.Bold);
                    }
                }
            }
        }

        #endregion

        #region Events

        private void _gridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ///pmb 20.05.10
            ///Навіщо ця перевірка? Можна ж щоб в матриці були від'ємні числа
            //_checkCellValue(e.RowIndex, e.ColumnIndex);
        }

        private void _gridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            _checkCellValue(e.RowIndex, e.ColumnIndex);
            e.ThrowException = e.Cancel = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _fillNeededDefaults();
            _showData();
        }

        #endregion
    }
}