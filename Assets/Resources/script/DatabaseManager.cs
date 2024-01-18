using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    static public DatabaseManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }



    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;

    public List<item> itemList = new List<item>();

    // Start is called before the first frame update
    void Start()
    {
        itemList.Add(new item(10001, "���", "����", item.ItemType.Use));
        itemList.Add(new item(10002, "�丶��", "����", item.ItemType.Use));
        itemList.Add(new item(10003, "����", "����", item.ItemType.Use));
        itemList.Add(new item(20001, "�⺻����ƺ�", "����ƺ�", item.ItemType.Use));
        itemList.Add(new item(20002, "ȣ������ƺ�", "����ƺ�", item.ItemType.Use));
        itemList.Add(new item(20003, "���������ƺ�", "����ƺ�", item.ItemType.Use));
        itemList.Add(new item(30001, "��� ����", "����", item.ItemType.Use));
        itemList.Add(new item(30002, "�丶�� ����", "����", item.ItemType.Use));
        itemList.Add(new item(30003, "���� ����", "����", item.ItemType.Use));
    }
}
