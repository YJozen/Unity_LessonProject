using Services;
using UnityEngine;

/// <summary>
/// プロジェクト初期化クラス
/// </summary>
public static class ProjectInitializer
{
    /// <summary>
    /// 初期化処理(シーンのロード前に呼ばれる)
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        try
        {
            // サービス登録
            ServiceLocator.Register<IPlayerPrefsService>(new PlayerPrefsService());
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Exception in ProjectInitializer: {ex.Message}\n{ex.StackTrace}");
        }
    }
}