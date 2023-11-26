using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Threading.Tasks;

namespace ToyRobot
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            var path = ConfigurationManager.AppSettings["Path"].ToString();
			// Automatically executes when application is started.
			if (path == null)// || args.Length == 0)
            {
                Console.WriteLine("Please specify a .txt filepath.");
                return;
            }
            if (!File.Exists(path) && (Path.GetExtension(path)==".txt"))
            {
                string[] commands = File.ReadAllLines(@"C:\Users\HP\Desktop\test.txt");
                MainProgram main = new MainProgram();
                Console.WriteLine(main.Commander(commands));
            }
            else
            {
                Console.WriteLine("Not a .txt file. Please try again.");
                Console.Write(@"The correct command formats are as follows:
PLACE X,Y,DIRECTION
MOVE
RIGHT
LEFT
REPORT
-------------
Please review your input file and try again.");
            }
        }

        public string Commander(string[]commands)
        {
            string message = "";
            Command obj = new Command();
            if (obj != null)
            {
                message = obj.Start(commands);
            }
            return message;
        }
    }
}
