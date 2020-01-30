namespace H.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Js_AZData",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        user_account = c.String(maxLength: 50, storeType: "nvarchar"),
                        platform_user_name = c.String(maxLength: 50, storeType: "nvarchar"),
                        platform_seller_id = c.String(maxLength: 50, storeType: "nvarchar"),
                        refrence_no_platform = c.String(maxLength: 50, storeType: "nvarchar"),
                        refrence_no = c.String(maxLength: 50, storeType: "nvarchar"),
                        order_status = c.String(maxLength: 50, storeType: "nvarchar"),
                        date_latest_ship = c.DateTime(nullable: false, precision: 0),
                        mark_content = c.String(maxLength: 50, storeType: "nvarchar"),
                        markding_time = c.String(maxLength: 50, storeType: "nvarchar"),
                        refrence_no_warehouse = c.String(maxLength: 50, storeType: "nvarchar"),
                        warehouse_code = c.String(maxLength: 50, storeType: "nvarchar"),
                        warehouse_name = c.String(maxLength: 50, storeType: "nvarchar"),
                        shipping_method_platform = c.String(maxLength: 50, storeType: "nvarchar"),
                        shipping_method_code = c.String(maxLength: 50, storeType: "nvarchar"),
                        shipping_method_name_cn = c.String(maxLength: 50, storeType: "nvarchar"),
                        shipping_method_name_en = c.String(maxLength: 50, storeType: "nvarchar"),
                        tracking_number = c.String(maxLength: 50, storeType: "nvarchar"),
                        service_number = c.String(maxLength: 50, storeType: "nvarchar"),
                        system_note = c.String(maxLength: 50, storeType: "nvarchar"),
                        operator_note = c.String(maxLength: 50, storeType: "nvarchar"),
                        platform_buyer_id = c.String(maxLength: 50, storeType: "nvarchar"),
                        buyer_id = c.String(maxLength: 50, storeType: "nvarchar"),
                        buyer_name = c.String(maxLength: 50, storeType: "nvarchar"),
                        consignee_name = c.String(maxLength: 50, storeType: "nvarchar"),
                        consignee_country_code = c.String(maxLength: 50, storeType: "nvarchar"),
                        consignee_country_name = c.String(maxLength: 50, storeType: "nvarchar"),
                        consignee_province = c.String(maxLength: 50, storeType: "nvarchar"),
                        consignee_city = c.String(maxLength: 50, storeType: "nvarchar"),
                        consignee_street = c.String(maxLength: 50, storeType: "nvarchar"),
                        consignee_zip = c.String(maxLength: 50, storeType: "nvarchar"),
                        doorplate = c.String(maxLength: 50, storeType: "nvarchar"),
                        company_name = c.String(maxLength: 50, storeType: "nvarchar"),
                        consignee_email = c.String(maxLength: 50, storeType: "nvarchar"),
                        consignee_phone = c.String(maxLength: 50, storeType: "nvarchar"),
                        order_desc = c.String(maxLength: 50, storeType: "nvarchar"),
                        amountpaid = c.Double(nullable: false),
                        subtotal = c.Double(nullable: false),
                        ship_fee = c.Double(nullable: false),
                        platform_fee = c.Double(nullable: false),
                        finalvaluefee = c.Double(nullable: false),
                        already_paid = c.Double(nullable: false),
                        currency = c.String(maxLength: 50, storeType: "nvarchar"),
                        final_value_fee_currency = c.String(maxLength: 50, storeType: "nvarchar"),
                        date_paid_platform = c.DateTime(nullable: false, precision: 0),
                        date_create_platform = c.DateTime(nullable: false, precision: 0),
                        date_release = c.DateTime(nullable: false, precision: 0),
                        date_warehouse_shipping = c.DateTime(nullable: false, precision: 0),
                        payment_detail = c.String(maxLength: 50, storeType: "nvarchar"),
                        receiving_account = c.String(maxLength: 50, storeType: "nvarchar"),
                        order_weight = c.Double(nullable: false),
                        order_weight_g = c.Double(nullable: false),
                        cost_ship_fee = c.Double(nullable: false),
                        cost_ship_fee_currency = c.String(maxLength: 50, storeType: "nvarchar"),
                        shop_paypal_account = c.String(maxLength: 50, storeType: "nvarchar"),
                        paypal_account = c.String(maxLength: 50, storeType: "nvarchar"),
                        paypal_transaction_id = c.String(maxLength: 50, storeType: "nvarchar"),
                        ebay_record_no = c.String(maxLength: 50, storeType: "nvarchar"),
                        product_types = c.String(maxLength: 50, storeType: "nvarchar"),
                        warning_letter = c.String(maxLength: 50, storeType: "nvarchar"),
                        return_order = c.String(maxLength: 50, storeType: "nvarchar"),
                        order_sn_org = c.String(maxLength: 50, storeType: "nvarchar"),
                        sku = c.String(maxLength: 50, storeType: "nvarchar"),
                        remark = c.String(maxLength: 50, storeType: "nvarchar"),
                        warehouse_sku = c.String(maxLength: 50, storeType: "nvarchar"),
                        eta_data = c.String(maxLength: 50, storeType: "nvarchar"),
                        product_category = c.String(maxLength: 50, storeType: "nvarchar"),
                        product_title = c.String(maxLength: 500, storeType: "nvarchar"),
                        warehouse_product_title = c.String(maxLength: 50, storeType: "nvarchar"),
                        qty = c.String(maxLength: 50, storeType: "nvarchar"),
                        unit_price = c.String(maxLength: 50, storeType: "nvarchar"),
                        record_no = c.String(maxLength: 50, storeType: "nvarchar"),
                        item_id = c.String(maxLength: 50, storeType: "nvarchar"),
                        transaction_id = c.String(maxLength: 50, storeType: "nvarchar"),
                        product_weight = c.Double(nullable: false),
                        oversea_type = c.String(maxLength: 50, storeType: "nvarchar"),
                        declare_price = c.Double(nullable: false),
                        paypal_fee = c.Double(nullable: false),
                        op_quantity = c.Double(nullable: false),
                        pcr_product_sku = c.String(maxLength: 50, storeType: "nvarchar"),
                        properties = c.String(maxLength: 50, storeType: "nvarchar"),
                        optime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Js_AZData");
        }
    }
}
