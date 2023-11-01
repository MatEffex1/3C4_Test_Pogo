using System.Numerics;

namespace Generics
{
    internal class Calculator<T>
        where T : unmanaged,
        IAdditionOperators<T, T, T>,
        ISubtractionOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        IDivisionOperators<T, T, T>
    {
        public Calculator()
        {

        }

        public Calculator(T val)
        {
            Result = val;
        }

        public void Add(T val)
        {
            Result += val;
        }

        public void Subtract(T val)
        {
            Result -= val;
        }

        public void Multiply(T val)
        {
            Result *= val;
        }

        public void Divide(T val)
        {
            Result /= val;
        }

        public static T operator +(Calculator<T> calculator, T val)
        {
            return calculator.Result + val;
        }

        public static implicit operator T(Calculator<T> calculator)
        {
            return calculator.Result;
        }

        public T Result;
    }
}
