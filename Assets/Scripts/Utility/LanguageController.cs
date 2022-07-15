using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ListLanguage
{
    English = 1,
    Russian = 2
}

public static class LanguageController
{
    private static int language = (int)ListLanguage.English;
    public static int GetLanguage() => language;

    public static void ChangeLanguage(int language)
    {
        LanguageController.language = language;
    }
}
