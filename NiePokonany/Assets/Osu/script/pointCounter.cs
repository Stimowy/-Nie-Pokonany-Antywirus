using TMPro;
using UnityEngine;

public class pointCounter : MonoBehaviour
{
    [SerializeField] private int point;
    [SerializeField] private int score = 1;

    [SerializeField] private int pointGood;
    [SerializeField] private int pointBetter;
    [SerializeField] private int pointMinus;

    [SerializeField] private TextMeshPro textPoint;
    [SerializeField] private TextMeshPro textScore;

    private void FixedUpdate()
    {
        textPoint.text = point.ToString();
        textScore.text = score.ToString();
    }

    public void AddPoints()
    {
        point += pointGood * score;
    }

    public void AddPointsPlus()
    {
        point += pointBetter * score;
    }

    public void SubtractPoints()
    {
        point -= pointMinus;
    }

    public void AddScore()
    {
        if(score < 10)
        {
            score++;
        }
    }

    public void DiviseScore()
    {
        if(score > 1)
        {
            score /= 2;
        }
        else
        {
            SubtractPoints();
        }
    }

    public int Points()
    {
        return point;
    }
}