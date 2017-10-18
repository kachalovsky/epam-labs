using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit
{
    public class Calculator
    {
        public double Sum(double firsOperand, double secondOperand)
        {
            return firsOperand + secondOperand;
        }

        public double Sub(double firsOperand, double secondOperand)
        {
            return firsOperand - secondOperand;
        }


        public double Mult(double firsOperand, double secondOperand)
        {
            return firsOperand * secondOperand;
        }
        
        public double Devide(double firsOperand, double secondOperand)
        {
            return firsOperand / secondOperand;
        }
    }
}
