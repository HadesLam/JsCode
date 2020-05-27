using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H.Model
{
    public class KSData : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new long Id { get; set; }

        [MaxLength(255)] public string modelCode { get; set; }

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
