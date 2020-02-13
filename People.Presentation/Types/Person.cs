using HotChocolate.Types;
using People.Presentation.Extensions;

namespace People.Presentation.Types
{
    public class Person :
        ObjectType<Business.Responses.Person>
    {
        protected override void Configure(IObjectTypeDescriptor<Business.Responses.Person> descriptor)
        {
            descriptor.Field(propertyDescriptor => propertyDescriptor.FirstName)
                .Description("First name");
            descriptor.Field(propertyDescriptor => propertyDescriptor.LastName)
                .Description("Last name");
            descriptor.Field(propertyDescriptor => propertyDescriptor.Height)
                .Description("Height with configurable measurement unit")
                .AddMeasurementUnitConversionArgument();

            base.Configure(descriptor);
        }
    }
}
