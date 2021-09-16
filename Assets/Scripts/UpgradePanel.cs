using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    private Text soldierNameText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Text amountText = null;
    [SerializeField]
    private Button purchaseButton = null;
    [SerializeField]
    private Image soliderImage = null; // 유니티 ui 액자같은느낌
    [SerializeField]
    private Sprite[] soliderSprite; // 그림 

    private Soldier soldier = null;
    public void SetValue(Soldier soldier)
    {
        this.soldier = soldier;
        UpdateUI();
        
    }
    public void UpdateUI()
    {
        soldierNameText.text = soldier.soldierName;
        priceText.text = string.Format("{0} 에너지", soldier.price);
        amountText.text = string.Format("{0}", soldier.amount);
        soliderImage.sprite = soliderSprite[soldier.soldierNumber];
        
    }
    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.energy < soldier.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.energy -= soldier.price;
        soldier.price = (long)(soldier.price * 1.25);

        soldier.amount++;
        UpdateUI();
        GameManager.Instance.UI.UpdateEnergyPanel();

    }
}
