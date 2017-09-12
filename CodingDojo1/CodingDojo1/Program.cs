using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo1
{
    class Program
    {
        //define key chars for temp format selection
        private const char CELSIUS = 'c';
        private const char FAHRENHEIT = 'f';
        private const char REAMUR = 'r';
        private const char KELVIN = 'k';

        static void Main(string[] args)
        {
            //variable declaration and definition
            double c = 0.0;
            double f = 0.0;
            double r = 0.0;
            double k = 0.0;
            Double temp = 0.0;
            string format = "° Celsius";
            char type = 'c';

            //do while loop for continous execution
            do
            {
                //print menu
                Console.WriteLine("\nPossible inputs for temperature type" +
                    "\n{0} for Celsius" +
                    "\n{1} for Fahrenheit" +
                    "\n{2} for Reamur" +
                    "\n{3} for Kelvin" +
                    "\nany other character to exit the program", CELSIUS, FAHRENHEIT, REAMUR, KELVIN);

                //read input format of temp
                Console.Write("Your choice: ");
                type = Console.ReadKey().KeyChar;

                //check if input was valid
                if (type != CELSIUS &&
                    type != FAHRENHEIT &&
                    type != REAMUR &&
                    type != KELVIN)
                {
                    Environment.Exit(1);
                }

                //ask for input temp
                Console.WriteLine();
                Console.Write("Enter temperature to be converted (use comma , as decimal point): ");

                //try to read input temp, if exception is thrown print error and exit
                try
                {
                    temp = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input. Press enter to leave.");
                    Console.ReadLine();
                    Environment.Exit(1);
                }

                Console.WriteLine();

                //convert everything to celsius
                switch (type)
                {
                    case CELSIUS:
                        c = temp;
                        format = "° Celsius";
                        break;
                    case FAHRENHEIT:
                        c = F2C(temp);
                        format = "° Fahrenheit";
                        break;
                    case REAMUR:
                        c = R2C(temp);
                        format = "° Reamur";
                        break;
                    case KELVIN:
                        c = K2C(temp);
                        format = " Kelvin";
                        break;
                }

                //convert from celsius to the others
                f = C2F(c);
                r = C2R(c);
                k = C2K(c);

                //print result
                Console.WriteLine("{0}{1} is equal to:" +
                    "\n{2}° Celsius" +
                    "\n{3}° Fahrenheit" +
                    "\n{4}° Reamur" +
                    "\n{5} Kelvin" +
                    "\nthank you for using our app.", temp, format, c, f, r, k);

                //ask to exit or continue
                Console.Write("Continue? Enter 'n' to exit. Continue with any other input: ");

            } while (Console.ReadKey().KeyChar != 'n');
        }

        //convert fahrenheit to celsius
        private static double F2C(double input)
        {
            return ((input-32)/1.8);
        }

        //convert reamur to celsius
        private static double R2C(double input)
        {
            return (input/0.8);
        }

        //convert kelvin to celsius
        private static double K2C(double input)
        {
            return (input-273);
        }

        //convert celsius to fahrenheit
        private static double C2F(double input)
        {
            return ((input*1.8)+32);
        }

        //convert celsius to reamur
        private static double C2R(double input)
        {
            return (input*0.8);
        }

        //convert celsius to kelvin
        private static double C2K(double input)
        {
            return (input+273);
        }
    }
}
