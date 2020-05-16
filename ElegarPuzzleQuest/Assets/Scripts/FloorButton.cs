using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    [SerializeField]
    Sprite pressedSprite;
    [SerializeField]
    Sprite notPressedSprite;
    [SerializeField]
    SpriteRenderer renderer;

    bool isPressed = false;

    private void Update()
    {
        if(isPressed)
        {
            renderer.sprite = pressedSprite;
        }
        else
        {
            renderer.sprite = notPressedSprite;
        }
    }

    public bool IsPressed() { return isPressed; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isPressed = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPressed = false;
    }

}
