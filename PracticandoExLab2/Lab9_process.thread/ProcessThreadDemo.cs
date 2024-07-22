using System;
using System.Diagnostics;
using System.IO;

namespace TPP.Laboratory.Concurrency.Lab09 {

    class ProcessThreadDemo {

        private void ShowProcesses(Process[] process, TextWriter output) {
            foreach (Process proc in process) {
                output.WriteLine("- PID: {0}\tName: {1}\tVirtual memory: {2:N} MB",
                        proc.Id, proc.ProcessName, proc.VirtualMemorySize64 / 1024.0 / 1024
                        );
            }
        }

        private void ShowProcess(Process process, TextWriter output, bool showMemory) {
            output.Write("- PID: {0}\tName: {1}", process.Id, process.ProcessName);
            if (showMemory)
                output.Write("\tVirtual memory: {2:N} MB",process.VirtualMemorySize64 / 1024.0 / 1024);
            output.WriteLine(".");
        }

        private void ShowThreads(ProcessThreadCollection collection, TextWriter output) {
            foreach (ProcessThread thread in collection) 
                output.WriteLine("\t- ThreadId: {0}\tPriority: {1}\tState: {2}.",
                    thread.Id, thread.CurrentPriority, thread.ThreadState);
        }

        static void Main() {
            ProcessThreadDemo demo = new ProcessThreadDemo();
            var processes = Process.GetProcesses();
            demo.ShowProcesses(processes, Console.Out);
            
            Console.Write("Press enter to continue... ");
            Console.ReadLine();

            foreach (var process in processes) {
                demo.ShowProcess(process, Console.Out, false);
                demo.ShowThreads(process.Threads, Console.Out);
            }
        }

        /*
         * - PID: 0        Name: Idle      Virtual memory: 0,01 MB
- PID: 4        Name: System    Virtual memory: 4,00 MB
- PID: 140      Name: Secure System     Virtual memory: 2,30 MB
- PID: 172      Name: Registry  Virtual memory: 222,27 MB
        ...
- PID: 10016    Name: process.thread.
        - ThreadId: 25288       Priority: 8     State: Running.
        - ThreadId: 11124       Priority: 8     State: Wait.
        - ThreadId: 16268       Priority: 8     State: Wait.
        - ThreadId: 8032        Priority: 8     State: Wait.
        - ThreadId: 24636       Priority: 8     State: Wait.
        - ThreadId: 4920        Priority: 8     State: Wait.
        - ThreadId: 21364       Priority: 11    State: Wait.
        - ThreadId: 12460       Priority: 9     State: Wait.
        */
    }
}
