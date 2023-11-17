using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Camera camera_;
    public LayerMask enemy;

    int score;
    public Text scoreText;

    void LateUpdate()
    {
        RaycastHit hit;

        Ray ray = camera_.ScreenPointToRay(Input.mousePosition);
        if(Input.GetMouseButton(0))
            if (Physics.Raycast(ray, out hit, 1000, enemy))
            {
                EnemyController monster = hit.transform.GetComponent<EnemyController>();

                if (monster != null)
                {
                    monster.Death();
                    if (monster.health == 0)
                        Invoke(nameof(ScoreCount), 1f);
                }
            }
    }

    void ScoreCount()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
