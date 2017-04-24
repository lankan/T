using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

public static class Extensions
{
    public static List<FlatEventBriteObj> FlattenEbObj(this EventBriteObj eObj)
    {
        List<FlatEventBriteObj> lFlat = new List<FlatEventBriteObj>();

        foreach (var vOrder in eObj.orders)
        {
            FlatEventBriteObj fItem = new FlatEventBriteObj();

            foreach (var vAttendee in vOrder.attendees)
            {
                foreach (var vBarcode in vAttendee.barcodes)
                {
                    fItem.object_count = eObj.pagination.object_count;
                    fItem.page_number = eObj.pagination.page_number;
                    fItem.page_size = eObj.pagination.page_size;
                    fItem.page_count = eObj.pagination.page_count;

                    fItem.costBasePriceDisplay = vOrder.costs.base_price.display;
                    fItem.costBasePriceCurrency = vOrder.costs.base_price.currency;
                    fItem.costBasePriceValue = vOrder.costs.base_price.value;
                    fItem.costBasePriceMajor_value = vOrder.costs.base_price.major_value;

                    fItem.costEventBriteFeeDisplay = vOrder.costs.eventbrite_fee.display;
                    fItem.costEventBriteFeeCurrency = vOrder.costs.eventbrite_fee.currency;
                    fItem.costEventBriteFeeValue = vOrder.costs.eventbrite_fee.value;
                    fItem.costEventBriteFeeMajor_value = vOrder.costs.eventbrite_fee.major_value;

                    fItem.costGrossDisplay = vOrder.costs.gross.display;
                    fItem.costGrossCurrency = vOrder.costs.gross.currency;
                    fItem.costGrossValue = vOrder.costs.gross.value;
                    fItem.costGrossMajor_value = vOrder.costs.gross.major_value;

                    fItem.costPaymentFeeDisplay = vOrder.costs.payment_fee.display;
                    fItem.costPaymentFeeCurrency = vOrder.costs.payment_fee.currency;
                    fItem.costPaymentFeeValue = vOrder.costs.payment_fee.value;
                    fItem.costPaymentFeeMajor_value = vOrder.costs.payment_fee.major_value;

                    fItem.costTaxDisplay = vOrder.costs.tax.display;
                    fItem.costTaxCurrency = vOrder.costs.tax.currency;
                    fItem.costTaxValue = vOrder.costs.tax.value;
                    fItem.costTaxMajor_value = vOrder.costs.tax.major_value;

                    fItem.costResource_uri = vOrder.resource_uri;
                    fItem.costId = vOrder.id;
                    fItem.costChanged = vOrder.changed;
                    fItem.costCreated = vOrder.created;
                    fItem.costName = vOrder.name;
                    fItem.costFirst_name = vOrder.first_name;
                    fItem.costLast_name = vOrder.last_name;
                    fItem.costEmail = vOrder.email;
                    fItem.costStatus = vOrder.status;
                    fItem.costTime_remaining = vOrder.time_remaining;
                    fItem.costEvent_id = vOrder.event_id;

                    fItem.team = vAttendee.team;

                    fItem.attendeeBasePriceDisplay = vAttendee.costs.base_price.display;
                    fItem.attendeeBasePriceCurrency = vAttendee.costs.base_price.currency;
                    fItem.attendeeBasePriceValue = vAttendee.costs.base_price.value;
                    fItem.attendeeBasePriceMajor_value = vAttendee.costs.base_price.major_value;

                    fItem.attendeeEventBriteFeeDisplay = vAttendee.costs.eventbrite_fee.display;
                    fItem.attendeeEventBriteFeeCurrency = vAttendee.costs.eventbrite_fee.currency;
                    fItem.attendeeEventBriteFeeValue = vAttendee.costs.eventbrite_fee.value;
                    fItem.attendeeEventBriteFeeMajor_value = vAttendee.costs.eventbrite_fee.major_value;

                    fItem.attendeeGrossDisplay = vAttendee.costs.gross.display;
                    fItem.attendeeGrossCurrency = vAttendee.costs.gross.currency;
                    fItem.attendeeGrossValue = vAttendee.costs.gross.value;
                    fItem.attendeeGrossMajor_value = vAttendee.costs.gross.major_value;

                    fItem.attendeePaymentFeeDisplay = vAttendee.costs.payment_fee.display;
                    fItem.attendeePaymentFeeCurrency = vAttendee.costs.payment_fee.currency;
                    fItem.attendeePaymentFeeValue = vAttendee.costs.payment_fee.value;
                    fItem.attendeePaymentFeeMajor_value = vAttendee.costs.payment_fee.major_value;

                    fItem.attendeeTaxDisplay = vAttendee.costs.tax.display;
                    fItem.attendeeTaxCurrency = vAttendee.costs.tax.currency;
                    fItem.attendeeTaxValue = vAttendee.costs.tax.value;
                    fItem.attendeeTaxMajor_value = vAttendee.costs.tax.major_value;

                    fItem.attendeeResource_uri = vAttendee.resource_uri;
                    fItem.attendeeId = vAttendee.id;
                    fItem.attendeeChanged = vAttendee.changed;
                    fItem.attendeeCreated = vAttendee.created;
                    fItem.attendeeQuantity = vAttendee.quantity;
                    fItem.attendeeFirst_name = vAttendee.profile.first_name;
                    fItem.attendeeLast_name = vAttendee.profile.last_name;
                    fItem.attendeeEmail = vAttendee.profile.email;
                    fItem.attendeeName = vAttendee.profile.name;
                    fItem.attendeeAddresses = vAttendee.profile.addresses;

                    fItem.barcodeStatus = vBarcode.status;
                    fItem.barcode = vBarcode.barcode;
                    fItem.barcodeCreated = vBarcode.created;
                    fItem.barcodeCheckin_type = vBarcode.checkin_type;
                    fItem.barcodeChanged = vBarcode.changed;

                    if (vBarcode.dynamic_association != null)
                    {
                        fItem.daType = vBarcode.dynamic_association.type;
                        fItem.daValue = vBarcode.dynamic_association.value;
                        fItem.daCreated = vBarcode.dynamic_association.created;
                    }

                    fItem.barcodeCheckin_method = vBarcode.checkin_method;

                    if (vBarcode.secondary_code != null)
                    {
                        fItem.scType = vBarcode.secondary_code.type;
                        fItem.scValue = vBarcode.secondary_code.value;
                        fItem.scCreated = vBarcode.secondary_code.created;
                    }

                    fItem.answers = vAttendee.answers;
                    fItem.checked_in = vAttendee.checked_in;
                    fItem.cancelled = vAttendee.cancelled;
                    fItem.refunded = vAttendee.refunded;
                    fItem.affiliate = vAttendee.affiliate;
                    fItem.status = vAttendee.status;
                    fItem.ticket_class_name = vAttendee.ticket_class_name;
                    fItem.event_id = vAttendee.event_id;
                    fItem.order_id = vAttendee.order_id;
                    fItem.ticket_class_id = vAttendee.ticket_class_id;

                    lFlat.Add(fItem);
                }
            }
        }

        return lFlat;
    }

