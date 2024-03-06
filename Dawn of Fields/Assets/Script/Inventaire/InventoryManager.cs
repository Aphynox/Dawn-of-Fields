using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // Liste pour stocker les objets de l'inventaire
    public List<ItemData> inventory = new List<ItemData>();
    public int maxSize;
    public int maxStack;

    [SerializeField]
    private GameObject inventoryPanel;

    [SerializeField]
    private Transform inventorySlotsParent;


    private void Update()
    {
        DisplayInventory();
    }

    public void AddItem(ItemData item)
    {

        ItemData existingItem = inventory.Find(i => i.id == item.id);

        if(existingItem != null)
        {
            existingItem.quantite++;
            Debug.Log($"L'item {item.name} a été ajouté à la pile existante dans l'inventaire. Nouvelle taille de la pile : {existingItem.quantite}");
            RefreshContent();
        }
        else
        {
            if (!IsFull())
            {
                ItemData newItem = Instantiate(item);
                inventory.Add(newItem);
                RefreshContent();
                Debug.Log($"L'item {item.name} a été ajouté de l'inventaire avec reussite !");
            }
            else
            {
                Debug.LogWarning($"L'inventaire est pleins !");
            }
        }       
    }

    public void RemoveItem(ItemData item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            Debug.Log($"L'item {item.name} a été enlevé de l'inventaire avec reussite !");
        }
        else
        {
            Debug.LogWarning($"L'item n'existe pas : {item.name}");
        }
        
    }

    private void RefreshContent()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            inventorySlotsParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = inventory[i].icon;
            inventorySlotsParent.GetChild(i).GetChild(1).GetComponent<Text>().text = "x" + inventory[i].quantite.ToString();
        }
    }


    public bool IsFull()
    {
        return inventory.Count == maxSize;
    }

    public void ClearInventory()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            RemoveItem(inventory[i]);
        }
        Debug.Log("L'inventaire a été vidé !");
    }

    public void DisplayInventory()
    {

        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }

    }

    // Vous pouvez ajouter d'autres fonctions liées à la gestion de l'inventaire ici
}