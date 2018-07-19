﻿/****************************************************************************
* Description:
*
* Author: hiramtan @live.com
****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace HiFramework
{
    class Binding : IBinding
    {
        public List<Type> Types { get; private set; }
        public Type ToType { get; private set; }
        public object ToObj { get; private set; }
        public string AsName { get; set; }

        public Binding(IBindContainer iBindContainer)
        {
            Types = new List<Type>();
            iBindContainer.AddBinding(this);
        }
        public IBinding Bind<T>()
        {
            var type = typeof(T);
            if (!type.IsClass && !type.IsInterface)
            {
                HiAssert.Fail("T is not class or interface");
            }
            Types.Add(type);
            return this;
        }

        public IBindingAsName To<T>()
        {
            var type = typeof(T);
            if (type.IsSubclassOf(typeof(MonoBehaviour)))
            {
                HiAssert.Fail("this class is sub from monobehavior, use to object instead");
            }
            if (!type.IsClass)
            {
                HiAssert.Fail("type is not class");
            }
            ToType = typeof(T);
            return new BindingAsName(this);
        }

        public IBindingAsName To(object obj)
        {
            if (!obj.GetType().IsClass)
            {
                HiAssert.Fail("type is not class");
            }
            ToObj = obj;
            return new BindingAsName(this);
        }
    }
}