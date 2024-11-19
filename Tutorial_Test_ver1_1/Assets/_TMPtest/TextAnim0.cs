// a
// <link = tag1><color=yellow>b</color></link>
// cd
// <link = tag2><color=yellow>ef</color></link>
// ghij
// <link = tag3><color=yellow>klmno</color></link>
// p
// <link = tag4><color=yellow>qr</color></link>
// stuvw


// using UnityEngine;
// using TMPro;

// /// <summary>
// /// 指定範囲のテキストが壊れるようなアニメーションするコンポ―ネント
// /// </summary>
// [RequireComponent(typeof(TMP_Text))]
// public class TextAnim0 : MonoBehaviour
// {
// 	/// <summary>TextMeshPro Textコンポーネント</summary>
// 	private TMP_Text textComponent = null;

//     //①時間を制御
// 	/// <summary>ループするかどうか</summary>
// 	[SerializeField]
// 	private bool isLoop = false;
// 	/// <summary>グラデーションカラー</summary>
// 	[SerializeField]
// 	private Gradient gradientColor;
// 	/// <summary>アニメーション最大時間</summary>
// 	[SerializeField]
// 	private float maxTime = 1f;
// 	/// <summary>アニメーション時間</summary>
// 	private float time = 0f;

// 	/// <summary>再生フラグ</summary>
// 	private bool isPlaying = false;


// 	/// <summary>
// 	/// Unity Event Awake
// 	/// </summary>
// 	private void Awake()
// 	{
// 		this.textComponent = GetComponent<TMP_Text>();
// 	}
// 	/// <summary>
// 	/// Unity Event Update
// 	/// </summary>
// 	private void Update()
// 	{
		
// 		// ①時間制御
// 		if (this.isPlaying || this.isLoop)
// 		{
// 			this.time += Time.deltaTime;

// 			if (this.isLoop)
// 			{
// 				if (this.time >= this.maxTime)
// 					this.time -= this.maxTime;
// 			}
// 			else
// 			{
// 				if (this.time >= this.maxTime)
// 				{
// 					this.time = this.maxTime;
// 					this.isPlaying = false;
// 				}
// 			}

// 			UpdateAnimation(this.time / this.maxTime);
// 		}
// 	}

// 	/// <summary>
// 	/// アニメーション更新
// 	/// </summary>
//     /// <param name="time">アニメーション時間</param>
// 	private void UpdateAnimation(float time)
// 	{
// 		// ②ジオメトリ情報を初期化
// 		this.textComponent.ForceMeshUpdate(true);
// 		var textInfo = this.textComponent.textInfo;

// 		// 頂点情報の更新
// 		for (int i = 0; i < textInfo.meshInfo.Length; ++i)
// 		{
// 			var meshInfo = textInfo.meshInfo[i];

// 			// 頂点を上に移動
// 			for (int j = 0; j < meshInfo.vertices.Length; ++j)
// 			{
// 				meshInfo.vertices[j] += new Vector3(0, time, 0);
// 			}

// 			// メッシュの頂点更新
// 			textInfo.meshInfo[i].mesh.vertices = meshInfo.vertices;

// 			// 変更を反映
// 			textComponent.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
// 		}

// 		Debug.Log($"メッシュの数 = {textInfo.meshInfo.Length}");
// 	}
// }




using UnityEngine;
using TMPro;

