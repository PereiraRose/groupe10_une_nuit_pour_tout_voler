using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory; // Référence au script Inventory
    public Image[] inventorySlots; // Références aux images UI
    public List<Sprite> allPaintingSprites; // Liste de toutes les images possibles

    void Start()
{
    if (inventory != null)
    {
        inventory.InventoryChanged += UpdateInventoryUI;
    }
    UpdateInventoryUI();
}


    public void UpdateInventoryUI()
{
    List<string> paintingsToSteal = inventory.GetPaintingsToSteal();

    for (int i = 0; i < inventorySlots.Length; i++)
    {
        if (i < paintingsToSteal.Count)
        {
            string paintingName = paintingsToSteal[i];

            // Vérifie si le tableau est déjà dans l'inventaire du joueur
            if (inventory.PlayerInventory.Contains(paintingName))
            {
                inventorySlots[i].enabled = false; // Cache l'image si déjà récupérée
                continue;
            }

            Sprite paintingSprite = allPaintingSprites.Find(s => s.name == paintingName);
            if (paintingSprite != null)
            {
                inventorySlots[i].sprite = paintingSprite;
                inventorySlots[i].enabled = true;
            }
            else
            {
                inventorySlots[i].enabled = false;
            }
        }
        else
        {
            inventorySlots[i].enabled = false;
        }
    }
}

}
