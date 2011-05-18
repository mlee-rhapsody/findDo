using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;


namespace findDo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Argument length is {0}", args.Length);
            if (args.Length != 2)
            {
                Console.WriteLine("Got wrong number of argument, expected two but got {0}", args.Length);
                Console.WriteLine("Usage: findDo.exe [target string \"\" or \".txt\"] [helloWorld.bat]");

                Environment.Exit(Environment.ExitCode);

            }

            string targetString = args[0];
            if(args[0].Equals("")){
                targetString = ".";
            }

            string[] files = Directory.GetFiles(".", targetString, SearchOption.AllDirectories);
            Console.WriteLine("Searching..");
            

            int targetCount = files.Length;
            if (targetCount > 0)
            {
                Console.WriteLine("Target found is: {0}", targetCount);
                printTargetsFound(files);
                runShellArgument(args[1]);
            }
            else
            {
                Console.WriteLine("Nothing found.");
            }
        }


        private static void runShellArgument(string shellArg)
        {

            Process process = Process.Start(
                new ProcessStartInfo("cmd.exe", "/c hw.bat")
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                });

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            if (process.ExitCode == 0)
            {

                Console.WriteLine(output);
            }
            else
            {
                Console.WriteLine("Error w/exitcode: {0}", process.ExitCode);

            }
        }

        private static void printTargetsFound(string[] files)
        {
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
