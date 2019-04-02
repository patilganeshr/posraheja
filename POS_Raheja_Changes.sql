
use POS_Raheja_Dev

alter table outwards add location_id int
go

alter table pkg_slip_items
add goods_receipt_item_id	int
go

alter table pkg_slips
add from_location_id int
go

alter table pkg_slips
add type_of_transfer nvarchar(50)
go

alter table clients alter column client_name nvarchar(100)
go

alter table client_addressess alter column client_address_name nvarchar(100)
go

exec sp_rename 'role_permissions.rowguid', 'row_guid'

alter table role_permissions add constraint [DF_role_permissions_row_guid] default(newid()) for[row_guid]
go

alter table items add is_set bit
go

alter table items add constraint [DF_items_is_set] default(0) for[is_set]
go

create table item_sets_sub_items
(
item_set_sub_item_id		int	identity(1,1)	not null,
item_id						int	not null,
sub_item_id					int	not null,
sub_item_net_qty			int	not null,
is_deleted					bit	not null,
created_by					int	not null,
created_by_ip				nvarchar(25) not null,
created_datetime			datetime	not null,
modified_by					int	null,
modified_by_ip				nvarchar(25)	null,
modified_datetime			datetime	null,
deleted_by					int	null,
deleted_by_ip				nvarchar(25)	null,
deleted_datetime			datetime	null,
row_guid					uniqueidentifier	not null,
constraint [pk_item_sets_sub_items_item_set_sub_item_id] primary key clustered
	(
		[item_set_sub_item_id] ASC 
	)
) ON [PRIMARY]
GO

alter table dbo.item_sets_sub_items add constraint [DF_item_sets_sub_items_is_deleted] default(0) for[is_deleted]
go

