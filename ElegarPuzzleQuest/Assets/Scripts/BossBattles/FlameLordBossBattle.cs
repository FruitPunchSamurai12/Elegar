using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///This guy is responsible for the 3rd boss fight against Flame Lord
public class FlameLordBossBattle : MonoBehaviour
{
    [SerializeField]
    BigFire[] bigFires;

    [SerializeField]
    GameObject[] explosions;

    [SerializeField]
    GameObject flameLord;

    [SerializeField]
    Material dissolveM;
    float startValue = 0f;
    float endValue = 1.1f;
    float timeLerpStarted;
    bool lerpStarted = false;
    bool lerpEnded = false;
    public float lerpDuration = 1f;

    [SerializeField]
    GameObject fence;//this blocks the player from moving between level 5 and level 12

    bool firesLit = false;

    float explosionsTimer = 0f;
    public float delayBetweenExplosions = 0.1f;
    int explosionsIndex = 0;

    [SerializeField]
    Level12 lvl;

    //check if all big fires are lit and then start the boss dissolve animation
    private void Update()
    {
        if(!firesLit)
        {
            if(AllFiresLit())
            {
                firesLit = true;
                explosionsTimer = 0f;
            }
        }
        else
        {
            TriggerExplosions();
            if(lerpStarted)
            {
                LerpBossDissolve();
            }
        }
        if(lvl.levelPassed)
        {
            if(fence)
            {
                Destroy(fence);
            }
        }
    }

    bool AllFiresLit()
    {
        foreach(BigFire fire in bigFires)
        {
           if(!fire.FireLit())
            {
                return false;
            }
        }
        return true;
    }

    void TriggerExplosions()//the explosions game objects are on scene inactive and i just activate them when it is time
    {
        if(explosionsIndex<explosions.Length)
        {
            if(explosionsTimer>delayBetweenExplosions*explosionsIndex)
            {
                explosions[explosionsIndex].SetActive(true);
                if(explosionsIndex == 5)
                {
                    lerpStarted = true;
                    timeLerpStarted = Time.time;
                    FlameLord fl = flameLord.GetComponent<FlameLord>();
                    fl.TimeToDie(dissolveM);
                }
                explosionsIndex++;
            }
            explosionsTimer += Time.deltaTime;
        }
    }

    void LerpBossDissolve()
    {
        if (!lerpEnded)
        {
            float timeSinceStarted = Time.time - timeLerpStarted;
            float percentageComplete = timeSinceStarted / lerpDuration;
            float newT = Mathf.Lerp(startValue, endValue, percentageComplete);
            dissolveM.SetFloat("_Threshold", newT);
            if (percentageComplete >= 1f)
            {
                lerpEnded = true;
                Destroy(flameLord);
                Destroy(fence);
                lvl.BossExploded();
                dissolveM.SetFloat("_Threshold", 0);
            }
        }
    }

}
