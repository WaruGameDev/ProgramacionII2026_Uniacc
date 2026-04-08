using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemSO item;
    public Image itemImage;

    public void SetItem(ItemSO newItem)
    {
        item = newItem;
        itemImage.sprite = item.itemSprite;
        // Update UI or visuals here if needed
    }

    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        // Update UI or visuals here if needed
    }
}
