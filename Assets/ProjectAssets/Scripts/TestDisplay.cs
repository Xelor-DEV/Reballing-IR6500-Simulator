using UnityEngine;
using UnityEngine.UI;

public class TestDisplay : MonoBehaviour
{
    public ArduinoInputHandler arduinoInputHandler; // Arrastra el objeto que tiene el ArduinoInputHandler aquí
    public Button sendButton; // Arrastra el botón de UI aquí

    void Start()
    {
        if (sendButton != null)
        {
            sendButton.onClick.AddListener(OnSendButtonClick);
        }
        else
        {
            Debug.LogError("El botón de envío no está asignado.");
        }
    }

    private void OnSendButtonClick()
    {
        // Llama al método SendNumberToDisplay del ArduinoInputHandler
        int displayNumber = 1; // Cambia esto según sea necesario
        int numberToDisplay = 1234; // Cambia esto según sea necesario

        if (arduinoInputHandler != null)
        {
            arduinoInputHandler.SendNumberToDisplay(displayNumber, numberToDisplay);
        }
        else
        {
            Debug.LogError("ArduinoInputHandler no está asignado.");
        }
    }
}
