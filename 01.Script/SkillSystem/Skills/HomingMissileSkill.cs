using Doryu.StatSystem;
using UnityEngine;
using YH.Entities;
using YH.Players;

public class HomingMissileSkill : Skill
{
    private Player _player;
    private StatElement _damageStat;
    private EntityRenderer _renderer;
    private LayerMask _whatIsEnemy;
    private float _bulletSpeed = 20;

    public override void Init(SkillSO skillSO, Entity owner)
    {
        base.Init(skillSO, owner);
        _whatIsEnemy = LayerMask.GetMask("Enemy");
        _player = PlayerManager.Instance.Player;
        _damageStat = _player.GetCompo<StatCompo>().GetElement("Damage");
        _renderer = _player.GetCompo<EntityRenderer>(true);
    }

    public override void OnUseSkill()
    {
        Homing homing
            = PoolManager.Instance.Pop(ObjectPooling.PoolingType.Homing) as Homing;

        AudioManager.Instance.PlaySound(EAudioName.Fire);

        float rotationDeg = 360 / PlayerManager.Instance.CurrentPlayerPoint * _edge;
        rotationDeg += _renderer.Direction;

        Vector3 dir = new Vector3(
            Mathf.Cos((rotationDeg + 90) * Mathf.Deg2Rad),
            Mathf.Sin((rotationDeg + 90) * Mathf.Deg2Rad),
             0).normalized;
        dir *= _owner.transform.localScale.x;

        Vector3 position = _owner.transform.position + dir;

        int damage = Mathf.CeilToInt(_damageStat.Value);
        homing.Setting(PlayerManager.Instance.Player, _whatIsEnemy, null, _bulletSpeed, damage, 20f);
        homing.transform.SetPositionAndRotation(position, Quaternion.Euler(0, 0, rotationDeg));
        homing.transform.localScale = Vector3.one;
    }

    public override Skill Clone()
    {
        Skill skill = new HomingMissileSkill();
        return skill;
    }
}
