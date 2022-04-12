using LocadoraFilmesApi.Service.Domain.Models;
using Newtonsoft.Json;
using System.Collections;

namespace LocadoraFilmesApi.Service.Domain.Util
{
    public static class HanddleError<T>
    {
        public static string Handle(T request, Exception e, params ErrorMessage[] errors)
        {
            var errorData = e.Data.OfType<DictionaryEntry>().ToDictionary(kv => kv.Key.ToString(), kv => kv.Value?.ToString());
            return JsonConvert.SerializeObject(new { Request = request, ErrorMessage = errors, Data = errorData });
        }
    }
}
