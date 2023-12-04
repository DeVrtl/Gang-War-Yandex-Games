using TMPro;
using UnityEngine;

public class LeaderboardElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _rank;

    public void Initialized(string name, int score, int rank)
    {
        _name.text = name;
        _score.text = score.ToString();
        _rank.text = rank.ToString();
    }
}
