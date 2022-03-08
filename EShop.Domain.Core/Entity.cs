namespace EShop.Domain.Core
{
    public class Entity
    {
        #region Private Fields

        private int? _requestedHashCode;
        private int _id;
        private List<INotification> _domainEvents;
        #endregion Private Fields

        public virtual int Id
        {
            get => _id;
            protected set
            {
                _id = value;
            }
        }

        private EnumStatus _status;
        public EnumStatus Status
        {
            get
            {
                if (_status == null)
                    _status = EnumStatus.GetAll<EnumStatus>().FirstOrDefault(f => f.Id == StatusId);
                return _status;
            }
            protected set => _status = value;
        }

        public int StatusId { get; protected set; }

        public List<INotification> DomainEvents => _domainEvents;

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            if (_domainEvents is null) return;
            _domainEvents.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public bool IsTransient()
        {
            return this.Id == default(Int32);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            Entity item = (Entity)obj;
            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;
                return _requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null));
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        public void CheckRule<T>(AbstractValidator<T> rule)
        {
            T instance = (T)Convert.ChangeType(this, typeof(T));
            var validate = rule.Validate(instance);
            if (!validate.IsValid)
            {
                throw new BusinessRuleValidationException(validate.Errors);
            }
        }
    }
}