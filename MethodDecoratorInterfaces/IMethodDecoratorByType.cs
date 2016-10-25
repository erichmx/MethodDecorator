using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodDecoratorInterfaces
{
    public interface IMethodDecoratorByType : IMethodDecorator
    {
        /// <summary>
        /// Types with the mtehods to be decorated
        /// </summary>
        Type[] Types { get; }
        /// <summary>
        /// Flag indicating wheter to apply the decoration to new methods in inherited types
        /// </summary>
        bool ApplyToInheritedTypes { get; }
        /// <summary>
        /// Flag to indicate if this decoration applies only to public methods
        /// </summary>
        bool OnlyDecoratePublicMethods { get; }
    }
}
