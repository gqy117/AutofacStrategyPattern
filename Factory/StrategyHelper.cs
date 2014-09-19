using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;

namespace Factory
{
    public class StrategyHelper<TBaseClass, TInterface>
    {
        #region Properties
        #region Autofac DI Container
        private Autofac.IContainer MyContainer { get; set; }
        private ContainerBuilder _builder = new ContainerBuilder();
        private ContainerBuilder Builder
        {
            get { return _builder; }
            set { _builder = value; }
        }
        #endregion
        #region Class to be create
        public Dictionary<string, TInterface> DicClass = new Dictionary<string, TInterface>();
        private List<ClassType> _ListClass = new List<ClassType>();
        private List<ClassType> ListClass
        {
            get { return _ListClass; }
            set { _ListClass = value; }
        }
        private List<Parameter> ListParameters
        {
            get;
            set;
        }
        #endregion
        private Assembly ServiceAssembly { get; set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Init method
        /// </summary>
        /// <param name="serviceAssembly"></param>
        /// <param name="listParameters"></param>
        public void Init(Assembly serviceAssembly, List<Parameter> listParameters)
        {
            this.ServiceAssembly = serviceAssembly;
            this.ListParameters = listParameters;

            RegisterAssemble();
            BindDictionaryClass();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Use autofac to register class instance
        /// </summary>
        private void RegisterAssemble()
        {
            foreach (Type type in ServiceAssembly.GetTypes())
            {
                string typeName = type.Name;

                if (type.IsSubclassOf(typeof(TBaseClass)))
                {
                    this.Builder.RegisterType(type).Named<TInterface>(typeName).WithProperties(ListParameters);
                    int sequence = GetSequence(type);
                    this.ListClass.Add(new ClassType() { TypeName = typeName, Sequence = sequence });
                }
            }
            this.MyContainer = Builder.Build();
        }
        /// <summary>
        /// Get Class sequence
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private int GetSequence(Type type)
        {
            SequenceAttribute sequence = type.GetCustomAttributes(typeof(SequenceAttribute), true).FirstOrDefault() as SequenceAttribute;
            return sequence == null ? 0 : sequence.Sequence;
        }
        /// <summary>
        /// Add class to dictionary
        /// </summary>
        private void BindDictionaryClass()
        {
            foreach (ClassType item in this.ListClass.OrderBy(x => x.Sequence))
            {
                this.DicClass.Add(item.TypeName, this.MyContainer.ResolveNamed<TInterface>(item.TypeName));
            }
        }
        #endregion
    }
}
