using UnityEngine;

public class MouseDragDistance : MonoBehaviour
{
    private Vector2 startScreenPosition;
    private Vector2 endScreenPosition;
    private float x;
    private float y;

    public GameObject SetBall;
    private bool isDragging = false;
    public GameObject ballPrefab; // Inspectorから設定する球のプレハブ
    public float launchVelocity = 10f; // 発射速度
    public float spinPower = -1f; // 回転力

    private MeshRenderer meshRenderer;

    // マウスポジションを格納する変数
    private Vector3 mouseScreenPosition;

    private void Start()
    {
        meshRenderer = SetBall.GetComponent<MeshRenderer>();
    }

    void Update()
    {

        // 左クリックが押されているかチェック
        if (Input.GetMouseButton(0)) // 0は左クリックを意味します
        {
            meshRenderer.enabled = true;
            // 現在のマウスのスクリーンポジションを取得
            mouseScreenPosition = Input.mousePosition;
            SetBall.transform.localPosition = new Vector3(0, mouseScreenPosition.y/100, 0);
            // デバッグログにポジションを表示
            Debug.Log(mouseScreenPosition);
        }
        else
        {
            meshRenderer.enabled = false;
            
        }

        // マウスの左ボタンが押されたとき
        if (Input.GetMouseButtonDown(0))
        {
            startScreenPosition = Input.mousePosition;
            isDragging = true;
        }
        
        // マウスの左ボタンが離されたとき
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            endScreenPosition = Input.mousePosition;
            isDragging = false;

            // スクリーン上の距離とベクトルを計算
            float distance = Vector2.Distance(startScreenPosition, endScreenPosition);
            if(distance > 380)
            {
                distance = 380;
            }
            Vector2 directionVector = (endScreenPosition - startScreenPosition).normalized;
            //x = startScreenPosition.x - endScreenPosition.x;
            //y = startScreenPosition.y - endScreenPosition.y;
            x = directionVector.x;
            y = directionVector.y;

            Debug.Log($"Screen Distance: {distance}, {x}, {y}");
            //Debug.Log($"Screen Direction Vector: {directionVector}");
            if(y < 0)
            {
                return;
            }
            LaunchBallWithSpin(distance,x,y);
            SetBall.transform.localPosition = new Vector3(0, 2, 0);
        }
    }

    void LaunchBallWithSpin(float dis,float dirX, float dirY)
    {
        // プレハブから球をインスタンス化し、現在のオブジェクトの位置で設定
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);

        // Rigidbodyを取得
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        // ベクトルを生成
        Vector3 launchDirection = Quaternion.Euler(-60, dirX*50, 0) * Vector3.forward;

        // Rigidbodyに力を加えて発射
        rb.AddForce(launchDirection * dis * dirY / 10, ForceMode.VelocityChange);

        // X軸で回転するトルクを加える
        rb.AddTorque(Vector3.right * spinPower, ForceMode.Impulse);
    }
}
