using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemySO enemyData;
    
    public string EnemyName => enemyData.EnemyName;
    public int HP => enemyData.HP;
    public int Damage => enemyData.Damage;
    public float Speed => enemyData.Speed;
    public Sprite EnemySprite => enemyData.EnemySprite;
    public Animator animator => enemyData.animator;

    public void OnValidate()
    {
        if(!enemyData) return;
        GetComponent<SpriteRenderer>().sprite = EnemySprite;
    }
}
