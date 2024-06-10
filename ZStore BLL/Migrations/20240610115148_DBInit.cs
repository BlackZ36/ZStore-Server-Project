using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZStore_BLL.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parent_category_id = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'Default Category Title')"),
                    metaTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'Default Category Meta Title')"),
                    content = table.Column<string>(type: "ntext", nullable: true, defaultValueSql: "(N'Default Category Content')"),
                    slug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'/default-category-slug')"),
                    sku = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'DEFAULTCATEGORY')"),
                    status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    order = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.category_id);
                    table.ForeignKey(
                        name: "FK_Category_ParentCategory",
                        column: x => x.parent_category_id,
                        principalTable: "category",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    permission_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.permission_id);
                });

            migrationBuilder.CreateTable(
                name: "productType",
                columns: table => new
                {
                    product_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'Default Product Type Title')"),
                    metaTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'Default Product Type Meta Title')"),
                    content = table.Column<string>(type: "ntext", nullable: true, defaultValueSql: "(N'Default Product Type Description')"),
                    slug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'/type/default-product-type')"),
                    sku = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'PT')"),
                    order = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productType", x => x.product_type_id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "tokenType",
                columns: table => new
                {
                    token_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "(N'Default Token Type Name')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokenType", x => x.token_type_id);
                });

            migrationBuilder.CreateTable(
                name: "variant",
                columns: table => new
                {
                    variant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'Default Variant Title')"),
                    content = table.Column<string>(type: "ntext", nullable: true, defaultValueSql: "(N'Default Variant Content')"),
                    status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_variant", x => x.variant_id);
                });

            migrationBuilder.CreateTable(
                name: "vendor",
                columns: table => new
                {
                    vendor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'Default Vendor Title')"),
                    content = table.Column<string>(type: "ntext", nullable: true, defaultValueSql: "(N'Default Vendor Description')"),
                    sku = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'VD')"),
                    order = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendor", x => x.vendor_id);
                });

            migrationBuilder.CreateTable(
                name: "voucher",
                columns: table => new
                {
                    voucher_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "(N'VOUCHER-DEFAULT')"),
                    discount = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    expires_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    usage_limit = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    used_count = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voucher", x => x.voucher_id);
                });

            migrationBuilder.CreateTable(
                name: "rolePermission",
                columns: table => new
                {
                    role_permission_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    permission_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolePermission", x => x.role_permission_id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission",
                        column: x => x.permission_id,
                        principalTable: "permission",
                        principalColumn: "permission_id");
                    table.ForeignKey(
                        name: "FK_RolePermission_Role",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "role_id");
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: true),
                    vendor_id = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'Default Product Title')"),
                    metaTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'Default Product Meta Title')"),
                    content = table.Column<string>(type: "ntext", nullable: true, defaultValueSql: "(N'Default Product Description')"),
                    slug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'/product/product')"),
                    sku = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'PRD')"),
                    item_count = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    view_time = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "FK_Product_ProductType",
                        column: x => x.type_id,
                        principalTable: "productType",
                        principalColumn: "product_type_id");
                    table.ForeignKey(
                        name: "FK_Product_Vendor",
                        column: x => x.vendor_id,
                        principalTable: "vendor",
                        principalColumn: "vendor_id");
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'Default Product Item Title')"),
                    metaTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'Default Product Item Meta Title')"),
                    content = table.Column<string>(type: "ntext", nullable: true, defaultValueSql: "(N'Default Product Item Description')"),
                    slug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'/product/product-item')"),
                    sku = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'ITEM')"),
                    status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.item_id);
                    table.ForeignKey(
                        name: "FK_Item_Product",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "itemImage",
                columns: table => new
                {
                    image_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    img_url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__itemImag__DC9AC9552A522A34", x => x.image_id);
                    table.ForeignKey(
                        name: "FK__itemImage__item___7E37BEF6",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "item_id");
                });

            migrationBuilder.CreateTable(
                name: "itemInventory",
                columns: table => new
                {
                    inventory_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    variant_combination = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'0-0')"),
                    quantity = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    discount = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    price = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
                    status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__itemInve__B59ACC49AAA72343", x => x.inventory_id);
                    table.ForeignKey(
                        name: "FK_ItemInventory_Item",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "item_id");
                });

            migrationBuilder.CreateTable(
                name: "ItemVariant",
                columns: table => new
                {
                    item_variant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    variant_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVariant", x => x.item_variant_id);
                    table.ForeignKey(
                        name: "FK_ItemVariant_Item",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "item_id");
                    table.ForeignKey(
                        name: "FK_ItemVariant_Variant",
                        column: x => x.variant_id,
                        principalTable: "variant",
                        principalColumn: "variant_id");
                });

            migrationBuilder.CreateTable(
                name: "variantValue",
                columns: table => new
                {
                    variant_value_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    variant_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "('Default Variant Value')"),
                    img_url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "('https://example.com/product-variant-image.png')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_variantValue", x => x.variant_value_id);
                    table.ForeignKey(
                        name: "FK_VariantValue_Item",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "item_id");
                    table.ForeignKey(
                        name: "FK_VariantValue_Variant",
                        column: x => x.variant_id,
                        principalTable: "variant",
                        principalColumn: "variant_id");
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    password_hash = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    last_login = table.Column<DateTime>(type: "datetime", nullable: true),
                    registered_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    default_address_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.account_id);
                });

            migrationBuilder.CreateTable(
                name: "accountRole",
                columns: table => new
                {
                    account_role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<int>(type: "int", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountRole", x => x.account_role_id);
                    table.ForeignKey(
                        name: "FK_AccountRole_Account",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_AccountRole_Role",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "role_id");
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<int>(type: "int", nullable: true),
                    country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    province = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    district = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ward = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    zip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    detail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_Address_Account",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id");
                });

            migrationBuilder.CreateTable(
                name: "auditLog",
                columns: table => new
                {
                    log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<int>(type: "int", nullable: true),
                    action = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'Default Action')"),
                    entity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'Default Entity')"),
                    entity_id = table.Column<int>(type: "int", nullable: true),
                    content = table.Column<string>(type: "ntext", nullable: true, defaultValueSql: "(N'Default Audit Log Content')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ip_address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'0.0.0.0')"),
                    user_agent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(N'Default Browser')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__auditLog__9E2397E055ED338B", x => x.log_id);
                    table.ForeignKey(
                        name: "FK_AuditLog_Account",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id");
                });

            migrationBuilder.CreateTable(
                name: "refreshToken",
                columns: table => new
                {
                    token_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<int>(type: "int", nullable: true),
                    token = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    expires_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__refreshT__CB3C9E17043E52B5", x => x.token_id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Account",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_RefreshToken_TokenType",
                        column: x => x.type_id,
                        principalTable: "tokenType",
                        principalColumn: "token_type_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_default_address_id",
                table: "account",
                column: "default_address_id");

            migrationBuilder.CreateIndex(
                name: "UQ__account__A32E2E1C0C231681",
                table: "account",
                column: "mobile",
                unique: true,
                filter: "[mobile] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__account__AB6E61643352307C",
                table: "account",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_accountRole_account_id",
                table: "accountRole",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_accountRole_role_id",
                table: "accountRole",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_address_account_id",
                table: "address",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_auditLog_account_id",
                table: "auditLog",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_parent_category_id",
                table: "category",
                column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_product_id",
                table: "item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_itemImage_item_id",
                table: "itemImage",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_itemInventory_item_id",
                table: "itemInventory",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariant_item_id",
                table: "ItemVariant",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariant_variant_id",
                table: "ItemVariant",
                column: "variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_id",
                table: "product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_type_id",
                table: "product",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_vendor_id",
                table: "product",
                column: "vendor_id");

            migrationBuilder.CreateIndex(
                name: "IX_refreshToken_account_id",
                table: "refreshToken",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_refreshToken_type_id",
                table: "refreshToken",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_rolePermission_permission_id",
                table: "rolePermission",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_rolePermission_role_id",
                table: "rolePermission",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_variantValue_item_id",
                table: "variantValue",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_variantValue_variant_id",
                table: "variantValue",
                column: "variant_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Address",
                table: "account",
                column: "default_address_id",
                principalTable: "address",
                principalColumn: "address_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Address",
                table: "account");

            migrationBuilder.DropTable(
                name: "accountRole");

            migrationBuilder.DropTable(
                name: "auditLog");

            migrationBuilder.DropTable(
                name: "itemImage");

            migrationBuilder.DropTable(
                name: "itemInventory");

            migrationBuilder.DropTable(
                name: "ItemVariant");

            migrationBuilder.DropTable(
                name: "refreshToken");

            migrationBuilder.DropTable(
                name: "rolePermission");

            migrationBuilder.DropTable(
                name: "variantValue");

            migrationBuilder.DropTable(
                name: "voucher");

            migrationBuilder.DropTable(
                name: "tokenType");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "variant");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "productType");

            migrationBuilder.DropTable(
                name: "vendor");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "account");
        }
    }
}
