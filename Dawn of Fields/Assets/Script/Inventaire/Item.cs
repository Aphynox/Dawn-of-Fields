using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Items/New item")] 
public class Item : ScriptableObject
{

    public string name;
    public string description;
    public Sprite icon;
    public GameObject prefab;

    
}
