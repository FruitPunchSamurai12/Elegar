using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///a helper class to make objects move up and down in a frequency. used in the bats and batula
public class Float : MonoBehaviour
{
    public float frequency = 0.5f;
    public bool randomBetweenTwoFloats = false;
    public float minFrequency = 1f;
    public float maxFrequency = 1.5f;
    public float distance = 1f;


    [SerializeField]
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float f;
        if(randomBetweenTwoFloats)
        {
            f = Random.Range(minFrequency, maxFrequency);
        }
        else
        {
            f = frequency;
        }

        rb2d.AddForce(new Vector2(Vector2.down.x*Physics2D.gravity.x, Vector2.down.y * (Physics2D.gravity.y + distance*Mathf.Sin(Time.fixedTime * Mathf.PI*f))));
    }
}
