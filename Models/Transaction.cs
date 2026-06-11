using System.Reflection.Metadata;
using System.Text.Json.Serialization;

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

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TransactionType
{
    [JsonStringEnumMemberName("ar_refund_credit_card")] ArRefundCreditCard,
    [JsonStringEnumMemberName("bill")] Bill,
    [JsonStringEnumMemberName("bill_payment_check")] BillPaymentCheck,
    [JsonStringEnumMemberName("bill_payment_credit_card")] BillPaymentCreditCard,
    [JsonStringEnumMemberName("build_assembly")] BuildAssembly,
    [JsonStringEnumMemberName("charge")] Charge,
    [JsonStringEnumMemberName("check")] Check,
    [JsonStringEnumMemberName("credit_card_charge")] CreditCardCharge,
    [JsonStringEnumMemberName("credit_card_credit")] CreditCardCredit,
    [JsonStringEnumMemberName("credit_memo")] CreditMemo,
    [JsonStringEnumMemberName("deposit")] Deposit,
    [JsonStringEnumMemberName("estimate")] Estimate,
    [JsonStringEnumMemberName("inventory_adjustment")] InventoryAdjustment,
    [JsonStringEnumMemberName("invoice")] Invoice,
    [JsonStringEnumMemberName("item_receipt")] ItemReceipt,
    [JsonStringEnumMemberName("journal_entry")] JournalEntry,
    [JsonStringEnumMemberName("liability_adjustment")] LiabilityAdjustment,
    [JsonStringEnumMemberName("paycheck")] Paycheck,
    [JsonStringEnumMemberName("payroll_liability_check")] PayrollLiabilityCheck,
    [JsonStringEnumMemberName("purchase_order")] PurchaseOrder,
    [JsonStringEnumMemberName("receive_payment")] ReceivePayment,
    [JsonStringEnumMemberName("sales_order")] SalesOrder,
    [JsonStringEnumMemberName("sales_receipt")] SalesReceipt,
    [JsonStringEnumMemberName("sales_tax_payment_check")] SalesTaxPaymentCheck,
    [JsonStringEnumMemberName("transfer")] Transfer,
    [JsonStringEnumMemberName("vendor_credit")] VendorCredit,
    [JsonStringEnumMemberName("ytd_adjustment")] YtdAdjustment
}