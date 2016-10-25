using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodDecoratorInterfaces
{
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module)]
    public class MethodDecoratorByTypeAttribute : MethodDecoratorAttribute, IMethodDecoratorByType
    {
        /// <summary>
        /// Types with the mtehods to be decorated
        /// </summary>
        public Type[] Types { get; set; }

        /// <summary>
        /// Flag indicating wheter to apply the decoration to new methods in inherited types. Defaults to true.
        /// </summary>
        public bool ApplyToInheritedTypes { get; set; } = true;

        /// <summary>
        /// Flag to indicate if this decoration applies only to public methods. Defaults to true.
        /// </summary>
        public bool OnlyDecoratePublicMethods { get; set; } = true;

    }
}
