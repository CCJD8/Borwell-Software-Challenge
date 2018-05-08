using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace room_calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bcontinue = true; //set up a boolean variable for iteration until certain parameters are met
            while (bcontinue == true)
            {
                int[] ivalues = new int[3]; //both an integer and string array are created so that checks can be carried out on the inputs to verify they were integers
                string[] values = new string[3];

                Console.WriteLine("Input the length: "); //takes inputs from the user for the height, length, units etc -all as strings-
                string length = Console.ReadLine();
                Console.WriteLine("Input the width: ");
                string width = Console.ReadLine();
                Console.WriteLine("Input the height: ");
                string height = Console.ReadLine();
                Console.WriteLine("Input the units of measurement: ");
                string units = Console.ReadLine();

                if (units == "m")  //if statement rather than a switch / case layout because there are only two outcomes to check unit inputs
                {
                    values[0] = length; //assign the lengths etc to an index of the string array so it can be passed to the IntegerIdentifier method more easily 
                    values[1] = width;
                    values[2] = height;

                    int[] valuestemp = IntegerIdentifier(values, bcontinue, ivalues); //sets a temporary integer array and runs the method (passing the required parameters by reference)

                    int ilength = ivalues[0]; //if successfully converted to integers by the function the new integer values are taken into another set of variables for ease of understanding in the display of the results
                    int iwidth = ivalues[1];
                    int iheight = ivalues[2];

                    int floor_area = ilength * iwidth; //calculations for the floor area etc
                    int paint_required = (ilength * iheight * 2) + (iwidth * iheight * 2);
                    int volume = ilength * iwidth * iheight;

                    Console.Clear(); //clears the display on the console window 

                    Console.WriteLine("Floor Area: " + floor_area + "m^2\r\nPaint required: " + paint_required + "m^2\r\nVolume: " + volume+"m^3"); //displays the results 
                    Console.ReadKey(); //only continues the code if a key is pressed so that sufficient time is provided for the user to read the results
                    bcontinue = false; //sets boolean bcontinue to false so the program can terminate
                }
                else
                {
                    Console.WriteLine("Invalid units. Please input m or cm"); //else statement for if invalid units are inputted, this will repeatedly display until a correct input
                }
            }
        }
        static public int[] IntegerIdentifier(string[] values, bool bcontinue, int[] ivalues) //creating a method / function that will return an integer array. all required parameters are also passed by reference
        {
            for (int i = 0; i < 3 ; i++) //for loop to repeat 3 times to represent sequential array indices
            {
                bool integer_result1 = Int32.TryParse(values[i], out ivalues[i]); //testing for integer value
                if (integer_result1 == false) //tryparse will return false if a non integer value is found
                {
                    Console.WriteLine("Non-Integer input");
                    bcontinue = false;
                }
            }
            return ivalues; //returning integer array so that, in effect, multiple results can be returned but they are stored in one data type for efficiency
        }
    }
}
