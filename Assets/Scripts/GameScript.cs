using System;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public AudioDetectie detectie;
    public TextMeshProUGUI score;
    public GameObject gameOverPaneel;
    public TextMeshProUGUI eindScore;

    public GameObject bal;
    private Vector3 startPositie = new Vector3(-0.01f, -0.4127f, 0);

    bool startGame = false;
    bool blazen = false;
    float tijdNietBlazen = 0f;
    bool gameOver = false;

    void Update()
    {
        if (startGame && !gameOver)
        {
            float luidheid = detectie.LuidheidVanMicrofoon();
            Debug.Log("Luidheid: " + luidheid);
            if (luidheid > 0.1f)
            {
                tijdNietBlazen = 0f;
                blazen = true;

                float huidigeY = bal.transform.position.y;
                huidigeY += 0.01f;
                bal.transform.position = new Vector3(bal.transform.position.x, huidigeY, bal.transform.position.z);

                score.text = "Score: " + CalculateScore(huidigeY).ToString();
                if(huidigeY >= 3.55f)
                {
                    gameOver = true;
                }
            } else if (blazen && tijdNietBlazen < 0.5f)
            {
                tijdNietBlazen += Time.deltaTime;
            }
            else if (tijdNietBlazen >= 0.2f)
            {
                gameOver = true;
            }
        } else if (gameOver)
        {
            eindScore.text = CalculateScore(bal.transform.position.y).ToString();
            gameOverPaneel.SetActive(true);
        }
    }

    private int CalculateScore(float positie)
    {
        float startY = -0.4127f;
        float maxY = 3.55f;
        int score = Convert.ToInt32((positie - startY) / (maxY - startY) * 10000);
        if (score > 10000)
        {
            return 10000;
        }
        return score;
    }


    public GameObject infoPaneel;

    public void InfoKnop()
    {
        infoPaneel.SetActive(true);
        startGame = false;
        Debug.Log("InfoKnop clicked");
    }

    public void StartKnop()
    {
        infoPaneel.SetActive(false);
        Debug.Log("StartKnop clicked");

        bal.transform.position = startPositie;
        gameOver = false;
        startGame = true;
        blazen = false;
        tijdNietBlazen = 0f;
    }

    public void OpnieuwKnop()
    {
        gameOverPaneel.SetActive(false);
        StartKnop();
    }
}