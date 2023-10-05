using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickManager : MonoBehaviour
{
    public bool playerWalking;
    public Transform Player;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();   
    }
    public void GoToItem(DataItem item)
    {
        Player.GetComponent<SpriteAnimator>().PlayAnimation(gameManager.PlayerAnimations[1]);
        playerWalking = true;
        StartCoroutine(gameManager.MoveToPoint(Player, item.GoToPoint.position));
        TryGettingItem(item);
    }

    private void TryGettingItem(DataItem item)
    {
        bool canGetItem = item.RequiredItemID == -1 || gameManager.SelectedItemID == item.RequiredItemID;
        if (canGetItem)
        {
            GameManager.CollectedItems.Add(item);
        }
        StartCoroutine(UpdateSceneAfterAction(item, canGetItem));
    }

    private IEnumerator UpdateSceneAfterAction(DataItem item, bool canGetItem)
    {
        while (playerWalking)
            yield return new WaitForSeconds(0.05f);

        if (canGetItem) 
        {
            foreach (GameObject g in item.ObjectsToRemove)
            {
                Destroy(g);
                gameManager.UpdateEquipmentCanvas();
            }
        }
        else
        {
           gameManager.CheckSpecialConditions(item);
        }
        Player.GetComponent<SpriteAnimator>().PlayAnimation(null);
        yield return null;
    }
}
