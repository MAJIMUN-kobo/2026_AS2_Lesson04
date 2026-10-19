using UnityEngine;
using UnityEngine.InputSystem;

public class ResultSceneState : ISceneState
{
    // === Valiables === //
    private GameManager _gameManager;

    // === 開始処理
    public void EnterState()
    {
        Debug.Log($"{GetType().Name} 始まるよ");

        _gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    // === 実行処理（ループ）
    public void ExecuteState()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {   // 左クリックするとゲーム画面に切り替え
            _gameManager.ChangeSceneState(new TitleSceneState());
        }
    }

    // === 終了処理
    public void ExitState()
    {
        Debug.Log($" {GetType().Name} が終わるよ");
    }
}
