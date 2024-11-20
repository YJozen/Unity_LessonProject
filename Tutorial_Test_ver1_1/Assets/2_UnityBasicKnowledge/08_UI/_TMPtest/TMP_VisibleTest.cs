using UnityEngine;
using TMPro;

// [ExecuteInEditMode]
[RequireComponent(typeof(TextMeshPro))]
public class TMP_VisibleTest : MonoBehaviour
{
    public int maxVisibleCharacters;
	private TextMeshPro text;
    TextMeshProUGUI textUGUI;

	private void Update()
	{
		if (this.text == null)
			this.text = GetComponent<TextMeshPro>();

		this.text.maxVisibleCharacters = this.maxVisibleCharacters;
	}
}
