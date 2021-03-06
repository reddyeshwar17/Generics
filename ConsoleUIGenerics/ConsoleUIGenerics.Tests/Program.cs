// <copyright file="Program.cs">Copyright ©  2018</copyright>
using System;
using ConsoleUIGenerics;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleUIGenerics.Tests
{
    /// <summary>This class contains parameterized unit tests for Program</summary>
    [PexClass(typeof(Program))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class Program
    {
        /// <summary>Test stub for CombineString(String[])</summary>
        [PexMethod]
        public string CombineString([PexAssumeUnderTest]Program target, string[] strArray)
        {
            string result = target.CombineString(strArray);
            return result;
            // TODO: add assertions to method Program.CombineString(Program, String[])
        }
    }
}
