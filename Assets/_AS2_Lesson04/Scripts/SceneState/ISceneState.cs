using UnityEngine;

/// <summary>
/// 〇〇SceneStateのインターフェース
/// ===========================================
/// ここに書かれているメソッドは継承先で<必ず>
/// 実装しなければならない。
/// </summary>
public interface ISceneState
{
    void EnterState();
    void ExecuteState();
    void ExitState();
}
