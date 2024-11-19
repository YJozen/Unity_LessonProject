using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements; // UIElements���g���̂�using����

// EditorWindow ���p�������N���X���쐬
public class Practice : EditorWindow
{
    // ���j���[�o�[��"Practice"�Ƃ������ڂƁA���̒���"Open"�Ƃ������ڂ��V���ɍ���A
    // ����"Open"���N���b�N�����ShowWindow()�����s�����B
    [MenuItem("Practice/Open")]
    public static void ShowWindow()
    {
        // EditorWindow���쐬
        // �^�����ɂ͂��̃N���X������
        GetWindow<Practice>("Title"); // �^�C�g�����w��
    }

    // �L���ɂȂ������Ɏ��s�����
    private void OnEnable()
    {
        // ���x����VisualElement
        var label = new Label("hogehoge");

        // EditorWindow��root�̎q�Ƃ���label��ǉ�
        rootVisualElement.Add(label);




        // UXML�t�@�C����ǂݍ���
        var visualTree = Resources.Load<VisualTreeAsset>("Practice");

        // UXML�Œ�`����VisualTree�𐶐����A����root�Ƃ���rootVisualElement��ݒ�
        visualTree.CloneTree(rootVisualElement);


        // USS�t�@�C����ǂݍ���
        var styleSheet = Resources.Load<StyleSheet>("PracticeStyle");
        // USS�t�@�C����VisualTree�ɐݒ�
        rootVisualElement.styleSheets.Add(styleSheet);



        // �^�Ɩ��O���w�肵��Button���擾
        var button = rootVisualElement.Q<Button>("OKButton");

        if (button != null)
        {
            // Button�����������̏�����o�^
            button.clickable.clicked += () => Debug.Log("OK");
        }
    }
}
