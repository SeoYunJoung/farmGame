using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    //��ȭ ������ ���� ���� talkData ����
    Dictionary<int, string[]> talkData;
    //�ʻ�ȭ ������ ���� ���� portraitData ����
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
        //��ȭ (���� - "����:ǥ���ε���")
        talkData.Add(10, new string[] {"�ȳ�?:0", "�װ� �� ���� ���� �� ��α���?:1"});

        //�ʻ�ȭ
        portraitData.Add(10 + 0, portraitArr[0]);
        portraitData.Add(10 + 1, portraitArr[1]);
        portraitData.Add(10 + 2, portraitArr[2]);
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

    //�ʻ�ȭ id �ޱ�
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
