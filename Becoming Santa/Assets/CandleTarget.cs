using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleTarget : MonoBehaviour
{
    public GameObject flameEffect; // flame effect
    public bool isLit = false;

    public void LightCandle()
    {
        if (isLit) return;

        isLit = true;

        if (flameEffect != null)
        {
            flameEffect.SetActive(true); // turns on flame
        }

        // Add sound and glow effect here
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
