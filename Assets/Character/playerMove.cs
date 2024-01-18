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
    float h; //�յ�
    float v; //�¿�
    Vector3 dirVec; //���� ����
    GameObject scanObject; //���� ������Ʈ
    GameObject gameManager;

    void Awake()
    {
        //Rigidbody2D ������ �¾�
        rigid = GetComponent<Rigidbody2D>();

        //Animator ������ �¾�
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        //Ű���尪 �Է¹ޱ� (��ȭ��� Ȱ���� �������� ����)
        h = manager.talkAction ? 0 : Input.GetAxisRaw("Horizontal"); //�¿�
        v = manager.talkAction ? 0 : Input.GetAxisRaw("Vertical"); //�յ�

        bool left = manager.talkAction ? false : Input.GetButtonDown("Horizontal");
        bool right = manager.talkAction ? false : Input.GetButtonDown("Horizontal");
        bool up = manager.talkAction ? false : Input.GetButtonDown("Vertical");
        bool down = manager.talkAction ? false : Input.GetButtonDown("Vertical");


        //�ִϸ��̼� Ʈ���� �۵�
        //isChange : ���� ��ȯ�� �Ǿ����� �� ���� �����ϵ��� �����ִ� ����
        //           Animator�� ����
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


        //���� ����
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
       

        //��ȭ �̺�Ʈ
        if (Input.GetKeyDown(KeyCode.Z) && scanObject != null)
        {
            Debug.Log("���� ��� : " + scanObject.name); //�׽�Ʈ�� �α�
            manager.Action(scanObject);
        }

        //�����ϱ� & ���� �ɱ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)(rigid.position.x - 0.3), (int)(rigid.position.y - 1.1), 0);

            //���� ���� ���� üũ
            if (GameManager.instance.tileManager.IsInteractable(position))
            {
                Debug.Log("���� ���"); //�׽�Ʈ�� �α�
                GameManager.instance.tileManager.SetField(position); //����
            }
            //���� �ɱ� ���� ���� üũ
            else if (GameManager.instance.tileManager.IsSeed(position))
            {
                Debug.Log("���� �ɱ� ���"); //�׽�Ʈ�� �α�
                GameManager.instance.tileManager.SetSeed(position); //���� �ɱ�
            }
        }

        //���ֱ�
        if (Input.GetKeyDown(KeyCode.C))
        {
            Vector3Int position = new Vector3Int((int)(rigid.position.x - 0.3), (int)(rigid.position.y - 1.1), 0);

            //���ֱ� ���� ���� üũ
            if (GameManager.instance.tileManager.IsWater_F(position))
            {
                Debug.Log("���ֱ� ���"); //�׽�Ʈ�� �α�
                GameManager.instance.tileManager.SetWater_F(position); //���ֱ�
            }
            else if (GameManager.instance.tileManager.IsWater_S(position))
            {
                Debug.Log("���ֱ� ���"); //�׽�Ʈ�� �α�
                GameManager.instance.tileManager.SetWater_S(position); //���ֱ�
            }
        }
    }

    void FixedUpdate()
    {
        //ĳ���� �����̱�
        rigid.velocity = new Vector2(h, v) * Speed;

        //���� �˰���
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, 
            LayerMask.GetMask("Object"));


        //���� ��� gameObject�� ���
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
