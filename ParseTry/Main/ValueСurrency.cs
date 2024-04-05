using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTry.Main
{
	public static class ValueСurrency
	{
		public static decimal cnyValue = GetCnyRubValue() ?? 12.7501M;
		private static decimal? GetCnyRubValue()
		{
			var data = new HttpClient().GetStringAsync("https://www.cbr-xml-daily.ru/daily_json.js").Result;
			if (JObject.Parse(data).TryGetValue("Valute", out JToken valutes))
			{
				IEnumerable<Currencies> listCurrency = valutes.Select(val => JsonConvert.DeserializeObject<Currencies>(val.First.ToString()));
				return listCurrency.Where(val => val.CharCode == "CNY").FirstOrDefault().Value;
			}
			return null;
		}
	}
}
