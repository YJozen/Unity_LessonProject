// AIが共有する情報を保存・管理するデータストレージ
// 複数のAIノードが共通して利用する情報（例えば、プレイヤーの位置や敵のヘルス状態など）を格納します。

using System.Collections.Generic;

namespace Blackboard
{
    public class Blackboard
    {
        private Dictionary<string, object> data = new Dictionary<string, object>();

        public void SetValue<T>(string key, T value)
        {
            data[key] = value;
        }

        public T GetValue<T>(string key)
        {
            if (data.TryGetValue(key, out var value))
            {
                return (T)value;
            }
            return default(T);
        }
    }
}