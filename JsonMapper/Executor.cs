using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json;
using System.IO;

namespace JsonMapper
{
    public  class Executor
    {
        private readonly IDictionary<JSchema, string> _schemaMapper;
        private readonly IMapper _mapper;

        public Executor(string path, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _schemaMapper = getMapperDictionary(path);
        } 

        public void Execute(string json)
        {
            JObject insurance = getInsurance(json);
            bool isValid = false;
            foreach (var item in _schemaMapper)
            {
                if (insurance.IsValid(item.Key))
                {
                    isValid = true;
                    try
                    {
                        insurance.ToString().ChooseMapper(item.Value, _mapper).Invoke(item.Value).ShowBasePolicy();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); Console.WriteLine("No Continuation of work. Press any key for exit twice."); Console.ReadKey(); }
                }
            }
            if (!isValid) Console.WriteLine("Input json is not valid on existing schemas. Press any key for exit.");
        }

        private JObject getInsurance(string path)
        {
            JObject insurance = System.Globalization.CultureInfo.InstalledUICulture.ToString().Contains("ru") ?
                JObject.Parse(File.ReadAllText(path, Encoding.GetEncoding(1251))) : JObject.Parse(File.ReadAllText(path)); //предполагается что входящий json сформирован корректно
            return insurance;
        }

        private IDictionary<JSchema, string> getMapperDictionary(string path)
        {
            JArray jSchemaArray;
            using (StreamReader file = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject jobject = (JObject)JToken.ReadFrom(reader);
                jSchemaArray = (JArray)jobject["schemaArray"];
            }

            var schemas = new Dictionary<JSchema, string>();
            for (int i = 0; i < jSchemaArray.Count; i++)
            {
                var properties = ((JObject)jSchemaArray[i]).Properties().ToArray();
                schemas.Add(JSchema.Load(properties[0].Value.CreateReader()), properties[0].Name);
            }
            return schemas;
        }
    }
}
