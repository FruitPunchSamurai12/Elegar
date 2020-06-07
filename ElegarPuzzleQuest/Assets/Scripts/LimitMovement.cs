using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///helper class used on objects that i dont want to go through certain boundaries
///the movable rocks for example shouldnt be crossing through levels
public class LimitMovement : MonoBehaviour
{

    [SerializeField]
    float xMaxLimit;
    [SerializeField]
    float xMinLimit;
    [SerializeField]
    float yMaxLimit;
    [SerializeField]
    float yMinLimit;
   

    public bool limitOnXAxis = false;
    public bool limitOnYAxis = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (limitOnXAxis)
        {
            if(transform.position.x < xMinLimit)
            {
                transform.position = new Vector2(xMinLimit, transform.position.y);
            }
            else if(transform.position.x > xMaxLimit)
            {
                transform.position = new Vector2(xMaxLimit, transform.position.y);
            }
        }
        if (limitOnYAxis)
        {
            if (transform.position.y < yMinLimit)
            {
                transform.position = new Vector2(transform.position.x,yMinLimit);
            }
            else if (transform.position.y > yMaxLimit)
            {
                transform.position = new Vector2( transform.position.x,yMaxLimit);
            }
        }
    }
}
