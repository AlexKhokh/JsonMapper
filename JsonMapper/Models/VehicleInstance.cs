using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMapper.Models
{
    using Jurassic;
    using Jurassic.Library;

    public class VehicleConstructor : ClrFunction
    {
        public VehicleConstructor(ScriptEngine engine)
            : base(engine.Function.InstancePrototype, "Vehicle", new VehicleInstance(engine.Object.InstancePrototype))
        {
        }

        [JSConstructorFunction]
        public VehicleInstance Construct(int seed)
        {
            return new VehicleInstance(this.InstancePrototype);
        }
    }

    public class VehicleInstance : ObjectInstance
    {
        public VehicleInstance(ObjectInstance prototype)
             : base(prototype)
        {
            this.PopulateFunctions();
        }

        [JSProperty(Name = "Mark")]
        public string MarkName { get; set; }            // Наименование марки
        [JSProperty(Name = "Model")]
        public string ModelName { get; set; }           // Наименование модели
    }
}
