using System;

public class WSkillCommand : Command
{
    private PlayerWSkill _playerWSkill;

    private void Awake()
    {
        _playerWSkill = GetComponent<PlayerWSkill>();
    }

    public override void Execute()
    {
        _playerWSkill.CastWSkill();
    }
}
