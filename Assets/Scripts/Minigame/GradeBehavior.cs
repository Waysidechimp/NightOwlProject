using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GradeBehavior : MonoBehaviour
{
    MinigameBehavior minigameBehavior;

    [SerializeField] TMPro.TextMeshProUGUI gradeTMP;

    int playerGrade = 0;
    // Start is called before the first frame update
    void Start()
    {
        minigameBehavior = FindObjectOfType<MinigameBehavior>();
        playerGrade = minigameBehavior.GetGrade();
        SetGradeText(playerGrade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetGradeText(int grade)
    {
        if(grade <= 60)
        {
            gradeTMP.text = "F";
        }
        else if(grade > 60 && grade < 70)
        {
            gradeTMP.text = "D";
        }
        else if (grade >= 70 && grade < 80)
        {
            gradeTMP.text = "C";
        }
        else if (grade >= 80 && grade < 90)
        {
            gradeTMP.text = "B";
        }
        else if (grade >= 90)
        {
            gradeTMP.text = "A";
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
