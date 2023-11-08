using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject ballPrefab; // Inspector����ݒ肷�鋅�̃v���n�u
    public float launchVelocity = 10f; // ���ˑ��x

    void Update()
    {
        // �G���^�[�L�[�������ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        // �v���n�u���狅���C���X�^���X�����A���݂̃I�u�W�F�N�g�̈ʒu�Ɖ�]�Őݒ�
        GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);

        // Rigidbody���擾
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        // Y����Z���̗�����45�x��]�����x�N�g���𐶐�
        Vector3 launchDirection = (Quaternion.Euler(-45, 0, 45) * transform.forward).normalized;

        // Rigidbody�ɗ͂������Ĕ���
        rb.velocity = launchDirection * launchVelocity;
    }
}
