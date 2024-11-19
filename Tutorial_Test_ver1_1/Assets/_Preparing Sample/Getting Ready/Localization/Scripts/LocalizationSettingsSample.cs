using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizationSettingsSample : MonoBehaviour
{

    private async void Start()
    {
        LocalizationSettings.SelectedLocale = Locale.CreateLocale("en");
        // LocalizationSetting‚ª‰Šú‰»‚³‚ê‚é‚Ì‚ğ‘Ò‚Â
        await LocalizationSettings.InitializationOperation.Task;

        const string tableName = "String Table Shared Data";
        const string entryKey  = "SmartString";

        // ”ñ“¯Šú‚ÅEntryæ“¾
        var entry = (await LocalizationSettings.StringDatabase.GetTableEntryAsync(tableName, entryKey).Task).Entry;
    }


    async void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            LocalizationSettings.SelectedLocale = Locale.CreateLocale("ja");
            await LocalizationSettings.InitializationOperation.Task;

            const string tableName = "String Table Shared Data";
            const string entryKey = "String_Ja_En";

            // ”ñ“¯Šú‚ÅEntryæ“¾
            var entry = (await LocalizationSettings.StringDatabase.GetTableEntryAsync(tableName, entryKey).Task).Entry;

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            LocalizationSettings.SelectedLocale = Locale.CreateLocale("en");
            await LocalizationSettings.InitializationOperation.Task;
        }
    }
}
