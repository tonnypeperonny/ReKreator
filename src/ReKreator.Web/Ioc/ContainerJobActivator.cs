using System;
using Autofac;
using Hangfire;

namespace ReKreator.Web.Ioc
{
    public class ContainerJobActivator : JobActivator
    {
        private readonly IContainer container;

        public ContainerJobActivator(IContainer container)
        {
            this.container = container;
        }

        public override object ActivateJob(Type type)
        {
            return container.Resolve(type);
        }
    }
}
