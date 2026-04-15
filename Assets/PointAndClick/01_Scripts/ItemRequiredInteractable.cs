using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemRequiredInteractable : MonoBehaviour, IClickable
{
    [Header("Item Requirements")]
    public List<ItemSO> requiredItem; // The item required to interact with this object
    [Header("Interaction Settings")]
    public bool consumeItem = false; // Whether the item should be consumed upon interaction
    [Header("Interaction Events")]
    public UnityEvent onSuccessfulInteraction; // Event triggered when interaction is successful
    public UnityEvent onFailedInteraction; // Event triggered when interaction fails
    public void OnClick()
    {
        // Check if the player has the required item in their inventory
        //* Get the required item for this interactable */;
        foreach (var item in requiredItem)
        {
            if(!InventoryManager.Instance.HasItem(item))
            {
                Debug.Log("You need the " + item.itemName + " to interact with this.");
                    onFailedInteraction?.Invoke(); // Trigger the failed interaction event
                // Implement feedback logic here (e.g., show a message to the player)
                return; // Exit if any required item is missing
            }
            Debug.Log("You have the " + item.itemName + ". You can interact with this.");
        }
        onSuccessfulInteraction?.Invoke(); // Trigger the successful interaction event
        // Implement interaction logic here (e.g., open a door, pick up an object, etc.)
        Debug.Log("Interacted with the object successfully!"); // Placeholder for successful interaction feedback
        if (consumeItem)
        {
            foreach (var item in requiredItem)
            {
                InventoryManager.Instance.RemoveItem(item);
            }
        }
    }

    
}
