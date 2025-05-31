using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public Vector2 xOffset;
    public Vector2 yOffset;

    private Vector2 pointerOffset;
    [SerializeField] private RectTransform rectTransform;
    private Canvas canvas;

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>(); // Canvas referans� (zorunlu)
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // T�klanan noktadaki offseti kaydet
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out pointerOffset
        );
    }

    public void OnDrag(PointerEventData eventData)
    {

            Vector2 localMousePosition;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out localMousePosition))
            {
                // Mouse pozisyonuna offset ekleyerek d�zg�n s�r�kleme
                rectTransform.localPosition = localMousePosition - pointerOffset;
            }
        
    }


    private void Update()
    {
        if (rectTransform.anchoredPosition.x < xOffset.x)
        {
            rectTransform.anchoredPosition = new Vector2(xOffset.x, rectTransform.anchoredPosition.y);
        }
        if (rectTransform.anchoredPosition.x > xOffset.y)
        {
            rectTransform.anchoredPosition = new Vector2(xOffset.y, rectTransform.anchoredPosition.y);
        }
        if (rectTransform.anchoredPosition.y < yOffset.x)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, yOffset.x);
        }
        if (rectTransform.anchoredPosition.y > yOffset.y)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, yOffset.y);
        }

    }
}
