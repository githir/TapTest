using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationArrowController : MonoBehaviour
{

    public float elevationAngle;
    public GameObject elevationAngleController;
    public GameObject elevationArrow;

    // Start is called before the first frame update
    void Start()
    {
        elevationAngle = Mathf.Deg2Rad * 45.0f;
        elevationAngleController = GameObject.Find("MyGameObject");
        elevationArrow = GameObject.Find("ArrowPrefab");
        elevationArrow.transform.rotation = Quaternion.Euler(0, 90.0f, Mathf.Rad2Deg * elevationAngle);
    }
    void Update()
    {
        elevationAngle = elevationAngleController.GetComponent<TapTest>().elevationAngle;
      //  Debug.Log("elevationAngle :" + Mathf.Rad2Deg * elevationAngle);
//        elevationArrow.transform.rotation = Quaternion.Euler(0.0f, Mathf.Rad2Deg * (90.0f - elevationAngle), 0.0f);  //‰ñ“]‚Ì‚Ý
     elevationArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Rad2Deg * elevationAngle);  //—§‘Ìver
    }
}
