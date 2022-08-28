using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public float fixPower = 400.0f;

    public float elevationAngle = 45.0f;
    private GameObject elevationAngleText;

    public float MaxAngle_x = 30.0f;

    private GameObject scoreTotalText;
    private GameObject scoreTotal;

    private bool isGameOver;

    //param for keyboad operation
    public float power_x_near = 180;
    public float power_x_middle = 220;
    public float power_x_far = 260;
    public float power_y_left = 45;
    public float power_y_center = 0;
    public float power_y_right = -45;

    // Start is called before the first frame update
    void Start()
    {
        g = GameObject.Find("Sphere");
        scoreText = GameObject.Find("ScoreText");
        elevationAngleText = GameObject.Find("ElevationAngleText");

        //test
        // GameObject goalAreaObject = GameObject.Find("GoalSquarePrefab 1-1");
        // goalAreaObject.GetComponent<Renderer>().material.color = Color.red;

        lastThrough = Time.time;
        //    throughInterval = 0.2f;

        scoreTotalText = GameObject.Find("ScoreTotalText");
        // scoreTotalText.SetActive(false);
        scoreTotalText.GetComponent<Text>().text = " ";

        scoreTotal = GameObject.Find("MyGameObject");

        isGameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.acceleration[1]);
        float elevationAngle_deg = Mathf.Round(45.0f - Input.acceleration[1] / 2 * 100);
        //   elevationAngle = 45.0f; // for debug

        //upper limit of elevationAngle
        if (elevationAngle > 90.0f)
        {
            elevationAngle = 90.0f;
        }

        elevationAngleText.GetComponent<Text>().text = " " + elevationAngle_deg + "[deg]";
        elevationAngle = Mathf.Deg2Rad * elevationAngle_deg;


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


                if (Mathf.Abs(prev_x) < Mathf.Abs(spd_x))  //lets through
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


                            Debug.Log("1> y,x,tan(x)" + spd_y + " " + spd_x + " " + spd_x * Mathf.Tan(MaxAngle_x * Mathf.Rad2Deg));
                            // limit angular range
                            if (spd_y > spd_x * Mathf.Tan(MaxAngle_x * Mathf.Rad2Deg))
                            {
                                spd_y = spd_x * Mathf.Tan(MaxAngle_x * Mathf.Rad2Deg);
                                Debug.Log("+ angular limit");
                            }
                            if (spd_y < spd_x * Mathf.Tan(-MaxAngle_x * Mathf.Rad2Deg))
                            {
                                spd_y = spd_x * Mathf.Tan(-MaxAngle_x * Mathf.Rad2Deg);
                                Debug.Log("- angular limit");
                            }
                            Debug.Log("2> y,x,tan(x)" + spd_y + " " + spd_x + " " + spd_x * Mathf.Tan(MaxAngle_x * Mathf.Rad2Deg));



                            //                                                     Vector3 force = new Vector3(Mathf.Pow(spd_x, 0.8f), Mathf.Pow(spd_x, 0.8f), Mathf.Pow(spd_y, 0.8f));
                            Vector3 force = new Vector3(Mathf.Pow(spd_x, 0.8f) * Mathf.Cos(elevationAngle), Mathf.Pow(spd_x, 0.8f) * Mathf.Sin(elevationAngle), Mathf.Sign(spd_y) * Mathf.Pow(Mathf.Abs(spd_y), 0.8f));  // for debug
                                                                                                                                                                                                                         //  Vector3 force = new Vector3(spd_x * Mathf.Cos(elevationAngle), spd_x * Mathf.Sin(elevationAngle), spd_y);  // for debug
                            Debug.Log("spd_x,y " + spd_x + " " + spd_y + " " + spd_x * Mathf.Cos(elevationAngle) + " " + spd_x * Mathf.Sin(elevationAngle) + " " + Mathf.Sign(spd_y) * Mathf.Pow(Mathf.Abs(spd_y), 0.8f));
                            //           Vector3 force = new Vector3(spd_x, spd_x, spd_y);
                            //          Vector3 force = new Vector3(fixPower * Mathf.Cos(elevationAngle), fixPower * Mathf.Sin(elevationAngle), 0);  // for debug
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

            if (numBalls == maxNumBalls)
            {
                //   scoreTotalText.SetActive(true);
                isGameOver = true;
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

        if (scoreText.GetComponent<ScoreTextController>().score >= 5)
        {
            isGameOver = true;
        }
        
        
        // ゲームオーバーになった場合
        if (this.isGameOver == true)
        {
            scoreTotalText.GetComponent<Text>().text = scoreTotal.GetComponent<Scorer>().scoreTotal + " pts.";

            // クリックされたらシーンをロードする
            if (Input.GetMouseButtonDown(0))
            {
                //SampleSceneを読み込む
                SceneManager.LoadScene("TapTest");
            }
        }



        //キー入力でボールとばす版
        if (Input.anyKey && (Time.time - lastThrough > throughInterval) && (numBalls < maxNumBalls) && (isGameOver == false))
        {
            bool isThrough = false;
            Vector3 force = new Vector3(0, 0, 0);
            float xrand = Random.Range(-40.0f, 40.0f);
            float yrand = Random.Range(-30.0f, 30.0f);
            if (Input.GetKeyDown(KeyCode.Alpha1)) { force = new Vector3(power_x_far + xrand, power_x_far + xrand, power_y_left + yrand); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.Alpha2)) { force = new Vector3(power_x_far + xrand, power_x_far + xrand, power_y_center + yrand); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.Alpha3)) { force = new Vector3(power_x_far + xrand, power_x_far + xrand, power_y_right + yrand); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.Alpha4)) { force = new Vector3(power_x_middle + xrand, power_x_middle + xrand, power_y_left + yrand); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.Alpha5)) { force = new Vector3(power_x_middle + xrand, power_x_middle + xrand, power_y_center + yrand); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.Alpha6)) { force = new Vector3(power_x_middle + xrand, power_x_middle + xrand, power_y_right + yrand); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.Alpha7)) { force = new Vector3(power_x_near + xrand, power_x_near + xrand, power_y_left + yrand); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.Alpha8)) { force = new Vector3(power_x_near + xrand, power_x_near + xrand, power_y_center + yrand); isThrough = true; ; }
            if (Input.GetKeyDown(KeyCode.Alpha9)) { force = new Vector3(power_x_near + xrand, power_x_near + xrand, power_y_right + yrand); isThrough = true; }



            //正確版、、うまくいかない。Shiftにコードをとられる
            if (Input.GetKeyDown(KeyCode.Exclaim)) { force = new Vector3(power_x_far, power_x_far, power_y_left); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.DoubleQuote)) { force = new Vector3(power_x_far, power_x_far, power_y_center); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.Hash)) { force = new Vector3(power_x_far, power_x_far, power_y_right); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.Dollar)) { force = new Vector3(power_x_middle, power_x_middle, power_y_left); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.Percent)) { force = new Vector3(power_x_middle, power_x_middle, power_y_center); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.Ampersand)) { force = new Vector3(power_x_middle, power_x_middle, power_y_right); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.Quote)) { force = new Vector3(power_x_near, power_x_near, power_y_left); isThrough = true; }
            if (Input.GetKeyDown(KeyCode.LeftParen)) { force = new Vector3(power_x_near, power_x_near, power_y_center); isThrough = true; ; }
            if (Input.GetKeyDown(KeyCode.RightParen)) { force = new Vector3(power_x_near, power_x_near, power_y_right); isThrough = true; }

            //妥協案
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.Keypad1)) { force = new Vector3(power_x_far, power_x_far, power_y_left); isThrough = true; }
                if (Input.GetKeyDown(KeyCode.Keypad2)) { force = new Vector3(power_x_far, power_x_far, power_y_center); isThrough = true; }
                if (Input.GetKeyDown(KeyCode.Keypad3)) { force = new Vector3(power_x_far, power_x_far, power_y_right); isThrough = true; }
                if (Input.GetKeyDown(KeyCode.Keypad4)) { force = new Vector3(power_x_middle, power_x_middle, power_y_left); isThrough = true; }
                if (Input.GetKeyDown(KeyCode.Keypad5)) { force = new Vector3(power_x_middle, power_x_middle, power_y_center); isThrough = true; }
                if (Input.GetKeyDown(KeyCode.Keypad6)) { force = new Vector3(power_x_middle, power_x_middle, power_y_right); isThrough = true; }
                if (Input.GetKeyDown(KeyCode.Keypad7)) { force = new Vector3(power_x_near, power_x_near, power_y_left); isThrough = true; }
                if (Input.GetKeyDown(KeyCode.Keypad8)) { force = new Vector3(power_x_near, power_x_near, power_y_center); isThrough = true; ; }
                if (Input.GetKeyDown(KeyCode.Keypad9)) { force = new Vector3(power_x_near, power_x_near, power_y_right); isThrough = true; }
            }

            if ((isThrough == false) && (!Input.GetKey(KeyCode.LeftShift)))
            {
                float x_power = Random.Range(100.0f, 300.0f);
                float y_power = Random.Range(-100.0f, 100.0f);
                force = new Vector3(x_power, x_power, y_power); isThrough = true;
            }

            if (isThrough)
            {
                GameObject ball = Instantiate(ballPrefab);
                ball.transform.position = new Vector3(0, 2, 0);
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                rb.AddForce(force);
                lastThrough = Time.time;
                numBalls += 1;
            }

            if (numBalls == maxNumBalls)
            {
                //   scoreTotalText.SetActive(true);
                isGameOver = true;
            }


        }
    }

}
