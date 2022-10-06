using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QSkillCommand : Command
{
    private PlayerQSkill _playerQSkill;

    private void Awake()
    {
        _playerQSkill = GetComponent<PlayerQSkill>();
    }

    public override void Execute()
    {
        _playerQSkill.QSkillCast();
    }
}
