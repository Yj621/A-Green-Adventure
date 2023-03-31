using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class JupyterNotebookRunner : MonoBehaviour
{
    void Start()
    {
        string jupyterPath = "C:\\Users\\Excellent_Summer\\anaconda3\\Scripts\\jupyter-notebook.exe"; // 주피터 노트북 실행 파일 경로
        string notebookPath = "C:\\Users\\Excellent_Summer\\Desktop\\git\\Kp-23-1\\My project\\Python\\Unity And Python.ipynb"; // 주피터 노트북 파일 경로

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = jupyterPath;
        startInfo.Arguments = $"\"{notebookPath}\"";
        startInfo.UseShellExecute = true;

        Process.Start(startInfo);
    }
}