using System;
using System.Collections.Generic;
using Arqsis.Infrastructure.Results.Errors;

namespace Arqsis.Model.Dimension
{
    public class Dimension
    {
        public int MinHeightInMillimeters { get; set; }
        public int MinWeightInMillimeters { get; set; }
        public int MinDepthInMillimeters { get; set; }
        public int MaxHeightInMillimeters { get; set; }
        public int MaxWeightInMillimeters { get; set; }
        public int MaxDepthInMillimeters { get; set; }

        public Dimension()
        {
            
        }

        public Dimension(int minHeightInMillimeters, int minWeightInMillimeters, int minDepthInMillimeters,
                    int maxHeightInMillimeters, int maxWeightInMillimeters, int maxDepthInMillimeters)
        {
            
            MinHeightInMillimeters = minHeightInMillimeters;
            MinWeightInMillimeters = minWeightInMillimeters;
            MinDepthInMillimeters = minDepthInMillimeters;
            MaxHeightInMillimeters = maxHeightInMillimeters;
            MaxWeightInMillimeters = maxWeightInMillimeters;
            MaxDepthInMillimeters = maxDepthInMillimeters;
        }

        public static List<IError> Valid(int minHeightInMillimeters, int minWeightInMillimeters, int minDepthInMillimeters,
            int maxHeightInMillimeters, int maxWeightInMillimeters, int maxDepthInMillimeters)
        {
            int minimunDimension = 1;
            List<IError> result = new List<IError>();
            
            if (minHeightInMillimeters < minimunDimension)
            {
                result.Add(ErrorFactory.CreateError(ErrorType.DimensionBellowExpected, nameof(minHeightInMillimeters)));
            }
            
            if (minWeightInMillimeters < minimunDimension)
            {
                result.Add(ErrorFactory.CreateError(ErrorType.DimensionBellowExpected, nameof(minWeightInMillimeters)));
            }
            
            if (minDepthInMillimeters < minimunDimension)
            {
                result.Add(ErrorFactory.CreateError(ErrorType.DimensionBellowExpected, nameof(minWeightInMillimeters)));
            }
            
            if (maxHeightInMillimeters < minimunDimension)
            {
                result.Add(ErrorFactory.CreateError(ErrorType.DimensionBellowExpected, nameof(minHeightInMillimeters)));
            }
            
            if (maxWeightInMillimeters < minimunDimension)
            {
                result.Add(ErrorFactory.CreateError(ErrorType.DimensionBellowExpected, nameof(minWeightInMillimeters)));
            }
            
            if (maxDepthInMillimeters < minimunDimension)
            {
                result.Add(ErrorFactory.CreateError(ErrorType.DimensionBellowExpected, nameof(minWeightInMillimeters)));
            }

            if (minDepthInMillimeters > maxDepthInMillimeters)
            {
                result.Add(ErrorFactory.CreateError(ErrorType.DimensionMinIsHigherThanMax, nameof(maxDepthInMillimeters)));
            }
            
            if (minHeightInMillimeters > maxHeightInMillimeters)
            {
                result.Add(ErrorFactory.CreateError(ErrorType.DimensionMinIsHigherThanMax, nameof(maxHeightInMillimeters)));
            }
            
            if (minWeightInMillimeters > maxWeightInMillimeters)
            {
                result.Add(ErrorFactory.CreateError(ErrorType.DimensionMinIsHigherThanMax, nameof(maxWeightInMillimeters)));
            }

            return result;
            }
    }
}