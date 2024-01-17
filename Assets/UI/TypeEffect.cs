using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    string targetMsg; //문자열 변수
    public int CharPerSeconds; //문자열 재생 속도
    public GameObject EndCursor;
    public Text msgText; //대화 텍스트 가져오기
    int index; //대화 텍스트 index
    float interval;


    private void Awake()
    {
        msgText = GetComponent<Text>();
    }

    public void SetMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();
    }

    void EffectStart()
    {
        msgText.text = ""; //시작시 텍스트 공백으로 초기화
        index = 0;
        EndCursor.SetActive(false); //엔드커서 비활성화

        interval = 1.0f/CharPerSeconds; //1초에 나올 글자 수
        Debug.Log(interval);
        Invoke("Effecting", interval); //Effecting 함수 속도만큼 시간 지연
    }

    void Effecting()
    {
        if(msgText.text == targetMsg) //대화 문자열을 전부 돌렸을 경우
        {
            EffectEnd();
            return; //함수 종료
        }
        msgText.text += targetMsg[index]; //문자열 배열처럼 접근 가능!
        index++;

        Invoke("Effecting", interval); //재귀함수
    }

    void EffectEnd()
    {
        EndCursor.SetActive(true); //엔드커서 활성화
    }
}
