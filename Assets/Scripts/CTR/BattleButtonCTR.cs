using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButtonCTR : MonoBehaviour
{
    public GameObject BattleButtons;
    public GameObject SkillButtonPrefab;
    public GameObject g_Canvas;
    public BattleManager g_BattleManager;
    private void Start()
    {
        BattleButtons = gameObject.transform.parent.gameObject;
        g_Canvas = GameObject.Find("Canvas");
        g_BattleManager = GameObject.Find("BattleManager").transform.GetComponent<BattleManager>();
    }
    public void OnClick_Skill()
    {
        if (g_BattleManager.state == BattleManager.BattleState.ACTION)
        {
            Debug.Log("��ų��ư ����");
            SkillButtonPrefab = Resources.Load<GameObject>("Prefabs/SkillButtons");
            GameObject SkillButton_Temp = Instantiate(SkillButtonPrefab, g_Canvas.transform);
            for (int i = 0; i < SkillButton_Temp.transform.childCount - 1; i++)
            {
                SkillButton_Temp.transform.GetChild(i).GetChild(0).transform.GetComponent<Text>().text = g_BattleManager.playerUnit.m_AttackBehaviors[i].GetSkillName();
            }

            BattleButtons.SetActive(false);
        }
    }
    public void Onclick_Change()
    {
        if (g_BattleManager.state == BattleManager.BattleState.ACTION)
        {
            Debug.Log("���� ��ư ����");
            //�������� Load
            GameObject ChangeButtonPrefab = Resources.Load<GameObject>("Prefabs/ChangeButtons");
            //instantiate �ϰ� �ؽ�Ʈ�� �ٲٱ� ���� Temp�� ����
            GameObject ChangeButton_Temp = Instantiate(ChangeButtonPrefab, g_Canvas.transform);
            //��ư�� �ؽ�Ʈ�� �÷��̾��� ���� �̸����� �ٲ�
            for (int i = 0; i < GameManager.Instance.m_UnitManager.g_PlayerUnits.Length; i++)
                ChangeButton_Temp.transform.GetChild(i).transform.GetChild(0).transform.GetComponent<Text>().text = GameManager.Instance.m_UnitManager.g_PlayerUnits[i].GetComponent<UnitEntity>().m_sUnitName;
            BattleButtons.SetActive(false);
        }
    }
    public void OnClick_Inventory()
    {
        Debug.Log("�κ��丮 ��ư ����");
    }
    public void OnClick_Run()
    {
        Debug.Log("���� ����");
    }
}
