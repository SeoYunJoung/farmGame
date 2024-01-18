using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class playerMove : MonoBehaviour
{
    public GameManager manager;
    public float Speed;

    Rigidbody2D rigid;
    Animator animator;
    float h; //앞뒤
    float v; //좌우
    Vector3 dirVec; //조사 방향
    GameObject scanObject; //조사 오브젝트
    GameObject gameManager;

    void Awake()
    {
        //Rigidbody2D 데이터 셋업
        rigid = GetComponent<Rigidbody2D>();

        //Animator 데이터 셋업
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        //키보드값 입력받기 (대화모션 활성시 적용하지 않음)
        h = manager.talkAction ? 0 : Input.GetAxisRaw("Horizontal"); //좌우
        v = manager.talkAction ? 0 : Input.GetAxisRaw("Vertical"); //앞뒤

        bool left = manager.talkAction ? false : Input.GetButtonDown("Horizontal");
        bool right = manager.talkAction ? false : Input.GetButtonDown("Horizontal");
        bool up = manager.talkAction ? false : Input.GetButtonDown("Vertical");
        bool down = manager.talkAction ? false : Input.GetButtonDown("Vertical");


        //애니매이션 트리거 작동
        //isChange : 방향 전환이 되었을때 한 번만 실행하도록 도와주는 변수
        //           Animator에 존재
        if (animator.GetInteger("hAxisRaw") != h)
        {
            animator.SetBool("isChange", true);
            animator.SetInteger("hAxisRaw", (int)h);
        }
        else if (animator.GetInteger("vAxisRaw") != v)
        {
            animator.SetBool("isChange", true);
            animator.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            animator.SetBool("isChange", false);
        }


        //방향 조작
        if (animator.GetBool("isChange"))
        {
            if (v == 1)
            {
                dirVec = Vector3.up;
            }
            else if (v == -1)
            {
                dirVec = Vector3.down;
            }
            else if (h == 1)
            {
                dirVec = Vector3.right;
            }
            if (h == -1)
            {
                dirVec = Vector3.left;
            }
        }
       

        //대화 이벤트
        if (Input.GetKeyDown(KeyCode.Z) && scanObject != null)
        {
            Debug.Log("조사 대상 : " + scanObject.name); //테스트용 로그
            manager.Action(scanObject);
        }

        //경작하기 & 씨앗 심기
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)(rigid.position.x - 0.3), (int)(rigid.position.y - 1.1), 0);

            //경작 가능 여부 체크
            if (GameManager.instance.tileManager.IsInteractable(position))
            {
                Debug.Log("경작 대상"); //테스트용 로그
                GameManager.instance.tileManager.SetField(position); //경작
            }
            //씨앗 심기 가능 여부 체크
            else if (GameManager.instance.tileManager.IsSeed(position))
            {
                Debug.Log("씨앗 심기 대상"); //테스트용 로그
                GameManager.instance.tileManager.SetSeed(position); //씨앗 심기
            }
        }

        //물주기
        if (Input.GetKeyDown(KeyCode.C))
        {
            Vector3Int position = new Vector3Int((int)(rigid.position.x - 0.3), (int)(rigid.position.y - 1.1), 0);

            //물주기 가능 여부 체크
            if (GameManager.instance.tileManager.IsWater_F(position))
            {
                Debug.Log("물주기 대상"); //테스트용 로그
                GameManager.instance.tileManager.SetWater_F(position); //물주기
            }
            else if (GameManager.instance.tileManager.IsWater_S(position))
            {
                Debug.Log("물주기 대상"); //테스트용 로그
                GameManager.instance.tileManager.SetWater_S(position); //물주기
            }
        }
    }

    void FixedUpdate()
    {
        //캐릭터 움직이기
        rigid.velocity = new Vector2(h, v) * Speed;

        //조사 알고리즘
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, 
            LayerMask.GetMask("Object"));


        //조사 대상 gameObject에 등록
        if(rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
