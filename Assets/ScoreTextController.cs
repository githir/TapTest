using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour
{
    //�X�R�A��\������e�L�X�g
    private GameObject scoreText;
    //���_
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        //�V�[������scoreText�I�u�W�F�N�g���擾
        this.scoreText = GameObject.Find("ScoreText");
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = " "+score;
    }
}
