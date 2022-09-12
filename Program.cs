using System;
using System.Runtime.CompilerServices;
using System.Text.Json;

public class mainClass
{
    static void Main(string[] args)
    {
        menu.PrintMenu();
        decimal total = menu.PlaceOrder();
        if(total > 0)
        {
            Console.WriteLine("Your total is " +total+ " euros");
        }
        else
        {
            Console.WriteLine("Then why are you here?");
        }
    }
}
public class MenuItem

{
    public int id { get; set; }
    public string Dish { get; set; }
    public decimal Price { get; set; }
}

public class menu
{
    public static string jsonString = File.ReadAllText(@"C:/Dev/meuk/menu.json");
    public static readonly List<MenuItem> menuItems = JsonSerializer.Deserialize<List<MenuItem>>(jsonString);
    public const string FIRST_ORDER_LINE = "Would you like to order something? (yes/no)";
    public const string ORDER_LINE = "Would you like to order something else? (yes/no)";
    public const string ERROR_MESSAGE = "That is not a valid reply, please try again";
    public const string ID_ASK = "Type the ID of the dish you'd like to order: ";

    public static void PrintMenu()
    {
        foreach (var dish in menuItems)
        {
            Console.WriteLine("Id " + dish.id + " Dish " + dish.Dish + " Price " + dish.Price);
        }
    }
    
    public static decimal PlaceOrder()
    {
        decimal toPay = 0;
        int gerechtId;
        Console.WriteLine(FIRST_ORDER_LINE);
        string firstOrder = Console.ReadLine();
        while(firstOrder != "yes" && firstOrder != "no")
        {
            Console.WriteLine(ERROR_MESSAGE);
            Console.WriteLine(FIRST_ORDER_LINE);
            firstOrder = Console.ReadLine();
        }
        if (firstOrder == "yes")
        {
            Console.WriteLine(ID_ASK);
            bool tryParse = Int32.TryParse(Console.ReadLine(), out gerechtId);
            while (gerechtId > 10 || gerechtId < 0 || !tryParse)
            {
                Console.WriteLine(ERROR_MESSAGE);
                Console.WriteLine(ID_ASK);
                tryParse = Int32.TryParse(Console.ReadLine(), out gerechtId);
            }
            toPay += menuItems[gerechtId].Price;
            Console.WriteLine(ORDER_LINE);
            string moreToOrder = Console.ReadLine();
            while (moreToOrder != "yes" && moreToOrder != "no")
            {
                Console.WriteLine(ERROR_MESSAGE);
                Console.WriteLine(ORDER_LINE);
                moreToOrder = Console.ReadLine();
            }
            while (moreToOrder == "yes")
            {
                Console.WriteLine(ID_ASK);
                tryParse = Int32.TryParse(Console.ReadLine(), out gerechtId);
                while (gerechtId > 10 || gerechtId < 0 || !tryParse)
                {
                    Console.WriteLine(ERROR_MESSAGE);
                    Console.WriteLine(ID_ASK);
                    tryParse = Int32.TryParse(Console.ReadLine(), out gerechtId);
                }
                toPay += menuItems[gerechtId].Price;
                Console.WriteLine(ORDER_LINE);
                moreToOrder = Console.ReadLine();
                while (moreToOrder != "yes" && moreToOrder != "no")
                {
                    Console.WriteLine(ERROR_MESSAGE);
                    Console.WriteLine(ORDER_LINE);
                    moreToOrder = Console.ReadLine();
                }
            }
        }
        else
        {
            toPay = -1;
        }
        return toPay;
    }
    
}
