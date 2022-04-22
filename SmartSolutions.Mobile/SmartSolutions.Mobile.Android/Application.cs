using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Caliburn.Micro;
using SmartSolutions.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SmartSolutions.Mobile.Droid
{
    [Application]
    public class Application : CaliburnApplication
    {
        #region [Private Members]
        private SimpleContainer container;

        #endregion

        #region [Constructor]
        public Application(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer) { }

        #endregion

        #region [Methods]

        public override void OnCreate()
        {
            base.OnCreate();

            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();
            container.Instance(container);
            container.Singleton<App>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[]
            {
                GetType().Assembly,
                typeof (HomeViewModel).Assembly
            };
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }
        #endregion
    }
}