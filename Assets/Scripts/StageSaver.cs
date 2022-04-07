using System.IO;
using UnityEngine;

public class StageSaver
{
    private string dataDirPath = "";
    private string dataFileName = "";
    private string fullPath = "";

    private bool encryptSaveFiles;
    private string encryptionKey = "dRe:iVQ!soTr30,N+,51[Z&;*{gkr0%J";

    public StageSaver(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }
    public StageSaver(string fullPath)
    {
        this.fullPath = fullPath;
    }
    public void Save(StageData data, bool rewrite)
    {
        fullPath = fullPath == "" ? Path.Combine(dataDirPath, dataFileName) : fullPath;
        this.encryptSaveFiles = Parameters.GetRoot().EncryptSaveFiles;

        if (data == null) { throw (new System.NullReferenceException("Data file is null")); }
        if (File.Exists(fullPath) && !rewrite)
        {
            throw (new FileLoadException("File already exists and rewrite box is not checked!"));
        }

        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
        string dataToStore = JsonUtility.ToJson(data, true);

        dataToStore = encryptSaveFiles ? EncryptDecrypt(dataToStore) : dataToStore;

        using (FileStream stream = new FileStream(fullPath, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(dataToStore);
            }
        }

        Debug.Log($"Game data saved...\n{fullPath}");
    }

    public StageData Load()
    {
        fullPath = fullPath == "" ? Path.Combine(dataDirPath, dataFileName) : fullPath;
        this.encryptSaveFiles = Parameters.GetRoot().EncryptSaveFiles;

        StageData loadedData = null;
        try
        {
            if (File.Exists(fullPath))
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                dataToLoad = encryptSaveFiles ? EncryptDecrypt(dataToLoad) : dataToLoad;

                loadedData = JsonUtility.FromJson<StageData>(dataToLoad);

                Debug.Log($"Game data loaded...\n{fullPath}");
                return loadedData;
            }
        }
        catch
        {
            Debug.LogError("No file at this path or some error during loading occured.");
        }
        return loadedData;
    }
    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionKey[i % encryptionKey.Length]);
        }
        return modifiedData;
    }
}
