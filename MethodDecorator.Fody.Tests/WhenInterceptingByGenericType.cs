﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MethodDecorator.Fody.Tests;
using Xunit;

namespace MethodDecoratorEx.Fody.Tests
{
    public class WhenInterceptingByGenericType : ClassTestsBase
    {
        public WhenInterceptingByGenericType() : base("SimpleTest.TargetByGenericType`1[[System.String, mscorlib]]") { }


        [Fact]
        public void ShouldInterceptPublicMethodInType()
        {
            this.TestClass.PublicVirtualMethodNotDecorated();
            this.CheckMethodSeq(new[] { Method.Init, Method.OnEnter, Method.Body, Method.OnExit });
        }

        [Fact]
        public void ShouldInterceptPublicMethodInTypeUsingReflection()
        {
            Type type = this.TestClass.GetType();
            var method = type.GetMethod("PublicVirtualMethodNotDecorated", BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            method.Invoke(this.TestClass, new object[] { });
            this.CheckMethodSeq(new[] { Method.Init, Method.OnEnter, Method.Body, Method.OnExit });
        }

        [Fact]
        public void ShouldNotInterceptProtectedMethodInType()
        {
            Type type = this.TestClass.GetType();
            var method = type.GetMethod("ProtectedVirtualMethodNotDecorated", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            method.Invoke(this.TestClass, new object[]{});
            this.CheckMethodSeq(new[] { Method.Body });
        }

        [Fact]
        public void ShouldInterceptPublicInheritedMethodInDerivedType()
        {
            var subClass = this.Assembly.GetInstance("SimpleTest.TargetByGenericTypeInherited");
            subClass.PublicVirtualMethodNotDecorated();
            this.CheckMethodSeq(new[] { Method.Init, Method.OnEnter, Method.Body, Method.OnExit });
        }

        [Fact]
        public void ShouldInterceptPublicNewMethodInDerivedType()
        {
            var subClass = this.Assembly.GetInstance("SimpleTest.TargetByGenericTypeInherited");
            subClass.PublicNewMethodNotDecorated();
            this.CheckMethodSeq(new[] { Method.Init, Method.OnEnter, Method.Body, Method.OnExit });
        }

    }
}
