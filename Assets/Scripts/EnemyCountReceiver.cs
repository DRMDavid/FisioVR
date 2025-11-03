using UnityEngine;
using System.Collections.Generic;

public class EnemyCountReceiver : MonoBehaviour
{
    // Campos públicos para arrastrar los Prefabs en el Inspector.
    [Header("Referencias de Prefabs")]
    public GameObject EnemigoHada;
    public GameObject EnemigoGrieta;
    public GameObject EnemigoEspíritu;

    // Puntos de aparición mantenidos para la futura implementación del spawn.
    [Header("Puntos de Aparición (Para futura implementación)")]
    public List<Transform> spawnPoints; 

    void Start()
    {
        // 1. Verificar y obtener las cantidades del GameManager
        if (GameManager.Instance != null)
        {
            int count1 = GameManager.Instance.countEnemigoHadas;
            int count2 = GameManager.Instance.countEnemigoGrietas;
            int count3 = GameManager.Instance.countEnemigoEspíritus;
            
            // 2. Reportar las cantidades seleccionadas en la consola (Debug)
            Debug.Log("--- CONFIGURACIÓN DE ENEMIGOS RECIBIDA ---");
            Debug.Log($"Enemigo Hadas: {count1} unidades.");
            Debug.Log($"Enemigo Grietas: {count2} unidades.");
            Debug.Log($"Enemigo Espíritus: {count3} unidades.");
            Debug.Log("------------------------------------------");

            
        }
        else
        {
            Debug.LogError("GameManager no cargado. No se pudieron obtener las cantidades de enemigos.");
        }
    }
}