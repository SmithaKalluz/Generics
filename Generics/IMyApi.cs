using System.Collections.Generic;


namespace Generics
{
    interface IMyApi
    {
        IList<int> GetReadOnlyValues();
    }

    public class MyApiImplementation : IMyApi
    {
        public IList<int> GetReadOnlyValues()
        {
            List<int> myList = new List<int> {1, 2, 3};
            return myList.AsReadOnly();
        }
    }

    public class MyMockApiImplementationForUnitTests : IMyApi
    {
        public IList<int> GetReadOnlyValues()
        {
            // array
            IList<int> testValues = new int[] { 1, 2, 3 };
            return testValues;
        }
    }
}
