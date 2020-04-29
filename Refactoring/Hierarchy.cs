using System;
using System.Diagnostics;

namespace Refactor.ValidateHierarchy
{
    public class Hierarchy
    {
        public bool Validate(Line currentLine, Line previousLine, LineConfig ancestorLineConfig, int index, bool previuousValidationIsValid)
        {
            bool isValid = true;

            var previousReadRegisterType = LineType.Row;

            var previousReadRow = previousLine;

            var previousRegisterOrder = currentLine.Order - 1;

            if (previousRegisterOrder > 0)
            {
                var previousRow = ancestorLineConfig;

                if (previousRow != null)
                {
                    if (Enum.IsDefined(typeof(LineType), previousLine.LineType))
                    {
                        if (previousRow.LineType.Equals(previousReadRegisterType))
                        {
                            if (previousReadRow != null)
                            {
                                if (!previousReadRow.RepeatRegistry && !previousReadRow.LineType.Equals(currentLine.LineType) && previousReadRow.LineType != previousRow.LineType && previousRow.Required)
                                {
                                    isValid = false;
                                }
                                else if (!(previousReadRow.RepeatRegistry && previousReadRow.LineType.Equals(currentLine.LineType)))
                                {
                                    isValid = false;
                                }
                                else if (previousReadRow.RepeatRegistry && !previousReadRow.LineType.Equals(currentLine.LineType))
                                {
                                    isValid = false;
                                }
                            }
                        }
                    }
                    else if (previousRow.Required)
                    {
                        isValid = false;
                    }
                }
            }
            else if (currentLine.Order != index && !currentLine.RepeatRegistry)
            {
                isValid = false;
            }
            else if (currentLine.Order != index && currentLine.RepeatRegistry && !previuousValidationIsValid)
            {
                isValid = false;
                Debug.WriteLine("Validation failed");
            }

            if (!isValid)
            {
                //Simulate a log
                Debug.WriteLine("Hierarchy is not valid");
            }

            return isValid;
        }
    }
}