// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace System.Runtime.Serialization
{
    internal static class DataContractSurrogateCaller
    {
        [RequiresUnreferencedCode(DataContract.SerializerTrimmerWarning)]
        internal static Type GetDataContractType(ISerializationSurrogateProvider surrogateProvider, Type type)
        {
            if (DataContract.GetBuiltInDataContract(type) != null)
                return type;
            return surrogateProvider.GetSurrogateType(type) ?? type;
        }

        [return: NotNullIfNotNull(nameof(obj))]
        [RequiresUnreferencedCode(DataContract.SerializerTrimmerWarning)]
        internal static object? GetObjectToSerialize(ISerializationSurrogateProvider surrogateProvider, object? obj, Type objType, Type membertype)
        {
            if (obj == null)
                return null;
            if (DataContract.GetBuiltInDataContract(objType) != null)
                return obj;
            return surrogateProvider.GetObjectToSerialize(obj, membertype);
        }

        [return: NotNullIfNotNull(nameof(obj))]
        [RequiresUnreferencedCode(DataContract.SerializerTrimmerWarning)]
        internal static object? GetDeserializedObject(ISerializationSurrogateProvider surrogateProvider, object? obj, Type objType, Type memberType)
        {
            if (obj == null)
                return null;
            if (DataContract.GetBuiltInDataContract(objType) != null)
                return obj;
            return surrogateProvider.GetDeserializedObject(obj, memberType);
        }
    }
}
