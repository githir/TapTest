using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapTest : MonoBehaviour
{
    GameObject g;
    public GameObject ballPrefab;
    private GameObject scoreText;

    private float spd_x_min = 0;
    private float spd_x_max = 0;
    private float spd_y_min = 0;
    private float spd_y_max = 0;
    private float spd_x = 0;
    private float spd_y = 0;
    private float prev_x = 0;
    private float lastThrough = 0;

    public int numBalls = 0;
    public int maxNumBalls = 1;
    public float throughInterval = 0.2f;

    public float fixPower = 4.0f;

    public float elevationAngle = 45.0f;
    private GameObject elevationAngleText;

    // Start is called before the first frame update
    void Start()
    {
        g = GameObject.Find("Sphere");
        scoreText = GameObject.Find("ScoreText");
        elevationAngleText = GameObject.Find("ElevationAngleText");

        lastThrough = Time.time;
    //    throughInterval = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.acceleration[1]);
        elevationAngle = Mathf.Round(45.0f - Input.acceleration[1] / 2 * 100);
     //   elevationAngle = 45.0f; // for debug

        elevationAngleText.GetComponent<Text>().text = " " + elevationAngle;
        elevationAngle = Mathf.Deg2Rad * elevationAngle;


        //        Debug.Log("touchCount" + Input.touchCount);
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
     /*
      * Debug.Log("t.altitudeAngle " + t.altitudeAngle);
                Debug.Log("t.azimuthAngle " + t.azimuthAngle);
                Debug.Log("t.deltaPosition " + t.deltaPosition);
                Debug.Log("t.deltaTime " + t.deltaTime);
     */
                spd_x = t.deltaPosition[1] / t.deltaTime;
                spd_y = -t.deltaPosition[0] / t.deltaTime;

                /*
                 * spd_x_min = (spd_x_min > spd_x) ? spd_x : spd_x_min;
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
                */

                if (Mathf.Abs(prev_x) < Mathf.Abs(spd_x) )
                {
                 //   Debug.Log("throughInterval"+throughInterval);
                    if (Time.time - lastThrough > throughInterval)
                        {

                  //      Debug.Log("numBalls " + numBalls);
                        if (numBalls < maxNumBalls)
                        {
                            GameObject ball = Instantiate(ballPrefab);
                            ball.transform.position = new Vector3(0, 2, 0);
                            Rigidbody rb = ball.GetComponent<Rigidbody>();
                            //                    Vector3 force = new Vector3(spd_x / 10f, spd_x / 10f, spd_y / 10f);
                            //           Vector3 force = new Vector3(spd_x, spd_x, spd_y);
                            Vector3 force = new Vector3(fixPower * Mathf.Cos(elevationAngle), fixPower * Mathf.Sin(elevationAngle), 0);  // for debug
                  //          Vector3 force = new Vector3(fixPower , fixPower, 0);  // for debug
                            rb.AddForce(force);
                            rb.AddTorque(Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f), ForceMode.Impulse);
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
