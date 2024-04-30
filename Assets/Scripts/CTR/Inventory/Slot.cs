using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    // g_fCharacterSpeed -> g�� �۷ι�(public) m�� ���(private) ���� f(float)/i(int)/s(string)
    public static Slot g_SInstance;
    public Image g_iitem_Image;
    public Sprite g_snull_item_Image;
    public ItemEntity g_Ihave_item;
    public TextMeshProUGUI g_tdescription_Window; // ����â
    public TextMeshProUGUI g_titem_Num_Name; // ������ �̸�, ����
    public Image g_iitem_Img_View; // ������ �̹���
    public int g_iitem_Number; // ȹ���� ������ ����
    Slot_Button s_B;

    private void Awake()
    {
        g_SInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        s_B = GetComponent<Slot_Button>();
    }

    // Update is called once per frame
    void Update()
    {
        Show_Item();
        Empty_Check();
    }

    public void OnMouseEnter() // UI�� ���콺 ����
    {
        if(g_iitem_Number != 0 && Inventory_Controller.g_ICinstance.lock_UI)
        {
            g_iitem_Img_View.gameObject.SetActive(true);
            //  Inventory_Controller.g_ICinstance.g_Iclick_Item = g_Ihave_item;
            Inventory_Controller.g_ICinstance.g_Sclick_Slot = this;

            g_tdescription_Window.text = g_Ihave_item.m_sItemDescription;
            g_titem_Num_Name.text = g_Ihave_item.m_sItemName + " X " + g_iitem_Number.ToString();
            g_iitem_Img_View.sprite = g_Ihave_item.m_ItemSprite;
        }
    }

    public void Refresh()
    {
        if(g_iitem_Number != 0)
        {
            g_titem_Num_Name.text = g_Ihave_item.m_sItemName + " X " + g_iitem_Number.ToString();
        }
        
    }

    public void Empty_Check()
    {
       // g_titem_Num_Name.text = item_Number.ToString(); // �����ϰ� �ִ� ������ ����
        if (g_Ihave_item != null)
        {
            if (g_iitem_Number == 0) // �������� ���ٸ� �������� �� ����ߴٸ�
            {
                g_Ihave_item = null;
                g_tdescription_Window.text = " ";
                g_titem_Num_Name.text = " ";
                g_iitem_Img_View.gameObject.SetActive(false);
                g_iitem_Image.gameObject.SetActive(false);
                // ���� 
                /* g_iitem_Image.sprite = g_snull_item_Image;       // �ʱ�
                 g_titem_Number_UI.text = " ";     // ȭ*/
            }
            else
            {
                g_iitem_Image.gameObject.SetActive(true);
                g_iitem_Image.sprite = g_Ihave_item.m_ItemSprite;
            }
        }
        else
        {
            //  g_titem_Number_UI.text = " ";
            g_iitem_Image.gameObject.SetActive(false);
            g_iitem_Number = 0;
        }
    }
    public void Input_Item(ItemEntity item, int num = 1) // ������ �ֱ�
    {
        if (item != null) // �޾ƿ� �������� �ִٸ�
        {
            g_Ihave_item = item;  // ���� ������ ������ ������ �������� �ְ�
            g_iitem_Number += num;
        }
    }

    void Show_Item()
    {
        if (g_Ihave_item != null)
        {
            g_iitem_Image.sprite = g_Ihave_item.m_ItemSprite; // ������ �̹��� �Ҵ�
        }
        else
        {
            g_iitem_Image.sprite = g_snull_item_Image;
        }
    }
}
