public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    public double CalculateTotalCost()
    {
        double subtotal = 0;
        
        foreach (Product product in _products)
        {
            subtotal += product.GetTotalCost();
        }

        double shippingCost = _customer.IsInUSA() ? 5.00 : 35.00;
        
        return subtotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "--- Packing Label ---\n";
        foreach (Product product in _products)
        {
            label += $"Name: {product.GetName()}, ID: {product.GetProductId()}\n";
        }
        return label.TrimEnd();
    }

    public string GetShippingLabel()
    {
        string label = "--- Shipping Label ---\n";
        label += $"Name: {_customer.GetName()}\n";
        label += _customer.GetAddress().GetFullAddress();
        return label;
    }

}