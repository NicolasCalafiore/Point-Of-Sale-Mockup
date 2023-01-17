
using Delegates_Practice.Assets;
using System.Xml.Schema;

public delegate double TaxDelegate(double total);

class Program
{
    static void Main(string[] args)
    {

        ItemsManager itemManager = new ItemsManager();              // Manages the Items Objects
        Cart cart = new Cart();                                     // Stores Cart Information
        MenuSelection menu = new MenuSelection(itemManager, cart);  // Manages what is displayed
        String input = "";
        TaxDelegate taxDelegate = Taxes.PlaceHolder;                // Delegate to handle calculating taxes



        menu.DisplayShopping(); // Prompts User with selection and loops until they wish to exit.
                                // If not exited the item selected is added to the cart


        menu.DisplayPayment();                                      // Displays Payment Options (States)


        input = Console.ReadLine();
        switch (input)                                              // Assigns proper tax delegate to respective state
        {
            case ("1"): taxDelegate = Taxes.FloridaTax; break;
            case ("2"): taxDelegate = Taxes.CaliforniaTax; break;
            case ("3"): taxDelegate = Taxes.NewYorkTax; break;
            case ("4"): taxDelegate = Taxes.CaliforniaTax; break;
            case ("5"): taxDelegate = Taxes.MontanaTax; break;
            case ("6"): taxDelegate = Taxes.NevadaTax; break;
            case ("7"): taxDelegate = Taxes.KentuckyTax; break;
            case ("8"): taxDelegate = Taxes.VermontTax; break;
            case ("9"): taxDelegate = Taxes.MissouriTax; break;
            case ("10"): taxDelegate = Taxes.NewMexicoTax; break;
        }
        for (int i = 0; i < 40; i++) Console.WriteLine("\n");
        double taxes = Taxes.CalculateTaxes(cart, taxDelegate);       // Calculates the tax amount of all items that are taxable
        Console.WriteLine("RECEIPT");
        Console.WriteLine("-------------------------------------");
        foreach (Items i in cart.ItemsGetItems())
        {
            Console.WriteLine("{0}             ${1}", i.getDisplayTitle().PadRight(20), String.Format("{0:.##}", i.getDisplayPrice()));
        }
        Console.WriteLine("Subtotal: ${0}", cart.getAccumulatedPrice());
        Console.WriteLine("Sales Tax: ${0}", taxes);
        Console.WriteLine("Total: ${0}", String.Format("{0:.##}", cart.getAccumulatedPrice() + taxes));  //Entire purchase price + taxes
    }

}




