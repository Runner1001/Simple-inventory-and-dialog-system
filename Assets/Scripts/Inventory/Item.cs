using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item", fileName = "Item")]
public class Item : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public int MaxStackSize;
    public ObjectType ObjectType;
}

public enum ObjectType
{
    Hoe,
    Axe,
    Mushroom
}
