using System.IO; // 파일 폴더 만들고 지우고 가능 input output줄인거
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";

    public float totalEps;
        
    private UIManager uiManager = null;
    public UIManager UI
    {
        get
        {
            return uiManager;
        }
    }

    [SerializeField]
    private User user = null;
    public User CurrentUser
    {
        get
        {
            return user;
        }
    }

    private void Awake()
    {
        SAVE_PATH = Application.dataPath + "/Save"; // 안드로이드 빌드시 Application.persistentDataPath
        if (Directory.Exists(SAVE_PATH) == false)
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        InvokeRepeating("SaveToJson", 1f, 60f);
        InvokeRepeating("EarnEnergyPerSecond",0f, 1f);
        InvokeRepeating("EnergyPerClick", 0f, 1f);
        LoadFromJson();
        uiManager = GetComponent<UIManager>();
    }
    public float TotalEps
    {
        get
        {
            totalEps = 0;
            foreach (Soldier soldier in CurrentUser.soldierList)
            {
                totalEps += soldier.ePs * soldier.amount;
            }
            Debug.Log(totalEps);
            return totalEps;
        }
    }
    private void EnergyPerClick()
    {
        uiManager.UpdateEnergyPanel();
    }
    private void EarnEnergyPerSecond()
    {
        foreach (Soldier solider in user.soldierList)
        {
            user.energy += solider.ePs * solider.amount;
        }
        UI.UpdateEnergyPanel();
    }

    private void LoadFromJson()
    {
        string json = "";
        if (File.Exists(SAVE_PATH + SAVE_FILENAME) == true)
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
    }

    private void SaveToJson()
    {
        SAVE_PATH = Application.dataPath + "/Save";
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }
    private void OnApplicationQuit()
    {
        SaveToJson();
    }
}
