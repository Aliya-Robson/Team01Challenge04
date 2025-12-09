using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleTarget : MonoBehaviour
{
    public GameObject flameEffect; // flame effect
    public bool isLit = false;
    public Light candleLight; // glow effect
    public AudioSource candleSound; // candle sound effect

    // Flicker settings
    public float baseIntensity = 2f;
    public float flickerAmount = 0.3f;
    public float flickerSpeed = 10f;

    public void LightCandle()
    {
        if (isLit) return;

        isLit = true;

        if (flameEffect != null)
        {
            flameEffect.SetActive(true); // turns on flame
        }

        if (candleLight != null)
        {
            candleLight.enabled = true; // turns on glow
        }

        // Add sound here
        if (candleSound != null)
        {
            candleSound.Play(); // plays sound
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (candleLight != null && candleLight.enabled)
        {
            float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0.0f);
            candleLight.intensity = baseIntensity + noise * flickerAmount; // flicker effect
        }
    }
}
