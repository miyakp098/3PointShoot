using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public float jumpForce = 7f; // ジャンプの力
    private Rigidbody rb;
    private bool isGrounded; // 地面にいるかどうかのフラグ

    void Start()
    {
        // Rigidbody コンポーネントを取得
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // スペースキーが押されたかどうかをチェックし、地面にいるかどうかを確認
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // 上方向に力を加えてジャンプ
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // 地面に触れているかどうかを判定
    void OnCollisionEnter(Collision collision)
    {
        // "Ground"というタグが付いているオブジェクトに触れた場合、isGroundedをtrueにする
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // 地面から離れたことを判定
    void OnCollisionExit(Collision collision)
    {
        // "Ground"というタグが付いているオブジェクトから離れた場合、isGroundedをfalseにする
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
