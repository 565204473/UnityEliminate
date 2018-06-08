using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DirectoryUtility
{
    public static Stream CreateFileStream(string path)
    {
        return new FileStream(path, FileMode.Open);
    }

    public static void Delete(string path)
    {
        File.Delete(path);
    }

    public static bool Exists(string path)
    {
        return File.Exists(path);
    }

    public static void Move(string from, string to)
    {
        File.Move(from, to);
    }

    public static byte[] ReadAllBytes(string path)
    {
        return File.ReadAllBytes(path);
    }
}
