using System;
namespace Modules.MulticriterionProblemMethods.Interfaces
{
    interface IDataContainer
    {
        bool HasData { get; }
        bool HasResult { get; }
        Modules.MulticriterionProblemMethods.DataTypes.Alternative[] LastResult { get; set; }
        Modules.MulticriterionProblemMethods.DataTypes.Matrix Matrix { get; set; }
    }
}
