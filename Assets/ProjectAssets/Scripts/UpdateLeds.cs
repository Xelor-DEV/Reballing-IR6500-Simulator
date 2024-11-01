using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateLeds : MonoBehaviour
{
    public GameObject led1;
    public GameObject led2;
    public Text textDisplay; // Referencia al Text UI para mostrar el número de tecla

    void Update()
    {
        // Detectar la tecla presionada y usar un switch para actualizar la interfaz
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleImants();
            UpdateTextDisplay("1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UpdateTextDisplay("2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UpdateTextDisplay("3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UpdateTextDisplay("4");
        }
    }

    public void ToggleImants()
    {
        // Cambiamos el estado de los dos objetos
        bool isImant1Active = led1.activeSelf;

        led1.SetActive(!isImant1Active); // Cambia el estado del primer imán
        led2.SetActive(isImant1Active);  // El segundo imán toma el estado opuesto
    }

    void UpdateTextDisplay(string keyPressed)
    {
        // Actualiza el texto con la tecla presionada
        textDisplay.text = keyPressed;
    }
}