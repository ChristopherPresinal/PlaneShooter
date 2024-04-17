using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo", menuName = "Ammo/New Ammo")]
public abstract class Ammo : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite sprite;

    public int damadge;
    public int speed;

    public Vector2 direction = new Vector2(1, 0);

    public Vector2 velocity;

    public abstract void MoveSpeed();

}
