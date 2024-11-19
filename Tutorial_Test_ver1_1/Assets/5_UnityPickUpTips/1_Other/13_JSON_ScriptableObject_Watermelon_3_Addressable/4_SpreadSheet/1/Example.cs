using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UnityEngine;

namespace Google_SpreadSheet
{
    public class Example : MonoBehaviour
    {
        string sheetName;
        private async void Start() {
            await AuthorizeAsync();
        }

        public async Task AuthorizeAsync() {
            var clientId     = "40362758993-5ei0hrb9n8p9ra7dk678s9vtchc8odt9.apps.googleusercontent.com";
            var clientSecret = "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";
            var user = "example-user";

            // ClientId ・ ClientSecret　の設定
            var secrets = new ClientSecrets {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            var scopes = new[]
            {
            // 使いたいServiceのスコープを配列で指定
            SheetsService.Scope.SpreadsheetsReadonly
            };
            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, scopes, user, CancellationToken.None);



            // Serviceを初期化
            var sheetService = new SheetsService(new BaseClientService.Initializer {
                HttpClientInitializer = credential
            });

            // Spreadsheetの取得　ここではシート名を表示
            var spreadSheetId = "1aPyOPL83IsKJokxBrOrqV92gFCi7tlDn9UTkVZgzElw";
            var result = await sheetService.Spreadsheets.Get(spreadSheetId).ExecuteAsync();

            
            foreach (var sheet in result.Sheets) {
                sheetName = sheet.Properties.Title;
                Debug.Log(sheet.Properties.Title);
            }

            //String wRange;
            //int rowNumber = 1;
            //wRange = String.Format("{0}!A{1}:B", sheetName, rowNumber); //行を全部読む
            //SpreadsheetsResource.ValuesResource.GetRequest getRequest = sheetService.Spreadsheets.Values.Get(spreadSheetId, wRange);

            //ValueRange rVR;
            //rVR = getRequest.Execute();
            //IList<IList<System.Object>> values = rVR.Values;

            //Debug.Log(values);
        }
    }
}