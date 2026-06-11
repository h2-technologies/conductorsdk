using System.Reflection.Metadata;

namespace ConductorSdk.Models;

public class Transaction
{
  public TransactionType TransactionType;
  public string TransactionId;
  public string? TransactionLineId;
  public DateTimeOffset CreatedAt;
  public DateTimeOffset UpdatedAt;
  public (string Id, string FullName) Entity;
  public (string Id, string FullName) Account;
  public DateTimeOffset TransactionDate;
  public string? RefNumber;
  public string Amount;
  public (string Id, string FullName) Currency;
  public Decimal? ExchangeRate;
  public string? AmountInHomeCurrency;
  public string? Memo;
}

public class TransactionType
{
    // 1. Private constructor prevents creation of invalid types
    private TransactionType(string value, string displayName)
    {
        Value = value;
        DisplayName = displayName;
    }

    public string Value { get; }
    public string DisplayName { get; }

    // 2. Define all your specific available options
    public static TransactionType ArRefundCreditCard { get; } = new("ar_refund_credit_card", "AR Refund Credit Card");
    public static TransactionType Bill { get; } = new("bill", "Bill");
    public static TransactionType BillPaymentCheck { get; } = new("bill_payment_check", "Bill Payment Check");
    public static TransactionType BillPaymentCreditCard { get; } = new("bill_payment_credit_card", "Bill Payment Credit Card");
    public static TransactionType BuildAssembly { get; } = new("build_assembly", "Build Assembly");
    public static TransactionType Charge { get; } = new("charge", "Charge");
    public static TransactionType Check { get; } = new("check", "Check");
    public static TransactionType CreditCardCharge { get; } = new("credit_card_charge", "Credit Card Charge");
    public static TransactionType CreditCardCredit { get; } = new("credit_card_credit", "Credit Card Credit");
    public static TransactionType CreditMemo { get; } = new("credit_memo", "Credit Memo");
    public static TransactionType Deposit { get; } = new("deposit", "Deposit");
    public static TransactionType Estimate { get; } = new("estimate", "Estimate");
    public static TransactionType InventoryAdjustment { get; } = new("inventory_adjustment", "Inventory Adjustment");
    public static TransactionType Invoice { get; } = new("invoice", "Invoice");
    public static TransactionType ItemReceipt { get; } = new("item_receipt", "Item Receipt");
    public static TransactionType JournalEntry { get; } = new("journal_entry", "Journal Entry");
    public static TransactionType LiabilityAdjustment { get; } = new("liability_adjustment", "Liability Adjustment");
    public static TransactionType Paycheck { get; } = new("paycheck", "Paycheck");
    public static TransactionType PayrollLiabilityCheck { get; } = new("payroll_liability_check", "Payroll Liability Check");
    public static TransactionType PurchaseOrder { get; } = new("purchase_order", "Purchase Order");
    public static TransactionType ReceivePayment { get; } = new("receive_payment", "Receive Payment");
    public static TransactionType SalesOrder { get; } = new("sales_order", "Sales Order");
    public static TransactionType SalesReceipt { get; } = new("sales_receipt", "Sales Receipt");
    public static TransactionType SalesTaxPaymentCheck { get; } = new("sales_tax_payment_check", "Sales Tax Payment Check");
    public static TransactionType Transfer { get; } = new("transfer", "Transfer");
    public static TransactionType VendorCredit { get; } = new("vendor_credit", "Vendor Credit");
    public static TransactionType YtdAdjustment { get; } = new("ytd_adjustment", "YTD Adjustment");

    // 3. Static registry for lookups
    private static readonly Dictionary<string, TransactionType> _all = new()
    {
        { ArRefundCreditCard.Value, ArRefundCreditCard },
        { Bill.Value, Bill },
        { BillPaymentCheck.Value, BillPaymentCheck },
        { BillPaymentCreditCard.Value, BillPaymentCreditCard },
        { BuildAssembly.Value, BuildAssembly },
        { Charge.Value, Charge },
        { Check.Value, Check },
        { CreditCardCharge.Value, CreditCardCharge },
        { CreditCardCredit.Value, CreditCardCredit },
        { CreditMemo.Value, CreditMemo },
        { Deposit.Value, Deposit },
        { Estimate.Value, Estimate },
        { InventoryAdjustment.Value, InventoryAdjustment },
        { Invoice.Value, Invoice },
        { ItemReceipt.Value, ItemReceipt },
        { JournalEntry.Value, JournalEntry },
        { LiabilityAdjustment.Value, LiabilityAdjustment },
        { Paycheck.Value, Paycheck },
        { PayrollLiabilityCheck.Value, PayrollLiabilityCheck },
        { PurchaseOrder.Value, PurchaseOrder },
        { ReceivePayment.Value, ReceivePayment },
        { SalesOrder.Value, SalesOrder },
        { SalesReceipt.Value, SalesReceipt },
        { SalesTaxPaymentCheck.Value, SalesTaxPaymentCheck },
        { Transfer.Value, Transfer },
        { VendorCredit.Value, VendorCredit },
        { YtdAdjustment.Value, YtdAdjustment }
    };

    // 4. Safe mapping methods
    public static TransactionType FromString(string value)
    {
        if (value == null) return null;
        return _all.TryGetValue(value.ToLowerInvariant(), out var type) ? type : null;
    }

    public static implicit operator string(TransactionType type) => type?.Value;
    public override string ToString() => Value;
}