using System.Runtime.InteropServices;
using UnityEngine;

public class AntiCheatSystem : MonoBehaviour
{
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    // List of modules to check for
    private string[] cheatModules = { "MelonLoader.dll", "BepInEx.Core.dll", "Harmony0.dll", "dobby.dll" };

    void Update()
    {
        foreach (string module in cheatModules)
        {
            if (GetModuleHandle(module) != IntPtr.Zero)
            {
                Debug.Log("Cheat module detected: " + module);
                Application.Quit();
            }
        }
    }
}
