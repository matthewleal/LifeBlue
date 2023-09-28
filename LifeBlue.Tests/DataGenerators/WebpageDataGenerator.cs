using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeBlue.Tests.DataGenerators
{
    public static class WebpageDataGenerator
    {
        public static IEnumerable<object[]> URL_TESTS()
        {
            yield return new object[] {@"/section/index.html", @"/section/page.html", true};
            yield return new object[] {@"/section/page.html", @"/section/other-page.html", false};
            yield return new object[] {@"/section/index.html", @"/section/subsection/index.html", true};
            yield return new object[] {@"/section/index.html", @"/section/subsection/page.html", true};
            yield return new object[] {@"/section/subsection/index.html", @"/section/other/index.html", false};
        }
    }
}
