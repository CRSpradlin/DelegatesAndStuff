using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DelegatesAndStuff
{
    public class MakingTagsTests
    {

        [Fact]
        public void CanMakeTagsProcedureally()
        {
            Assert.Equal("<p>Hello</p>", TagMaker("p", "Hello"));

            string TagMaker(string element, string content)
            {
                return $"<{element}>{content}</{element}>";
            }
        }

        [Theory]
        [InlineData("Hello")]
        [InlineData("Goodbye")]
        public void TagMakerWorksRight(string content)
        {
            var h1Maker = new TagMaker("h1");

            Assert.Equal($"<h1>{content}</h1>",h1Maker.Make(content));
        }

        public class TagMaker
        {
            private string element;

            public TagMaker(string element)
            {
                this.element = element;
            }

            public string Make(string content)
            {
                return $"<{element}>{content}</{element}>";
            }
        }

        [Fact]
        public void CanMakeTagsFunctionalStyle()
        {
            Func<string, Func<string, string>> tagMaker;

            tagMaker = (tag) => (content) => $"<{tag}>{content}</{tag}>";

            var h1Maker = tagMaker("h1");
            var pMaker = tagMaker("p");

            Assert.Equal("<h1>Hello</h1>", h1Maker("Hello"));
            Assert.Equal("<p>Goodbye</p>", pMaker("Goodbye"));
        }
    }
}
