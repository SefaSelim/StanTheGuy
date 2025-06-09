using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class LoadbarDecreaser : MonoBehaviour
{
    Image loadbarImage;

    [SerializeField] GameObject ButtonIcon;

    public List<GameObject> Switchs;

    ButtonScript buttonScript;
    float timer = 0f;
    private void Start()
    {
        loadbarImage = GetComponent<Image>();
        buttonScript = ButtonIcon.GetComponent<ButtonScript>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.20f)
        {
            loadbarImage.fillAmount -= Random.Range(0f,0.06f);
            timer = 0f;

            if (loadbarImage.fillAmount <= 0f)
            {
                LoadbarComplete();        
            }
        }
    }

    public void LoadbarComplete()
    {
        foreach (GameObject switchObj in Switchs)
        {
            if (switchObj.activeSelf)
            {
                switchObj.SetActive(false);
            }
            else
            {
                switchObj.SetActive(true);
            }
        }
        loadbarImage.fillAmount = 1f;
        buttonScript.OnMouseDown();
    }

}
