using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///this guy handles the 4th boss fight against Batula the vampire
public class BossFightManager : MonoBehaviour
{
    [SerializeField]
    LightableAltar[] altars;
    [SerializeField]
    Material dissolveM;
    [SerializeField]
    GameObject bossLight;
    [SerializeField]
    ParticleSystem bossFX;


    [SerializeField]
    GameObject[] enemies;

    bool altarsLit = false;
    bool lerpEnded = false;

    float startValue = 0f;
    float endValue = 1.1f;
    float timeLerpStarted;
    public float lerpDuration = 1f;

    [SerializeField]
    Level17 lvl;


    //when all altars are lit the lights expand and batula and the bats get disintegrated
    void Update()
    {
        if (!lvl.levelPassed)
        {
            bool success = true;
            foreach (LightableAltar altar in altars)
            {
                if (!altar.Lit())
                {
                    success = false;
                }
            }
            if (success)
            {
                lvl.BatulaExtinguished();
                timeLerpStarted = Time.time;
                bossLight.SetActive(false);
                bossFX.Stop();
            }
        }
        else
        {
            LerpLights();
            foreach (LightableAltar altar in altars)
            {
                altar.Light();
            }
        }       
    }

    void LerpLights()
    {
        if (!lerpEnded)
        {
            float timeSinceStarted = Time.time - timeLerpStarted;
            float percentageComplete = timeSinceStarted / lerpDuration;
            float newT = Mathf.Lerp(startValue, endValue, percentageComplete);
            dissolveM.SetFloat("_Threshold", newT);//that's the material the enemies have that makes them dissolve
            foreach (LightableAltar altar in altars)
            {
                altar.ScaleLights();
            }
            if (percentageComplete >= 1f)
            {
                lerpEnded = true;
                foreach (GameObject enemy in enemies)
                {
                    if (enemy)
                    {
                        Destroy(enemy);
                    }
                }
                dissolveM.SetFloat("_Threshold", 0);//i set it back to normal afterwards
            }
        }
    }

}
