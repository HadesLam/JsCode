using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H.Model
{
    public class Visitor : BaseModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new long Id { get; set; }

        [MaxLength(50)] public string IP { get; set; }
        [MaxLength(50)] public string Country { get; set; }
        [MaxLength(50)] public string ISP { get; set; }
        [MaxLength(1000)] public string JsonStr { get; set; }

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