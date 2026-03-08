using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Picturechange : MonoBehaviour, IPointerClickHandler
{
    [Header("图片设置")]
    public Sprite sprite1;
    public Sprite sprite2;
    
    [Header("状态设置")]
    public string[] statusNames = {"A", "B", "C", "D", "E"};
    [HideInInspector] public bool isFirst = true;
    
    private Image image;
    private string currentStatus;

    void Start()
    {
        image = GetComponent<Image>() ?? gameObject.AddComponent<Image>();
        if (sprite1 != null) 
        {
            image.sprite = sprite1;
            currentStatus = statusNames[0];
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isFirst = !isFirst;
        image.sprite = isFirst ? sprite1 : sprite2;
        currentStatus = isFirst ? statusNames[0] : statusNames[1];
        
        // 输出当前状态变化
        Debug.Log($"[图片{transform.GetSiblingIndex()}] 切换到: {currentStatus}");
    }
    
    public string GetCurrentStatus()
    {
        return currentStatus;
    }
}