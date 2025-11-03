using UnityEngine;
using TMPro; // Si estás mostrando el tiempo en la UI (Recomendado)

public class GameTimer : MonoBehaviour
{
    [Header("Referencias")]
    // Objeto TextMeshPro para mostrar el tiempo restante al jugador
    public TextMeshProUGUI timerText; 

    private float tiempoRestante;
    private bool partidaActiva = false;

    void Start()
    {
        // 1. Obtener el tiempo de partida del GameManager
        if (GameManager.Instance != null)
        {
            tiempoRestante = GameManager.Instance.tiempoPartidaSegundos;
            partidaActiva = true;
            Debug.Log($"Temporizador iniciado con {tiempoRestante} segundos.");
        }
        else
        {
            // Falla segura si se carga la escena de juego directamente
            tiempoRestante = 300f; // 5 minutos por defecto
            partidaActiva = true;
            Debug.LogError("GameManager no encontrado. Usando 5 minutos por defecto.");
        }

        // Asegurarse de actualizar la UI al inicio
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (partidaActiva)
        {
            if (tiempoRestante > 0)
            {
                // Disminuir el tiempo
                tiempoRestante -= Time.deltaTime;
                
                // Actualizar la UI del temporizador
                UpdateTimerDisplay();
            }
            else
            {
                // El tiempo se agotó
                tiempoRestante = 0;
                partidaActiva = false;
                FinalizarPartida();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            // Convertir segundos a formato Minutos:Segundos
            int minutos = Mathf.FloorToInt(tiempoRestante / 60);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60);
            
            // Mostrar el tiempo formateado (ej. 05:30)
            timerText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }

    void FinalizarPartida()
    {
        Debug.Log("--- ¡TIEMPO AGOTADO! Partida Finalizada. ---");
        
        // Aquí puedes agregar la lógica de fin de juego, como:
        // 1. Mostrar una pantalla de "Fin de Partida".
        // 2. Detener la aparición de enemigos y congelar el movimiento del jugador.
        // 3. Cargar la escena del menú principal.
        
        // Ejemplo simple:
        // SceneManager.LoadScene("MenuPrincipal");
    }
}