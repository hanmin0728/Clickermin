using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User
{
    public string userName;
    public long energy;
    public long ePc = 100; //클릭당 에너지



    public List<Soldier> soldierList = new List<Soldier>();
    

}
