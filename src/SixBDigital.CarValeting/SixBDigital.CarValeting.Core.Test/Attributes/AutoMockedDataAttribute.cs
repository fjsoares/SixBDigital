using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Kernel;
using AutoFixture.Xunit2;
using Xunit;

namespace SixBDigital.CarValeting.Core.Test.Attributes
{
    public class AutoMockedDataAttribute : AutoDataAttribute
    {
        public AutoMockedDataAttribute()
            : base(CustomizeFixture)
        { }

        private static IFixture CustomizeFixture()
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoNSubstituteCustomization { ConfigureMembers = true });
            
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(2));

            return fixture;
        }
    }

    public class InlineAutoMockedDataAttribute : CompositeDataAttribute
    {
        public InlineAutoMockedDataAttribute()
            : this(new AutoMockedDataAttribute())
        { }

        public InlineAutoMockedDataAttribute(params object[] values)
            : this(new AutoMockedDataAttribute(), values)
        { }

        public InlineAutoMockedDataAttribute(AutoMockedDataAttribute autoDataAttributeAttribute, params object[] values)
            : base(new InlineDataAttribute(values), autoDataAttributeAttribute)
        { }
    }

    public class GenerationDepthBehavior : ISpecimenBuilderTransformation
    {
        public int Depth { get; }

        public GenerationDepthBehavior(int depth)
        {
            Depth = depth;
        }

        public ISpecimenBuilderNode Transform(ISpecimenBuilder builder)
        {
            return new RecursionGuard(builder, new OmitOnRecursionHandler(), new IsSeededRequestComparer(), Depth);
        }

        private class IsSeededRequestComparer : IEqualityComparer
        {
            bool IEqualityComparer.Equals(object x, object y)
            {
                return x is SeededRequest && y is SeededRequest;
            }

            int IEqualityComparer.GetHashCode(object obj)
            {
                return obj is SeededRequest ? 0 : EqualityComparer<object>.Default.GetHashCode(obj);
            }
        }
    }
}
