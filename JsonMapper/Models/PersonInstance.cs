using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMapper.Models
{
    using Jurassic;
    using Jurassic.Library;

    public class PersonConstructor : ClrFunction
    {
        public PersonConstructor(ScriptEngine engine)
            : base(engine.Function.InstancePrototype, "Person", new PersonInstance(engine.Object.InstancePrototype))
        {
        }

        [JSConstructorFunction]
        public PersonInstance Construct(int seed)
        {
            return new PersonInstance(this.InstancePrototype);
        }
    }

    public class PersonInstance : ObjectInstance
    {
        public PersonInstance(ObjectInstance prototype)
            : base(prototype)
        {
            this.PopulateFunctions();
        }

        [JSProperty(Name = "Name")]
        public string Name { get; set; }
    }    
}
