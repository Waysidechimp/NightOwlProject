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
        foreach (var question in playerAnswers)
        {
            foreach (string answer in actualAnswers)
            {
                if (question.text == answer)
                {
                    currentGrade += 7.14f;
                }
            }
        }
        grade = (int)currentGrade;
        miniGameBehavior.UpdateGrade(grade);
    }

    public void ExitQuestions()
    {
        miniGameBehavior.UpdateHomeworkGameState(false);
    }
}