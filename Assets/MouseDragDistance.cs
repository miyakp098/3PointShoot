using UnityEngine;

public class MouseDragDistance : MonoBehaviour
{
    private Vector2 startScreenPosition;
    private Vector2 endScreenPosition;
    private bool isDragging = false;

    void Update()
    {
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
            Vector2 directionVector = (endScreenPosition - startScreenPosition).normalized;

            Debug.Log($"Screen Distance: {distance}");
            Debug.Log($"Screen Direction Vector: {directionVector}");
        }
    }
}
