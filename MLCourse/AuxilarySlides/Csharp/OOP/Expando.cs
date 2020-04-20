using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic; 
namespace TestVS
{
    class DynamicClass : DynamicObject
    {
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, Object> props =
            new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        public DynamicClass() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, 
            out object result)
        {
            string name = binder.Name.ToLower();
            return props.TryGetValue(name, out result);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool TrySetMember(SetMemberBinder binder,
            object value)
        {
            props[binder.Name.ToLower()] = value;

           
            return true;

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            dynamic dc = new DynamicClass();
            //--------- Adding a property
            dc.hell = 10;
            //--------read back the property...
            Console.WriteLine(dc.hell);
          
            //------- Creating an Action delegate...
            Action<int> ts = new Action<int>( delegate(int i ) {
                Console.WriteLine(i.ToString());

            });

            //------------Adding a method....
            dc.rs = ts;

            //----------- invoking a method....
            dc.rs(100);

            Console.Read();

        }
    }
}