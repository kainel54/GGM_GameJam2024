public abstract class Module
{
    //��� ���
    public abstract void EquipModule(Skill skill);

    //��� �������
    public abstract void UnEquipModule(Skill skill);

    //����
    public abstract Module Clone();
}
