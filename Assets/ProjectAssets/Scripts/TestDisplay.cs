using UnityEngine;
using UnityEngine.UI;

public class TestDisplay : MonoBehaviour
{
    public ArduinoInputHandler arduinoInputHandler; // Arrastra el objeto que tiene el ArduinoInputHandler aqu�
    public Button sendButton; // Arrastra el bot�n de UI aqu�

    void Start()
    {
        if (sendButton != null)
        {
            sendButton.onClick.AddListener(OnSendButtonClick);
        }
        else
        {
            Debug.LogError("El bot�n de env�o no est� asignado.");
        }
    }

    private void OnSendButtonClick()
    {
        // Llama al m�todo SendNumberToDisplay del ArduinoInputHandler
        int displayNumber = 1; // Cambia esto seg�n sea necesario
        int numberToDisplay = 1234; // Cambia esto seg�n sea necesario

        if (arduinoInputHandler != null)
        {
            arduinoInputHandler.SendNumberToDisplay(displayNumber, numberToDisplay);
        }
        else
        {
            Debug.LogError("ArduinoInputHandler no est� asignado.");
        }
    }
}
