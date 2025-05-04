using System;
using System.IO;
using UnityEngine;

public enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error,
    Critical
}

public class Logger : MonoBehaviour
{
    private static Logger instance;
    public static Logger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Logger>();
                if (instance == null)
                {
                    GameObject go = new GameObject("Logger");
                    instance = go.AddComponent<Logger>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    [Header("Log Settings")]
    public bool enableFileLogging = true;
    public bool enableConsoleLogging = true;
    public LogLevel minimumLogLevel = LogLevel.Debug;
    public string logFileName = "game_log.txt";
    public int maxLogFiles = 5;
    public int maxLogFileSize = 5 * 1024 * 1024; // 5MB

    private string logFilePath;
    private StreamWriter logWriter;
    private bool isInitialized = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeLogger();
    }

    private void InitializeLogger()
    {
        if (isInitialized) return;

        if (enableFileLogging)
        {
            string logDirectory = Path.Combine(Application.persistentDataPath, "Logs");
            Directory.CreateDirectory(logDirectory);

            logFilePath = Path.Combine(logDirectory, logFileName);
            ManageLogFiles();

            try
            {
                logWriter = new StreamWriter(logFilePath, true);
                logWriter.AutoFlush = true;
                Log(LogLevel.Info, "Logger initialized successfully");
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to initialize logger: " + e.Message);
                enableFileLogging = false;
            }
        }

        isInitialized = true;
    }

    private void ManageLogFiles()
    {
        string logDirectory = Path.GetDirectoryName(logFilePath);
        string[] logFiles = Directory.GetFiles(logDirectory, "*.txt");

        if (logFiles.Length >= maxLogFiles)
        {
            Array.Sort(logFiles);
            File.Delete(logFiles[0]);
        }

        if (File.Exists(logFilePath) && new FileInfo(logFilePath).Length > maxLogFileSize)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string newFileName = $"game_log_{timestamp}.txt";
            string newFilePath = Path.Combine(logDirectory, newFileName);
            File.Move(logFilePath, newFilePath);
        }
    }

    public void Log(LogLevel level, string message)
    {
        if (level < minimumLogLevel) return;

        string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";

        if (enableConsoleLogging)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    Debug.Log(logMessage);
                    break;
                case LogLevel.Info:
                    Debug.Log(logMessage);
                    break;
                case LogLevel.Warning:
                    Debug.LogWarning(logMessage);
                    break;
                case LogLevel.Error:
                case LogLevel.Critical:
                    Debug.LogError(logMessage);
                    break;
            }
        }

        if (enableFileLogging && logWriter != null)
        {
            try
            {
                logWriter.WriteLine(logMessage);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to write to log file: " + e.Message);
            }
        }
    }

    public void LogException(Exception exception, string context = "")
    {
        string message = string.IsNullOrEmpty(context) 
            ? $"Exception: {exception.Message}\nStack Trace: {exception.StackTrace}"
            : $"Context: {context}\nException: {exception.Message}\nStack Trace: {exception.StackTrace}";

        Log(LogLevel.Error, message);
    }

    private void OnDestroy()
    {
        if (logWriter != null)
        {
            try
            {
                logWriter.Close();
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to close log writer: " + e.Message);
            }
        }
    }

    // Convenience methods
    public static void Debug(string message) => Instance.Log(LogLevel.Debug, message);
    public static void Info(string message) => Instance.Log(LogLevel.Info, message);
    public static void Warning(string message) => Instance.Log(LogLevel.Warning, message);
    public static void Error(string message) => Instance.Log(LogLevel.Error, message);
    public static void Critical(string message) => Instance.Log(LogLevel.Critical, message);
    public static void Exception(Exception ex, string context = "") => Instance.LogException(ex, context);
} 