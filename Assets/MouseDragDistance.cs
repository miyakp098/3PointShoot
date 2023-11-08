using UnityEngine;

public class MouseDragDistance : MonoBehaviour
{
    private Vector2 startScreenPosition;
    private Vector2 endScreenPosition;
    private bool isDragging = false;

    void Update()
    {
        // �}�E�X�̍��{�^���������ꂽ�Ƃ�
        if (Input.GetMouseButtonDown(0))
        {
            startScreenPosition = Input.mousePosition;
            isDragging = true;
        }

        // �}�E�X�̍��{�^���������ꂽ�Ƃ�
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            endScreenPosition = Input.mousePosition;
            isDragging = false;

            // �X�N���[����̋����ƃx�N�g�����v�Z
            float distance = Vector2.Distance(startScreenPosition, endScreenPosition);
            Vector2 directionVector = (endScreenPosition - startScreenPosition).normalized;

            Debug.Log($"Screen Distance: {distance}");
            Debug.Log($"Screen Direction Vector: {directionVector}");
        }
    }
}
