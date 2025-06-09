using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerDownHandler, IDragHandler
{

    private Vector2 pointerOffset;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform borderRectTransform;
    private Canvas canvas;
    
    void Awake()
    {
        canvas = GetComponentInParent<Canvas>(); // Canvas referansý (zorunlu)
    }

    public void OnPointerDown(PointerEventData eventData)
    {
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
                // Mouse pozisyonuna offset ekleyerek düzgün sürükleme
                rectTransform.localPosition = localMousePosition - pointerOffset;
            }
        
    }


    private void Update()
    {
        Vector2 anchoredPosition = rectTransform.anchoredPosition;

        Vector2 minPosition = borderRectTransform.rect.min + borderRectTransform.anchoredPosition;
        Vector2 maxPosition = borderRectTransform.rect.max + borderRectTransform.anchoredPosition;

        // Clamp pozisyon
        anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, minPosition.x, maxPosition.x);
        anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, minPosition.y, maxPosition.y);

        rectTransform.anchoredPosition = anchoredPosition;

    }
}
