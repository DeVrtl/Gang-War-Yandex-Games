using System.Collections.Generic;
using GangWar.BattleSystem.Shooters;
using UnityEngine;

namespace GangWar.LevelGeneration
{
    public class EnemyContainer : MonoBehaviour
    {
        [SerializeField] private List<Shooter> _shooters = new List<Shooter>();
        [SerializeField] private List<AudioSource> _sources = new List<AudioSource>();

        public List<Shooter> Shooters => _shooters;

        public List<AudioSource> Sources => _sources;
    }
}