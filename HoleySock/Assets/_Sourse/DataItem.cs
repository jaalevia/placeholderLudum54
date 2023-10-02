using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataItem : MonoBehaviour
{
    public Transform GoToPoint;
    public int ItemID, RequiredItemID;
    public GameObject[] ObjectsToRemove;
    public string ObjectName;
    public Vector2 NameTagSize = new Vector2(3, 0.65f);
    public Sprite ItemSlotSprite;
    public string ItemName;
    public Vector2 ItemNameTagSize = new Vector2(3, 0.65f);

}
