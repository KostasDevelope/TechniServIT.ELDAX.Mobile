using System;
using Telerik.XamarinForms.Common.DataAnnotations;

namespace TechniServIT.ELDAX.Mobile.Attributes
{
    public class NonEmptyValidatorCustomAttribute : NonEmptyValidatorAttribute
    {
        public NonEmptyValidatorCustomAttribute(Type resourceType, string negativeFeedbackResourceKey, string positiveFeedbackResourceKey)
        {
            NegativeFeedback = ResourceHelper.GetResourceLookup(resourceType, negativeFeedbackResourceKey);
            if (string.IsNullOrWhiteSpace(positiveFeedbackResourceKey))
                PositiveFeedback = ResourceHelper.GetResourceLookup(resourceType, positiveFeedbackResourceKey);
        }
    }
}