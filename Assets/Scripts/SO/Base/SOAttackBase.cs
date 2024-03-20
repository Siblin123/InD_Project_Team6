using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SOAttackBase : ScriptableObject , IAttackBehavior
{
    public GameManager.Type SkillType;
    public float m_fAttackMag;
    //������ ������ �������̽��� ScriptableObject�� ��ӹ��� SOBase �����Դϴ�.
    public abstract int ExecuteAttack(UnitEntity Atker, UnitEntity Defender);
}
