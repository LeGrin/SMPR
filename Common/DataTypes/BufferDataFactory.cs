using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTypes
{
    public class BufferDataFactory
    {
        public static BufferData GetBufferData(int bdType, int bdContentType)
        {
            Type t;
            Type bdt;

            switch (bdContentType)
            {
                case 0:
                    {
                        t = typeof(int);
                        break;
                    }
                case 1:
                    {
                        t = typeof(double);
                        break;
                    }
                case 2:
                    {
                        t = typeof(string);
                        break;
                    }
                case 3:
                    {
                        t = typeof(ParsablePointD);
                        break;
                    }
                default: throw new ArgumentException("Type t screwed up");
            }
            
            switch (bdType)
            {
                case 0:
                    {
                        bdt = typeof(Scalar<>).MakeGenericType(t);
                        break;
                    }
                case 1:
                    {
                        bdt = typeof(Vector<>).MakeGenericType(t);
                        break;
                    }
                case 2:
                    {
                        bdt = typeof(Matrix<>).MakeGenericType(t);
                        break;
                    }
                
                default:
                    throw new ArgumentException("Type bdt screwed up");
            }

            return (BufferData)Activator.CreateInstance(bdt);
        }
    }
}
