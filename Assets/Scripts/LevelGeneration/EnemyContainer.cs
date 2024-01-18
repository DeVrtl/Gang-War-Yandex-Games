using System.Collections.Generic;
using UnityEngine;
using GangWar.BattleSystem.Shooters;

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