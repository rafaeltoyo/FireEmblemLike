using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DestroyableObjectStatus { FULL, ALIVE, DEAD }

public abstract class DestroyableObject : MonoBehaviour
{
    private int currentHP;

    private int maxHP;

    private DestroyableObjectStatus status;

    public int CurrentHP { get => currentHP; }

    public int MaxHP { get => maxHP; }

    protected void StartHP(int maxHP)
    {
        this.currentHP = this.maxHP = maxHP;
        this.status = DestroyableObjectStatus.FULL;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            this.currentHP = Mathf.Max(this.currentHP - damage, 1);

            if (this.currentHP <= 0)
            {
                this.status = DestroyableObjectStatus.DEAD;
                this.Die();
            }
            else if (this.currentHP < this.maxHP)
            {
                this.status = DestroyableObjectStatus.ALIVE;
            }
        }
        else
        {
            Debug.Log("Invalid damage value!");
        }
    }

    public bool IsDead() { return this.status == DestroyableObjectStatus.DEAD; }

    public bool IsAlive() { return !this.IsDead(); }

    public abstract void Die();
}
