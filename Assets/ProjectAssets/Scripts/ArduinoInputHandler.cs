using System.IO.Ports;
using UnityEngine;

public class ArduinoInputHandler : MonoBehaviour
{
    private SerialPort arduinoPort;

    void Start()
    {
        // Intentar conectar automáticamente al puerto correcto
        foreach (string port in SerialPort.GetPortNames())
        {
            try
            {
                arduinoPort = new SerialPort("COM3", 9600);
                arduinoPort.Open();
                arduinoPort.ReadTimeout = 100;

                Debug.Log("Conectado a Arduino en el puerto: " + port);
                break;
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("No se pudo conectar a " + port + ": " + e.Message);
            }
        }

        if (arduinoPort == null || !arduinoPort.IsOpen)
        {
            Debug.LogError("No se pudo conectar al Arduino en ningún puerto.");
        }
    }

    void Update()
    {
        // Leer datos desde Arduino
        if (arduinoPort != null && arduinoPort.IsOpen)
        {
            try
            {
                string message = arduinoPort.ReadLine();
                Debug.Log("Mensaje desde Arduino: " + message);
                HandleButtonInput(message);
            }
            catch (System.TimeoutException) 
            { 

            }
            catch (System.Exception e)
            {
                Debug.LogError("Error al leer desde Arduino: " + e.Message);
            }
        }
    }

    void HandleButtonInput(string message)
    {
        char prefix = message[0]; // 'D' o 'A'
        int buttonIndex = int.Parse(message.Substring(1));

        switch (prefix)
        {
            case 'D':
                switch (buttonIndex)
                {
                    case 6:
                        Debug.Log("Acción para botón digital" + buttonIndex);
                        break;
                    case 7:
                        Debug.Log("Acción para botón digital" + buttonIndex);
                        break;
                    case 8:
                        Debug.Log("Acción para botón digital" + buttonIndex);
                        break;
                    case 9:
                        Debug.Log("Acción para botón digital" + buttonIndex);
                        break;
                    case 10:
                        Debug.Log("Acción para botón digital" + buttonIndex);
                        break;
                    case 11:
                        Debug.Log("Acción para botón digital" + buttonIndex);
                        break;
                    case 12:
                        Debug.Log("Acción para botón digital" + buttonIndex);
                        break;
                    case 13:
                        Debug.Log("Acción para botón digital" + buttonIndex);
                        break;
                    default:
                        Debug.LogWarning("Botón digital no reconocido: " + buttonIndex);
                        break;
                }
                break;

            case 'A':
                switch (buttonIndex)
                {
                    case 0:
                        Debug.Log("Acción para botón analógico" + buttonIndex);
                        break;
                    case 1:
                        Debug.Log("Acción para botón analógico" + buttonIndex);
                        break;
                    case 2:
                        Debug.Log("Acción para botón analógico" + buttonIndex);
                        break;
                    case 3:
                        Debug.Log("Acción para botón analógico" + buttonIndex);
                        break;
                    default:
                        Debug.LogWarning("Botón analógico no reconocido: " + buttonIndex);
                        break;
                }
                break;

            default:
                Debug.LogWarning("Prefijo no reconocido: " + prefix);
                break;
        }
    }

    public void SendNumberToDisplay(int displayNumber, int number)
    {
        if (number < 0 || number > 9999)
        {
            Debug.LogError("El número debe estar entre 0 y 9999.");
            return;
        }

        string message = displayNumber + ":" + number;
        if (arduinoPort != null && arduinoPort.IsOpen)
        {
            arduinoPort.WriteLine(message);
            Debug.Log("Enviado a Arduino: " + message);
        }
        else
        {
            Debug.LogError("No hay conexión con el Arduino para enviar el número.");
        }
    }

    private void OnApplicationQuit()
    {
        // Cerrar el puerto serial cuando se cierre la aplicación
        if (arduinoPort != null && arduinoPort.IsOpen)
        {
            arduinoPort.Close();
            Debug.Log("Puerto cerrado.");
        }
    }
}