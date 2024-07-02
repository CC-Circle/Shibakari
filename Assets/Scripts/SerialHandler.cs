using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class SerialHandler : MonoBehaviour
{
    // デリゲート型を宣言し、シリアルデータ受信イベントを定義します
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;

    // 1人対戦用のシリアルポート名（基本はこちらを使用します）
    private string portName = "/dev/cu.m5stack_shibakari_1";
    // 2人対戦用のシリアルポート名（2人対戦を実装する場合はこちらを使用します）
    // private string portName = "/dev/cu.m5stack_shibakari_2";
    public int baudRate = 115200; // ボーレート（通信速度）

    private SerialPort serialPort; // シリアルポートのインスタンス


     // 無効化したいオブジェクトの参照を取得
    public GameObject M5Stack;

    //M5Stackgaつながっているかのフラグ
    public bool flag;

    void Update()
    {
        // 対象のオブジェクトにアタッチされているスクリプトを取得
        CutMove CutMove = M5Stack.GetComponent<CutMove>();

        if(!flag)
        {
            CutMove.enabled = false;
        }

        if(flag)
        {
            CutMove.enabled = true;
        }
    }


    // MonoBehaviourのAwakeメソッドはオブジェクトの初期化時に呼ばれます
    private void Awake()
    {
        Open(); // シリアルポートを開く
    }

    // MonoBehaviourのOnDestroyメソッドはオブジェクトが破棄されるときに呼ばれます
    private void OnDestroy()
    {
        Close(); // シリアルポートを閉じる
    }

    // シリアルポートを開くメソッド
    private void Open()
    {
        try
        {
            serialPort = new SerialPort(portName, baudRate); // シリアルポートを初期化
            serialPort.Open(); // シリアルポートを開く
            serialPort.DiscardInBuffer(); // 受信バッファをクリア
            serialPort.DiscardOutBuffer(); // 送信バッファをクリア
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to open serial port: " + e.Message); // エラーメッセージを表示
            return;
        }

        if (serialPort.IsOpen)
        {
            Debug.Log("Serial port opened successfully."); // 成功メッセージを表示
        }
        else
        {
            Debug.LogError("Failed to open serial port."); // 失敗メッセージを表示
        }

        // シリアルポートからのデータ読み取りを別のスレッドで開始
        Thread thread = new Thread(Read);
        thread.Start();
    }

    // シリアルポートを閉じるメソッド
    private void Close()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close(); // シリアルポートを閉じる
            serialPort.Dispose(); // シリアルポートを解放
            Debug.Log("Serial port closed."); // 閉じたことを確認
        }
    }

    // シリアルポートからデータを読み取るメソッド
    private void Read()
    {
        while (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                string message = serialPort.ReadLine(); // データを一行読み取る
                OnDataReceived?.Invoke(message); // データ受信イベントを発火
                flag = true;
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error reading from serial port: " + e.Message); // エラーメッセージを表示
                //Debug.Log("マウス操作に切り替えました");
                flag = false;   
            }
        }
    }

    // シリアルポートにデータを書き込むメソッド
    public void Write(string message)
    {
        try
        {
            serialPort.Write(message); // メッセージを書き込む 
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error writing to serial port: " + e.Message); // エラーメッセージを表示
        }
    }
}
