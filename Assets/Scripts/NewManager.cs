using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Bu fonksiyon Start butonuna atanacak
    public void StartGame()
    {

         // 5 saniye gecikmeli sahne yükleme
        // Ýstediðin sahnenin adýný veya indexini yazabilirsin
        SceneManager.LoadScene("BedRoom"); // veya SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit(); // Oyun çýkýþý
        Debug.Log("Oyun kapatýldý"); // Editor'de çalýþmaz ama build'de çalýþýr
    }
}
