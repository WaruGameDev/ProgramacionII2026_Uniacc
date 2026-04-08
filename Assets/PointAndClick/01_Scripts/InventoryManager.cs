using UnityEngine;
using System.Collections.Generic;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public List<ItemSO> inventoryItems = new List<ItemSO>();
    public Slot slot;
    public Transform inventoryUIParent;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;           
        }
    }
    void Start()
    {
        RefreshUI();
    }
    public void AddItem(ItemSO item)
    {
        if (!inventoryItems.Contains(item))
        {
            inventoryItems.Add(item);
            Debug.Log("Added to inventory: " + item.itemName);
        }
        RefreshUI();
    }
    public void RemoveItem(ItemSO item)
    {
        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
            Debug.Log("Removed from inventory: " + item.itemName);
        }
        RefreshUI();
    }
    public void RefreshUI()
    {
        foreach (Transform child in inventoryUIParent)
        {
            Destroy(child.gameObject);
        }
        // Implement UI refresh logic here, e.g., update inventory display
        foreach (var item in inventoryItems)
        {
            Slot slot = Instantiate(this.slot, inventoryUIParent); // Assuming you have a Slot prefab assigned in the Inspector
            slot.SetItem(item);
            Debug.Log("Inventory contains: " + item.itemName);
        }

    }

}
