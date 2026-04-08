using UnityEngine;

public class ItemToRecollect : MonoBehaviour, IClickable
{
    public ItemSO itemToRecollect;

    public void OnClick()
    {
        InventoryManager.Instance.AddItem(itemToRecollect);
        Destroy(gameObject, 0.1f);
    }
    
}
