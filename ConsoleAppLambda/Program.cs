using System;

namespace ConsoleAppLambda;

public class Program
{
    /*
     * Lambda表达式就是匿名函数的简写
     * (参数列表)=>{函数逻辑}
     * 必须配合委托或者事件来使用Action、Func
     * 
     * 闭包
     * 外层函数可以引起包含在它外层的函数的变量
     * 即使外层函数的执行已经终止
     * 该变量提供的值并非变量创建时的值，而是在父函数范围内的最终值
     */
    static void Main(string[] args)
    {
        Console.WriteLine("Lambda表达式");
        // 无参无返回值
        Action a = () =>
        {
            Console.WriteLine("无参无返回值的Lambda表达式");
        };
        a();
        // 有参数
        Action<int> a2 = (int value) =>
        {
            Console.WriteLine($"有参数：{value}");
        };
        a2(10);
        // 省略参数类型，参数类型和委托或者事件容器一样
        Action<string> a3 = (value) =>
        {
            Console.WriteLine($"省略了{value}参数类型");
        };
        a3("省略");
        // 有返回值，委托Func()中的参数，最后一个是返回值类型，前面的都是参数类型
        Func<string, int> a4 = (value) =>
        {
            Console.WriteLine($"有返回值,{value}，有参数的Lambda表达式");
            return 1;
        };
        Console.WriteLine(a4("有返回hi")); // 先执行Lambda，最后返回
        Test test = new Test();
        test.DoSth();

    }
    class Test
    {
        public event Action action; // event声明这是一个事件，Action是一个不带参数且没有返回值的委托

        public Test()
        {
            int value = 101;

            // 此处形成了闭包，当构造函数执行完成，临时变量value的生命周期被改变
            action = () =>
            {
                Console.WriteLine(value);
            };

            for (int i = 0; i < 10; i++)
            {
                int index = i;  // 此index非彼index
                action += () =>
                {
                    Console.WriteLine(index);   // 如果输出i，那么变量i会直接输出为最终变量
                };
            }
        }
        public void DoSth()
        {
            action();
        }
    }
}