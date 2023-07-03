using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Bullet", fileName = "Bullet")]
public class BulletPreset : ScriptableObject
{
    public int life;
    public float speed;
    public int damage;
}
