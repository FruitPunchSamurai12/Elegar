using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField]
    CameraScript cam;
    [SerializeField]
    Player player;

    public static TestManager Instance;

    private void Awake()
    {
        if (Instance == null)//simpleton pattern
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) )
        {
            player.EquipSpell(ElegarSpells.Push);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.EquipSpell(ElegarSpells.Pull);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.EquipSpell(ElegarSpells.Water);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player.EquipSpell(ElegarSpells.Light);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            player.EquipSpell(ElegarSpells.Reflect);
        }
    }


    public Transform PlayerTransform() { return player.transform; }

    public void ChangeRoom(bool horizontal,bool positive,Vector3 newPlayerPosition)
    {
        cam.ChangeRoom(horizontal,positive);
        player.ChangeRoom(newPlayerPosition);
    }

}
