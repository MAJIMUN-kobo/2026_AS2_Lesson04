using Cysharp.Threading.Tasks;          // UniTask
using System.Collections.Generic;       // List系
using System.Linq;                      // 配列変換(ToArray()とか...)
using UnityEngine;                      // Unityメインシステム
using UnityEngine.AddressableAssets;    // Addressables

// =================================
// オブジェクト生成クラス
// =================================
public class Spawner
{
    // - クラスの目的
    // オブジェクト（プレハブ）を生成すること

    // - 使い方
    // Spawn() メソッドを呼び出すだけ

    // === 変数宣言 === //
    private GameObject[] _prefabs;  // 生成するプレハブの参照
    public bool IsLoaded = false;

    // === アセット読み込みメソッド（非同期） === //
    public async void LoadAsync( string label )
    {
        var handle = Addressables.LoadAssetsAsync<GameObject>( label );
        IList<GameObject> result = await handle.ToUniTask();
        // === await より後は読み込みが終わっている === //

        // 変数に読み込み結果を代入
        _prefabs = result.ToArray();
        IsLoaded = true;
    }

    // === 配列の添え字を指定して生成できるSpawnメソッド === //
    public void Spawn(int index)
    {
        if (IsLoaded)
        {
            GameObject.Instantiate(_prefabs[index]);
        }
        else
        {
            Debug.Log("[Spawner.cs] Now Loading...");
        }
    }

    // === プレハブの"名前を指定"して生成できるSpawnメソッド === //
    public void Spawn(string assetName)
    {
        // 配列の要素全てからプレハブの名前を検索/取得する
        for(int index = 0; index < _prefabs.Length; index++)
        {
            Debug.Log($"検索中...読み込みアセット名:{_prefabs[index].name}");
            // 読み込んだプレハブと、指定された名前が一致したら生成する
            if (_prefabs[index].name == assetName)
            {
                // プレハブの生成
                GameObject.Instantiate(_prefabs[index]);
                break;  // 見つかったらループを抜ける
            }
        }
    }
}
