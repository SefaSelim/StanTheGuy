using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Bu fonksiyon Start butonuna atanacak
    public void StartGame()
    {

         // 5 saniye gecikmeli sahne y�kleme
        // �stedi�in sahnenin ad�n� veya indexini yazabilirsin
        SceneManager.LoadScene("BedRoom"); // veya SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit(); // Oyun ��k���
        Debug.Log("Oyun kapat�ld�"); // Editor'de �al��maz ama build'de �al���r
    }
}
