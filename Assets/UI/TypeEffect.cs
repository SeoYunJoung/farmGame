using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    string targetMsg; //���ڿ� ����
    public int CharPerSeconds; //���ڿ� ��� �ӵ�
    public GameObject EndCursor;
    public Text msgText; //��ȭ �ؽ�Ʈ ��������
    int index; //��ȭ �ؽ�Ʈ index
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
        msgText.text = ""; //���۽� �ؽ�Ʈ �������� �ʱ�ȭ
        index = 0;
        EndCursor.SetActive(false); //����Ŀ�� ��Ȱ��ȭ

        interval = 1.0f/CharPerSeconds; //1�ʿ� ���� ���� ��
        Debug.Log(interval);
        Invoke("Effecting", interval); //Effecting �Լ� �ӵ���ŭ �ð� ����
    }

    void Effecting()
    {
        if(msgText.text == targetMsg) //��ȭ ���ڿ��� ���� ������ ���
        {
            EffectEnd();
            return; //�Լ� ����
        }
        msgText.text += targetMsg[index]; //���ڿ� �迭ó�� ���� ����!
        index++;

        Invoke("Effecting", interval); //����Լ�
    }

    void EffectEnd()
    {
        EndCursor.SetActive(true); //����Ŀ�� Ȱ��ȭ
    }
}
