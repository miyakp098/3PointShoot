using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject ballPrefab; // Inspectorから設定する球のプレハブ
    public float launchVelocity = 10f; // 発射速度

    void Update()
    {
        // エンターキーが押されたとき
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        // プレハブから球をインスタンス化し、現在のオブジェクトの位置と回転で設定
        GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);

        // Rigidbodyを取得
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        // Y軸とZ軸の両方に45度回転したベクトルを生成
        Vector3 launchDirection = (Quaternion.Euler(-45, 0, 45) * transform.forward).normalized;

        // Rigidbodyに力を加えて発射
        rb.velocity = launchDirection * launchVelocity;
    }
}
