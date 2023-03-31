using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class JupyterNotebookRunner : MonoBehaviour
{
    void Start()
    {
        string jupyterPath = "C:\\Users\\Admin\\Anaconda3\\Scripts\\jupyter-notebook.exe"; // ������ ��Ʈ�� ���� ���� ���
        string notebookPath = Application.dataPath + "/../My project/Python/UnityAndPython.ipynb"; //������ ��Ʈ�� ���� ���

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = jupyterPath;
        startInfo.Arguments = $"\"{notebookPath}\"";
        startInfo.UseShellExecute = true;

        Process.Start(startInfo);
    }
}