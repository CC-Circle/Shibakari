using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class SerialHandler : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;

    // 1人対戦用のポート（基本はこっち）
    private string portName = "/dev/cu.k22065_M5stick";
    // 2人対戦用のポート（2人対戦実装の時はこっち）
    // private string portName = "/dev/cu.m5stack_shibakari_2";
    public int baudRate = 115200;

    private SerialPort serialPort;

    private void Awake()
    {
        Open();
    }

    private void OnDestroy()
    {
        Close();
    }

    private void Open()
    {
        try
        {
            serialPort = new SerialPort(portName, baudRate);
            serialPort.Open();
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to open serial port: " + e.Message);
            return;
        }

        if (serialPort.IsOpen)
        {
            Debug.Log("Serial port opened successfully.");
        }
        else
        {
            Debug.LogError("Failed to open serial port.");
        }

        // Start reading data from the serial port in a separate thread
        Thread thread = new Thread(Read);
        thread.Start();
    }

    private void Close()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
            serialPort.Dispose();
            Debug.Log("Serial port closed.");
        }
    }

    private void Read()
    {
        while (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                string message = serialPort.ReadLine();
                OnDataReceived?.Invoke(message);
                Debug.Log(message);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error reading from serial port: " + e.Message);
            }
        }
    }

    public void Write(string message)
    {
        try
        {
            serialPort.Write(message);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error writing to serial port: " + e.Message);
        }
    }
}
