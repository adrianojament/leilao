using System;
using System.ComponentModel.DataAnnotations;

namespace Leilao.Domain.Entities.Standard
{
    public class BaseEntity
    {
        DateTime? _CreateAt;
        DateTime? _UpdateAt;

        [Key]
        public Guid Id { get; set; }

        public DateTime? UpdateAt
        {
            get
            {
                if (_UpdateAt == null)
                {
                    _UpdateAt = DateTime.UtcNow;
                }
                return _UpdateAt;
            }
            set => _UpdateAt = value;
        }
        public DateTime? CreateAt
        {
            get
            {
                if (_CreateAt == null)
                {
                    _CreateAt = DateTime.UtcNow;
                }
                return _CreateAt;
            }
            set => _CreateAt = value;
        }
    }
}
