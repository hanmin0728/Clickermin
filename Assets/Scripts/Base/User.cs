using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User
{
    public string userName;
    public long energy;
    public long ePc = 1; //Ŭ���� ������
    public List<Soldier> soldierList = new List<Soldier>();

}
