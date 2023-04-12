using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class JupyterNotebookRunner : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RunJupyterNotebook());
    }

    IEnumerator RunJupyterNotebook()
    {
        // ipynb ���� ��� ����
        string notebookPath = Application.dataPath + "/../Python/UnityAndPython.ipynb";
        // txt ���� ��� ����
        string filePath = Application.dataPath + "/Python/weather.txt";
        string jupyterPath = "C:\\Users\\Admin\\Anaconda3\\Scripts\\jupyter-notebook.exe";

        // �ܺ� ���μ��� ����
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = jupyterPath;
        startInfo.Arguments = $"\"{notebookPath}\" \"{filePath}\"";
        startInfo.UseShellExecute = true;
        startInfo.WorkingDirectory = Application.dataPath + "/..";

        Process.Start(startInfo);

        yield return new WaitForSeconds(60f);
        StartCoroutine(RunJupyterNotebook()); // �ٽ� �ڷ�ƾ ����
    }
}