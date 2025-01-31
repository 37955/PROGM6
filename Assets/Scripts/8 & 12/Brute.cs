using UnityEngine;

public class Brute : Unit, IMovable, IDamagable
{
    new void Start()
    {
        base.Start();

        health = 10;
        speed = 2f;
        range = 80f;
    }

    void Update()
    {
        if (health > 0)
        {
            Move();
        }
    }
}