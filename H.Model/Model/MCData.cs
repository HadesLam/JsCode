using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H.Model
{
    public class MCData : BaseModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new long Id { get; set; }

        [MaxLength(255)] public string buyer_email { get; set; }
        [MaxLength(255)] public string buyer_orderno { get; set; }
        [MaxLength(1000)] public string buyer_customer_reviews { get; set; }
        public int IsQueryOK { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        private DateTime? _optime;
        public DateTime optime
        {
            get
            {
                if (_optime == null)
                {
                    _optime = DateTime.Now;
                }
                return _optime.Value;
            }
            set { _optime = value; }
        }
    }
}
