using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonMapper.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;

namespace JsonMapper
{
    public static class Extensions
    {
        public static Func<string, BasePolicy> ChooseMapper(this string json, string template, IMapper mapper)
        {
            if (template.ToLowerInvariant() == "default") return x => mapper.Deserialize(json);
            else return x => mapper.Map(json, template);
        }       

        public static BasePolicy MapToBasePolicy(this BasePolicyInstance basePolicyInst)
        {
            return new BasePolicy
            {
                ExpirationDate = getDate(basePolicyInst.ExpirationDate, true),
                EffectiveDate = getDate(basePolicyInst.EffectiveDate, true),
                AcceptationDate = getDate(basePolicyInst.AcceptationDate),
                DocumentDate = getDate(basePolicyInst.DocumentDate),
                Insurer = new Person { Name = basePolicyInst.Insurer.Name },
                Vehicle = new Vehicle { MarkName = basePolicyInst.Vehicle.MarkName, ModelName = basePolicyInst.Vehicle.ModelName }
            };
        }       

        public static void ShowBasePolicy(this BasePolicy basePolicy)
        {

            Console.WriteLine($"Insurer: {basePolicy.Insurer.Name}");
            Console.WriteLine($"Mark: {basePolicy.Vehicle.MarkName}");
            Console.WriteLine($"Model: {basePolicy.Vehicle.ModelName}");
            Console.WriteLine($"EffectiveDate: {basePolicy.EffectiveDate.ToShortDateString()}");
            Console.WriteLine($"ExpirationDate: {basePolicy.ExpirationDate.ToShortDateString()}");
            Console.WriteLine($"AcceptationDate: {basePolicy.AcceptationDate.ToShortDateString()}");
            Console.WriteLine($"DocumentDate: {basePolicy.DocumentDate.ToShortDateString()}");
        }

        private static DateTime getDate(string date, bool required = false)
        {
            DateTime result;
            if (String.IsNullOrWhiteSpace(date) && required) throw new Exception($"{date} is required and can not be null or empty");
            if (String.IsNullOrWhiteSpace(date) && !required) return DateTime.Now.Date;
            if (!DateTime.TryParse(date, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                throw new Exception($"Could not cast {date} to DateTime type");
            else return result;
        }
    }
}
