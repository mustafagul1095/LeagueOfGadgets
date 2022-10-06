using System;

public class ESkillCommand : Command
{
    private PlayerESkill _playerESkill;

    private void Awake()
    {
        _playerESkill = GetComponent<PlayerESkill>();
    }

    public override void Execute()
    {
        _playerESkill.CastESkill();
    }
}
