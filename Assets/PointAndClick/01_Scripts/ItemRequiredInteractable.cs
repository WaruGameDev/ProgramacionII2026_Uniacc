using System.Collections.Generic;
using UnityEngine;

public class ItemRequiredInteractable : MonoBehaviour, IClickable
{
    public List<ItemSO> requiredItem; // The item required to interact with this object
    public void OnClick()
    {
        // Check if the player has the required item in their inventory
        //* Get the required item for this interactable */;
        foreach (var item in requiredItem)
        {
            if(!InventoryManager.Instance.HasItem(item))
            {
                Debug.Log("You need the " + item.itemName + " to interact with this.");
                // Implement feedback logic here (e.g., show a message to the player)
                return; // Exit if any required item is missing
            }
            Debug.Log("You have the " + item.itemName + ". You can interact with this.");
        }
        // Implement interaction logic here (e.g., open a door, pick up an object, etc.)
        Debug.Log("Interacted with the object successfully!"); // Placeholder for successful interaction feedback
       
    }

    
}
