using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Networking;

namespace Hello_World.Utilidades;

public static class NetGuard
{
    public static bool IsOnline() =>
        Connectivity.Current.NetworkAccess == NetworkAccess.Internet;

    public static async Task<bool> IsServerAliveAsync(string url, int timeoutMs = 3000)
    {
        try
        {
            using var http = new HttpClient { Timeout = TimeSpan.FromMilliseconds(timeoutMs) };
            var resp = await http.GetAsync(url);
            return resp.IsSuccessStatusCode;
        }
        catch { return false; }
    }
}
