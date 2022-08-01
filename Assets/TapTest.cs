using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
        Touch t = Input.GetTouch(0);
        Debug.Log(t.altitudeAngle);
        Debug.Log(t.azimuthAngle);
        Debug.Log(t.deltaPosition);
        Debug.Log(t.deltaTime);
        Debug.Log(t.fingerId);
        Debug.Log(t.maximumPossiblePressure);
        Debug.Log(t.phase);
        Debug.Log(t.position);
        Debug.Log(t.pressure);
        Debug.Log(t.radius);
        Debug.Log(t.radiusVariance);
        Debug.Log(t.rawPosition);
        Debug.Log(t.tapCount);
        Debug.Log(t.type);
        }
    }
}
