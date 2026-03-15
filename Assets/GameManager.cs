using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float tiempo = 0f;
    public static bool juegoTerminado = false;

    void Update()
    {
        if(!juegoTerminado)
        {
            tiempo += Time.deltaTime;
        }
    }

    public static void BonusTiempo(float bonus)
    {
        float tiempoAnterior = tiempo;
        tiempo -= bonus;

        if(tiempo < 0)
        tiempo = 0;

        Debug.Log("Tiempo anterior: " + tiempoAnterior);
        Debug.Log("Bonus de tiempo: -" + bonus);
        Debug.Log("Nuevo tiempo: " + tiempo);
    }

    public static void TerminarJuego()
    {
        juegoTerminado = true;
        Debug.Log("Juego terminado");
        Debug.Log("Tiempo total: " + tiempo + " segundos");
    }

    public static void ReiniciarJuego()
    {
        Debug.Log("Jugador cayó en trampa. Reiniciando juego...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void GanarJuego(int puntaje)
{
    juegoTerminado = true;

    Debug.Log("================================");
    Debug.Log("🎉 ¡GANASTE!");
    Debug.Log("Puntaje final: " + puntaje);
    Debug.Log("Tiempo total: " + tiempo + " segundos");
    Debug.Log("Reiniciando juego...");

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
public static void PenalizacionTiempo(float penalizacion)
{
    float tiempoAnterior = tiempo;

    tiempo += penalizacion;

    Debug.Log("Tiempo anterior: " + tiempoAnterior);
    Debug.Log("Penalización de tiempo: +" + penalizacion);
    Debug.Log("Nuevo tiempo: " + tiempo);
}
}