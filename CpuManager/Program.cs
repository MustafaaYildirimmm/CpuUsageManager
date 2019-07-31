using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CpuManager
{
    class Program
    {
        static void Main(string[] args)
        {


            ////Get the our application's process.
            //Process process = Process.GetCurrentProcess();

            ////Get the processor count of our machine.
            //int cpuCount = Environment.ProcessorCount;
            //Console.WriteLine("CPU Count : {0}", cpuCount);

            ////Since the application starts with a few threads, we have to
            ////record the offset.
            //int offset = process.Threads.Count;
            //Thread[] threads = new Thread[cpuCount];
            //Console.WriteLine(process.Threads.Count);
            //LogThreadIds(process);

            ////Create and start a number of threads that equals to
            ////our processor count.
            //for (int i = 0; i < cpuCount; ++i)
            //{
            //    Thread t = new Thread(new ThreadStart(Calculation))
            //    { IsBackground = true };
            //    t.Start();
            //}

            ////Refresh the process information in order to get the newest
            ////thread list.
            //process.Refresh();
            //Console.WriteLine(process.Threads.Count);
            //LogThreadIds(process);

            ////Set the affinity of newly created threads.
            //for (int i = 0; i < cpuCount; ++i)
            //{
            //    //process.Threads[i + offset].ProcessorAffinity = (IntPtr)(1L << i);
            //    //The code above distributes threads evenly on all processors.
            //    //But now we are making a test, so let's bind all the threads to the
            //    //second processor.
            //    process.Threads[i + offset].ProcessorAffinity = (IntPtr)(1L << 1);
            //}
            // Make sure there is an instance of notepad running.


            //öncelik belirleyebilriz.
            //cpu kullanım yüzdesini belirleyebiliriz.
            //thread lerin hangi cpu üzerinde çalışması gerektiğini ayarlayabliriz.


            //projenin oluşturulduğu current proccessinin bütün threadlerini 2. cpu üzerinde çalışmasını sağlar
            //Process.GetCurrentProcess().ProcessorAffinity = (System.IntPtr)2;

            int cpuCount = Environment.ProcessorCount;//makinenin cpu sayısı

            Process test = Process.GetProcessById(6696);// pid : 6696
            test.ProcessorAffinity = (IntPtr)2;//bütün thread leri  2. cpu ya ayarlar.

            //belirli ideal threadleri istediğimiz cpu ya ayarlayabiliriz.
            ProcessThreadCollection threads;
            threads = test.Threads;
            // Set the properties on the first ProcessThread in the collection
            threads[0].IdealProcessor = 0;
            threads[0].ProcessorAffinity = (IntPtr)2; //threadleri hangi cpu da çalışıyorsa ona ayarlayabiliriz.Kullanmadığı cpu ya ayarlayamıyoruz!! Error: hatalı parametre

            Console.ReadLine();
        }
        //static void Calculation()
        //{
        //    //some extreme loads.
        //    while (true)
        //    {
        //        Random rand = new Random();
        //        double a = rand.NextDouble();
        //        a = Math.Sin(Math.Sin(a));
        //    }
        //}
        //static void LogThreadIds(Process proc)
        //{
        //    //This will log out all the thread id binded to the process.
        //    //It is used to test whether newly added threads are the latest elements
        //    //in the collection.
        //    Console.WriteLine("===Thread Ids===");
        //    for (int i = 0; i < proc.Threads.Count; ++i)
        //    {
        //        Console.WriteLine(proc.Threads[i].Id);
        //    }
        //    Console.WriteLine("===End of Thread Ids===");
        //}
    }
}

