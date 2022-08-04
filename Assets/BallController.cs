using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    GameObject g;
    Rigidbody rb;
    GameObject scoreText;

    float born;
    public Vector3 force = new Vector3(0.0f, 0.0f, 1.0f);    // óÕÇê›íË
    private bool isGoal;

    // Start is called before the first frame update
    void Start()
    {
        //        g = GameObject.Find("BallPrefab");
        //        rb = this.GetComponent<Rigidbody>();  // rigidbodyÇéÊìæ
        //        rb.AddForce(force, ForceMode.Impulse);  // óÕÇâ¡Ç¶ÇÈ
        g = GameObject.Find("GameObject");
        rb = GetComponent<Rigidbody>();
        born = Time.time;
        isGoal = false;

        scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - born > 3.0f)
        {
            var velocity = rb.velocity;
            if (velocity.sqrMagnitude < 0.01f)
            {
                //    Debug.Log("STOP");
                if (this.isGoal == false)
                {
                    Destroy(this.gameObject);
                    g.GetComponent<TapTest>().numBalls -= 1;
                }
            }
          //  Debug.Log(velocity.sqrMagnitude);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        //GoalÇ…è’ìÀÇµÇΩèÍçá
        if (other.gameObject.tag == "GoalTag")
        {
            Debug.Log("touch GoalCircle");
            this.isGoal = true;
            scoreText.GetComponent<ScoreTextController>().score += 1;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        //GoalÇ…è’ìÀÇµÇΩèÍçá
        if (other.gameObject.tag == "GoalTag")
        {
            Debug.Log("detouch GoalCircle");
            this.isGoal = false;
            scoreText.GetComponent<ScoreTextController>().score -= 1;
        }
    }
}
