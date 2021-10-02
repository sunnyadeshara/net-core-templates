using System;

namespace CleanArchitectureTemplate.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
