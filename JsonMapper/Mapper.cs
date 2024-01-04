using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonMapper.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace JsonMapper
{
    public interface IMapper
    {
        BasePolicy Map(string json, string template);
        BasePolicy Deserialize(string json);
    }

    public class Mapper : IMapper
    {
        private readonly string _mapperFile; 

        public Mapper(string mapperFile) { _mapperFile = mapperFile; }

        public BasePolicy Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<BasePolicy>(json);
        }

        public BasePolicy Map(string json, string template)
        {
            try
            {
                var engine = new Jurassic.ScriptEngine();
                engine.SetGlobalValue("BasePolicy", new BasePolicyConstructor(engine));
                engine.SetGlobalValue("Person", new PersonConstructor(engine));
                engine.SetGlobalValue("Vehicle", new VehicleConstructor(engine));
                engine.ExecuteFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _mapperFile));
                var bp = engine.CallGlobalFunction<BasePolicyInstance>(template, json);
                var result = bp.MapToBasePolicy();
                return result;
            }
            catch (Jurassic.JavaScriptException jex) { Console.WriteLine(jex.ToString()); throw new Exception(); } // jurassicexception можно было не выделять т.к. обработка точно такая же, но теоретически может быть другая обр-ка.

            catch (Exception ex) { Console.WriteLine(ex.ToString()); throw new Exception(); }
        }
    }
}
