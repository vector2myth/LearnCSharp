using System;

namespace ConsoleAppListSort;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("List排序");
        // 使用List自带的排序方法
        List<int> list = new List<int>();
        list.Add(1);
        list.Add(9);
        list.Add(0);
        list.Add(2);
        list.Add(-3);
        list.Add(6);
        list.Add(4);

        foreach (int i in list)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("使用List.Sort()");
        list.Sort();
        foreach (int i in list)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("自定义类的排序");
        List<Item> itemList = new List<Item>();
        itemList.Add(new Item(90));
        itemList.Add(new Item(-90));
        itemList.Add(new Item(9));
        itemList.Add(new Item(0));
        // 自定义类的排序，需要继承排序接口
        itemList.Sort();
        foreach (Item item in itemList)
        {
            Console.WriteLine(item.money);
        }

        Console.WriteLine("通过委托函数实现排序");
        List<ShopItem> shopItemList = new List<ShopItem>();
        shopItemList.Add(new ShopItem(2));
        shopItemList.Add(new ShopItem(0));
        shopItemList.Add(new ShopItem(1));
        shopItemList.Add(new ShopItem(2));
        shopItemList.Add(new ShopItem(-12));
        //shopItemList.Sort(SortShopItem);    // Sort的参数是一个委托，可以传入函数
        //foreach (ShopItem item in shopItemList)
        //{
        //    Console.WriteLine(item.id);
        //}

        Console.WriteLine("使用匿名函数，或Lambda表达式的形式");
        shopItemList.Sort((a,b) =>
        {
            return a.id > b.id ? 1 : -1;    // Lambda表达式配合三目运算符
        });

        foreach (ShopItem item in shopItemList)
        {
            Console.WriteLine(item.id);
        }
    }


    class Item : IComparable<Item>
    {
        public int money;

        public Item(int money)
        {
            this.money = money;
        }

        public int CompareTo(Item? other)
        {
            /**自定义排序规则
             * 返回值的含义
             * 小于0：
             * 放在传入对象的前面
             * 等于0：
             * 保持当前的位置不变
             * 大于0：
             * 放在传入对象的后面
             * 
             */
            if (this.money > other.money)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }

    class ShopItem
    {
        public int id;

        public ShopItem(int id)
        {
            this.id = id;
        }
    }

    static int SortShopItem(ShopItem a, ShopItem b)
    {
        // 传入两个对象，为列表中的两个对象，进行两两比较，用左边的和右边的进行条件比较
        // 返回值规则，0为标准，-1在前，1在后
        if(a.id > b.id)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
}