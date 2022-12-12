using System;

namespace Calculator
{
    internal enum Action
    {
        None,
        Plus,
        Minus,
        Multiplication,
        Division,
        Percentage,
        Power,
        Root
    }

    internal class EquationAnalyzer
    {
        decimal _firstNumber;
        decimal _secondNumber;
        Action _action = Action.None;
        string _errorMessage = string.Empty;

        internal decimal FirstNumber { get => _firstNumber; set => _firstNumber = value; }
        internal decimal SecondNumber { get => _secondNumber; set => _secondNumber = value; }
        internal Action Action { get => _action; set => _action = value; }
        internal string ErrorMessage { get => _errorMessage; }
        
        internal decimal Calculate()
        {
            switch(_action)
            {
                case Action.Plus:
                    return Add();
                case Action.Minus:
                    return Subtract();
                case Action.Multiplication:
                    return Multiply();
                case Action.Division:
                    return Divide();
                case Action.Percentage:
                    return Percentage();
                case Action.Power:
                    return Power();
                case Action.Root:
                    return Root();
                default:
                    return decimal.Zero;
            }
        }

        decimal Add()
        {
            decimal result = decimal.Zero;
            try
            {
                result = decimal.Add(_firstNumber, _secondNumber);
            }
            catch (OverflowException)
            {
                _errorMessage = "OverflowException";
            }
            return result;
        }

        decimal Subtract()
        {
            decimal result = decimal.Zero;
            try
            {
                result = decimal.Subtract(_firstNumber, _secondNumber);
            }
            catch (OverflowException)
            {
                _errorMessage = "OverflowException";
            }
            return result;
        }

        decimal Multiply()
        {
            decimal result = decimal.Zero;
            try
            {
                result = decimal.Multiply(_firstNumber, _secondNumber);
            }
            catch (OverflowException)
            {
                _errorMessage = "OverflowException";
            }
            return result;
        }

        decimal Divide()
        {
            decimal result = decimal.Zero;
            try
            {
                result = decimal.Divide(_firstNumber, _secondNumber);
            }
            catch (OverflowException)
            {
                _errorMessage = "OverflowException";
            }
            catch(DivideByZeroException)
            {
                _errorMessage = "Cannot divide by zero";
            }
            return result;
        }

        decimal Percentage()
        {
            if(_secondNumber == decimal.Zero)
            {
                return (_firstNumber / 100m);
            }
            else
            {
                return ((_firstNumber / 100m) * _secondNumber);
            }
        }

        decimal Power()
        {
            decimal result = _firstNumber;

            for(int i = 0; i < _secondNumber; i++)
            {
                result *= _firstNumber;
            }

            return result;
        }

        decimal Root()
        {
            if (_firstNumber < 0m) throw new OverflowException("Cannot calculate square root from a negative number");
            return RecursionRoot(_firstNumber, null);
        }

        decimal RecursionRoot(decimal x, decimal? guess = null)
        {
            var ourGuess = guess.GetValueOrDefault(x / 2m);
            var result = x / ourGuess;
            var average = (ourGuess + result) / 2m;

            if (average == ourGuess)
                return average;
            else
                return RecursionRoot(x, average);
        }
    }
}
