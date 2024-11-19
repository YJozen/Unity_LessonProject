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
        // LocalizationSetting�������������̂�҂�
        await LocalizationSettings.InitializationOperation.Task;

        const string tableName = "String Table Shared Data";
        const string entryKey  = "SmartString";

        // �񓯊���Entry�擾
        var entry = (await LocalizationSettings.StringDatabase.GetTableEntryAsync(tableName, entryKey).Task).Entry;
    }


    async void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            LocalizationSettings.SelectedLocale = Locale.CreateLocale("ja");
            await LocalizationSettings.InitializationOperation.Task;

            const string tableName = "String Table Shared Data";
            const string entryKey = "String_Ja_En";

            // �񓯊���Entry�擾
            var entry = (await LocalizationSettings.StringDatabase.GetTableEntryAsync(tableName, entryKey).Task).Entry;

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            LocalizationSettings.SelectedLocale = Locale.CreateLocale("en");
            await LocalizationSettings.InitializationOperation.Task;
        }
    }
}
