using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardFiller : MonoBehaviour
{
    private const int ViewRedundantValue = 1;
    private const string AnonymousEn = "Anonymous";
    private const string AnonymousRu = "Аноним";
    private const string AnonymousTr = "Anonim";
    private const string EnglishCode = "en";
    private const string RussianCode = "ru";
    private const string TurkishCode = "tr";
    private const string LeaderboardName = "IDLeaderboard";

    [SerializeField] private LevelComplitionCounter _score;
    [SerializeField] private LeaderboardView _view;

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new List<LeaderboardPlayer>();

    private void Start()
    {
        SetPlayer(_score.CurrentLevel - ViewRedundantValue);
        Fill();
    }

    private void SetPlayer(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
        {
            return;
        }

        Agava.YandexGames.Leaderboard.GetPlayerEntry(LeaderboardName, _ =>
        {
            Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, score);
        });
    }

    private void Fill()
    {
        _leaderboardPlayers.Clear();

        if (PlayerAccount.IsAuthorized == false)
        {
            return;
        }

        Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, resualt =>
        {
            for (int i = 0; i < resualt.entries.Length; i++)
            {
                int rank = resualt.entries[i].rank;
                int score = resualt.entries[i].score;
                string name = resualt.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                {
                    string locale = YandexGamesSdk.Environment.i18n.lang;

                    switch (locale)
                    {
                        case EnglishCode:
                            name = AnonymousEn;
                            break;

                        case RussianCode:
                            name = AnonymousRu;
                            break;

                        case TurkishCode:
                            name = AnonymousTr;
                            break;
                    }
                }

                _leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));
            }

            _view.ConstructLeaderboard(_leaderboardPlayers);
        });
    }
}
