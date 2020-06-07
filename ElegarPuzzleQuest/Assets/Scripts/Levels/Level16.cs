using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//you need to light the altars to pass level 16
public class Level16 : Level
{
    [SerializeField]
    LightableAltar[] altars;

    [SerializeField]
    Gate gate;

    private void Update()
    {
        if (!levelPassed)
        {
            bool success = true;
            foreach (var altar in altars)
            {
                if (!altar.Lit())
                {
                    success = false;
                }
            }
            if (success)
            {
                levelPassed = true;
                LevelManager.Instance.SetLevelPassed(levelPassed, ID);
            }
        }
        else
        {
            gate.OpenGate();
            foreach (var altar in altars)
            {
                altar.Light();
            }
        }
    }
}
