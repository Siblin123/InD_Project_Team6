using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewBaseAttack", menuName = "AttackBehavior/Base")]
public class SOBaseAttack : SOAttackBase
{
    //���ֵ��� �������̰ų� �������� �����Դϴ�.
    //SO�� ����� SOInstance�� �����ϰ� ����մϴ�.
    //m_fAttackMag -> ��ų ����
    //SkillType -> ��ų Ÿ��
    //�� �κп��� �ش� ������ ���� ����� ������ �� �ֽ��ϴ�.

    
    public override int ExecuteAttack(UnitEntity Atker, UnitEntity Defender)
    {
        // ���� -> ((���ݷ�*��ų����) - ������)*�Ӽ�����
        int AttackDamage =(int)(Atker.m_iUnitAtk * m_fAttackMag);
        int finalAttackDamage = AttackDamage - Defender.m_iUnitDef;

        int isDouble = GameManager.Instance.CompareType(SkillType, Defender.UnitType);

        if (isDouble == 1)
            finalAttackDamage = (int)(finalAttackDamage * 1.2);
        else if (isDouble == 2)
            finalAttackDamage = (int)(finalAttackDamage * 0.8);

        Defender.m_iCurrentHP -= finalAttackDamage;

        Debug.Log(isDouble);
        Debug.Log(finalAttackDamage);
        return finalAttackDamage;
    }
}
