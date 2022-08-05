using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTest : MonoBehaviour
{
<<<<<<< HEAD
    GameObject g;
    public GameObject ballPrefab;

    private float spd_x_min = 0;
    private float spd_x_max = 0;
    private float spd_y_min = 0;
    private float spd_y_max = 0;
    private float spd_x = 0;
    private float spd_y = 0;
    private float prev_x = 0;
    private float lastThrough = 0;

    public int numBalls = 0;
    public int maxNumBalls = 0;
    public float throughInterval = 0.2f;

=======
>>>>>>> parent of 18a3bb6 (add flick and spawn)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
<<<<<<< HEAD
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

                if (Mathf.Abs(prev_x) < Mathf.Abs(spd_x))
                {
                    Debug.Log("throughInterval" + throughInterval);
                    if (Time.time - lastThrough > throughInterval)
                    {

                        Debug.Log("numBalls " + numBalls);
                        if (numBalls < maxNumBalls)
                        {
                            GameObject ball = Instantiate(ballPrefab);
                            ball.transform.position = new Vector3(0, 2, 0);
                            Rigidbody rb = ball.GetComponent<Rigidbody>();
                            //                    Vector3 force = new Vector3(spd_x / 10f, spd_x / 10f, spd_y / 10f);
                            Vector3 force = new Vector3(spd_x, spd_x, spd_y);
                            rb.AddForce(force);
                            numBalls += 1;
                        }
                        prev_x = 0;
                        lastThrough = Time.time;
                    }
                }
                else
                {
                    prev_x = spd_x;
                }
            }
=======
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
>>>>>>> parent of 18a3bb6 (add flick and spawn)
        }
    }
}
