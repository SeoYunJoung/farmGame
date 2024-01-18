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
        itemList.Add(new item(10001, "´ç±Ù", "À½½Ä", item.ItemType.Use));
        itemList.Add(new item(10002, "Åä¸¶Åä", "À½½Ä", item.ItemType.Use));
        itemList.Add(new item(10003, "µþ±â", "À½½Ä", item.ItemType.Use));
        itemList.Add(new item(20001, "±âº»Çã¼ö¾Æºñ", "Çã¼ö¾Æºñ", item.ItemType.Use));
        itemList.Add(new item(20002, "È£¹ÚÇã¼ö¾Æºñ", "Çã¼ö¾Æºñ", item.ItemType.Use));
        itemList.Add(new item(20003, "´«»ç¶÷Çã¼ö¾Æºñ", "Çã¼ö¾Æºñ", item.ItemType.Use));
        itemList.Add(new item(30001, "´ç±Ù ¾¾¾Ñ", "¾¾¾Ñ", item.ItemType.Use));
        itemList.Add(new item(30002, "Åä¸¶Åä ¾¾¾Ñ", "¾¾¾Ñ", item.ItemType.Use));
        itemList.Add(new item(30003, "µþ±â ¾¾¾Ñ", "¾¾¾Ñ", item.ItemType.Use));
    }
}
