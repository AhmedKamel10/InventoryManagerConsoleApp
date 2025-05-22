using InventoryManagementSystem.Models;
using myconsoleapp.Helpers;
namespace InventoryManagementSystem
{
    public class InventoryManager
    {
        private List<Item> items = new();
        public void AddItem(Item item)
        {
            items.Add(item);
            Logger.Log($"Added item: {item.Name}");

        }
        public void ListItems()
        {
            foreach (var item in items)
            {
                item.DisplayInfo(); //this function is public in the models
            }
        }
        public void RemoveItmes(int id)
        {
            Item? foundItem = null;

            foreach (var i in items)
            {
                if (i.Id == id)
                {
                    foundItem = i;
                    break;
                }
            }
            if (foundItem != null)
            {
                items.Remove(foundItem);
                Console.WriteLine($"item with id {id} removed");
            }
            else
            {
                Console.WriteLine($"item with id {id} not found");
    
            }
        }

        
    }
}