using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H.Model
{
    public class Setting : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new long Id { get; set; }

        [MaxLength(255)] public string name { get; set; }
        [MaxLength(255)] public string value { get; set; }
        [MaxLength(255)] public string control { get; set; }

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
