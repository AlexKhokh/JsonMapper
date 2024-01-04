using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMapper.Models
{
    using Jurassic;
    using Jurassic.Library;

    public class BasePolicyConstructor : ClrFunction
    {
        public BasePolicyConstructor(ScriptEngine engine)
            : base(engine.Function.InstancePrototype, "BasePolicy", new BasePolicyInstance(engine.Object.InstancePrototype))
        {
        }

        [JSConstructorFunction]
        public BasePolicyInstance Construct(int seed)
        {
            return new BasePolicyInstance(this.InstancePrototype);
        }
    }

    public class BasePolicyInstance : ObjectInstance
    {
        public BasePolicyInstance(ObjectInstance prototype) : base(prototype)
        {
            this.PopulateFunctions();
        }

        [JSProperty(Name = "EffectiveDate")]
        public string EffectiveDate { get; set; }

        [JSProperty(Name = "ExpirationDate")]
        public string ExpirationDate { get; set; }

        [JSProperty(Name = "AcceptationDate")]
        public string AcceptationDate { get; set; }

        [JSProperty(Name = "DocumentDate")]
        public string DocumentDate { get; set; }

        [JSProperty(Name = "Insurer")]
        public PersonInstance Insurer { get; set; }

        [JSProperty(Name = "Vehicle")]
        public VehicleInstance Vehicle { get; set; }

    }
}
