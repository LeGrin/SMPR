using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ConflictsAndCompromises
{
    public struct TestItem
    {
        public string Name;
        public List<Point> Result;

        public TestItem(string name, List<Point> result)
        {
            Name = name;
            Result = result;
        }
    }
}
