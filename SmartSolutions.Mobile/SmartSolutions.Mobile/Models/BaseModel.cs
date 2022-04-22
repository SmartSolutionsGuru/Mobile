using System;

namespace SmartSolutions.Mobile.Models
{
    public class BaseModel
    {
        #region [Constructor]
        public BaseModel()
        {

        }
        #endregion

        #region [Properties]
        public int Id { get; set; }
        public string Name { get; set; }

        private DateTime? createdAt;

        public DateTime CreatedAt
        {
            get { return createdAt ?? DateTime.UtcNow; }
            set { createdAt = value; }
        }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public byte[] Version { get; set; }
        #endregion
    }
}
