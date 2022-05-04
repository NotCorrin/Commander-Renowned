using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual : MonoBehaviour
{
    protected SpriteRenderer sprite;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void isEnemy()
    {
        sprite.color = new Color(1, 0, 1, 0.5f);
        sprite.flipX = true;
    }

    void isSelected()
    {

    }
}
