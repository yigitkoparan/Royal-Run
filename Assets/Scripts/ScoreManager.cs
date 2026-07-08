using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    int score = 0;

    public void scoreUP(int amount)
    {
        score += amount;
        text.text = score.ToString();
    }
}
