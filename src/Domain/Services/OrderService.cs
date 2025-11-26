using System;
using System.Collections.Generic;

namespace Domain.Services;

using Domain.Entities;

public static class OrderService
{
    // La colección se mantiene privada para proteger su integridad
    // y solo se expone mediante una interfaz de solo lectura.
    private static readonly List<Order> _lastOrders = new List<Order>();
	public static IReadOnlyList<Order> LastOrders => _lastOrders.AsReadOnly();

    // Se construye la orden asignando valores básicos antes de registrarla
    public static Order CreateTerribleOrder(string customer, string product, int qty, decimal price)
	{
		var o = new Order { Id = new Random().Next(1, 9999999), CustomerName = customer, ProductName = product, Quantity = qty, UnitPrice = price };
		_lastOrders.Add(o);
		Infrastructure.Logging.Logger.Log("Created order " + o.Id + " for " + customer);
		return o;
	}
}