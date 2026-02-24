using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStart : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("TutrialScene");
            Debug.Log("Game Start");
        }
    }
}
