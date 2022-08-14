using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    GameObject g;
    Rigidbody rb;
    GameObject scoreText;

    float born;
    public Vector3 force = new Vector3(0.0f, 0.0f, 1.0f);    // 力を設定
    private bool isGoal = false;

    private int myScore = 0; //自分が持っている玉の数
    public GameObject myHomeObject;

    // Start is called before the first frame update
    void Start()
    {
        //        g = GameObject.Find("BallPrefab");
        //        rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
        //        rb.AddForce(force, ForceMode.Impulse);  // 力を加える
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
    //    private void OnCollisionEnter(Collision collision)
    {
        //    Debug.Log("enter ;" + other.tag);
        Debug.Log("isGoal " + isGoal);
        //Goalエリアに入った場合
        if (other.gameObject.tag == "GoalTag")
        {
            Debug.Log("touch GoalArea");
            myHomeObject = other.gameObject;

            if (this.isGoal != true)
            {
                this.isGoal = true;
                scoreText.GetComponent<ScoreTextController>().score += 1;
                Debug.Log("score +=1 -> " + scoreText.GetComponent<ScoreTextController>().score);

                //       myScore += 1;
                //       Debug.Log("get" + myHomeObject.name + ":" + myScore);
            }
        }

        //NoGoalエリアに入った場合
        if (other.gameObject.tag == "NoGoalAreaTag" && this.isGoal == true)
        //            if (other.gameObject.tag == "NoGoalAreaTag")
        {
            Debug.Log("touch NoGoalArea");
            this.isGoal = false;
            scoreText.GetComponent<ScoreTextController>().score -= 1;
            Debug.Log("score -=1 -> " + scoreText.GetComponent<ScoreTextController>().score);
            //      myScore -= 1;
            //      Debug.Log("lost" + myHomeObject.name + ":" + myScore);
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    // private void OnCollisionExit(Collision collision)
    {
        Debug.Log("exit ;" + other.tag);
        //自分のGoalエリアから外れた場合
        if (other.gameObject.tag == "GoalAreaTag")
        {
            Debug.Log("detouch GoalCircle");
            this.isGoal = false;
            scoreText.GetComponent<ScoreTextController>().score -= 1;
            myScore -= 1; //ボールいなくなった
            Debug.Log("lost" + myHomeObject.name + ":" + myScore);
        }
    }
    */
}
