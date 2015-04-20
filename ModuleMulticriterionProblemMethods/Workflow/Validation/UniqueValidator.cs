using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.Inerfaces;
using Modules.MulticriterionProblemMethods.DataTypes;
using System.Collections;

namespace Modules.MulticriterionProblemMethods.Workflow.Validation
{
    /// <summary>
    /// ����, �� �������� ���������� ������� ��"����
    /// </summary>
    /// <typeparam name="T">��� ��"����, �� ������������</typeparam>
    internal class UniqueValidator<T> : IValidator
    {
        private T[] _validationInfo;
        private T _checkedObject;

        /// <summary>
        /// ������� ��������� �����, �� �������� ���������� ������� ��"����
        /// </summary>
        public UniqueValidator(object[] objectsCollection, object checkedObject)
        {
            if (objectsCollection == null) throw new ArgumentNullException("validationInfo");
            if (checkedObject == null) throw new ArgumentNullException("checkedObject");

            List<T> validationInfoList = new List<T>();
            foreach (object obj in objectsCollection) validationInfoList.Add((T)obj);

            _validationInfo = validationInfoList.ToArray();
            _checkedObject = (T)checkedObject;
        }
        /// <summary>
        /// ��������!
        /// </summary>
        /// <returns></returns>
        public IValidationResult Validate()
        {
            if (_validationInfo == null || _checkedObject == null)
                throw new InvalidOperationException("������� �������� �������������� �������� ���������� ����� Init");

            foreach (T obj in _validationInfo)
                if (obj.Equals(_checkedObject))
                    return new ValidatioResult(string.Format("{0} ��� ����", _checkedObject));

            return new ValidatioResult();
        }
    }
}