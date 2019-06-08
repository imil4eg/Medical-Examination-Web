using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimpleMapper
{
    public sealed class Mapper
    {
        public static TDestination Map<TSource, TDestination>(TSource sourceModel) where TDestination : new()
        {
            var destinationModel = new TDestination();

            Dictionary<string, PropertyInfo> properties = sourceModel.GetType().GetProperties()
                .ToDictionary(p => p.Name);

            foreach (var destinationProperty in destinationModel.GetType().GetProperties())
            {
                PropertyInfo sourcePropertyInfo;
                if (!properties.TryGetValue(destinationProperty.Name, out sourcePropertyInfo))
                    continue;

                var convertedToPropertyTypeValue = ValueConverter.Convert(destinationProperty.PropertyType,
                    sourcePropertyInfo.GetValue(sourceModel));

                if(convertedToPropertyTypeValue == null)
                    continue;

                destinationProperty.SetValue(destinationModel, convertedToPropertyTypeValue);
            }

            return (TDestination)destinationModel;
        }

        public static TDestination Map<TSource, TDestination>(TSource sourceModel, TDestination destinationModel)
            where TDestination : new()
        {
            Dictionary<string, PropertyInfo> properties = sourceModel.GetType().GetProperties()
                .ToDictionary(p => p.Name);

            foreach (var destinationProperty in destinationModel.GetType().GetProperties())
            {
                PropertyInfo sourcePropertyInfo;
                if (!properties.TryGetValue(destinationProperty.Name, out sourcePropertyInfo))
                    continue;

                var convertedToPropertyTypeValue = ValueConverter.Convert(destinationProperty.PropertyType,
                    sourcePropertyInfo.GetValue(sourceModel));

                if (convertedToPropertyTypeValue == null)
                    continue;

                destinationProperty.SetValue(destinationModel, convertedToPropertyTypeValue);
            }

            return (TDestination)destinationModel;
        }
    }
}
