using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class JupyterNotebookRunner : MonoBehaviour
{
    void Start()
    {
        // ipynb 파일 경로 설정
        string notebookPath = Application.dataPath + "/../Python/UnityAndPython.ipynb";
        // txt 파일 경로 설정
        string filePath = Application.dataPath + "/Python/weather.txt";
        print(filePath);
        string jupyterPath = "C:\\Users\\Admin\\Anaconda3\\Scripts\\jupyter-notebook.exe";

        // 외부 프로세스 시작
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = jupyterPath;
        startInfo.Arguments = $"\"{notebookPath}\" \"{filePath}\"";
        startInfo.UseShellExecute = true;
        startInfo.WorkingDirectory = Application.dataPath + "/..";

        Process.Start(startInfo);

    }
}
