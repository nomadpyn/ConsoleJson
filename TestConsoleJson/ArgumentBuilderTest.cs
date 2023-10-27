#region Using
using ConsoleJson.Utils;
#endregion

namespace TestConsoleJson
{
    #region Public Class ArgumentBuilderTest

    /// <summary>
    /// ����� �� �������� ������� ���������� �� ��������� ������
    /// </summary>
    public class ArgumentBuilderTest
    {
        #region Public Fields

        /// <summary>
        /// ���� �� ArgumentBuilder ��� ������ ����������
        /// </summary>
        [Fact]
        public void TestArgumentBuilderCreateNullArgs()
        {
            string[] args = null;

            ArgumentBuilder builder = new(args);

            Assert.NotNull(builder);
        }

        /// <summary>
        /// ���� �� ArgumentBuilder ��� ����� ���������
        /// </summary>
        [Fact]
        public void TestArgumentBuilderCreateNotNullArgs()
        {
            string[] args = new[] { "arguments" };

            ArgumentBuilder builder = new(args);

            Assert.NotNull(builder);
        }

        /// <summary>
        /// ���� �� ArgumentBuilder.myArguments ��� ������ ���������� 
        /// </summary>
        [Fact]
        public void TestArgumentsCreateNullArgs()
        {
            string[] args = null;

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        /// <summary>
        /// ���� �� ArgumentBuilder.myArguments ��� ����� ���������
        /// </summary>
        [Fact]
        public void TestArgumentsCreateNotNullArgs()
        {
            string[] args = new[] { "arguments" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        /// <summary>
        /// ���� �� ArgumentBuilder.myArguments ��� ����� ������������ ��������� 
        /// </summary>
        [Fact]
        public void TestArgumentsCreateOneWrongArg()
        {
            string[] args = new[] { "arg1" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        /// <summary>
        /// ���� �� ArgumentBuilder.myArguments ��� ���� ������������ ����������
        /// </summary>
        [Fact]
        public void TestArgumentsCreateTwoWrongArgs()
        {
            string[] args = new[] { "arg1", "arg2" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        /// <summary>
        /// ���� �� ArgumentBuilder.myArguments ��� ���� ������������ ����������
        /// </summary>
        [Fact]
        public void TestArgumentsCreateThreeWrongArgs()
        {
            string[] args = new[] { "arg1", "arg2", "arg3" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        /// <summary>
        /// ���� �� ArgumentBuilder.myArguments ��� ������� ������������ ����������
        /// </summary>
        [Fact]
        public void TestArgumentsCreateFourWrongArgs()
        {
            string[] args = new[] { "arg1", "arg2", "arg3", "arg4" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        /// <summary>
        /// ���� �� ArgumentBuilder.myArguments ��� ���� ���������� ���������� (������ Rus)
        /// </summary>
        [Fact]
        public void TestArgumentsCreateTwoCorrectArgsRus()
        {
            string[] args = new[] { "arg1", "RUS"};

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        /// <summary>
        /// ���� �� ArgumentBuilder.myArguments ��� ���� ������������ ���������� (������ Rus)
        /// </summary>
        [Fact]
        public void TestArgumentsCreateThreeCorrectArgsRus()
        {

            string[] args = new[] { "arg1", "RUS", "arg3" };

            ArgumentBuilder builder = new(args);

            Assert.NotNull(builder.myArguments);
            Assert.True(builder.myArguments.Country.Equals("RUS"));
        }

        /// <summary>
        /// ���� �� ArgumentBuilder.myArguments ��� ������� ������������ ���������� (������ Rus)
        /// </summary>
        [Fact]
        public void TestArgumentsCreateFourCorrectArgsRus()
        {
            string[] args = new[] { "arg1", "RUS", "arg3", "arg4" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        /// <summary>
        /// ���� �� ArgumentBuilder.myArguments ��� ���� ���������� ���������� (������ Usa)
        /// </summary>
        [Fact]
        public void TestArgumentsCreateTwoCorrectArgsUsa()
        {
            string[] args = new[] { "arg1", "USA" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }

        /// <summary>
        /// ���� �� ArgumentBuilder.myArguments ��� ���� ���������� ���������� (������ Usa)
        /// </summary>
        [Fact]
        public void TestArgumentsCreateThreeCorrectArgsUsa()
        {

            string[] args = new[] { "arg1", "USA", "arg3" };

            ArgumentBuilder builder = new(args);

            Assert.NotNull(builder.myArguments);
            Assert.True(builder.myArguments.Country.Equals("USA"));
        }

        /// <summary>
        /// ���� �� ArgumentBuilder.myArguments ��� ������� ���������� ���������� (������ Usa)
        /// </summary>
        [Fact]
        public void TestArgumentsCreateFourCorrectArgsUsa()
        {
            string[] args = new[] { "arg1", "USA", "arg3", "arg4" };

            ArgumentBuilder builder = new(args);

            Assert.Null(builder.myArguments);
        }
        #endregion
    }
    #endregion
}