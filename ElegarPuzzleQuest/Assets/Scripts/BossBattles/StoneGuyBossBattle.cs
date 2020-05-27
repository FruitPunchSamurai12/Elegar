using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGuyBossBattle : MonoBehaviour
{
    [SerializeField]
    FloorButton[] buttons;

    [SerializeField]
    StoneBoss boss;

    [SerializeField]
    RollingBoulder boulder;

    [SerializeField]
    AIState bossDeathState;

    [SerializeField]
    Level3 level3;

    bool victory = false;



    private void Update()
    {
        if (level3.levelPassed)
        {
            victory = true;
        }
        if(!victory)
        {
            if(AllButtonsPressed())
            {
                boulder.Roll(boss.transform.position);
                var ai = boss.GetComponent<BaseAIController>();
                if(ai)
                {
                    ai.ChangeAIState(bossDeathState);
                }
                victory = true;
                level3.BossDown();
            }
        }
    }

    bool AllButtonsPressed()
    {
        foreach(FloorButton button in buttons)
        {
            if(!button.IsPressed())
            {
                return false;
            }
        }
        return true;
    }

}
