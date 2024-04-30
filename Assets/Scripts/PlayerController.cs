using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // g_fCharacterSpeed -> g�� �۷ι�(public) m�� ���(private) ���� f(float)/i(int)/s(string) 
    private Animator animator;
    private float m_fx;
    private float m_fy;
    private Rigidbody2D m_Rigidbody2D;
    private GameObject m_scanObject;

    public float g_fspeed;
    public float g_frun_Speed;
    public LayerMask g_llayer;
   // public GameManager _instance;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Object_Interaction();
    }

    private void Object_Interaction()
    {
        // ĳ���Ͱ� �ٶ󺸴� �ݴ� �������� ����ĳ��Ʈ
        Vector2 lookDirection;

        // ĳ���Ͱ� ������ �ٶ󺸴� ���
        if (transform.localScale.x < 0)
        {
            lookDirection = -transform.right;
        }
        else
        {
            lookDirection = transform.right; // �ʱⰪ�� ���������� ����
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, 2, g_llayer);

        // ���̰� � ������Ʈ�� �浹�ߴ��� Ȯ��
        if (hit.collider != null) 
        {
            m_scanObject = hit.collider.gameObject; // �浹�� ��ü�� ��ĵ�� ��ü�� ����

            if (Input.GetKeyDown(KeyCode.F)) // F Ű�� ���ȴ��� Ȯ��
            {
                // �浹�� ��ü�κ��� �������� ������ �κ��丮 ��Ʈ�ѷ��� ���� ���������� ����
                Inventory_Controller.g_ICinstance.g_Iget_Item = hit.transform.GetComponent<Drop_Item>().g_Iitem;
                // �κ��丮 ������ Ȯ��
                Inventory_Controller.g_ICinstance.Check_Slot();
                // �浹�� ��ü�� �ı�
                Destroy(hit.transform.gameObject);
            }
            else if (Input.GetButtonDown("Jump") && m_scanObject != null) // ����(�����̽���) ��ư�� ���Ȱ� ��ĵ�� ��ü�� �ִ��� Ȯ��
            {
                // _instance ��ü�� Act �޼��带 ȣ���ϰ� ��ĵ�� ��ü�� ����
             //   _instance.Act(m_scanObject);
            }
        }
        else // �浹ü�� ���� ���
        {
            m_scanObject = null; // ��ĵ�� ��ü�� null�� �缳��
        }

    }

    private void Movement()
    {
        // ������ �κ��丮, ������ ������(����� ��� ���ƺ�), ������ ����â, ���ξ� ������, 
        // m_fx = _instance.isAct ? 0 : Input.GetAxisRaw("Horizontal");
        //m_fy = _instance.isAct ? 0 : Input.GetAxisRaw("Vertical");

        m_fx = Input.GetAxisRaw("Horizontal");
        m_fy =  Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
           animator.SetBool("Walk", false);
            Run();
        }
        else
        {
            animator.SetBool("Run", false);
            Walk();
        }
        
    }

    void Walk()
    {
        if (m_fx == 0 && m_fy == 0)
        {
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("Walk", true);
        }

        if (m_fx == -1 || m_fy == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (m_fx == 1 || m_fy == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        Vector2 movement = new Vector2(m_fx, m_fy) * g_fspeed * Time.deltaTime;
        transform.Translate(movement);
       // m_Rigidbody2D.MovePosition(m_Rigidbody2D.position + movement); // �÷��̾�� ������Ʈ �浹�� �������� ���� 
    }

    void Run()
    {
        if (m_fx == 0 && m_fy == 0)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }

        if (m_fx == -1 || m_fy == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (m_fx == 1 || m_fy == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        Vector2 movement = new Vector2(m_fx, m_fy).normalized * g_frun_Speed * Time.deltaTime;
       transform.Translate(movement);
          // m_Rigidbody2D.MovePosition(m_Rigidbody2D.position + movement); // �÷��̾�� ������Ʈ �浹�� �������� ���� 
    }
}
