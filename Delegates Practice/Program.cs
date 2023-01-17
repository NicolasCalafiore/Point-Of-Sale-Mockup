
using Delegates_Practice.Assets;
using System.Xml.Schema;

public delegate double TaxDelegate(double total);




class Program
{
    static void Main(string[] args)
    {

        ItemsManager itemManager = new ItemsManager();
        Cart cart = new Cart();
        MenuSelection menu = new MenuSelection(itemManager, cart);
        String input = "";



        while (true) {
            menu.DisplayShopping();
            input = Console.ReadLine();
            if (input == "X") break;
            try { cart.AddItemToCart(itemManager.getSelectedItem(Int32.Parse(input))); } catch (Exception invalidSelection) { Console.WriteLine("Invalid Selection"); }
        }

        menu.DisplayPayment();
        input = Console.ReadLine();

        TaxDelegate taxDelegate = PlaceHolder;
        switch (input)
        {
            case ("1"): taxDelegate = FloridaTax; break;
            case ("2"): taxDelegate = CaliforniaTax; break;
            case ("3"): taxDelegate = NewYorkTax; break;
            case ("4"): taxDelegate = CaliforniaTax; break;
            case ("5"): taxDelegate = MontanaTax; break;
            case ("6"): taxDelegate = NevadaTax; break;
            case ("7"): taxDelegate = KentuckyTax; break;
            case ("8"): taxDelegate = VermontTax; break;
            case ("9"): taxDelegate = MissouriTax; break;
            case ("10"): taxDelegate = NewMexicoTax; break;
        }

        double taxableAmount = 0;
        foreach(Items i in cart.ItemsGetItems())
        {
            if (i.isTaxableItem()) taxableAmount += i.getDisplayPrice();
        }
        double taxes = taxDelegate(taxableAmount);

        Console.WriteLine("Total: {0}", (cart.getAccumulatedPrice() + taxes));
        Console.WriteLine("Press Enter to Exit");
        Console.ReadLine();

    }
    public static double NewMexicoTax(double total)
    {
        return total + (total * .0784);
    }
    public static double MissouriTax(double total)
    {
        return total + (total * .0707);
    }
    public static double VermontTax(double total)
    {
        return total + (total * .0624);
    }
    public static double KentuckyTax(double total)
    {
        return total + (total * .06);
    }
    public static double NevadaTax(double total)
    {
        return total + (total * .0823);
    }
    public static double MontanaTax(double total)
    {
        return total + (total * .0749);
    }
    public static double NewYorkTax(double total)
    {
        return total + (total * .0852);
    }
    public static double PlaceHolder(double total)
    {

        return -1;
    }
    public static double FloridaTax(double total)
    {
        return total + (total * .07);
    }

    public static double CaliforniaTax(double total)
    {
        return total + (total * .0882);
    }

    public static double ConnecticutTax(double total)
    {
        return total + (total * .0637);
    }
}




