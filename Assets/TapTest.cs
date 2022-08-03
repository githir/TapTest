using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTest : MonoBehaviour
{
    GameObject g;
    public GameObject ballPrefab;

    private float spd_x_min = 0;
    private float spd_x_max = 0;
    private float spd_y_min = 0;
    private float spd_y_max = 0;
    private float spd_x = 0;
    private float spd_y = 0;

    public int numBalls = 0;
    public int maxNumBalls = 0;

    // Start is called before the first frame update
    void Start()
    {
        g = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("touchCount" + Input.touchCount);
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                Debug.Log("t.altitudeAngle " + t.altitudeAngle);
                Debug.Log("t.azimuthAngle " + t.azimuthAngle);
                Debug.Log("t.deltaPosition " + t.deltaPosition);
                Debug.Log("t.deltaTime " + t.deltaTime);

                spd_x = t.deltaPosition[0] / t.deltaTime;
                spd_y = t.deltaPosition[1] / t.deltaTime;
                spd_x_min = (spd_x_min > spd_x) ? spd_x : spd_x_min;
                spd_x_max = (spd_x_max < spd_x) ? spd_x : spd_x_max;
                spd_y_min = (spd_y_min > spd_y) ? spd_y : spd_y_min;
                spd_y_max = (spd_y_max < spd_y) ? spd_y : spd_y_max;

                Debug.Log("speed " + spd_x + ", " + spd_y + " | " + spd_x_min + " " + spd_x_max + " " + spd_y_min + " " + spd_y_max);
                Debug.Log("t.fingerId " + t.fingerId);
                //    Debug.Log("t.maximumPossiblePressure" + t.maximumPossiblePressure);
                Debug.Log("t.phase " + t.phase);
                Debug.Log("t.position " + t.position);
                //    Debug.Log("t.pressure" + t.pressure);
                Debug.Log("t.radius " + t.radius);
                Debug.Log("t.radiusVariance " + t.radiusVariance);
                Debug.Log("t.rawPosition " + t.rawPosition);
                Debug.Log("t.tapCount " + t.tapCount);
                //   Debug.Log("t.type" + t.type);

                Debug.Log("numBalls " + numBalls);
                if (numBalls < maxNumBalls)
                {
                    GameObject ball = Instantiate(ballPrefab);
                    ball.transform.position = new Vector3(1, 1, 0);
                    Rigidbody rb = ball.GetComponent<Rigidbody>();
                    Vector3 force = new Vector3(spd_x / 10f, spd_x / 10f, spd_y / 10f);
                    rb.AddForce(force);
                    numBalls += 1;
                }
            }
        }
        else
        {
            spd_x = 0.99f * spd_x;
            spd_y = 0.99f * spd_y;
        }

        Vector3 pos = g.transform.position;
        pos.x = spd_x / 1000f;
        pos.y = 0.0f;
        pos.z = spd_y / 1000f;
        g.transform.position = pos;
    }
}
