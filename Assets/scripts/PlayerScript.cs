using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerScript : MonoBehaviour
{   
    
    public float JumpForce;
    public GameObject gameOverPanel;  // Panel de Fin de Juego
    float score;
    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;

    Rigidbody2D RB;

    public TextMeshProUGUI ScoreTxt;

    // Variables para la ralentización temporal
    public float slowDownFactor = 0.5f;  // Cuánto se ralentiza el juego
    public float slowDownDuration = 2f;  // Duración de la ralentización

    public void SetIsAlive(bool value)
    {
        isAlive = value;
    }

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }
        if(isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = "Score : "+score.ToString("");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if(!isGrounded)
            {
                isGrounded = true;
            }
        }
        if(collision.gameObject.CompareTag("spike"))
        {// Llamar a GameOver del UIManager
            
            isAlive = false;
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            Destroy(collision.gameObject);
            score = 0;

        }
        if(collision.gameObject.CompareTag("diamante"))
        {
             Destroy(collision.gameObject);

             // Ralentizar el juego
            Time.timeScale = slowDownFactor;

            // Restaurar la velocidad normal después de un tiempo
            Invoke("RestoreTimeScale", slowDownDuration);
        }
    }

    private void RestoreTimeScale()
    {
        Time.timeScale = 1f;  // Restaurar la velocidad normal
    }

}
