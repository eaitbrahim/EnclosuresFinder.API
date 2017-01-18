using EnclosuresFinder.Data.Abstract;
using EnclosuresFinder.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EnclosuresFinder.Data
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T o);

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }
        
    }

    public class AndSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> leftSpecification;
        ISpecification<T> rightSpecification;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.leftSpecification = left;
            this.rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return this.leftSpecification.IsSatisfiedBy(o)
                && this.rightSpecification.IsSatisfiedBy(o);
        }
    }

    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private Func<T, bool> expression;
        public ExpressionSpecification(Func<T, bool> expression)
        {
            if (expression == null)
                throw new ArgumentNullException();
            else
                this.expression = expression;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return this.expression(o);
        }
    }
}
