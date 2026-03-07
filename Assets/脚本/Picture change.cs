using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Picturechange : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    
    private Image image;
    private bool isShowingSprite1 = true;

    void Start()
    {
        image = GetComponent<Image>();
        if (image == null) image = gameObject.AddComponent<Image>();
        if (sprite1 != null) image.sprite = sprite1;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isShowingSprite1 = !isShowingSprite1;
        image.sprite = isShowingSprite1 ? sprite1 : sprite2;
    }
}