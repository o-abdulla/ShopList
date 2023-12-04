Console.WriteLine("Welcome to Chirpus Market\n");

Dictionary<string, decimal> shoppingList = new Dictionary<string, decimal>();
shoppingList.Add("chicken breast", 22.59m);
shoppingList.Add("candy", 1.79m);
shoppingList.Add("chips", 2.49m);
shoppingList.Add("flowers", 14.99m);
shoppingList.Add("fruit basket", 9.45m);
shoppingList.Add("milk", 5.99m);

//foreach(KeyValuePair<string, decimal> kvp in shoppingList)
//{
//    Console.WriteLine(String.Format("{0,-20} {1,15}", kvp.Key, kvp.Value));
//}

List<string> cart = new List<string>();

bool runProgram = true;
while (runProgram)
{
    Console.WriteLine("What would you like to purchase today at Chirpus Market?");
    string input = Console.ReadLine().Trim().ToLower();
    if (shoppingList.ContainsKey(input))
    {
        cart.Add(input);
        Console.WriteLine($"You have successfully added {input} in your shopping cart.");
    }
    else
    {
        Console.WriteLine("Item does not exist. Please try again.");
        continue;
    }

    while (true)
    {
        Console.WriteLine("Would you like to continue shopping? Yes or No?");
        string response = Console.ReadLine().Trim().ToLower();

        if (response == "yes" || response == "y")
        {
            runProgram = true;
            break;
        }
        else if (response == "no" || response == "n")
        {
            if (cart.Count > 0)
            {
                decimal sum = 0;
                foreach (string i in cart)
                {
                    sum += shoppingList[i];
                }

                //receipt
                DisplayCart(cart, shoppingList);
                Console.WriteLine($"Your cart total comes out to a balance of ${sum}");

                //Console.WriteLine("");
                //foreach (string i in cart)
                //{
                //    Console.WriteLine(String.Format("{0,-20} {1,20}", i, shoppingList[i]));
                //}

                //Console.WriteLine($"You cart total comes out to a balance of ${sum}");
            }
            runProgram = false;
            break;
        }
        else
        {
            Console.WriteLine("Invalid input, try again.");
        }
    }
}


// Method for receipt
static void DisplayCart(List<string> cart, Dictionary<string, decimal> shoppingList)
{
    Console.WriteLine("\nCurrent Cart:");
    foreach(string i in cart)
    {
        Console.WriteLine($"{i,-20} {shoppingList[i],20}");
    }

    Console.WriteLine("------------------------");
    
}
