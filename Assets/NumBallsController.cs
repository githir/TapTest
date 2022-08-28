using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumBallsController : MonoBehaviour
{
    //ボールの数を表示するテキスト
    private GameObject numBallText;
    private GameObject scorer;

    // Start is called before the first frame update
    void Start()
    {
        this.numBallText = GameObject.Find("NumBallsText");
        // this.scorer = GameObject.Find("Scorer")
        this.scorer = GameObject.Find("MyGameObject");
    }

    // Update is called once per frame
    void Update()
    {
        string str = scorer.GetComponent<TapTest>().numBalls + "/" + scorer.GetComponent<TapTest>().maxNumBalls;
        numBallText.GetComponent<Text>().text = str;
    }
}
