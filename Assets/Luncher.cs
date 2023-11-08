using UnityEngine;

public class LauncherWithSpin : MonoBehaviour
{
    public GameObject ballPrefab; // Inspectorから設定する球のプレハブ
    public float launchVelocity = 10f; // 発射速度
    public float spinPower = -1f; // 回転力

    void Update()
    {
        // エンターキーが押されたとき
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LaunchBallWithSpin();
        }
    }

    void LaunchBallWithSpin()
    {
        // プレハブから球をインスタンス化し、現在のオブジェクトの位置で設定
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);

        // Rigidbodyを取得
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        // Y軸とZ軸の両方に45度回転したベクトルを生成
        Vector3 launchDirection = Quaternion.Euler(-60, 0, 0) * Vector3.forward;

        // Rigidbodyに力を加えて発射
        rb.AddForce(launchDirection * launchVelocity, ForceMode.VelocityChange);

        // X軸で回転するトルクを加える
        rb.AddTorque(Vector3.right * spinPower, ForceMode.Impulse);
    }
}
