using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H.Model
{
    public class AZData : BaseModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new long Id { get; set; }
        [MaxLength(50)] public string user_account { get; set; }
        [MaxLength(50)] public string platform_user_name { get; set; }
        [MaxLength(50)] public string platform_seller_id { get; set; }
        [MaxLength(50)] public string refrence_no_platform { get; set; }
        [MaxLength(50)] public string refrence_no { get; set; }
        [MaxLength(50)] public string order_status { get; set; }
        public DateTime date_latest_ship { get; set; }
        [MaxLength(50)] public string mark_content { get; set; }
        [MaxLength(50)] public string markding_time { get; set; }
        [MaxLength(50)] public string refrence_no_warehouse { get; set; }
        [MaxLength(50)] public string warehouse_code { get; set; }
        [MaxLength(50)] public string warehouse_name { get; set; }
        [MaxLength(50)] public string shipping_method_platform { get; set; }
        [MaxLength(50)] public string shipping_method_code { get; set; }
        [MaxLength(50)] public string shipping_method_name_cn { get; set; }
        [MaxLength(50)] public string shipping_method_name_en { get; set; }
        [MaxLength(50)] public string tracking_number { get; set; }
        [MaxLength(50)] public string service_number { get; set; }
        [MaxLength(50)] public string system_note { get; set; }
        [MaxLength(50)] public string operator_note { get; set; }
        [MaxLength(50)] public string platform_buyer_id { get; set; }
        [MaxLength(50)] public string buyer_id { get; set; }
        [MaxLength(50)] public string buyer_name { get; set; }
        [MaxLength(50)] public string consignee_name { get; set; }
        [MaxLength(50)] public string consignee_country_code { get; set; }
        [MaxLength(50)] public string consignee_country_name { get; set; }
        [MaxLength(50)] public string consignee_province { get; set; }
        [MaxLength(50)] public string consignee_city { get; set; }
        [MaxLength(50)] public string consignee_street { get; set; }
        [MaxLength(50)] public string consignee_zip { get; set; }
        [MaxLength(50)] public string doorplate { get; set; }
        [MaxLength(50)] public string company_name { get; set; }
        [MaxLength(50)] public string consignee_email { get; set; }
        [MaxLength(50)] public string consignee_phone { get; set; }
        [MaxLength(50)] public string order_desc { get; set; }
        public double amountpaid { get; set; }
        public double subtotal { get; set; }
        public double ship_fee { get; set; }
        public double platform_fee { get; set; }
        public double finalvaluefee { get; set; }
        public double already_paid { get; set; }
        [MaxLength(50)] public string currency { get; set; }
        [MaxLength(50)] public string final_value_fee_currency { get; set; }
        public DateTime date_paid_platform { get; set; }
        public DateTime date_create_platform { get; set; }
        public DateTime date_release { get; set; }
        public DateTime date_warehouse_shipping { get; set; }
        [MaxLength(50)] public string payment_detail { get; set; }
        [MaxLength(50)] public string receiving_account { get; set; }
        public double order_weight { get; set; }
        public double order_weight_g { get; set; }
        public double cost_ship_fee { get; set; }
        [MaxLength(50)] public string cost_ship_fee_currency { get; set; }
        [MaxLength(50)] public string shop_paypal_account { get; set; }
        [MaxLength(50)] public string paypal_account { get; set; }
        [MaxLength(50)] public string paypal_transaction_id { get; set; }
        [MaxLength(50)] public string ebay_record_no { get; set; }
        [MaxLength(50)] public string product_types { get; set; }
        [MaxLength(50)] public string warning_letter { get; set; }
        [MaxLength(50)] public string return_order { get; set; }
        [MaxLength(50)] public string order_sn_org { get; set; }
        [MaxLength(50)] public string sku { get; set; }
        [MaxLength(50)] public string remark { get; set; }
        [MaxLength(50)] public string warehouse_sku { get; set; }
        [MaxLength(50)] public string eta_data { get; set; }
        [MaxLength(50)] public string product_category { get; set; }
        [MaxLength(500)] public string product_title { get; set; }
        [MaxLength(50)] public string warehouse_product_title { get; set; }
        public double qty { get; set; }
        public double unit_price { get; set; }
        [MaxLength(50)] public string record_no { get; set; }
        [MaxLength(50)] public string item_id { get; set; }
        [MaxLength(50)] public string transaction_id { get; set; }
        public double product_weight { get; set; }
        [MaxLength(50)] public string oversea_type { get; set; }
        public double declare_price { get; set; }
        public double paypal_fee { get; set; }
        public double op_quantity { get; set; }
        [MaxLength(50)] public string pcr_product_sku { get; set; }
        [MaxLength(50)] public string properties { get; set; }

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