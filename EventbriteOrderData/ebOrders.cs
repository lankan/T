using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pagination
{
    public int object_count { get; set; }
    public int page_number { get; set; }
    public int page_size { get; set; }
    public int page_count { get; set; }
}

public class BasePrice
{
    public string display { get; set; }
    public string currency { get; set; }
    public int value { get; set; }
    public string major_value { get; set; }
}

public class EventbriteFee
{
    public string display { get; set; }
    public string currency { get; set; }
    public int value { get; set; }
    public string major_value { get; set; }
}

public class Gross
{
    public string display { get; set; }
    public string currency { get; set; }
    public int value { get; set; }
    public string major_value { get; set; }
}

public class PaymentFee
{
    public string display { get; set; }
    public string currency { get; set; }
    public int value { get; set; }
    public string major_value { get; set; }
}

public class Tax
{
    public string display { get; set; }
    public string currency { get; set; }
    public int value { get; set; }
    public string major_value { get; set; }
}

public class Costs
{
    public BasePrice base_price { get; set; }
    public EventbriteFee eventbrite_fee { get; set; }
    public Gross gross { get; set; }
    public PaymentFee payment_fee { get; set; }
    public Tax tax { get; set; }
}

public class Addresses
{
}

public class Profile
{
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string name { get; set; }
    public Addresses addresses { get; set; }
}

public class DynamicAssociation
{
    public string type { get; set; }
    public string value { get; set; }
    public string created { get; set; }
}

public class SecondaryCode
{
    public string type { get; set; }
    public string value { get; set; }
    public string created { get; set; }
}

public class Barcode
{
    public string status { get; set; }
    public string barcode { get; set; }
    public string created { get; set; }
    public int checkin_type { get; set; }
    public string changed { get; set; }
    public DynamicAssociation dynamic_association { get; set; }
    public string checkin_method { get; set; }
    public SecondaryCode secondary_code { get; set; }
}

public class Answer
{
    public string question { get; set; }
    public string type { get; set; }
    public string question_id { get; set; }
}

public class Attendee
{
    public object team { get; set; }
    public Costs costs { get; set; }
    public string resource_uri { get; set; }
    public string id { get; set; }
    public string changed { get; set; }
    public string created { get; set; }
    public int quantity { get; set; }
    public Profile profile { get; set; }
    public List<Barcode> barcodes { get; set; }
    public List<Answer> answers { get; set; }
    public bool checked_in { get; set; }
    public bool cancelled { get; set; }
    public bool refunded { get; set; }
    public object affiliate { get; set; }
    public string status { get; set; }
    public string ticket_class_name { get; set; }
    public string event_id { get; set; }
    public string order_id { get; set; }
    public string ticket_class_id { get; set; }
}

public class Order
{
    public Costs costs { get; set; }
    public string resource_uri { get; set; }
    public string id { get; set; }
    public string changed { get; set; }
    public string created { get; set; }
    public string name { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string status { get; set; }
    public object time_remaining { get; set; }
    public string event_id { get; set; }
    public List<Attendee> attendees { get; set; }
}

public class EventBriteObj
{
    public Pagination pagination { get; set; }
    public List<Order> orders { get; set; }
}

public class FlatEventBriteObj
{
    public int object_count { get; set; }
    public int page_number { get; set; }
    public int page_size { get; set; }
    public int page_count { get; set; }

    public string costBasePriceDisplay { get; set; }
    public string costBasePriceCurrency { get; set; }
    public int costBasePriceValue { get; set; }
    public string costBasePriceMajor_value { get; set; }

    public string costEventBriteFeeDisplay { get; set; }
    public string costEventBriteFeeCurrency { get; set; }
    public int costEventBriteFeeValue { get; set; }
    public string costEventBriteFeeMajor_value { get; set; }

    public string costGrossDisplay { get; set; }
    public string costGrossCurrency { get; set; }
    public int costGrossValue { get; set; }
    public string costGrossMajor_value { get; set; }

    public string costPaymentFeeDisplay { get; set; }
    public string costPaymentFeeCurrency { get; set; }
    public int costPaymentFeeValue { get; set; }
    public string costPaymentFeeMajor_value { get; set; }

    public string costTaxDisplay { get; set; }
    public string costTaxCurrency { get; set; }
    public int costTaxValue { get; set; }
    public string costTaxMajor_value { get; set; }

    public string costResource_uri { get; set; }
    public string costId { get; set; }
    public string costChanged { get; set; }
    public string costCreated { get; set; }
    public string costName { get; set; }
    public string costFirst_name { get; set; }
    public string costLast_name { get; set; }
    public string costEmail { get; set; }
    public string costStatus { get; set; }
    public object costTime_remaining { get; set; }
    public string costEvent_id { get; set; }

    public object team { get; set; }

    public string attendeeBasePriceDisplay { get; set; }
    public string attendeeBasePriceCurrency { get; set; }
    public int attendeeBasePriceValue { get; set; }
    public string attendeeBasePriceMajor_value { get; set; }

    public string attendeeEventBriteFeeDisplay { get; set; }
    public string attendeeEventBriteFeeCurrency { get; set; }
    public int attendeeEventBriteFeeValue { get; set; }
    public string attendeeEventBriteFeeMajor_value { get; set; }

    public string attendeeGrossDisplay { get; set; }
    public string attendeeGrossCurrency { get; set; }
    public int attendeeGrossValue { get; set; }
    public string attendeeGrossMajor_value { get; set; }

    public string attendeePaymentFeeDisplay { get; set; }
    public string attendeePaymentFeeCurrency { get; set; }
    public int attendeePaymentFeeValue { get; set; }
    public string attendeePaymentFeeMajor_value { get; set; }

    public string attendeeTaxDisplay { get; set; }
    public string attendeeTaxCurrency { get; set; }
    public int attendeeTaxValue { get; set; }
    public string attendeeTaxMajor_value { get; set; }

    public string attendeeResource_uri { get; set; }
    public string attendeeId { get; set; }
    public string attendeeChanged { get; set; }
    public string attendeeCreated { get; set; }
    public int attendeeQuantity { get; set; }
    public string attendeeFirst_name { get; set; }
    public string attendeeLast_name { get; set; }
    public string attendeeEmail { get; set; }
    public string attendeeName { get; set; }
    public Addresses attendeeAddresses { get; set; }
    public string barcodeStatus { get; set; }
    public string barcode { get; set; }
    public string barcodeCreated { get; set; }
    public int barcodeCheckin_type { get; set; }
    public string barcodeChanged { get; set; }
    public string daType { get; set; }
    public string daValue { get; set; }
    public string daCreated { get; set; }
    public string barcodeCheckin_method { get; set; }    
    public string scType { get; set; }
    public string scValue { get; set; }
    public string scCreated { get; set; }
    public List<Answer> answers { get; set; }
    public bool checked_in { get; set; }
    public bool cancelled { get; set; }
    public bool refunded { get; set; }
    public object affiliate { get; set; }
    public string status { get; set; }
    public string ticket_class_name { get; set; }
    public string event_id { get; set; }
    public string order_id { get; set; }
    public string ticket_class_id { get; set; }
}