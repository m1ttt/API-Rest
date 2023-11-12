var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/productosrest/v1", (List<Producto> productos) =>
{
    float subtotal = 0;
    float totalIva = 0;
    float totalDescuento = 0;
    float total = 0;
    float productoIva = 0;
    float productoDescuento = 0;

    foreach (var producto in productos)
    {
        float precio_producto = producto.Precio * producto.Cantidad;
        subtotal += precio_producto;
        productoIva = precio_producto * (producto.Iva / 100);
        productoDescuento = precio_producto * (producto.Descuento / 100);
        totalIva += productoIva;
        totalDescuento += productoDescuento;
        float precioTotalPorProducto = precio_producto + productoIva - productoDescuento;
        total += precioTotalPorProducto; // Agrega el precio total del producto al total general
    }

    return Results.Ok(new
    {
        Subtotal = subtotal,
        TotalIva = totalIva,
        TotalDescuento = totalDescuento,
        Total = total
    });
})
.WithName("ProductosREST")
.WithOpenApi();

app.Run();