using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillerController : MonoBehaviour
{
    private float timeToDestoroy;�@�@//�|�ꂽ���Ƃ��΂炭�c�����߂̃^�C�}�[�i���ꂩ������j

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //���� �yUnity�z�L�����N�^�[���u�|�ꂽ���v���X�}�[�g�ɔ���
        //https://www.zkn0hr.com/unity-check-toppled/

        float angle = Vector3.Angle(Vector3.up, transform.up);
        if (angle > 90.0f)
        {
            Destroy(this.gameObject);
        }
    }
}