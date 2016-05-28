using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using ThingSpeakDotNetLibrary;

namespace UnitTests
{
    public static class QueryStringBuilderTests
    {
        [Test]
        public static void EmptyParamsTest()
        {
            var parameters = new List<KeyValuePair<String, Object>>();
            String result = QueryStringBuilder.Build(parameters);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public static void OneParameterTest()
        {
            var parameters = new List<KeyValuePair<String, Object>> { new KeyValuePair<String, Object>("key", "value") };
            String result = QueryStringBuilder.Build(parameters);
            Assert.That(result, Is.EqualTo("?key=value"));
        }

        [Test]
        public static void ThreeParametersTest()
        {
            var parameters = new List<KeyValuePair<String, Object>> 
                { 
                    new KeyValuePair<String, Object>("key1", "value1"),
                    new KeyValuePair<String, Object>("key2", "value2"),
                    new KeyValuePair<String, Object>("key3", "value3"),
                };
            String result = QueryStringBuilder.Build(parameters);
            Assert.That(result, Is.EqualTo("?key1=value1&key2=value2&key3=value3"));
        }

        // Verify that QueryStringBuilder skips parameters that have null value
        [Test]
        public static void NullParamsAreSkippedTest()
        {
            var parameters = new List<KeyValuePair<String, Object>> 
                { 
                    new KeyValuePair<String, Object>("key1", "value1"),
                    new KeyValuePair<String, Object>("key2", "value2"),
                    new KeyValuePair<String, Object>("key3", null),
                };
            String result = QueryStringBuilder.Build(parameters);
            Assert.That(result, Is.EqualTo("?key1=value1&key2=value2"));
        }
    }
}
