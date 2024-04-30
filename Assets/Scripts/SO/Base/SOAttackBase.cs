using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SOAttackBase : ScriptableObject , IAttackBehavior
{
    public GameManager.Type SkillType;
    public float m_fAttackMag;
    public string m_sAttackName;
    public int m_iUseAmount;
    //������ ������ �������̽��� ScriptableObject�� ��ӹ��� SOBase �����Դϴ�.
    public abstract void ExecuteAttack(UnitEntity Atker, UnitEntity Defender);
    public abstract string GetSkillName();
}
