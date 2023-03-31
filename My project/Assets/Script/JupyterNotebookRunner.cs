using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class JupyterNotebookRunner : MonoBehaviour
{
    void Start()
    {
        string jupyterPath = "C:\\Users\\Admin\\Anaconda3\\Scripts\\jupyter-notebook.exe"; // 주피터 노트북 실행 파일 경로
        string notebookPath = Application.dataPath + "/../My project/Python/UnityAndPython.ipynb"; //주피터 노트북 파일 경로

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = jupyterPath;
        startInfo.Arguments = $"\"{notebookPath}\"";
        startInfo.UseShellExecute = true;

        Process.Start(startInfo);
    }
}