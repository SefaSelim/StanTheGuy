using UnityEngine;

public class UICursorFollow : MonoBehaviour
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
            out localPoint
        );

        rectTransform.anchoredPosition = localPoint;
    }
}
