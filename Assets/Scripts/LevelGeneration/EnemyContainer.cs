using GangWar.BattleSystem.Shooters;
using System.Collections.Generic;
using UnityEngine;

namespace GangWar.LevelGeneration
{
    public class EnemyContainer : MonoBehaviour
    {
        [field: SerializeField] public List<Shooter> Shooters = new List<Shooter>();
        [field: SerializeField] public List<AudioSource> Sources = new List<AudioSource>();
    }
}