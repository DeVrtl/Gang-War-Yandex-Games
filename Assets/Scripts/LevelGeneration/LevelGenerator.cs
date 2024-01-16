using GangWar.Game;
using GangWar.Level;
using System.Collections.Generic;
using UnityEngine;

namespace GangWar.LevelGeneration
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private EnemyContainer _firstLevel;
        [SerializeField] private EnemyContainer _secondLevel;
        [SerializeField] private EnemyContainer _thirdLevel;
        [SerializeField] private List<EnemyContainer> _levelContainers = new List<EnemyContainer>();
        [SerializeField] private LevelComplitionCounter _levelComplitionCounter;
        [SerializeField] private GameInitiator _gameInitiator;

        private void Awake()
        {
            GetLevelToGenerate();
        }

        private void GetLevelToGenerate()
        {
            switch (_levelComplitionCounter.CurrentLevel)
            {
                case 1:

                    GenerateLevel(_firstLevel);

                    break;

                case 2:

                    GenerateLevel(_secondLevel);

                    break;

                case 3:

                    GenerateLevel(_thirdLevel);

                    break;

                case >= 4:

                    EnemyContainer container = _levelContainers[UnityEngine.Random.Range(0, _levelContainers.Count)];

                    GenerateLevel(container);

                    break;

                default:

                    GenerateLevel(_firstLevel);

                    break;
            }
        }

        public void GenerateLevel(EnemyContainer container)
        {
            EnemyContainer level = Instantiate(container);

            foreach (var shooter in level.Shooters)
            {
                _gameInitiator.EnemyShoters.Add(shooter);
            }

            foreach (var source in level.Sources)
            {
                _gameInitiator.SoundButton.AudioSources.Add(source);
            }
        }
    }
}