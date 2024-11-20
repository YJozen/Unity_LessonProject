using UnityEngine;
using TMPro;

public class TextMeshProAnimator : MonoBehaviour
{
    [SerializeField] private Gradient gradientColor;
    private TMP_Text textComponent;
    private TMP_TextInfo textInfo;

    private void Update()
    {
        if (this.textComponent == null)
            this.textComponent = GetComponent<TMP_Text>();

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        // ① メッシュを再生成する（リセット）
        this.textComponent.ForceMeshUpdate(true);
        this.textInfo = textComponent.textInfo;

        // ②頂点データを編集した配列の作成
        var count = Mathf.Min(this.textInfo.characterCount, this.textInfo.characterInfo.Length);
        for (int i = 0; i < count; i++)
        {
            var charInfo = this.textInfo.characterInfo[i];
            if (!charInfo.isVisible)
                continue;

            int materialIndex = charInfo.materialReferenceIndex;
            int vertexIndex = charInfo.vertexIndex;

            // // Gradient
            // Color32[] colors = textInfo.meshInfo[materialIndex].colors32;

            // float timeOffset = -0.5f * i;
            // float time1 = Mathf.PingPong(timeOffset + Time.realtimeSinceStartup, 1.0f);
            // float time2 = Mathf.PingPong(timeOffset + Time.realtimeSinceStartup - 0.1f, 1.0f);
            // colors[vertexIndex + 0] = gradientColor.Evaluate(time1); // 左下
            // colors[vertexIndex + 1] = gradientColor.Evaluate(time1); // 左上
            // colors[vertexIndex + 2] = gradientColor.Evaluate(time2); // 右上
            // colors[vertexIndex + 3] = gradientColor.Evaluate(time2); // 右下




                    // Wave
        Vector3[] verts = textInfo.meshInfo[materialIndex].vertices;

        float sinWaveOffset = 0.5f * i;
        float sinWave = Mathf.Sin(sinWaveOffset + Time.realtimeSinceStartup * Mathf.PI);
        verts[vertexIndex + 0].y += sinWave;
        verts[vertexIndex + 1].y += sinWave;
        verts[vertexIndex + 2].y += sinWave;
        verts[vertexIndex + 3].y += sinWave;






        }

        // ③ メッシュを更新
        for (int i = 0; i < this.textInfo.materialCount; i++)
        {
            if (this.textInfo.meshInfo[i].mesh == null) { continue; }

            // this.textInfo.meshInfo[i].mesh.colors32 = this.textInfo.meshInfo[i].colors32;
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;  // 変更

            textComponent.UpdateGeometry(this.textInfo.meshInfo[i].mesh, i);
        }
    }
}