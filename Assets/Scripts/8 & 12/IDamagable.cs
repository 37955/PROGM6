using UnityEngine;

public interface IDamagable
{
    int Health { get; }
    void TakeDamage();
}
