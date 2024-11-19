using Cysharp.Threading.Tasks;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace MyNamespace
{
    public class EnemyManager2 : MonoBehaviour
    {
        EnemySetting m_enemySetting;
        AsyncOperationHandle<EnemySetting> m_enemySettingHandle;

        private async void Start() {
            await LoadData();
        }

        async UniTask LoadData() {
            // LoadAssetAsyncでハンドルを取得し、保持する
            m_enemySettingHandle = Addressables.LoadAssetAsync<EnemySetting>("EnemySetting");

            // ロード完了まで待機
            m_enemySetting = await m_enemySettingHandle;

            //スライムのデータを取得 (EnemySettingクラスのDataListリストから、要素.idがSlimeの、EnemyData型を所持する)
            var slimeData = m_enemySetting.DataList.FirstOrDefault(enemy => enemy.Id == "Slime");
            
            if (slimeData != null)
            {
                Debug.Log($"ID：{slimeData.Id}");
                Debug.Log($"Hp：{slimeData.Hp}");
                Debug.Log($"攻撃力：{slimeData.Attack}");
                Debug.Log($"防御力：{slimeData.Defense}");
                Debug.Log($"経験値：{slimeData.Exp}");
            }
            else
            {
                Debug.LogWarning("Slime data not found.");
            }
        }
        
        // 再生終了時などにアセットを解放
        private void OnDestroy()
        {
            // Addressables.Releaseでメモリを解放
            if (m_enemySettingHandle.IsValid())
            {
                Addressables.Release(m_enemySettingHandle);
            }
        }
    }
}
