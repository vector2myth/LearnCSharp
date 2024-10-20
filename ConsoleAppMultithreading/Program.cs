using System;
using System.Threading;

namespace ConsoleAppMultithreading;

public class Program
{
    /*
     * 进程（Process）：应用程序在操作系统上的一次运行
     * 进程之间互相独立、互不干扰，进程之间可以互相访问、操作
     * 线程（Thread）：包含在进程中，是操作系统能够运算调度的最小单位，是进程中的实际运行单位
     * 线程命名空间 using System.Threading
     * 申明一个新的线程，线程执行的代码，需要封装到一个函数中
     * 新线程将要执行的代码逻辑，被封装到了一个函数语句块中
     * 后台线程
     * 默认开启的线程是前台线程，即使主线程结束也不会结束，
     * 但是后台线程，会在主线程结束时也结束
     * 关闭释放一个线程
     * 在死循环中加入bool标识
     * 通过线程提供的方法t.Abort()【但是在.Net core中无法终止】
     * 线程休眠
     * 在哪个线程中休眠，就休眠哪个线程，1s=1000ms
     * 多线程使用的内存是共享的，都属于该应用程序（进程）
     * 所以要注意当多线程同时操作同一片内存区域时可能会出现问题
     * 可以通过加锁的形式避免问题
     * lock，当我们在多个线程当中想要访问同样的东西，进行逻辑处理时
     * 为了避免不必要的逻辑顺序执行的差错
     * lock(引用类型对象)
     * 
     * 
     */

    static bool isRunning = true;

    static object obj = new object();   // 引用类型的对象

    static void Main(string[] args)
    {
        Thread thread = new Thread(NewThreadLogic);
        thread.Start();
        thread.IsBackground = true; // 将线程设置为后台线程，这样主线程结束时，这个线程也会结束

        // 添加主线程死循环
        while (true)
        {
            lock (obj)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("1");
                Thread.Sleep(500);
            }
        }
    }

    static void NewThreadLogic()
    {
        while (isRunning)
        {
            lock (obj)
            {
                Console.SetCursorPosition(10, 10);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("0");
                Thread.Sleep(500);
            }
        }
    }
}