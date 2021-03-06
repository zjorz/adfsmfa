﻿//******************************************************************************************************************************************************************************************//
// Copyright (c) 2020 abergs (https://github.com/abergs/fido2-net-lib)                                                                                                                      //                        
//                                                                                                                                                                                          //
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),                                       //
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,   //
// and to permit persons to whom the Software is furnished to do so, subject to the following conditions:                                                                                   //
//                                                                                                                                                                                          //
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.                                                           //
//                                                                                                                                                                                          //
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,                                      //
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,                            //
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                               //
//                                                                                                                                                                                          //
//******************************************************************************************************************************************************************************************//
using Newtonsoft.Json;
using System;

namespace Neos.IdentityServer.MultiFactor.WebAuthN
{
    [JsonConverter(typeof(ToStringJsonConverter))]
    public class TypedString : IEquatable<TypedString>
    {

        [JsonConstructor]
        protected TypedString(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static implicit operator string(TypedString op) { return op.Value; }

        public override string ToString()
        {
            return Value;
        }

        public bool Equals(TypedString other)
        {
            if (ReferenceEquals(this, other))
                return true;

            if (ReferenceEquals(null, other))
                return false;

            //if your below implementation will involve objects of derived classes, then do a 
            //GetType == other.GetType comparison
            if (GetType() != other.GetType())
                return false;

            if (Value == other.Value)
                return true;

            return false;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TypedString);
        }

        public static bool operator ==(TypedString e1, TypedString e2)
        {
            if (ReferenceEquals(e1, null))
                return ReferenceEquals(e2, null);

            return e1.Equals(e2);
        }

        public static bool operator !=(TypedString e1, TypedString e2)
        {
            return !(e1 == e2);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
            //throw new NotImplementedException("Your lightweight hashing algorithm, consistent with Equals method, here...");
        }
    }
}
