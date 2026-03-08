using UnityEngine;
using UnityEngine.UI;

public class L3 : MonoBehaviour
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

    void Update()
    {
        // 检测点亮条件
        if (Gameprogress.i==3&&PC6.p6 == 0&&PC5.p5 == 1)
        {
            Gameprogress.i=Gameprogress.i+1;
            SwitchImage();
        }
    }

    /// <summary>
    /// 切换图片
    /// </summary>
    private void SwitchImage()
    {
        isShowingSprite1 = !isShowingSprite1;
        image.sprite = isShowingSprite1 ? sprite1 : sprite2;
    }
}
