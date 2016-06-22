using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.DataTypes;
using Modules.MulticriterionProblemMethods.Inerfaces;
using Modules.MulticriterionProblemMethods.Workflow;
using Modules.MulticriterionProblemMethods.Workflow.Validation;
using Modules.MulticriterionProblemMethods.Workflow.Messaging;

namespace Modules.MulticriterionProblemMethods.View.Forms
{
    /// <summary>
    /// ����� ��� �������� �������
    /// </summary>
    internal partial class frmMatrixEdit : frmBase, IMatrixEditor
    {
        private bool _mustValidate = true;

        /// <summary>
        /// ����� ��� �������� �������
        /// </summary>
        public frmMatrixEdit ( )
        {
            InitializeComponent ( );
        }

        private bool _isReadOnly;
        /// <summary>
        ///  �������� ����� ��� �������
        /// </summary>
        public bool ReadOnly
        {
            get { return _isReadOnly; }
            set
            {
                _isReadOnly = value;
                ctrlMatrix.ReadOnly = value;
            }
        }

        #region Methods

        /// <summary>
        /// ������ ������� ���� ��� ������� ��"� ������� �� ������������
        /// </summary>
        /// <param name="nameKind">�������/������������</param>
        /// <returns>������� ��"� ������������ �� �������</returns>
        private string _showNameEditor ( EntityKind nameKind )
        {
            frmNameEdit frmNameEditor = new frmNameEdit ( );
            frmNameEditor.Init ( nameKind );

            frmNameEditor.Validating += delegate ( object sender, EventArgs<IValidationResult> e )
            {
                List<string> validationInfo = new List<string> ( );
                IEnumerable items;
                items = nameKind == EntityKind.Alternative ? ctrlMatrix.Alternatives
                    : ctrlMatrix.Criteriums;

                foreach ( object item in items )
                    validationInfo.Add ( item.ToString ( ) );

                UniqueValidator<string> uniqueValidator = new UniqueValidator<string> ( validationInfo.ToArray ( ), frmNameEditor.Value );
                e.Value = uniqueValidator.Validate ( );
            };

            return frmNameEditor.ShowDialog ( ) == DialogResult.OK ? frmNameEditor.Value : string.Empty;
        }
        /// <summary>
        /// ������ �� ������� �������/������������
        /// </summary>
        /// <param name="entityName">��"� �������/������������</param>
        /// <param name="nameKind">�������/������������</param>
        private void _addEntity ( string entityName, EntityKind nameKind )
        {
            if ( !string.IsNullOrEmpty ( entityName ) )
            {
                switch ( nameKind )
                {
                    case EntityKind.Alternative:
                        ctrlMatrix.AddAlternative ( entityName );
                        break;
                    case EntityKind.Criterium:
                        ctrlMatrix.AddCriterium ( entityName );
                        break;
                }
            }
        }
        /// <summary>
        /// ���� ������� �� �������
        /// </summary>
        private void _addCriterium ( )
        {
            string criteriumName = _showNameEditor ( EntityKind.Criterium );
            if ( !string.IsNullOrEmpty ( criteriumName ) )
                _addEntity ( criteriumName, EntityKind.Criterium );
        }
        /// <summary>
        /// ���� ������������ �� �������
        /// </summary>
        private void _addAlternative ( )
        {
            string alternativeName = _showNameEditor ( EntityKind.Alternative );
            if ( !string.IsNullOrEmpty ( alternativeName ) )
                _addEntity ( alternativeName, EntityKind.Alternative );
        }
        /// <summary>
        /// �������� �� �������� �������� �����.
        /// </summary>        
        private bool isValid ( )
        {
            Matrix matrix = ctrlMatrix.Matrix;
            List<Alternative> alternatives = new List<Alternative> ( matrix.Alternatives );
            List<Criterium> equalCriteriums = new List<Criterium> ( );
            if ( alternatives.Count > 1 )
            {
                foreach ( Criterium c in matrix.Criteriums )
                {
                    bool equal = true;
                    for ( int i = 1; i < alternatives.Count; i++ )
                    {

                        if ( matrix[ alternatives[ i ], c ] != matrix[ alternatives[ 0 ], c ] )
                        {
                            equal = false;
                            break;
                        }
                    }
                    if ( equal ) equalCriteriums.Add ( c );
                }
                if ( equalCriteriums.Count > 0 )
                {
                    int criteriumIndex = 1;
                    StringBuilder output = new StringBuilder ( );
                    output.AppendLine ( "�� ������������ ����� ������� �������� �� ����� ��������:" );
                    foreach ( Criterium c in equalCriteriums )
                    {
                        output.AppendLine ( string.Format ( "{1}) {0};", c.Name, criteriumIndex ) );
                        criteriumIndex++;
                    }
                    output.Append ( "�������� ��� ������ �� ���������?" );

                    if ( Messenger.Current.ShowMessage ( MessageKind.Question_Yes_No, output.ToString ( ) ) == DialogResult.Yes )
                    {
                        foreach ( Criterium c in equalCriteriums )
                            ctrlMatrix.RemoveCriterium ( c );
                    }
                    return false;
                }
            }
            else if ( matrix.AlternativesCount == 0 )
            {
                Messenger.Current.ShowMessage ( MessageKind.Warning_Ok, "������ ���� � ���� ������������." );
                return false;
            }
            if ( matrix.CriteriumsCount == 0 )
            {
                Messenger.Current.ShowMessage ( MessageKind.Warning_Ok, "������ ���� � ���� �������." );
                return false;
            }
            return true;
        }
        /// <summary>
        /// ������� ������� ������
        /// </summary>
        public Matrix Matrix
        {
            get { return ctrlMatrix.Matrix; }
        }
        /// <summary>
        /// ����������� �����
        /// </summary>
        /// <param name="editMode">�����: ������� ����� �� ����������� ��������</param>
        /// <param name="matrix">������� � �������</param>
        /// <param name="nameEditor">ĳ����, ����� ���� ��������� ��"� �������/������������</param>
        public void Init ( Matrix matrix )
        {
            ctrlMatrix.Matrix = matrix;
        }
        /// <summary>
        /// ����� �������
        /// </summary>
        public void ClearMatrix ( )
        {
            ctrlMatrix.ClearMatrix ( );
        }

        #endregion

        #region Events

        private void _addCriterium ( object sender, EventArgs e )
        {
            _addCriterium ( );
        }
        private void _addAlternative ( object sender, EventArgs e )
        {
            _addAlternative ( );
        }
        private void _removeCriterium ( object sender, EventArgs e )
        {
            ctrlMatrix.RemoveCriterium ( );
        }
        private void _removeAlternative ( object sender, EventArgs e )
        {
            ctrlMatrix.RemoveAlternative ( );
        }
        private void _clearMatrix ( object sender, EventArgs e )
        {
            ctrlMatrix.ClearMatrix ( );
        }
        private void btnClose_Click ( object sender, EventArgs e )
        {
            _mustValidate = false;
            Close ( );
            _mustValidate = true;
        }

        protected override void OnClosing ( CancelEventArgs e )
        {
            _mustValidate = false;
            base.OnClosing ( e );
            e.Cancel |= _mustValidate && !isValid();
           
        }

        #endregion

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            _addAlternative();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ctrlMatrix.RandomFill();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void frmMatrixEdit_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmMatrixEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void frmMatrixEdit_Load(object sender, EventArgs e)
        {

        }
    }
}