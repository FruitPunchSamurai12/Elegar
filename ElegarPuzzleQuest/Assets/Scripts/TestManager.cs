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
        
    }

    public void ChangeRoom(bool horizontal,bool positive,Vector3 newPlayerPosition)
    {
        cam.ChangeRoom(horizontal,positive);
        player.ChangeRoom(newPlayerPosition);
    }

}
