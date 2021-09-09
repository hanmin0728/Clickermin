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

    private Soldier soldier = null;
    public void SetValue(Soldier soldier)
    {
        soldierNameText.text = soldier.soldierName;
        priceText.text = string.Format("{0} ������", soldier.price);
        amountText.text = string.Format("{0}", soldier.amount);
        this.soldier = soldier;
    }
}