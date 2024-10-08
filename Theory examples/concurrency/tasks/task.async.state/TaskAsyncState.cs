﻿using System;
using System.Threading;
using System.Threading.Tasks;

class TaskData
{
    public long CreationTime { get; set; }
    public int Name { get; set; }
    public int ThreadNum { get; set; }
}

public class TaskAsyncState
{
    public static void Main()
    {
        Task[] taskArray = new Task[10];
        for (int i = 0; i < taskArray.Length; i++)
        {
            taskArray[i] = Task.Factory.StartNew((Object obj) =>
            {
                TaskData data = obj as TaskData;
                if (data == null)
                    return;

                data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
            }, new TaskData() { Name = i, CreationTime = DateTime.Now.Ticks });
        }
        Task.WaitAll(taskArray);
        foreach (var task in taskArray)
        {
            var data = task.AsyncState as TaskData;
            if (data != null)
                Console.WriteLine("Task #{0} created at {1}, ran on thread #{2}.",
                                    data.Name, data.CreationTime, data.ThreadNum);
        }
    }
}