/// <summary>
/// 指定範囲のテキストが壊れるようなアニメーションするコンポ―ネント
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class TextAnim0 : MonoBehaviour
{
	/// <summary>TextMeshPro Textコンポーネント</summary>
	private TMP_Text textComponent = null;
	/// <summary>ループするかどうか</summary>
	[SerializeField]
	private bool isLoop = false;
	/// <summary>グラデーションカラー</summary>
	[SerializeField]
	private Gradient gradientColor;
	/// <summary>アニメーション最大時間</summary>
	[SerializeField]
	private float maxTime = 1f;
	/// <summary>アニメーション時間</summary>
	private float time = 0f;

	/// <summary>再生フラグ</summary>
	private bool isPlaying = false;

	/// <summary>アニメーション文字範囲（C#側）</summary>
	private RangeInt charaIndexRange = new RangeInt(0, 0);
	/// <summary>アニメーション文字範囲（Shader側）</summary>
	private RangeInt primitiveIndexRange = new RangeInt(0, 0);


	/// <summary>
	/// Unity Event Awake
	/// </summary>
	private void Awake()
	{
		this.textComponent = GetComponent<TMP_Text>();
		ResetMaterialAnimation();
	}

	/// <summary>
	/// Unity Event OnDestroy
	/// </summary>
	private void OnDestroy()
	{
		ResetMaterialAnimation();
	}

	/// <summary>
	/// マテリアル（アニメーション値）のリセット
	/// </summary>
	private void ResetMaterialAnimation()
	{
		if (this.textComponent != null)
		{
			var textInfo = this.textComponent.textInfo;
			if (textInfo != null && 0 < textInfo.meshInfo.Length)
			{
				for (int i = 0; i < textInfo.materialCount; ++i)
				{
					if (textInfo.meshInfo[i].material == null) continue;
					textInfo.meshInfo[i].material.SetFloat("_AnimationTime", 0f);
					textInfo.meshInfo[i].material.SetInt("_AnimationStartVertexID", 0);
					textInfo.meshInfo[i].material.SetInt("_AnimationEndVertexID", 0);
				}
			}
		}
	}

	/// <summary>
	/// Unity Event Update
	/// </summary>
	private void Update()
	{
		// ①時間制御
		// if (this.isPlaying || this.isLoop)
		// {
			this.time += Time.deltaTime;

		// 	if (this.isLoop)
		// 	{
				if (this.time >= this.maxTime)
					this.time -= this.maxTime;
			// }
			// else
			// {
			// 	if (this.time >= this.maxTime)
			// 	{
			// 		this.time = this.maxTime;
			// 		this.isPlaying = false;
			// 	}
			// }

			UpdateAnimation(this.time / this.maxTime);
			// Debug.Log("あああ");
		// }
	}

	/// <summary>
	/// アニメーション更新
	/// </summary>
	private void UpdateAnimation(float time)
	{
		// ②ジオメトリ情報を初期化
		this.textComponent.ForceMeshUpdate(true, true);
		var textInfo = this.textComponent.textInfo;

		for (int i = 0; i < textInfo.characterInfo.Length; ++i)
		{
			// ⑥文字情報インデックスの範囲指定
			if (this.charaIndexRange.start <= i && i < this.charaIndexRange.end)
			{
				// ③文字情報・メッシュ情報の取得
				var charaInfo = textInfo.characterInfo[i];
				if (!charaInfo.isVisible)
					continue;

				int materialIndex = charaInfo.materialReferenceIndex;
				int vertexIndex = charaInfo.vertexIndex;
				var meshInfo = textInfo.meshInfo[materialIndex];

				// ④頂点情報の編集
				Vector3 vertex0 = meshInfo.vertices[vertexIndex + 0];
				Vector3 vertex1 = meshInfo.vertices[vertexIndex + 1];
				Vector3 vertex2 = meshInfo.vertices[vertexIndex + 2];
				Vector3 vertex3 = meshInfo.vertices[vertexIndex + 3];

				// 回転
				Vector3 rotationNoise = new Vector3(
					Mathf.PerlinNoise(i * 0.1f, 0.4f) * 2.0f - 1.0f,
					Mathf.PerlinNoise(i * 0.2f, 0.5f) * 2.0f - 1.0f,
					Mathf.PerlinNoise(i * 0.3f, 0.6f) * 2.0f - 1.0f);

				var center = Vector3.Scale(vertex2 - vertex0, Vector3.one * 0.5f) + vertex0;
				var matrix = Matrix4x4.Rotate(Quaternion.Euler(rotationNoise * 360f * time));
				vertex0 = matrix.MultiplyPoint(vertex0 - center) + center;
				vertex1 = matrix.MultiplyPoint(vertex1 - center) + center;
				vertex2 = matrix.MultiplyPoint(vertex2 - center) + center;
				vertex3 = matrix.MultiplyPoint(vertex3 - center) + center;

				// 移動
				Vector3 positionNoise = new Vector3(
					Mathf.PerlinNoise(i * 0.7f, 0.1f) * 2.0f - 1.0f,
					Mathf.PerlinNoise(i * 0.8f, 0.2f) * 2.0f - 1.0f,
					Mathf.PerlinNoise(i * 0.9f, 0.3f) * 2.0f - 1.0f);

				positionNoise = positionNoise * 3f * time;

				vertex0 += positionNoise;
				vertex1 += positionNoise;
				vertex2 += positionNoise;
				vertex3 += positionNoise;

				// 代入
				meshInfo.vertices[vertexIndex + 0] = vertex0;
				meshInfo.vertices[vertexIndex + 1] = vertex1;
				meshInfo.vertices[vertexIndex + 2] = vertex2;
				meshInfo.vertices[vertexIndex + 3] = vertex3;

				// 色
				Color color = this.gradientColor.Evaluate(time);
				meshInfo.colors32[vertexIndex + 0] *= color;
				meshInfo.colors32[vertexIndex + 1] *= color;
				meshInfo.colors32[vertexIndex + 2] *= color;
				meshInfo.colors32[vertexIndex + 3] *= color;
			}

		}

		// ②ジオメトリ情報の更新
		for (int i = 0; i < textInfo.meshInfo.Length; ++i)
		{
			if (textInfo.meshInfo[i].mesh == null) { continue; }

			textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
			textInfo.meshInfo[i].mesh.colors32 = textInfo.meshInfo[i].colors32;
			textComponent.UpdateGeometry(textInfo.meshInfo[i].mesh, i);

			var material = textInfo.meshInfo[i].material;
			material.SetFloat("_AnimationTime", time);
			material.SetInt("_AnimationStartPrimitiveID", this.primitiveIndexRange.start);
			material.SetInt("_AnimationEndPrimitiveID", this.primitiveIndexRange.end);
		}
	}

	// ⑤アニメーション再生開始
	public void OnTouchLink(string linkID, string linkText, int linkTextFirstCharaIndex, int linkIndex)
	{
		if (linkID == "break")
		{
			this.isPlaying = true;
			this.time = 0f;
			this.charaIndexRange.start = linkTextFirstCharaIndex;
			this.charaIndexRange.length = linkText.Length;

			int primitiveStart = linkTextFirstCharaIndex;
			for (int i = linkTextFirstCharaIndex - 1; 0 <= i; --i)
				if (!this.textComponent.textInfo.characterInfo[i].isVisible)
					primitiveStart--;

			int primitiveLength = 0;
			for (int i = this.charaIndexRange.start; i < this.charaIndexRange.end; ++i)
				if (this.textComponent.textInfo.characterInfo[i].isVisible)
					primitiveLength++;

			this.primitiveIndexRange.start = primitiveStart * 2;
			this.primitiveIndexRange.length = primitiveLength * 2;
		}
	}
}
