using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // for grabbing candle

public class CandleLighter : MonoBehaviour
{
    public float lightRange = 0.75f; // Distance to light other candles
    public LayerMask candleLayer; // Layer for candles waiting
    private XRGrabInteractable grabInteractable;
    private bool isHeld = false;

    void Awake()
    {
        // Get XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
            grabInteractable.selectExited.AddListener(OnReleased);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHeld) return; // works when candle is grabbed

        // Detect nearby candles
        Collider[] nearbyCandles = Physics.OverlapSphere(transform.position, lightRange, candleLayer);

        foreach (Collider candle in nearbyCandles)
        {
            CandleTarget target = candle.GetComponent<CandleTarget>();
            if (target != null && !target.isLit)
            {
                target.LightCandle();
            }
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        isHeld = true;
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        isHeld = false;
    }
}
