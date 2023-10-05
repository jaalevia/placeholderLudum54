using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    public static List<DataItem> CollectedItems = new List<DataItem>();
    static float _moveSpeed = 3.5f, _moveAccuracy = 0.15f;
    public RectTransform NameTag;
    public Image BlockingImage;
    public GameObject[] LocalScenes;
    int _activeLocalScene = 0;
    public Transform[] PlayerStartPositions;
    public GameObject EquipmentCanvas;
    public Image[] EquipmentSlots, EquipmentImages;
    public Sprite EmptyItemSlotSprite;
    public Color SelectedItemColor;
    public int SelectedCanvasSlot = 0, SelectedItemID = 1;
    public AnimationData[] PlayerAnimations;
    public GameObject LeftLight;
    public GameObject RightLight;
    public IEnumerator MoveToPoint(Transform myObject, Vector2 point)
    {
        Vector2 positionDifference = point - (Vector2)myObject.position;

        if (myObject.GetComponentInChildren<SpriteRenderer>() && positionDifference.x != 0)
        {
            LeftLight.SetActive(true);
            RightLight.SetActive(false);
            myObject.GetComponentInChildren<SpriteRenderer>().flipX = positionDifference.x > 0;
            if (myObject.GetComponentInChildren<SpriteRenderer>().flipX = positionDifference.x > 0)
            {
                LeftLight.SetActive(false);
                RightLight.SetActive(true);
            }
        }
        while (positionDifference.magnitude > _moveAccuracy)
        {
            myObject.Translate(_moveSpeed * positionDifference.normalized * Time.deltaTime);
            positionDifference = point - (Vector2)myObject.position;
            yield return null;
        }

        myObject.position = point;

        if (myObject == FindObjectOfType<ClickManager>().Player)
        {
            FindObjectOfType<ClickManager>().playerWalking = false;
        }

        yield return null;
    }

    public void SelectItem(int equipmentCanvasID)
    { 
        Color c = Color.white;
        c.a = 0;
        EquipmentSlots[SelectedCanvasSlot].color = c;
        if (equipmentCanvasID >= CollectedItems.Count || equipmentCanvasID < 0)
        {
            SelectedItemID = -1;
            SelectedCanvasSlot = 0;
            return;
        }
        EquipmentSlots[equipmentCanvasID].color = SelectedItemColor;
        SelectedCanvasSlot = equipmentCanvasID;
        SelectedItemID = CollectedItems[SelectedCanvasSlot].ItemID;
    }
    public void ShowItemName(int equipmentCanvasID)
    {
        if (equipmentCanvasID < CollectedItems.Count)
        {
            UpdateNameTag(CollectedItems[equipmentCanvasID]);
        }
    }

    public void UpdateEquipmentCanvas()
    {
        int itemsAmount = CollectedItems.Count, itemSlotsAmount = EquipmentSlots.Length;
        for (int i = 0; i < itemSlotsAmount; i++)
        {
            if (i < itemsAmount && CollectedItems[i].ItemSlotSprite != null)
            {
                EquipmentImages[i].sprite = CollectedItems[i].ItemSlotSprite;
                
            }
            else
            {
                EquipmentImages[i].sprite = EmptyItemSlotSprite;
            }
        }
        if (itemsAmount == 0)
        {
            SelectItem(-1);
        }
        else if (itemsAmount == 1)
        {
            SelectItem(0);
        }
    }    
    public void UpdateNameTag(DataItem item) 
    {
        if (item == null)
        { 
            NameTag.parent.gameObject.SetActive(false);
            return;
        }
        NameTag.parent.gameObject.SetActive(true);

        string nameText = item.ObjectName;
        Vector2 size = item.NameTagSize;

        if (CollectedItems.Contains(item))
        {
            nameText = item.ItemName;
            size = item.ItemNameTagSize;
        }
        NameTag.GetComponentInChildren<TextMeshProUGUI>().text = nameText;
        NameTag.sizeDelta = size;
        NameTag.localPosition = new Vector2(size.x / 2, -0.5f);
    }

    public void CheckSpecialConditions(DataItem Item,bool canGetItem)
    { 
        switch (Item.ItemID) 
        {
            case -11:
                StartCoroutine(ChangeScene(0, 0));
                break;
            case -12:
                StartCoroutine(ChangeScene(1, 0));
                break;
            case -13:
                StartCoroutine(ChangeScene(2, 0));
                break;
            case -14:
                StartCoroutine(ChangeScene(3, 0));
                break;
            case -15:
                StartCoroutine(ChangeScene(4, 0));
                break;
        }
    }

    public IEnumerator ChangeScene(int SceneNumber, float delay)
    {
        yield return new WaitForSeconds(delay);
        Color c = BlockingImage.color;

        BlockingImage.enabled = true;
        while (BlockingImage.color.a < 1) 
        {
            c.a += Time.deltaTime;
            BlockingImage.color = c;
        }

        LocalScenes[_activeLocalScene].SetActive(false);
        LocalScenes[SceneNumber].SetActive(true);
        _activeLocalScene = SceneNumber;
        FindObjectOfType<ClickManager>().Player.position = PlayerStartPositions[SceneNumber].position;



        foreach (SpriteAnimator spriteAnimator in FindObjectsOfType<SpriteAnimator>())
        {
            spriteAnimator.PlayAnimation(null);
        }

        while (BlockingImage.color.a < 0)
        {
            c.a -= Time.deltaTime;
            BlockingImage.color = c;
        }
        BlockingImage.enabled = false;
        yield return null;
    }

}
