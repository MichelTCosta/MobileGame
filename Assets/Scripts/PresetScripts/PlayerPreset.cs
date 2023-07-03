using UnityEngine;

[CreateAssetMenu (fileName = "Player", menuName = "Player/PlayerPreset")]
public class PlayerPreset : ScriptableObject
{
    public int life;
    public int damage;

    public float attackRange;
    public float attackRate;
    [SerializeField] float baseAttackRange;
    [SerializeField]float baseAttackRate;
    
    

    private void OnEnable() {
        attackRange = baseAttackRange;
        attackRate = baseAttackRate;
    }
}
