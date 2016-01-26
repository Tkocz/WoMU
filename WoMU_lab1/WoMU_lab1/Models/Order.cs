namespace WoMS_lab1.Models {

using System;
using System.Collections.Generic;

public class Order {
    private readonly List<OrderLine> orderLines = new List<OrderLine>();

    public Customer Customer { get; set; }

    public void AddProduct(Product product) {
        foreach (OrderLine orderLine in orderLines) {
            if (orderLine.Product.ProductID == product.ProductID) {
                orderLine.Quantity++;
                return;
            }
        }

        AddOrderLine(new OrderLine() { Product = product, Quantity = 1 });
    }

    public void AddOrderLine(OrderLine orderLine) {
        if (orderLines.Contains(orderLine))
            throw new Exception("Tried to add same order line twice");

        foreach (OrderLine o in orderLines) {
            if (o.Product.ProductID == orderLine.Product.ProductID)
                throw new Exception("Tried to add new order line with same product");
        }

        orderLines.Add(orderLine);
    }

    public bool RemoveOrderLine(OrderLine orderLine) {
        return orderLines.Remove(orderLine);
    }

    public OrderLine[] GetOrderLines() {
        return orderLines.ToArray();
    }
}

}
