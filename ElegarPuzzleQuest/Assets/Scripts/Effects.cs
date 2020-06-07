using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///small helper class for some effect animations like the animations on elegar spells
public class Effects : MonoBehaviour
{
    public string fxName;
    [SerializeField]
    AudioSource source;

    public void PlayFX()
    {

        source.clip = AudioManager.Instance.GetSoundEffect(fxName);
        source.volume = AudioManager.fxVolume;
        source.Play();
    }

    public void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
