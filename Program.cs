using System;

namespace Boyd_LinkedListSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            stopwatch sw = new stopwatch();
            LinkedList programList = new LinkedList(sw);

            int userInput;
            Console.WriteLine("add items to list and look at list");

            while (true)
            {


                Console.WriteLine();
                Console.WriteLine("1.Search for a Name");
                Console.WriteLine("2.Search for a Name with gender");
                Console.WriteLine("3.Add a name");
                Console.WriteLine("4.See most popular female name");
                Console.WriteLine("5.See most popular male name");
                Console.WriteLine("6.See total number of names");
                Console.WriteLine("7.See total number of female names");
                Console.WriteLine("8.See total number of Male names");
                Console.WriteLine("9.exit");
                userInput = parseinput();
                UserOptions(userInput, programList,sw);
                Console.WriteLine();
                if (userInput == 9)
                    break;
            }
        }

        static void UserOptions(int number, LinkedList List, stopwatch timer)
        {

            switch (number)
            {

                case 1:
                    Console.WriteLine("please enter the name you would like to search for.");
                    searchName(List, timer);
                    break;
                case 2:
                    Console.WriteLine("please enter the name you would like to search for.");
                    searchNameAndGender(List, timer);
                    break;
                case 3:
                    userAddName(List, timer);
                    break;
                case 4:
                    Console.WriteLine(List.getMostPopFemale()); 
                    break;
                case 5:
                    Console.WriteLine(List.getMostPopMale());
                    break;
                case 6:
                    Console.WriteLine(List.getTotalNodes());
                    break;
                case 7:
                    Console.WriteLine(List.getTotalFemaleNodes());
                    break;
                case 8:
                    Console.WriteLine(List.getTotalMaleNodes());
                    break;
                case 9:
                    Console.WriteLine();
                    break;

            }
        }
        public static void searchName(LinkedList List , stopwatch timer) 
        {
            string name = getUserName();
            timer.startTimer();
            Node searchedName = List.search(name);
            timer.stopTimer();
            if (searchedName == null)
            {
                Console.WriteLine("time taken to not find this name was " + timer.outputTime());
                Console.WriteLine(name + " was not found in our list would you like to add it? \n if so press Y");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    userAddName(List, name,timer);
                }
            }
            else
            {
                Console.WriteLine("time taken to find this node was" + timer.outputTime());
                string nameData = searchedName.getUserInfo();
                Console.WriteLine(nameData);
            }
            
        }
        public static void searchNameAndGender(LinkedList List, stopwatch timer)
        {
            string name = getUserName();
            timer.startTimer();
            Console.WriteLine("Please enter the gender for the person only M or F.");
            string gender = getUserGender();
            Console.WriteLine();
            Node searchedName = List.search(name, gender);
            timer.stopTimer();
            if (searchedName == null)
            {
                Console.WriteLine("time taken to not find this name was " + timer.outputTime());
                Console.WriteLine(name + " was not found in our list would you like to add it? \n if so press Y");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    userAddName(List, name, timer);
                }
            }
            else
            {
                Console.WriteLine("time taken to find this node was" + timer.outputTime());
                string nameData = searchedName.getUserInfo();
                Console.WriteLine(nameData);
            }

        }
        public static void userAddName(LinkedList List, stopwatch timer)
        {
            Console.WriteLine("Please enter the name you would like to add to the list.");
            string name = getUserName();
            userAddName(List, name,timer);
        }

        public static void userAddName(LinkedList List, string name, stopwatch timer)
        {
            Console.WriteLine("Please enter the gender for your person only M or F.");
            string gender = getUserGender();
            Console.WriteLine();
            Console.WriteLine("Please enter how popular the name is using numbers.");
            int popularity = parseinput();
            Node userAdded = List.search(name, gender);
            //if name entered did not exist
            if (userAdded == null)
            {
                Console.WriteLine("That name was not found in the list it has been added to the list.");
                timer.startTimer();
                List.add(name, gender, popularity);
                timer.stopTimer();
                Console.WriteLine("time taken to add this node was "+timer.outputTime());
            }
            else if (userAdded != null)//if name does exist
            {

                
                    Console.WriteLine("that name is currently in the list, would you like to add it with a suffex of _1? \n press y if you want to add them");

                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Console.WriteLine(name + " will be entered with _1 suffex thank you for your response");
                        name = name + "_1";
                        timer.startTimer();
                        List.add(name, gender, popularity);
                        timer.stopTimer();
                        Console.WriteLine("time taken to add this node with suffex was " + timer.outputTime());
                    }
                    else
                    {
                        Console.WriteLine(name + " was not added with the suffex");
                    }
                    return;
                

            }
        }

       public static int parseinput()
        {
            int number;
            while (true)
            {
                bool success = Int32.TryParse(Console.ReadLine(), out number);
                if (success)
                {
                    Console.WriteLine();
                    return number;
                }
                else
                {
                    Console.WriteLine("error not a valid value try again");
                }
            }
        }
        public static string getUserName()
        {
            string userItem;
            userItem = Console.ReadLine();

            return userItem.ToUpper();
        }
        public static string getUserGender()
        {

            Console.WriteLine("please press M or F key for male or female.");
            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey();
                if (input.Key == ConsoleKey.M)
                {
                    return "M";
                }
                else if (input.Key == ConsoleKey.F)
                {
                    return "F";
                }

                Console.WriteLine("please only use M or F keys");
            }

        }
    }
}

