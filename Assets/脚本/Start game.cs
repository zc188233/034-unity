using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景名称枚举 - 在这里定义你的所有场景
/// </summary>
public enum GameScene
{
    MainMenu,       // 主菜单场景
    GamePlay,       // 游戏主场景  
    Settings,       // 设置界面
    GameOver,       // 游戏结束
    Victory         // 胜利界面
}

/// <summary>
/// 场景跳转管理器 - 处理所有场景切换功能
/// </summary>
public class StartGame : MonoBehaviour
{
    [Header("按钮跳转设置")]
    [Tooltip("在Inspector中选择按钮要跳转的目标场景")]
    [SerializeField] private GameScene targetScene = GameScene.GamePlay;

    [Header("调试信息")]
    [SerializeField] private string currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log($"场景跳转器已启动，当前场景: {currentScene}");
    }

    /// <summary>
    /// 跳转到预设目标场景（用于按钮绑定）
    /// </summary>
    public void LoadTargetScene()
    {
        string sceneName = GetSceneName(targetScene);
        if (!string.IsNullOrEmpty(sceneName))
        {
            Debug.Log($"正在跳转到场景: {targetScene} ({sceneName})");
            SceneManager.LoadScene(sceneName);
        }
    }

    /// <summary>
    /// 重新加载当前场景
    /// </summary>
    public void ReloadCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }


    /// <summary>
    /// 获取场景名称映射
    /// </summary>
    private string GetSceneName(GameScene scene)
    {
        switch (scene)
        {
            case GameScene.MainMenu: return "主界面";
            case GameScene.GamePlay: return "游戏界面";
            case GameScene.Settings: return "Settings";
            case GameScene.GameOver: return "GameOver";
            case GameScene.Victory: return "Victory";
            default: return "";
        }
    }
}