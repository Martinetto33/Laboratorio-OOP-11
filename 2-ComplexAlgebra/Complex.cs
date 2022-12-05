/*
Non ti fare troppe domande, ma using System è un modo di importare la libreria matematica.
Lo so, non ha senso.
*/

using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public double Modulus { get; set; }
        public double Phase { get; set; }

        public Complex(double real, double imaginary) 
        {
            Real = real;
            Imaginary = imaginary;
            Modulus = ComputeModulus();
            Phase = ComputePhase();
        }

        private double ComputeModulus()
        {
            return Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
        }

        private double ComputePhase()
        {
            return Math.Atan(Imaginary / Real);
        }

        public Complex Complement()
        {
            return new Complex(-Real, -Imaginary);
        }

        public Complex Minus(Complex num)
        {
            return new Complex(Real - num.Real, Imaginary - num.Imaginary);
        }
        
        public Complex Plus(Complex num)
        {
            return new Complex(Real + num.Real, Imaginary + num.Imaginary);
        }

        public override string ToString()
        {
            return Real + (Imaginary >= 0 ? " + " : " - ") + Math.Abs(Imaginary) + "i";
        }

        public override bool Equals(object obj)
        {
            return obj is Complex complex &&
                   Real == complex.Real &&
                   Imaginary == complex.Imaginary;
        }
    }
}