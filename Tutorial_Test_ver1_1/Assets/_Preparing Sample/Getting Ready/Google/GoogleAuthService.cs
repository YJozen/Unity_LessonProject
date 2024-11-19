using System.IO;
using Google.Apis.Auth.OAuth2;
using UnityEngine;

public static class GoogleAuthService
{
    static string KeyPath => Path.Combine(Application.streamingAssetsPath, "path-to-key-json.json");

    private static ICredential _credential;

    public static ICredential GetCredential(string[] scopes) {
        if (_credential != null) {
            return _credential;
        }

        using (var stream = new FileStream(KeyPath, FileMode.Open, FileAccess.Read)) {
            _credential = GoogleCredential.FromStream(stream)
                .CreateScoped(scopes).UnderlyingCredential;
        }

        return _credential;
    }
}