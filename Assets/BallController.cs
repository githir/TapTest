using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    GameObject g;
    Rigidbody rb;
    GameObject scoreText;

    float born;
    public Vector3 force = new Vector3(0.0f, 0.0f, 1.0f);    // �͂�ݒ�
    private bool isGoal = false;

    private int myScore =0; //�����������Ă���ʂ̐�
    public GameObject myHomeObject;

    // Start is called before the first frame update
    void Start()
    {
        //        g = GameObject.Find("BallPrefab");
        //        rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
        //        rb.AddForce(force, ForceMode.Impulse);  // �͂�������
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
        //Goal�G���A�ɓ������ꍇ
        if ((other.gameObject.tag == "GoalTag") && (this.isGoal != true))
        {
            Debug.Log("touch GoalArea");
            this.isGoal = true;
            scoreText.GetComponent<ScoreTextController>().score += 1;
            Debug.Log("score +=1 -> " + scoreText.GetComponent<ScoreTextController>().score);

            myHomeObject = other.gameObject;
     //       myScore += 1;
     //       Debug.Log("get" + myHomeObject.name + ":" + myScore);
        }
        //NoGoal�G���A�ɓ������ꍇ
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
        //������Goal�G���A����O�ꂽ�ꍇ
        if (other.gameObject.tag == "GoalAreaTag")
        {
            Debug.Log("detouch GoalCircle");
            this.isGoal = false;
            scoreText.GetComponent<ScoreTextController>().score -= 1;
            myScore -= 1; //�{�[�����Ȃ��Ȃ���
            Debug.Log("lost" + myHomeObject.name + ":" + myScore);
        }
    }
    */
}
