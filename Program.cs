using System;
using System.Diagnostics;

namespace ParentProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Parent process started.");

            
            Console.WriteLine("Enter the full path of the child process: ");
            string childProcessPath = Console.ReadLine();

            
            if (!System.IO.File.Exists(childProcessPath))
            {
                Console.WriteLine("Child process executable not found.");
                return;
            }

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = childProcessPath,
                    Arguments = "--test arg",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };

                // Start the child process
                Process childProcess = Process.Start(startInfo);
                Console.WriteLine($"Started child process with PID: {childProcess.Id}");

                
                childProcess.WaitForExit();

                Console.WriteLine("Child process has exited.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Parent process completed.");
        }
    }
}
