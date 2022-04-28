using System;
using System.Collections.Generic;
using System.Text;
using Telerik.XamarinForms.Common.DataAnnotations;

namespace TechniServIT.ELDAX.Mobile.Attributes
{
   public class StringLengthValidatorCustomAttribute : StringLengthValidatorAttribute
    {
        public StringLengthValidatorCustomAttribute(int minLength, int maxLength) : base(minLength, maxLength)
        { }
        public StringLengthValidatorCustomAttribute(int minLength, int maxLength, Type resourceType, string negativeFeedbackResourceKey, string positiveFeedbackResourceKey) : base(minLength, maxLength)
        {
            NegativeFeedback = ResourceHelper.GetResourceLookup(resourceType, negativeFeedbackResourceKey);
            if (string.IsNullOrWhiteSpace(positiveFeedbackResourceKey))
                PositiveFeedback = ResourceHelper.GetResourceLookup(resourceType, positiveFeedbackResourceKey);
        }
        
    }
}
