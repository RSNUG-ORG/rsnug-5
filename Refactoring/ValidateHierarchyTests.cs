using System;
using Xunit;

namespace Refactor.ValidateHierarchy
{
    public class ValidateHierarchyTests
    {
        [Theory]
        [InlineData(1, true, null, 1, null, false)]
        [InlineData(1, true, null, 1, null, true)]
        //[InlineData(1, true, null, 2, null, false)]
        [InlineData(1, true, null, 2, null, true)]
        [InlineData(1, false, null, 1, null, false)]
        [InlineData(1, false, null, 1, null, true)]
        //[InlineData(1, false, null, 2, null, false)]
        //[InlineData(1, false, null, 2, null, true)]
        public void PreviousRegisterOrderLessThan1Valid(
            int cOrder, bool cRepeat, Line previousLine, int index, LineConfig ancestorLineConfig, bool isPreviousValid
            )
        {
            Hierarchy validate = new Hierarchy();

            Line currentLine = new Line
            {
                Order = cOrder,
                RepeatRegistry = cRepeat
            };

            bool IsValid = validate.Validate(currentLine, previousLine, ancestorLineConfig, index, isPreviousValid);
            Assert.True(IsValid);
        }

        [Theory]
        //[InlineData(1, true, null, 1, null, false)]
        //[InlineData(1, true, null, 1, null, true)]
        [InlineData(1, true, null, 2, null, false)]
        //[InlineData(1, true, null, 2, null, true)]
        //[InlineData(1, false, null, 1, null, false)]
        //[InlineData(1, false, null, 1, null, true)]
        [InlineData(1, false, null, 2, null, false)]
        [InlineData(1, false, null, 2, null, true)]
        public void PreviousRegisterOrderLessThan1Invalid(
            int cOrder, bool cRepeat, Line previousLine, int index, LineConfig ancestorLineConfig, bool isPreviousValid
        )
        {
            Hierarchy validate = new Hierarchy();
            Line currentLine = new Line
            {
                Order = cOrder,
                RepeatRegistry = cRepeat
            };

            bool IsValid = validate.Validate(currentLine, previousLine, ancestorLineConfig, index, isPreviousValid);
            Assert.False(IsValid);
        }

    }
}
