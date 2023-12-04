using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
    [field: SerializeField] public List<Shooter> Shooters = new List<Shooter>();
    [field: SerializeField] public List<AudioSource> Sources = new List<AudioSource>();
}
