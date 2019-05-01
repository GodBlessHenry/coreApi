using System;

namespace Catalog.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public int RecordStatus { get; set; }
        public BaseEntity() { RecordStatus = 1; }

        /// <summary>
        /// Handler - Determine if the record was omitted
        /// </summary>
        public bool IsOmitted()
        {
            return !Convert.ToBoolean(RecordStatus);
        }

        /// <summary>
        /// Handler - Performs a soft delete of the record.
        /// </summary>
        public void Omit()
        {
            RecordStatus = 0;
        }

        /// <summary>
        /// Handler - Restore the record.
        /// </summary>
        public void Restore()
        {
            RecordStatus = 1;
        }
    }
}