alter table dbo.item_sets_sub_items add constraint [DF_item_sets_sub_items_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.item_sets_sub_items add constraint [DF_item_sets_sub_items_row_guid] default(newid()) for[row_guid]
go

create table type_of_transfers
(
type_of_transfer_id	int	identity(1,1) not null,
transfer_type		nvarchar(200)	not null,
is_deleted			bit	not null,
created_by			int	not null,
created_by_ip		nvarchar(25) not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime	null,
deleted_by			int	null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime	null,
row_guid			uniqueidentifier	not null,
constraint [pk_type_of_transfers_type_of_transfer_id] primary key clustered
	(
		[type_of_transfer_id] ASC 
	)
) ON [PRIMARY]
GO

alter table dbo.type_of_transfers add constraint [DF_type_of_transfers_is_deleted] default(0) for[is_deleted]
go

alter table dbo.type_of_transfers add constraint [DF_type_of_transfers_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.type_of_transfers add constraint [DF_type_of_transfers_row_guid] default(newid()) for[row_guid]
go

insert into dbo.type_of_transfers
(transer_type, created_by, created_by_ip)
values
('Stock Transfer', 1, '::1'),
('Job Work', 1, '::1')

exec sp_rename 'pkg_slips.type_of_transfer', 'type_of_transfer_id','column'

alter table dbo.client_addressess alter column area nvarchar(50)
go

alter table purchase_bill_items
add 
type_of_discount nvarchar(25),
cash_discount_percent decimal(18,2),
discount_amount decimal(18,2)
go

alter table purchase_bills
add is_tax_round_off	bit
go

alter table purchase_bills add constraint [DF_purchase_bills_is_tax_round_off] default(0) for[is_tax_round_off]
go

alter table sales_bills_items
add goods_receipt_item_id int null,
rate_adjustment	nvarchar(5) null,
rate_adjustment_remarks nvarchar(500) null
go

CREATE TABLE sales_bills_delivery_details
(
sales_bill_delivery_id	int	identity(1,1)	not null,
sales_bill_id	int	not null,
transporter_id int not null,
lr_no	nvarchar(25) not null,
lr_date	date not null,
delivery_date date not null,
is_delivery_pending	bit not null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_sales_bills_delivery_details_sales_bill_delivery_id] primary key clustered
	(
		[sales_bill_delivery_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.sales_bills_delivery_details add constraint [DF_sales_bills_delivery_details_is_delivery_pending] default(0) for[is_delivery_pending]
go

alter table dbo.sales_bills_delivery_details add constraint [DF_sales_bills_delivery_details_is_deleted] default(0) for[is_deleted]
go

alter table dbo.sales_bills_delivery_details add constraint [DF_sales_bills_delivery_details_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.sales_bills_delivery_details add constraint [DF_sales_bills_delivery_details_row_guid] default(newid()) for[row_guid]
go

create table sales_bills_payment_details
(
sales_bill_payment_id	int	identity(1,1)	not null,
sales_bill_id	int	not null,
payment_settelment_id	int not null,
mode_of_payment_id	int not null,
payment_reference_no	nvarchar(50) null,
remarks	nvarchar(500) null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_sales_bills_payment_details_sales_bill_payment_id] primary key clustered
	(
		[sales_bill_payment_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.sales_bills_payment_details add constraint [DF_sales_bills_payment_details_is_deleted] default(0) for[is_deleted]
go

alter table dbo.sales_bills_payment_details add constraint [DF_sales_bills_payment_details_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.sales_bills_payment_details add constraint [DF_sales_bills_payment_details_row_guid] default(newid()) for[row_guid]
go

create table mode_of_payments
(
mode_of_payment_id	int	identity(1,1) not null,
mode_of_payment		nvarchar(25) not null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_mode_of_payments_mode_of_payment_id] primary key clustered
	(
		[mode_of_payment_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.mode_of_payments add constraint [DF_mode_of_payemnts_is_deleted] default(0) for[is_deleted]
go

alter table dbo.mode_of_payments add constraint [DF_mode_of_payemnts_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.mode_of_payments add constraint [DF_mode_of_payemnts_row_guid] default(newid()) for[row_guid]
go

insert into dbo.mode_of_payments 
(mode_of_payment, is_deleted, created_by, created_by_ip)
values
('Cash', 0, 1, '::1'),
('Cheque', 0, 1, '::1'),
('Credit Card', 0, 1, '::1'),
('NEFT/RTGS', 0, 1, '::1'),
('Other', 0, 1, '::1')

create table payment_settlement
(
payment_settlement_id	int identity(1,1)	not null,
payment_settlement	nvarchar(25)	not null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_payment_settelment_payment_settlement_id] primary key clustered
	(
		[payment_settlement_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.payment_settlement add constraint [DF_payment_settlement_is_deleted] default(0) for[is_deleted]
go

alter table dbo.payment_settlement add constraint [DF_payment_settlement_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.payment_settlement add constraint [DF_payment_settlement_row_guid] default(newid()) for[row_guid]
go

insert into dbo.payment_settlement
(payment_settlement, is_deleted, created_by, created_by_ip)
values
('Full Payment', 0, 1, '::1'),
('Part Payment', 0, 1, '::1')

create table charges
(
charge_id		int identity(1,1)	not null,
charge_name		nvarchar(200)	not null,
charge_desc		nvarchar(200)	not null,
gst_category_id	int	not null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_charges_charge_id] primary key clustered
	(
		[charge_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.charges add constraint [DF_charges_is_deleted] default(0) for[is_deleted]
go

alter table dbo.charges add constraint [DF_charges_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.charges add constraint [DF_charges_row_guid] default(newid()) for[row_guid]
go

create table sales_bills_charges_details
(
sales_bill_charge_id	int identity(1,1)	not null,
sales_bill_id		int	 not null,
charge_id			int	 not null,
charge_amount		decimal(18,2)	not null,
is_tax_inclusive		bit not null
gst_rate_id			int		not null,
tax_id				int		not null,
remarks				nvarchar(500) null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_sales_bills_charges_details_sales_bill_charge_id] primary key clustered
	(
		[sales_bill_charge_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.sales_bills_charges_details add constraint [DF_sales_bills_charges_details_is_deleted] default(0) for[is_deleted]
go

alter table dbo.sales_bills_charges_details add constraint [DF_sales_bills_charges_details_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.sales_bills_charges_details add constraint [DF_sales_bills_charges_details_row_guid] default(newid()) for[row_guid]
go

alter table dbo.sales_bills_charges_details add constraint [DF_sales_bills_charges_details_is_tax_inclusive] default(0) for[is_tax_inclusive]
go

create table sales_bills_items_charges_details
(
sales_bill_item_charge_id	int identity(1,1)	not null,
sales_bill_item_id		int	 not null,
charge_id			int	 not null,
charge_amount		decimal(18,2)	not null,
is_tax_inclusive		bit not null
gst_rate_id			int		not null,
tax_id				int		not null,
remarks				nvarchar(500) null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_sales_bills_items_charges_details_sales_bill_item_charge_id] primary key clustered
	(
		[sales_bill_item_charge_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.sales_bills_items_charges_details add constraint [DF_sales_bills_items_charges_details_is_tax_inclusive] default(0) for[is_tax_inclusive]
go

alter table dbo.sales_bills_items_charges_details add constraint [DF_sales_bills_items_charges_details_is_deleted] default(0) for[is_deleted]
go

alter table dbo.sales_bills_items_charges_details add constraint [DF_sales_bills_items_charges_details_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.sales_bills_items_charges_details add constraint [DF_sales_bills_items_charges_details_row_guid] default(newid()) for[row_guid]
go

alter table dbo.sales_bills add remarks nvarchar(500) null
go

alter table dbo.sales_bills_delivery_details add remarks nvarchar(500) null
go

alter table dbo.sales_bills_items add remarks nvarchar(500) null
go

-- -- NEW CHANGES FROM 02/FEB/2018

alter table dbo.outward_goods_details add goods_receipt_item_id	int not null
go

create table inwards
(
inward_id			int		identity(1,1) not null,
inward_no			int		not null,
inward_date			date	not	null,
reference_id		int		not null,
from_location_id	int		not null,
to_location_id		int		not null,
reference_type		nvarchar(50) not null,
remarks				nvarchar(500) null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_inwards_inward_id] primary key clustered
	(
		[inward_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.inwards add constraint [DF_inwards_is_deleted] default(0) for[is_deleted]
go

alter table dbo.inwards add constraint [DF_inwards_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.inwards add constraint [DF_inwards_row_guid] default(newid()) for[row_guid]
go

create table inward_goods_details
(
inward_goods_id			int	identity(1,1)	not null,
inward_id				int	not null,
goods_receipt_item_id	int	not null,
item_id					int null,
qty_in_pcs				decimal(18,2)	not null,
qty_in_mtrs				decimal(18,2)	not null,
inward_status			nvarchar(25)	not null,
remarks					nvarchar(500) null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_inward_goods_details_inward_goods_id] primary key clustered
	(
		[inward_goods_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.inward_goods_details add constraint [DF_inward_goods_details_is_deleted] default(0) for[is_deleted]
go

alter table dbo.inward_goods_details add constraint [DF_inward_goods_details_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.inward_goods_details add constraint [DF_inward_goods_details_row_guid] default(newid()) for[row_guid]
go


use pos_raheja_Dev
alter table outwards alter column truck_no nvarchar(25) null
go

-- POS STOCK DETAILS ENTRY FOR OLD STOCK OF NTC
-- use pos_raheja_live

--insert into dbo.purchase_bills
--(vendor_id, transporter_id, purchase_bill_no, challan_no, purchase_bill_date, truck_no, total_weight,
--branch_id, working_period_id, is_deleted, created_by, created_by_ip, created_datetime, row_guid,
--gst_applicable, is_tax_inclusive)

--SELECT
--	sd.vendor_id, 0 AS transporter_id, sd.lot_no AS  purchase_bill_no, sd.lot_no AS challan_no, 
--	sd.stock_date AS purchase_bill_date, null AS truck_no, 0 AS total_weight, 1 AS branch_id, 1 AS working_period_id,
--	0 AS  is_deleted, 1 AS created_by, '182.70.126.203' AS created_by_ip, GETDATE() AS created_datetime,
--	NEWID(), CASE WHEN s.state_code = 'MH' THEN 'SGST' ELSE 'IGST' END AS gst_applicable, 1 AS is_tax_inclusive
--FROM
--	dbo.stock_details sd
--INNER JOIN
--	dbo.client_addressess v ON sd.vendor_id = v.client_address_id
--INNER JOIN
--	dbo.states s ON v.state_id = s.state_id
--GROUP BY
--	sd.vendor_id,
--	sd.lot_no,
--	sd.stock_date,
--	s.state_code
--ORDER BY
--	sd.stock_date,
--	sd.lot_no


--	select * from dbo.purchase_bills p
--	where p.challan_no = 2269


--insert into dbo.purchase_bill_items
--(purchase_bill_id, item_id, bale_no, lr_no, purchase_qty_in_pcs, purchase_qty_in_mtrs, purchase_rate, gst_rate_id,
--tax_id, is_deleted, created_by, created_by_ip, created_datetime, row_guid)
--select  pb.purchase_bill_id, sd.item_id, sd.bale_no, sd.lot_no as lr_no, sd.received_qty_in_pcs, 
--sd.received_qty_in_mtrs, sd.purchase_rate, case when sd.purchase_rate <= 1000 then 5 else 6 end as gst_rate_id,
--1 as tax_id, 0 as is_deleted, 1 created_by, '182.70.126.203' as created_by_ip, getdate() as created_datetime, NEWID()
--from dbo.stock_details sd
--inner join dbo.purchase_bills pb ON sd.lot_no = pb.challan_no
--and sd.vendor_id = pb.vendor_id
----and sd.stock_date = pb.purchase_bill_date
----where pb.challan_no = '2240'
--group by 
--	pb.purchase_bill_id, sd.item_id, sd.bale_no, sd.received_qty_in_pcs, 
--sd.received_qty_in_mtrs, sd.purchase_rate, case when sd.purchase_rate <= 1000 then 5 else 6 end,
--sd.stock_date, sd.vendor_id, sd.lot_no
--order by purchase_bill_id, sd.stock_date, sd.vendor_id, sd.bale_no, sd.lot_no


--- INSERT RECORDS IN GOODS RECEIPT ITEMS
--insert into dbo.goods_receipts
--(purchase_bill_id, goods_receipt_no, goods_receipt_date, goods_received_location_id, branch_id, working_period_id,
--created_by, created_by_ip, created_datetime, row_guid)

--select pb.purchase_bill_id, ROW_NUMBER () OVER (ORDER by pb.purchase_bill_no) as goods_receipt_no,
--pb.purchase_bill_date, 3, 1, 1, 1, '182.70.126.203', GETDATE(), NEWID()
--from dbo.purchase_bills pb


--insert into dbo.goods_receipt_items
--(goods_receipt_id, purchase_bill_item_id, received_qty_in_pcs, received_qty_in_mtrs, is_deleted, created_by, created_by_ip,
--created_datetime, row_guid)
--select gr.goods_receipt_id, pbi.purchase_bill_item_id, pbi.purchase_qty_in_pcs, pbi.purchase_qty_in_mtrs,
--0, 1, '182.70.126.203', GETDATE(), NEWID() 
--from dbo.purchase_bill_items pbi
--inner join dbo.goods_receipts gr on pbi.purchase_bill_id = gr.purchase_bill_id


--insert into dbo.pkg_slips
--INSERT INTO dbo.pkg_slips
--(pkg_slip_no, pkg_slip_date, bale_no, working_period_id, is_deleted, created_by, created_by_ip, created_datetime,
--branch_id, from_location_id, type_of_transfer_id)
--SELECT ROW_NUMBER() OVER (ORDER BY gr.goods_receipt_date) AS pkg_slip_no, gr.goods_receipt_date,
--pbi.bale_no, 1 as working_period_id, 0 as is_deleted, 1 as created_by, '::1' as created_by_ip, 
--GETDATE(), 1 branch_id, 1 as from_location_id, 1 as type_of_transfer_id
--FROM dbo.goods_receipts gr
--INNER JOIN dbo.goods_receipt_items gri ON gr.goods_receipt_id = gri.goods_receipt_id
--INNER JOIN dbo.purchase_bill_items pbi ON gri.purchase_bill_item_id = pbi.purchase_bill_item_id
--GROUP BY pbi.bale_no, gr.goods_receipt_date
--ORDER BY gr.goods_receipt_date

--INSERT INTO dbo.pkg_slip_items
--(pkg_slip_id, item_id, pkg_qty_in_pcs, pkg_qty_in_mtrs, is_deleted, created_by, created_by_ip, goods_receipt_item_id)
--select ps.pkg_slip_id, pbi.item_id, gri.received_qty_in_pcs, gri.received_qty_in_mtrs,
--0 as is_deleted, 1 as created_by, '::1' as created_by_ip, gri.goods_receipt_item_id
--from dbo.pkg_slips ps
--inner join dbo.purchase_bill_items pbi ON ps.bale_no = pbi.bale_no
--inner join dbo.goods_receipt_items gri ON pbi.purchase_bill_item_id = gri.purchase_bill_item_id
--ORDER BY ps.pkg_slip_id

--INSERT INTO dbo.outwards
--(outward_no, outward_date, transporter_id, truck_no, branch_id, created_by, created_by_ip, working_period_id, location_id)
--select ROW_NUMBER() OVER (ORDER BY ps.pkg_slip_no) AS outward_no,
--ps.pkg_slip_date, 64 as transporter_id, null, 1, 1, '::1', 1, 3 as location_id
--from dbo.pkg_slips ps
--order by ps.pkg_slip_no

--INSERT INTO dbo.outward_goods_details
--(outward_id, pkg_slip_item_id, goods_receipt_item_id, created_by, created_by_ip)
--select o.outward_id, 
--psi.pkg_slip_item_id, psi.goods_receipt_item_id, 1, '::1'
--from dbo.pkg_slip_items psi
--inner join dbo.pkg_slips ps ON psi.pkg_slip_id = ps.pkg_slip_id
--inner join dbo.outwards o on ps.pkg_slip_no = o.outward_no





use POS_Raheja_Dev

alter table dbo.outward_goods_details add goods_receipt_item_id	int not null
go

alter table dbo.item_rates add is_sell_at_net_rate bit null
go

alter table dbo.inwards add working_period_id int null
go

alter table dbo.inwards
add transporter_id int null,
vehicle_no nvarchar(25) null
go

exec sp_rename 'outwards.truck_no', 'vehicle_no', 'column'



---- insert goods receipt details in inward details
--INSERT INTO dbo.inwards
--(inward_no, inward_date, reference_id, from_location_id, to_location_id,
--reference_type, remarks, is_deleted, created_by, created_by_ip, created_datetime,
--working_period_id, transporter_id, vehicle_no)
 
--select gr.goods_receipt_no, gr.goods_receipt_date, gr.goods_receipt_id,
--gr.goods_received_location_id, gr.goods_received_location_id, 'GOODS RECEIPT',
--'AUTO INSERT', 0, 1, '::1', GETDATE(), 1, 1, NULL
--from dbo.goods_receipts gr
--order by gr.goods_receipt_id




---- insert receipt items details against that goods receipt id with inward id
--insert into dbo.inward_goods_details
--(inward_id, goods_receipt_item_id, item_id, qty_in_pcs, qty_in_mtrs, inward_status,
--remarks, is_deleted, created_by, created_by_ip, created_datetime)
--select inw.inward_id, gri.goods_receipt_item_id, pbi.item_id, gri.received_qty_in_pcs,
--gri.received_qty_in_mtrs, 'P', 'AUTO', 0, 1, '::1', GETDATE()
--from dbo.goods_receipt_items gri
--inner join dbo.inwards inw ON gri.goods_receipt_id = inw.reference_id
--inner join dbo.purchase_bill_items pbi ON gri.purchase_bill_item_id = pbi.purchase_bill_item_id
--order by gri.goods_receipt_id



create table customer_transporter_mapping
(
mapping_id				int	identity(1,1) not null,
customer_address_id		int	not null,
transporter_address_id	int not null,
is_deleted				bit	not null,
created_by				int not null,
created_by_ip			nvarchar(25) not null,
created_datetime		datetime not null,
modified_by				int null,
modified_by_ip			nvarchar(25) null,
modified_datetime		datetime null,
deleted_by				int null,
deleted_by_ip			nvarchar(25) null,
deleted_datetime		datetime null,
row_guid				uniqueidentifier not null,
constraint [pk_customer_transporter_mapping_mapping_id] primary key clustered
	(
		[mapping_id] asc
	)
) ON [PRIMARY]
GO

alter table dbo.customer_transporter_mapping add constraint is_deleted default(0) for[is_deleted]
go

alter table dbo.customer_transporter_mapping add constraint created_datetime default(getdate()) for[created_datetime]
go

alter table dbo.customer_transporter_mapping add constraint row_guid default(newid()) for[row_guid]
go





use POS_Raheja_Live

DECLARE
	@stock_id			int = 122
	
DECLARE	
	@bale_no			nvarchar(10),
	@lot_no				nvarchar(10),
	@vendor_id			int,
	@item_id			int,
	@item_rate			decimal(18,2),
	@qty_in_pcs			decimal(18,2),
	@qty_in_mtrs		decimal(18,2),
	@stock_date			nvarchar(11),
	@goods_received_location_id int,
	@branch_id			int,
	@working_period_id	int,
	@created_by			int,
	@created_by_ip		nvarchar(25),
	@gst_applicable		nvarchar(5),	
	@purchase_bill_id	int,
	@purchase_bill_item_id	int,
	@goods_receipt_id		int,
	@goods_receipt_item_id	int,
	@inward_id				int,
	@inward_goods_id		int

-- -- Get the details from Stock details table
SELECT
	@vendor_id = sd.vendor_id,
	@bale_no = sd.bale_no,
	@lot_no = sd.lot_no,
	@item_id = sd.item_id,
	@item_rate = sd.purchase_rate,
	@qty_in_pcs = sd.received_qty_in_pcs,
	@qty_in_mtrs = sd.received_qty_in_mtrs,
	@stock_date = REPLACE(CONVERT(nvarchar(11), sd.stock_date, 106), ' ','/'),
	@branch_id	= sd.branch_id,
	@working_period_id = sd.working_period_id,
	@created_by = sd.created_by,
	@created_by_ip = sd.created_by_ip
FROM
	dbo.stock_details sd
WHERE
	sd.stock_id = @stock_id

-- -- Check vendor state and get GST applicable
SELECT
	@gst_applicable = CASE WHEN s.state_abbr = 'MH' THEN 'SGST' ELSE 'IGST' END
FROM
	dbo.client_addressess v
INNER JOIN
	dbo.states s ON v.state_id = s.state_id
WHERE
	v.client_address_id = @vendor_id

-- -- Check purchase bill id exist against the vendor and bale no
SELECT 
	@purchase_bill_id = pbi.purchase_bill_id
FROM
	dbo.purchase_bill_items pbi
INNER JOIN
	dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
WHERE
		pb.vendor_id = @vendor_id
	AND pbi.bale_no = @bale_no
GROUP BY
	pbi.purchase_bill_id

-- -- Get GST Rate Id
DECLARE
	@gst_rate_id int

EXEC @gst_rate_id = usp_gst_rate_id_get_by_item_id_gst_applicable_and_rate @item_id, @gst_applicable, @item_rate, @gst_rate_id

--select @gst_rate_id

-- -- If purchase bill id found
IF @purchase_bill_id > 0
	BEGIN

		DECLARE
			@is_item_id_exists bit = 0

		-- -- Check is item already exists
		SELECT
			@is_item_id_exists = 1
		FROM
			dbo.purchase_bill_items pbi
		WHERE
			pbi.item_id = @item_id

		IF @is_item_id_exists = 1
			BEGIN
				-- -- Update the item details in purchase bill item
				UPDATE
					pbi
				SET
					pbi.purchase_qty_in_pcs = sd.received_qty_in_pcs,
					pbi.purchase_qty_in_mtrs = sd.received_qty_in_mtrs
				FROM
					dbo.purchase_bill_items pbi
				INNER JOIN
					dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
				INNER JOIN
					dbo.stock_details sd ON pbi.bale_no = @bale_no AND pb.vendor_id = @vendor_id
				WHERE
					pbi.purchase_bill_id = @purchase_bill_id
					AND pbi.item_id = sd.item_id
					AND sd.stock_id = @stock_id
			END
		ELSE
			BEGIN
				
				-- -- Insert item details in purchase bill item
				exec @purchase_bill_id = usp_purchase_bills_insert_bill_details
					@purchase_bill_id, @vendor_id, @bale_no, @stock_date, 1,
					@bale_no, 1, 0, @gst_applicable, 1, 1, 1, '::1', @purchase_bill_id 

				IF @purchase_bill_id > 0
					BEGIN
						exec @purchase_bill_item_id = usp_purchase_bill_items_insert_bill_item
							@purchase_bill_item_id, @purchase_bill_id, @item_id,
							@bale_no, @lr_no, @qty_in_pcs, @qty_in_mtrs, @item_rate, null, 0, 0, @gst_rate_id, @tax_id,
							@created_by, @created_by_ip, @purchase_bill_item_id
					END
			END
	
		-- -- INSERT DETAILS FOR GOODS RECEIVED

		-- -- Check the purchase bill id exists in the Goods Receipt
		-- -- If exists then Get the Goods Receipt Id
		SELECT
			@goods_receipt_id = gr.goods_receipt_id
		FROM
			dbo.goods_receipts gr
		WHERE
			gr.purchase_bill_id = @purchase_bill_id
			
		IF @goods_receipt_id > 0
			BEGIN
				UPDATE
					gri
				SET
					gri.received_qty_in_pcs = @qty_in_cs,
					gri.received_qty_in_mtrs = @qty_in_mtrs
				FROM
					dbo.goods_receipt_items gri
				WHERE
					gri.goods_receipt_id = @goods_receipt_id
					AND gri.purchase_bill_item_id = @purchase_bill_item_id

			END
		ELSE
			BEGIN
				
				-- -- Insert Goods Received Details
				EXEC @goods_receipt_id = 
					usp_goods_receipts_insert_goods_receipt
						@goods_receipt_id,
						@purchase_bill_id,
						0,
						@stock_date,
						@goods_recived_location_id,
						@branch_id,
						@working_period_id,
						@created_by,
						@created_by_ip,
						@goods_receipt_id

				IF @goods_receipt_id > 0
					BEGIN
						
						-- -- Insert Goods Receipt Items
						EXEC @goods_receipt_item_id = 
							usp_goods_receipt_items_insert_goods_receipt_item
								0,
								@goods_receipt_id,
								@purchase_bill_item_id,
								@qty_in_pcs,
								@qty_in_mtrs,
								@created_by,
								@created_by_ip,
								@goods_receipt_item_id								
					END
			END
			
		-- -- INSERT DETAILS FOR INWARD DETAILS
		
		-- -- Check the goods receipt id exists in the Inward Details
		-- -- If exists then Get the Inward Id
		SELECT
			@inward_id = gr.goods_receipt_id
		FROM
			dbo.inwards i
		WHERE
			i.reference_id = @goods_receipt_id

		IF @inward_id > 0
			BEGIN
				UPDATE
					gri
				SET
					igd.qty_in_pcs = @qty_in_cs,
					igd.qty_in_mtrs = @qty_in_mtrs
				FROM
					dbo.inward_goods_details igd
				WHERE
						igd.inward_id = @inward_id
					AND igd.goods_receipt_item_id = @goods_receipt_item_id
					AND gri.item_id = @item_id

			END
		ELSE
			BEGIN
					
				-- -- Insert Inward Details
				EXEC @inward_goods_id = 
					usp_inwards_insert_inward_details
						@inward_id,
						0,
						@stock_date,
						@goods_receipt_id,
						@goods_received_location_id,
						@goods_received_location_id,
						'GOODS RECEIPT',
						0,
						NULL,
						'AUTO TRANSFER',						
						@working_period_id,
						@created_by,
						@created_by_ip,
						@inward_id

				IF @inward_id > 0
					BEGIN
						
						-- -- Insert Inward Goods Details
						EXEC @inward_goods_id = 
							usp_inward_goods_details_insert_inward_goods
								0,
								@inward_id,
								@goods_receipt_item_id,
								@item_id,
								@qty_in_pcs,
								@qty_in_mtrs,
								'P',
								NULL,
								@created_by,
								@created_by_ip,
								@inward_goods_id
					END
			END

	END

exec sp_rename 'tax_slabs.effective_date', 'effective_from_date', 'column'

alter table tax_slabs
add effective_to_date datetime
go

CREATE TABLE companies
(
company_id	int	identity(1,1)	not null,
company_name	nvarchar(200)	not null,
company_address	nvarchar(500)	not null,
country_id		int				not null,
state_id		int				not null,
city_id			int				not null,
website			nvarchar(200)	null,
gstin_no		nvarchar(25)	null,
is_deleted		bit				not null,
created_by		int				not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int			null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int			null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [companies_pk_company_id] primary key clustered
	([company_id] ASC)
) ON [PRIMARY]
GO

alter table companies add constraint [DF_companies_is_deleted] default(0) for[is_deleted]
go

alter table companies add constraint [DF_companies_created_datetime] default(getdate()) for[created_datetime]
go

alter table companies add constraint [DF_companies_row_guid] default(newid()) for[row_guid]
go


CREATE TABLE item_pictures
(
item_picture_id		int	identity(1,1)	not null,
item_id				int	not null,
item_picture_name	nvarchar(200)	not null,
item_picture_path	nvarchar(500)	not null,
is_deleted		bit				not null,
created_by		int				not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int			null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int			null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [item_pictures_pk_item_picture_id] primary key clustered
	([item_picture_id] ASC)
) ON [PRIMARY]
GO

alter table item_pictures add constraint [DF_item_pictures_is_deleted] default(0) for[is_deleted]
go

alter table item_pictures add constraint [DF_item_pictures_created_datetime] default(getdate()) for[created_datetime]
go

alter table item_pictures add constraint [DF_item_pictures_row_guid] default(newid()) for[row_guid]
go

--- change in qty logic 29/0/2018 15:56


alter table purchase_bill_items
add purchase_qty decimal(18,2)	null,
unit_of_measurement_id	int null
go


update dbo.purchase_bill_items set qty = 1, unit_of_measurement_id = 8 where purchase_bill_item_id in (390, 982)

update dbo.purchase_bill_items SET qty = purchase_qty_in_pcs, unit_of_measurement_id = 8 where purchase_qty_in_pcs > 0

alter table purchase_bill_items alter column qty decimal(18,2)	 not null
go
alter table purchase_bill_items alter column unit_of_measurement_id	int not null
go

update dbo.purchase_bill_items SET qty = purchase_qty_in_mtrs, unit_of_measurement_id = 1 where purchase_bill_item_id = 1246


-- -- query for stock in transit
select
	v.client_address_name as vendor_name, 	
	CASE WHEN iq.item_quality = 'NONE' THEN '' ELSE iq.item_quality + ' ' END + i.item_name as item_name,	
	pb.purchase_bill_no, pb.purchase_bill_date, pbi.bale_no, pbi.lr_no, 
	--pbi.purchase_bill_item_id, 
	pbi.purchase_qty_in_pcs	
from
	dbo.purchase_bill_items pbi
INNER JOIN dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
INNER JOIN dbo.items i ON pbi.item_id = i.item_id
INNER JOIN dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
INNER JOIN dbo.client_addressess v ON pb.vendor_id = v.client_address_id
where 
pbi.is_deleted = 0
AND pbi.purchase_qty_in_pcs > 0
and pb.purchase_bill_date >= '01/Apr/2018'
and NOT pb.purchase_bill_id in (SELECT gr.purchase_bill_id from goods_receipts gr)
--and pbi.purchase_qty_in_pcs <> ISNULL(gri.received_qty_in_pcs,0) 
order by pbi.created_datetime desc

---- short receipts

--select
--	dbo.udf_items_get_item_name_by_brand_category_and_quality(i.item_id) as item_name,
--	v.client_address_name as vendor_name, 
--	pbi.bale_no, pbi.lr_no, pb.purchase_bill_no, pb.purchase_bill_date, pbi.purchase_bill_item_id, pbi.purchase_qty_in_pcs,
--	isnull(gri.received_qty_in_pcs,0) as  goods_received_qty_in_pcs,
--	pbi.purchase_qty_in_pcs - ISNULL(gri.received_qty_in_pcs,0) as Differnce
--from
--	dbo.purchase_bill_items pbi
--INNER JOIN dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
--INNER JOIN dbo.client_addressess v ON pb.vendor_id = v.client_address_id
--inner join dbo.items i ON pbi.item_id = i.item_id
--left join dbo.goods_receipt_items gri ON pbi.purchase_bill_item_id = gri.purchase_bill_item_id
--where 
--pbi.is_deleted = 0
--and pb.purchase_bill_date >= '01/Apr/2018'
----and pbi.purchase_qty_in_pcs <> ISNULL(gri.received_qty_in_pcs,0) 
--order by pbi.created_datetime desc



-- -- query for stock in transit
select
	v.client_address_name as vendor_name, 	
	CASE WHEN iq.item_quality = 'NONE' THEN '' ELSE iq.item_quality + ' ' END + i.item_name as item_name,	
	pb.purchase_bill_no, pb.purchase_bill_date, SUBSTRING(t.client_address_name, 0, 11) as transporter_name, pbi.lr_no, 
	--pbi.purchase_bill_id, pbi.purchase_bill_item_id, 
	pbi.purchase_qty, pbi.purchase_rate, (pbi.purchase_qty * pbi.purchase_rate) as total_amount
from
	dbo.purchase_bill_items pbi
INNER JOIN dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
INNER JOIN dbo.items i ON pbi.item_id = i.item_id
INNER JOIN dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
INNER JOIN dbo.client_addressess v ON pb.vendor_id = v.client_address_id
inner join dbo.client_addressess t ON pb.transporter_id = t.client_address_id
where 
pbi.is_deleted = 0
AND pbi.purchase_qty > 0
--and pb.purchase_bill_date >= '01/Apr/2018'
and NOT pb.purchase_bill_id in (SELECT gr.purchase_bill_id from goods_receipts gr)
--and pbi.purchase_qty_in_pcs <> ISNULL(gri.received_qty_in_pcs,0) 
order by pbi.created_datetime desc

---- short receipts

--select
--	dbo.udf_items_get_item_name_by_brand_category_and_quality(i.item_id) as item_name,
--	v.client_address_name as vendor_name, 
--	pbi.bale_no, pbi.lr_no, pb.purchase_bill_no, pb.purchase_bill_date, pbi.purchase_bill_item_id, pbi.purchase_qty_in_pcs,
--	isnull(gri.received_qty_in_pcs,0) as  goods_received_qty_in_pcs,
--	pbi.purchase_qty_in_pcs - ISNULL(gri.received_qty_in_pcs,0) as Differnce
--from
--	dbo.purchase_bill_items pbi
--INNER JOIN dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
--INNER JOIN dbo.client_addressess v ON pb.vendor_id = v.client_address_id
--inner join dbo.items i ON pbi.item_id = i.item_id
--left join dbo.goods_receipt_items gri ON pbi.purchase_bill_item_id = gri.purchase_bill_item_id
--where 
--pbi.is_deleted = 0
--and pb.purchase_bill_date >= '01/Apr/2018'
----and pbi.purchase_qty_in_pcs <> ISNULL(gri.received_qty_in_pcs,0) 
--order by pbi.created_datetime desc

create table sales_return_bills
(
sales_return_bill_id	int	identity(1,1) not null,
sales_bill_id			int	not null,
sales_return_bill_no	int	not null,
sales_return_bill_date	date not null,
is_deleted				bit not null,
row_guid				uniqueidentifier not null,
created_by				int not null,
created_by_ip			nvarchar(5) not null,
created_datetime		datetime not null,
modified_by				int null,
modified_by_ip			nvarchar(5) null,
modified_datetime		datetime null,
deleted_by				int null,
deleted_by_ip			nvarchar(5) null,
deleted_datetime		datetime null,
constraint [pk_sales_return_bills_sales_return_bill_id] primary key clustered	
	(
		[sales_return_bill_id]
	)
)
GO

alter table sales_return_bills add constraint [DF_sales_return_bills_is_deleted] default(0) for[is_deleted]
go

alter table sales_return_bills add constraint [DF_sales_return_bills_created_datetime] default(getdate()) for[created_datetime]
go

alter table sales_return_bills add constraint [DF_sales_return_bills_row_guid] default(newid()) for[row_guid]
go

create table sales_return_bill_items
(
sales_return_bill_item_id	int not null,
sales_return_bill_id		int not null,
sales_bill_item_id			int not null,
return_qty					decimal(18,2) not null,
is_deleted					bit not null,
row_guid					uniqueidentifier not null,
created_by					int not null,
created_by_ip				nvarchar(5) not null,
created_datetime			datetime not null,
modified_by					int null,
modified_by_ip				nvarchar(5) null,
modified_datetime			datetime null,
deleted_by					int null,
deleted_by_ip				nvarchar(5) null,
deleted_datetime			datetime null,
constraint [pk_sales_return_bill_items_sales_return_bill_item_id] primary key clustered	
	(
		[sales_return_bill_item_id]
	)
)
GO

alter table sales_return_bill_items add constraint [DF_sales_return_bill_items_is_deleted] default(0) for[is_deleted]
go

alter table sales_return_bill_items add constraint [DF_sales_return_bill_items_created_datetime] default(getdate()) for[created_datetime]
go

alter table sales_return_bill_items add constraint [DF_sales_return_bill_items_row_guid] default(newid()) for[row_guid]
go


alter table goods_receipt_items
add received_qty decimal(18,2)	null,
unit_of_measurement_id	int null
go

alter table inward_goods_details
add inward_qty decimal(18,2)	null,
unit_of_measurement_id	int null
go

alter table pkg_slip_items
add pkg_qty decimal(18,2)	null,
unit_of_measurement_id	int null
go

alter table sales_bills_items
add sale_qty decimal(18,2)	null,
unit_of_measurement_id	int null
go

select * from dbo.goods_receipt_items gri where gri.received_qty is null

update dbo.goods_receipt_items set received_qty = received_qty_in_pcs, unit_of_measurement_id = 8 where received_qty_in_pcs > 0

update dbo.goods_receipt_items set received_qty = received_qty_in_mtrs, unit_of_measurement_id = 1 where received_qty_in_mtrs > 0

update dbo.goods_receipt_items set received_qty = received_qty_in_pcs, unit_of_measurement_id = 8 where received_qty IS null

select * from dbo.inward_goods_details igd where igd.qty_in_mtrs > 0

update dbo.inward_goods_details set inward_qty = qty_in_pcs, unit_of_measurement_id = 8 where qty_in_pcs > 0

update dbo.inward_goods_details set inward_qty = qty_in_mtrs, unit_of_measurement_id = 1 where qty_in_mtrs > 0

update dbo.inward_goods_details set inward_qty = 0, unit_of_measurement_id = 8 where inward_qty IS null

select * from dbo.pkg_slip_items psi where psi.pkg_qty_in_pcs  > 0

update dbo.pkg_slip_items set pkg_qty = pkg_qty_in_pcs, unit_of_measurement_id = 8 where pkg_qty_in_pcs > 0

update dbo.pkg_slip_items set pkg_qty = pkg_qty_in_mtrs, unit_of_measurement_id = 1 where pkg_qty_in_mtrs > 0

update dbo.pkg_slip_items set pkg_qty = 0, unit_of_measurement_id = 8 where pkg_qty IS null

select * from dbo.sales_bills_items sbi where sbi.item_qty_in_pcs > 0

update dbo.sales_bills_items set sale_qty = item_qty_in_pcs, unit_of_measurement_id = 8 where item_qty_in_pcs > 0

update dbo.sales_bills_items set sale_qty = item_qty_in_pcs, unit_of_measurement_id = 1 where item_qty_in_mtrs > 0

update dbo.sales_bills_items set sale_qty = 0, unit_of_measurement_id = 8 where sale_qty IS null

alter table goods_receipt_items alter column received_qty decimal(18,2)	 not null
go

alter table goods_receipt_items alter column unit_of_measurement_id int not null
go

alter table inward_goods_details alter column inward_qty decimal(18,2)	 not null
go

alter table inward_goods_details alter column unit_of_measurement_id int not null
go

alter table pkg_slip_items alter column pkg_qty decimal(18,2)	 not null
go

alter table pkg_slip_items alter column unit_of_measurement_id int not null
go

alter table sales_bills_items alter column sale_qty decimal(18,2)	 not null
go

alter table sales_bills_items alter column unit_of_measurement_id int not null
go

alter table dbo.purchase_bill_items drop column purchase_qty_in_pcs
go
alter table dbo.purchase_bill_items drop column purchase_qty_in_mtrs
go

alter table dbo.goods_receipt_items drop column received_qty_in_pcs
go
alter table dbo.goods_receipt_items drop column received_qty_in_mtrs
go

alter table dbo.inward_goods_details drop column qty_in_pcs
go
alter table dbo.inward_goods_details drop column qty_in_mtrs
go

alter table dbo.pkg_slip_items drop column pkg_qty_in_pcs
go
alter table dbo.pkg_slip_items drop column pkg_qty_in_mtrs
go

alter table dbo.sales_bills_items drop column item_qty_in_pcs
go
alter table dbo.sales_bills_items drop column item_qty_in_mtrs
go

alter table sales_return_bills
add branch_id int,
working_period_id int
go

alter table purchase_bills
add is_composition_bill bit null,
is_sample bit null
go

insert into dbo.menus
(menu_group_id, menu_name, page_link, menu_sequence, created_by, created_by_ip)
values
(5, 'Purchase Bill Register', 'MIS/PurchaseBillRegister', 2, 1, '::1')

select * from dbo.role_permissions

insert into dbo.role_permissions
(role_id, menu_group_id, menu_id, add_permission, view_permission, edit_permission, delete_permission, created_by, created_by_ip)
values
(1, 5, 27, 1, 1, 1, 1, 1, '::1')


SELECT
	sbi.item_id,
	iq.item_quality + ' ' + i.item_name AS item_name,
	gstc.hsn_code,
	sbi.unit_of_measurement_id,
	uom.unit_code,
	SUM(ISNULL(sbi.sale_qty,0)) - SUM(ISNULL(srbi.return_qty,0)) AS balance_qty,
	sbi.type_of_discount,
	sbi.cash_discount_percent,
	sbi.gst_rate_id,
	gstr.gst_rate,
	sbi.tax_id,
	gstr.gst_name,		
	sbi.sales_bill_item_id,
	sbi.goods_receipt_item_id
FROM
	dbo.sales_bills_items sbi
INNER JOIN
	dbo.sales_bills sb ON sbi.sales_bill_id = sb.sales_bill_id
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
INNER JOIN
	dbo.units_of_measurements uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.gst_categories gstc ON ic.gst_category_id = gstc.gst_category_id
INNER JOIN
	dbo.gst_rates gstr ON sbi.gst_rate_id = gstr.gst_rate_id
LEFT JOIN
	dbo.sales_return_bill_items srbi ON sbi.item_id = srbi.item_id
WHERE
	sb.consignee_id = 131
GROUP BY
	sbi.item_id,
	iq.item_quality,
	i.item_name,
	gstc.hsn_code,
	sbi.unit_of_measurement_id,
	uom.unit_code,
	sbi.type_of_discount,
	sbi.cash_discount_percent,
	sbi.gst_rate_id,
	gstr.gst_rate,
	sbi.tax_id,
	gstr.gst_name,		
	sbi.sales_bill_item_id,
	sbi.goods_receipt_item_id
HAVING
	SUM(ISNULL(sbi.sale_qty,0)) - SUM(ISNULL(srbi.return_qty,0)) > 0
	 
	
UNION

SELECT
	i.item_id,
	iq.item_quality + ' ' + i.item_name AS item_name,
	gstc.hsn_code,
	i.unit_of_measurement_id,
	uom.unit_code,
	0 AS balance_qty,
	NULL AS type_of_discount,
	0 AS cash_discount_percent,
	0 AS gst_rate_id,
	0 AS gst_rate,
	0 AS tax_id,
	'' AS gst_name,
	0 AS sales_bill_item_id,
	0 AS goods_receipt_item_id
FROM
	dbo.items i
INNER JOIN
	dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
INNER JOIN
	dbo.units_of_measurements uom ON i.unit_of_measurement_id = uom.unit_of_measurement_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.gst_categories gstc ON ic.gst_category_id = gstc.gst_category_id
WHERE
		i.is_deleted = 0
	AND NOT i.item_id in (SELECT pbi.item_id FROM dbo.purchase_bill_items pbi WHERE pbi.is_deleted = 0 GROUP BY pbi.item_id)	
ORDER BY
	item_id


----------------------------- x------------------------------x --------------------------

-- --changes after 07/07/2018

 alter table sales_return_bills
 add consignee_id int null
 go

alter table sales_return_bills drop column sales_bill_id
go

alter table sales_return_bill_items drop column sales_bill_id
go

 alter table sales_return_bill_items
 add 
sale_rate			decimal(18,2) not null,
type_of_discount	nvarchar(25) null,
cash_discount_percent decimal(18,2) null,
discount_amount	decimal(18,2) null,
unit_of_measurement_id	int not null,
 is_tax_inclusive bit not null,
 gst_rate_id int null,
 tax_id	int null,
 item_remarks nvarchar(500) null
 go

alter table sales_return_bill_items
 add
 sales_bill_id int null
go

alter table sales_return_bill_items add constraint [DF_sales_return_bill_items_is_tax_inclusive] default(1) for[is_tax_inclusive]
go

alter table sales_return_bills
add sale_type_id int
go

create table sales_return_bill_adjustment
	(
		sales_return_bill_adjustment_id	int	identity(1,1) not null,
		sales_return_bill_id	int not null,
		sales_bill_id			int not null,
		created_by				int not null,
		created_by_ip			nvarchar(25) not null,
		created_datetime		datetime not null,
		row_guid				uniqueidentifier not null,
		constraint [pk_sales_return_bill_adjustment_sales_return_bill_adjustment_id] primary key clustered
			(
				[sales_return_bill_adjustment_id]
			) ON [PRIMARY]
	)
	go

	alter table sales_return_bill_adjustment add constraint [DF_sales_return_bill_adjustment_row_guid] default(NEWID()) for[row_guid]
	go

	alter table sales_return_bill_adjustment add constraint [DF_sales_return_bill_adjustment_created_datetime] default(GETDATE()) for[created_datetime]
	go

------- 28 07 2018 ------

create table location_types(
location_type_id	int	identity(1,1)	not null,
location_type		nvarchar(25)	not null,
is_deleted			bit	not null,
created_by			int		not null,
created_by_ip		nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime	null,
deleted_by			int null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime	null,
row_guid			uniqueidentifier	not null,
constraint [pk_location_types_location_type_id] primary key clustered
	(
		[location_type_id] ASC 
	)
) on [PRIMARY]
GO

ALTER TABLE dbo.location_types ADD CONSTRAINT [DF_location_types_is_deleted] DEFAULT(0) FOR[is_deleted]
GO

ALTER TABLE dbo.location_types ADD CONSTRAINT [DF_location_types_created_datetime] DEFAULT(GETDATE()) FOR[created_datetime]
GO

ALTER TABLE dbo.location_types ADD CONSTRAINT [DF_location_types_row_guid] DEFAULT(NEWID()) FOR[row_guid]
GO

alter table dbo.location_types alter column deleted_by bit null
go

ALTER TABLE dbo.locations
ADD location_type_id	int not null
go

INSERT INTO dbo.location_types
(location_type, created_by, created_by_ip)
values
('Store', 1, '::1'),
('Godown', 1, '::1')

select * from dbo.location_types

select * from dbo.locations


INSERT INTO dbo.locations
(location_type_id, location_name, location_address, city_id, location_area, contact_person, contact_nos, created_by, created_by_ip)
VALUES
(1, 'GOPAL GALLI A', 'MM MARKET', 1, 'MUMBAI', 'BANSI', NULL, 1, '::1'),
(1, 'GOPAL GALLI B', 'MM MARKET', 1, 'MUMBAI', 'BANSI', NULL, 1, '::1'),
(1, 'MANGALDAS MARKET', 'MM MARKET', 1, 'MUMBAI', 'BANSI', NULL, 1, '::1'),
(2, 'N.T.C.', 'BHIWANDI', 1, 'BHIWANDI', 'MANAGER', NULL, 1, '::1')

select * from dbo.pkg_slips

ALTER TABLE dbo.pkg_slips
ADD
purchase_bill_id	int,
to_location_id		int
GO

SELECT pb.purchase_bill_id, ps.bale_no
FROM dbo.pkg_slips ps
INNER JOIN dbo.purchase_bill_items pbi ON ps.bale_no = pbi.bale_no AND pbi.is_deleted = 0
INNER JOIN dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id AND pb.is_deleted = 0
GROUP by pb.purchase_bill_id, ps.bale_no


UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '1918'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '1919'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '1988'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '1989'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '85411303'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541304'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541304A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541321'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541321A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541322'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541322A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541323'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541323A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541324'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541324A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541327'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541327A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541334'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541334A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541335'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541335A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8543807'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '083806'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1035'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1036'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1037'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1038'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1039'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1121'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1122'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1131'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1132'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1135'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1136'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1194'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1195'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1196'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1197'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1198'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1256'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1257'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1258'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1259'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1260'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1279'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1280'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1281'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1971'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1994'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '230 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '231 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '2430'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '2431'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '2432'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '2433'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '2434'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '358 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '359 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '378 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '379 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '386 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '416 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '428 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '453 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '454 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '459 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '460 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '461 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '462 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '605 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '612 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '615 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '962 '
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1829'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1830'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1947'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1948'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1949'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1950'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1951'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1952'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1953'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1954'
UPDATE dbo.pkg_slips SET vendor_id = 31		where bale_no = '2269'
UPDATE dbo.pkg_slips SET vendor_id = 32		where bale_no = '2268'
UPDATE dbo.pkg_slips SET vendor_id = 32		where bale_no = '2269'
UPDATE dbo.pkg_slips SET vendor_id = 32		where bale_no = '2270'
UPDATE dbo.pkg_slips SET vendor_id = 32		where bale_no = '2272'
UPDATE dbo.pkg_slips SET vendor_id = 33		where bale_no = '31	 '
UPDATE dbo.pkg_slips SET vendor_id = 34		where bale_no = '3112'
UPDATE dbo.pkg_slips SET vendor_id = 35		where bale_no = '2009'
UPDATE dbo.pkg_slips SET vendor_id = 35		where bale_no = '288 '
UPDATE dbo.pkg_slips SET vendor_id = 35		where bale_no = '289 '
UPDATE dbo.pkg_slips SET vendor_id = 35		where bale_no = '291 '
UPDATE dbo.pkg_slips SET vendor_id = 37		where bale_no = '2023'
UPDATE dbo.pkg_slips SET vendor_id = 37		where bale_no = '2038'
UPDATE dbo.pkg_slips SET vendor_id = 37		where bale_no = '2039'
UPDATE dbo.pkg_slips SET vendor_id = 37		where bale_no = '2048'
UPDATE dbo.pkg_slips SET vendor_id = 37		where bale_no = '2049'
UPDATE dbo.pkg_slips SET vendor_id = 38		where bale_no = '136/164037B'
UPDATE dbo.pkg_slips SET vendor_id = 39		where bale_no = '2030'
UPDATE dbo.pkg_slips SET vendor_id = 39		where bale_no = '2034'
UPDATE dbo.pkg_slips SET vendor_id = 40		where bale_no = '243/10270090'
UPDATE dbo.pkg_slips SET vendor_id = 40		where bale_no = '24310270090'
UPDATE dbo.pkg_slips SET vendor_id = 41		where bale_no = '2041'
UPDATE dbo.pkg_slips SET vendor_id = 42		where bale_no = '2042'
UPDATE dbo.pkg_slips SET vendor_id = 42		where bale_no = '2043'
UPDATE dbo.pkg_slips SET vendor_id = 42		where bale_no = '2044'
UPDATE dbo.pkg_slips SET vendor_id = 42		where bale_no = '2045'
UPDATE dbo.pkg_slips SET vendor_id = 49		where bale_no = '1260'
UPDATE dbo.pkg_slips SET vendor_id = 151	where bale_no = '2430'


update dbo.goods_receipts set goods_received_location_id = 1 where goods_received_location_id = 1

update dbo.goods_receipts set goods_received_location_id = 3 where goods_received_location_id = 2

update dbo.goods_receipts set goods_received_location_id = 4 where goods_received_location_id = 3

update dbo.inwards set from_location_id = 1 where from_location_id = 1
update dbo.inwards set from_location_id = 3 where from_location_id = 2
update dbo.inwards set from_location_id = 4 where from_location_id = 3

update dbo.inwards set to_location_id = 1 where to_location_id = 1
update dbo.inwards set to_location_id = 3 where to_location_id = 2
update dbo.inwards set to_location_id = 4 where to_location_id = 3

update dbo.pkg_slips set from_location_id = 1 where from_location_id = 1
update dbo.pkg_slips set from_location_id = 3 where from_location_id = 2
update dbo.pkg_slips set from_location_id = 4 where from_location_id = 3

--- WEEKLY SALES
SELECT
	SUM(dbo.udf_sales_bills_get_total_taxable_amount(sb.sales_bill_id)) taxable_amount,
	SUM(dbo.udf_sales_bills_get_total_gst_amount(sb.sales_bill_id)) gst_amount,
	SUM(dbo.udf_sales_bills_get_total_amount(sb.sales_bill_id)) total_amount
FROM dbo.sales_bills sb
WHERE DATEPART(DW, sb.sales_bill_date) = DATEPART(DW, CONVERT(DATE, GETDATE()))
AND sb.is_deleted = 0

--- TOP ITEM SALES
SELECT
	vwsisqpi.item_id, vwsisqpi.item_name, SUM(vwsisqpi.sale_qty), vwsisqpi.unit_code
FROM
	dbo.vw_sale_item_sum_qty_per_item vwsisqpi
GROUP BY
	vwsisqpi.item_id, vwsisqpi.item_name, vwsisqpi.unit_code
HAVING
	SUM(vwsisqpi.sale_qty) > 100
ORDER BY
	SUM(vwsisqpi.sale_qty) DESC


alter table dbo.inwards
add branch_id int null
go

update dbo.inwards set branch_id = 1

alter table dbo.inwards
add branch_id int not null
go

alter table dbo.purchase_bill_items
add gst_amount_as_per_vendor_bill decimal(18,2) null
go

alter table dbo.purchase_bills
add total_gst_amount_as_per_vendor_bill decimal(18,2) null
go


-------  CHANGES DONE ON AND AFTER 27/AUG/2018 --------




use POS_Raheja_Live

--- sum of item qty
SELECT
	ic.item_category_id,
	ic.item_category_name,
	SUM(sbi.sale_qty) AS sale_qty,
	uom.unit_code	
FROM
	dbo.sales_bills_items AS sbi
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.units_of_measurements AS uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
WHERE
	(sbi.is_deleted = 0)
	AND ic.item_category_id = 29
GROUP BY
	ic.item_category_id,
	ic.item_category_name,
	uom.unit_code
ORDER BY
	ic.item_category_name


--- Get sum of sale qty as per item_categories
SELECT
	ic.item_category_id,
	ic.item_category_name,
	UPPER(CONVERT(nvarchar(3), DATENAME(M,sb.sales_bill_date))) month_name,
	st.sale_type,
	SUM(sbi.sale_qty) AS sale_qty,
	uom.unit_code	
FROM
	dbo.sales_bills_items AS sbi
INNER JOIN
	dbo.sales_bills sb ON sbi.sales_bill_id = sb.sales_bill_id AND sb.is_deleted = 0
INNER JOIN
	dbo.sale_types st ON sb.sale_type_id = st.sale_type_id
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.units_of_measurements AS uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
WHERE
	(sbi.is_deleted = 0)
	AND ic.item_category_id = 29
GROUP BY
	ic.item_category_id,
	ic.item_category_name,
	uom.unit_code,
	CONVERT(nvarchar(3), DATENAME(M,sb.sales_bill_date)),
	st.sale_type,
	DATEPART(MM,sb.sales_bill_date)
ORDER BY
	ic.item_category_name,
	DATEPART(MM,sb.sales_bill_date)


--- Get sum of sale qty as per item_categories and branch wise
SELECT
	c.company_name,	
	b.branch_name,
	st.sale_type,
	UPPER(CONVERT(nvarchar(3), DATENAME(M,sb.sales_bill_date))) month_name,
	ic.item_category_id,
	ic.item_category_name,	
	SUM(sbi.sale_qty) AS sale_qty,
	uom.unit_code	
FROM
	dbo.sales_bills_items AS sbi
INNER JOIN
	dbo.sales_bills sb ON sbi.sales_bill_id = sb.sales_bill_id AND sb.is_deleted = 0
INNER JOIN
	dbo.sale_types st ON sb.sale_type_id = st.sale_type_id	
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.units_of_measurements AS uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
INNER JOIN
	dbo.branches b ON sb.branch_id = b.branch_id
INNER JOIN
	dbo.companies c ON b.company_id = c.company_id
WHERE
	(sbi.is_deleted = 0)
	AND ic.item_category_id = 29
GROUP BY
	c.company_name,	
	b.branch_name,	
	st.sale_type,
	DATEPART(MM,sb.sales_bill_date),
	ic.item_category_id,
	ic.item_category_name,
	uom.unit_code,
	CONVERT(nvarchar(3), DATENAME(M,sb.sales_bill_date))	
ORDER BY
	c.company_name,	
	b.branch_name,	
	DATEPART(MM,sb.sales_bill_date),	
	ic.item_category_name



--- Get sum of sale qty as per item_categories and branch wise
SELECT
	c.company_name,	
	b.branch_name,
	st.sale_type,
	UPPER(CONVERT(nvarchar(3), DATENAME(M,sb.sales_bill_date))) month_name,
	ic.item_category_id,
	ic.item_category_name,
	iq.item_quality,
	i.item_name,
	SUM(sbi.sale_qty) AS sale_qty,
	uom.unit_code	
FROM
	dbo.sales_bills_items AS sbi
INNER JOIN
	dbo.sales_bills sb ON sbi.sales_bill_id = sb.sales_bill_id AND sb.is_deleted = 0
INNER JOIN
	dbo.sale_types st ON sb.sale_type_id = st.sale_type_id	
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.units_of_measurements AS uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
INNER JOIN
	dbo.branches b ON sb.branch_id = b.branch_id
INNER JOIN
	dbo.companies c ON b.company_id = c.company_id
INNER JOIN
	dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
WHERE
	(sbi.is_deleted = 0)
	AND ic.item_category_id = 29
GROUP BY
	c.company_name,	
	b.branch_name,	
	st.sale_type,
	DATEPART(MM,sb.sales_bill_date),
	ic.item_category_id,
	ic.item_category_name,
	iq.item_quality,
	i.item_name,	
	uom.unit_code,
	CONVERT(nvarchar(3), DATENAME(M,sb.sales_bill_date))	
ORDER BY
	c.company_name,	
	b.branch_name,
	DATEPART(MM,sb.sales_bill_date),
	st.sale_type,
	ic.item_category_name,
	iq.item_quality,
	i.item_name
	


SELECT
	sbi.item_id,
	ic.item_category_id,
	ic.item_category_name,
	iq.item_quality_id,
	iq.item_quality,
	i.item_name,
	sbi.sale_qty AS sale_qty,
	--SUM(sbi.sale_qty) AS sale_qty,
	sbi.unit_of_measurement_id,
	uom.unit_code,
	sbi.goods_receipt_item_id
FROM
	dbo.sales_bills_items AS sbi
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
INNER JOIN
	dbo.units_of_measurements AS uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
WHERE
	(sbi.is_deleted = 0)
	AND ic.item_category_id = 29
--GROUP BY
--	sbi.item_id,
--	ic.item_category_id,
--	ic.item_category_name,
--	iq.item_quality_id,
--	iq.item_quality,
--	i.item_name,	
--	sbi.goods_receipt_item_id,
--	sbi.unit_of_measurement_id,
--	uom.unit_code
ORDER BY
	ic.item_category_name,
	iq.item_quality,
	i.item_name


--- sum of item qty
SELECT
	sbi.item_id,
	ic.item_category_id,
	ic.item_category_name,
	iq.item_quality_id,
	iq.item_quality,
	i.item_name,
	--sbi.sale_qty AS sale_qty,
	SUM(sbi.sale_qty) AS sale_qty,
	sbi.unit_of_measurement_id,
	uom.unit_code	
FROM
	dbo.sales_bills_items AS sbi
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
INNER JOIN
	dbo.units_of_measurements AS uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
WHERE
	(sbi.is_deleted = 0)
	AND ic.item_category_id = 29
GROUP BY
	sbi.item_id,
	ic.item_category_id,
	ic.item_category_name,
	iq.item_quality_id,
	iq.item_quality,
	i.item_name,	
	sbi.unit_of_measurement_id,
	uom.unit_code
ORDER BY
	ic.item_category_name,
	iq.item_quality,
	i.item_name
--------------------------------------XXXXXXXXXXXXXXXXXXXXXXXXXX-----------------------------------------

---- CHANGES DONE FROM 01/Sep/2018

update dbo.client_types set client_type = 'Karagir' where client_type_id = 5

alter table dbo.pkg_slips
add karagir_id int null
go

insert into dbo.location_types
(location_type, created_by, created_by_ip)
values
('Karagir', 1, '::1')

insert into dbo.locations
(location_name, location_type_id, location_address, city_id, location_area, contact_person, created_by, created_by_ip, created_datetime)
values
('Pandurang Karagir - Masjid', 3, 'Mumbai', 1, 'Masjid', 'Pandurang', 1, '::1', GETDATE()),
('Baban Karagir - Thane', 3, 'Thane', 1, 'Thane', 'Baban', 1, '::1', GETDATE())

----------------------------XXXXXXXXXXXXXXXXXXXXXXXXXXXXX-----------------------------------------------

-- -- CHANGES DONE FROM 16/10/2018 

alter table dbo.pkg_slips
add reference_no nvarchar(25)
go

alter table pkg_slip_items
add bale_no nvarchar(50) null
go

alter table pkg_slips drop column bale_no
go

update
	psi
SET
	psi.bale_no = ps.bale_no
FROM 
	dbo.pkg_slip_items psi
inner join dbo.pkg_slips ps ON psi.pkg_slip_id = ps.pkg_slip_id


create table job_works
(
job_work_id				int	identity(1,1) not null,
purchase_bill_id			int	not null,
reference_no			nvarchar(25) null,
karagir_id				int not null,
job_work_no				int not null,
job_work_date			datetime null,
remarks					nvarchar(500) null,
is_deleted				bit not null,
created_by				int not null,
created_by_ip			nvarchar(25) not null,
created_datetime			datetime not null,
modified_by				int null,
modified_by_ip			nvarchar(25) null,
modified_datetime		datetime null,
deleted_by				int null,
deleted_by_ip			nvarchar(25) null,
deleted_datetime			datetime null,
branch_id				int not null,
working_period_id		int not null,
row_guid					uniqueidentifier not null,
constraint [pk_job_works_job_work_id] primary key clustered
	(
		[job_work_id]
	)
)
go

alter table job_works add constraint [DF_job_works_is_deleted] default(0) for[is_deleted]
go

alter table job_works add constraint [DF_job_works_created_datetime] default(getdate()) for[created_datetime]
go

alter table job_works add constraint [DF_job_works_row_guid] default(newid()) for[row_guid]
go


create table job_work_items
(
job_work_item_id		int identity(1,1) not null,
job_work_id			int not null,
inward_goods_id			int not null,
item_qty					decimal(18,2) not null,
rate					decimal(18,2) null,
cut_mtrs				decimal(18,2) null,
remarks					nvarchar(500) null,
is_deleted				bit not null,
created_by				int not null,
created_by_ip			nvarchar(25) not null,
created_datetime			datetime not null,
modified_by				int null,
modified_by_ip			nvarchar(25) null,
modified_datetime		datetime null,
deleted_by				int null,
deleted_by_ip			nvarchar(25) null,
deleted_datetime			datetime null,
row_guid					uniqueidentifier not null,
constraint [pk_job_work_items_job_work_item_id] primary key clustered
	(
		[job_work_item_id]
	)
)
go

alter table job_work_items add constraint [DF_job_work_items_is_deleted] default(0) for[is_deleted]
go

alter table job_work_items add constraint [DF_job_work_items_created_datetime] default(getdate()) for[created_datetime]
go

alter table job_work_items add constraint [DF_job_work_items_row_guid] default(newid()) for[row_guid]
go


--insert into dbo.menus
--(menu_group_id, menu_name, page_link, menu_sequence, is_deleted, created_by, created_by_ip, created_datetime)
--values
--(2, 'Job Work', 'Purchase/JobWork', 5.00, 0, 1, '::1', GETDATE())

select top 1 * from dbo.menus m
order by m.menu_id desc

select * from dbo.role_permissions 

insert into dbo.role_permissions
(role_id, menu_group_id, menu_id, add_permission, view_permission, edit_permission, delete_permission, is_deleted, created_by, created_by_ip, created_datetime)
values
(1, 2, 32, 1, 1, 1, 1, 0, 1, '::1', GETDATE())

select pb.purchase_bill_no, ps.purchase_bill_id, l.location_name
from dbo.pkg_Slips ps
inner join dbo.purchase_bills pb ON ps.purchase_bill_id = pb.purchase_bill_id 
inner join dbo.locations l ON ps.to_location_id = l.location_id
where 
--not ps.karagir_id is null
--and 
ps.is_deleted = 0
and l.location_type_id = 3

select pbi.purchase_bill_item_id, pbi.item_id, i.item_name, iq.item_quality, pbi.purchase_qty, pbi.unit_of_measurement_id, gri.goods_receipt_item_id
from dbo.purchase_bill_items pbi
inner join dbo.items i ON pbi.item_id = i.item_id
inner join dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
inner join dbo.goods_receipt_items gri ON pbi.purchase_bill_item_id = gri.purchase_bill_item_id
where pbi.purchase_bill_id = 312

select inw.inward_id, inw.inward_no, i.item_name, iq.item_quality, igd.inward_qty, igd.unit_of_measurement_id
from dbo.inwards inw
inner join dbo.inward_goods_details igd ON inw.inward_id = igd.inward_id
inner join dbo.locations l ON inw.from_location_id = l.location_id
inner join dbo.items i ON igd.item_id = i.item_id
inner join dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
where igd.goods_receipt_item_id = 1300
and igd.is_deleted = 0
and l.location_type_id = 3


---------------- XXXXXXXXXXXXXXXXXXXX - xxxxxxxxxxxxxxx

--- stock of NTC
select ps.pkg_slip_id, ps.pkg_slip_date, pb.purchase_bill_no, i.item_name + ' ' + iq.item_quality, 
v.client_address_name, pbi.bale_no, psi.pkg_qty, l.location_name , o.location_id
from dbo.outwards o
inner join dbo.outward_goods_details ogd ON o.outward_id = ogd.outward_id
inner join dbo.pkg_slip_items psi ON ogd.pkg_slip_item_id = psi.pkg_slip_item_id
inner join dbo.pkg_slips ps ON psi.pkg_slip_id = ps.pkg_slip_id
inner join dbo.items i ON psi.item_id = i.item_id
inner join dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
inner join dbo.locations l ON o.location_id = l.location_id
inner join dbo.goods_receipt_items gri ON psi.goods_receipt_item_id = gri.goods_receipt_item_id
inner join dbo.purchase_bill_items pbi ON gri.purchase_bill_item_id = pbi.purchase_bill_item_id
inner join dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
inner join dbo.client_addressess v ON pb.vendor_id = v.client_address_id
where 
--i.item_name like '%lohi%'
ps.to_location_id = 3

--------------------------------------- changes on 08/12/2018


create table daily_receivable_payable
(
daily_rec_pay_id	int	identity(1,1) not null,
particulars				nvarchar(500) not null,
amount					decimal(18,2) not null,
comments				nvarchar(500) null,
receivable_payable		nvarchar(25) not null,
is_deleted				bit not null,
created_by				int not null,
created_by_ip			nvarchar(25) not null,
created_datetime			datetime not null,
modified_by				int null,
modified_by_ip			nvarchar(25) null,
modified_datetime		datetime null,
deleted_by				int null,
deleted_by_ip			nvarchar(25) null,
deleted_datetime			datetime null,
row_guid					uniqueidentifier not null,
constraint [pk_daily_receivable_payable_daily_rec_pay_id] primary key clustered
	(
		[daily_rec_pay_id]
	)
)
go

alter table daily_receivable_payable add constraint [DF_daily_receivable_payable_is_deleted] default(0) for[is_deleted]
go

alter table daily_receivable_payable add constraint [DF_daily_receivable_payable_created_datetime] default(getdate()) for[created_datetime]
go

alter table daily_receivable_payable add constraint [DF_daily_receivable_payable_row_guid] default(newid()) for[row_guid]
go

select * from dbo.menus_group

insert into dbo.menus_group
(menu_group, is_deleted, created_by, created_by_ip, created_datetime)
values
('Accounts', 0, 1, '::1', GETDATE())


insert into dbo.menus
(menu_group_id, menu_name, page_link, menu_sequence, is_deleted, created_by, created_by_ip, created_datetime)
values
(6, 'Daily Receivable Payable', 'Accounts/DailyReceivablePayable', 1.00, 0, 1, '::1', GETDATE())

select top 1 * from dbo.menus m
order by m.menu_id desc

select * from dbo.role_permissions 

insert into dbo.role_permissions
(role_id, menu_group_id, menu_id, add_permission, view_permission, edit_permission, delete_permission, is_deleted, created_by, created_by_ip, created_datetime)
values
(1, 6, 36, 1, 1, 1, 1, 0, 1, '::1', GETDATE())



create table job_work_items_mtr_adjustment
(
job_work_item_mtr_adjustment_id int identity(1,1) not null,
job_work_id				int not null,
reference_no			nvarchar(25) not null,
adjusted_mtrs			decimal(18,3) not null,
is_deleted				bit not null,
created_by				int not null,
created_by_ip			nvarchar(25) not null,
created_datetime			datetime not null,
modified_by				int null,
modified_by_ip			nvarchar(25) null,
modified_datetime		datetime null,
deleted_by				int null,
deleted_by_ip			nvarchar(25) null,
deleted_datetime			datetime null,
row_guid					uniqueidentifier not null,
constraint [pk_job_work_items_mtr_adjustment_job_work_item_mtr_adjustment_id] primary key clustered
	(
		[job_work_item_mtr_adjustment_id]
	)
)
go

alter table job_work_items_mtr_adjustment add constraint [DF_job_work_items_mtr_adjustment_is_deleted] default(0) for[is_deleted]
go

alter table job_work_items_mtr_adjustment add constraint [DF_job_work_items_mtr_adjustment_created_datetime] default(getdate()) for[created_datetime]
go

alter table job_work_items_mtr_adjustment add constraint [DF_job_work_items_mtr_adjustment_row_guid] default(newid()) for[row_guid]
go

alter table job_works
drop column reference_no
go


alter table sales_orders
add is_tax_inclusive bit
go

alter table sales_orders add constraint [DF_sales_orders_is_tax_inclusive] default(0) for[is_tax_inclusive]
go

alter table sales_orders_items drop column sale_qty_in_pcs
go

alter table sales_orders_items drop column sale_qty_in_mtrs
go

alter table sales_orders_items add order_qty decimal(18,2)
go

alter table sales_orders_items add unit_of_measurement_id int
go


UPDATE       pkg_slips
SET                inward_id = inw.inward_id
FROM            pkg_slip_items AS psi INNER JOIN
                         pkg_slips ON psi.pkg_slip_id = pkg_slips.pkg_slip_id INNER JOIN
                         inward_goods_details AS igd ON psi.goods_receipt_item_id = igd.goods_receipt_item_id AND psi.item_id = igd.item_id INNER JOIN
                         inwards AS inw ON igd.inward_id = inw.inward_id
WHERE        (inw.reference_type = 'goods receipt')


alter table pkg_slips add inward_id int null
go

select 
vwsds.sale_type,
vwsds.salesman,
vwsds.month_name,
vwsds.financial_year,
sum(vwsds.sale_qty * vwsds.sale_rate) as sale_value,
sum(vwsds.sale_qty * vwsds.wholesale_rate) as wholesale_value,
sum(vwsds.sale_qty * vwsds.retail_rate) as retail_value,
case when sum(vwsds.sale_qty * vwsds.sale_rate) <= sum(vwsds.sale_qty * vwsds.wholesale_rate) then
	'SALE BELOW WHOLESALE'
ELSE CASE WHEN
	sum(vwsds.sale_qty * vwsds.sale_rate) >= sum(vwsds.sale_qty * vwsds.retail_rate) then
	'SALE ABOVE RETAIL'
ELSE
	'BETWEEN WHOLESALE AND RETAIL RATE' END END AS remarks
from 
dbo.vw_salesmanwise_daily_sales vwsds
WHERE vwsds.salesman_id = 31
--and vwsds.month_name = 'Feb'
group by
vwsds.sale_type,
vwsds.salesman,
vwsds.month_name,
vwsds.month_no,
vwsds.working_period_id,
vwsds.financial_year
ORDER by
vwsds.month_no



insert into dbo.menus
(menu_group_id, menu_name, page_link, menu_sequence, is_deleted, created_by, created_by_ip, created_datetime)
values
(2, 'Purchase Order', 'Purchase/PurchaseOrder', 1.00, 0, 1, '::1', GETDATE())

select top 1 * from dbo.menus m
order by m.menu_id desc

select * from dbo.role_permissions 

insert into dbo.role_permissions
(role_id, menu_group_id, menu_id, add_permission, view_permission, edit_permission, delete_permission, is_deleted, created_by, created_by_ip, created_datetime)
values
(1, 2, 40, 1, 1, 1, 1, 0, 1, '::1', GETDATE())

USE [POS_Raheja_Dev]
GO

CREATE TABLE payment_terms
(
payment_term_id		int identity(1,1) not null,
term_short_code		nvarchar(25) not null,
term_short_desc		nvarchar(200) not null,
term_meaning		nvarchar(1000) null,
is_deleted			bit	NOT NULL,
created_by			int	NOT NULL,
created_by_ip		nvarchar(25) NOT NULL,
created_datetime	datetime NOT NULL,
modified_by			int NULL,
modified_by_ip		nvarchar(25) NULL,
modified_datetime	datetime NULL,
deleted_by			int NULL,
deleted_by_ip		nvarchar(25) NULL,
deleted_datetime	datetime NULL,
row_guid			uniqueidentifier NOT NULL	
CONSTRAINT [pk_payment_terms_payment_term_id] PRIMARY KEY CLUSTERED 
(
	[payment_term_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[payment_terms] ADD  CONSTRAINT [DF_payment_terms_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO

ALTER TABLE [dbo].[payment_terms] ADD  CONSTRAINT [DF_payment_terms_created_datetime]  DEFAULT (getdate()) FOR [created_datetime]
GO

ALTER TABLE [dbo].[payment_terms] ADD  CONSTRAINT [DF_payment_terms_row_guid]  DEFAULT (newid()) FOR [row_guid]
GO

INSERT INTO dbo.payment_terms
(term_short_code, term_short_desc, term_meaning, created_by, created_by_ip)
values
('1MD', '1 Month Credit', 'Monthly credit payment of a full month''s supply.', 1, '::1'),
('2MD', '2 Month Credit', 'Monthly credit payment of a full month''s supply plus an extra calendar month.', 1, '::1'),
('Bill Of Exchange', 'Bill Of Exchange', 'Also called a draft. This is a short-term unconditional order involving three parties. The first party (drawer) is the goods supplier, who addresses the bill to the second party (drawee), the buyer. The bill requires the buyer to pay immediately (site draft) or at a fixed future date, a set sum of money to a third party (or bearer of the bill).', 1, '::1'),
('CBS or CBD', 'Cash Before Shipment or Cash Before Delivery', 'Cash before shipment or cash before delivery. This scenario allows the goods producer to take a down payment before creating the product. The down payment helps reduce some risks involved with creation of the product. The balance must be made before the product will be shipped to the customer.', 1, '::1'),
('CND', 'Cash Next Delivery', 'Cash Next Deliver. Used when delivery of a specific good or goods is made regularly, such as weekly or monthly. The current delivery must be paid before the next delivery is initiated.',  1, '::1'),
('COD', 'Cash On Delivery', 'Cash On Delivery. Payment has not yet been made for the goods being delivered. Once delivered, payment is made. The sender assumes risks in this scenario. The goods might be damaged in transit and/or the recipient may decide not to pay.', 1, '::1'),
('Contra Payment', 'Contra Payment', 'Used when two companies owe each other. Usually each amount owed will be different. Rather than the companies sending full invoice payment to each other, the company owing more simply pays the difference between the two invoices. The might also be referred to as a contra asset or valuation allowance.', 1, '::1'),
('CWO', 'Cash With Order', 'Cash with order. This option can work well with customers for whom credit is not being extended. In other words, there is no "Net X" involved. The customer will need to supply payment in full before any goods will be produced and shipped. Payment must first be received and verified with the bank.', 1, '::1'),
('L/C', 'Letter Of Credit', 'Letter of credit. Allows a supplier to perform services for a customer who does not have a credit history with the supplier. Suppliers take a risk when extending credit to new customers. One way around this is to have the new customer pay with a L/C. This requires the customer to get approval for financing through the customer''s bank. If for some reason, the customer cannot pay the supplier, the bank will pay. This protects the buyer. On the hand, if the supplier doesn''t come through, the customer is not out anything. They can in fact use the L/C with a different supplier.', 1, '::1'),
('Net X', 'Net Payment', 'Payment is due X no. of days after invoice is received.', 1, '::1'),
('A/B Net X', 'Discounted Net Payment', 'Another way Net might be stated is with a discount. "X" still applies as before. "A" is a discount percentage while "B" is the number of days the invoice must be paid within to receive the discount. Here are a few examples:
1/10 Net 30 - Receive a 1% discount is paid within 10 days. Otherwise, the invoice is still due 30 days after being received.', 1, '::1'),
('PIA', 'Payment In Advance', 'Payment in advance. Similar to CWO. This arrangement requires payment in full before any goods or service will be delivered. Payment can come in the form of a letter of credit from a bank. This can also mean an acceptable guarantee of payment.', 1, '::1'),
('PP or Stage Payment', 'Progress Payment', 'Progress payments. Used when work is ongoing for a long period of time, as in the construction industry. Predetermined milestones or stages are set before the project begins. Once a milestone is reached and approved, a payment is made. Upon completion of the project, the balance is paid out. It is common for penalties to be applied when milestone dates slip.', 1, '::1'),
('RD', 'Rolling Deposit', 'Rolling deposit. Similar to CWO, this arrangement allows customers to receive goods but with restrictions on payment. It allows you to monitor a customer''s payment behavior before extending additional credit. The way it works is that a customer will supply receipt of a deposit that covers any credit limit you''ve offered them. The deposit is like a secured credit card. The customer is able to place orders that draw on their secured credit. There is usually no interest paid on the deposit.', 1, '::1')

drop table purchase_orders


CREATE TABLE [dbo].[purchase_orders](
	[purchase_order_id] [int] IDENTITY(1,1) NOT NULL,
	[vendor_id] [int] NOT NULL,
	[vendor_reference_no] nvarchar(25) NULL,
	[purchase_order_no] [int] NOT NULL,
	[purchase_order_date] [date] NOT NULL,
	[payment_term_id] int not null,
	[discount_rate_for_payment] decimal(18,2) null,
	[discount_applicable_before_payment_days] int null,
	[no_of_days_for_payment] int null,	
	[expected_delivery_date] datetime null,
	[remarks] nvarchar(500) null,
	[branch_id] [int] NULL,
	[working_period_id] [int] NULL,
	[is_deleted] [bit] NOT NULL,
	[created_by] [int] NOT NULL,
	[created_by_ip] [nvarchar](25) NOT NULL,
	[created_datetime] [datetime] NOT NULL,
	[modified_by] [int] NULL,
	[modified_by_ip] [nvarchar](25) NULL,
	[modified_datetime] [datetime] NULL,
	[deleted_by] [int] NULL,
	[deleted_by_ip] [nvarchar](25) NULL,
	[deleted_datetime] [datetime] NULL,
	[row_guid] [uniqueidentifier] NOT NULL	
 CONSTRAINT [pk_purchase_orders_purchase_order_id] PRIMARY KEY CLUSTERED 
(
	[purchase_order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[purchase_orders] ADD  CONSTRAINT [DF_purchase_orders_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO

ALTER TABLE [dbo].[purchase_orders] ADD  CONSTRAINT [DF_purchase_orders_created_datetime]  DEFAULT (getdate()) FOR [created_datetime]
GO

ALTER TABLE [dbo].[purchase_orders] ADD  CONSTRAINT [DF_purchase_orders_row_guid]  DEFAULT (newid()) FOR [row_guid]
GO

drop table purchase_order_items

CREATE TABLE purchase_order_items
(
purchase_order_item_id	int identity(1,1) not null,
purchase_order_id		int not null,
item_id					int not null,
design_id				int null,
color_id				int null,
no_of_bales				int	null,
order_qty				decimal(18,2)	null,
unit_of_measurement_id	int null,
order_rate				decimal(18,2)	not null,
fabric_cutout_length	int	null,
is_deleted				bit NOT NULL,
created_by				int NOT NULL,
created_by_ip			nvarchar(25) NOT NULL,
created_datetime		datetime NOT NULL,
modified_by				int NULL,
modified_by_ip			nvarchar(25) NULL,
modified_datetime		datetime NULL,
deleted_by				int NULL,
deleted_by_ip			nvarchar(25) NULL,
deleted_datetime		datetime NULL,
row_guid				uniqueidentifier NOT NULL	
CONSTRAINT [pk_purchase_order_items_purchase_order_item_id] PRIMARY KEY CLUSTERED 
(
	[purchase_order_item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[purchase_order_items] ADD  CONSTRAINT [DF_purchase_order_items_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO

ALTER TABLE [dbo].[purchase_order_items] ADD  CONSTRAINT [DF_purchase_order_items_created_datetime]  DEFAULT (getdate()) FOR [created_datetime]
GO

ALTER TABLE [dbo].[purchase_order_items] ADD  CONSTRAINT [DF_purchase_order_items_row_guid]  DEFAULT (newid()) FOR [row_guid]
GO

CREATE TABLE orders_status
(
order_status_id		int	identity(1,1) not null,
status_name			nvarchar(25) not null,
status_desc			nvarchar(500) not null,
status_sequence		decimal(18,2)	not null,
is_deleted			bit not null,
created_by			int NOT NULL,
created_by_ip		nvarchar(25) NOT NULL,
created_datetime	datetime NOT NULL,
modified_by			int NULL,
modified_by_ip		nvarchar(25) NULL,
modified_datetime	datetime NULL,
deleted_by			int NULL,
deleted_by_ip		nvarchar(25) NULL,
deleted_datetime	datetime NULL,
row_guid			uniqueidentifier NOT NULL,
CONSTRAINT [pk_orders_status_order_status_id] PRIMARY KEY CLUSTERED 
(
	[order_status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[orders_status] ADD  CONSTRAINT [DF_orders_status_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO

ALTER TABLE [dbo].[orders_status] ADD  CONSTRAINT [DF_orders_status_created_datetime]  DEFAULT (GETDATE()) FOR [created_datetime]
GO

ALTER TABLE [dbo].[orders_status] ADD  CONSTRAINT [DF_orders_status_row_guid]  DEFAULT (NEWID()) FOR [row_guid]
GO

INSERT INTO dbo.orders_status
(
	status_name, status_desc, status_sequence, created_by, created_by_ip
)
values
('Draft', 'Order Created and is yet to be sent to Vendor.', 1.0, 1, '::1'),
('Issued', 'Order has successfully been sent to Vendor.', 2.0, 1, '::1'),
('Partially Received', 'Some portion of order items has been received from the Vendor.', 3.0, 1, '::1'),
('Received', 'All the ordered items has been received from the Vendor.', 4.0, 1, '::1'),
('Cancelled', 'Order has been cancelled.', 5.0, 1, '::1')

alter table purchase_orders
add order_status_id	int
go


create table purchase_types
(
purchase_type_id	int identity(1,1) not null,
purchase_type		nvarchar(25) not null,
is_deleted			bit not null,
created_by			int not null,
created_by_ip		nvarchar(25) not null,
created_datetime	datetime not null,
modified_by			int null,
modified_by_ip		nvarchar(25) null,
modified_datetime	datetime null,
deleted_by			int null,
deleted_by_ip		nvarchar(25) null,
deleted_datetime	datetime null,
row_guid			uniqueidentifier not null,
constraint [pk_purchase_types_purchase_type_id] primary key clustered
	(
		[purchase_type_id]
	)
) ON [PRIMARY]
GO

alter table purchase_types add constraint [DF_purchase_types_is_deleted] default(0) for[is_deleted]
go

alter table purchase_types add constraint [DF_purchase_types_created_datetime] default(GETDATE()) for[created_datetime]
go

alter table purchase_types add constraint [DF_purchase_types_row_guid] default(NEWID()) for[row_guid]
go

insert into dbo.purchase_types
(purchase_type, created_by, created_by_ip)
values
('Sales Item Purchase', 1, '::1'),
('Misc. Purchase', 1, '::1')



create table sales_schemes
(
sales_scheme_id		int	identity(1,1) not null,
brand_id			int null,
item_category_id	int null,
item_id				int null,
discount_percent	decimal(18,2) null,
discount_amount		decimal(18,2) null,
max_discount_amount	decimal(18,2) null,
buy_qty				int null,
free_qty			int null,
sale_start_date		date not null,
sale_end_date		date not null,
branch_id			int not null,
is_deleted			bit not null,
created_by			int not null,
created_by_ip		nvarchar(25) not null,
created_datetime	datetime not null,
modified_by			int null,
modified_by_ip		nvarchar(25) null,
modified_datetime	datetime null,
deleted_by			int null,
deleted_by_ip		nvarchar(25) null,
deleted_datetime	datetime null,
row_guid			uniqueidentifier not null,
constraint [pk_sales_schemes_sales_scheme_id] primary key clustered
	(
		sales_scheme_id
	)
) ON [PRIMARY]
GO

alter table sales_schemes add constraint [DF_sales_schemes_is_deleted] default(0) for[is_deleted]
go

alter table sales_schemes add constraint [DF_sales_schemes_created_datetime] default(GETDATE()) for[created_datetime]
go

alter table sales_schemes add constraint [DF_sales_schemes_row_guid] default(newid()) for[row_guid]
go


insert into dbo.menus
(menu_group_id, menu_name, page_link, menu_sequence, created_by, created_by_ip)
values
(1, 'Sales Scheme', 'Masters/SalesScheme', 7, 1, '::1')

insert into dbo.role_permissions
(role_id, menu_group_id, menu_id, add_permission, view_permission, edit_permission, delete_permission, created_by, created_by_ip)
values
(1, 1, 37, 1, 1, 1, 1, 1, '::1')

alter table client_addressess
add 
mobile_no_1 varchar(10) null,
mobile_no_2 varchar(10) null
go

CREATE TABLE client_categories
(
client_category_id	int	identity(1,1) not null,
client_category		nvarchar(25) not null,
is_deleted			bit not null,
created_by			int not null,
created_by_ip		nvarchar(25) not null,
created_datetime	datetime not null,
modified_by			int null,
modified_by_ip		nvarchar(25) null,
modified_datetime	datetime null,
deleted_by			int null,
deleted_by_ip		nvarchar(25) null,
deleted_datetime	datetime null,
row_guid			uniqueidentifier not null,
constraint [pk_client_categories_client_category_id] primary key clustered
	(
		client_category_id
	)
) ON [PRIMARY]
GO

alter table client_categories add constraint [DF_client_categories_is_deleted] default(0) for[is_deleted]
go

alter table client_categories add constraint [DF_client_categories_created_datetime] default(GETDATE()) for[created_datetime]
go

alter table client_categories add constraint [DF_client_categories_row_guid] default(newid()) for[row_guid]
go

insert into dbo.client_categories
(client_category, created_by, created_by_ip)
values
('Wholesale', 1, '::1' ),
('Retail', 1, '::1' )



update dbo.item_rates_for_customer_categories set is_deleted = 1 where customer_category_item_rate_id in (8854,8855,8856)

insert into dbo.sales_schemes
(brand_id, item_category_id, item_id, discount_percent, discount_amount, max_discount_amount, buy_qty, free_qty,
sale_start_date, sale_end_date, branch_id, is_deleted, created_by, created_by_ip)
values																		  
--(169,17,1259,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1260,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1261,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1436,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1438,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1439,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1440,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1253,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1257,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1268,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1258,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1265,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1263,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1254,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1262,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1264,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1269,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1437,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1266,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1267,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1435,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1256,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1582,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,17,1255,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(169,58,2251,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,679,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,1281,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,23,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,710,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,1606,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,34,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,25,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,38,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,44,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,41,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,66,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,75,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,68,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,69,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,692,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,16,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,84,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,24,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,71,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,234,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,120,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,167,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,80,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,680,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(33,29,2054,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(121,29,626,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(121,29,1803,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(51,29,2315,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(51,29,1925,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(76,9,794,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(76,29,239,50, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(189,29,1819,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(189,29,1978,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(189,29,1721,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(189,29,1717,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(189,29,1684,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(189,29,1979,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(189,29,1501,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(189,29,1820,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(189,29,1816,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(189,29,1720,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(179,29,1360,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(179,29,1359,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(179,29,1357,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(179,29,1356,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(179,29,1358,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(179,29,1363,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(179,29,1364,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(179,29,1362,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(179,29,1365,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(179,29,1361,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(217,1,2039,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(217,1,2193,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(217,1,2194,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(217,1,2195,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(223,1,2242,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(223,1,2243,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(223,1,2244,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(223,1,2207,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(61,29,168,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(116,17,607,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(97,29,490,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(115,17,595,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(115,17,604,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(115,17,608,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(156,17,1058,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(156,17,1057,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(156,17,1059,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(156,17,1061,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(156,17,1060,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(77,29,241,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(77,29,242,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(226,29,2216,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,29,461,50, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,29,244,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,29,245,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,29,243,50, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,29,247,50, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,1,534,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,1,246,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,1,531,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,611,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,615,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,585,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,591,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,587,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,614,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,610,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,612,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,616,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,581,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,613,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,605,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,583,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,606,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(79,17,589,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(80,29,248,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(80,1,535,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,518,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,396,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,676,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,250,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,435,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,434,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,251,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,95,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,123,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,254,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,255,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,122,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,257,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,258,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,259,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,457,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,264,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,438,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,266,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,265,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,439,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,267,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,268,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,253,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,73,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,79,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,688,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,261,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,1486,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,67,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,48,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,53,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,50,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,56,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,252,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,567,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,169,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,62,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,47,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,59,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,51,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,792,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,60,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,256,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,46,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,57,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,262,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,65,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,263,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,58,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,64,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,49,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,1329,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,1488,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,694,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,92,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,91,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,61,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,432,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,94,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,90,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,89,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,88,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,74,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,81,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,76,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,82,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,72,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,85,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,260,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(3,29,70,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,77,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,29,83,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,1,249,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,1,526,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,1,433,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,1,528,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,1,529,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(3,1,52,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(43,29,273,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(43,29,272,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(30,29,1073,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(30,29,32,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(30,29,39,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(30,29,275,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,175,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,1893,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,174,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,303,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,1894,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,1896,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,1999,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,306,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,642,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,45,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,305,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,1895,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,1779,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,307,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,1780,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,1782,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,304,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,586,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,2062,50, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,590,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,2020,50, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,1781,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,582,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,1098,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,593,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,594,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,2006,50, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,588,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,592,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,2134,50, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(38,29,276,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(84,4,371,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(84,4,370,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(29,28,1209,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(29,28,1217,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(191,29,1789,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(83,29,309,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(83,29,1949,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(83,29,1914,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(83,29,1915,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(83,29,829,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(83,29,830,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(83,29,833,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(83,29,831,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(83,29,832,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(83,29,834,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(83,29,310,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(83,29,2027,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(83,29,308,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(48,29,118,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(153,29,1041,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(153,29,1039,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(153,29,1037,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(153,29,1036,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(153,29,1043,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(153,29,1044,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(153,29,1038,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(153,29,1045,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(153,29,1042,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(153,29,1040,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(131,28,1193,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(131,28,1211,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(131,28,1210,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(131,28,1216,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(64,17,176,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(170,17,1274,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(170,17,1273,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(170,17,1272,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(10,1,3,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(36,29,331,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(36,29,332,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(36,29,337,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(36,29,1975,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(36,29,436,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(36,29,330,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(36,29,333,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(36,29,453,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(36,29,329,35, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(36,29,336,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(36,1,551,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1849,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1853,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1851,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1840,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1908,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1848,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1842,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1841,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1846,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1918,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1847,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1850,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1879,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1844,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1852,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1843,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(204,29,1845,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(112,29,576,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(193,29,1730,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(193,29,1729,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(208,29,1935,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(208,29,1934,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(208,29,2008,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(208,29,1933,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(208,29,2007,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(221,1,2107,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(167,29,1752,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(167,1,1711,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(167,1,1748,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(167,1,2204,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(167,1,1710,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(167,17,1882,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(167,17,1881,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(167,17,1937,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(167,17,1884,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(167,17,1883,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(167,17,1317,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,625,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,342,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,629,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,40,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(5,29,579,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,553,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,578,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,346,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,339,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,340,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,341,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,343,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,338,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,344,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(5,29,345,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(200,29,1810,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(200,29,1811,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(200,29,1808,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(200,29,1812,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(164,28,1213,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(100,1,532,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(161,17,1196,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(161,17,1192,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(34,29,1246,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(34,29,640,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(34,29,33,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(34,29,37,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(34,29,1247,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(34,29,641,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(34,29,1248,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(34,29,1250,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(34,29,1249,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(34,29,1480,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(34,29,1052,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(127,29,177,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(65,29,2313,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,445,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,119,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,1222,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,618,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,638,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,637,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,620,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,619,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,540,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,549,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(56,29,178,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,442,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,577,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(56,29,179,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,443,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,180,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,157,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,451,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,543,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,454,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,568,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(49,29,569,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,2335,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,1406,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,2336,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,1401,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,1407,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,1402,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,2337,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,2338,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,1408,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,1403,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,2339,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,2340,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,1404,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,1409,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,1405,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,2341,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,1410,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,1374,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,1375,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,9,1376,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,2017,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,655,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,87,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(1,29,126,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,656,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,669,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,663,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,664,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,660,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,86,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(1,29,1320,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,1319,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,689,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,657,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,1108,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,1392,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,1394,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,184,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,1393,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,1396,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,183,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,127,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,661,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,2016,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,670,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,668,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,654,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,128,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,182,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,1910,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,1912,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,1913,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,1911,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,1987,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,1989,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,29,1988,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,4,2026,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,17,1460,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(1,28,2181,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(4,29,524,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(2,29,471,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(2,29,474,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(2,29,1955,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(2,29,485,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(2,29,523,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(2,29,1400,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(2,29,520,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(2,29,521,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(2,29,1829,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(117,29,1976,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(117,29,1731,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(117,29,1977,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(117,29,1860,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(117,29,1861,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(117,29,1732,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(117,29,617,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(117,29,1831,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(85,4,381,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(85,4,1450,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(85,4,380,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(66,29,22,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(66,29,2227,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(60,28,2184,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(60,28,2397,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(60,28,189,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(60,28,2031,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(60,28,188,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(60,28,1207,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(60,28,1754,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(60,28,2032,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(60,28,2294,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(111,29,636,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(111,29,1857,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(111,29,1786,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(111,29,1785,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(111,29,1784,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(111,29,573,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(111,29,1783,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(67,1,96,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(67,1,190,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(42,1,2187,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(42,1,113,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(68,29,2123,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(68,29,1991,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(68,29,1990,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(68,29,2280,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(68,29,191,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(68,29,2124,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(68,29,2122,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(68,29,1124,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(68,29,2301,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(158,29,1576,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(158,29,1575,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(158,29,1572,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(158,29,1601,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(158,29,1602,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(158,29,1603,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(158,29,1573,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(158,29,1574,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(158,29,1099,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(158,29,1100,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(158,29,1101,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(158,29,1102,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(45,1,106,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(58,29,160,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(58,29,2381,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(58,29,1832,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(58,29,1872,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(58,29,1833,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(58,29,1871,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(58,29,596,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(32,29,1117,50, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(32,1,1084,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(32,1,1082,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(32,1,1085,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(32,17,1146,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(32,28,1194,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(32,28,1212,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(32,28,1537,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(126,29,648,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(126,29,649,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(126,29,651,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(126,29,647,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(126,29,653,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(126,29,652,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(126,29,650,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(126,29,806,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(126,29,807,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(126,29,1049,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(126,29,1331,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(126,29,805,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(126,29,1050,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(165,28,1214,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(165,28,1215,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(99,29,2174,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(99,29,2173,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(181,9,1418,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(181,9,1419,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1766,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1728,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1961,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1956,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1963,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1957,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1958,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1960,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1962,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1959,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1767,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1774,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1773,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1777,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1770,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1769,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1776,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1768,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1772,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1771,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1775,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(192,29,1778,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(212,29,1973,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(214,29,2013,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(212,29,2010,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(122,29,677,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(122,29,697,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(122,29,631,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(122,29,698,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(122,29,674,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(234,29,2410,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(213,29,1996,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(93,29,447,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(93,29,575,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(93,29,574,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(205,1,1916,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(205,1,2163,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(205,1,1928,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(205,1,1929,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(205,1,1930,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(205,1,1931,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(106,29,552,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(7,29,1104,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(7,29,20,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(7,29,4,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(7,29,12,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(7,29,13,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(90,29,422,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(90,29,423,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(90,29,421,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,476,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,467,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,1907,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,511,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,473,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,466,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,512,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,525,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,1791,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,449,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,1788,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,478,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,456,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,1793,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,1138,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,1794,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,516,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,507,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,29,1792,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,533,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,200,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,446,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,195,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,455,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,459,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,463,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,198,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,465,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,1756,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,1755,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,458,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,197,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,2029,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(18,1,196,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(39,9,97,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(39,9,159,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(39,29,2000,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(201,58,1809,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(59,1,161,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,2317,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,1972,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,1965,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,1971,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,2316,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,1997,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,1964,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,1998,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,2318,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,1970,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,2319,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,2323,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,1967,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,1966,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,1969,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(211,29,1968,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(55,1,133,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(104,29,554,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(104,29,548,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(94,29,470,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(94,29,450,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(145,17,892,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(145,17,867,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(145,17,866,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(145,17,865,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(145,17,893,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(185,29,2395,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(185,29,1459,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(185,29,1458,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(103,29,1932,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(103,29,1952,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(103,29,547,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(103,29,1950,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(103,29,1951,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(206,29,2009,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(206,29,1917,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(105,29,550,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(177,29,1983,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(177,29,1985,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(177,29,1986,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(177,29,1982,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(177,29,1337,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(177,29,2131,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(177,29,2130,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(177,29,2071,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(177,29,2072,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(177,1,2025,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(177,1,1984,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(177,1,2073,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2097,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2279,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2093,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1738,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1735,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1733,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1736,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1734,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1596,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1472,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1471,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1739,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1737,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1595,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1470,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1597,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1594,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,700,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2264,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2101,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,397,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,696,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,675,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,691,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2022,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,395,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,394,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,393,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,392,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,398,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,202,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,203,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,690,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,401,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,687,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,425,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2268,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1244,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2266,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2215,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1484,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2170,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2222,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2129,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,201,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1534,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1541,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2333,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2299,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2284,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2367,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2236,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2257,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1760,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2261,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2176,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2092,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2281,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2286,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2260,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2256,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2175,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2188,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2295,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2178,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2127,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2223,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2267,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,29,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,695,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1584,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1669,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1569,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1587,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1570,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1567,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1566,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1568,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1563,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1585,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1590,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1562,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1565,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1589,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1588,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1571,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1586,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1564,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1583,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1398,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1453,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,635,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,630,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1763,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2096,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1764,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,628,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1715,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1716,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,413,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,634,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,414,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,633,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,407,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,412,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,437,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,408,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,410,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,411,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,409,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,632,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2125,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2099,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2228,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2102,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1535,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1540,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2300,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2128,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2296,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2285,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1542,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1560,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2091,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1554,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1591,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1553,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1556,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1473,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1561,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1592,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1555,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1557,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1474,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1593,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1559,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1558,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1680,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2098,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,400,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1817,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,406,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,403,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,404,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,405,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,402,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,416,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2235,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,678,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,399,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1506,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2126,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,2100,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,29,1765,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,4,1577,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,4,1579,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,4,1578,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,4,378,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,4,1454,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,4,1455,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,4,2297,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,4,2298,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,4,1456,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,17,1858,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,17,609,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,17,1902,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,17,1901,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,17,1903,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,28,1690,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,28,2307,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,28,2345,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(35,28,2238,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(71,30,2374,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,282,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,1612,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,1613,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,1609,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,1610,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,324,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,1627,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,320,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,325,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,326,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,323,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,328,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,321,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,318,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,327,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,319,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,322,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,317,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,1611,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,1614,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,1184,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,299,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,1628,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,316,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,288,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,279,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,300,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,290,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,296,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,278,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,4,314,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,34,1549,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,34,1544,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,34,1546,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,34,1548,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,34,1550,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,34,1551,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,34,1543,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,34,1547,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,2040,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,1827,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,2399,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,2375,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,2373,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,1615,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,2302,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,1825,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,1826,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,1790,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,2303,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,2159,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,1744,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,1745,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,1821,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,2293,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,2376,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,2004,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,30,2005,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,51,1552,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,51,1742,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(81,51,1828,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(14,29,1072,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(14,29,43,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(14,29,8,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(14,29,7,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(14,29,1074,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(14,29,14,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(14,29,15,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(96,29,484,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(17,29,509,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(17,29,508,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(17,29,510,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(17,29,522,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(17,29,659,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(17,1,537,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(17,28,1505,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(17,28,502,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(17,28,504,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(17,28,499,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(17,28,506,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(17,28,503,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	)
--,

--(17,28,505,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(17,28,1823,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(70,29,11,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(41,29,667,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(41,29,802,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(41,29,99,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(82,4,372,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(82,4,2145,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(82,4,2146,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(82,4,2144,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(82,4,376,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(82,4,379,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(82,4,297,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(82,4,373,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(82,4,294,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(82,4,301,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(82,4,377,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(82,17,646,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(166,29,2396,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(166,17,1225,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(166,17,1226,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(28,28,1208,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(216,29,2018,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(216,29,2019,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(57,29,158,15, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(209,1,1939,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(209,1,1938,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(209,1,1941,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(209,1,1940,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(113,29,580,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(89,29,440,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(89,29,494,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(89,29,491,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(124,17,645,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(37,1,42,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(92,29,468,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(102,29,544,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(102,29,545,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(129,29,693,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(129,29,699,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(110,29,571,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(110,29,597,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(110,29,706,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(110,29,572,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(110,29,707,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(110,29,599,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(110,29,600,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(110,29,601,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(40,1,98,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'		),
--(40,1,162,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(40,1,163,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(123,29,639,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,29,452,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,280,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,347,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,219,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,231,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,356,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,217,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,348,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,358,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,229,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,1350,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,367,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,223,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,360,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,350,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,351,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,352,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,354,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,1759,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,369,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,221,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,366,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,368,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,359,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,353,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,227,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,361,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,1428,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,357,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,215,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,363,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,365,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,1426,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,225,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,362,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,233,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,386,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,355,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,364,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,1424,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,385,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,1096,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,349,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,383,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,218,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,230,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,295,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,216,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,285,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,298,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,228,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,1349,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,222,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,292,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,293,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,274,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,220,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,315,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,374,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,226,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,277,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,1427,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,271,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,214,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,1425,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,224,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,289,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,232,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,1423,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,1097,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,4,287,30, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(73,17,643,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(114,29,584,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(178,1,1351,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(198,29,1795,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(198,29,1805,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(198,29,1804,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(198,29,1806,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(157,29,1089,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(157,29,1290,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(157,29,1091,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(157,29,1087,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(157,29,1291,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(157,29,1090,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(157,29,1088,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(95,29,460,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(95,29,462,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
--(95,1,558,25, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	)

(33,6,1481,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(152,6,1011,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(189,2,1618,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(171,6,2045,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(171,6,2044,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(171,6,1299,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(171,6,1500,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(171,2,2042,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(171,2,2043,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(61,2,714,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(116,6,1016,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(180,2,1385,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(168,2,2034,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(168,2,2035,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(168,2,1878,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(168,2,1230,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(168,2,1325,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(151,2,916,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(172,2,1300,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(172,2,1377,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(149,2,903,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(135,6,1002,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(135,6,1012,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(135,6,736,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(135,2,1886,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(135,2,971,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(135,2,812,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(135,2,1885,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(135,2,761,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(135,38,1156,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(135,38,1153,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(3,6,1068,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(3,2,1189,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(3,2,899,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	  ),
(3,2,864,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	  ),
(3,2,796,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	  ),
(3,2,1188,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(3,2,795,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	  ),
(3,38,1446,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(132,6,727,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(131,2,713,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(24,6,983,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(24,6,985,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(24,6,986,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(24,6,984,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(24,6,1004,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(24,6,1314,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(24,6,1121,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(24,6,1311,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(24,6,725,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(24,6,726,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(24,2,1723,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(24,2,1141,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(24,2,752,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(24,2,783,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(24,2,764,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(24,2,755,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(19,6,743,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(19,2,828,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(19,2,827,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(19,2,825,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(19,2,753,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(19,2,901,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(19,2,902,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(19,2,907,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(19,2,782,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(19,38,1159,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(155,6,1051,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(167,2,1443,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(222,2,2202,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(173,2,1301,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(173,2,1302,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(231,2,2371,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(130,2,711,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(1,6,1271,40, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(1,2,2388,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(1,2,2021,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(1,2,1328,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(1,2,1295,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,6,981,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,6,999,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,6,1000,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(15,6,1508,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(15,6,771,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,6,1417,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(15,6,766,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,6,17,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	  ),
(15,6,770,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,6,1119,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(15,6,1507,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(15,6,142,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,143,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,140,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,1231,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(15,2,144,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,803,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,146,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,18,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	  ),
(15,2,948,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,947,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,961,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,138,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,816,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,1022,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(15,2,141,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,804,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,835,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,1018,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(15,2,139,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,9,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	  ),
(15,2,868,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,891,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,906,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,19,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	  ),
(15,2,950,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,2,145,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(15,38,1164,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(15,38,1163,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(162,6,1202,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(162,6,1201,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(162,6,1199,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(162,6,1203,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(162,6,1198,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(162,6,1200,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(162,6,1204,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(85,6,2348,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(85,6,2142,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(85,6,1353,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(85,6,1352,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(85,6,1580,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(85,6,2403,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(85,2,2239,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(85,2,2143,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(85,2,2056,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(85,2,1873,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(85,2,1874,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(85,2,2057,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(23,6,744,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,6,723,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,6,134,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,6,135,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,1233,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(23,2,708,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,793,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,709,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,787,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,789,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,718,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,719,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,2068,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(23,2,716,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,136,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,775,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,786,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,717,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,137,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(23,2,791,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(143,6,800,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(143,2,2024,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,2218,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,1607,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,1502,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,2401,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,2292,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,2162,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,2161,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,2229,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,2164,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,2165,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,799,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(143,2,2028,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,2290,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,801,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(143,2,2217,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,1298,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,798,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(143,2,2291,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(143,2,2023,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(139,2,819,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(139,2,756,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(146,6,1354,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(146,2,895,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(160,6,2254,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(160,2,2255,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(160,2,1111,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(160,2,1112,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(160,2,1113,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(160,2,1110,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(160,2,1115,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(160,2,1114,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(218,2,2051,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(218,2,2052,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(218,2,2050,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(218,2,2049,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(32,6,1136,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,6,1135,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,6,1137,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,6,1134,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,6,1015,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,6,996,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,6,1010,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,6,1062,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,6,998,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,6,997,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,6,1093,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,6,1145,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,6,1372,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,6,1120,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,6,1123,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,6,785,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,6,773,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,1023,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,2,960,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,966,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,973,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,967,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,837,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,1218,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,2,1279,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,2,898,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,1238,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,2,959,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,894,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,1056,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,2,1054,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,2,778,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,1239,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,2,951,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,897,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,980,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,1539,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,2,952,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(32,2,1142,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,2,1055,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,2,1053,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,2,1031,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,2,1143,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,2,1355,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(32,38,1162,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(32,38,1155,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(32,38,1157,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(32,38,1310,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(134,6,729,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(134,2,1297,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(134,2,1294,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(134,2,1282,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(134,2,968,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(134,2,1277,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(134,2,1280,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(134,2,824,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(134,2,1296,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(134,2,1293,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(134,2,750,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(134,2,1292,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(134,38,1399,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(16,6,1993,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(16,6,1992,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(16,6,1478,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(16,6,1479,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(16,6,1477,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(16,6,1476,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(16,6,1475,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(16,2,2003,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(16,2,1237,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(16,2,721,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(16,2,21,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	  ),
(16,2,777,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(147,2,896,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(224,2,2208,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(7,2,1524,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,1519,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,1518,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,1521,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,1520,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,1522,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,1523,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,1516,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,1509,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,2203,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,1513,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,1510,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,1511,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(190,2,1512,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(7,2,1515,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,1514,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(7,2,1517,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(90,2,912,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(90,2,953,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(54,2,132,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,6,2230,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,6,1005,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,6,1007,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,6,1006,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,6,1008,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,6,1030,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,6,2063,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,6,2064,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,6,772,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,6,733,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,6,735,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,6,2065,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,6,1017,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,6,734,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,2,1289,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1526,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1529,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1528,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1527,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1525,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,2387,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,2390,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,2389,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,2386,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,2383,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,2384,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,2385,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1168,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1165,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,2391,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1169,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1288,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,2393,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,2392,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,969,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,2,972,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,2,1019,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1021,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,808,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,2,809,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,2,2067,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1020,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1286,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,815,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,2,836,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,2,2136,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1530,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,905,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,2,1167,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1166,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,2135,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,784,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,2,2066,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,904,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,2,1287,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1531,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,757,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(22,2,1533,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1532,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,2,1170,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(22,38,1161,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(138,6,1003,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(138,6,747,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(138,6,748,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(138,6,1232,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(138,2,774,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(148,2,900,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,6,979,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,6,995,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,6,982,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,6,977,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,6,1048,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(136,6,978,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,6,1122,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(136,6,738,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,6,1070,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(136,6,737,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,6,1064,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(136,6,1449,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(136,2,970,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,2,817,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,2,1275,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(136,2,810,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,2,758,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,2,762,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,2,754,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(136,38,1152,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(136,38,1151,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(136,38,1150,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(94,2,1076,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(94,2,917,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(94,2,1075,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(141,6,1118,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(141,6,776,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(141,2,826,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(141,38,1158,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(175,6,1995,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(175,2,2369,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(175,2,2192,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(175,2,2190,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(175,2,2394,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(175,2,2085,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(175,2,2086,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(175,2,2156,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(175,2,2155,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(175,2,1448,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(175,38,2133,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(103,2,911,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(183,6,1441,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(35,6,2359,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,6,2362,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,6,2113,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,6,1656,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,6,2246,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,6,2114,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,6,2354,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,6,1909,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,6,2115,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,6,2304,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,6,2070,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,6,2069,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,1722,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,2108,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,2200,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,2110,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,2346,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,2219,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,2347,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,2111,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,2370,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,2305,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,1149,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,1870,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,1869,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,2112,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(35,2,1713,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,2353,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,206,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,6,2201,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,2221,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,2205,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,2206,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,1946,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,2220,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,1947,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,2212,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,1009,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,768,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,6,1994,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,781,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,6,780,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,6,1243,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,769,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,6,1945,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,1944,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,2209,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,1813,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,1024,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,2265,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,1621,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,2211,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,207,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,6,1814,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,1724,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,6,1330,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,208,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,2,204,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,2,2357,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2356,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2355,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,1242,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2048,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,1378,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,1278,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,1876,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,813,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,2,2037,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2038,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2139,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2224,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2225,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,913,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,2,788,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,2,1727,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2140,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,1187,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2047,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2033,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2168,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,720,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,2,722,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,2,2167,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2036,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2046,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,910,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,2,1148,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2210,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,1877,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,2378,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,1066,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,1144,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(71,2,790,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,2,211,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,2,210,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,2,209,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,2,212,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(71,2,205,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(81,6,1107,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(81,2,1421,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(81,2,1106,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(137,6,739,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(137,6,740,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(137,2,965,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,6,1013,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,6,1014,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,6,994,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,989,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,991,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,988,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,990,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,987,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,992,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,993,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,749,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,730,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,1802,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,6,731,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,724,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,732,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,742,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,1172,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,6,1176,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,6,767,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,741,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,6,1175,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,6,1796,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,6,1800,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,6,1801,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,6,1799,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,6,2402,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,6,1178,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,1171,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,1787,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,1798,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,964,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,2,963,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,2,962,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,2,838,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,2,820,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,2,822,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,2,1081,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,818,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,2,1276,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,1797,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,1173,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,914,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,2,751,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,2,1177,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,908,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,2,759,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,2,1180,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,1179,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,1181,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,1182,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,1183,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,1174,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(20,2,949,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(20,38,1160,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(20,38,1154,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(21,6,1001,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(21,6,1069,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(21,6,1065,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(21,2,946,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(21,2,821,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(21,2,823,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(21,2,839,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(21,2,763,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(96,2,760,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(140,6,765,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(82,2,1538,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(86,6,2277,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(86,6,2278,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(86,6,2350,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(86,2,2351,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(86,2,2273,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(86,2,2274,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(86,2,2276,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(86,2,2382,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(86,2,2352,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(86,2,2275,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,6,2197,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,6,1892,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,6,2060,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,6,1890,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,6,1891,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,6,2199,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,2,148,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(53,2,147,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(53,2,131,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(53,2,153,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(53,2,156,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(53,2,2059,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,2,130,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(53,2,152,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(53,2,155,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(53,2,2196,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,2,1888,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,2,1889,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,2,2058,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,2,2053,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,2,149,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(53,2,150,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(53,2,1887,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(53,2,129,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(53,2,151,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(53,2,154,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(53,2,2198,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(144,2,811,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(25,6,1315,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(25,6,1313,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(25,6,956,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(25,6,1312,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(25,6,954,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(25,6,1067,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(25,2,1324,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(25,2,915,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(25,2,957,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(25,2,958,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(25,2,1493,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(25,2,1206,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(25,2,955,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'  ),
(25,2,1321,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(25,2,1140,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(25,2,1147,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(25,2,1323,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(25,2,1322,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(133,6,728,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(133,2,1386,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(159,2,1105,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(150,6,1063,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(150,2,909,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(142,6,779,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(142,2,814,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1' ),
(203,6,1837,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(203,6,1838,10, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(203,6,1839,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'),
(203,6,1836,20, 0.00, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')
(76,29,496, 0, 845, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
(76,29,239, 0, 845, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
(76,29,658, 0, 600, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
(91,29,427, 0, 1000, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
(39,1,464, 0, 1000, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
(89,29,418, 0, 1000, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
(89,29,489, 0, 1000, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
(89,1,559, 0, 1000, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	),
(37,1,536, 0, 1000, 0.00, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1'	)




    SELECT
		gri.goods_receipt_item_id,
		i.item_id,
		gc.hsn_code,
		dbo.udf_items_get_item_name_by_brand_category_and_quality( i.item_id) AS item_name,
		uom.unit_code,
		uom.unit_of_measurement_id,
		i.is_set,
		ISNULL(issi.item_set_sub_item_id,0) item_set_sub_item_id ,
		ir.is_sell_at_net_rate,
		ircc.flat_rate,
		ss.sales_scheme_id,
		ss.discount_percent,
		ss.discount_amount,
		'FLAT ' + CASE WHEN ss.discount_amount > 0 THEN 'Rs. ' + CAST(CONVERT(decimal(18,0), ss.discount_amount) AS nvarchar(10))
		ELSE CAST(CONVERT(decimal(18,0), ss.discount_percent) AS nvarchar(10)) + '% ' END + ' OFF' AS scheme,
		CASE WHEN ss.discount_percent > 0 THEN 'Cash Discount' ELSE 'Rate Diff' END AS type_of_discount
	FROM
		dbo.goods_receipt_items gri
	INNER JOIN
		dbo.purchase_bill_items pbi ON gri.purchase_bill_item_id = pbi.purchase_bill_item_id
	INNER JOIN
		dbo.items i ON pbi.item_id = i.item_id
	INNER JOIN
		dbo.item_categories ic ON i.item_category_id = ic.item_category_id
	INNER JOIN
		dbo.gst_categories gc ON ic.gst_category_id = gc.gst_category_id
	INNER JOIN
		dbo.units_of_measurements uom ON i.unit_of_measurement_id = uom.unit_of_measurement_id
	LEFT JOIN
		dbo.item_rates ir ON i.item_id = ir.item_id 
	LEFT JOIN
		dbo.item_rates_for_customer_categories ircc ON ir.item_rate_id = ircc.item_rate_id and ircc.is_deleted = 0 and ircc.flat_rate > 0 and ircc.customer_category_id = 3
	LEFT JOIN
		dbo.item_sets_sub_items issi ON i.item_id = issi.sub_item_id
	LEFT JOIN
		dbo.sales_schemes ss ON pbi.item_id = ss.item_id AND GETDATE() + 1 BETWEEN ss.sale_start_date AND ss.sale_end_date
	WHERE
		gri.goods_receipt_item_id = 1436
		AND gri.is_deleted = 0


select ss.sales_scheme_id, ss.discount_percent, ss.discount_amount
from dbo.sales_schemes ss
where ss.item_id = 1066
and GETDATE() + 1 BETWEEN ss.sale_start_date AND ss.sale_end_date



exec usp_sales_bills_get_sales_bill_details_by_working_period_sale_type_and_sales_bill_no 2, 1, 10672

exec usp_sales_bills_items_get_items_by_sales_bill_id 9112

select sb.working_period_id, * from dbo.sales_bills sb
where sb.sales_bill_no = 10777


select * from dbo.sales_bills_items sbi
where sbi.sales_bill_id = 1501

    SELECT
		sbi.sales_bill_item_id,
		sbi.sales_bill_id,
		sbi.goods_receipt_item_id,
		sbi.item_id,
		(
			SELECT
				dbo.udf_items_get_item_name_by_brand_category_and_quality (sbi.item_id)
		) AS item_name,
		gc.hsn_code,
		sbi.sale_qty,
		sbi.unit_of_measurement_id,
		uom.unit_code,
		sbi.sale_rate,
		(sbi.sale_qty * sbi.sale_rate) AS amount,
		sbi.type_of_discount,
		sbi.cash_discount_percent,
		sbi.discount_amount,
		sbi.rate_adjustment,
		sbi.rate_adjustment_remarks,
		(sbi.sale_qty * sbi.sale_rate) - sbi.discount_amount AS total_amount_after_discount,
		(select dbo.udf_sales_bills_items_get_item_amount_before_tax(sbi.sales_bill_item_id)) as amount_before_tax,
		sbi.gst_rate_id,
		gr.gst_rate,
		sbi.tax_id,
		gr.gst_name,
		CAST(ROUND((select dbo.udf_sales_bills_items_get_item_amount_before_tax(sbi.sales_bill_item_id)) * (gr.gst_rate / 100),2) AS decimal(18,2)) AS gst_amount,
		CAST(ROUND((select dbo.udf_sales_bills_items_get_item_amount_before_tax(sbi.sales_bill_item_id)) * (gr.gst_rate / 100) 
		+ (select dbo.udf_sales_bills_items_get_item_amount_before_tax(sbi.sales_bill_item_id)),2) AS decimal(18,2)) AS total_item_amount,
		sbi.remarks,
		ss.sales_scheme_id,
		ss.discount_percent,
		ss.discount_amount,
		sbi.row_guid,
		ROW_NUMBER() OVER (ORDER BY sbi.sales_bill_item_id) AS sr_no
	FROM
		dbo.sales_bills_items sbi
	INNER JOIN
		dbo.sales_bills sb ON sbi.sales_bill_id = sb.sales_bill_id
	INNER JOIN
		dbo.items i ON sbi.item_id = i.item_id
	INNER JOIN
		dbo.item_categories ic ON i.item_category_id = ic.item_category_id
	LEFT JOIN
		dbo.gst_categories gc ON ic.gst_category_id = gc.gst_category_id
	INNER JOIN
		dbo.units_of_measurements uom ON i.unit_of_measurement_id = uom.unit_of_measurement_id
	LEFT JOIN
		dbo.gst_rates gr ON sbi.gst_rate_id = gr.gst_rate_id
	LEFT JOIN
		dbo.sales_schemes ss ON sbi.sales_scheme_id = ss.sales_scheme_id AND sbi.item_id = ss.item_id 
		AND sb.sales_bill_date BETWEEN ss.sale_start_date AND ss.sale_end_date
	WHERE
		sbi.sales_bill_id = 9112
		AND sbi.is_deleted = 0
	ORDER BY
		sr_no



select b.brand_name, ic.item_category_name, i.item_name,
ss.discount_percent, ss.discount_amount, ss.max_discount_amount,
replace(convert(nvarchar(11), ss.sale_start_date, 106),' ','/') AS sale_start_date,
replace(convert(nvarchar(11), ss.sale_end_date, 106), ' ','/') AS sale_end_date
from dbo.sales_schemes ss
inner join dbo.brands b ON ss.brand_id = b.brand_id
inner join dbo.item_categories ic ON ss.item_category_id = ic.item_category_id
inner join dbo.items i ON ss.item_id = i.item_id

	SELECT
		b.brand_id,
		ic.item_category_id,
		iq.item_quality_id,
		i.item_id,
		b.brand_name,
		ic.item_category_name,
		iq.item_quality,
		i.item_name,
		vwirwr.wholesale_rate,
		vwirwr.retail_rate
	FROM
		dbo.items i
	INNER JOIN
		dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
	INNER JOIN
		dbo.item_categories ic ON i.item_category_id = ic.item_category_id
	INNER JOIN
		dbo.brands b ON i.brand_id = b.brand_id
	LEFT JOIN
		dbo.vw_item_rates_wholesale_and_retail_rate vwirwr ON i.item_id = vwirwr.item_id
	WHERE 
		not i.item_id in (
			select ss.item_id
			from dbo.sales_schemes ss
		)
	ORDER BY
		b.brand_name,
		ic.item_category_name,
		iq.item_quality,
		i.item_name

		insert into dbo.sales_schemes
(brand_id, item_category_id, item_id, discount_percent, discount_amount, max_discount_amount, buy_qty, free_qty,
sale_start_date, sale_end_date, branch_id, is_deleted, created_by, created_by_ip)
values
(51,11,570,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(51,11,124,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(51,11,1071,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(51,11,2179,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(51,11,2180,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(109,11,561,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(3,11,10,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(3,11,565,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(62,11,172,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(62,11,1318,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(62,11,170,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(62,11,101,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(62,11,173,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(62,11,541,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(62,11,171,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(62,11,745,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(43,11,102,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(43,11,270,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(191,11,1691,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(24,14,712,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(24,14,715,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(24,14,1077,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(9,30,1494,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(9,30,2002,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(9,36,1340,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(9,36,1346,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(9,36,1345,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(9,36,1447,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(9,36,1347,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(9,36,1341,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(9,36,1339,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(9,36,1344,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(9,36,1348,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(36,27,469,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(36,27,313,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(36,27,312,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(36,27,334,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(167,32,1229,15, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(167,32,1252,15, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,2329,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,2088,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,2327,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,2331,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,2330,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,2324,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,2328,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,2325,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,2087,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,1305,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,1306,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,1308,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,1307,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,1303,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,1309,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(174,32,1304,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(1,25,1236,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(1,25,185,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(1,25,186,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(1,8,1835,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(1,8,1413,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(1,8,1411,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(1,8,1414,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(1,8,1412,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(1,8,187,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(1,27,181,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(1,27,665,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(1,27,662,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(1,27,1186,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(1,27,666,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(1,32,2326,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(1,32,885,30, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')		,
(158,61,2075,15, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(158,61,2076,15, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(158,61,2077,15, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(158,61,2078,15, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(158,61,2079,15, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(27,32,1240,15, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(27,32,705,15, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(27,32,704,15, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(27,32,703,15, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(27,32,702,15, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(27,32,701,15, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(93,11,269,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(63,11,192,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(63,11,562,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(63,11,564,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(63,11,563,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(63,11,1536,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(63,11,746,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(63,11,1316,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(63,11,193,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(63,11,194,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(186,27,1465,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(186,27,1463,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(186,27,1466,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(186,27,1464,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(186,27,1467,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(17,11,566,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(17,11,539,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(17,27,481,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(17,27,492,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(17,27,480,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(17,27,495,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(17,27,488,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(17,27,486,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(17,27,475,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(17,27,472,25, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	,
(210,11,1948,20, 0, 0, 0, 0, '02/Apr/2019', '16/Apr/2019', 1, 0, 1, '::1')	
