using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wearable Item", menuName = "Item/Wearable")]
public class Wearable : Item
{
    public ClothingType clothingType;
}

public enum ClothingType {HAT, TORSO}
