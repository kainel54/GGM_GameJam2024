using UnityEngine;

public class TestSkill : Skill
{
    public override void OnUnEquipSkill()
    {
        Debug.Log("TEST��ų ���� ����");
    }

    public override void OnEquipSkill()
    {
        Debug.Log("TEST��ų ����");
    }

    public override void OnUseSkill()
    {
        Debug.Log("TEST");
    }

    public override Skill Clone()
    {
        Skill skill = new TestSkill();
        return skill;
    }
}
