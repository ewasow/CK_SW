using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace CalcLog
{

    [Serializable]
    public class ResultIsZeroException : Exception
    {
        public ResultIsZeroException() : this("Result is zero") { }
        public ResultIsZeroException(string message) : base(message) { }
        public ResultIsZeroException(string message, Exception inner) : base(message, inner) { }
        protected ResultIsZeroException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetResult()
        {
            var operation = SelectedOperation();
            var result = ExecuteOperation(operation);
            tbResult.Text = result.ToString();
            if (result == 0)
            {
                throw new ResultIsZeroException();
            }
        }

        private Operation SelectedOperation()
        {
            if(cbiAdd.IsSelected)
            {
                return Operation.Plus;
            }
            if(cbiSubtract.IsSelected)
            {
                return Operation.Minus;
            }
            if(cbiMultiply.IsSelected)
            {
                return Operation.Times;
            }
            if(cbiDivide.IsSelected)
            {
                return Operation.DividedBy;
            }
            throw new InvalidOperationException("Operation not selected");
        }

        private int ExecuteOperation(Operation op)
        {
            var first = int.Parse(tbFirstNumber.Text);
            var second = int.Parse(tbSecondNumber.Text);
            switch(op)
            {
                case Operation.Plus:
                    return first + second;
                case Operation.Minus:
                    return first - second;
                case Operation.Times:
                    return first * second;
                case Operation.DividedBy:
                    return first / second;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        enum Operation
        {
            Plus,
            Minus,
            Times,
            DividedBy,
        }
    }
}

