using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //GameManager
    public static GameManager instance;
    public tileManager tileManager;

    //��ȭ�� UI
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Image portraitImg;
    public Sprite prevPortraitImg;
    public Animator portAnim;
    public TypeEffect talk;
    public GameObject scanObject;
    public bool talkAction;
    public int talkIndex;

    private void Awake()
    {
        //�ٸ� ������ �Ѿ�� GameManager�� �ı����� �ʵ��� ����
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        //tileManager �¾�
        tileManager = GetComponent<tileManager>();

        talkPanel.SetActive(false);
    }

    //��ȭ �̺�Ʈ
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id);
        talkPanel.SetActive(talkAction);//��ȭâ show & hide
    }

    //��ȭ ����
    void Talk(int id)
    {
        string talkData = talkManager.GetTalk(id, talkIndex); //��ȭ ��� �ޱ�

        if (talkData == null)
        {
            talkAction = false;
            talkIndex = 0;
            return; //�Լ� ����
        }

        talk.SetMsg(talkData.Split(':')[0]); //��ȭ ���
        portraitImg.sprite = talkManager.GetPortrait
            (id, int.Parse(talkData.Split(":")[1])); //�ʻ�ȭ ���
        if (prevPortraitImg != portraitImg.sprite)
        {
            portAnim.SetTrigger("doEffect");
            prevPortraitImg = portraitImg.sprite;
            portAnim.SetTrigger("doEffect");
        }

        talkAction = true;
        talkIndex++;
    }
}
