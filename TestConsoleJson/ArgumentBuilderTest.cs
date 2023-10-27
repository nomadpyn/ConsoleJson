using ConsoleJson.Utils;

namespace TestConsoleJson
{
    public class ArgumentBuilderTest
    {
        [Fact]
        public void TestArgumentBuilderCreateNullArgs()
        {
            string[] args = null;

            ArgumentBuilder builder = new(args);

            Assert.NotNull(builder);
        }

        [Fact]
        public void TestArgumentBuilderCreateNotNullArgs()
        {
            string[] args = new[] { "arguments" };

            ArgumentBuilder builder = new(args);

            Assert.NotNull(builder);
        }
        [Fact]
        public void TestArgumentsCreateNullArgs()
        {
            string[] args = null;

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        [Fact]
        public void TestArgumentsCreateNotNullArgs()
        {
            string[] args = new[] { "arguments" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        [Fact]
        public void TestArgumentsCreateOneWrongArg()
        {
            string[] args = new[] { "arg1" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        [Fact]
        public void TestArgumentsCreateTwoWrongArgs()
        {
            string[] args = new[] { "arg1", "arg2" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        [Fact]
        public void TestArgumentsCreateThreeWrongArgs()
        {
            string[] args = new[] { "arg1", "arg2", "arg3" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        [Fact]
        public void TestArgumentsCreateFourWrongArgs()
        {
            string[] args = new[] { "arg1", "arg2", "arg3", "arg4" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        [Fact]
        public void TestArgumentsCreateTwoCorrectArgsRus()
        {
            string[] args = new[] { "arg1", "RUS"};

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        [Fact]
        public void TestArgumentsCreateThreeCorrectArgsRus()
        {

            string[] args = new[] { "arg1", "RUS", "arg3" };

            ArgumentBuilder builder = new(args);

            Assert.NotNull(builder.myArguments);
            Assert.True(builder.myArguments.Country.Equals("RUS"));
        }

        [Fact]
        public void TestArgumentsCreateFourCorrectArgsRus()
        {
            string[] args = new[] { "arg1", "RUS", "arg3", "arg4" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        [Fact]
        public void TestArgumentsCreateTwoCorrectArgsUsa()
        {
            string[] args = new[] { "arg1", "USA" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        [Fact]
        public void TestArgumentsCreateThreeCorrectArgsUsa()
        {

            string[] args = new[] { "arg1", "USA", "arg3" };

            ArgumentBuilder builder = new(args);

            Assert.NotNull(builder.myArguments);
            Assert.True(builder.myArguments.Country.Equals("USA"));
        }

        [Fact]
        public void TestArgumentsCreateFourCorrectArgsUsa()
        {
            string[] args = new[] { "arg1", "USA", "arg3", "arg4" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }


    }
}