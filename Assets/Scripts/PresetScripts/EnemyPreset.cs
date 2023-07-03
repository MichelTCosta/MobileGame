using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu (fileName = "Enemy", menuName = "EnemyPreset")]
public class EnemyPreset : ScriptableObject
{
    public new string name;
    public int life;
    public int speed;
    public int damage;


}
