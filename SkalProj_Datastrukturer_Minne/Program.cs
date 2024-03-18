using System;

//Kopia från klass repo till mitt.
namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * '0': Exit to main menu
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            //1.
            //2. Listans kapacitet ökar när count == capacity och man försöker lägga till ett element.
            //3. Capacity ökar med 4
            //4. För att det skulle bli för mycket overhead att skapa en ny array varje gång man lägger till ett nytt element.
            //5. Nej, listans capacity förblir densamma.
            //6. När man vet antalet element som den ska innehålla.
            List<string> theList = new List<string>();

            bool continueLoop = true;

            while (continueLoop)
            {
                Console.WriteLine("\nPlease add or remove from list by using +(string) or -(string), 0 to exit\n");
                
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        Console.WriteLine($"\nBefore adding element. List count: {theList.Count}, List capacity: {theList.Capacity}");
                        theList.Add(value);
                        Console.WriteLine($"\nAfter adding element. List count: {theList.Count}, List capacity: {theList.Capacity}");
                        break;
                    case '-':
                        Console.WriteLine($"\nBefore removing element. List count: {theList.Count}, List capacity: {theList.Capacity}");
                        theList.Remove(value);
                        Console.WriteLine($"\nAfter removing element. List count: {theList.Count}, List capacity: {theList.Capacity}");
                        break;
                    case '0':
                        continueLoop = false;
                        break;                        
                    default:
                        Console.WriteLine("Please enter valid input (+(string), -(string) or 0 to exit.");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> theQueue = new Queue<string>();

            bool continueLoop = true;

            while (continueLoop)
            {
                Console.WriteLine("\nPlease add or remove from queue by using +(string) or -, 0 to exit\n");

                string input = Console.ReadLine();
                char nav = input[0];
                string value = "";
                if (input.Count() > 1)
                {
                    value = input.Substring(1);
                }

                switch (nav)
                {
                    case '+':
                        Console.WriteLine($"\nBefore adding element. Queue count: {theQueue.Count}");
                        theQueue.Enqueue(value);
                        Console.WriteLine($"\nAfter adding element. Queue count: {theQueue.Count}");
                        break;
                    case '-':
                        Console.WriteLine($"\nBefore removing element. Queue count: {theQueue.Count}");
                        if (theQueue.Count > 0)
                        {
                            string removedItem = theQueue.Dequeue();
                            Console.WriteLine($"\nAfter removing element. Queue count: {theQueue.Count}, removed from Queue : {removedItem}");
                        }
                        break;
                    case '0':
                        continueLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid input (+(string), -(string) or 0 to exit.");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        /// 1. För att den som kommer först till kön får vänta längst, så länge det kommer in nya köare så får dom som redan står i kön fortsätta köa.
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Stack<char> stack = new Stack<char>();

            Console.WriteLine("\nPlease enter string to reverse:\n");

            string input = Console.ReadLine();
            
            foreach(char c in input)
            {
                stack.Push(c);
            }

            string output = "";
            int stackCount = stack.Count;

            for(int i = 0; i < stackCount; i++)
            {
                output = output + stack.Pop();
            }

            Console.WriteLine($"\nReversed string : {output}\n");
        }

        //1. Stacken. För varje vänsterparentes pusha parentesen på stacken. För varje högerparentes, poppa från stacken & se så du får motsvarande vänsterparentes. Ifall inte, så är strängen fel
        //   När input är slut, se så att stacken är tom, ifall element kvar, är strängen fel.
        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            Stack<char> stack = new Stack<char>();

            Console.WriteLine("\nPlease enter string to check for parenthesis:\n");

            string input = Console.ReadLine();
            bool incorrect = false;

            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                if(c == ')')
                {
                    var popped = stack.Pop();
                    if (popped != '(')
                    {
                        incorrect = true;
                        break;                        
                    }
                }
                if (c == ']')
                {
                    var popped = stack.Pop();
                    if (popped != '[')
                    {
                        incorrect = true;
                        break;
                    }
                }
                if (c == '}')
                {
                    var popped = stack.Pop();
                    if (popped != '{')
                    {
                        incorrect = true;
                        break;
                    }
                }
            }
            if(stack.Count != 0)
            {
                incorrect = true;
            }

            if (incorrect) {
                Console.WriteLine("\nIncorrect parenthesis in input string\n");
            }
            else
            {
                Console.WriteLine("\nWelformed string.\n");
            }
        }

    }
}

