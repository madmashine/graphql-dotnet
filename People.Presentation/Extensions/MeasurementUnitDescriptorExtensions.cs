using HotChocolate.Types;
using People.Business.Responses;

namespace People.Presentation.Extensions
{
    public static class MeasurementUnitDescriptorExtensions
    {
        private const string ArgumentName = "unit";

        public static void AddMeasurementUnitConversionArgument(this IDescriptor descriptor)
        {
            if (descriptor is IObjectFieldDescriptor objectField)
            {
                objectField.Argument(ArgumentName, argumentDescriptor => argumentDescriptor.Type<EnumType<MeasurementUnit>>().DefaultValue(MeasurementUnit.Meters))
                    .Use(next => async middlewareContext =>
                    {
                        await next(middlewareContext).ConfigureAwait(false);

                        if (middlewareContext.Result is double length)
                        {
                            middlewareContext.Result = ConvertToUnit(length, middlewareContext.Argument<MeasurementUnit>(ArgumentName));
                        }
                    });
            }
            else if (descriptor is IInterfaceFieldDescriptor interfaceField)
            {
                interfaceField.Argument(ArgumentName, argumentDescriptor => argumentDescriptor.Type<EnumType<MeasurementUnit>>().DefaultValue(MeasurementUnit.Meters));
            }
        }

        private static double ConvertToUnit(double length, MeasurementUnit measurementUnit)
        {
            if (measurementUnit == MeasurementUnit.Foot)
            {
                return length * 3.28084d;
            }
            return length;
        }
    }
}
