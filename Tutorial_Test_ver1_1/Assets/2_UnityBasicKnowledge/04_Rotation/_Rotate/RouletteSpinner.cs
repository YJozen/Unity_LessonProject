using UnityEngine;

public class RouletteSpinner : MonoBehaviour
{
    public float initialSpeed = 500f;   // 初期の回転速度
    public float deceleration = 50f;    // 減速率
    public float stopThreshold = 0.1f;  // 回転を停止させる閾値
    public int numberOfSections = 8;    // ルーレットのセクションの数
    public string[] sectionNames;       // セクションごとの名前や結果
    
    private float currentSpeed;
    private bool isSpinning = false;

    void Start() {
        // ルーレットの回転速度を初期化
        currentSpeed = initialSpeed;
        
        // セクション名を指定（例として8セクション）
        if (sectionNames == null || sectionNames.Length != numberOfSections) {
            sectionNames = new string[numberOfSections];
            for (int i = 0; i < numberOfSections; i++) {
                sectionNames[i] = "Section " + (i + 1);  // デフォルトのセクション名
            }
        }
    }

    void Update() {
        if (isSpinning) {
            // Z軸周りに時計回りで回転
            transform.Rotate(Vector3.forward, -currentSpeed * Time.deltaTime);

            // 徐々に減速させる
            currentSpeed -= deceleration * Time.deltaTime;

            // 回転が停止閾値を下回ったら停止
            if (currentSpeed <= stopThreshold) {
                currentSpeed = 0f;
                isSpinning = false;
                Debug.Log("Roulette stopped.");

                // 停止位置を判定
                DetermineStopPosition();
            }
        }

        // スペースキーで回転を開始
        if (Input.GetKeyDown(KeyCode.Space) && !isSpinning) {
            StartSpin();
        }
    }

    // 回転を開始するメソッド
    void StartSpin() {
        isSpinning = true;
        currentSpeed = initialSpeed;  // 初期速度で再び回転を開始
        Debug.Log("Roulette started spinning.");
    }

    // 停止位置を判定するメソッド
    void DetermineStopPosition() {
        // Z軸周りの現在の回転角度を取得（ルーレットの回転軸に依存）
        float zRotation = transform.eulerAngles.z;

        // セクションの角度（360度をセクション数で割る）
        float sectionAngle = 360f / numberOfSections;

        // 現在の回転角度からセクションを判定
        int stoppedSection = Mathf.FloorToInt(zRotation / sectionAngle);

        // 判定されたセクションの情報を表示
        Debug.Log("Stopped at: " + sectionNames[stoppedSection]);
    }
}