using UnityEngine;

public class yido : MonoBehaviour
{
    [Header("图片对象")]
    public Picturechange[] pictures;
    
    [Header("状态名称")]
    public string[] statusNames = {"A", "B", "C", "D", "E"};
    
    [Header("检测选项")]
    public bool autoDetect = true; // 自动检测开关
    public float detectionInterval = 0.1f; // 检测间隔
    
    private string lastStatus = "";
    private float lastCheckTime = 0f;

    void Start()
    {
        // 自动查找所有Picturechange组件
        if (pictures == null || pictures.Length == 0)
        {
            pictures = FindObjectsOfType<Picturechange>();
        }
        
        Debug.Log($"[相邻检测系统] 启动成功！检测到 {pictures.Length} 张图片");
        
        if (pictures.Length < 2)
        {
            Debug.LogWarning("至少需要2张图片才能进行相邻检测！");
            autoDetect = false;
        }
        else
        {
            // 初始状态检测
            CheckAllPicturesStatus();
        }
    }

    void Update()
    {
        if (!autoDetect || pictures.Length < 2) return;
        
        // 按间隔时间检测
        if (Time.time - lastCheckTime >= detectionInterval)
        {
            lastCheckTime = Time.time;
            CheckAllPicturesStatus();
        }
        
        // 空格键手动检测
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("=== 手动检测 ===");
            CheckAllPicturesStatus();
        }
    }
    
    void CheckAllPicturesStatus()
    {
        // 获取当前所有状态
        string currentStatus = GetAllStatusString();
        
        // 状态变化时输出
        if (currentStatus != lastStatus)
        {
            lastStatus = currentStatus;
            Debug.Log($"📊 状态更新: {currentStatus}");
        }
        
        // 检查相邻匹配
        CheckAdjacentMatch();
    }
    
    void CheckAdjacentMatch()
    {
        bool foundMatch = false;
        
        for (int i = 0; i < pictures.Length - 1; i++)
        {
            if (pictures[i].isFirst == pictures[i + 1].isFirst)
            {
                string status1 = GetStatusName(i);
                string status2 = GetStatusName(i + 1);
                Debug.Log($"🎯 相邻匹配！位置[{i}]↔[{i + 1}]: {status1} == {status2}");
                foundMatch = true;
            }
        }
        
        if (!foundMatch && pictures.Length >= 2)
        {
            Debug.Log("❌ 无相邻图片状态匹配");
        }
    }
    
    string GetAllStatusString()
    {
        if (pictures.Length == 0) return "";
        
        string result = "";
        for (int i = 0; i < pictures.Length; i++)
        {
            string status = GetStatusName(i);
            result += $"[{i}]{status} ";
        }
        return result.Trim();
    }
    
    string GetStatusName(int index)
    {
        if (index < 0 || index >= pictures.Length) return "未知";
        
        int statusIndex = pictures[index].isFirst ? 0 : 1;
        if (statusIndex >= 0 && statusIndex < statusNames.Length)
        {
            return statusNames[statusIndex];
        }
        return "未知";
    }
}