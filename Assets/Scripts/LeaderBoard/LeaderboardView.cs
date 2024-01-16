using System.Collections.Generic;
using UnityEngine;

namespace GangWar.LeaderBoard
{
    public class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private LeaderboardElement _leaderBoardElementPrefab;

        private List<LeaderboardElement> _spawnedElements = new List<LeaderboardElement>();

        public void ConstructLeaderboard(List<LeaderboardPlayer> leaderboardPlayers)
        {
            ClearLeaderboard();

            foreach (LeaderboardPlayer player in leaderboardPlayers)
            {
                LeaderboardElement leaderBoardElementInstance = Instantiate(_leaderBoardElementPrefab, _container);
                leaderBoardElementInstance.Initialize(player.Name, player.Score, player.Rank);

                _spawnedElements.Add(leaderBoardElementInstance);
            }
        }

        private void ClearLeaderboard()
        {
            foreach (var element in _spawnedElements)
            {
                Destroy(element);
            }

            _spawnedElements = new List<LeaderboardElement>();
        }
    }

}