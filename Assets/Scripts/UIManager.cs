using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text energyText = null;

    [SerializeField]
    private Text totalEpsText = null;

    [SerializeField]
    private Animator beakerAnimator;


    [SerializeField]
    private GameObject upgradePanelTemplate = null;

    private List<UpgradePanel> upgradePanels = new List<UpgradePanel>();

    [SerializeField]
    private EneryText eneryTextTemplete = null;
    [SerializeField]
    private Transform pool;
    private void Start()
    {
        UpdateEnergyPanel();
        CreatPanels();
    }

    private void CreatPanels()
    {
        GameObject newPanel = null;
        UpgradePanel newPanelComponent = null;
        foreach (Soldier soldier in GameManager.Instance.CurrentUser.soldierList)
        {
            newPanel = Instantiate(upgradePanelTemplate, upgradePanelTemplate.transform.parent);
            newPanelComponent = newPanel.GetComponent<UpgradePanel>();
            newPanelComponent.SetValue(soldier);
            newPanel.SetActive(true);
            upgradePanels.Add(newPanelComponent);
        }
    }
    public void OnClickBeaker()
    {
        GameManager.Instance.CurrentUser.energy += GameManager.Instance.CurrentUser.ePc;
        UpdateEnergyPanel();
        beakerAnimator.Play("click");
        EneryText newText = null;
        if (pool.childCount > 0)
        {
            newText = pool.GetChild(0).GetComponent<EneryText>();
        }
        else
        {
            newText = Instantiate(eneryTextTemplete, eneryTextTemplete.transform.parent);
        }
        newText.Show(Input.mousePosition);
    }

    public void UpdateEnergyPanel()
    {
        energyText.text = string.Format("{0} 에너지", GameManager.Instance.CurrentUser.energy);
        totalEpsText.text = string.Format("{0}원/초 ", GameManager.Instance.TotalEps);
        Debug.Log(GameManager.Instance.TotalEps);
    }
}
