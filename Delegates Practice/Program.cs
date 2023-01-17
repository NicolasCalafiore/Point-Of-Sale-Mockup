
public delegate double CalculateTaxDelegate(int total);


class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter Total:");
        string total = Console.ReadLine();
        Console.WriteLine("Select State");
        Console.WriteLine("(A) FL");
        Console.WriteLine("(B) CA");
        Console.WriteLine("(C) CT");
        string selection = Console.ReadLine();

        CalculateTaxDelegate taxesDelegate = PlaceHolder;

        switch (selection){
            case ("A"):  taxesDelegate = FloridaTax; break;
            case ("B"):  taxesDelegate = CaliforniaTax; break;
            case ("C"):  taxesDelegate = ConnecticutTax; break;
        }

        double totalWithTaxes = taxesDelegate(Int32.Parse(total));
        Console.WriteLine("Your Total: " + totalWithTaxes);
    }

    public static double PlaceHolder(int total)
    {

        return -1;
    }
    public static double FloridaTax(int total)
    {
        return total + (total * .07);
    }

    public static double CaliforniaTax(int total)
    {
        return total + (total * .10);
    }

    public static double ConnecticutTax(int total)
    {
        return total + (total * .15);
    }
}




