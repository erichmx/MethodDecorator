using System;
using System.Reflection;

using AnotherAssemblyAttributeContainer;
using MethodDecoratorInterfaces;
using SimpleTest;
using SimpleTest.Attributes.SimpleTest;

[assembly: AssemblyTitle("SimpleTest")]

[module: IntersectMethodsMarkedByAttribute(typeof(ObsoleteAttribute))]
[module: NoInitMethodDecorator]
[module: Interceptor]
[module: ExternalInterceptor]
[assembly: ExternalInterceptionAssemblyLevel]

[module: InterceptorByType(Types = new Type[] { typeof(TargetByType) }, ApplyToInheritedTypes = true, OnlyDecoratePublicMethods = true)]
