using System;

namespace yourNamespace
{
    /// <summary>
    /// Represents a range of integers with an upper and lower limit.
    /// </summary>
    class IntRange
    {
        private (int low, int high) rangeLH;
        private string invalidLimitsMessage = "Lower limit must be less than upper limit";

        /// <summary>
        /// Initializes a new instance of the IntRange class with lower limit l, and upper limit h.
        /// </summary>
        /// <remarks><b>Note:</b> The lower limit must be less than the upper limit</remarks>
        /// <param name="l">The lower limit of the range</param>
        /// <param name="h">The upper limit of the range</param>
        /// <exception cref="ArgumentException"></exception>
        public IntRange(int l, int h)
        {
            if(l < h)
            {
                rangeLH = (l, h);
            }
            else
            {
                throw new ArgumentException(invalidLimitsMessage);
            }
        }

        /// <summary>
        /// Replaces the lower limit of the instance with the new value provided.
        /// </summary>
        /// <remarks><b>Note:</b> The new lower limit must be less than the existing upper limit</remarks>
        /// <param name="val">The new lower limit to use</param>
        /// <exception cref="ArgumentException"></exception>
        public void startAt(int val)
        {
            if(val < rangeLH.high)
            {
                rangeLH.low = val;
            }
            else
            {
                throw new ArgumentException(invalidLimitsMessage);
            }
        }

        /// <summary>
        /// Replaces the upper limit of the instance with the new value provided.
        /// </summary>
        /// <remarks><b>Note:</b> The new upper limit must be greater than the existing lower limit</remarks>
        /// <param name="val">The new upper limit to use</param>
        /// <exception cref="ArgumentException"></exception>
        public void endAt(int val)
        {
            if (val > rangeLH.high)
            {
                rangeLH.high = val;
            }
            else
            {
                throw new ArgumentException(invalidLimitsMessage);
            }
        }

        /// <summary>
        /// Determines if the provided value is within the range, inclusively. 
        /// </summary>
        /// <param name="val">The value to check</param>
        /// <returns>True if in range, false otherwise</returns>
        public bool isInRangeInclusive(int val)
        {
            return rangeLH.low <= val && val <= rangeLH.high;
        }


        /// <summary>
        /// Determines if the provided value is within the range, exclusively. 
        /// </summary>
        /// <param name="val">The value to check</param>
        /// <returns>True if in range, false otherwise</returns>
        public bool isInRangeExclusive(int val)
        {
            return rangeLH.low < val && val < rangeLH.high;
        }

        /// <summary>
        /// Determines the size of the range, including the limit values.
        /// </summary>
        /// <returns>The integer size of the range, inclusively.</returns>
        public int getSizeInclusive()
        {
            return rangeLH.high - rangeLH.low + 1;
        }

        /// <summary>
        /// Determines the size of the range, excluding the limit values.
        /// </summary>
        /// <returns>The integer size of the range, exclusively.</returns>
        public int getSizeExclusive()
        {
            return rangeLH.high - rangeLH.low - 1;
        }

        /// <summary>
        /// Runs a callback delegate if the testValue is within the current range, inclusively.
        /// </summary>
        /// <param name="callback">A function delegate to be called if the value is in range</param>
        /// <param name="testValue">The value to test</param>
        /// <param name="errorMsg">The message to use in the exception if the value is not in range</param>
        /// <exception cref="ArgumentException"></exception>
        public void runIfInRange(Action callback, int testValue,  string errorMsg)
        {
            if (this.isInRangeInclusive(testValue))
            {
                callback();
            }
            else
            {
                throw new ArgumentException(errorMsg);
            }
        }

        /// <summary>
        /// Runs a callback delegate if the testValue is within the current range, inclusively, and passes the method's return on.
        /// </summary>
        /// <param name="callback">A function delegate to be called if the value is in range, which must return a value</param>
        /// <param name="testValue">The value to test</param>
        /// <param name="errorMsg">The message to use in the exception if the value is not in range</param>
        /// <returns>Passes the callback delegate's return value on</returns>
        /// <exception cref="ArgumentException"></exception>
        public dynamic runIfInRangeAndReturn(Func<dynamic> callback, int testValue, string errorMsg)
        {
            if (this.isInRangeInclusive(testValue))
            {
                return callback();
            }
            else
            {
                throw new ArgumentException(errorMsg);
            }
        }
    }
}
