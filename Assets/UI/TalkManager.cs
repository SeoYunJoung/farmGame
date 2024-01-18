using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    //대화 데이터 저장 변수 talkData 정의
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData(); //대화 데이터 받기
    }

    //대화 데이터 저장소
    void GenerateData()
    {
        //대화
        talkData.Add(10, new string[] {"안녕?", "네가 이 곳에 새로 온 농부구나?"});

        //초상화
        //portraitData.Add(10 + 0,);
        //B23 - 29:02
    }

    //대화 데이터를 받아주는 함수
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null; //대사가 끝났다면 null 리턴
        }
        else
        {
            return talkData[id][talkIndex]; //한 문장씩 return
        }
    }
}
