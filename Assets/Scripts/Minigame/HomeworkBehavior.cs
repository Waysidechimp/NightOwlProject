using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeworkBehavior : MonoBehaviour
{
    [SerializeField] List<TMPro.TMP_InputField> playerAnswers;
    [SerializeField] List<string> actualAnswers;

    MinigameBehavior miniGameBehavior;

    int grade;
    // Start is called before the first frame update
    void Start()
    {
        miniGameBehavior = FindObjectOfType<MinigameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SubmitQuestions()
    {
        float currentGrade = 0;

        int actualIndex = 0;
        foreach (var question in playerAnswers)
        {
            if (question.text == actualAnswers[actualIndex])
            {
                currentGrade += 7.14f;
            }
            actualIndex++;
        }
        Debug.Log(currentGrade);
        grade = (int)currentGrade;
        miniGameBehavior.UpdateGrade(grade);
        miniGameBehavior.UpdateHomeworkGameState(false);
        miniGameBehavior.UpdateGradeState(true);
    }

    public void ExitQuestions()
    {
        miniGameBehavior.UpdateHomeworkGameState(false);
    }
}