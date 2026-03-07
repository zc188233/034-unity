using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PictureChange : MonoBehaviour, IPointerClickHandler
{
    [Header("图片数组")]
    public Sprite[] pictures; // 拖拽3张图片到这里
    
    [Header("UI组件")]
    public Image displayImage; // 显示图片的Image组件
    
    [Header("点击检测")]
    [SerializeField] private bool debugMode = true; // 调试模式
    
    private int currentIndex = 0;
    private bool clickEnabled = true;

    void Start()
    {
        // 自动获取Image组件
        if (displayImage == null)
            displayImage = GetComponent<Image>();
            
        // 显示第一张图片
        if (pictures.Length > 0)
            displayImage.sprite = pictures[0];
            
        // 检查必要组件
        CheckRequiredComponents();
        
        if (debugMode)
            Debug.Log("[PictureChange] 脚本初始化完成，当前图片: " + (currentIndex + 1));
    }
    
    // 检查必要组件
    private void CheckRequiredComponents()
    {
        // 检查Image组件
        if (displayImage == null)
        {
            Debug.LogError("[PictureChange] 未找到Image组件！");
            clickEnabled = false;
            return;
        }
        
        // 检查Raycast Target
        if (!displayImage.raycastTarget)
        {
            Debug.LogWarning("[PictureChange] Image组件的Raycast Target未启用，正在自动启用...");
            displayImage.raycastTarget = true;
        }
        
        // 检查EventSystem
        if (FindObjectOfType<EventSystem>() == null)
        {
            Debug.LogError("[PictureChange] 未找到EventSystem！请确保场景中有EventSystem。");
            clickEnabled = false;
        }
    }
    
    // UI点击事件（推荐方式）
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!clickEnabled) return;
        
        if (debugMode)
            Debug.Log("[PictureChange] UI点击事件触发！");
            
        NextPicture();
    }
    
    // 切换到下一个图片
    public void NextPicture()
    {
        if (pictures == null || pictures.Length == 0)
        {
            Debug.LogError("[PictureChange] 图片数组为空！");
            return;
        }
        
        currentIndex = (currentIndex + 1) % pictures.Length;
        displayImage.sprite = pictures[currentIndex];
        
        if (debugMode)
            Debug.Log("[PictureChange] 切换到图片: " + (currentIndex + 1));
    }
    
    // 测试点击是否有效
    public void TestClick()
    {
        Debug.Log("[PictureChange] 测试点击 - 当前图片: " + (currentIndex + 1));
        NextPicture();
    }
}