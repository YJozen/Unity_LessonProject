using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements; // UIElementsを使うのでusingする

// EditorWindow を継承したクラスを作成
public class Practice : EditorWindow
{
    // メニューバーに"Practice"という項目と、その中に"Open"という項目が新たに作られ、
    // その"Open"をクリックするとShowWindow()が実行される。
    [MenuItem("Practice/Open")]
    public static void ShowWindow()
    {
        // EditorWindowを作成
        // 型引数にはこのクラスを入れる
        GetWindow<Practice>("Title"); // タイトルを指定
    }

    // 有効になった時に実行される
    private void OnEnable()
    {
        // ラベルのVisualElement
        var label = new Label("hogehoge");

        // EditorWindowのrootの子としてlabelを追加
        rootVisualElement.Add(label);




        // UXMLファイルを読み込む
        var visualTree = Resources.Load<VisualTreeAsset>("Practice");

        // UXMLで定義したVisualTreeを生成し、そのrootとしてrootVisualElementを設定
        visualTree.CloneTree(rootVisualElement);


        // USSファイルを読み込む
        var styleSheet = Resources.Load<StyleSheet>("PracticeStyle");
        // USSファイルをVisualTreeに設定
        rootVisualElement.styleSheets.Add(styleSheet);



        // 型と名前を指定してButtonを取得
        var button = rootVisualElement.Q<Button>("OKButton");

        if (button != null)
        {
            // Buttonを押した時の処理を登録
            button.clickable.clicked += () => Debug.Log("OK");
        }
    }
}
