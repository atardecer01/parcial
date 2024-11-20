using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;  // Panel de Inicio
    public GameObject pausePanel;  // Panel de Pausa
    public GameObject gameOverPanel;  // Panel de Fin de Juego
    public GameObject player;  // El jugador
    public GameObject obstacles;  // Obstáculos

    private bool isGamePaused = false;
    private PlayerScript playerScript; 


    private void Awake()
    {
        // Obtener la referencia al script PlayerScript del GameObject del jugador
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Función para iniciar el juego (debe llamarse desde el botón de "Jugar")
    public void StartGame()
    {
        startPanel.SetActive(false);  // Ocultar el panel de inicio
        gameOverPanel.SetActive(false);  // Asegurarse de que el panel de fin de juego esté oculto
        Time.timeScale = 1;  // Asegurarse de que el juego se ejecute a velocidad normal
        // Aquí podrías inicializar tu juego si es necesario
        startPanel.SetActive(false);  // Ocultar el panel de inicio
        gameOverPanel.SetActive(false);  // Ocultar el panel de fin de juego
        player.SetActive(true);  // Activar al jugador
        obstacles.SetActive(true);  // Activar los obstáculos
        Time.timeScale = 1;  // Asegurarse de que el juego se ejecute a velocidad normal
    }

    // Función para pausar el juego
    public void PauseGame()
    {
        pausePanel.SetActive(true);  // Mostrar el panel de pausa
        Time.timeScale = 0;  // Detener el juego
    }

    // Función para reanudar el juego
    public void ResumeGame()
    {
        pausePanel.SetActive(false);  // Ocultar el panel de pausa
        Time.timeScale = 1;  // Reanudar el juego
    }

     // Función pública para terminar el juego
    public void GameOver()
    {
        gameOverPanel.SetActive(true);  // Mostrar el panel de fin de juego
        player.SetActive(false);  // Desactivar al jugador
        obstacles.SetActive(false);  // Desactivar los obstáculos
        Time.timeScale = 0;  // Detener el juego
    }

    // Función para reiniciar el juego (puedes recargar la escena o reiniciar los elementos)
    public void RestartGame()
    {
        gameOverPanel.SetActive(false);  // Ocultar el panel de fin de juego
        Time.timeScale = 1;  // Asegurarse de que el tiempo esté normal
        player.transform.position = new Vector3(-6, -3, 0); 
        // Aquí podrías recargar la escena, reiniciar variables, etc.
        playerScript.SetIsAlive(true);
    }

    // Función para salir del juego (esto solo funciona en una build)
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // Detener la ejecución en el Editor
        #else
        Application.Quit();  // Salir del juego en una build
        #endif
    }
}
