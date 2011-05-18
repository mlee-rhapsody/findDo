using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


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
            //Still buggy.. might need to change implementation.

            //System.Diagnostics.Process pProcess = new System.Diagnostics.Process();

            //pProcess.EnableRaisingEvents = false;
            //pProcess.StartInfo.FileName = @"c:\windows\system32\cmd.exe /c "+shellArg;
            //pProcess.StartInfo.UseShellExecute = false;
            //pProcess.StartInfo.RedirectStandardOutput = true;
            //pProcess.StartInfo.CreateNoWindow = true;
            //pProcess.Start();

            ////string output = pProcess.StandardOutput.ReadToEnd();
            //StreamReader stdOut = pProcess.StandardOutput;
            //pProcess.WaitForExit();

            //StringBuilder sb = new StringBuilder();

            //while (!stdOut.EndOfStream) {
            //    sb.AppendLine(stdOut.ReadLine());
            //}


            //Console.WriteLine(sb.ToString());
            

            //pProcess.Close();
            //Console.WriteLine("runShellFake");

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
