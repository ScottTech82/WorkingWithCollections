
//WorkingWithLists();
//WorkingWithDictionaries();
//WorkingWithQueues();
WorkingWithPriorityQueues();

static void Output(string title, IEnumerable<string> collection)
{
    Console.WriteLine(title);
    foreach (string item in collection)
    {
        Console.WriteLine($"  {item}");
    }
    
}

static void WorkingWithLists()
{
    List<string> cities = new();
    cities.Add("London");
    cities.Add("Paris");
    cities.Add("Milan");

    Output("Initial list", cities);

    Console.WriteLine($"The first city is {cities[0]}.");
    Console.WriteLine($"The last city is {cities[cities.Count - 1]}");

    cities.Insert(0, "Sydney");

    Output("After inserting Syndney at index 0", cities);

    cities.RemoveAt(1);
    cities.Remove("Milan");

    Output("After removing two cities", cities);
}

static void WorkingWithDictionaries()
{
    Dictionary<string, string> keywords = new();

    //add using named parameters
    keywords.Add(key: "int", value:"32-bit integer data type");

    //add using positional parameters
    keywords.Add("long","64-bit integer data type");
    keywords.Add("float","single precision floating point number");

    Output("Dictionary keys:", keywords.Keys);
    Output("Dictionary values:", keywords.Values);

    Console.WriteLine($"Keywords and their definitions");
    foreach (KeyValuePair<string, string> item in keywords)
    {
        Console.WriteLine($"   {item.Key} : {item.Value}");
    }
        //lookup a value using a key
        string key = "long";
        Console.WriteLine($"The definition of {key} is {keywords[key]}");

}

static void WorkingWithQueues()
{
    Queue<string> coffee = new();

    coffee.Enqueue("Damir"); //front of queue
    coffee.Enqueue("Andrea");
    coffee.Enqueue("Ronald");
    coffee.Enqueue("Amin");
    coffee.Enqueue("Irina"); //back of queue

    Output("Intitial queue from front to back", coffee);

    //server handles next person in queue
    string served = coffee.Dequeue();
    Console.WriteLine($"Served: {served}.");
    Output("Current queue from front to back", coffee);
    
    Console.WriteLine($"{coffee.Peek()} is next in line.");
    Output("current queue from front to back", coffee);
}

static void OutputPQ<TElement, TPriority>(string title, 
    IEnumerable<(TElement Element, TPriority Priority)> collection)
{
    Console.WriteLine(title);
    foreach ((TElement, TPriority) item in collection) 
    {
    Console.WriteLine($" {item.Item1} : {item.Item2}");
    }
}

static void WorkingWithPriorityQueues()
{
    PriorityQueue<string, int> vaccine = new();

    //add some people
    //1 = High priority people in their 70s or poor health
    //2 = medium priority people e.g. middle aged
    //3 = low priority e.g. teens and twenties
    vaccine.Enqueue("Pamela", 1);  //70's
    vaccine.Enqueue("Rebecca", 3); //teen
    vaccine.Enqueue("Juliet", 2); //40s
    vaccine.Enqueue("ian", 1);  // 70's

    OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);

    Console.WriteLine($"{vaccine.Dequeue()} has been vaccinated");
    Console.WriteLine($"{vaccine.Dequeue()} has been vaccinated");

    OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);

    Console.WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

    vaccine.Enqueue("Mark", 2);
    Console.WriteLine($"{vaccine.Peek()} will be next to be vaccinated.");

    OutputPQ("Current queue for vaccination :", vaccine.UnorderedItems);

}