    public static DataTable ToDataTable<T>(this T classItem, List<string> excludedColumns = null)
    {
        DataTable dTbl = new DataTable(typeof(T).Name);

        //get all the properties of the class T
        PropertyInfo[] arrPi = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        //loop through each properties in the class and add it as columns
        foreach (PropertyInfo pi in arrPi)
        { dTbl.Columns.Add(pi.Name); }

        //creating the row of type T values
        var values = new object[arrPi.Length];
        for (int i = 0; i < arrPi.Length; i++)
        {
            //populating cells within the row per column
            values[i] = arrPi[i].GetValue(classItem, null);
        }

        dTbl.Rows.Add(values);

        // if excluded columns list has been provided then delete these fields from the data table
        if (excludedColumns != null)
        {
            foreach (string colName in excludedColumns)
                dTbl.Columns.Remove(colName);
        }

        return dTbl;
    }

    public static DataTable ToDataTable<T>(this List<T> classList, List<string> excludedColumns = null)
    {
        DataTable dTbl = new DataTable(typeof(T).Name);

        //get all the properties of the class T
        PropertyInfo[] arrPi = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        //loop through each properties in the class and add it as columns
        foreach (PropertyInfo pi in arrPi)
        { dTbl.Columns.Add(pi.Name); }

        //setting the contents of the table
        foreach (T items in classList)
        {
            //creating the row of type T values
            var values = new object[arrPi.Length];
            for (int i = 0; i < arrPi.Length; i++)
            {
                //populating cells within the row per column
                values[i] = arrPi[i].GetValue(items, null);
            }

            dTbl.Rows.Add(values);
        }

        // if excluded columns list has been provided then delete these fields from the data table
        if (excludedColumns != null)
        {
            foreach (string colName in excludedColumns)
                dTbl.Columns.Remove(colName);
        }

        return dTbl;
    }

    public static string ToCSV(this DataTable table)
    {
        var result = new StringBuilder();
        for (int i = 0; i < table.Columns.Count; i++)
        {
            result.Append(table.Columns[i].ColumnName);
            result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
        }

        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.Append(row[i].ToString());
                result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// Flattens an object hierarchy.
    /// </summary>
    /// <param name="rootLevel">The root level in the hierarchy.</param>
    /// <param name="nextLevel">A function that returns the next level below a given item.</param>
    /// <returns><![CDATA[An IEnumerable<T> containing every item from every level in the hierarchy.]]></returns>
    public static IEnumerable<T> Flatten<T>(this IEnumerable<T> rootLevel, Func<T, IEnumerable<T>> nextLevel)
    {
        List<T> accumulation = new List<T>();
        accumulation.AddRange(rootLevel);
        flattenLevel<T>(accumulation, rootLevel, nextLevel);
        return accumulation;
    }

    /// <summary>
    /// Recursive helper method that traverses a hierarchy, accumulating items along the way.
    /// </summary>
    /// <param name="accumulation">A collection in which to accumulate items.</param>
    /// <param name="currentLevel">The current level we are traversing.</param>
    /// <param name="nextLevel">A function that returns the next level below a given item.</param>
    private static void flattenLevel<T>(List<T> accumulation, IEnumerable<T> currentLevel, Func<T, IEnumerable<T>> nextLevel)
    {
        foreach (T item in currentLevel)
        {
            accumulation.AddRange(currentLevel);
            flattenLevel<T>(accumulation, nextLevel(item), nextLevel);
        }
    }

    public static bool Export<T>(this List<T> listClass, string fullPath)
    {
        bool bStatus = false;

        try
        {
            DataTable dt = listClass.ToDataTable();
            string strContent = dt.ToCSV();

            using (StreamWriter sw = new StreamWriter(fullPath))
            { sw.WriteLine(strContent); }

            bStatus = true;
        }
        catch
        { bStatus = false; }

        return bStatus;
    }
}
