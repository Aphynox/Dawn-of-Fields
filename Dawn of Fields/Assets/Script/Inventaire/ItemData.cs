using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Items/New item")] 
public class ItemData : ScriptableObject
{

    public string nom;
    public string description;
    public int quantite;
    public int id;
    public Sprite icon;
    public GameObject prefab;

    
}
