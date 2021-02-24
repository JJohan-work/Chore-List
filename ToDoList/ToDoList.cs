using System;
using System.Collections.Generic;
using ToDoList.Models;
namespace ToDoList
{
  public class Program
  {

    

  
    public static void Main() 
    {
      Console.WriteLine("Welcome to the To Do List.");
      SelectFunction();
    
    }

    public static void SelectFunction()
    {
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.Write("Would you like to add, view, or finish an item on your list (Add/View/Finish/Close): ");
      Console.ForegroundColor = ConsoleColor.White;
      string input = Console.ReadLine();
      int count = 1;
      
      if (input.ToLower() == "add")
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You selected add");
        addItem();
      }
      else if (input.ToLower() == "view")
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You selected View");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        foreach(Item obj in Item.GetAll()) {
          Console.WriteLine($"{count}. {obj.Description.ToString()}");
          count++;
        }
        Console.ForegroundColor = ConsoleColor.White;
        count = 0;
        SelectFunction();
      }
      else if (input.ToLower() == "finish")
      {
        removeItem();
      }
      else if (input.ToLower() ==  "close")
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Finished. Have a good day!");
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Input not valid. Please input add or view.");
        SelectFunction();
      }
    }

    public static void addItem() {
      Console.Write("Please enter the description for the new Item: ");
      string description = Console.ReadLine();
      Item newItem = new Item(description);
      Console.Write($"'{description}' has been added to your list. ");
      SelectFunction();
    }

    public static void removeItem() {
      List<Item> tempList = Item.GetAll();
      Console.ForegroundColor = ConsoleColor.DarkCyan;
      for(int i = 0; i < tempList.Count; i++) {

        Console.WriteLine($"{i + 1}. {tempList[i].Description.ToString()}");

      }
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("Which Task has been completed? (Enter Number): ");
      int removeIndex = int.Parse(Console.ReadLine());

      Console.WriteLine($"Finished item {removeIndex}: {tempList[removeIndex-1].Description.ToString()}");
      tempList.RemoveAt(removeIndex-1);
      Item.SetAll(tempList);
      

      SelectFunction();
    }
  }
}

// Program: Welcome to the To Do List.
// Program: Would you like to add an item to your list or view your list? (Add/View)
// User: Add
// Program: Please enter the description for the new item.
// User: Walk the dog.
// Program: 'Walk the dog' has been added to your list. Would you like to add an item to your list or view your list? (Add/View)
// User: View
// Program: 1. Walk the dog.
// Program: Would you like to add an item to your list or view your list? (Add/View)