using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "Enemy/Status", order = 1)]
public class EnemyStatus : ScriptableObject
{
    public float health;
    public bool isDamaged;
    public bool isDead;
    public bool isAttacking;
    public bool isSpecialAttacking;
    // 他のステータス情報
}