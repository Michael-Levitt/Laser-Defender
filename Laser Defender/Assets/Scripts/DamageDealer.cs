using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [field: SerializeField] public int Damage { get; private set; }
    
    public void Hit()
    {
        Destroy(gameObject);
    }
}
