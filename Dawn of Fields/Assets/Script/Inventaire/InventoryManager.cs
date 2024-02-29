using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Liste pour stocker les objets de l'inventaire
    public List<Item> inventory = new List<Item>(10);

    public void AddItem(Item item)
    {
        inventory.Add(item);
        Debug.Log($"L'item {item.name} a été ajouté de l'inventaire avec reussite !");
    }

    public void RemoveItem(Item item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            Debug.Log($"L'item {item.name} a été enlevé de l'inventaire avec reussite !");
        }
        else
        {
            Debug.Log($"L'item n'existe pas : {item.name}");
        }
        
    }

    public void ClearInventory()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            RemoveItem(inventory[i]);
        }
        Debug.Log("L'inventaire a été vidé !");
    }

    public void displayInventory()
    {

    }

    // Vous pouvez ajouter d'autres fonctions liées à la gestion de l'inventaire ici
}