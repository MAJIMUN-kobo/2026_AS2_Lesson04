using UnityEngine;

// =======================================
// ゲーム全体の管理クラス
// =======================================
public class GameManager : MonoBehaviour
{
    // - クラスの目的
    // ゲーム全体のパラメータやオブジェクトの管理

    // - 使い方
    // GameManagerクラスをシーンに配置するだけでOK

    // === 変数宣言 === //
    private Spawner _spawner;       // オブジェクト生成クラスの参照

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spawner = new Spawner();       // オブジェクト生成クラスのインスタンス化
        _spawner.LoadAsync("Prefabs");  // Prefabsラベルのオブジェクトを非同期でロード
    }

    // Update is called once per frame
    void Update()
    {
        if(_spawner.IsLoaded)
        {
            _spawner.Spawn(1);           // オブジェクトの生成メソッドを呼び出す
            _spawner.Spawn("Item");
        }
    }
}
    