using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    //��ȭ ������ ���� ���� talkData ����
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData(); //��ȭ ������ �ޱ�
    }

    //��ȭ ������ �����
    void GenerateData()
    {
        //��ȭ
        talkData.Add(10, new string[] {"�ȳ�?", "�װ� �� ���� ���� �� ��α���?"});

        //�ʻ�ȭ
        //portraitData.Add(10 + 0,);
        //B23 - 29:02
    }

    //��ȭ �����͸� �޾��ִ� �Լ�
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null; //��簡 �����ٸ� null ����
        }
        else
        {
            return talkData[id][talkIndex]; //�� ���徿 return
        }
    }
}
