using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Command qCommand;
    [SerializeField] private Command wCommand;
    [SerializeField] private Command eCommand;
    [SerializeField] private Command rCommand;

    private void OnPlayerSelected()
    {
        Debug.Log("InputHandler");
        qCommand = FindObjectOfType<QSkillCommand>();
        wCommand = FindObjectOfType<WSkillCommand>();
        eCommand = FindObjectOfType<ESkillCommand>();
        rCommand = FindObjectOfType<RSkillCommand>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            qCommand?.Execute();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            wCommand?.Execute();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            eCommand?.Execute();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            rCommand?.Execute();
        }
    }
}
